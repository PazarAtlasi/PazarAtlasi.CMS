// Section Item Modal Management
let currentMediaType = "None";
let sliderImages = ["", "", ""];

function showSectionItemModal(html) {
  // Remove existing modal if any
  const existingModal = document.getElementById(
    "sectionItemModalOverlay"
  );
  if (existingModal) {
    existingModal.remove();
  }

  // Create modal overlay
  const modalOverlay = document.createElement("div");
  modalOverlay.id = "sectionItemModalOverlay";
  modalOverlay.className =
    "fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50 p-4";
  modalOverlay.style.overflowY = "auto";
  modalOverlay.innerHTML = html;

  document.body.appendChild(modalOverlay);
  document.body.style.overflow = "hidden";

  // Ensure modal content is scrollable
  const modalContent = modalOverlay.querySelector(
    ".section-item-modal"
  );
  if (modalContent) {
    modalContent.style.maxHeight = "90vh";
    modalContent.style.overflowY = "auto";
    modalContent.style.overflowX = "hidden";
  }

  // Initialize modal
  initializeSectionItemModal();
}

function closeSectionItemModal() {
  const modal = document.getElementById("sectionItemModalOverlay");
  if (modal) {
    modal.remove();
    document.body.style.overflow = "";
  }

  // Reset variables
  currentMediaType = "None";
  sliderImages = ["", "", ""];
}

function initializeSectionItemModal() {
  // Get current media type from active button
  const activeMediaBtn = document.querySelector(
    ".media-type-btn.active"
  );
  if (activeMediaBtn) {
    currentMediaType = activeMediaBtn.dataset.mediaType;
  }

  // Initialize item type visibility
  const itemTypeSelect = document.getElementById("itemType");
  if (itemTypeSelect) {
    handleItemTypeChange(itemTypeSelect.value);
  }
}

// Handle Item Type Change
function handleItemTypeChange(itemType) {
  console.log("Item Type Changed:", itemType); // Debug

  const mediaSettingsPanel = document.getElementById(
    "mediaSettingsPanel"
  );
  const translationsContainer = document.getElementById(
    "translationsContainer"
  );

  // Parse enum value to number
  const typeValue = parseInt(itemType);
  console.log("Type Value:", typeValue); // Debug

  // SectionItemType enum values:
  // None = 0, Text = 1, Image = 2, Paragraph = 3, Link = 4, Button = 5,
  // Gallery = 6, Audio = 7, Pdf = 8, Picture = 9, Video = 10

  const mediaTypes = [2, 6, 9, 10]; // Image, Gallery, Picture, Video
  const needsMedia = mediaTypes.includes(typeValue);

  console.log("Needs Media:", needsMedia); // Debug
  console.log("Media Panel Element:", mediaSettingsPanel); // Debug

  if (mediaSettingsPanel) {
    mediaSettingsPanel.style.display = needsMedia ? "block" : "none";
    console.log(
      "Media Panel Display:",
      mediaSettingsPanel.style.display
    ); // Debug
  } else {
    console.error("Media settings panel not found!");
  }

  // Update translation labels based on type
  updateTranslationLabels(typeValue);
}

// Update translation field labels based on item type
function updateTranslationLabels(typeValue) {
  const titleLabels = document.querySelectorAll(
    ".translation-item label"
  );

  // Customize labels based on type
  if (typeValue === 1) {
    // Text
    // Show text-focused fields
  } else if (typeValue === 2 || typeValue === 9 || typeValue === 10) {
    // Image, Picture, Video
    // Show image/video description fields
  }
}

// Media Type Selection
function selectMediaType(mediaType) {
  currentMediaType = mediaType;

  // Update button states
  document.querySelectorAll(".media-type-btn").forEach((btn) => {
    btn.classList.remove("active");
  });

  const selectedBtn = document.querySelector(
    `[data-media-type="${mediaType}"]`
  );
  if (selectedBtn) {
    selectedBtn.classList.add("active");
  }

  // Show/hide appropriate upload sections
  document
    .querySelectorAll(".media-upload-section")
    .forEach((section) => {
      section.style.display = "none";
    });

  switch (mediaType) {
    case "Image":
      document.getElementById("singleImageUpload").style.display =
        "block";
      break;
    case "ImageSlider":
      document.getElementById("sliderImagesUpload").style.display =
        "block";
      break;
    case "Video":
      document.getElementById("videoUpload").style.display = "block";
      break;
  }
}

// Single Image Upload
async function handleSingleImageUpload(input) {
  if (!input.files || !input.files[0]) return;

  const file = input.files[0];
  const formData = new FormData();
  formData.append("file", file);
  formData.append("folder", "hero");

  try {
    showUploadProgress("Uploading image...");

    const response = await fetch("/Content/UploadImage", {
      method: "POST",
      body: formData,
    });

    const result = await response.json();

    if (result.success) {
      document.getElementById("pictureUrl").value = result.url;

      // Show preview
      const preview = document.getElementById("singleImagePreview");
      preview.src = result.url;
      preview.classList.remove("hidden");

      const placeholder = document.getElementById(
        "singleImagePlaceholder"
      );
      if (placeholder) {
        placeholder.style.display = "none";
      }

      showNotification("Image uploaded successfully", "success");
    } else {
      showNotification(
        result.message || "Failed to upload image",
        "error"
      );
    }
  } catch (error) {
    console.error("Upload error:", error);
    showNotification("An error occurred while uploading", "error");
  } finally {
    hideUploadProgress();
  }
}

function removeSingleImage() {
  if (!confirm("Are you sure you want to remove this image?")) return;

  document.getElementById("pictureUrl").value = "";
  document
    .getElementById("singleImagePreview")
    .classList.add("hidden");

  const placeholder = document.getElementById(
    "singleImagePlaceholder"
  );
  if (placeholder) {
    placeholder.style.display = "block";
  }
}

// Slider Images Upload
async function handleSliderImageUpload(input, slotIndex) {
  if (!input.files || !input.files[0]) return;

  const file = input.files[0];
  const formData = new FormData();
  formData.append("file", file);
  formData.append("folder", "hero-slider");

  try {
    showUploadProgress("Uploading image...");

    const response = await fetch("/Content/UploadImage", {
      method: "POST",
      body: formData,
    });

    const result = await response.json();

    if (result.success) {
      sliderImages[slotIndex] = result.url;

      // Update preview
      const slot = document.querySelector(
        `.slider-image-slot[data-slot="${slotIndex}"]`
      );
      if (slot) {
        slot.innerHTML = `
                    <div class="relative">
                        <img src="${result.url}" alt="Slider ${
          slotIndex + 1
        }" class="w-full h-24 object-cover rounded" />
                        <button type="button" onclick="removeSliderImage(${slotIndex})" 
                                class="absolute top-1 right-1 bg-red-500 text-white rounded-full p-1 hover:bg-red-600 text-xs">
                            <i class="fas fa-times"></i>
                        </button>
                    </div>
                    <input type="file" id="sliderImage${slotIndex}" accept="image/*" class="hidden" onchange="handleSliderImageUpload(this, ${slotIndex})" />
                    <button type="button" onclick="document.getElementById('sliderImage${slotIndex}').click()" 
                            class="mt-2 py-1 px-2 bg-slate-200 hover:bg-slate-300 text-slate-700 rounded text-xs">
                        <i class="fas fa-upload mr-1"></i> Upload
                    </button>
                `;
      }

      showNotification(
        `Slider image ${slotIndex + 1} uploaded successfully`,
        "success"
      );
    } else {
      showNotification(
        result.message || "Failed to upload image",
        "error"
      );
    }
  } catch (error) {
    console.error("Upload error:", error);
    showNotification("An error occurred while uploading", "error");
  } finally {
    hideUploadProgress();
  }
}

function removeSliderImage(slotIndex) {
  if (!confirm("Are you sure you want to remove this image?")) return;

  sliderImages[slotIndex] = "";

  // Reset slot to placeholder
  const slot = document.querySelector(
    `.slider-image-slot[data-slot="${slotIndex}"]`
  );
  if (slot) {
    slot.innerHTML = `
            <div class="h-24 flex flex-col items-center justify-center">
                <i class="fas fa-image text-2xl text-slate-400 mb-1"></i>
                <p class="text-xs text-slate-500">Image ${
                  slotIndex + 1
                }</p>
            </div>
            <input type="file" id="sliderImage${slotIndex}" accept="image/*" class="hidden" onchange="handleSliderImageUpload(this, ${slotIndex})" />
            <button type="button" onclick="document.getElementById('sliderImage${slotIndex}').click()" 
                    class="mt-2 py-1 px-2 bg-slate-200 hover:bg-slate-300 text-slate-700 rounded text-xs">
                <i class="fas fa-upload mr-1"></i> Upload
            </button>
        `;
  }
}

// Video Upload
async function handleVideoUpload(input) {
  if (!input.files || !input.files[0]) return;

  const file = input.files[0];
  const formData = new FormData();
  formData.append("file", file);
  formData.append("folder", "hero-video");

  try {
    showUploadProgress("Uploading video... This may take a while.");

    const response = await fetch("/Content/UploadVideo", {
      method: "POST",
      body: formData,
    });

    const result = await response.json();

    if (result.success) {
      document.getElementById("videoUrl").value = result.url;

      // Show preview
      const preview = document.getElementById("videoPreview");
      preview.src = result.url;
      preview.classList.remove("hidden");

      const placeholder = document.getElementById("videoPlaceholder");
      if (placeholder) {
        placeholder.style.display = "none";
      }

      showNotification("Video uploaded successfully", "success");
    } else {
      showNotification(
        result.message || "Failed to upload video",
        "error"
      );
    }
  } catch (error) {
    console.error("Upload error:", error);
    showNotification("An error occurred while uploading", "error");
  } finally {
    hideUploadProgress();
  }
}

function removeVideo() {
  if (!confirm("Are you sure you want to remove this video?")) return;

  document.getElementById("videoUrl").value = "";
  document.getElementById("videoPreview").classList.add("hidden");

  const placeholder = document.getElementById("videoPlaceholder");
  if (placeholder) {
    placeholder.style.display = "block";
  }
}

// Save Section Item
async function saveSectionItem() {
  try {
    // Gather form data
    const itemId =
      parseInt(document.getElementById("itemId").value) || 0;
    const sectionId = parseInt(
      document.getElementById("sectionId").value
    );
    const type = parseInt(document.getElementById("itemType").value);
    const status = parseInt(
      document.getElementById("itemStatus").value
    );
    const sortOrder =
      parseInt(document.getElementById("itemSortOrder").value) || 0;

    // Get media data - only if item type needs media
    const mediaTypes = [2, 6, 9, 10]; // Image, Gallery, Picture, Video
    let pictureUrl = "";
    let videoUrl = "";
    let mediaAttributes = {};

    if (mediaTypes.includes(type)) {
      switch (currentMediaType) {
        case "Image":
          pictureUrl =
            document.getElementById("pictureUrl")?.value || "";
          break;
        case "ImageSlider":
          mediaAttributes.sliderImages = sliderImages.filter(
            (img) => img !== ""
          );
          pictureUrl = mediaAttributes.sliderImages[0] || ""; // Use first image as thumbnail
          break;
        case "Video":
          videoUrl = document.getElementById("videoUrl")?.value || "";
          break;
      }
    }

    // Gather translations
    const translations = [];
    document.querySelectorAll(".translation-item").forEach((item) => {
      const languageId = parseInt(item.dataset.languageId);
      const title =
        item.querySelector(".translation-title")?.value || "";
      const description =
        item.querySelector(".translation-description")?.value || "";
      const buttonText =
        item.querySelector(".translation-button-text")?.value || "";
      const buttonUrl =
        item.querySelector(".translation-button-url")?.value || "";

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

    // Prepare request - Use PascalCase for C# model binding
    const request = {
      Id: itemId,
      SectionId: sectionId,
      Type: type,
      MediaType: getMediaTypeValue(currentMediaType),
      PictureUrl: pictureUrl,
      VideoUrl: videoUrl,
      RedirectUrl: "",
      Icon: "",
      SortOrder: sortOrder,
      MediaAttributes: JSON.stringify(mediaAttributes),
      Status: status,
      Translations: translations,
    };

    // Submit
    console.log("=== REQUEST TO SEND ===");
    console.log("Request object:", request);
    console.log("JSON string:", JSON.stringify(request, null, 2));
    console.log("======================");

    const response = await fetch("/Content/SaveSectionItem", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Accept: "application/json",
      },
      body: JSON.stringify(request),
    });

    const result = await response.json();
    console.log("Response:", result); // Debug log

    if (result.success) {
      showNotification(result.message, "success");
      closeSectionItemModal();

      // Refresh page to show updated section items
      setTimeout(() => {
        location.reload();
      }, 1000);
    } else {
      showNotification(
        result.message || "Failed to save section item",
        "error"
      );
      if (result.error) {
        console.error("Server error:", result.error);
      }
    }
  } catch (error) {
    console.error("Save error:", error);
    showNotification("An error occurred while saving", "error");
  }
}

function getMediaTypeValue(mediaTypeString) {
  const mediaTypes = {
    None: 0,
    Image: 1,
    Video: 2,
    ImageSlider: 3,
    Audio: 4,
    Document: 5,
  };
  return mediaTypes[mediaTypeString] || 0;
}

// UI Helper Functions
function showUploadProgress(message) {
  // Create or show progress overlay
  let progressDiv = document.getElementById("uploadProgressOverlay");
  if (!progressDiv) {
    progressDiv = document.createElement("div");
    progressDiv.id = "uploadProgressOverlay";
    progressDiv.className =
      "fixed inset-0 bg-black bg-opacity-75 flex items-center justify-center z-50";
    progressDiv.innerHTML = `
            <div class="bg-white rounded-lg p-6 text-center">
                <div class="animate-spin rounded-full h-12 w-12 border-b-2 border-purple-600 mx-auto mb-4"></div>
                <p class="text-slate-700 font-medium" id="uploadProgressMessage"></p>
            </div>
        `;
    document.body.appendChild(progressDiv);
  }

  document.getElementById("uploadProgressMessage").textContent =
    message;
  progressDiv.style.display = "flex";
}

function hideUploadProgress() {
  const progressDiv = document.getElementById(
    "uploadProgressOverlay"
  );
  if (progressDiv) {
    progressDiv.style.display = "none";
  }
}

function showNotification(message, type = "info") {
  // Use existing PageEditor notification system
  const pageEditor = new PageEditor();
  pageEditor.showNotification(message, type);
}

// Modal Scroll Fix - Monitor modal creation and ensure scrolling
document.addEventListener("DOMContentLoaded", function () {
  const observer = new MutationObserver(function (mutations) {
    mutations.forEach(function (mutation) {
      if (mutation.addedNodes.length) {
        mutation.addedNodes.forEach(function (node) {
          if (node.id === "sectionItemModalOverlay") {
            const modal = node.querySelector(".section-item-modal");
            if (modal) {
              modal.style.maxHeight = "90vh";
              modal.style.overflowY = "auto";
              modal.style.overflowX = "hidden";
            }
          }
        });
      }
    });
  });

  observer.observe(document.body, {
    childList: true,
    subtree: false,
  });
});
