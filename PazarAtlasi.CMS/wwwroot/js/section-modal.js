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
let gridLayout = 3; // Default grid layout

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

  // Load and update page dropdowns
  loadAvailablePages();
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

  // Show/hide grid configuration
  const gridConfig = document.getElementById("gridConfiguration");
  if (gridConfig) {
    if (templateType === "Grid") {
      gridConfig.classList.remove("hidden");
      // Set initial grid layout
      const gridLayoutSelect = document.getElementById("gridLayout");
      if (gridLayoutSelect) {
        gridLayout = parseInt(gridLayoutSelect.value) || 3;
      }
    } else {
      gridConfig.classList.add("hidden");
    }
  }

  // Determine required items count
  switch (templateType) {
    case "Carousel":
      requiredItemsCount = 3;
      break;
    case "Grid":
      requiredItemsCount = gridLayout; // Use selected grid layout
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

function handleGridLayoutChange(layout) {
  gridLayout = parseInt(layout);
  requiredItemsCount = gridLayout;

  // Update items grid
  updateItemsGrid();
  updateItemsCountBadge();
}

function updateItemsGrid() {
  const itemsGrid = document.getElementById("itemsGrid");
  if (!itemsGrid) return;

  // Clear existing items
  itemsGrid.innerHTML = "";

  // Set grid layout classes based on template type and grid configuration
  let gridClasses = "grid gap-4";
  if (currentSection.templateType === "Grid") {
    if (gridLayout === 3) {
      gridClasses += " grid-cols-1 md:grid-cols-1 lg:grid-cols-3"; // 3 items in a row (vertical layout)
    } else if (gridLayout === 6) {
      gridClasses += " grid-cols-2 md:grid-cols-3 lg:grid-cols-3"; // 3x2 grid layout
    }
  } else {
    gridClasses += " grid-cols-1 md:grid-cols-3"; // Default layout for other types
  }

  itemsGrid.className = gridClasses;

  // Ensure we have the right number of items
  if (currentSection.templateType === "List") {
    // List: ensure at least 1 item
    while (currentSection.items.length < 1) {
      currentSection.items.push(createEmptyItem());
    }
  } else {
    // Other types: ensure required count
    while (currentSection.items.length < requiredItemsCount) {
      currentSection.items.push(createEmptyItem());
    }
  }

  // Generate item cards
  const itemsToShow =
    currentSection.templateType === "List"
      ? Math.max(currentSection.items.length, 1) // List: show all items, minimum 1
      : requiredItemsCount; // Other types: show required count

  for (let i = 0; i < itemsToShow; i++) {
    const item = currentSection.items[i] || createEmptyItem();
    const itemCard = createItemCard(item, i);
    itemsGrid.appendChild(itemCard);
  }

  // Update page dropdowns after cards are created
  setTimeout(() => updatePageDropdowns(), 100);

  // Show/hide add button for List type (allow dynamic addition)
  const addBtn = document.getElementById("addItemBtn");
  if (addBtn) {
    if (currentSection.templateType === "List") {
      addBtn.style.display = "inline-flex";
    } else {
      addBtn.style.display = "none";
    }
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
  card.className = `item-card ${
    item.pictureUrl || item.videoUrl ? "filled" : ""
  }`;
  card.setAttribute("data-index", index);

  const hasMedia =
    (item.pictureUrl && item.pictureUrl.trim() !== "") ||
    (item.videoUrl && item.videoUrl.trim() !== "");
  const isImage =
    item.mediaType === 1 || [2, 6, 9].includes(item.type); // Image, Gallery, Picture
  const isVideo = item.mediaType === 2 || item.type === 10; // Video
  const isAudio = item.mediaType === 4 || item.type === 7; // Audio
  const isDocument =
    item.mediaType === 5 || [8, 11].includes(item.type); // Pdf, Document

  card.innerHTML = `
        <div class="item-content">
            <!-- Item Type Selection -->
            <div class="mb-3">
                <label class="block text-xs font-medium text-slate-700 mb-1">Item Type</label>
                <select id="itemType${index}" class="w-full px-2 py-1 border border-slate-300 rounded text-xs" 
                        onchange="handleItemTypeChange(${index}, this.value)">
                    <option value="0" ${
                      item.type === 0 ? "selected" : ""
                    }>None</option>
                    <option value="1" ${
                      item.type === 1 ? "selected" : ""
                    }>Text</option>
                    <option value="2" ${
                      item.type === 2 ? "selected" : ""
                    }>Image</option>
                    <option value="3" ${
                      item.type === 3 ? "selected" : ""
                    }>Paragraph</option>
                    <option value="4" ${
                      item.type === 4 ? "selected" : ""
                    }>Link</option>
                    <option value="5" ${
                      item.type === 5 ? "selected" : ""
                    }>Button</option>
                    <option value="6" ${
                      item.type === 6 ? "selected" : ""
                    }>Gallery</option>
                    <option value="7" ${
                      item.type === 7 ? "selected" : ""
                    }>Audio</option>
                    <option value="8" ${
                      item.type === 8 ? "selected" : ""
                    }>Pdf</option>
                    <option value="9" ${
                      item.type === 9 ? "selected" : ""
                    }>Picture</option>
                    <option value="10" ${
                      item.type === 10 ? "selected" : ""
                    }>Video</option>
                    <option value="11" ${
                      item.type === 11 ? "selected" : ""
                    }>Document</option>
                    <option value="12" ${
                      item.type === 12 ? "selected" : ""
                    }>Map</option>
                    <option value="13" ${
                      item.type === 13 ? "selected" : ""
                    }>Form</option>
                    <option value="14" ${
                      item.type === 14 ? "selected" : ""
                    }>List</option>
                    <option value="15" ${
                      item.type === 15 ? "selected" : ""
                    }>Grid</option>
                    <option value="16" ${
                      item.type === 16 ? "selected" : ""
                    }>Sidebar</option>
                    <option value="17" ${
                      item.type === 17 ? "selected" : ""
                    }>Advertisement</option>
                    <option value="18" ${
                      item.type === 18 ? "selected" : ""
                    }>Search</option>
                    <option value="19" ${
                      item.type === 19 ? "selected" : ""
                    }>ContactForm</option>
                    <option value="20" ${
                      item.type === 20 ? "selected" : ""
                    }>SocialMediaLinks</option>
                    <option value="21" ${
                      item.type === 21 ? "selected" : ""
                    }>Testimonials</option>
                    <option value="22" ${
                      item.type === 22 ? "selected" : ""
                    }>CallToAction</option>
                    <option value="23" ${
                      item.type === 23 ? "selected" : ""
                    }>Breadcrumbs</option>
                    <option value="24" ${
                      item.type === 24 ? "selected" : ""
                    }>Pagination</option>
                </select>
            </div>

            ${
              hasMedia
                ? `
                <div class="item-preview mb-3 relative">
                    ${
                      isImage && item.pictureUrl
                        ? `<img src="${item.pictureUrl}" alt="Item ${
                            index + 1
                          }" />`
                        : isVideo && item.videoUrl
                        ? `<div class="video-preview bg-slate-100 rounded flex items-center justify-center h-24">
                            <i class="fas fa-play-circle text-3xl text-slate-400"></i>
                            <span class="ml-2 text-xs text-slate-600">Video</span>
                        </div>`
                        : `<div class="text-preview bg-slate-100 rounded p-3 h-24 flex items-center justify-center">
                            <i class="fas fa-font text-2xl text-slate-400"></i>
                        </div>`
                    }
                    <button type="button" onclick="removeItemMedia(${index})" 
                            class="absolute top-2 right-2 bg-red-500 text-white rounded-full p-1 hover:bg-red-600 text-xs">
                        <i class="fas fa-times"></i>
                    </button>
                </div>
            `
                : `
                <div class="item-placeholder mb-3">
                    ${
                      isImage
                        ? `<i class="fas fa-image text-4xl text-slate-400 mb-2"></i>`
                        : isVideo
                        ? `<i class="fas fa-video text-4xl text-slate-400 mb-2"></i>`
                        : isAudio
                        ? `<i class="fas fa-music text-4xl text-slate-400 mb-2"></i>`
                        : isDocument
                        ? `<i class="fas fa-file-pdf text-4xl text-slate-400 mb-2"></i>`
                        : `<i class="fas fa-font text-4xl text-slate-400 mb-2"></i>`
                    }
                    <p class="text-sm text-slate-600">Item ${
                      index + 1
                    }</p>
                </div>
            `
            }
            
            <div class="item-actions space-y-2">
                ${
                  isImage
                    ? `
                    <input type="file" id="itemImage${index}" accept="image/png,image/jpg,image/jpeg" class="hidden" 
                           onchange="handleItemImageUpload(this, ${index})" />
                    <button type="button" onclick="document.getElementById('itemImage${index}').click()" 
                            class="w-full py-1 px-3 bg-purple-600 hover:bg-purple-700 text-white rounded text-sm transition-colors">
                        <i class="fas fa-upload mr-1"></i> ${
                          item.pictureUrl
                            ? "Change Image"
                            : "Upload Image"
                        }
                    </button>
                `
                    : ""
                }
                
                ${
                  isVideo
                    ? `
                    <button type="button" onclick="editVideoUrl(${index})" 
                            class="w-full py-1 px-3 bg-red-600 hover:bg-red-700 text-white rounded text-sm transition-colors">
                        <i class="fas fa-video mr-1"></i> ${
                          item.videoUrl
                            ? "Change Video"
                            : "Add Video URL"
                        }
                    </button>
                `
                    : ""
                }
                
                ${
                  isAudio
                    ? `
                    <button type="button" onclick="editAudioUrl(${index})" 
                            class="w-full py-1 px-3 bg-green-600 hover:bg-green-700 text-white rounded text-sm transition-colors">
                        <i class="fas fa-music mr-1"></i> Add Audio URL
                    </button>
                `
                    : ""
                }
                
                ${
                  isDocument
                    ? `
                    <input type="file" id="itemDocument${index}" accept=".pdf,.doc,.docx" class="hidden" 
                           onchange="handleDocumentUpload(this, ${index})" />
                    <button type="button" onclick="document.getElementById('itemDocument${index}').click()" 
                            class="w-full py-1 px-3 bg-orange-600 hover:bg-orange-700 text-white rounded text-sm transition-colors">
                        <i class="fas fa-file-upload mr-1"></i> Upload Document
                    </button>
                `
                    : ""
                }
                
            </div>
            
            <!-- Direct Edit Fields -->
            <div class="mt-3 space-y-2">
                <div>
                    <label class="block text-xs font-medium text-slate-700 mb-1">Title</label>
                    <input type="text" id="itemTitle${index}" 
                           class="w-full px-2 py-1 border border-slate-300 rounded text-xs"
                           value="${
                             item.translations && item.translations[0]
                               ? item.translations[0].title || ""
                               : ""
                           }" 
                           placeholder="Enter title"
                           onchange="updateItemTranslation(${index}, 'title', this.value)" />
                </div>
                
                <div>
                    <label class="block text-xs font-medium text-slate-700 mb-1">Description</label>
                    <textarea id="itemDescription${index}" 
                              class="w-full px-2 py-1 border border-slate-300 rounded text-xs" 
                              rows="2"
                              placeholder="Enter description"
                              onchange="updateItemTranslation(${index}, 'description', this.value)">${
    item.translations && item.translations[0]
      ? item.translations[0].description || ""
      : ""
  }</textarea>
                </div>
                
                ${
                  item.type === 4 // Link type
                    ? `
                <div>
                    <label class="block text-xs font-medium text-slate-700 mb-1">Link to Page</label>
                    <select id="itemPageLink${index}" 
                            class="w-full px-2 py-1 border border-slate-300 rounded text-xs"
                            onchange="updateItemPageLink(${index}, this.value)">
                        <option value="">Select a page...</option>
                        <!-- Pages will be loaded dynamically -->
                    </select>
                </div>
                `
                    : ""
                }
                
                ${
                  item.type === 10
                    ? `
                <div>
                    <label class="block text-xs font-medium text-slate-700 mb-1">Video URL</label>
                    <input type="text" id="itemVideoUrl${index}" 
                           class="w-full px-2 py-1 border border-slate-300 rounded text-xs"
                           value="${item.videoUrl || ""}" 
                           placeholder="https://youtube.com/watch?v=..."
                           onchange="updateItemProperty(${index}, 'videoUrl', this.value)" />
                </div>
                `
                    : ""
                }
                
                <div>
                    <label class="block text-xs font-medium text-slate-700 mb-1">Custom Link URL</label>
                    <input type="text" id="itemRedirectUrl${index}" 
                           class="w-full px-2 py-1 border border-slate-300 rounded text-xs"
                           value="${item.redirectUrl || ""}" 
                           placeholder="https://example.com"
                           onchange="updateItemProperty(${index}, 'redirectUrl', this.value)" />
                </div>
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

function handleItemTypeChange(index, type) {
  const item = currentSection.items[index];
  item.type = parseInt(type);

  // Set appropriate media type based on SectionItemType enum
  switch (parseInt(type)) {
    case 2: // Image
    case 9: // Picture
    case 6: // Gallery
      item.mediaType = 1; // Image
      break;
    case 10: // Video
      item.mediaType = 2; // Video
      break;
    case 7: // Audio
      item.mediaType = 4; // Audio
      break;
    case 8: // Pdf
    case 11: // Document
      item.mediaType = 5; // Document
      break;
    default:
      item.mediaType = 0; // None for text, link, button, etc.
      break;
  }

  // Clear inappropriate media URLs when type changes
  if (![2, 6, 9].includes(parseInt(type))) {
    // Not Image, Gallery, or Picture
    item.pictureUrl = "";
  }
  if (parseInt(type) !== 10) {
    // Not Video
    item.videoUrl = "";
  }

  updateItemsGrid();
  updateItemsCountBadge();
}

function removeItemMedia(index) {
  if (confirm("Are you sure you want to remove this media?")) {
    currentSection.items[index].pictureUrl = "";
    currentSection.items[index].videoUrl = "";
    updateItemsGrid();
    updateItemsCountBadge();
  }
}

function editVideoUrl(index) {
  const item = currentSection.items[index];
  const currentUrl = item.videoUrl || "";

  const videoUrl = prompt(
    "Enter video URL (YouTube, Vimeo, etc.):",
    currentUrl
  );
  if (videoUrl !== null) {
    item.videoUrl = videoUrl.trim();
    updateItemsGrid();
    updateItemsCountBadge();
  }
}

function editAudioUrl(index) {
  const item = currentSection.items[index];
  const currentUrl = item.audioUrl || "";

  const audioUrl = prompt("Enter audio URL:", currentUrl);
  if (audioUrl !== null) {
    item.audioUrl = audioUrl.trim();
    updateItemsGrid();
    updateItemsCountBadge();
  }
}

async function handleDocumentUpload(input, index) {
  if (input.files && input.files[0]) {
    const file = input.files[0];

    // Show loading
    const card = document.querySelector(`[data-index="${index}"]`);
    const placeholder = card.querySelector(
      ".item-placeholder, .item-preview"
    );
    if (placeholder) {
      placeholder.innerHTML =
        '<i class="fas fa-spinner fa-spin text-2xl text-orange-600"></i><p class="text-sm text-slate-600 mt-2">Uploading...</p>';
    }

    try {
      // Upload document (using same endpoint as images for now)
      const formData = new FormData();
      formData.append("file", file);
      formData.append("folder", "documents");

      const response = await fetch("/Content/UploadImage", {
        method: "POST",
        body: formData,
      });

      const result = await response.json();

      if (result.success) {
        // Update item data
        currentSection.items[index].documentUrl = result.url;

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

function editItemContent(index) {
  const item = currentSection.items[index];

  // Create a content editor modal
  const contentModal = document.createElement("div");
  contentModal.className =
    "fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-60 p-4";
  contentModal.innerHTML = `
        <div class="bg-white rounded-lg p-6 w-full max-w-lg">
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
                
                ${
                  item.type === 10
                    ? `
                <div>
                    <label class="block text-sm font-medium text-slate-700 mb-1">Video URL</label>
                    <input type="text" id="itemVideoUrl${index}" class="w-full px-3 py-2 border border-slate-300 rounded-lg text-sm" 
                           value="${
                             item.videoUrl || ""
                           }" placeholder="https://youtube.com/watch?v=...">
                </div>
                `
                    : ""
                }
                
                <div>
                    <label class="block text-sm font-medium text-slate-700 mb-1">Link URL (optional)</label>
                    <input type="text" id="itemUrl${index}" class="w-full px-3 py-2 border border-slate-300 rounded-lg text-sm" 
                           value="${
                             item.redirectUrl || ""
                           }" placeholder="https://example.com">
                </div>
                
                ${
                  item.type === 2 || item.type === 10
                    ? `
                <div>
                    <label class="block text-sm font-medium text-slate-700 mb-1">Icon (optional)</label>
                    <input type="text" id="itemIcon${index}" class="w-full px-3 py-2 border border-slate-300 rounded-lg text-sm" 
                           value="${
                             item.icon || ""
                           }" placeholder="fas fa-star">
                </div>
                `
                    : ""
                }
            </div>
            
            <div class="flex items-center justify-end space-x-3 pt-4 mt-6 border-t border-slate-200">
                <button type="button" onclick="closeItemContentModal()" 
                        class="py-2 px-4 bg-slate-200 hover:bg-slate-300 text-slate-700 rounded-lg text-sm transition-colors">
                    Cancel
                </button>
                <button type="button" onclick="saveItemContent(${index})" 
                        class="py-2 px-4 bg-purple-600 hover:bg-purple-700 text-white rounded-lg text-sm transition-colors">
                    Save
                </button>
            </div>
        </div>
    `;

  document.body.appendChild(contentModal);
}

function closeItemContentModal() {
  const modal = document.querySelector(".fixed.inset-0.z-60");
  if (modal) {
    modal.remove();
  }
}

function saveItemContent(index) {
  const title = document.getElementById(`itemTitle${index}`).value;
  const description = document.getElementById(
    `itemDescription${index}`
  ).value;
  const url = document.getElementById(`itemUrl${index}`).value;

  // Update item data
  currentSection.items[index].redirectUrl = url;

  // Update video URL if it's a video item
  const videoUrlInput = document.getElementById(
    `itemVideoUrl${index}`
  );
  if (videoUrlInput) {
    currentSection.items[index].videoUrl = videoUrlInput.value;
  }

  // Update icon if available
  const iconInput = document.getElementById(`itemIcon${index}`);
  if (iconInput) {
    currentSection.items[index].icon = iconInput.value;
  }

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

  closeItemContentModal();
  updateItemsGrid();
}

function addNewItem() {
  // For List type, allow unlimited items
  if (
    currentSection.templateType === "List" ||
    currentSection.items.length < requiredItemsCount
  ) {
    currentSection.items.push(createEmptyItem());
    updateItemsGrid();
    updateItemsCountBadge();
  }
}

function updateItemsCountBadge() {
  const badge = document.getElementById("itemsCountBadge");
  if (badge) {
    const filledItems = currentSection.items.filter(
      (item) =>
        item.pictureUrl ||
        item.videoUrl ||
        (item.translations &&
          item.translations.length > 0 &&
          item.translations[0].title)
    ).length;

    if (currentSection.templateType === "List") {
      badge.textContent = `${filledItems} items`;
    } else {
      badge.textContent = `${filledItems}/${requiredItemsCount} items`;
    }
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

function switchLanguageTab(languageId) {
  // Hide all translation contents
  document
    .querySelectorAll(".translation-content")
    .forEach((content) => {
      content.classList.add("hidden");
    });

  // Show selected translation content
  const selectedContent = document.querySelector(
    `.translation-content[data-language-id="${languageId}"]`
  );
  if (selectedContent) {
    selectedContent.classList.remove("hidden");
  }

  // Update tab styles
  document.querySelectorAll(".language-tab").forEach((tab) => {
    tab.classList.remove("bg-green-100", "text-green-800");
    tab.classList.add(
      "text-slate-600",
      "hover:text-slate-800",
      "hover:bg-slate-50"
    );
  });

  // Activate selected tab
  const selectedTab = document.querySelector(
    `.language-tab[data-language-id="${languageId}"]`
  );
  if (selectedTab) {
    selectedTab.classList.remove(
      "text-slate-600",
      "hover:text-slate-800",
      "hover:bg-slate-50"
    );
    selectedTab.classList.add("bg-green-100", "text-green-800");
  }
}

// Make function globally available
window.switchLanguageTab = switchLanguageTab;

function gatherSectionTranslations() {
  const translations = [];

  document
    .querySelectorAll(
      "#sectionTranslationsContainer .translation-content"
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

// Make functions globally available
window.showSectionModal = showSectionModal;
window.closeSectionModal = closeSectionModal;
window.handleTemplateTypeChange = handleTemplateTypeChange;
window.handleGridLayoutChange = handleGridLayoutChange;
window.handleItemTypeChange = handleItemTypeChange;
window.handleItemImageUpload = handleItemImageUpload;
window.removeItemMedia = removeItemMedia;
window.editVideoUrl = editVideoUrl;
window.editAudioUrl = editAudioUrl;
window.handleDocumentUpload = handleDocumentUpload;
window.editItemContent = editItemContent;
window.closeItemContentModal = closeItemContentModal;
window.saveItemContent = saveItemContent;
window.addNewItem = addNewItem;
window.saveSection = saveSection;

function updateItemTranslation(index, field, value) {
  const item = currentSection.items[index];

  // Ensure translations array exists
  if (!item.translations || item.translations.length === 0) {
    item.translations = [
      {
        id: 0,
        languageId: 1, // Default language
        name: "",
        title: "",
        description: "",
      },
    ];
  }

  // Update the field
  if (field === "title") {
    item.translations[0].title = value;
    item.translations[0].name = value; // Also update name
  } else if (field === "description") {
    item.translations[0].description = value;
  }
}

function updateItemProperty(index, property, value) {
  const item = currentSection.items[index];
  item[property] = value;
}

function updateItemPageLink(index, pageId) {
  const item = currentSection.items[index];

  if (pageId && pageId !== "") {
    // Find the selected page and set redirect URL to its slug
    const selectedPage = availablePages.find((p) => p.id == pageId);
    if (selectedPage) {
      item.redirectUrl = `/${selectedPage.slug}`;
      item.linkedPageId = parseInt(pageId);

      // Update the custom URL field
      const customUrlInput = document.getElementById(
        `itemRedirectUrl${index}`
      );
      if (customUrlInput) {
        customUrlInput.value = item.redirectUrl;
      }
    }
  } else {
    item.linkedPageId = null;
  }
}

async function loadAvailablePages() {
  try {
    const response = await fetch("/Content/GetAvailablePages");
    const result = await response.json();

    if (result.success) {
      availablePages = result.pages;
      // Update all page dropdowns
      updatePageDropdowns();
    }
  } catch (error) {
    console.error("Error loading pages:", error);
    availablePages = [];
  }
}

function updatePageDropdowns() {
  // Update all existing page dropdowns (only for link-type items)
  document
    .querySelectorAll('[id^="itemPageLink"]')
    .forEach((select) => {
      const currentValue = select.value;

      // Clear existing options except the first one
      while (select.children.length > 1) {
        select.removeChild(select.lastChild);
      }

      // Add page options
      availablePages.forEach((page) => {
        const option = document.createElement("option");
        option.value = page.id;
        option.textContent = `${page.name} (/${page.slug})`;
        if (page.id == currentValue) {
          option.selected = true;
        }
        select.appendChild(option);
      });
    });
}

// Global variable to store available pages
let availablePages = [];

// Make new functions globally available
window.updateItemTranslation = updateItemTranslation;
window.updateItemProperty = updateItemProperty;
window.updateItemPageLink = updateItemPageLink;
window.loadAvailablePages = loadAvailablePages;

// Initialize when page loads
document.addEventListener("DOMContentLoaded", function () {
  // Load available pages when DOM is ready
  loadAvailablePages();
});
