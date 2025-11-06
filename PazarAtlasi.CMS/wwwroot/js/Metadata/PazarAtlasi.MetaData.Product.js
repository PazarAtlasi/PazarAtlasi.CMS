/**
 * PazarAtlasi MetaData Product Manager
 * Handles Product creation with schema support
 */

// Prevent redeclaration
if (typeof ProductManager === "undefined") {
  var ProductManager = (function () {
    "use strict";

    // Private variables
    let availableSchemas = [];
    let selectedSchemas = [];
    let schemaFields = {};
    let availableLanguages = [];

    // Initialize
    function init() {
      loadAvailableSchemas();
      loadLanguages();
      bindEvents();
    }

    // Load available schemas
    function loadAvailableSchemas() {
      MetaDataServices.product
        .getAvailableSchemas()
        .then((response) => {
          if (response.success) {
            availableSchemas = response.schemas;
            populateSchemaSelects();
          }
        })
        .catch((error) => {
          console.error("Error loading schemas:", error);
          // Fallback: show error message
          MetaDataServices.utils.showError(
            "Şemalar yüklenirken hata oluştu."
          );
        });
    }

    // Load available languages
    function loadLanguages() {
      // Get languages from the page context or make an API call
      availableLanguages = [
        { id: 1, name: "Türkçe", code: "tr-TR", isDefault: true },
        { id: 2, name: "English", code: "en-US", isDefault: false },
      ];
    }

    // Populate schema select dropdowns
    function populateSchemaSelects() {
      const primarySelect = document.getElementById(
        "primarySchemaSelect"
      );
      const additionalSelect = document.getElementById(
        "additionalSchemasSelect"
      );

      if (!primarySelect || !additionalSelect) return;

      // Clear existing options
      primarySelect.innerHTML =
        '<option value="">Şema seçin...</option>';
      additionalSelect.innerHTML = "";

      // Populate options
      availableSchemas.forEach((schema) => {
        // Primary schema option
        const primaryOption = document.createElement("option");
        primaryOption.value = schema.id;
        primaryOption.textContent = `${schema.name} (${schema.fieldsCount} alan)`;
        primaryOption.title = schema.description || "";
        primarySelect.appendChild(primaryOption);

        // Additional schema option
        const additionalOption = document.createElement("option");
        additionalOption.value = schema.id;
        additionalOption.textContent = `${schema.name} (${schema.fieldsCount} alan)`;
        additionalOption.title = schema.description || "";
        additionalSelect.appendChild(additionalOption);
      });
    }

    // Bind events
    function bindEvents() {
      // Primary schema selection
      const primarySelect = document.getElementById(
        "primarySchemaSelect"
      );
      if (primarySelect) {
        primarySelect.addEventListener("change", function () {
          const schemaId = parseInt(this.value);
          if (schemaId) {
            addSchemaToSelection(schemaId, true);
          } else {
            removeSchemaFromSelection(null, true);
          }
        });
      }

      // Additional schemas selection
      const additionalSelect = document.getElementById(
        "additionalSchemasSelect"
      );
      if (additionalSelect) {
        additionalSelect.addEventListener("change", function () {
          const selectedOptions = Array.from(this.selectedOptions);
          const selectedIds = selectedOptions.map((option) =>
            parseInt(option.value)
          );

          // Remove unselected additional schemas
          selectedSchemas
            .filter(
              (s) => !s.isPrimary && !selectedIds.includes(s.id)
            )
            .forEach((schema) =>
              removeSchemaFromSelection(schema.id, false)
            );

          // Add newly selected schemas
          selectedIds.forEach((schemaId) => {
            if (!selectedSchemas.find((s) => s.id === schemaId)) {
              addSchemaToSelection(schemaId, false);
            }
          });
        });
      }
    }

    // Add schema to selection
    function addSchemaToSelection(schemaId, isPrimary) {
      const schema = availableSchemas.find((s) => s.id === schemaId);
      if (!schema) return;

      // Remove existing primary schema if adding new primary
      if (isPrimary) {
        selectedSchemas = selectedSchemas.filter((s) => !s.isPrimary);
      }

      // Check if schema already exists
      const existingSchema = selectedSchemas.find(
        (s) => s.id === schemaId
      );
      if (existingSchema) {
        existingSchema.isPrimary = isPrimary;
      } else {
        selectedSchemas.push({
          ...schema,
          isPrimary: isPrimary,
        });
      }

      updateSelectedSchemasDisplay();
      loadSchemaFields(schemaId);
    }

    // Remove schema from selection
    function removeSchemaFromSelection(schemaId, isPrimary) {
      if (isPrimary) {
        // Remove primary schema
        selectedSchemas = selectedSchemas.filter((s) => !s.isPrimary);

        // Clear primary select
        const primarySelect = document.getElementById(
          "primarySchemaSelect"
        );
        if (primarySelect) {
          primarySelect.value = "";
        }
      } else if (schemaId) {
        // Remove specific additional schema
        selectedSchemas = selectedSchemas.filter(
          (s) => s.id !== schemaId
        );
      }

      updateSelectedSchemasDisplay();
      updateSchemaFieldsDisplay();
    }

    // Update selected schemas display
    function updateSelectedSchemasDisplay() {
      const container = document.getElementById(
        "selectedSchemasContainer"
      );
      const list = document.getElementById("selectedSchemasList");

      if (!container || !list) return;

      if (selectedSchemas.length === 0) {
        container.classList.add("hidden");
        return;
      }

      container.classList.remove("hidden");
      list.innerHTML = "";

      selectedSchemas.forEach((schema) => {
        const schemaCard = createSchemaCard(schema);
        list.appendChild(schemaCard);
      });
    }

    // Create schema card element
    function createSchemaCard(schema) {
      const card = document.createElement("div");
      card.className =
        "bg-slate-50 border border-slate-200 rounded-lg p-4";

      card.innerHTML = `
                <div class="flex items-center justify-between">
                    <div class="flex items-center">
                        <div class="h-10 w-10 rounded-full ${
                          schema.isPrimary
                            ? "bg-purple-100"
                            : "bg-blue-100"
                        } flex items-center justify-center">
                            <i class="fas fa-database ${
                              schema.isPrimary
                                ? "text-purple-600"
                                : "text-blue-600"
                            }"></i>
                        </div>
                        <div class="ml-4">
                            <div class="flex items-center">
                                <h4 class="text-sm font-semibold text-slate-800">${
                                  schema.name
                                }</h4>
                                ${
                                  schema.isPrimary
                                    ? '<span class="ml-2 inline-flex items-center px-2 py-1 rounded-full text-xs font-medium bg-purple-100 text-purple-800">Ana Şema</span>'
                                    : '<span class="ml-2 inline-flex items-center px-2 py-1 rounded-full text-xs font-medium bg-blue-100 text-blue-800">Ek Şema</span>'
                                }
                            </div>
                            <div class="text-xs text-slate-600 mt-1">
                                ${schema.fieldsCount} alan • ${
        schema.category || "Kategori yok"
      }
                            </div>
                            ${
                              schema.description
                                ? `<div class="text-xs text-slate-500 mt-1">${schema.description}</div>`
                                : ""
                            }
                        </div>
                    </div>
                    <button type="button" onclick="ProductManager.removeSchema(${
                      schema.id
                    }, ${schema.isPrimary})" 
                            class="text-red-600 hover:text-red-800 transition-colors">
                        <i class="fas fa-times"></i>
                    </button>
                </div>
            `;

      return card;
    }

    // Load schema fields
    function loadSchemaFields(schemaId) {
      if (schemaFields[schemaId]) {
        updateSchemaFieldsDisplay();
        return;
      }

      MetaDataServices.product
        .getSchemaFields(schemaId)
        .then((response) => {
          if (response.success) {
            schemaFields[schemaId] = response.fields;
            updateSchemaFieldsDisplay();
          }
        })
        .catch((error) => {
          console.error("Error loading schema fields:", error);
          MetaDataServices.utils.showError(
            "Şema alanları yüklenirken hata oluştu."
          );
        });
    }

    // Update schema fields display
    function updateSchemaFieldsDisplay() {
      const container = document.getElementById(
        "schemaFieldsContainer"
      );
      const content = document.getElementById("schemaFieldsContent");

      if (!container || !content) return;

      if (selectedSchemas.length === 0) {
        container.classList.add("hidden");
        return;
      }

      container.classList.remove("hidden");
      content.innerHTML = "";

      selectedSchemas.forEach((schema) => {
        const fields = schemaFields[schema.id];
        if (fields && fields.length > 0) {
          const schemaSection = createSchemaFieldsSection(
            schema,
            fields
          );
          content.appendChild(schemaSection);
        }
      });
    }

    // Create schema fields section
    function createSchemaFieldsSection(schema, fields) {
      const section = document.createElement("div");
      section.className =
        "mb-8 bg-slate-50 border border-slate-200 rounded-lg p-6";

      const headerHtml = `
                <div class="flex items-center mb-6">
                    <div class="h-8 w-8 rounded-full ${
                      schema.isPrimary
                        ? "bg-purple-100"
                        : "bg-blue-100"
                    } flex items-center justify-center">
                        <i class="fas fa-database ${
                          schema.isPrimary
                            ? "text-purple-600"
                            : "text-blue-600"
                        } text-sm"></i>
                    </div>
                    <div class="ml-3">
                        <h4 class="text-lg font-semibold text-slate-800">${
                          schema.name
                        }</h4>
                        <p class="text-sm text-slate-600">${
                          fields.length
                        } alan</p>
                    </div>
                </div>
            `;

      section.innerHTML = headerHtml;

      // Add fields
      const fieldsContainer = document.createElement("div");
      fieldsContainer.className = "space-y-6";

      fields.forEach((field, index) => {
        const fieldElement = createSchemaFieldElement(
          schema,
          field,
          index
        );
        fieldsContainer.appendChild(fieldElement);
      });

      section.appendChild(fieldsContainer);
      return section;
    }

    // Create schema field element
    function createSchemaFieldElement(schema, field, index) {
      const fieldDiv = document.createElement("div");
      fieldDiv.className = `schema-field ${
        field.isRequired ? "required-field" : ""
      }`;
      fieldDiv.setAttribute("data-schema-id", schema.id);
      fieldDiv.setAttribute("data-field-id", field.id);
      fieldDiv.setAttribute("data-required", field.isRequired);

      let fieldHtml = `
                <div class="flex items-start justify-between mb-2">
                    <div class="flex-1">
                        <label class="block text-sm font-medium text-slate-700">
                            ${field.fieldName}
                            ${
                              field.isRequired
                                ? '<span class="text-red-500 ml-1">*</span>'
                                : ""
                            }
                        </label>
                        ${
                          field.description
                            ? `<p class="text-xs text-slate-500 mt-1">${field.description}</p>`
                            : ""
                        }
                    </div>
                    <div class="flex items-center space-x-2 ml-4">
                        ${
                          field.isRequired
                            ? '<span class="inline-flex items-center px-2 py-1 rounded-full text-xs font-medium bg-red-100 text-red-800" title="Zorunlu"><i class="fas fa-asterisk"></i></span>'
                            : ""
                        }
                        ${
                          field.isTranslatable
                            ? '<span class="inline-flex items-center px-2 py-1 rounded-full text-xs font-medium bg-green-100 text-green-800" title="Çevrilebilir"><i class="fas fa-language"></i></span>'
                            : ""
                        }
                        ${
                          field.isFilterable
                            ? '<span class="inline-flex items-center px-2 py-1 rounded-full text-xs font-medium bg-blue-100 text-blue-800" title="Filtrelenebilir"><i class="fas fa-filter"></i></span>'
                            : ""
                        }
                    </div>
                </div>
            `;

      // Create input based on field type
      const inputElement = createFieldInput(schema, field, index);
      fieldDiv.innerHTML = fieldHtml;
      fieldDiv.appendChild(inputElement);

      // Add translations if field is translatable
      if (field.isTranslatable) {
        const translationsElement = createFieldTranslations(
          schema,
          field,
          index
        );
        fieldDiv.appendChild(translationsElement);
      }

      return fieldDiv;
    }

    // Create field input based on type
    function createFieldInput(schema, field, index) {
      const container = document.createElement("div");
      const inputName = `FieldValues[${schema.id}_${field.id}].Value`;
      const inputId = `field_${schema.id}_${field.id}`;

      let inputHtml = "";
      const commonClasses =
        "w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500";
      const placeholder =
        field.placeholder || `${field.fieldName} değeri girin`;

      switch (field.type) {
        case "Text":
          inputHtml = `<input type="text" name="${inputName}" id="${inputId}" class="${commonClasses}" placeholder="${placeholder}" ${
            field.isRequired ? "required" : ""
          }>`;
          break;

        case "TextArea":
          inputHtml = `<textarea name="${inputName}" id="${inputId}" rows="3" class="${commonClasses}" placeholder="${placeholder}" ${
            field.isRequired ? "required" : ""
          }></textarea>`;
          break;

        case "Number":
          inputHtml = `<input type="number" name="${inputName}" id="${inputId}" class="${commonClasses}" placeholder="${placeholder}" ${
            field.isRequired ? "required" : ""
          }>`;
          if (field.unit) {
            inputHtml = `
                            <div class="flex">
                                <input type="number" name="${inputName}" id="${inputId}" class="${commonClasses} rounded-r-none" placeholder="${placeholder}" ${
              field.isRequired ? "required" : ""
            }>
                                <span class="inline-flex items-center px-3 rounded-r-lg border border-l-0 border-slate-300 bg-slate-50 text-slate-500 text-sm">${
                                  field.unit
                                }</span>
                            </div>
                        `;
          }
          break;

        case "Boolean":
          inputHtml = `
                        <div class="flex items-center">
                            <input type="checkbox" name="${inputName}" id="${inputId}" class="h-4 w-4 text-blue-600 focus:ring-blue-500 border-slate-300 rounded" value="true">
                            <label for="${inputId}" class="ml-2 block text-sm text-slate-700">${field.fieldName}</label>
                        </div>
                    `;
          break;

        case "Date":
          inputHtml = `<input type="date" name="${inputName}" id="${inputId}" class="${commonClasses}" ${
            field.isRequired ? "required" : ""
          }>`;
          break;

        case "DateTime":
          inputHtml = `<input type="datetime-local" name="${inputName}" id="${inputId}" class="${commonClasses}" ${
            field.isRequired ? "required" : ""
          }>`;
          break;

        case "Email":
          inputHtml = `<input type="email" name="${inputName}" id="${inputId}" class="${commonClasses}" placeholder="${placeholder}" ${
            field.isRequired ? "required" : ""
          }>`;
          break;

        case "Url":
          inputHtml = `<input type="url" name="${inputName}" id="${inputId}" class="${commonClasses}" placeholder="${placeholder}" ${
            field.isRequired ? "required" : ""
          }>`;
          break;

        case "Color":
          inputHtml = `
                        <div class="flex items-center space-x-3">
                            <input type="color" name="${inputName}" id="${inputId}" class="h-10 w-20 border border-slate-300 rounded-lg cursor-pointer" ${
            field.isRequired ? "required" : ""
          }>
                            <input type="text" class="${commonClasses} flex-1" placeholder="Renk kodu (örn: #FF0000)" readonly>
                        </div>
                    `;
          break;

        case "Select":
          if (field.optionsJson) {
            try {
              const options = JSON.parse(field.optionsJson);
              let optionsHtml = '<option value="">Seçin...</option>';
              options.forEach((option) => {
                optionsHtml += `<option value="${option.value}">${option.label}</option>`;
              });
              inputHtml = `<select name="${inputName}" id="${inputId}" class="${commonClasses}" ${
                field.isRequired ? "required" : ""
              }>${optionsHtml}</select>`;
            } catch (e) {
              inputHtml = `<input type="text" name="${inputName}" id="${inputId}" class="${commonClasses}" placeholder="${placeholder}" ${
                field.isRequired ? "required" : ""
              }>`;
            }
          } else {
            inputHtml = `<input type="text" name="${inputName}" id="${inputId}" class="${commonClasses}" placeholder="${placeholder}" ${
              field.isRequired ? "required" : ""
            }>`;
          }
          break;

        case "MultiSelect":
          if (field.optionsJson) {
            try {
              const options = JSON.parse(field.optionsJson);
              let optionsHtml = "";
              options.forEach((option) => {
                optionsHtml += `<option value="${option.value}">${option.label}</option>`;
              });
              inputHtml = `<select name="${inputName}" id="${inputId}" class="${commonClasses}" multiple size="4" ${
                field.isRequired ? "required" : ""
              }>${optionsHtml}</select>`;
            } catch (e) {
              inputHtml = `<input type="text" name="${inputName}" id="${inputId}" class="${commonClasses}" placeholder="${placeholder}" ${
                field.isRequired ? "required" : ""
              }>`;
            }
          } else {
            inputHtml = `<input type="text" name="${inputName}" id="${inputId}" class="${commonClasses}" placeholder="${placeholder}" ${
              field.isRequired ? "required" : ""
            }>`;
          }
          break;

        case "Image":
          inputHtml = `
                        <div class="space-y-3">
                            <input type="file" name="${inputName}_file" id="${inputId}_file" accept="image/*" class="block w-full text-sm text-slate-500 file:mr-4 file:py-2 file:px-4 file:rounded-lg file:border-0 file:text-sm file:font-semibold file:bg-blue-50 file:text-blue-700 hover:file:bg-blue-100">
                            <input type="hidden" name="${inputName}" id="${inputId}">
                            <div id="${inputId}_preview" class="hidden">
                                <img class="h-20 w-20 object-cover rounded-lg border border-slate-300" alt="Preview">
                            </div>
                        </div>
                    `;
          break;

        case "File":
          inputHtml = `
                        <div class="space-y-3">
                            <input type="file" name="${inputName}_file" id="${inputId}_file" class="block w-full text-sm text-slate-500 file:mr-4 file:py-2 file:px-4 file:rounded-lg file:border-0 file:text-sm file:font-semibold file:bg-blue-50 file:text-blue-700 hover:file:bg-blue-100">
                            <input type="hidden" name="${inputName}" id="${inputId}">
                        </div>
                    `;
          break;

        default:
          inputHtml = `<input type="text" name="${inputName}" id="${inputId}" class="${commonClasses}" placeholder="${placeholder}" ${
            field.isRequired ? "required" : ""
          }>`;
          break;
      }

      container.innerHTML = inputHtml;

      // Add event listeners for special field types
      if (field.type === "Color") {
        const colorInput = container.querySelector(
          'input[type="color"]'
        );
        const textInput = container.querySelector(
          'input[type="text"]'
        );
        if (colorInput && textInput) {
          colorInput.addEventListener("change", function () {
            textInput.value = this.value;
          });
        }
      }

      // Add file upload handlers
      if (field.type === "Image" || field.type === "File") {
        const fileInput = container.querySelector(
          'input[type="file"]'
        );
        const hiddenInput = container.querySelector(
          'input[type="hidden"]'
        );

        if (fileInput && hiddenInput) {
          fileInput.addEventListener("change", function () {
            if (this.files && this.files[0]) {
              const file = this.files[0];
              const folder =
                field.type === "Image"
                  ? "products/images"
                  : "products/files";

              MetaDataServices.utils.showLoading(
                this.parentElement,
                "Yükleniyor..."
              );

              const uploadPromise =
                field.type === "Image"
                  ? MetaDataServices.file.uploadImage(file, folder)
                  : MetaDataServices.file.uploadFile(file, folder);

              uploadPromise
                .then((response) => {
                  if (response.success) {
                    hiddenInput.value = response.url;

                    if (field.type === "Image") {
                      const preview = container.querySelector(
                        `#${inputId}_preview`
                      );
                      const img = preview.querySelector("img");
                      if (preview && img) {
                        img.src = response.url;
                        preview.classList.remove("hidden");
                      }
                    }

                    MetaDataServices.utils.showSuccess(
                      "Dosya başarıyla yüklendi."
                    );
                  } else {
                    MetaDataServices.utils.showError(
                      response.message ||
                        "Dosya yüklenirken hata oluştu."
                    );
                  }
                })
                .catch((error) => {
                  console.error("File upload error:", error);
                  MetaDataServices.utils.showError(
                    "Dosya yüklenirken hata oluştu."
                  );
                })
                .finally(() => {
                  MetaDataServices.utils.hideLoading(
                    this.parentElement,
                    "Dosya Seç"
                  );
                });
            }
          });
        }
      }

      return container;
    }

    // Create field translations
    function createFieldTranslations(schema, field, index) {
      const container = document.createElement("div");
      container.className =
        "mt-4 bg-white border border-slate-200 rounded-lg p-4";

      let translationsHtml = `
                <h5 class="text-sm font-semibold text-slate-800 mb-3 flex items-center">
                    <i class="fas fa-language text-green-600 mr-2"></i>
                    ${field.fieldName} Çevirileri
                </h5>
                
                <!-- Translation Tabs -->
                <div class="border-b border-slate-200 mb-3">
                    <nav class="-mb-px flex space-x-4">
                        ${availableLanguages
                          .map(
                            (lang, langIndex) => `
                            <button type="button" 
                                    class="field-translation-tab py-1 px-2 border-b-2 font-medium text-xs transition-colors ${
                                      lang.isDefault
                                        ? "border-green-500 text-green-600"
                                        : "border-transparent text-slate-500 hover:text-slate-700 hover:border-slate-300"
                                    }"
                                    data-language-id="${lang.id}"
                                    onclick="ProductManager.switchFieldTranslationTab(this, ${
                                      lang.id
                                    }, '${schema.id}_${field.id}')">
                                ${lang.name}
                                ${
                                  lang.isDefault
                                    ? '<span class="ml-1 text-xs bg-green-100 text-green-600 px-1 py-0.5 rounded">Varsayılan</span>'
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
                    <div class="field-translation-content ${
                      lang.isDefault ? "" : "hidden"
                    }" data-language-id="${
                      lang.id
                    }" data-field-key="${schema.id}_${field.id}">
                        <input type="hidden" name="FieldValues[${
                          schema.id
                        }_${
                      field.id
                    }].Translations[${langIndex}].LanguageId" value="${
                      lang.id
                    }" />
                        <input type="hidden" name="FieldValues[${
                          schema.id
                        }_${
                      field.id
                    }].Translations[${langIndex}].LanguageName" value="${
                      lang.name
                    }" />
                        <input type="hidden" name="FieldValues[${
                          schema.id
                        }_${
                      field.id
                    }].Translations[${langIndex}].IsDefault" value="${
                      lang.isDefault
                    }" />
                        
                        <div>
                            <label class="block text-xs font-medium text-slate-700 mb-1">${
                              field.fieldName
                            } (${lang.name})</label>
                            <input type="text" name="FieldValues[${
                              schema.id
                            }_${
                      field.id
                    }].Translations[${langIndex}].Value" 
                                   class="w-full px-3 py-2 text-sm border border-slate-300 rounded-lg focus:ring-2 focus:ring-green-500 focus:border-green-500" 
                                   placeholder="${
                                     lang.name
                                   } dilinde ${field.fieldName.toLowerCase()}">
                        </div>
                    </div>
                `
                  )
                  .join("")}
            `;

      container.innerHTML = translationsHtml;
      return container;
    }

    // Switch field translation tab
    function switchFieldTranslationTab(
      tabElement,
      languageId,
      fieldKey
    ) {
      const container = tabElement.closest(".schema-field");

      // Hide all translation contents for this field
      container
        .querySelectorAll(
          `.field-translation-content[data-field-key="${fieldKey}"]`
        )
        .forEach((content) => {
          content.classList.add("hidden");
        });

      // Show selected translation content
      const selectedContent = container.querySelector(
        `.field-translation-content[data-language-id="${languageId}"][data-field-key="${fieldKey}"]`
      );
      if (selectedContent) {
        selectedContent.classList.remove("hidden");
      }

      // Update tab styles
      container
        .querySelectorAll(".field-translation-tab")
        .forEach((tab) => {
          tab.classList.remove("border-green-500", "text-green-600");
          tab.classList.add("border-transparent", "text-slate-500");
        });

      tabElement.classList.remove(
        "border-transparent",
        "text-slate-500"
      );
      tabElement.classList.add("border-green-500", "text-green-600");
    }

    // Remove schema (public method)
    function removeSchema(schemaId, isPrimary) {
      removeSchemaFromSelection(schemaId, isPrimary);

      // Update select elements
      if (isPrimary) {
        const primarySelect = document.getElementById(
          "primarySchemaSelect"
        );
        if (primarySelect) {
          primarySelect.value = "";
        }
      } else {
        const additionalSelect = document.getElementById(
          "additionalSchemasSelect"
        );
        if (additionalSelect) {
          const option = additionalSelect.querySelector(
            `option[value="${schemaId}"]`
          );
          if (option) {
            option.selected = false;
          }
        }
      }
    }

    // Public API
    return {
      init: init,
      removeSchema: removeSchema,
      switchFieldTranslationTab: switchFieldTranslationTab,
    };
  })();
}
