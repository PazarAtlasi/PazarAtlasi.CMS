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
      console.log("Making request to getSectionItemsList...");
      
      // Load section items list as HTML from backend (partial view)
      const html = await ContentServices.getSectionItemsList(
        templateId,
        currentSection.id
      );

      console.log("Received HTML from backend, length:", html ? html.length : 0);
      console.log("HTML content preview:", html ? html.substring(0, 200) + "..." : "null");

      // Insert HTML into container
      const container = document.getElementById(
        "sectionItemsContainer"
      );
      
      console.log("Container found:", !!container);
      
      if (container) {
        console.log("Setting container innerHTML...");
        container.innerHTML = html;

        // Give a small delay for DOM to update
        setTimeout(() => {
          // Parse and store template configuration from script tag
          const configScript = document.getElementById(
            "templateConfiguration"
          );
          
          console.log("Looking for templateConfiguration script tag...");
          console.log("Config script found:", !!configScript);
          
          if (configScript) {
            console.log("Script content:", configScript.textContent);
            try {
              currentSection.templateConfiguration = JSON.parse(
                configScript.textContent
              );
              console.log("✅ Template configuration loaded successfully:", currentSection.templateConfiguration);
              
            // Debug the configuration structure
            if (currentSection.templateConfiguration?.itemConfiguration) {
              const itemConfig = currentSection.templateConfiguration.itemConfiguration;
              console.log("✅ ItemConfiguration details:", {
                allowDynamicItems: itemConfig.allowDynamicItems,
                minItems: itemConfig.minItems,
                maxItems: itemConfig.maxItems,
                uiConfiguration: itemConfig.uiConfiguration,
                fields: itemConfig.fields,
                nestedItems: itemConfig.nestedItems
              });
              
              // Debug nested fields specifically
              if (itemConfig.nestedItems?.fields) {
                console.log("🔄 Nested fields with translation info:");
                itemConfig.nestedItems.fields.forEach((field, index) => {
                  console.log(`  Field ${index + 1}:`, {
                    name: field.name,
                    label: field.label,
                    type: field.type,
                    isTranslatable: field.isTranslatable
                  });
                });
              }
            } else {
              console.warn("❌ No itemConfiguration found in template configuration");
            }
            } catch (parseError) {
              console.error("❌ Error parsing template configuration:", parseError);
              console.error("Script content that failed to parse:", configScript.textContent);
            }
          } else {
            console.error("❌ templateConfiguration script tag not found");
            // Let's check what scripts are available
            const allScripts = document.querySelectorAll('script');
            console.log("All script tags found:", allScripts.length);
            allScripts.forEach((script, index) => {
              console.log(`Script ${index}:`, script.id, script.type);
            });
          }

          // Initialize plugins (SortableJS, etc.)
          initializePlugins();

          // Update UI counters
          updateItemsCountBadge();
        }, 100); // Small delay to ensure DOM is updated
        
      } else {
        console.error("❌ sectionItemsContainer not found");
      }
    } catch (error) {
      console.error("❌ Error in handleTemplateChange:", error);
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
      console.log("Collecting section items data...");
      
      // Collect section items data from form fields
      const sectionItems = [];
      const itemCards = document.querySelectorAll(".section-item-card");
      
      itemCards.forEach((card, index) => {
        const itemId = card.dataset.itemId;
        const itemData = window.sectionItemsData?.[itemId] || {};
        
        console.log(`Processing item ${index + 1}:`, itemId, itemData);
        
        // Separate main item data from nested items data
        const mainItemData = { ...itemData };
        if (mainItemData.nestedItems) {
          delete mainItemData.nestedItems; // Remove nested items from main data
        }
        
        // Collect nested items
        const nestedItems = [];
        const nestedCards = card.querySelectorAll(".nested-item-card");
        nestedCards.forEach((nestedCard, nestedIndex) => {
          const nestedId = nestedCard.dataset.nestedId;
          const nestedData = itemData.nestedItems?.[nestedId] || {};
          
          console.log(`  Processing nested item ${nestedIndex + 1}:`, nestedId, nestedData);
          
          nestedItems.push({
            TempId: nestedId,
            SortOrder: nestedIndex + 1,
            Data: nestedData, // Direct nested data object
            Type: 0, // Will be set by backend based on template
            Status: 1,
            MediaType: 0,
            Translations: []
          });
        });

        sectionItems.push({
          TempId: itemId,
          SortOrder: index + 1,
          Data: mainItemData, // Only main item data, no nested items
          NestedItems: nestedItems, // Separate nested items array
          Type: 0, // Will be set by backend based on template
          Status: 1,
          MediaType: 0,
          Translations: []
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
      if (currentSection.templateConfiguration?.itemConfiguration) {
        break;
      }
      
      console.log(`Waiting for template configuration... retry ${retryCount + 1}`);
      await new Promise(resolve => setTimeout(resolve, 200));
      retryCount++;
    }

    try {
      // Get current configuration
      const config = currentSection.templateConfiguration;
      if (!config || !config.itemConfiguration) {
        console.error("❌ No item configuration found after retries");
        console.log("Current template configuration:", currentSection.templateConfiguration);
        alert("Template configuration not loaded. Please try again or refresh the page.");
        return;
      }

      const itemConfig = config.itemConfiguration;
      console.log("✅ Item configuration found:", itemConfig);

      // Check max items limit
      const currentItemsCount = document.querySelectorAll(".section-item-card").length;
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
      const itemCardHtml = await ContentServices.getNewSectionItemCard(
        currentSection.templateId,
        currentSection.id,
        currentItemsCount
      );

      // Create a temporary container to parse the HTML
      const tempContainer = document.createElement('div');
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
        itemConfig.fields.forEach(field => {
          if (field.defaultValue) {
            itemData[field.name] = field.defaultValue;
          }
        });
      }
      window.sectionItemsData[itemId] = itemData;

      // Store nested items data if any
      if (itemConfig.nestedItems && itemConfig.nestedItems.defaultItems > 0) {
        if (!window.sectionItemsData[itemId].nestedItems) {
          window.sectionItemsData[itemId].nestedItems = {};
        }

        // Find nested items in the card and store their data
        const nestedCards = itemCard.querySelectorAll('.nested-item-card');
        nestedCards.forEach((nestedCard, index) => {
          const nestedId = nestedCard.dataset.nestedId;
          const nestedData = {};
          
          if (itemConfig.nestedItems.fields) {
            itemConfig.nestedItems.fields.forEach(field => {
              if (field.defaultValue) {
                nestedData[field.name] = field.defaultValue;
              }
            });
          }
          
          window.sectionItemsData[itemId].nestedItems[nestedId] = nestedData;
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

  /**
   * Update item field translation (multi-language support)
   */
  function updateItemFieldTranslation(
    itemTempId,
    fieldName,
    languageCode,
    languageId,
    value
  ) {
    console.log(
      "Item field translation updated:",
      itemTempId,
      fieldName,
      languageCode,
      value
    );
    
    // Store data for saving later
    if (!window.sectionItemsData) {
      window.sectionItemsData = {};
    }
    if (!window.sectionItemsData[itemTempId]) {
      window.sectionItemsData[itemTempId] = {};
    }
    
    // Store translation data
    const fieldKey = `${fieldName}_${languageCode}`;
    window.sectionItemsData[itemTempId][fieldKey] = value;
    
    // Also store the translation info for backend processing
    if (!window.sectionItemsData[itemTempId].translations) {
      window.sectionItemsData[itemTempId].translations = {};
    }
    
    if (!window.sectionItemsData[itemTempId].translations[languageId]) {
      window.sectionItemsData[itemTempId].translations[languageId] = {
        languageId: languageId,
        languageCode: languageCode
      };
    }
    
    window.sectionItemsData[itemTempId].translations[languageId][fieldName] = value;
  }

  /**
   * Switch language tab for section items
   */
  function switchItemLanguageTab(button, itemTempId, fieldName) {
    const fieldContainer = button.closest('.field-container');
    const languageCode = button.dataset.language;
    
    // Update active tab
    fieldContainer.querySelectorAll('.lang-tab').forEach(tab => {
        tab.classList.remove('border-purple-500', 'text-purple-600');
        tab.classList.add('border-transparent', 'text-slate-500');
    });
    button.classList.remove('border-transparent', 'text-slate-500');
    button.classList.add('border-purple-500', 'text-purple-600');
    
    // Show/hide language panels
    fieldContainer.querySelectorAll('.language-panel').forEach(panel => {
        if (panel.dataset.language === languageCode) {
            panel.classList.remove('hidden');
        } else {
            panel.classList.add('hidden');
        }
    });
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
    console.log("removeSectionItem called with itemId:", itemId);
    console.log("Current section state:", currentSection);
    
    const config = currentSection.templateConfiguration;
    if (!config || !config.itemConfiguration) {
      console.error("❌ No template configuration found");
      console.log("Available configuration:", currentSection.templateConfiguration);
      alert("Template configuration not loaded. Please refresh and try again.");
      return;
    }

    const itemConfig = config.itemConfiguration;
    console.log("✅ Item configuration found:", itemConfig);

    // Check min items limit - now using camelCase
    const currentItemsCount = document.querySelectorAll(
      ".section-item-card"
    ).length;
    
    console.log("Current items count:", currentItemsCount);
    
    const minItems = itemConfig.minItems || 0;
    console.log("Min items required:", minItems);
    
    if (minItems && currentItemsCount <= minItems) {
      alert(`Minimum ${minItems} items required`);
      return;
    }

    // Remove from DOM
    const card = document.querySelector(
      `[data-item-id="${itemId}"]`
    );
    
    console.log("Card found:", !!card);
    console.log("Card element:", card);
    
    if (card) {
      card.remove();
      console.log("✅ Card removed successfully");
    } else {
      console.error("❌ Card not found with itemId:", itemId);
      // Debug: Log all existing cards
      const allCards = document.querySelectorAll(".section-item-card");
      console.log("All existing cards:", allCards.length);
      allCards.forEach((c, index) => {
        console.log(`Card ${index}:`, c.dataset.itemId);
      });
    }

    // Remove from stored data
    if (window.sectionItemsData && window.sectionItemsData[itemId]) {
      delete window.sectionItemsData[itemId];
      console.log("✅ Removed from sectionItemsData");
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

      // Get new nested item card HTML from backend
      const nestedCardHtml = await ContentServices.getNewNestedItemCard(
        currentSection.templateId,
        parentTempId,
        currentNestedItems.length
      );

      // Create a temporary container to parse the HTML
      const tempContainer = document.createElement('div');
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
        nestedConfig.fields.forEach(field => {
          if (field.defaultValue) {
            nestedData[field.name] = field.defaultValue;
          }
        });
      }
      window.sectionItemsData[parentTempId].nestedItems[nestedId] = nestedData;

      // Append to parent container
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
    if (!window.sectionItemsData[parentTempId].nestedItems[nestedTempId]) {
      window.sectionItemsData[parentTempId].nestedItems[nestedTempId] = {};
    }
    
    // Store translation data
    const fieldKey = `${fieldName}_${languageCode}`;
    window.sectionItemsData[parentTempId].nestedItems[nestedTempId][fieldKey] = value;
    
    // Also store the translation info for backend processing
    if (!window.sectionItemsData[parentTempId].nestedItems[nestedTempId].translations) {
      window.sectionItemsData[parentTempId].nestedItems[nestedTempId].translations = {};
    }
    
    if (!window.sectionItemsData[parentTempId].nestedItems[nestedTempId].translations[languageId]) {
      window.sectionItemsData[parentTempId].nestedItems[nestedTempId].translations[languageId] = {
        languageId: languageId,
        languageCode: languageCode
      };
    }
    
    window.sectionItemsData[parentTempId].nestedItems[nestedTempId].translations[languageId][fieldName] = value;
  }

  /**
   * Switch language tab for nested items
   */
  function switchNestedLanguageTab(button, parentTempId, nestedTempId, fieldName) {
    const fieldContainer = button.closest('.nested-field-container');
    const languageCode = button.dataset.language;
    
    // Update active tab
    fieldContainer.querySelectorAll('.lang-tab').forEach(tab => {
        tab.classList.remove('border-purple-500', 'text-purple-600');
        tab.classList.add('border-transparent', 'text-slate-500');
    });
    button.classList.remove('border-transparent', 'text-slate-500');
    button.classList.add('border-purple-500', 'text-purple-600');
    
    // Show/hide language panels
    fieldContainer.querySelectorAll('.language-panel').forEach(panel => {
        if (panel.dataset.language === languageCode) {
            panel.classList.remove('hidden');
        } else {
            panel.classList.add('hidden');
        }
    });
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
    if (!addButton) {
      console.log("Add button not found");
      return;
    }

    const config = currentSection.templateConfiguration;
    if (!config || !config.itemConfiguration) {
      console.log("No item configuration, showing add button");
      addButton.style.display = "block";
      return;
    }

    const itemConfig = config.itemConfiguration;
    const currentCount = document.querySelectorAll(".section-item-card").length;

    // Now using camelCase
    const maxItems = itemConfig.maxItems;
    const allowDynamicItems = itemConfig.allowDynamicItems;
    
    console.log("updateAddButtonVisibility - Current count:", currentCount);
    console.log("updateAddButtonVisibility - Max items:", maxItems);
    console.log("updateAddButtonVisibility - Allow dynamic items:", allowDynamicItems);

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
    updateItemFieldTranslation,
    switchItemLanguageTab,
    openImageUpload,
    removeImage,
    // Nested items management
    addNestedItem,
    removeNestedItem,
    updateNestedItemField,
    updateNestedItemFieldTranslation,
    switchNestedLanguageTab,
    // Image handling
    handleImageUpload,
    // UI management
    clearSectionItemsUI
  };
})();

// Make globally available
window.SectionModal = SectionModal;
