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
    status: 1,
    selectedTemplateId: null, // Template ID for new section items
    availableTemplates: [],
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
      status: 1,
      selectedTemplateId: null,
      availableTemplates: [],
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

      // If editing existing section (id > 0), show items grid and load templates
      if (currentSection.id > 0) {
        const itemsGridContainer = document.getElementById(
          "itemsGridContainer"
        );
        const addItemButtonContainer = document.getElementById(
          "addItemButtonContainer"
        );

        // Check if there are existing items
        const existingItems = document.querySelectorAll(
          ".section-item-card"
        );

        if (existingItems.length > 0) {
          // Show items grid if there are existing items
          if (itemsGridContainer) {
            itemsGridContainer.classList.remove("hidden");
          }
          // Update items count badge
          updateItemsCountBadge();
        }

        // Show add item button if section type is selected
        if (currentSection.type > 0) {
          if (addItemButtonContainer) {
            addItemButtonContainer.classList.remove("hidden");
          }

          // Load available templates for this section type
          try {
            const result =
              await ContentServices.getTemplatesBySectionType(
                currentSection.type
              );
            if (
              result.success &&
              result.templates &&
              result.templates.length > 0
            ) {
              currentSection.availableTemplates = result.templates;
              console.log(
                "Available templates loaded for edit mode:",
                result.templates
              );
            }
          } catch (error) {
            console.error(
              "Error loading templates for edit mode:",
              error
            );
          }
        }
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

      // Collect section translations
      const sectionTranslations = collectSectionTranslations();

      console.log("Collected section items:", sectionItems);
      console.log(
        "Collected section translations:",
        sectionTranslations
      );

      const sectionData = {
        Id: currentSection.id,
        PageId: currentSection.pageId,
        Type: currentSection.type,
        Status: parseInt(
          document.getElementById("modalSectionStatus").value
        ),
        SortOrder: 1,
        Attributes: "{}",
        Configure: "{}",
        SectionItems: sectionItems,
        Translations: sectionTranslations,
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
   * Collect section items from DOM recursively using data-level attribute
   * @returns {Array} Array of section items with their fields and nested items
   */
  function collectSectionItems() {
    console.log("Starting collectSectionItems...");

    // Get all item cards (both section-item-card and nested-item-card)
    const allCards = document.querySelectorAll(
      ".section-item-card, .nested-item-card"
    );

    console.log(`Found ${allCards.length} total cards`);

    // Group cards by level
    const cardsByLevel = new Map();

    allCards.forEach((card) => {
      const level = parseInt(card.dataset.level) || 0;
      if (!cardsByLevel.has(level)) {
        cardsByLevel.set(level, []);
      }
      cardsByLevel.get(level).push(card);
    });

    console.log(
      "Cards grouped by level:",
      Array.from(cardsByLevel.keys())
    );

    // Start with level 0 (root items)
    const rootCards = cardsByLevel.get(0) || [];
    const sectionItems = [];

    rootCards.forEach((card, index) => {
      const itemData = collectItemDataRecursive(
        card,
        cardsByLevel,
        0
      );

      sectionItems.push({
        Id: itemData.id,
        SortOrder: index + 1,
        Type: itemData.type,
        TemplateId: itemData.templateId,
        Status: 1,
        MediaType: 0,
        Fields: itemData.fields,
        NestedItems: itemData.nestedItems, // Changed from ChildItems to NestedItems
      });
    });

    console.log("Final collected section items:", sectionItems);
    return sectionItems;
  }

  /**
   * Collect section translations from the section modal
   * @returns {Array} Array of section translations
   */
  function collectSectionTranslations() {
    console.log("Starting collectSectionTranslations...");

    const translations = [];
    const translationContainer = document.getElementById(
      "sectionTranslationsContainer"
    );

    if (!translationContainer) {
      console.log("No section translations container found");
      return translations;
    }

    // Get all translation content divs
    const translationContents = translationContainer.querySelectorAll(
      ".translation-content"
    );

    translationContents.forEach((content) => {
      const languageId = parseInt(content.dataset.languageId);

      // Get title and description inputs
      const titleInput = content.querySelector(
        ".section-translation-title"
      );
      const descriptionInput = content.querySelector(
        ".section-translation-description"
      );

      const title = titleInput ? titleInput.value.trim() : "";
      const description = descriptionInput
        ? descriptionInput.value.trim()
        : "";

      // Only add translation if there's content
      if (title || description) {
        translations.push({
          LanguageId: languageId,
          Title: title,
          Description: description,
        });

        console.log(
          `Added section translation [${languageId}]: title="${title}", description="${description}"`
        );
      }
    });

    console.log(
      `Collected ${translations.length} section translations`
    );
    return translations;
  }

  /**
   * Collect data for a single item recursively using level-based approach
   * @param {HTMLElement} itemCard - The item card DOM element
   * @param {Map} cardsByLevel - Map of cards grouped by level
   * @param {number} currentLevel - Current level being processed
   * @returns {Object} Item data with fields, translations, and nested items
   */
  function collectItemDataRecursive(
    itemCard,
    cardsByLevel,
    currentLevel
  ) {
    const itemId =
      itemCard.dataset.itemId || itemCard.dataset.nestedId;
    const itemType =
      parseInt(itemCard.dataset.itemType) ||
      parseInt(itemCard.dataset.nestedType) ||
      0;
    const templateId = parseInt(itemCard.dataset.templateId) || null;

    console.log(
      `Collecting data for item ${itemId} at level ${currentLevel}, type: ${itemType}, templateId: ${templateId}`
    );

    // Collect fields from this card only (not from nested cards)
    const fields = [];

    // Get field containers that belong DIRECTLY to this card only (not nested ones)
    // CSS class independent approach - use closest parent card logic
    const allFieldContainers = itemCard.querySelectorAll(
      ".field-container"
    );
    const directFieldContainers = Array.from(
      allFieldContainers
    ).filter((container) => {
      // Check if this field container's closest card parent is the current item card
      const closestCard = container.closest(
        ".section-item-card, .nested-item-card"
      );
      return closestCard === itemCard;
    });

    console.log(
      `Found ${allFieldContainers.length} total field containers, ${directFieldContainers.length} direct field containers for item ${itemId} at level ${currentLevel}`
    );

    directFieldContainers.forEach((container) => {
      const fieldId = container.dataset.fieldId;
      const fieldKey = container.dataset.fieldName;
      const isTranslatable =
        container.dataset.translatable === "true";

      console.log(
        `Processing field: ${fieldKey} (ID: ${fieldId}), translatable: ${isTranslatable}`
      );

      if (!isTranslatable) {
        // Non-translatable field - get value directly from input
        const input = container.querySelector(
          "input, textarea, select"
        );
        const fieldValue = input ? input.value : "";

        if (fieldKey) {
          fields.push({
            Id: parseInt(fieldId) || 0,
            FieldKey: fieldKey,
            FieldValue: fieldValue,
            FieldType: getFieldTypeFromContainer(container),
          });
          console.log(
            `  Non-translatable field: ${fieldKey} (ID: ${fieldId}) = ${fieldValue}, type: ${getFieldTypeFromContainer(
              container
            )}`
          );
        }
      } else {
        // Translatable field - collect from all language panels and embed in field
        const languagePanels =
          container.querySelectorAll(".language-panel");

        const fieldTranslations = [];
        let defaultValue = "";

        languagePanels.forEach((panel) => {
          const languageCode = panel.dataset.language;
          const input = panel.querySelector(
            "input, textarea, select"
          );
          const fieldValue = input ? input.value : "";

          if (fieldValue) {
            const languageTab = container.querySelector(
              `[data-language="${languageCode}"]`
            );
            const languageId = languageTab
              ? languageTab.dataset.languageId
              : null;

            fieldTranslations.push({
              LanguageId: parseInt(languageId) || 1,
              Value: fieldValue,
            });

            // Use first language as default value
            if (!defaultValue) {
              defaultValue = fieldValue;
            }

            console.log(
              `  Translatable field [${languageCode}]: ${fieldKey} (ID: ${fieldId}) = ${fieldValue}`
            );
          }
        });

        // Add field with embedded translations
        if (fieldTranslations.length > 0) {
          fields.push({
            Id: parseInt(fieldId) || 0,
            FieldKey: fieldKey,
            FieldValue: defaultValue,
            FieldType: getFieldTypeFromContainer(container),
            Translations: fieldTranslations,
          });
        }
      }
    });

    // Collect nested items from the next level
    const nestedItems = [];
    const nextLevel = currentLevel + 1;

    if (cardsByLevel.has(nextLevel)) {
      const nextLevelCards = cardsByLevel.get(nextLevel);

      // Find cards that belong to this parent item
      nextLevelCards.forEach((nestedCard, index) => {
        // Check if this nested card is a child of current item
        // This can be determined by DOM hierarchy or data attributes
        if (isChildOfItem(nestedCard, itemCard)) {
          const nestedData = collectItemDataRecursive(
            nestedCard,
            cardsByLevel,
            nextLevel
          );

          nestedItems.push({
            Id: nestedData.id,
            SortOrder: index + 1,
            Type: nestedData.type,
            TemplateId: nestedData.templateId,
            Status: 1,
            MediaType: 0,
            Fields: nestedData.fields,
            NestedItems: nestedData.nestedItems,
          });
        }
      });
    }

    return {
      id: parseInt(itemId) || 0,
      type: itemType,
      templateId: templateId,
      fields: fields,
      nestedItems: nestedItems,
    };
  }

  /**
   * Helper function to get field type from data attribute or input
   * First checks data-field-type attribute, then falls back to input analysis
   */
  function getFieldTypeFromContainer(container) {
    const dataFieldType = container.dataset.fieldType;
    return parseInt(dataFieldType) || 1;
  }

  /**
   * Helper function to check if a nested card is a child of a parent item
   */
  function isChildOfItem(nestedCard, parentCard) {
    // Check if the nested card is contained within the parent card's DOM structure
    return parentCard.contains(nestedCard);
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

    try {
      // Check if we have a selected template
      if (!currentSection.selectedTemplateId) {
        alert(
          "Please select a template first by clicking 'Add Section Item' button."
        );
        return;
      }
      console.log("✅ Item configuration found:", itemConfig);

      // Check max items limit
      const currentItemsCount = document.querySelectorAll(
        ".section-item-card"
      ).length;

      // Get the items grid
      const itemsGrid = document.getElementById("itemsGrid");
      if (!itemsGrid) {
        console.error("❌ Items grid not found");
        return;
      }

      // Get new section item card HTML from backend
      const itemCardHtml =
        await ContentServices.getNewSectionItemCard(
          currentSection.selectedTemplateId,
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

      // Append to grid
      itemsGrid.appendChild(itemCard);

      // Update UI
      updateItemNumbers();
      updateItemsCountBadge();

      // Initialize sortable if needed
      if (!itemsGrid.sortableInitialized) {
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
    if (!currentSection.selectedTemplateId) {
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
          currentSection.selectedTemplateId,
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

    // For now, always show the add button
    // Template-specific limits will be handled when template is selected
    addButton.style.display = "block";
    console.log("Add button shown");
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
      // Set the selected template ID
      currentSection.selectedTemplateId = templateId;

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

  /**
   * Check if items grid is empty and hide it
   */
  function checkAndHideEmptyItemsGrid() {
    const itemsGrid = document.getElementById("itemsGrid");
    const itemsGridContainer = document.getElementById(
      "itemsGridContainer"
    );

    if (itemsGrid && itemsGridContainer) {
      const remainingItems = itemsGrid.querySelectorAll(
        ".section-item-card"
      );

      if (remainingItems.length === 0) {
        // Hide the items grid container
        itemsGridContainer.classList.add("hidden");
        console.log("Items grid hidden - no items remaining");
      }
    }
  }

  // Public API
  return {
    show,
    close,
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

    // Image handling
    handleImageUpload,

    // UI management
    updateItemNumbers,
    updateItemsCountBadge,
    checkAndHideEmptyItemsGrid,

    // NEW: Type-based item management
    addSectionItemByType,
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

// Global functions for page sections partial
function editSectionItems(sectionId) {
  const pageId = window.currentPageId || 1; // Get from global or default
  SectionModal.show(sectionId, pageId);
}

function removeItem(button) {
  const itemCard = button.closest(".section-item-card");
  if (!itemCard) return;

  // Check if SwalHelper is available
  if (
    typeof SwalHelper === "undefined" ||
    typeof window.SwalHelper === "undefined"
  ) {
    console.error(
      "SwalHelper is not available, falling back to confirm"
    );
    if (confirm("Bu öğeyi silmek istediğinizden emin misiniz?")) {
      try {
        itemCard.remove();

        // Update item numbers and count badge safely
        if (typeof SectionModal !== "undefined") {
          if (typeof SectionModal.updateItemNumbers === "function") {
            SectionModal.updateItemNumbers();
          }
          if (
            typeof SectionModal.updateItemsCountBadge === "function"
          ) {
            SectionModal.updateItemsCountBadge();
          }
          if (
            typeof SectionModal.checkAndHideEmptyItemsGrid ===
            "function"
          ) {
            SectionModal.checkAndHideEmptyItemsGrid();
          }
        } else if (typeof updateItemNumbers === "function") {
          updateItemNumbers();
        }
      } catch (error) {
        console.error("Error during item removal:", error);
      }
    }
    return;
  }

  // Get item info for better UX
  const itemTitle =
    itemCard.querySelector(".item-number")?.textContent || "Bu öğe";

  // Show beautiful confirmation dialog
  SwalHelper.confirmDelete(
    "Öğeyi Sil",
    `"${itemTitle}" öğesini silmek istediğinizden emin misiniz? Bu işlem geri alınamaz.`,
    {
      confirmButtonText: '<i class="fas fa-trash mr-2"></i>Evet, Sil',
      cancelButtonText: '<i class="fas fa-times mr-2"></i>İptal',
    }
  )
    .then((result) => {
      if (result.isConfirmed) {
        // Show loading
        SwalHelper.loading(
          "Siliniyor...",
          "Öğe siliniyor, lütfen bekleyin..."
        );

        // Simulate removal delay for better UX
        setTimeout(() => {
          try {
            itemCard.remove();

            // Update item numbers and count badge safely
            if (typeof SectionModal !== "undefined") {
              if (
                typeof SectionModal.updateItemNumbers === "function"
              ) {
                SectionModal.updateItemNumbers();
              }
              if (
                typeof SectionModal.updateItemsCountBadge ===
                "function"
              ) {
                SectionModal.updateItemsCountBadge();
              }
              if (
                typeof SectionModal.checkAndHideEmptyItemsGrid ===
                "function"
              ) {
                SectionModal.checkAndHideEmptyItemsGrid();
              }
            } else if (typeof updateItemNumbers === "function") {
              updateItemNumbers();
            }

            // Close loading and show success
            Swal.close();
            SwalHelper.toast("Öğe başarıyla silindi", "success");
          } catch (error) {
            console.error("Error during item removal:", error);
            // Always close loading even if there's an error
            Swal.close();
            SwalHelper.error(
              "Hata",
              "Öğe silinirken bir hata oluştu."
            );
          }
        }, 800);
      }
    })
    .catch((error) => {
      console.error("Error in SwalHelper.confirmDelete:", error);
      // Close any open loading dialog
      Swal.close();
    });
}
