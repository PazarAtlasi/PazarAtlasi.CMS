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
   * Handle section type change - Show Add Item button
   */
  async function handleSectionTypeChange(sectionType) {
    currentSection.type = parseInt(sectionType);

    console.log("Section type changed:", sectionType);

    // Hide items grid, show add item button
    const addItemButtonContainer = document.getElementById(
      "addItemButtonContainer"
    );
    const itemsGridContainer = document.getElementById(
      "itemsGridContainer"
    );

    if (sectionType === "0" || !sectionType) {
      // Hide both if no type selected
      if (addItemButtonContainer)
        addItemButtonContainer.classList.add("hidden");
      if (itemsGridContainer)
        itemsGridContainer.classList.add("hidden");
      return;
    }

    // Show add item button
    if (addItemButtonContainer) {
      addItemButtonContainer.classList.remove("hidden");
    }

    // Load available templates for this section type (for later use)
    try {
      const result = await ContentServices.getTemplatesBySectionType(
        sectionType
      );

      if (
        result.success &&
        result.templates &&
        result.templates.length > 0
      ) {
        currentSection.availableTemplates = result.templates;
        console.log("Available templates loaded:", result.templates);
      } else {
        currentSection.availableTemplates = [];
        console.warn("No templates available for this section type");
      }
    } catch (error) {
      console.error("Error loading templates:", error);
      currentSection.availableTemplates = [];
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
   * Save section - Collects all data recursively from DOM
   */
  async function save() {
    console.log("Starting section save...");

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
      console.log("Collecting section items data from DOM...");
      console.log(
        "Current sectionItemsData:",
        window.sectionItemsData
      );

      // Collect section items data recursively
      const sectionItems = collectSectionItems();

      console.log("Collected section items:", sectionItems);

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

      console.log("Final section data to be sent:", sectionData);

      const result = await ContentServices.saveSection(sectionData);

      if (result.success) {
        console.log("Section saved successfully");
        close();
        location.reload(); // Refresh page to show new section
      } else {
        console.error("Save failed:", result);
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
   * Collect section items from DOM recursively
   * @returns {Array} Array of section items with their fields and nested items
   */
  function collectSectionItems() {
    const itemCards = document.querySelectorAll(
      "#itemsGrid > .section-item-card"
    );
    const sectionItems = [];

    itemCards.forEach((card, index) => {
      const itemId = card.dataset.itemId;
      const itemType = card.dataset.itemType || "Unknown";

      console.log(
        `Processing root item ${
          index + 1
        }: ID=${itemId}, Type=${itemType}`
      );

      // Collect item data
      const itemData = collectItemData(card, itemId);

      sectionItems.push({
        TempId: itemId,
        SortOrder: index + 1,
        Type: itemType,
        Status: 1,
        MediaType: 0,
        Fields: itemData.fields,
        Translations: itemData.translations,
        ChildItems: itemData.childItems,
      });
    });

    console.log("Collected section items:", sectionItems);
    return sectionItems;
  }

  /**
   * Collect data for a single item (fields, translations, nested items)
   * @param {HTMLElement} itemCard - The item card DOM element
   * @param {string} itemId - The item ID
   * @param {string} parentItemId - Parent item ID (for nested items)
   * @returns {Object} Item data with fields, translations, and child items
   */
  function collectItemData(itemCard, itemId, parentItemId = "") {
    const storedData =
      parentItemId && parentItemId !== "" && parentItemId !== "0"
        ? window.sectionItemsData?.[parentItemId]?.childItems?.[
            itemId
          ]
        : window.sectionItemsData?.[itemId];

    console.log(
      `Collecting data for item ${itemId}, parent ${parentItemId}:`,
      storedData
    );

    // Collect fields
    const fields = [];
    const fieldContainers = itemCard.querySelectorAll(
      ".field-container"
    );

    fieldContainers.forEach((container) => {
      const fieldKey = container.dataset.fieldName;
      const isTranslatable =
        container.dataset.translatable === "true";

      if (!isTranslatable) {
        // Non-translatable field - get value from storage
        const fieldValue = storedData?.fields?.[fieldKey] ?? "";

        if (fieldKey) {
          fields.push({
            FieldKey: fieldKey,
            FieldValue: fieldValue ? fieldValue.toString() : "",
          });
          console.log(`  Field: ${fieldKey} = ${fieldValue}`);
        }
      }
    });

    // Collect translations
    const translations = [];
    if (storedData?.translations) {
      Object.values(storedData.translations).forEach((trans) => {
        const translationFields = [];

        // Convert fields object to array
        if (trans.fields) {
          Object.entries(trans.fields).forEach(
            ([fieldKey, fieldValue]) => {
              translationFields.push({
                FieldKey: fieldKey,
                FieldValue: fieldValue ? fieldValue.toString() : "",
              });
            }
          );
        }

        translations.push({
          LanguageId: trans.languageId,
          LanguageCode: trans.languageCode,
          Fields: translationFields,
        });

        console.log(
          `  Translation [${trans.languageCode}]:`,
          translationFields
        );
      });
    }

    // Collect nested items recursively
    const childItems = [];
    const nestedCards = itemCard.querySelectorAll(
      ":scope > .mt-4 .nested-item-card, :scope .space-y-2 > .nested-item-card"
    );

    const processedNestedIds = new Set();

    nestedCards.forEach((nestedCard, nestedIndex) => {
      const nestedId = nestedCard.dataset.nestedId;
      const nestedType = nestedCard.dataset.nestedType || "Unknown";
      const nestedLevel = parseInt(nestedCard.dataset.level) || 1;

      // Skip if already processed (avoid duplicates in recursive structure)
      if (processedNestedIds.has(nestedId)) {
        return;
      }
      processedNestedIds.add(nestedId);

      console.log(
        `  Processing nested item: ID=${nestedId}, Type=${nestedType}, Level=${nestedLevel}`
      );

      // Recursively collect nested item data
      const nestedData = collectItemData(
        nestedCard,
        nestedId,
        itemId
      );

      childItems.push({
        TempId: nestedId,
        SortOrder: nestedIndex + 1,
        Type: nestedType,
        Status: 1,
        MediaType: 0,
        Fields: nestedData.fields,
        Translations: nestedData.translations,
        ChildItems: nestedData.childItems,
      });
    });

    return {
      fields: fields,
      translations: translations,
      childItems: childItems,
    };
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
   * Add new section item - Use backend partial view
   */
  async function addSectionItem() {
    console.log("addSectionItem called");
    console.log("Current section state:", currentSection);

    if (!currentSection.templateId) {
      console.warn("❌ No template selected");
      alert("Please select a template first");
      return;
    }

    // Wait a bit and retry if configuration is not loaded yet
    let retryCount = 0;
    const maxRetries = 5;

    while (retryCount < maxRetries) {
      if (
        currentSection.templateConfiguration?.sectionConfiguration
      ) {
        break;
      }

      console.log(
        `Waiting for template configuration... retry ${
          retryCount + 1
        }`
      );
      await new Promise((resolve) => setTimeout(resolve, 200));
      retryCount++;
    }

    try {
      // Get current configuration
      const config = currentSection.templateConfiguration;
      if (!config || !config.sectionConfiguration) {
        console.error("❌ No item configuration found after retries");
        console.log(
          "Current template configuration:",
          currentSection.templateConfiguration
        );
        alert(
          "Template configuration not loaded. Please try again or refresh the page."
        );
        return;
      }

      const itemConfig = config.sectionConfiguration;
      console.log("✅ Item configuration found:", itemConfig);

      // Check max items limit
      const currentItemsCount = document.querySelectorAll(
        ".section-item-card"
      ).length;
      const maxItems = itemConfig.maxItems;

      console.log("Current items count:", currentItemsCount);
      console.log("Max items allowed:", maxItems);

      if (maxItems && currentItemsCount >= maxItems) {
        alert(`Maximum ${maxItems} items allowed`);
        return;
      }

      // Get the items grid
      const itemsGrid = document.getElementById("itemsGrid");
      if (!itemsGrid) {
        console.error("❌ Items grid not found");
        return;
      }

      // Get new section item card HTML from backend
      const itemCardHtml =
        await ContentServices.getNewSectionItemCard(
          currentSection.templateId,
          currentSection.id,
          currentItemsCount
        );

      // Create a temporary container to parse the HTML
      const tempContainer = document.createElement("div");
      tempContainer.innerHTML = itemCardHtml;
      const itemCard = tempContainer.firstElementChild;

      if (!itemCard) {
        console.error("❌ Failed to create item card");
        return;
      }

      // Get the item ID from the card
      const itemId = itemCard.dataset.itemId;
      console.log("✅ New item card created with ID:", itemId);

      // Initialize item data storage
      if (!window.sectionItemsData) {
        window.sectionItemsData = {};
      }

      // Store default field values
      const itemData = {};
      if (itemConfig.fields) {
        itemConfig.fields.forEach((field) => {
          if (field.defaultValue) {
            itemData[field.name] = field.defaultValue;
          }
        });
      }
      window.sectionItemsData[itemId] = itemData;

      // Store nested items data if any
      if (
        itemConfig.nestedItems &&
        itemConfig.nestedItems.defaultItems > 0
      ) {
        if (!window.sectionItemsData[itemId].nestedItems) {
          window.sectionItemsData[itemId].nestedItems = {};
        }

        // Find nested items in the card and store their data
        const nestedCards = itemCard.querySelectorAll(
          ".nested-item-card"
        );
        nestedCards.forEach((nestedCard, index) => {
          const nestedId = nestedCard.dataset.nestedId;
          const nestedData = {};

          if (itemConfig.nestedItems.fields) {
            itemConfig.nestedItems.fields.forEach((field) => {
              if (field.defaultValue) {
                nestedData[field.name] = field.defaultValue;
              }
            });
          }

          window.sectionItemsData[itemId].nestedItems[nestedId] =
            nestedData;
        });
      }

      // Append to grid
      itemsGrid.appendChild(itemCard);

      // Update UI
      updateItemNumbers();
      updateItemsCountBadge();
      updateAddButtonVisibility();

      // Initialize sortable if needed
      const showReorder = itemConfig.uiConfiguration?.showReorder;
      if (showReorder && !itemsGrid.sortableInitialized) {
        initializeSortable(itemsGrid);
      }

      console.log("✅ Item added successfully");
    } catch (error) {
      console.error("❌ Error adding section item:", error);
      alert("Error adding item. Please try again.");
    }
  }

  /**
   * Switch language tab for section items
   * @param {HTMLElement} button - The clicked tab button
   */
  function switchItemLanguageTab(button) {
    const fieldContainer = button.closest(".field-container");
    const languageCode = button.dataset.language;

    // Update active tab
    fieldContainer.querySelectorAll(".lang-tab").forEach((tab) => {
      tab.classList.remove("border-purple-500", "text-purple-600");
      tab.classList.add("border-transparent", "text-slate-500");
    });
    button.classList.remove("border-transparent", "text-slate-500");
    button.classList.add("border-purple-500", "text-purple-600");

    // Show/hide language panels
    fieldContainer
      .querySelectorAll(".language-panel")
      .forEach((panel) => {
        if (panel.dataset.language === languageCode) {
          panel.classList.remove("hidden");
        } else {
          panel.classList.add("hidden");
        }
      });
  }

  /**
   * Handle image upload for a field
   * @param {string} itemId - The section item ID
   * @param {string} parentItemId - The parent item ID (empty string if root level)
   * @param {string} fieldKey - The field key
   * @param {HTMLInputElement} inputElement - The file input element
   */
  async function handleImageUpload(
    itemId,
    parentItemId,
    fieldKey,
    inputElement
  ) {
    const file = inputElement.files[0];
    if (!file) return;

    try {
      const result = await ContentServices.uploadImage(
        file,
        "section-item"
      );
      if (result.success) {
        // Update the preview image in UI
        const fieldContainer = inputElement.closest(
          ".image-upload-container"
        );
        let existingPreview = fieldContainer.querySelector("img");
        const uploadStatus =
          fieldContainer.querySelector(".text-green-600");

        if (existingPreview) {
          existingPreview.src = result.url;
          existingPreview.style.display = "block";
        } else {
          // Create preview image
          const previewImg = document.createElement("img");
          previewImg.src = result.url;
          previewImg.className = "mt-2 max-h-20 rounded";
          previewImg.alt = "Preview";
          fieldContainer.appendChild(previewImg);
        }

        if (uploadStatus) {
          uploadStatus.style.display = "inline";
        }
      } else {
        alert(
          "Error uploading image: " +
            (result.message || "Unknown error")
        );
      }
    } catch (error) {
      console.error("Error uploading image:", error);
      alert("Error uploading image. Please try again.");
    }
  }

  /**
   * Open image upload modal (placeholder)
   */
  function openImageUpload(button) {
    // For now, trigger file input directly
    const container = button.closest(".image-upload-container");
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
   * Add nested item to a parent item - Use backend partial view
   */
  async function addNestedItem(parentTempId) {
    if (!currentSection.templateId) {
      console.warn("No template selected");
      return;
    }

    try {
      // Get current configuration
      const config = currentSection.templateConfiguration;
      if (
        !config ||
        !config.sectionConfiguration ||
        !config.sectionConfiguration.nestedItems
      ) {
        console.warn("No nested items configuration found");
        return;
      }

      const nestedConfig = config.sectionConfiguration.nestedItems;
      const parentContainer = document.querySelector(
        `#nestedItems_${parentTempId}`
      );
      if (!parentContainer) {
        console.error("Parent container not found");
        return;
      }

      // Check max items limit
      const currentNestedItems = parentContainer.querySelectorAll(
        ".nested-item-card"
      );
      if (
        nestedConfig.maxItems &&
        currentNestedItems.length >= nestedConfig.maxItems
      ) {
        alert(
          `Maximum ${nestedConfig.maxItems} nested items allowed`
        );
        return;
      }

      // Get new nested item card HTML from backend
      const nestedCardHtml =
        await ContentServices.getNewNestedItemCard(
          currentSection.templateId,
          parentTempId,
          currentNestedItems.length
        );

      // Create a temporary container to parse the HTML
      const tempContainer = document.createElement("div");
      tempContainer.innerHTML = nestedCardHtml;
      const nestedCard = tempContainer.firstElementChild;

      if (!nestedCard) {
        console.error("Failed to create nested item card");
        return;
      }

      // Get the nested item ID from the card
      const nestedId = nestedCard.dataset.nestedId;
      console.log("New nested item created with ID:", nestedId);

      // Store nested item data
      if (!window.sectionItemsData) {
        window.sectionItemsData = {};
      }
      if (!window.sectionItemsData[parentTempId]) {
        window.sectionItemsData[parentTempId] = { nestedItems: {} };
      }
      if (!window.sectionItemsData[parentTempId].nestedItems) {
        window.sectionItemsData[parentTempId].nestedItems = {};
      }

      // Store default nested field values
      const nestedData = {};
      if (nestedConfig.fields) {
        nestedConfig.fields.forEach((field) => {
          if (field.defaultValue) {
            nestedData[field.name] = field.defaultValue;
          }
        });
      }
      window.sectionItemsData[parentTempId].nestedItems[nestedId] =
        nestedData;

      // Append to parent container
      parentContainer.appendChild(nestedCard);

      // Update parent's nested items count display
      const parentCard = document.querySelector(
        `[data-item-id="${parentTempId}"]`
      );
      if (parentCard) {
        const countDisplay = parentCard.querySelector("h5");
        if (countDisplay) {
          countDisplay.innerHTML = countDisplay.innerHTML.replace(
            /\(\d+\)/,
            `(${currentNestedItems.length + 1})`
          );
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
    const nestedCard = document.querySelector(
      `[data-nested-id="${nestedTempId}"]`
    );
    if (nestedCard) {
      nestedCard.remove();

      // Update parent's nested items count display
      const parentContainer = document.querySelector(
        `#nestedItems_${parentTempId}`
      );
      if (parentContainer) {
        const remainingItems = parentContainer.querySelectorAll(
          ".nested-item-card"
        );

        // Update numbering
        remainingItems.forEach((item, index) => {
          const numberSpan = item.querySelector("span");
          if (numberSpan) {
            numberSpan.innerHTML = `<i class="fas fa-link mr-1"></i> Dropdown #${
              index + 1
            }`;
          }
        });

        // Update parent's count display
        const parentCard = document.querySelector(
          `[data-item-id="${parentTempId}"]`
        );
        if (parentCard) {
          const countDisplay = parentCard.querySelector("h5");
          if (countDisplay) {
            countDisplay.innerHTML = countDisplay.innerHTML.replace(
              /\(\d+\)/,
              `(${remainingItems.length})`
            );
          }
        }
      }

      // Remove from stored data
      if (
        window.sectionItemsData?.[parentTempId]?.nestedItems?.[
          nestedTempId
        ]
      ) {
        delete window.sectionItemsData[parentTempId].nestedItems[
          nestedTempId
        ];
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
    if (
      !window.sectionItemsData[parentTempId].nestedItems[nestedTempId]
    ) {
      window.sectionItemsData[parentTempId].nestedItems[
        nestedTempId
      ] = {};
    }
    window.sectionItemsData[parentTempId].nestedItems[nestedTempId][
      fieldName
    ] = value;
  }

  /**
   * Update nested item field translation (multi-language support)
   */
  function updateNestedItemFieldTranslation(
    parentTempId,
    nestedTempId,
    fieldName,
    languageCode,
    languageId,
    value
  ) {
    console.log(
      "Nested field translation updated:",
      parentTempId,
      nestedTempId,
      fieldName,
      languageCode,
      value
    );

    // Store data for saving later
    if (!window.sectionItemsData) {
      window.sectionItemsData = {};
    }
    if (!window.sectionItemsData[parentTempId]) {
      window.sectionItemsData[parentTempId] = { nestedItems: {} };
    }
    if (
      !window.sectionItemsData[parentTempId].nestedItems[nestedTempId]
    ) {
      window.sectionItemsData[parentTempId].nestedItems[
        nestedTempId
      ] = {};
    }

    // Store translation data
    const fieldKey = `${fieldName}_${languageCode}`;
    window.sectionItemsData[parentTempId].nestedItems[nestedTempId][
      fieldKey
    ] = value;

    // Also store the translation info for backend processing
    if (
      !window.sectionItemsData[parentTempId].nestedItems[nestedTempId]
        .translations
    ) {
      window.sectionItemsData[parentTempId].nestedItems[
        nestedTempId
      ].translations = {};
    }

    if (
      !window.sectionItemsData[parentTempId].nestedItems[nestedTempId]
        .translations[languageId]
    ) {
      window.sectionItemsData[parentTempId].nestedItems[
        nestedTempId
      ].translations[languageId] = {
        languageId: languageId,
        languageCode: languageCode,
      };
    }

    window.sectionItemsData[parentTempId].nestedItems[
      nestedTempId
    ].translations[languageId][fieldName] = value;
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
      const count = document.querySelectorAll(
        ".section-item-card"
      ).length;
      badge.textContent = `${count} item${count !== 1 ? "s" : ""}`;
      console.log("Items count badge updated:", count);
    }
  }

  /**
   * Update add button visibility based on max items limit
   */
  function updateAddButtonVisibility() {
    const addButton = document.getElementById("addItemButton");
    if (!addButton) {
      console.log("Add button not found");
      return;
    }

    const config = currentSection.templateConfiguration;
    if (!config || !config.sectionConfiguration) {
      console.log("No item configuration, showing add button");
      addButton.style.display = "block";
      return;
    }

    const itemConfig = config.sectionConfiguration;
    const currentCount = document.querySelectorAll(
      ".section-item-card"
    ).length;

    // Now using camelCase
    const maxItems = itemConfig.maxItems;
    const allowDynamicItems = itemConfig.allowDynamicItems;

    console.log(
      "updateAddButtonVisibility - Current count:",
      currentCount
    );
    console.log("updateAddButtonVisibility - Max items:", maxItems);
    console.log(
      "updateAddButtonVisibility - Allow dynamic items:",
      allowDynamicItems
    );

    // Hide button if dynamic items not allowed or max limit reached
    if (!allowDynamicItems) {
      addButton.style.display = "none";
      console.log("Add button hidden - dynamic items not allowed");
    } else if (maxItems && currentCount >= maxItems) {
      addButton.style.display = "none";
      console.log("Add button hidden - max items reached");
    } else {
      addButton.style.display = "block";
      console.log("Add button shown");
    }
  }

  /**
   * NEW: Add section item by type
   */
  async function addSectionItemByType(
    templateId,
    itemType,
    sectionId
  ) {
    console.log("addSectionItemByType called:", {
      templateId,
      itemType,
      sectionId,
    });

    try {
      const itemsGrid = document.getElementById("itemsGrid");
      if (!itemsGrid) {
        console.error("Items grid not found");
        return;
      }

      const currentCount = itemsGrid.querySelectorAll(
        ".section-item-card"
      ).length;

      // Create a new section item card via backend
      const html = await ContentServices.getNewSectionItemCard(
        templateId,
        sectionId,
        currentCount
      );

      // Create temporary container
      const tempDiv = document.createElement("div");
      tempDiv.innerHTML = html;
      const newCard = tempDiv.firstElementChild;

      // Add to grid
      itemsGrid.appendChild(newCard);

      // Update UI
      updateItemNumbers();
      updateItemsCountBadge();
      updateAddButtonVisibility();

      console.log("Section item added successfully");
    } catch (error) {
      console.error("Error adding section item:", error);
      alert("Failed to add section item. Please try again.");
    }
  }

  /**
   * NEW: Add nested item by type
   */
  async function addNestedItemByType(parentItemId, itemType, level) {
    console.log("addNestedItemByType called:", {
      parentItemId,
      itemType,
      level,
    });

    try {
      // Find parent item's nested items container
      const parentCard =
        document.querySelector(
          `[data-nested-id="${parentItemId}"]`
        ) ||
        document.querySelector(`[data-item-id="${parentItemId}"]`);

      if (!parentCard) {
        console.error("Parent item not found:", parentItemId);
        return;
      }

      // Find or create nested items container
      let nestedContainer = parentCard.querySelector(".space-y-2");
      if (!nestedContainer) {
        // Create nested items section if it doesn't exist
        const itemContent =
          parentCard.querySelector(".space-y-3") ||
          parentCard.querySelector(".space-y-2");
        if (itemContent) {
          const nestedSection = document.createElement("div");
          nestedSection.className =
            "mt-4 pt-4 border-t border-slate-200";
          nestedSection.innerHTML = `
                        <div class="flex items-center justify-between mb-3">
                            <h5 class="text-xs font-semibold text-slate-700 uppercase tracking-wider">
                                <i class="fas fa-level-down-alt mr-2 text-purple-600"></i>
                                Nested Items (0)
                            </h5>
                        </div>
                        <div class="space-y-2 ml-4 pl-3 border-l-2 border-purple-200"></div>
                    `;
          itemContent.appendChild(nestedSection);
          nestedContainer = nestedSection.querySelector(".space-y-2");
        }
      }

      if (!nestedContainer) {
        console.error("Could not create nested container");
        return;
      }

      const currentCount = nestedContainer.querySelectorAll(
        ".nested-item-card"
      ).length;
      const templateId = currentSection.templateId;

      // For now, create a simple nested item card
      // TODO: Get this from backend based on itemType
      const colorClasses = ["purple", "indigo", "blue"];
      const colorIndex = Math.min(level - 1, colorClasses.length - 1);
      const color = colorClasses[colorIndex];

      const nestedCard = document.createElement("div");
      nestedCard.className = `nested-item-card bg-${color}-50 border border-${color}-200 rounded p-3`;
      nestedCard.setAttribute("data-nested-id", `temp-${Date.now()}`);
      nestedCard.setAttribute("data-nested-type", itemType);
      nestedCard.setAttribute("data-level", level);
      nestedCard.innerHTML = `
                <div class="flex items-center justify-between mb-2">
                    <span class="text-xs font-medium text-slate-600">
                        <i class="fas fa-link mr-1"></i> ${itemType} #${
        currentCount + 1
      }
                    </span>
                    <button type="button" onclick="SectionModal.removeNestedItem('${parentItemId}', 'temp-${Date.now()}', ${level})"
                            class="text-red-500 hover:text-red-700 text-xs">
                        <i class="fas fa-times"></i>
                    </button>
                </div>
                <div class="space-y-2">
                    <div class="nested-field-container">
                        <label class="block text-xs font-medium text-slate-600 mb-1">
                            ${itemType} Content
                        </label>
                        <input type="text" 
                               class="w-full px-2 py-1.5 border border-slate-300 rounded text-xs"
                               placeholder="Enter ${itemType.toLowerCase()} content...">
                    </div>
                </div>
            `;

      nestedContainer.appendChild(nestedCard);

      // Update nested items count
      const countHeader =
        nestedContainer.parentElement?.querySelector("h5");
      if (countHeader) {
        const newCount = nestedContainer.querySelectorAll(
          ".nested-item-card"
        ).length;
        countHeader.innerHTML = `
                    <i class="fas fa-level-down-alt mr-2 text-${color}-600"></i>
                    Nested Items (${newCount})
                `;
      }

      console.log("Nested item added successfully");
    } catch (error) {
      console.error("Error adding nested item:", error);
      alert("Failed to add nested item. Please try again.");
    }
  }

  /**
   * NEW: Show template selection modal for adding new item
   */
  function showTemplateSelectionForNewItem() {
    console.log("showTemplateSelectionForNewItem called");

    if (!currentSection.type) {
      alert("Please select a section type first");
      return;
    }

    const templates = currentSection.availableTemplates || [];

    if (templates.length === 0) {
      alert("No templates available for this section type");
      return;
    }
    console.log(templates);
    // Create modal HTML
    const modalHTML = `
      <div id="templateSelectionModal" class="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50 p-4">
        <div class="bg-white rounded-lg shadow-xl max-w-3xl w-full max-h-[80vh] overflow-y-auto">
          <div class="p-6">
            <div class="flex items-center justify-between mb-4">
              <h3 class="text-lg font-semibold text-slate-800">
                <i class="fas fa-layer-group mr-2 text-blue-600"></i>
                Select Template for Section Item
              </h3>
              <button type="button" onclick="SectionModal.closeTemplateSelectionModal()" 
                      class="text-slate-400 hover:text-slate-600">
                <i class="fas fa-times text-xl"></i>
              </button>
            </div>
            
            <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
              ${templates
                .map(
                  (template) => `
                <button type="button"
                        onclick="SectionModal.addItemWithTemplate(${
                          template.id
                        }); SectionModal.closeTemplateSelectionModal();"
                        class="p-4 border-2 border-slate-200 hover:border-blue-500 hover:bg-blue-50 rounded-lg transition-all text-left group">
                  <div class="flex items-start mb-2">
                    <i class="fas fa-layer-group text-2xl text-slate-400 group-hover:text-blue-600 mr-3 mt-1"></i>
                    <div class="flex-1">
                      <h4 class="font-medium text-slate-800 group-hover:text-blue-600 mb-1">
                        ${template.name}
                      </h4>
                      <p class="text-xs text-slate-500 line-clamp-2">
                        ${
                          template.description ||
                          "Template for " + template.name
                        }
                      </p>
                    </div>
                  </div>
                  <div class="flex items-center justify-between text-xs text-slate-400 mt-2 pt-2 border-t border-slate-100">
                    <span><i class="fas fa-tag mr-1"></i>${
                      template.templateType
                    }</span>
                    <span class="text-blue-600 group-hover:text-blue-700 font-medium">
                      Select <i class="fas fa-arrow-right ml-1"></i>
                    </span>
                  </div>
                </button>
              `
                )
                .join("")}
            </div>
          </div>
        </div>
      </div>
    `;

    // Add to body
    const tempDiv = document.createElement("div");
    tempDiv.innerHTML = modalHTML;
    document.body.appendChild(tempDiv.firstElementChild);
    document.body.style.overflow = "hidden";
  }

  /**
   * NEW: Close template selection modal
   */
  function closeTemplateSelectionModal() {
    const modal = document.getElementById("templateSelectionModal");
    if (modal) {
      modal.remove();
      document.body.style.overflow = "";
    }
  }

  /**
   * NEW: Add item with selected template
   */
  async function addItemWithTemplate(templateId) {
    console.log(
      "addItemWithTemplate called with templateId:",
      templateId
    );

    try {
      // Store selected template
      currentSection.templateId = templateId;

      // Get item card HTML from backend
      const itemsGrid = document.getElementById("itemsGrid");
      const currentCount = itemsGrid
        ? itemsGrid.querySelectorAll(".section-item-card").length
        : 0;

      const itemCardHtml =
        await ContentServices.getNewSectionItemCard(
          templateId,
          currentSection.id,
          currentCount
        );

      // Parse HTML
      const tempContainer = document.createElement("div");
      tempContainer.innerHTML = itemCardHtml;
      const itemCard = tempContainer.firstElementChild;

      if (!itemCard) {
        console.error("Failed to create item card");
        alert("Failed to create section item. Please try again.");
        return;
      }

      // Get the item ID
      const itemId = itemCard.dataset.itemId;
      console.log("New item card created with ID:", itemId);

      // Initialize storage for this item
      if (!window.sectionItemsData) {
        window.sectionItemsData = {};
      }

      window.sectionItemsData[itemId] = {
        fields: {},
        childItems: {},
        translations: {},
        templateId: templateId,
      };

      // Show items grid container if hidden
      const itemsGridContainer = document.getElementById(
        "itemsGridContainer"
      );
      if (
        itemsGridContainer &&
        itemsGridContainer.classList.contains("hidden")
      ) {
        itemsGridContainer.classList.remove("hidden");
      }

      // Add to grid
      if (itemsGrid) {
        itemsGrid.appendChild(itemCard);
      }

      // Update UI
      updateItemNumbers();
      updateItemsCountBadge();

      console.log(
        "Item added successfully with template:",
        templateId
      );
    } catch (error) {
      console.error("Error adding item with template:", error);
      alert("Failed to add section item. Please try again.");
    }
  }

  /**
   * NEW: Show item type selection modal
   */
  function showItemTypeSelectionModal(templateId, sectionId, level) {
    console.log("showItemTypeSelectionModal called:", {
      templateId,
      sectionId,
      level,
    });

    try {
      // Get template configuration from the page
      const configElement = document.getElementById(
        "templateConfiguration"
      );
      if (!configElement) {
        console.error("Template configuration not found");
        return;
      }

      const config = JSON.parse(configElement.textContent);
      const sectionItems =
        config.sectionConfiguration?.sectionItems || [];

      if (sectionItems.length === 0) {
        alert("No item types available");
        return;
      }

      // Create modal HTML
      const modalHTML = `
                <div id="itemTypeSelectionModal" class="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50 p-4">
                    <div class="bg-white rounded-lg shadow-xl max-w-2xl w-full max-h-[80vh] overflow-y-auto">
                        <div class="p-6">
                            <div class="flex items-center justify-between mb-4">
                                <h3 class="text-lg font-semibold text-slate-800">
                                    <i class="fas fa-plus-circle mr-2 text-blue-600"></i>
                                    Select Item Type to Add
                                </h3>
                                <button type="button" onclick="SectionModal.closeItemTypeSelectionModal()" 
                                        class="text-slate-400 hover:text-slate-600">
                                    <i class="fas fa-times text-xl"></i>
                                </button>
                            </div>
                            
                            <div class="grid grid-cols-2 gap-4">
                                ${sectionItems
                                  .map(
                                    (item, index) => `
                                    <button type="button"
                                            onclick="SectionModal.addSectionItemByType(${templateId}, '${
                                      item.itemType
                                    }', ${sectionId}); SectionModal.closeItemTypeSelectionModal();"
                                            class="p-4 border-2 border-slate-200 hover:border-blue-500 hover:bg-blue-50 rounded-lg transition-all text-left group">
                                        <div class="flex items-center mb-2">
                                            <i class="fas fa-${
                                              item.uiConfiguration
                                                ?.iconClass || "cube"
                                            } text-2xl text-slate-400 group-hover:text-blue-600 mr-3"></i>
                                            <div>
                                                <h4 class="font-medium text-slate-800 group-hover:text-blue-600">
                                                    ${
                                                      item
                                                        .translations?.[0]
                                                        ?.title ||
                                                      item.itemType
                                                    }
                                                </h4>
                                                <p class="text-xs text-slate-500">
                                                    ${
                                                      item
                                                        .translations?.[0]
                                                        ?.description ||
                                                      "Add new " +
                                                        item.itemType
                                                    }
                                                </p>
                                            </div>
                                        </div>
                                        ${
                                          item.maxItems
                                            ? `<div class="text-xs text-slate-400">Max: ${item.maxItems}</div>`
                                            : ""
                                        }
                                    </button>
                                `
                                  )
                                  .join("")}
                            </div>
                        </div>
                    </div>
                </div>
            `;

      // Add to body
      const tempDiv = document.createElement("div");
      tempDiv.innerHTML = modalHTML;
      document.body.appendChild(tempDiv.firstElementChild);
      document.body.style.overflow = "hidden";
    } catch (error) {
      console.error(
        "Error showing item type selection modal:",
        error
      );
      alert("Failed to show item type selection. Please try again.");
    }
  }

  /**
   * NEW: Close item type selection modal
   */
  function closeItemTypeSelectionModal() {
    const modal = document.getElementById("itemTypeSelectionModal");
    if (modal) {
      modal.remove();
      document.body.style.overflow = "";
    }
  }

  /**
   * Update item numbers after adding/removing items
   */
  function updateItemNumbers() {
    const itemCards = document.querySelectorAll(".section-item-card");
    itemCards.forEach((card, index) => {
      const numberElement = card.querySelector(".item-number");
      if (numberElement) {
        // Update the number while preserving the text before the #
        const text = numberElement.textContent;
        const hashIndex = text.lastIndexOf("#");
        if (hashIndex !== -1) {
          numberElement.textContent =
            text.substring(0, hashIndex + 1) + (index + 1);
        }
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

  // Public API
  return {
    show,
    close,
    handlePageChange,
    handleSectionTypeChange,
    save,
    loadAvailablePages,

    // Section items management
    addSectionItem,
    switchItemLanguageTab,
    openImageUpload,
    removeImage,

    // Nested items management
    addNestedItem,
    removeNestedItem,
    updateNestedItemField,
      updateNestedItemFieldTranslation,

    // Image handling
      handleImageUpload,

    // UI management
    clearSectionItemsUI,
      updateItemNumbers,

    // NEW: Type-based item management
    addSectionItemByType,
    addNestedItemByType,
    showItemTypeSelectionModal,
      closeItemTypeSelectionModal,

    // NEW: Template selection for items
    showTemplateSelectionForNewItem,
    closeTemplateSelectionModal,
    addItemWithTemplate,
  };
})();

// Make globally available
window.SectionModal = SectionModal;