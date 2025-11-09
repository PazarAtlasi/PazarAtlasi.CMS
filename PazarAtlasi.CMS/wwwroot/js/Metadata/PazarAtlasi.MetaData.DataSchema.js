/**
 * PazarAtlasi MetaData DataSchema Manager
 * Handles DataSchema creation, editing, and field management
 */

// Prevent redeclaration
if (typeof DataSchemaManager === "undefined") {
  var DataSchemaManager = (function () {
    "use strict";

    // Private variables
    let fieldCounter = 0;
    let availableFieldTypes = [];
    let availableLanguages = [];

    // Field type configurations
    const fieldTypeConfigs = {
      Text: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: false,
      },
      TextArea: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: false,
      },
      Number: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: true,
      },
      Boolean: {
        hasOptions: false,
        hasValidation: false,
        hasUnit: false,
      },
      Date: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: false,
      },
      DateTime: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: false,
      },
      Email: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: false,
      },
      Url: { hasOptions: false, hasValidation: true, hasUnit: false },
      Phone: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: false,
      },
      Color: {
        hasOptions: false,
        hasValidation: false,
        hasUnit: false,
      },
      File: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: false,
      },
      Image: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: false,
      },
      Video: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: false,
      },
      Select: {
        hasOptions: true,
        hasValidation: false,
        hasUnit: false,
      },
      MultiSelect: {
        hasOptions: true,
        hasValidation: false,
        hasUnit: false,
      },
      Radio: {
        hasOptions: true,
        hasValidation: false,
        hasUnit: false,
      },
      Checkbox: {
        hasOptions: true,
        hasValidation: false,
        hasUnit: false,
      },
      Range: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: true,
      },
      RichText: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: false,
      },
      Json: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: false,
      },
      Tags: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: false,
      },
      Rating: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: false,
      },
      Currency: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: true,
      },
      Percentage: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: false,
      },
      Dimensions: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: true,
      },
      Weight: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: true,
      },
      Temperature: {
        hasOptions: false,
        hasValidation: true,
        hasUnit: true,
      },
      Custom: {
        hasOptions: true,
        hasValidation: true,
        hasUnit: true,
      },
    };

    // Initialize
    function init() {
      loadFieldTypes();
      loadLanguages();
      bindEvents();
    }

    // Load available field types
    function loadFieldTypes() {
      MetaDataServices.dataSchema
        .getFieldTypes()
        .then((response) => {
          if (response.success) {
            availableFieldTypes = response.fieldTypes;
          }
        })
        .catch((error) => {
          console.error("Error loading field types:", error);
        });
    }

    // Load available languages
    function loadLanguages() {
      // Get languages from the page (already loaded in the view)
      const languageTabs = document.querySelectorAll(".language-tab");
      availableLanguages = Array.from(languageTabs).map((tab) => ({
        id: parseInt(tab.dataset.languageId),
        name: tab.textContent.trim(),
        isDefault: tab.classList.contains("border-blue-500"),
      }));
    }

    // Bind events
    function bindEvents() {
      // Field type change handler
      $(document).on("change", ".field-type-select", function () {
        const fieldItem = $(this).closest(".field-item");
        const fieldType = $(this).val();
        updateFieldOptions(fieldItem, fieldType);
      });

      // Remove field handler
      $(document).on("click", ".remove-field-btn", function () {
        const fieldItem = $(this).closest(".field-item");
        removeField(fieldItem);
      });

      // Add option handler
      $(document).on("click", ".add-option-btn", function () {
        const optionsContainer = $(this).siblings(
          ".options-container"
        );
        addOption(optionsContainer);
      });

      // Remove option handler
      $(document).on("click", ".remove-option-btn", function () {
        $(this).closest(".option-item").remove();
      });

      // Field key generation
      $(document).on("input", ".field-name-input", function () {
        const fieldItem = $(this).closest(".field-item");
        const fieldName = $(this).val();
        const fieldKey = generateFieldKey(fieldName);
        fieldItem.find(".field-key-input").val(fieldKey);
      });
    }

    // Add new field
    function addField(fieldData = null) {
      fieldCounter++;
      const fieldId = fieldData
        ? fieldData.id
        : `field_${fieldCounter}`;
      const fieldIndex =
        document.querySelectorAll(".field-item").length;

      const fieldHtml = createFieldHtml(
        fieldId,
        fieldIndex,
        fieldData
      );

      const fieldsContainer =
        document.getElementById("fieldsContainer");
      const emptyState = document.getElementById("fieldsEmptyState");

      fieldsContainer.insertAdjacentHTML("beforeend", fieldHtml);

      if (emptyState) {
        emptyState.style.display = "none";
      }

      // Initialize field type dropdown
      const newField = fieldsContainer.lastElementChild;
      const typeSelect = newField.querySelector(".field-type-select");
      populateFieldTypeOptions(typeSelect);

      // Set field data if provided
      if (fieldData) {
        setFieldData(newField, fieldData);
      }

      // Initialize sortable
      initializeSortable();
    }

    // Create field HTML
    function createFieldHtml(fieldId, fieldIndex, fieldData = null) {
      const isRequired = fieldData ? fieldData.isRequired : false;
      const isTranslatable = fieldData
        ? fieldData.isTranslatable
        : false;
      const showInListing = fieldData
        ? fieldData.showInListing
        : true;
      const showInDetails = fieldData
        ? fieldData.showInDetails
        : true;
      const isFilterable = fieldData ? fieldData.isFilterable : false;
      const isSortable = fieldData ? fieldData.isSortable : false;
      const isActive = fieldData ? fieldData.isActive : true;

      return `
                <div class="field-item bg-slate-50 border border-slate-200 rounded-lg p-6 mb-4" data-field-id="${fieldId}">
                    <div class="flex items-center justify-between mb-4">
                        <div class="flex items-center">
                            <div class="drag-handle cursor-move mr-3 text-slate-400 hover:text-slate-600">
                                <i class="fas fa-grip-vertical"></i>
                            </div>
                            <h4 class="text-lg font-semibold text-slate-800">
                                <i class="fas fa-list-ul text-purple-600 mr-2"></i>
                                Alan #${fieldIndex + 1}
                            </h4>
                        </div>
                        <button type="button" class="remove-field-btn text-red-600 hover:text-red-800 transition-colors">
                            <i class="fas fa-trash"></i>
                        </button>
                    </div>

                    <!-- Basic Field Information -->
                    <div class="grid grid-cols-1 md:grid-cols-2 gap-4 mb-4">
                        <div>
                            <label class="block text-sm font-medium text-slate-700 mb-2">Alan Adı *</label>
                            <input type="text" name="Fields[${fieldIndex}].FieldName" 
                                   class="field-name-input w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-purple-500" 
                                   placeholder="Örn: Storage" required>
                        </div>
                        <div>
                            <label class="block text-sm font-medium text-slate-700 mb-2">Alan Anahtarı *</label>
                            <input type="text" name="Fields[${fieldIndex}].FieldKey" 
                                   class="field-key-input w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-purple-500" 
                                   placeholder="Örn: storage_gb" required pattern="^[a-z0-9_]+$">
                            <p class="text-xs text-slate-500 mt-1">Sadece küçük harf, rakam ve alt çizgi</p>
                        </div>
                        <div>
                            <label class="block text-sm font-medium text-slate-700 mb-2">Alan Tipi *</label>
                            <select name="Fields[${fieldIndex}].Type" class="field-type-select w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-purple-500" required>
                                <option value="">Alan tipi seçin</option>
                            </select>
                        </div>
                        <div>
                            <label class="block text-sm font-medium text-slate-700 mb-2">Sıralama</label>
                            <input type="number" name="Fields[${fieldIndex}].SortOrder" min="0" 
                                   class="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-purple-500" 
                                   value="${fieldIndex + 1}">
                        </div>
                    </div>

                    <!-- Field Description -->
                    <div class="mb-4">
                        <label class="block text-sm font-medium text-slate-700 mb-2">Açıklama</label>
                        <textarea name="Fields[${fieldIndex}].Description" rows="2" 
                                  class="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-purple-500" 
                                  placeholder="Alan hakkında açıklama..."></textarea>
                    </div>

                    <!-- Field Options (Dynamic based on type) -->
                    <div class="field-options mb-4">
                        <!-- Will be populated based on field type -->
                    </div>

                    <!-- Field Settings -->
                    <div class="grid grid-cols-2 md:grid-cols-4 gap-4 mb-4">
                        <div class="flex items-center">
                            <input type="checkbox" name="Fields[${fieldIndex}].IsRequired" 
                                   class="h-4 w-4 text-purple-600 focus:ring-purple-500 border-slate-300 rounded" 
                                   ${isRequired ? "checked" : ""}>
                            <label class="ml-2 block text-sm text-slate-700">Zorunlu</label>
                        </div>
                        <div class="flex items-center">
                            <input type="checkbox" 
                                   id="field_${fieldIndex}_IsTranslatable"
                                   name="Fields[${fieldIndex}].IsTranslatable" 
                                   class="h-4 w-4 text-purple-600 focus:ring-purple-500 border-slate-300 rounded" 
                                   onchange="toggleFieldTranslations(${fieldIndex})"
                                   ${isTranslatable ? "checked" : ""}>
                            <label class="ml-2 block text-sm text-slate-700">Çevrilebilir</label>
                        </div>
                        <div class="flex items-center">
                            <input type="checkbox" name="Fields[${fieldIndex}].ShowInListing" 
                                   class="h-4 w-4 text-purple-600 focus:ring-purple-500 border-slate-300 rounded" 
                                   ${showInListing ? "checked" : ""}>
                            <label class="ml-2 block text-sm text-slate-700">Listede Göster</label>
                        </div>
                        <div class="flex items-center">
                            <input type="checkbox" name="Fields[${fieldIndex}].ShowInDetails" 
                                   class="h-4 w-4 text-purple-600 focus:ring-purple-500 border-slate-300 rounded" 
                                   ${showInDetails ? "checked" : ""}>
                            <label class="ml-2 block text-sm text-slate-700">Detayda Göster</label>
                        </div>
                        <div class="flex items-center">
                            <input type="checkbox" name="Fields[${fieldIndex}].IsFilterable" 
                                   class="h-4 w-4 text-purple-600 focus:ring-purple-500 border-slate-300 rounded" 
                                   ${isFilterable ? "checked" : ""}>
                            <label class="ml-2 block text-sm text-slate-700">Filtrelenebilir</label>
                        </div>
                        <div class="flex items-center">
                            <input type="checkbox" name="Fields[${fieldIndex}].IsSortable" 
                                   class="h-4 w-4 text-purple-600 focus:ring-purple-500 border-slate-300 rounded" 
                                   ${isSortable ? "checked" : ""}>
                            <label class="ml-2 block text-sm text-slate-700">Sıralanabilir</label>
                        </div>
                        <div class="flex items-center">
                            <input type="checkbox" name="Fields[${fieldIndex}].IsActive" 
                                   class="h-4 w-4 text-purple-600 focus:ring-purple-500 border-slate-300 rounded" 
                                   ${isActive ? "checked" : ""}>
                            <label class="ml-2 block text-sm text-slate-700">Aktif</label>
                        </div>
                    </div>

                    <!-- Field Translations (Collapsible) -->
                    <div id="fieldTranslations_${fieldIndex}" class="field-translations ${
        isTranslatable ? "" : "hidden"
      }">
                        <div class="bg-green-50 border border-green-200 rounded-lg p-4">
                            <h5 class="text-sm font-semibold text-slate-800 mb-3 flex items-center">
                                <i class="fas fa-language text-green-600 mr-2"></i>
                                Alan Çevirileri
                            </h5>
                        
                            <!-- Translation Tabs -->
                            <div class="border-b border-slate-200 mb-3">
                                <nav class="-mb-px flex space-x-4 field-translation-tabs">
                                    ${availableLanguages
                                      .map(
                                        (lang, langIndex) => `
                                        <button type="button" 
                                                class="field-translation-tab-${fieldIndex} py-1 px-2 border-b-2 font-medium text-xs transition-colors ${
                                          lang.isDefault
                                            ? "border-green-500 text-green-600"
                                            : "border-transparent text-slate-500 hover:text-slate-700 hover:border-slate-300"
                                        }"
                                                data-field-index="${fieldIndex}"
                                                data-tab-index="${langIndex}"
                                                onclick="switchFieldTranslationTab(${fieldIndex}, ${langIndex})">
                                            ${lang.name}
                                            ${
                                              lang.isDefault
                                                ? '<span class="ml-1 text-xs">●</span>'
                                                : ""
                                            }
                                        </button>
                                    `
                                      )
                                      .join("")}
                                </nav>
                            </div>

                            <!-- Translation Content -->
                            ${availableLanguages
                              .map(
                                (lang, langIndex) => `
                                <div id="fieldTranslationTab_${fieldIndex}_${langIndex}" 
                                     class="field-translation-content-${fieldIndex} ${
                                  lang.isDefault ? "" : "hidden"
                                }" data-language-id="${lang.id}">
                                <input type="hidden" name="Fields[${fieldIndex}].Translations[${langIndex}].LanguageId" value="${
                                  lang.id
                                }" />
                                <input type="hidden" name="Fields[${fieldIndex}].Translations[${langIndex}].LanguageName" value="${
                                  lang.name
                                }" />
                                <input type="hidden" name="Fields[${fieldIndex}].Translations[${langIndex}].IsDefault" value="${
                                  lang.isDefault
                                }" />
                                
                                <div class="grid grid-cols-1 md:grid-cols-2 gap-3">
                                    <div>
                                        <label class="block text-xs font-medium text-slate-700 mb-1">Alan Adı (${
                                          lang.name
                                        })</label>
                                        <input type="text" name="Fields[${fieldIndex}].Translations[${langIndex}].FieldName" 
                                               class="w-full px-3 py-2 text-sm border border-slate-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-purple-500" 
                                               placeholder="${
                                                 lang.name
                                               } dilinde alan adı">
                                    </div>
                                    <div>
                                        <label class="block text-xs font-medium text-slate-700 mb-1">Birim (${
                                          lang.name
                                        })</label>
                                        <input type="text" name="Fields[${fieldIndex}].Translations[${langIndex}].Unit" 
                                               class="w-full px-3 py-2 text-sm border border-slate-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-purple-500" 
                                               placeholder="Örn: GB, inches">
                                    </div>
                                </div>
                                <div class="mt-3">
                                    <label class="block text-xs font-medium text-slate-700 mb-1">Açıklama (${
                                      lang.name
                                    })</label>
                                    <textarea name="Fields[${fieldIndex}].Translations[${langIndex}].Description" rows="2" 
                                              class="w-full px-3 py-2 text-sm border border-slate-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-purple-500" 
                                              placeholder="${
                                                lang.name
                                              } dilinde açıklama"></textarea>
                                </div>
                                <div class="mt-3">
                                    <label class="block text-xs font-medium text-slate-700 mb-1">Placeholder (${
                                      lang.name
                                    })</label>
                                    <input type="text" name="Fields[${fieldIndex}].Translations[${langIndex}].Placeholder" 
                                           class="w-full px-3 py-2 text-sm border border-slate-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-purple-500" 
                                           placeholder="${
                                             lang.name
                                           } dilinde placeholder metni">
                                </div>
                                </div>
                            `
                              )
                              .join("")}
                        </div>
                    </div>
                </div>
            `;
    }

    // Populate field type options
    function populateFieldTypeOptions(selectElement) {
      selectElement.innerHTML =
        '<option value="">Alan tipi seçin</option>';

      if (availableFieldTypes.length > 0) {
        availableFieldTypes.forEach((fieldType) => {
          const option = document.createElement("option");
          option.value = fieldType.value;
          option.textContent = fieldType.name;
          option.title = fieldType.description;
          selectElement.appendChild(option);
        });
      } else {
        // Fallback if field types are not loaded
        Object.keys(fieldTypeConfigs).forEach((fieldType) => {
          const option = document.createElement("option");
          option.value = fieldType;
          option.textContent = fieldType;
          selectElement.appendChild(option);
        });
      }
    }

    // Update field options based on type
    function updateFieldOptions(fieldItem, fieldType) {
      const optionsContainer = fieldItem.find(".field-options");
      const config = fieldTypeConfigs[fieldType];

      if (!config) return;

      let optionsHtml = "";

      // Default value and placeholder
      optionsHtml += `
                <div class="grid grid-cols-1 md:grid-cols-2 gap-4 mb-4">
                    <div>
                        <label class="block text-sm font-medium text-slate-700 mb-2">Varsayılan Değer</label>
                        <input type="text" name="Fields[${getFieldIndex(
                          fieldItem
                        )}].DefaultValue" 
                               class="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-purple-500" 
                               placeholder="Varsayılan değer">
                    </div>
                    <div>
                        <label class="block text-sm font-medium text-slate-700 mb-2">Placeholder</label>
                        <input type="text" name="Fields[${getFieldIndex(
                          fieldItem
                        )}].Placeholder" 
                               class="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-purple-500" 
                               placeholder="Placeholder metni">
                    </div>
                </div>
            `;

      // Unit field
      if (config.hasUnit) {
        optionsHtml += `
                    <div class="mb-4">
                        <label class="block text-sm font-medium text-slate-700 mb-2">Birim</label>
                        <input type="text" name="Fields[${getFieldIndex(
                          fieldItem
                        )}].Unit" 
                               class="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-purple-500" 
                               placeholder="Örn: GB, inches, nits">
                    </div>
                `;
      }

      // Options for select/radio/checkbox fields
      if (config.hasOptions) {
        optionsHtml += `
                    <div class="mb-4">
                        <div class="flex items-center justify-between mb-2">
                            <label class="block text-sm font-medium text-slate-700">Seçenekler</label>
                            <button type="button" class="add-option-btn bg-green-600 hover:bg-green-700 text-white px-3 py-1 rounded text-sm transition-colors">
                                <i class="fas fa-plus mr-1"></i>
                                Seçenek Ekle
                            </button>
                        </div>
                        <div class="options-container space-y-2">
                            <!-- Options will be added here -->
                        </div>
                        <input type="hidden" name="Fields[${getFieldIndex(
                          fieldItem
                        )}].OptionsJson" class="options-json-input">
                    </div>
                `;
      }

      // Validation rules
      if (config.hasValidation) {
        optionsHtml += `
                    <div class="mb-4">
                        <label class="block text-sm font-medium text-slate-700 mb-2">Validasyon Kuralları (JSON)</label>
                        <textarea name="Fields[${getFieldIndex(
                          fieldItem
                        )}].ValidationRules" rows="3" 
                                  class="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-purple-500" 
                                  placeholder='{"min": 0, "max": 100, "pattern": "^[0-9]+$"}'></textarea>
                        <p class="text-xs text-slate-500 mt-1">JSON formatında validasyon kuralları</p>
                    </div>
                `;
      }

      optionsContainer.html(optionsHtml);

      // Add initial option for select fields
      if (config.hasOptions) {
        const optionsContainer = fieldItem.find(".options-container");
        addOption(optionsContainer);
      }
    }

    // Add option to select field
    function addOption(optionsContainer) {
      const optionIndex = optionsContainer.children().length;
      const optionHtml = `
                <div class="option-item flex items-center space-x-2">
                    <input type="text" class="option-value flex-1 px-3 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-purple-500" 
                           placeholder="Değer (örn: 128)" onchange="updateOptionsJson(this)">
                    <input type="text" class="option-label flex-1 px-3 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-purple-500" 
                           placeholder="Etiket (örn: 128 GB)" onchange="updateOptionsJson(this)">
                    <button type="button" class="remove-option-btn text-red-600 hover:text-red-800 transition-colors">
                        <i class="fas fa-trash"></i>
                    </button>
                </div>
            `;
      optionsContainer.append(optionHtml);
    }

    // Update options JSON
    window.updateOptionsJson = function (element) {
      const fieldItem = $(element).closest(".field-item");
      const optionsContainer = fieldItem.find(".options-container");
      const optionsJsonInput = fieldItem.find(".options-json-input");

      const options = [];
      optionsContainer.find(".option-item").each(function () {
        const value = $(this).find(".option-value").val();
        const label = $(this).find(".option-label").val();
        if (value && label) {
          options.push({ value: value, label: label });
        }
      });

      optionsJsonInput.val(JSON.stringify(options));
    };

    // Remove field
    function removeField(fieldItem) {
      MetaDataServices.utils
        .showConfirmation(
          "Alanı Sil",
          "Bu alanı silmek istediğinizden emin misiniz?",
          "Evet, Sil",
          "İptal"
        )
        .then((result) => {
          if (result.isConfirmed) {
            fieldItem.remove();

            // Show empty state if no fields left
            const fieldsContainer =
              document.getElementById("fieldsContainer");
            const emptyState = document.getElementById(
              "fieldsEmptyState"
            );

            if (fieldsContainer.children.length === 0 && emptyState) {
              emptyState.style.display = "block";
            }

            // Reindex fields
            reindexFields();
          }
        });
    }

    // Switch field translation tab
    window.switchFieldTranslationTab = function (
      tabElement,
      languageId
    ) {
      const fieldItem = $(tabElement).closest(".field-item");

      // Hide all translation contents
      fieldItem.find(".field-translation-content").addClass("hidden");

      // Show selected translation content
      fieldItem
        .find(
          `.field-translation-content[data-language-id="${languageId}"]`
        )
        .removeClass("hidden");

      // Update tab styles
      fieldItem
        .find(".field-translation-tab")
        .removeClass("border-purple-500 text-purple-600")
        .addClass("border-transparent text-slate-500");
      $(tabElement)
        .removeClass("border-transparent text-slate-500")
        .addClass("border-purple-500 text-purple-600");
    };

    // Generate field key from name
    function generateFieldKey(fieldName) {
      return fieldName
        .toLowerCase()
        .replace(/[^a-z0-9\s]/g, "")
        .replace(/\s+/g, "_")
        .replace(/_+/g, "_")
        .trim("_");
    }

    // Get field index
    function getFieldIndex(fieldItem) {
      return Array.from(fieldItem.parent().children()).indexOf(
        fieldItem[0]
      );
    }

    // Reindex fields after removal
    function reindexFields() {
      const fieldItems = document.querySelectorAll(".field-item");
      fieldItems.forEach((fieldItem, index) => {
        // Update field number in header
        const header = fieldItem.querySelector("h4");
        if (header) {
          header.innerHTML = `<i class="fas fa-list-ul text-purple-600 mr-2"></i>Alan #${
            index + 1
          }`;
        }

        // Update all input names
        const inputs = fieldItem.querySelectorAll(
          "input, select, textarea"
        );
        inputs.forEach((input) => {
          if (input.name) {
            input.name = input.name.replace(
              /Fields\[\d+\]/,
              `Fields[${index}]`
            );
          }
        });
      });
    }

    // Initialize sortable
    function initializeSortable() {
      const fieldsContainer =
        document.getElementById("fieldsContainer");
      if (fieldsContainer && typeof Sortable !== "undefined") {
        new Sortable(fieldsContainer, {
          handle: ".drag-handle",
          animation: 150,
          onEnd: function () {
            reindexFields();
          },
        });
      }
    }

    // Set field data (for editing)
    function setFieldData(fieldElement, fieldData) {
      // Set basic field data
      fieldElement.querySelector(".field-name-input").value =
        fieldData.fieldName || "";
      fieldElement.querySelector(".field-key-input").value =
        fieldData.fieldKey || "";
      fieldElement.querySelector(".field-type-select").value =
        fieldData.type || "";

      // Trigger field type change to show options
      $(fieldElement.querySelector(".field-type-select")).trigger(
        "change"
      );

      // Set other field properties
      const checkboxes = {
        IsRequired: fieldData.isRequired,
        IsTranslatable: fieldData.isTranslatable,
        ShowInListing: fieldData.showInListing,
        ShowInDetails: fieldData.showInDetails,
        IsFilterable: fieldData.isFilterable,
        IsSortable: fieldData.isSortable,
        IsActive: fieldData.isActive,
      };

      Object.keys(checkboxes).forEach((key) => {
        const checkbox = fieldElement.querySelector(
          `input[name*="${key}"]`
        );
        if (checkbox) {
          checkbox.checked = checkboxes[key] || false;
        }
      });
    }

    // Public API
    return {
      init: init,
      addField: addField,
      removeField: removeField,
      updateFieldOptions: updateFieldOptions,
    };
  })();
}
