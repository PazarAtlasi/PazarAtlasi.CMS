// Section Modal Management
let currentSection = {
  id: 0,
  pageId: 0,
  type: "Content",
  templateType: "Default",
  status: 1,
  items: [],
  translations: [],
};

let requiredItemsCount = 1;

function showSectionModal(html) {
  // Remove existing modal if any
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
  modalOverlay.style.overflowY = "auto";
  modalOverlay.innerHTML = html;

  document.body.appendChild(modalOverlay);
  document.body.style.overflow = "hidden";

  // Ensure modal content is scrollable
  const modalContent = modalOverlay.querySelector(".section-modal");
  if (modalContent) {
    modalContent.style.maxHeight = "90vh";
    modalContent.style.overflowY = "auto";
    modalContent.style.overflowX = "hidden";
  }

  // Initialize modal
  initializeSectionModal();
}

function closeSectionModal() {
  const modal = document.getElementById("sectionModalOverlay");
  if (modal) {
    modal.remove();
    document.body.style.overflow = "";
  }
}

function initializeSectionModal() {
  // Get current section data
  currentSection.id =
    parseInt(document.getElementById("sectionId").value) || 0;
  currentSection.pageId = parseInt(
    document.getElementById("pageId").value
  );
  currentSection.type = document.getElementById("sectionType").value;
  currentSection.templateType = document.getElementById(
    "sectionTemplateType"
  ).value;
  currentSection.status = parseInt(
    document.getElementById("sectionStatus").value
  );

  // Initialize items based on template type
  handleTemplateTypeChange(currentSection.templateType);
}

function handleTemplateTypeChange(templateType) {
  currentSection.templateType = templateType;

  // Determine required items count
  switch (templateType) {
    case "Carousel":
      requiredItemsCount = 3;
      break;
    case "Grid":
      requiredItemsCount = 6;
      break;
    case "List":
      requiredItemsCount = 4;
      break;
    case "SingleItem":
      requiredItemsCount = 1;
      break;
    default:
      requiredItemsCount = 1;
      break;
  }

  // Update items grid
  updateItemsGrid();

  // Update UI
  updateItemsCountBadge();
}

function updateItemsGrid() {
  const itemsGrid = document.getElementById("itemsGrid");
  if (!itemsGrid) return;

  // Clear existing items
  itemsGrid.innerHTML = "";

  // Ensure we have the right number of items
  while (currentSection.items.length < requiredItemsCount) {
    currentSection.items.push(createEmptyItem());
  }

  // Generate item cards
  for (let i = 0; i < requiredItemsCount; i++) {
    const item = currentSection.items[i] || createEmptyItem();
    const itemCard = createItemCard(item, i);
    itemsGrid.appendChild(itemCard);
  }

  // Show/hide add button
  const addBtn = document.getElementById("addItemBtn");
  if (addBtn) {
    addBtn.style.display =
      currentSection.items.length < requiredItemsCount
        ? "inline-flex"
        : "none";
  }
}

function createEmptyItem() {
  return {
    id: 0,
    type: 2, // Image
    mediaType: 1, // Image
    pictureUrl: "",
    videoUrl: "",
    redirectUrl: "",
    icon: "",
    sortOrder: currentSection.items.length + 1,
    mediaAttributes: "{}",
    status: 1,
    translations: [],
  };
}

function createItemCard(item, index) {
  const card = document.createElement("div");
  card.className = `item-card ${item.pictureUrl ? "filled" : ""}`;
  card.setAttribute("data-index", index);

  const hasImage = item.pictureUrl && item.pictureUrl.trim() !== "";

  card.innerHTML = `
        <div class="item-content">
            ${
              hasImage
                ? `
                <div class="item-preview mb-3">
                    <img src="${item.pictureUrl}" alt="Item ${
                    index + 1
                  }" />
                    <button type="button" onclick="removeItemImage(${index})" 
                            class="absolute top-2 right-2 bg-red-500 text-white rounded-full p-1 hover:bg-red-600 text-xs">
                        <i class="fas fa-times"></i>
                    </button>
                </div>
            `
                : `
                <div class="item-placeholder mb-3">
                    <i class="fas fa-image text-4xl text-slate-400 mb-2"></i>
                    <p class="text-sm text-slate-600">Item ${
                      index + 1
                    }</p>
                </div>
            `
            }
            
            <div class="item-actions">
                <input type="file" id="itemImage${index}" accept="image/*" class="hidden" 
                       onchange="handleItemImageUpload(this, ${index})" />
                <button type="button" onclick="document.getElementById('itemImage${index}').click()" 
                        class="py-1 px-3 bg-purple-600 hover:bg-purple-700 text-white rounded text-sm transition-colors">
                    <i class="fas fa-upload mr-1"></i> ${
                      hasImage ? "Change" : "Upload"
                    }
                </button>
                
                ${
                  hasImage
                    ? `
                    <button type="button" onclick="editItemTranslations(${index})" 
                            class="ml-2 py-1 px-3 bg-blue-600 hover:bg-blue-700 text-white rounded text-sm transition-colors">
                        <i class="fas fa-edit mr-1"></i> Edit
                    </button>
                `
                    : ""
                }
            </div>
        </div>
    `;

  return card;
}

async function handleItemImageUpload(input, index) {
  if (input.files && input.files[0]) {
    const file = input.files[0];

    // Show loading
    const card = document.querySelector(`[data-index="${index}"]`);
    const placeholder = card.querySelector(
      ".item-placeholder, .item-preview"
    );
    if (placeholder) {
      placeholder.innerHTML =
        '<i class="fas fa-spinner fa-spin text-2xl text-purple-600"></i><p class="text-sm text-slate-600 mt-2">Uploading...</p>';
    }

    try {
      // Upload image
      const formData = new FormData();
      formData.append("file", file);
      formData.append("folder", "sections");

      const response = await fetch("/Content/UploadImage", {
        method: "POST",
        body: formData,
      });

      const result = await response.json();

      if (result.success) {
        // Update item data
        currentSection.items[index].pictureUrl = result.url;

        // Refresh the item card
        updateItemsGrid();
        updateItemsCountBadge();
      } else {
        alert("Upload failed: " + result.message);
        updateItemsGrid(); // Reset the card
      }
    } catch (error) {
      console.error("Upload error:", error);
      alert("Upload failed. Please try again.");
      updateItemsGrid(); // Reset the card
    }
  }
}

function removeItemImage(index) {
  if (confirm("Are you sure you want to remove this image?")) {
    currentSection.items[index].pictureUrl = "";
    updateItemsGrid();
    updateItemsCountBadge();
  }
}

function editItemTranslations(index) {
  const item = currentSection.items[index];

  // Create a simple inline translation editor
  const translationModal = document.createElement("div");
  translationModal.className =
    "fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-60 p-4";
  translationModal.innerHTML = `
        <div class="bg-white rounded-lg p-6 w-full max-w-md">
            <h3 class="text-lg font-semibold text-slate-800 mb-4">Edit Item ${
              index + 1
            } Content</h3>
            
            <div class="space-y-4">
                <div>
                    <label class="block text-sm font-medium text-slate-700 mb-1">Title</label>
                    <input type="text" id="itemTitle${index}" class="w-full px-3 py-2 border border-slate-300 rounded-lg text-sm" 
                           value="${
                             item.translations[0]?.title || ""
                           }" placeholder="Enter title">
                </div>
                
                <div>
                    <label class="block text-sm font-medium text-slate-700 mb-1">Description</label>
                    <textarea id="itemDescription${index}" class="w-full px-3 py-2 border border-slate-300 rounded-lg text-sm" rows="3" 
                              placeholder="Enter description">${
                                item.translations[0]?.description ||
                                ""
                              }</textarea>
                </div>
                
                <div>
                    <label class="block text-sm font-medium text-slate-700 mb-1">Link URL (optional)</label>
                    <input type="text" id="itemUrl${index}" class="w-full px-3 py-2 border border-slate-300 rounded-lg text-sm" 
                           value="${
                             item.redirectUrl || ""
                           }" placeholder="https://example.com">
                </div>
            </div>
            
            <div class="flex items-center justify-end space-x-3 pt-4 mt-6 border-t border-slate-200">
                <button type="button" onclick="closeItemTranslationModal()" 
                        class="py-2 px-4 bg-slate-200 hover:bg-slate-300 text-slate-700 rounded-lg text-sm transition-colors">
                    Cancel
                </button>
                <button type="button" onclick="saveItemTranslations(${index})" 
                        class="py-2 px-4 bg-purple-600 hover:bg-purple-700 text-white rounded-lg text-sm transition-colors">
                    Save
                </button>
            </div>
        </div>
    `;

  document.body.appendChild(translationModal);
}

function closeItemTranslationModal() {
  const modal = document.querySelector(".fixed.inset-0.z-60");
  if (modal) {
    modal.remove();
  }
}

function saveItemTranslations(index) {
  const title = document.getElementById(`itemTitle${index}`).value;
  const description = document.getElementById(
    `itemDescription${index}`
  ).value;
  const url = document.getElementById(`itemUrl${index}`).value;

  // Update item data
  currentSection.items[index].redirectUrl = url;

  // Ensure translations array exists
  if (!currentSection.items[index].translations.length) {
    currentSection.items[index].translations.push({
      id: 0,
      languageId: 1, // Default language
      name: title,
      title: title,
      description: description,
    });
  } else {
    currentSection.items[index].translations[0].title = title;
    currentSection.items[index].translations[0].description =
      description;
    currentSection.items[index].translations[0].name = title;
  }

  closeItemTranslationModal();
  updateItemsGrid();
}

function addNewItem() {
  if (currentSection.items.length < requiredItemsCount) {
    currentSection.items.push(createEmptyItem());
    updateItemsGrid();
    updateItemsCountBadge();
  }
}

function updateItemsCountBadge() {
  const badge = document.getElementById("itemsCountBadge");
  if (badge) {
    const filledItems = currentSection.items.filter(
      (item) => item.pictureUrl
    ).length;
    badge.textContent = `${filledItems}/${requiredItemsCount} items`;
  }
}

async function saveSection() {
  try {
    // Gather section data
    const sectionData = {
      Id: currentSection.id,
      PageId: currentSection.pageId,
      Type: parseInt(document.getElementById("sectionType").value),
      SectionTemplateType: parseInt(
        document.getElementById("sectionTemplateType").value
      ),
      Status: parseInt(
        document.getElementById("sectionStatus").value
      ),
      SortOrder: 1, // Will be set by backend
      Attributes: "{}",
      Configure: "{}",
      SectionItems: currentSection.items.filter(
        (item) => item.pictureUrl
      ), // Only include items with images
      Translations: gatherSectionTranslations(),
    };

    console.log("Saving section:", sectionData);

    const response = await fetch("/Content/SaveSection", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        RequestVerificationToken: document.querySelector(
          'input[name="__RequestVerificationToken"]'
        ).value,
      },
      body: JSON.stringify(sectionData),
    });

    const result = await response.json();

    if (result.success) {
      closeSectionModal();

      // Refresh the page sections
      location.reload(); // Simple refresh for now
    } else {
      alert("Error saving section: " + result.message);
    }
  } catch (error) {
    console.error("Save error:", error);
    alert("Error saving section. Please try again.");
  }
}

function gatherSectionTranslations() {
  const translations = [];

  document
    .querySelectorAll(
      "#sectionTranslationsContainer .translation-item"
    )
    .forEach((item) => {
      const languageId = parseInt(
        item.getAttribute("data-language-id")
      );
      const title = item.querySelector(
        ".section-translation-title"
      ).value;
      const description = item.querySelector(
        ".section-translation-description"
      ).value;

      if (title || description) {
        translations.push({
          Id: 0,
          LanguageId: languageId,
          Name: title,
          Title: title,
          Description: description,
        });
      }
    });

  return translations;
}

// Initialize when page loads
document.addEventListener("DOMContentLoaded", function () {
  // Any initialization code here
});
