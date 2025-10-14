/**
 * Section Modal Management - Simplified & Dynamic
 * Backend'den HTML partial view alarak modal oluşturur
 */

const SectionModal = (function () {
  "use strict";

  // Modal state
  let currentSection = {
    id: 0,
    pageId: 0,
    type: 0,
    templateId: null,
    status: 1,
  };

  let availablePages = [];

  /**
   * Show section modal - Backend'den HTML alır
   */
  async function show(sectionId = 0, pageId = 0) {
    currentSection = {
      id: sectionId,
      pageId: pageId,
      type: 0,
      templateId: null,
      status: 1,
    };

    try {
      // Load modal HTML from backend
      const html = await ContentServices.getSectionModal(
        sectionId,
        pageId
      );

      // Remove existing modal
      const existingModal = document.getElementById(
        "sectionModalOverlay"
      );
      if (existingModal) {
        existingModal.remove();
      }

      // Create modal overlay
      const modalOverlay = document.createElement("div");
      modalOverlay.id = "sectionModalOverlay";
      modalOverlay.className =
        "fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50 p-4";
      modalOverlay.innerHTML = html;

      document.body.appendChild(modalOverlay);
      document.body.style.overflow = "hidden";

      // Initialize current section from hidden fields
      const sectionIdInput = document.getElementById("sectionId");
      const pageIdInput = document.getElementById("pageId");
      const sectionTypeSelect =
        document.getElementById("sectionType");

      if (sectionIdInput) {
        currentSection.id = parseInt(sectionIdInput.value) || 0;
      }
      if (pageIdInput) {
        currentSection.pageId = parseInt(pageIdInput.value) || 0;
      }
      if (sectionTypeSelect) {
        currentSection.type = parseInt(sectionTypeSelect.value) || 0;
      }
    } catch (error) {
      console.error("Error loading section modal:", error);
      alert("Error loading modal. Please try again.");
    }
  }

  /**
   * Close modal
   */
  function close() {
    const modal = document.getElementById("sectionModalOverlay");
    if (modal) {
      modal.remove();
      document.body.style.overflow = "";
    }
  }

  /**
   * Handle page change
   */
  function handlePageChange(pageId) {
    currentSection.pageId = parseInt(pageId) || 0;
  }

  /**
   * Handle section type change - Load templates from backend
   */
  async function handleSectionTypeChange(sectionType) {
    currentSection.type = parseInt(sectionType);

    const templateSelect = document.getElementById("sectionTemplate");

    if (!templateSelect) {
      console.warn("Template select element not found");
      return;
    }

    // Clear existing options except the first one
    templateSelect.innerHTML =
      '<option value="">Select a template...</option>';

    if (sectionType === "0" || !sectionType) {
      templateSelect.disabled = true;
      return;
    }

    // Show loading state
    templateSelect.disabled = true;
    templateSelect.innerHTML =
      '<option value="">Loading templates...</option>';

    try {
      // Load templates list from backend
      const result = await ContentServices.getTemplatesBySectionType(
        sectionType
      );

      if (
        result.success &&
        result.templates &&
        result.templates.length > 0
      ) {
        templateSelect.innerHTML =
          '<option value="">Select a template...</option>';

        result.templates.forEach((template) => {
          const option = document.createElement("option");
          option.value = template.id;
          option.textContent = template.name;
          templateSelect.appendChild(option);
        });

        templateSelect.disabled = false;
      } else {
        templateSelect.innerHTML =
          '<option value="">No templates available</option>';
      }
    } catch (error) {
      console.error("Error loading templates:", error);
      templateSelect.innerHTML =
        '<option value="">Error loading templates</option>';
    }
  }

  /**
   * Handle template change - Load section items UI as partial view HTML
   */
  async function handleTemplateChange(templateId) {
    currentSection.templateId = parseInt(templateId) || null;

    if (!templateId) {
      // Clear section items if no template selected
      clearSectionItemsUI();
      return;
    }

    try {
      // Load section items UI HTML from backend (partial view)
      const html = await ContentServices.getSectionItemsUI(
        templateId
      );

      // Insert HTML into container
      const container = document.getElementById(
        "sectionItemsContainer"
      );
      if (container) {
        container.innerHTML = html;

        // Parse and store template configuration from script tag
        const configScript = document.getElementById(
          "templateConfiguration"
        );
        if (configScript) {
          currentSection.templateConfiguration = JSON.parse(
            configScript.textContent
          );
        }

        // Initialize default items if configured
        initializeDefaultItems();

        // Initialize plugins (SortableJS, etc.)
        initializePlugins();

        // Update UI counters
        updateItemsCountBadge();
      } else {
        console.error("Section items container not found");
      }
    } catch (error) {
      console.error("Error loading section items UI:", error);
      clearSectionItemsUI();
    }
  }

  /**
   * Select template (for backward compatibility)
   */
  function selectTemplate(templateId) {
    handleTemplateChange(templateId);
  }

  /**
   * Save section
   */
  async function save() {
    // Validate
    if (!currentSection.pageId) {
      alert("Please select a page");
      return;
    }

    if (!currentSection.type) {
      alert("Please select a section type");
      return;
    }

    try {
      const sectionData = {
        Id: currentSection.id,
        PageId: currentSection.pageId,
        Type: currentSection.type,
        TemplateId: currentSection.templateId,
        Status: parseInt(
          document.getElementById("modalSectionStatus").value
        ),
        SortOrder: 1,
        Attributes: "{}",
        Configure: "{}",
        SectionItems: [],
        Translations: [],
      };

      const result = await ContentServices.saveSection(sectionData);

      if (result.success) {
        close();
        location.reload(); // Refresh page to show new section
      } else {
        alert(
          "Error saving section: " +
            (result.message || "Unknown error")
        );
      }
    } catch (error) {
      console.error("Save error:", error);
      alert("Error saving section. Please try again.");
    }
  }

  /**
   * Load available pages
   */
  async function loadAvailablePages() {
    try {
      const result = await ContentServices.getAvailablePages();
      if (result.success) {
        availablePages = result.pages || [];
      }
    } catch (error) {
      console.error("Error loading pages:", error);
      availablePages = [];
    }
  }

  // ==================== SECTION ITEMS UI RENDERING ====================
  // SOLID: Strategy Pattern - Different rendering for different configurations

  let currentConfiguration = null;
  let sectionItems = [];

  /**
   * Render section items UI based on template configuration
   */
  function renderSectionItemsUI(configuration) {
    currentConfiguration = configuration;
    const itemConfig = configuration.itemConfiguration;

    const container = document.getElementById(
      "sectionItemsContainer"
    );
    if (!container) {
      console.warn("Section items container not found");
      return;
    }

    // Clear existing items
    sectionItems = [];

    // Build the UI
    let html = `
            <div class="bg-blue-50 rounded-lg p-4 border border-blue-200">
                <h4 class="font-medium text-slate-800 mb-4 flex items-center">
                    <i class="fas fa-${
                      itemConfig.uiConfiguration.iconClass || "images"
                    } mr-2 text-blue-600"></i> 
                    Section Items
                    <span id="itemsCountBadge" class="ml-2 px-2 py-0.5 bg-blue-100 text-blue-800 text-xs rounded">
                        0 items
                    </span>
                    ${
                      itemConfig.minItems
                        ? `<span class="ml-2 text-xs text-slate-500">(Min: ${itemConfig.minItems})</span>`
                        : ""
                    }
                    ${
                      itemConfig.maxItems
                        ? `<span class="ml-2 text-xs text-slate-500">(Max: ${itemConfig.maxItems})</span>`
                        : ""
                    }
                </h4>
                
                <div id="itemsGrid" class="${getLayoutClass(
                  itemConfig.uiConfiguration.layout,
                  itemConfig.uiConfiguration.columns
                )}">
                    <!-- Items will be added here -->
                </div>
                
                ${
                  itemConfig.allowDynamicItems &&
                  (!itemConfig.maxItems ||
                    sectionItems.length < itemConfig.maxItems)
                    ? `
                    <div class="mt-4 text-center">
                        <button type="button" onclick="SectionModal.addSectionItem()" 
                            class="py-2 px-4 bg-blue-600 hover:bg-blue-700 text-white rounded-lg text-sm transition-colors">
                            <i class="fas fa-plus mr-2"></i> ${
                              itemConfig.uiConfiguration
                                .addButtonText || "Add Item"
                            }
                        </button>
                    </div>
                `
                    : ""
                }
            </div>
        `;

    container.innerHTML = html;

    // Create default items
    for (let i = 0; i < itemConfig.defaultItems; i++) {
      addSectionItem();
    }
  }

  /**
   * Get CSS classes for layout
   */
  function getLayoutClass(layout, columns = 3) {
    switch (layout) {
      case "grid":
        return `grid grid-cols-1 md:grid-cols-${columns} gap-4`;
      case "list":
        return "space-y-4";
      case "carousel":
        return "grid grid-cols-1 md:grid-cols-3 gap-4";
      default:
        return "space-y-4";
    }
  }

  /**
   * Add a new section item
   */
  function addSectionItem() {
    if (!currentConfiguration) return;

    const itemConfig = currentConfiguration.itemConfiguration;

    // Check max items limit
    if (
      itemConfig.maxItems &&
      sectionItems.length >= itemConfig.maxItems
    ) {
      alert(`Maximum ${itemConfig.maxItems} items allowed`);
      return;
    }

    const itemId = Date.now(); // Temporary ID
    const newItem = {
      id: itemId,
      tempId: itemId,
      sortOrder: sectionItems.length + 1,
      data: {},
    };

    sectionItems.push(newItem);
    renderSectionItem(newItem, sectionItems.length - 1);
    updateItemsCount();
    updateAddButtonVisibility();
  }

  /**
   * Render a single section item card
   */
  function renderSectionItem(item, index) {
    const itemConfig = currentConfiguration.itemConfiguration;
    const itemsGrid = document.getElementById("itemsGrid");

    const itemCard = document.createElement("div");
    itemCard.className =
      "section-item-card border border-slate-200 rounded-lg p-4 bg-white";
    itemCard.dataset.itemId = item.tempId;

    let fieldsHtml = "";
    itemConfig.fields.forEach((field) => {
      fieldsHtml += renderField(field, item, index);
    });

    itemCard.innerHTML = `
            <div class="flex items-center justify-between mb-3">
                <div class="flex items-center">
                    ${
                      itemConfig.uiConfiguration.showReorder
                        ? `
                        <div class="drag-handle cursor-move mr-2 p-2 text-slate-400 hover:text-slate-600">
                            <i class="fas fa-grip-vertical"></i>
                        </div>
                    `
                        : ""
                    }
                    <span class="text-sm font-medium text-slate-700">Item #${
                      index + 1
                    }</span>
                </div>
                ${
                  itemConfig.allowDynamicItems
                    ? `
                    <button type="button" onclick="SectionModal.removeSectionItem(${item.tempId})" 
                        class="text-red-600 hover:text-red-800 text-sm">
                        <i class="fas fa-trash"></i>
                    </button>
                `
                    : ""
                }
            </div>
            <div class="space-y-3">
                ${fieldsHtml}
            </div>
        `;

    itemsGrid.appendChild(itemCard);

    // Initialize sortable if reorder is enabled
    if (
      itemConfig.uiConfiguration.showReorder &&
      !itemsGrid.sortableInitialized
    ) {
      initializeSortable(itemsGrid);
    }
  }

  /**
   * Render a single field based on type
   */
  function renderField(field, item, itemIndex) {
    const fieldId = `item_${item.tempId}_${field.name}`;
    const value = item.data[field.name] || field.defaultValue || "";

    let fieldHtml = "";

    switch (field.type) {
      case "text":
      case "url":
        fieldHtml = `
                    <div>
                        <label class="block text-xs font-medium text-slate-700 mb-1">
                            ${field.label} ${
          field.required ? '<span class="text-red-500">*</span>' : ""
        }
                        </label>
                        <input type="${field.type}" 
                            id="${fieldId}"
                            class="w-full px-3 py-2 border border-slate-300 rounded-lg text-sm"
                            placeholder="${field.placeholder || ""}"
                            ${
                              field.maxLength
                                ? `maxlength="${field.maxLength}"`
                                : ""
                            }
                            ${field.required ? "required" : ""}
                            value="${value}"
                            onchange="SectionModal.updateItemField(${
                              item.tempId
                            }, '${field.name}', this.value)">
                    </div>
                `;
        break;

      case "textarea":
        fieldHtml = `
                    <div>
                        <label class="block text-xs font-medium text-slate-700 mb-1">
                            ${field.label} ${
          field.required ? '<span class="text-red-500">*</span>' : ""
        }
                        </label>
                        <textarea 
                            id="${fieldId}"
                            class="w-full px-3 py-2 border border-slate-300 rounded-lg text-sm"
                            placeholder="${field.placeholder || ""}"
                            ${
                              field.maxLength
                                ? `maxlength="${field.maxLength}"`
                                : ""
                            }
                            ${field.required ? "required" : ""}
                            rows="3"
                            onchange="SectionModal.updateItemField(${
                              item.tempId
                            }, '${
          field.name
        }', this.value)">${value}</textarea>
                    </div>
                `;
        break;

      case "checkbox":
        fieldHtml = `
                    <div class="flex items-center">
                        <input type="checkbox" 
                            id="${fieldId}"
                            class="mr-2"
                            ${
                              value === "true" || value === true
                                ? "checked"
                                : ""
                            }
                            onchange="SectionModal.updateItemField(${
                              item.tempId
                            }, '${field.name}', this.checked)">
                        <label class="text-xs font-medium text-slate-700">${
                          field.label
                        }</label>
                    </div>
                `;
        break;

      case "image":
        fieldHtml = `
                    <div>
                        <label class="block text-xs font-medium text-slate-700 mb-1">
                            ${field.label} ${
          field.required ? '<span class="text-red-500">*</span>' : ""
        }
                        </label>
                        <div class="flex items-center space-x-2">
                            <input type="file" 
                                id="${fieldId}"
                                class="hidden"
                                accept="image/*"
                                onchange="SectionModal.handleImageUpload(${
                                  item.tempId
                                }, '${field.name}', this)">
                            <button type="button" 
                                onclick="document.getElementById('${fieldId}').click()"
                                class="px-3 py-2 bg-slate-200 hover:bg-slate-300 text-slate-700 rounded-lg text-xs">
                                <i class="fas fa-upload mr-1"></i> Choose Image
                            </button>
                            ${
                              value
                                ? `<span class="text-xs text-green-600"><i class="fas fa-check mr-1"></i> Uploaded</span>`
                                : ""
                            }
                        </div>
                        ${
                          value
                            ? `<img src="${value}" class="mt-2 max-h-20 rounded" alt="Preview">`
                            : ""
                        }
                    </div>
                `;
        break;

      case "select":
        fieldHtml = `
                    <div>
                        <label class="block text-xs font-medium text-slate-700 mb-1">
                            ${field.label} ${
          field.required ? '<span class="text-red-500">*</span>' : ""
        }
                        </label>
                        <select 
                            id="${fieldId}"
                            class="w-full px-3 py-2 border border-slate-300 rounded-lg text-sm"
                            ${field.required ? "required" : ""}
                            onchange="SectionModal.updateItemField(${
                              item.tempId
                            }, '${field.name}', this.value)">
                            <option value="">Select...</option>
                            ${
                              field.options
                                ? field.options
                                    .map(
                                      (opt) =>
                                        `<option value="${opt}" ${
                                          value === opt
                                            ? "selected"
                                            : ""
                                        }>${opt}</option>`
                                    )
                                    .join("")
                                : ""
                            }
                        </select>
                    </div>
                `;
        break;

      default:
        fieldHtml = `<input type="text" value="${value}" class="w-full px-3 py-2 border rounded">`;
    }

    return fieldHtml;
  }

  /**
   * Update item field value
   */
  function updateItemField(itemTempId, fieldName, value) {
    const item = sectionItems.find((i) => i.tempId === itemTempId);
    if (item) {
      item.data[fieldName] = value;
    }
  }

  /**
   * Handle image upload for section item
   */
  async function handleImageUpload(
    itemTempId,
    fieldName,
    inputElement
  ) {
    const file = inputElement.files[0];
    if (!file) return;

    try {
      // TODO: Implement actual upload
      // const result = await ContentServices.uploadImage(file, 'section-item');
      // if (result.success) {
      //     updateItemField(itemTempId, fieldName, result.url);
      //     // Re-render the item to show preview
      //     const index = sectionItems.findIndex(i => i.tempId === itemTempId);
      //     if (index >= 0) {
      //         document.querySelector(`[data-item-id="${itemTempId}"]`).remove();
      //         renderSectionItem(sectionItems[index], index);
      //     }
      // }

      alert("Image upload will be implemented");
    } catch (error) {
      console.error("Error uploading image:", error);
      alert("Error uploading image");
    }
  }

  /**
   * Remove a section item
   */
  function removeSectionItem(itemTempId) {
    const itemConfig = currentConfiguration.itemConfiguration;

    // Check min items limit
    if (
      itemConfig.minItems &&
      sectionItems.length <= itemConfig.minItems
    ) {
      alert(`Minimum ${itemConfig.minItems} items required`);
      return;
    }

    sectionItems = sectionItems.filter(
      (i) => i.tempId !== itemTempId
    );

    // Remove from DOM
    const card = document.querySelector(
      `[data-item-id="${itemTempId}"]`
    );
    if (card) {
      card.remove();
    }

    updateItemsCount();
    updateAddButtonVisibility();
  }

  /**
   * Update items count badge
   */
  function updateItemsCount() {
    const badge = document.getElementById("itemsCountBadge");
    if (badge) {
      badge.textContent = `${sectionItems.length} item${
        sectionItems.length !== 1 ? "s" : ""
      }`;
    }
  }

  /**
   * Update add button visibility based on max items
   */
  function updateAddButtonVisibility() {
    // Re-render container to update button
    if (currentConfiguration) {
      const container = document.getElementById(
        "sectionItemsContainer"
      );
      const itemsGrid = document.getElementById("itemsGrid");
      if (container && itemsGrid) {
        const savedItems = itemsGrid.innerHTML;
        renderSectionItemsUI(currentConfiguration);
        document.getElementById("itemsGrid").innerHTML = savedItems;
      }
    }
  }

  /**
   * Initialize sortable for reordering
   */
  function initializeSortable(element) {
    if (typeof Sortable !== "undefined") {
      new Sortable(element, {
        animation: 150,
        handle: ".drag-handle",
        onEnd: function (evt) {
          // Update sort order
          const reorderedItems = [];
          document
            .querySelectorAll(".section-item-card")
            .forEach((card, index) => {
              const itemId = parseInt(card.dataset.itemId);
              const item = sectionItems.find(
                (i) => i.tempId === itemId
              );
              if (item) {
                item.sortOrder = index + 1;
                reorderedItems.push(item);
              }
            });
          sectionItems = reorderedItems;
        },
      });
      element.sortableInitialized = true;
    }
  }

  /**
   * Clear section items UI
   */
  function clearSectionItemsUI() {
    const container = document.getElementById(
      "sectionItemsContainer"
    );
    if (container) {
      container.innerHTML = `
        <div class="bg-slate-50 rounded-lg p-6 text-center text-slate-500">
          <i class="fas fa-info-circle text-2xl mb-2"></i>
          <p class="text-sm">Select a template to configure section items</p>
        </div>
      `;
    }
    sectionItems = [];
    currentSection.templateConfiguration = null;
  }

  /**
   * Initialize default items based on template configuration
   */
  function initializeDefaultItems() {
    const config = currentSection.templateConfiguration;
    if (!config || !config.itemConfiguration) return;

    const defaultCount = config.itemConfiguration.defaultItems || 0;
    if (defaultCount > 0) {
      for (let i = 0; i < defaultCount; i++) {
        addSectionItem();
      }
    }
  }

  /**
   * Initialize plugins (SortableJS for drag-drop)
   */
  function initializePlugins() {
    const config = currentSection.templateConfiguration;
    if (
      !config ||
      !config.itemConfiguration ||
      !config.itemConfiguration.uiConfiguration
    )
      return;

    const uiConfig = config.itemConfiguration.uiConfiguration;
    if (uiConfig.showReorder) {
      const itemsGrid = document.getElementById("itemsGrid");
      if (itemsGrid && typeof Sortable !== "undefined") {
        Sortable.create(itemsGrid, {
          animation: 150,
          handle: ".drag-handle",
          onEnd: function () {
            updateItemNumbers();
            updateItemsCountBadge();
          },
        });
      }
    }
  }

  /**
   * Add new section item by cloning template
   */
  function addSectionItem() {
    const template = document.getElementById("sectionItemTemplate");
    const itemsGrid = document.getElementById("itemsGrid");

    if (!template || !itemsGrid) {
      console.error("Template or grid not found");
      return;
    }

    // Clone template
    const clone = template.content.cloneNode(true);
    const itemCard = clone.querySelector(".section-item-card");

    // Generate unique ID
    const itemId =
      "item-" +
      Date.now() +
      "-" +
      Math.random().toString(36).substr(2, 9);
    itemCard.setAttribute("data-item-id", itemId);

    // Add to grid
    itemsGrid.appendChild(clone);

    // Update UI
    updateItemNumbers();
    updateItemsCountBadge();
    updateAddButtonVisibility();
  }

  /**
   * Remove section item
   */
  function removeSectionItem(button) {
    const itemCard = button.closest(".section-item-card");
    if (itemCard) {
      itemCard.remove();
      updateItemNumbers();
      updateItemsCountBadge();
      updateAddButtonVisibility();
    }
  }

  /**
   * Update item field value (for data collection)
   */
  function updateItemField(input) {
    // This will be used when saving section data
    console.log("Field updated:", input.name, "=", input.value);
  }

  /**
   * Update item numbers in UI
   */
  function updateItemNumbers() {
    const items = document.querySelectorAll(".section-item-card");
    items.forEach((item, index) => {
      const numberSpan = item.querySelector(".item-number");
      if (numberSpan) {
        numberSpan.textContent = `Item #${index + 1}`;
      }
    });
  }

  /**
   * Update items count badge
   */
  function updateItemsCountBadge() {
    const badge = document.getElementById("itemsCountBadge");
    if (badge) {
      const count = document.querySelectorAll(
        ".section-item-card"
      ).length;
      badge.textContent = `${count} item${count !== 1 ? "s" : ""}`;
    }
  }

  /**
   * Update add button visibility based on max items limit
   */
  function updateAddButtonVisibility() {
    const config = currentSection.templateConfiguration;
    if (!config || !config.itemConfiguration) return;

    const maxItems = config.itemConfiguration.maxItems;
    const addButton = document.getElementById("addItemButton");

    if (addButton && maxItems) {
      const currentCount = document.querySelectorAll(
        ".section-item-card"
      ).length;
      addButton.style.display =
        currentCount >= maxItems ? "none" : "block";
    }
  }

  /**
   * Open image upload modal (placeholder)
   */
  function openImageUpload(button) {
    alert("Image upload will be implemented soon!");
  }

  /**
   * Remove image from field (placeholder)
   */
  function removeImage(button) {
    const container = button.closest(".image-upload-container");
    if (container) {
      const preview = container.querySelector(".image-preview");
      const input = container.querySelector(".image-path-input");
      if (preview) preview.classList.add("hidden");
      if (input) input.value = "";
    }
  }

  // Public API
  return {
    show,
    close,
    handlePageChange,
    handleSectionTypeChange,
    handleTemplateChange,
    selectTemplate,
    save,
    loadAvailablePages,
    // Section items management
    addSectionItem,
    removeSectionItem,
    updateItemField,
    openImageUpload,
    removeImage,
  };
})();

// Make globally available
window.SectionModal = SectionModal;
