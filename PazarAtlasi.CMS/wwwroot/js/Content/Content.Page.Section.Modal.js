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
    console.log("handleTemplateChange called with templateId:", templateId);
    
    currentSection.templateId = parseInt(templateId) || null;

    if (!templateId) {
      console.log("No template ID provided, clearing UI");
      // Clear section items if no template selected
      clearSectionItemsUI();
      return;
    }

    try {
      // Load section items list as HTML from backend (partial view)
      const html = await ContentServices.getSectionItemsList(
        templateId,
        currentSection.id
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
          try {
            currentSection.templateConfiguration = JSON.parse(
              configScript.textContent
            );
            console.log("Template configuration loaded:", currentSection.templateConfiguration);
          } catch (parseError) {
            console.error("Error parsing template configuration:", parseError);
          }
        }

        // Initialize plugins (SortableJS, etc.)
        initializePlugins();

        // Update UI counters
        updateItemsCountBadge();
        
      } else {
      }
    } catch (error) {
      clearSectionItemsUI();
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
    // Clear stored data
    window.sectionItemsData = {};
    currentSection.templateConfiguration = null;
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
      // Collect section items data from form fields
      const sectionItems = [];
      const itemCards = document.querySelectorAll(".section-item-card");
      
      itemCards.forEach((card, index) => {
        const itemId = card.dataset.itemId;
        const itemData = window.sectionItemsData?.[itemId] || {};
        
        // Collect nested items
        const nestedItems = [];
        const nestedCards = card.querySelectorAll(".nested-item-card");
        nestedCards.forEach((nestedCard, nestedIndex) => {
          const nestedId = nestedCard.dataset.nestedId;
          const nestedData = itemData.nestedItems?.[nestedId] || {};
          
          nestedItems.push({
            TempId: nestedId,
            SortOrder: nestedIndex + 1,
            Data: nestedData,
            Type: 0, // Will be set by backend based on template
            Status: 1
          });
        });

        sectionItems.push({
          TempId: itemId,
          SortOrder: index + 1,
          Data: itemData,
          NestedItems: nestedItems,
          Type: 0, // Will be set by backend based on template
          Status: 1
        });
      });

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
        SectionItems: sectionItems,
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

  // ==================== SECTION ITEMS UI MANAGEMENT ====================
  // Simplified - Most UI is now generated by backend partial views

  /**
   * Add new section item - Load from backend as partial view
   */
  async function addSectionItem() {
    if (!currentSection.templateId) {
      console.warn("No template selected");
      return;
    }

    try {
      // Get current configuration
      const config = currentSection.templateConfiguration;
      if (!config || !config.itemConfiguration) {
        console.warn("No item configuration found");
        return;
      }

      const itemConfig = config.itemConfiguration;

      // Check max items limit
      const currentItemsCount = document.querySelectorAll(
        ".section-item-card"
      ).length;
      if (itemConfig.maxItems && currentItemsCount >= itemConfig.maxItems) {
        alert(`Maximum ${itemConfig.maxItems} items allowed`);
        return;
      }

      // Get section item form from backend
      const formHtml = await ContentServices.getSectionItemForm(
        currentSection.templateId
      );

      // Create a new item card and insert the form
      const itemsGrid = document.getElementById("itemsGrid");
      if (!itemsGrid) {
        console.error("Items grid not found");
        return;
      }

      const itemId = Date.now(); // Temporary ID
      const itemCard = document.createElement("div");
      itemCard.className =
        "section-item-card border border-slate-200 rounded-lg p-4 bg-white";
      itemCard.dataset.itemId = itemId;

      itemCard.innerHTML = `
        <div class="flex items-center justify-between mb-3">
          <div class="flex items-center">
            ${
              itemConfig.uiConfiguration?.showReorder
                ? `
              <div class="drag-handle cursor-move mr-2 p-2 text-slate-400 hover:text-slate-600">
                <i class="fas fa-grip-vertical"></i>
              </div>
            `
                : ""
            }
            <span class="text-sm font-medium text-slate-700 item-number">Item #${
              currentItemsCount + 1
            }</span>
          </div>
          ${
            itemConfig.allowDynamicItems
              ? `
            <button type="button" onclick="SectionModal.removeSectionItem('${itemId}')" 
              class="text-red-600 hover:text-red-800 text-sm">
              <i class="fas fa-trash"></i>
            </button>
          `
              : ""
          }
        </div>
        <div class="space-y-3">
          ${formHtml}
        </div>
      `;

      itemsGrid.appendChild(itemCard);

      // Update UI
      updateItemNumbers();
      updateItemsCountBadge();
      updateAddButtonVisibility();

      // Initialize sortable if needed
      if (itemConfig.uiConfiguration?.showReorder && !itemsGrid.sortableInitialized) {
        initializeSortable(itemsGrid);
      }
    } catch (error) {
      console.error("Error adding section item:", error);
      alert("Error adding item. Please try again.");
    }
  }

  /**
   * Update item field value
   */
  function updateItemField(itemTempId, fieldName, value) {
    console.log("Field updated:", itemTempId, fieldName, "=", value);
    // Store data for saving later
    if (!window.sectionItemsData) {
      window.sectionItemsData = {};
    }
    if (!window.sectionItemsData[itemTempId]) {
      window.sectionItemsData[itemTempId] = {};
    }
    window.sectionItemsData[itemTempId][fieldName] = value;
  }
  async function handleImageUpload(
    itemTempId,
    fieldName,
    inputElement
  ) {
    const file = inputElement.files[0];
    if (!file) return;

    try {
      const result = await ContentServices.uploadImage(file, 'section-item');
      if (result.success) {
        updateItemField(itemTempId, fieldName, result.url);
        
        // Update the preview image
        const fieldContainer = inputElement.closest('div').parentElement;
        const existingPreview = fieldContainer.querySelector('img');
        const uploadStatus = fieldContainer.querySelector('.text-green-600');
        
        if (existingPreview) {
          existingPreview.src = result.url;
          existingPreview.style.display = 'block';
        } else {
          // Create preview image
          const previewImg = document.createElement('img');
          previewImg.src = result.url;
          previewImg.className = 'mt-2 max-h-20 rounded';
          previewImg.alt = 'Preview';
          fieldContainer.appendChild(previewImg);
        }
        
        if (uploadStatus) {
          uploadStatus.style.display = 'inline';
        }
      } else {
        alert("Error uploading image: " + (result.message || "Unknown error"));
      }
    } catch (error) {
      console.error("Error uploading image:", error);
      alert("Error uploading image. Please try again.");
    }
  }

  /**
   * Remove a section item
   */
  function removeSectionItem(itemId) {
    const config = currentSection.templateConfiguration;
    if (!config || !config.itemConfiguration) return;

    const itemConfig = config.itemConfiguration;

    // Check min items limit
    const currentItemsCount = document.querySelectorAll(
      ".section-item-card"
    ).length;
    if (itemConfig.minItems && currentItemsCount <= itemConfig.minItems) {
      alert(`Minimum ${itemConfig.minItems} items required`);
      return;
    }

    // Remove from DOM
    const card = document.querySelector(
      `[data-item-id="${itemId}"]`
    );
    if (card) {
      card.remove();
    }

    // Update UI
    updateItemNumbers();
    updateItemsCountBadge();
    updateAddButtonVisibility();
  }

  /**
   * Open image upload modal (placeholder)
   */
  function openImageUpload(button) {
    // For now, trigger file input directly
    const container = button.closest('.image-upload-container');
    const fileInput = container.querySelector('input[type="file"]');
    if (fileInput) {
      fileInput.click();
    } else {
      alert("Image upload will be implemented soon!");
    }
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

  /**
   * Add nested item to a parent item
   */
  async function addNestedItem(parentTempId) {
    if (!currentSection.templateId) {
      console.warn("No template selected");
      return;
    }

    try {
      // Get current configuration
      const config = currentSection.templateConfiguration;
      if (!config || !config.itemConfiguration || !config.itemConfiguration.nestedItems) {
        console.warn("No nested items configuration found");
        return;
      }

      const nestedConfig = config.itemConfiguration.nestedItems;
      const parentContainer = document.querySelector(`#nestedItems_${parentTempId}`);
      if (!parentContainer) {
        console.error("Parent container not found");
        return;
      }

      // Check max items limit
      const currentNestedItems = parentContainer.querySelectorAll('.nested-item-card');
      if (nestedConfig.maxItems && currentNestedItems.length >= nestedConfig.maxItems) {
        alert(`Maximum ${nestedConfig.maxItems} nested items allowed`);
        return;
      }

      // Get nested item form from backend
      const formHtml = await ContentServices.getSectionItemForm(
        currentSection.templateId,
        0,
        parentTempId
      );

      const nestedId = Date.now();
      const nestedCard = document.createElement("div");
      nestedCard.className = "nested-item-card bg-purple-50 border border-purple-200 rounded p-3";
      nestedCard.dataset.nestedId = nestedId;

      nestedCard.innerHTML = `
        <div class="flex items-center justify-between mb-2">
          <span class="text-xs font-medium text-slate-600">
            <i class="fas fa-link mr-1"></i> Dropdown #${currentNestedItems.length + 1}
          </span>
          ${nestedConfig.allowDynamicItems ? `
            <button type="button" onclick="SectionModal.removeNestedItem('${parentTempId}', '${nestedId}')"
              class="text-red-500 hover:text-red-700 text-xs">
              <i class="fas fa-times"></i>
            </button>
          ` : ''}
        </div>
        <div class="space-y-2">
          ${formHtml}
        </div>
      `;

      parentContainer.appendChild(nestedCard);

      // Update parent's nested items count display
      const parentCard = document.querySelector(`[data-item-id="${parentTempId}"]`);
      if (parentCard) {
        const countDisplay = parentCard.querySelector('h5');
        if (countDisplay) {
          countDisplay.innerHTML = countDisplay.innerHTML.replace(/\(\d+\)/, `(${currentNestedItems.length + 1})`);
        }
      }

    } catch (error) {
      console.error("Error adding nested item:", error);
      alert("Error adding nested item. Please try again.");
    }
  }

  /**
   * Remove nested item from a parent item
   */
  function removeNestedItem(parentTempId, nestedTempId) {
    const nestedCard = document.querySelector(`[data-nested-id="${nestedTempId}"]`);
    if (nestedCard) {
      nestedCard.remove();

      // Update parent's nested items count display
      const parentContainer = document.querySelector(`#nestedItems_${parentTempId}`);
      if (parentContainer) {
        const remainingItems = parentContainer.querySelectorAll('.nested-item-card');
        
        // Update numbering
        remainingItems.forEach((item, index) => {
          const numberSpan = item.querySelector('span');
          if (numberSpan) {
            numberSpan.innerHTML = `<i class="fas fa-link mr-1"></i> Dropdown #${index + 1}`;
          }
        });

        // Update parent's count display
        const parentCard = document.querySelector(`[data-item-id="${parentTempId}"]`);
        if (parentCard) {
          const countDisplay = parentCard.querySelector('h5');
          if (countDisplay) {
            countDisplay.innerHTML = countDisplay.innerHTML.replace(/\(\d+\)/, `(${remainingItems.length})`);
          }
        }
      }

      // Remove from stored data
      if (window.sectionItemsData?.[parentTempId]?.nestedItems?.[nestedTempId]) {
        delete window.sectionItemsData[parentTempId].nestedItems[nestedTempId];
      }
    }
  }

  /**
   * Update nested item field value
   */
  function updateNestedItemField(
    parentTempId,
    nestedTempId,
    fieldName,
    value
  ) {
    console.log(
      "Nested field updated:",
      parentTempId,
      nestedTempId,
      fieldName,
      value
    );
    // Store data for saving later
    if (!window.sectionItemsData) {
      window.sectionItemsData = {};
    }
    if (!window.sectionItemsData[parentTempId]) {
      window.sectionItemsData[parentTempId] = { nestedItems: {} };
    }
    if (!window.sectionItemsData[parentTempId].nestedItems[nestedTempId]) {
      window.sectionItemsData[parentTempId].nestedItems[nestedTempId] = {};
    }
    window.sectionItemsData[parentTempId].nestedItems[nestedTempId][fieldName] = value;
  }

  // ==================== HELPER FUNCTIONS ====================

  /**
   * Initialize plugins like SortableJS
   */
  function initializePlugins() {
    console.log("Initializing plugins...");
    
    // Initialize SortableJS for section items if needed
    const itemsGrid = document.getElementById("itemsGrid");
    if (itemsGrid && typeof Sortable !== "undefined") {
      if (!itemsGrid.sortableInitialized) {
        initializeSortable(itemsGrid);
      }
    }
  }

  /**
   * Initialize sortable for a container
   */
  function initializeSortable(container) {
    try {
      new Sortable(container, {
        handle: ".drag-handle",
        animation: 150,
        onEnd: function (evt) {
          updateItemNumbers();
        },
      });
      container.sortableInitialized = true;
      console.log("Sortable initialized for container");
    } catch (error) {
      console.error("Error initializing sortable:", error);
    }
  }

  /**
   * Update item numbers after reordering
   */
  function updateItemNumbers() {
    const itemCards = document.querySelectorAll(".section-item-card");
    itemCards.forEach((card, index) => {
      const numberSpan = card.querySelector(".item-number");
      if (numberSpan) {
        numberSpan.textContent = `Item #${index + 1}`;
      }
    });
    console.log("Item numbers updated");
  }

  /**
   * Update items count badge
   */
  function updateItemsCountBadge() {
    const badge = document.getElementById("itemsCountBadge");
    if (badge) {
      const count = document.querySelectorAll(".section-item-card").length;
      badge.textContent = `${count} item${count !== 1 ? "s" : ""}`;
      console.log("Items count badge updated:", count);
    }
  }

  /**
   * Update add button visibility based on max items limit
   */
  function updateAddButtonVisibility() {
    const addButton = document.getElementById("addItemButton");
    if (!addButton) return;

    const config = currentSection.templateConfiguration;
    if (!config || !config.itemConfiguration) return;

    const itemConfig = config.itemConfiguration;
    const currentCount = document.querySelectorAll(".section-item-card").length;

    if (itemConfig.MaxItems && currentCount >= itemConfig.MaxItems) {
      addButton.style.display = "none";
    } else {
      addButton.style.display = "block";
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
    // Nested items management
    addNestedItem,
    removeNestedItem,
    updateNestedItemField,
    // Image handling
    handleImageUpload,
    // UI management
    clearSectionItemsUI
  };
})();

// Make globally available
window.SectionModal = SectionModal;
