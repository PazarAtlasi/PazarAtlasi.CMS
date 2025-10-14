// Page Edit JavaScript Functions
class PageEditor {
  constructor() {
    this.initializeEventListeners();
    this.initializeSortable();
  }

  initializeEventListeners() {
    // Save Draft button
    document.addEventListener("click", (e) => {
      if (e.target.matches('[data-action="save-draft"]')) {
        this.saveDraft();
      }
    });

    // Publish button
    document.addEventListener("click", (e) => {
      if (e.target.matches('[data-action="publish"]')) {
        this.publishPage();
      }
    });

    // Preview button
    document.addEventListener("click", (e) => {
      if (e.target.matches('[data-action="preview"]')) {
        this.previewPage();
      }
    });

    // Form validation
    const form = document.getElementById("pageEditForm");
    if (form) {
      form.addEventListener("submit", (e) => {
        if (!this.validateForm()) {
          e.preventDefault();
        }
      });
    }
  }

  initializeSortable() {
    const sectionsContainer = document.getElementById(
      "sectionsContainer"
    );
    if (sectionsContainer && typeof Sortable !== "undefined") {
      new Sortable(sectionsContainer, {
        handle: ".drag-handle",
        animation: 150,
        onEnd: (evt) => {
          this.updateSectionOrder();
        },
      });
    }
  }

  async saveDraft() {
    const pageId = document.querySelector('input[name="Id"]').value;
    const formData = this.getFormData();

    try {
      const response = await fetch(`/Content/SaveDraft/${pageId}`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          RequestVerificationToken: document.querySelector(
            'input[name="__RequestVerificationToken"]'
          ).value,
        },
        body: JSON.stringify(formData),
      });

      const result = await response.json();
      this.showNotification(
        result.message,
        result.success ? "success" : "error"
      );
    } catch (error) {
      this.showNotification(
        "An error occurred while saving draft.",
        "error"
      );
    }
  }

  async publishPage() {
    const pageId = document.querySelector('input[name="Id"]').value;

    if (!confirm("Are you sure you want to publish this page?")) {
      return;
    }

    try {
      const response = await fetch(`/Content/PublishPage/${pageId}`, {
        method: "POST",
        headers: {
          RequestVerificationToken: document.querySelector(
            'input[name="__RequestVerificationToken"]'
          ).value,
        },
      });

      const result = await response.json();
      this.showNotification(
        result.message,
        result.success ? "success" : "error"
      );

      if (result.success) {
        // Update status badge
        this.updateStatusBadge("Active");
      }
    } catch (error) {
      this.showNotification(
        "An error occurred while publishing page.",
        "error"
      );
    }
  }

  previewPage() {
    const pageId = document.querySelector('input[name="Id"]').value;
    window.open(`/Preview/Page/${pageId}`, "_blank");
  }

  validateForm() {
    let isValid = true;
    const requiredFields = document.querySelectorAll("[required]");

    requiredFields.forEach((field) => {
      if (!field.value.trim()) {
        this.showFieldError(field, "This field is required.");
        isValid = false;
      } else {
        this.clearFieldError(field);
      }
    });

    return isValid;
  }

  getFormData() {
    const form = document.getElementById("pageEditForm");
    const formData = new FormData(form);
    const data = {};

    for (let [key, value] of formData.entries()) {
      data[key] = value;
    }

    return data;
  }

  updateSectionOrder() {
    const sections = document.querySelectorAll(".section-editor");
    sections.forEach((section, index) => {
      const orderInput = section.querySelector(
        'input[name*="SortOrder"]'
      );
      if (orderInput) {
        orderInput.value = index + 1;
      }
    });
  }

  showNotification(message, type = "info") {
    // Create notification element
    const notification = document.createElement("div");
    notification.className = `fixed top-4 right-4 p-4 rounded-lg shadow-lg z-50 ${this.getNotificationClasses(
      type
    )}`;
    notification.innerHTML = `
            <div class="flex items-center">
                <span class="mr-2">${this.getNotificationIcon(
                  type
                )}</span>
                <span>${message}</span>
                <button class="ml-4 text-white hover:text-gray-200" onclick="this.parentElement.parentElement.remove()">
                    <i class="fas fa-times"></i>
                </button>
            </div>
        `;

    document.body.appendChild(notification);

    // Auto remove after 5 seconds
    setTimeout(() => {
      if (notification.parentElement) {
        notification.remove();
      }
    }, 5000);
  }

  getNotificationClasses(type) {
    const classes = {
      success: "bg-green-500 text-white",
      error: "bg-red-500 text-white",
      warning: "bg-yellow-500 text-white",
      info: "bg-blue-500 text-white",
    };
    return classes[type] || classes.info;
  }

  getNotificationIcon(type) {
    const icons = {
      success: '<i class="fas fa-check-circle"></i>',
      error: '<i class="fas fa-exclamation-circle"></i>',
      warning: '<i class="fas fa-exclamation-triangle"></i>',
      info: '<i class="fas fa-info-circle"></i>',
    };
    return icons[type] || icons.info;
  }

  showFieldError(field, message) {
    this.clearFieldError(field);

    field.classList.add("border-red-500");
    const errorDiv = document.createElement("div");
    errorDiv.className = "text-red-500 text-sm mt-1 field-error";
    errorDiv.textContent = message;
    field.parentElement.appendChild(errorDiv);
  }

  clearFieldError(field) {
    field.classList.remove("border-red-500");
    const errorDiv =
      field.parentElement.querySelector(".field-error");
    if (errorDiv) {
      errorDiv.remove();
    }
  }

  updateStatusBadge(status) {
    const badge = document.querySelector(".status-badge");
    if (badge) {
      badge.textContent = status;
      badge.className = `ml-4 inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium status-badge ${this.getStatusClasses(
        status
      )}`;
    }
  }

  getStatusClasses(status) {
    const classes = {
      Active: "bg-green-100 text-green-800",
      Pending: "bg-blue-100 text-blue-800",
      Draft: "bg-yellow-100 text-yellow-800",
      Archived: "bg-gray-100 text-gray-800",
    };
    return classes[status] || "bg-red-100 text-red-800";
  }
}

// Section Management Functions
function toggleSEOPanel() {
  const panel = document.getElementById("seoPanel");
  if (panel) {
    panel.style.display =
      panel.style.display === "none" ? "block" : "none";
  }
}

function toggleTranslationsPanel() {
  const panel = document.getElementById("translationsPanel");
  if (panel) {
    panel.style.display =
      panel.style.display === "none" ? "block" : "none";
  }
}

function toggleSectionSettings(sectionId) {
  const settings = document.getElementById(
    `sectionSettings_${sectionId}`
  );
  if (settings) {
    settings.style.display =
      settings.style.display === "none" ? "block" : "none";
  }
}

function addNewSection() {
  // Get the page ID
  const pageId = document.querySelector('input[name="Id"]').value;

  // Load the new section modal
  fetch(`/Content/GetSectionModal?id=0&pageId=${pageId}`)
    .then((response) => response.text())
    .then((html) => {
      showSectionModal(html);
    })
    .catch((error) => {
      console.error("Error loading section modal:", error);
      alert("Error loading section modal. Please try again.");
    });
}

function createSectionModal() {
  const modal = document.createElement("div");
  modal.className =
    "fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50";
  modal.innerHTML = `
        <div class="bg-white rounded-lg p-6 w-full max-w-md mx-4">
            <div class="flex items-center justify-between mb-4">
                <h3 class="text-lg font-semibold text-slate-800">Add Page Section</h3>
                <button type="button" onclick="closeSectionModal()" class="text-slate-400 hover:text-slate-600">
                    <i class="fas fa-times"></i>
                </button>
            </div>
            
            <form id="addSectionForm" class="space-y-4">
                <div>
                    <label class="block text-sm font-medium text-slate-700 mb-1">Section Type</label>
                    <select id="sectionType" name="sectionType" 
                            class="w-full px-3 py-2 border border-slate-300 rounded-lg text-sm focus:outline-none focus:ring-2 focus:ring-purple-200 focus:border-purple-400">
                        <option value="Content">Content</option>
                        <option value="Hero">Hero</option>
                        <option value="Gallery">Gallery</option>
                        <option value="Testimonial">Testimonial</option>
                        <option value="Contact">Contact</option>
                    </select>
                </div>
                
                <div>
                    <label class="block text-sm font-medium text-slate-700 mb-1">Template Type</label>
                    <select id="SectionTemplateType" name="SectionTemplateType" 
                            class="w-full px-3 py-2 border border-slate-300 rounded-lg text-sm focus:outline-none focus:ring-2 focus:ring-purple-200 focus:border-purple-400">
                        <option value="Default">Default</option>
                        <option value="Carousel">Carousel</option>
                        <option value="Grid">Grid</option>
                        <option value="List">List</option>
                        <option value="SingleItem">Single Item</option>
                        <option value="Accordion">Accordion</option>
                        <option value="Tabs">Tabs</option>
                        <option value="MegaMenu">Mega Menu</option>
                    </select>
                </div>
                
                <div class="flex items-center justify-end space-x-3 pt-4">
                    <button type="button" onclick="closeSectionModal()" 
                            class="py-2 px-4 bg-slate-200 hover:bg-slate-300 text-slate-700 rounded-lg text-sm transition-colors">
                        Cancel
                    </button>
                    <button type="submit" 
                            class="py-2 px-4 bg-purple-600 hover:bg-purple-700 text-white rounded-lg text-sm transition-colors">
                        <i class="fas fa-plus mr-2"></i> Add Section
                    </button>
                </div>
            </form>
        </div>
    `;

  // Add form submit handler
  modal
    .querySelector("#addSectionForm")
    .addEventListener("submit", handleAddSection);

  return modal;
}

function closeSectionModal() {
  const modal = document.querySelector(".fixed.inset-0");
  if (modal) {
    modal.remove();
  }
}

async function handleAddSection(e) {
  e.preventDefault();

  const formData = new FormData(e.target);
  const pageId = document.querySelector('input[name="Id"]').value;

  const data = {
    pageId: parseInt(pageId),
    sectionType: formData.get("sectionType"),
    SectionTemplateType: formData.get("SectionTemplateType"),
  };

  try {
    const response = await fetch("/Content/AddSection", {
      method: "POST",
      headers: {
        "Content-Type": "application/x-www-form-urlencoded",
        RequestVerificationToken: document.querySelector(
          'input[name="__RequestVerificationToken"]'
        ).value,
      },
      body: new URLSearchParams(data),
    });

    const result = await response.json();

    if (result.success) {
      // Add new section to the page
      const sectionsContainer = document.getElementById(
        "sectionsContainer"
      );
      const emptyState = sectionsContainer.querySelector(
        ".text-center.py-12"
      );

      if (emptyState) {
        emptyState.remove();
      }

      // Create new section element
      const newSectionDiv = document.createElement("div");
      newSectionDiv.innerHTML = result.sectionHtml;
      sectionsContainer.appendChild(newSectionDiv.firstElementChild);

      // Close modal
      closeSectionModal();

      // Show success notification
      const pageEditor = new PageEditor();
      pageEditor.showNotification(result.message, "success");
    } else {
      const pageEditor = new PageEditor();
      pageEditor.showNotification(result.message, "error");
    }
  } catch (error) {
    const pageEditor = new PageEditor();
    pageEditor.showNotification(
      "An error occurred while adding section.",
      "error"
    );
  }
}

async function removeSection(sectionId) {
  if (
    !confirm(
      "Are you sure you want to remove this section? This action cannot be undone."
    )
  ) {
    return;
  }

  try {
    const response = await fetch("/Content/RemoveSection", {
      method: "POST",
      headers: {
        "Content-Type": "application/x-www-form-urlencoded",
        RequestVerificationToken: document.querySelector(
          'input[name="__RequestVerificationToken"]'
        ).value,
      },
      body: new URLSearchParams({ sectionId: sectionId }),
    });

    const result = await response.json();

    if (result.success) {
      // Remove section from DOM
      const section = document.querySelector(
        `[data-section-id="${sectionId}"]`
      );
      if (section) {
        section.remove();
      }

      // Check if no sections left, show empty state
      const sectionsContainer = document.getElementById(
        "sectionsContainer"
      );
      const remainingSections =
        sectionsContainer.querySelectorAll(".section-editor");

      if (remainingSections.length === 0) {
        sectionsContainer.innerHTML = `
                    <div class="text-center py-12 text-slate-500">
                        <i class="fas fa-layer-group text-4xl mb-4"></i>
                        <h6 class="text-lg font-medium mb-2">No sections yet</h6>
                        <p class="text-sm mb-4">Start building your page by adding sections</p>
                        <button type="button" class="py-2 px-4 bg-green-600 hover:bg-green-700 text-white rounded-lg text-sm transition-colors" onclick="addNewSection()">
                            <i class="fas fa-plus mr-2"></i> Add Your First Section
                        </button>
                    </div>
                `;
      }

      // Show success notification
      const pageEditor = new PageEditor();
      pageEditor.showNotification(result.message, "success");
    } else {
      const pageEditor = new PageEditor();
      pageEditor.showNotification(result.message, "error");
    }
  } catch (error) {
    const pageEditor = new PageEditor();
    pageEditor.showNotification(
      "An error occurred while removing section.",
      "error"
    );
  }
}

function addCarouselItem(sectionId) {
  console.log(`Add carousel item to section ${sectionId}`);
}

function addSingleItem(sectionId) {
  console.log(`Add single item to section ${sectionId}`);
}

function removeItem(itemId) {
  if (confirm("Are you sure you want to remove this item?")) {
    const item = document.querySelector(`[data-item-id="${itemId}"]`);
    if (item) {
      item.remove();
    }
  }
}

function updateSectionTemplate(sectionId, SectionTemplateType) {
  console.log(
    `Update section ${sectionId} template to ${SectionTemplateType}`
  );
}

function uploadSlideMedia(itemId, mediaType) {
  console.log(`Upload ${mediaType} for item ${itemId}`);
  // Implementation for media upload
}

function selectHeroType(itemId, heroType) {
  console.log(`Select hero type ${heroType} for item ${itemId}`);
  // Implementation for hero type selection
}

function uploadHeroVideo(itemId) {
  console.log(`Upload hero video for item ${itemId}`);
  // Implementation for video upload
}

function uploadHeroImage(itemId) {
  console.log(`Upload hero image for item ${itemId}`);
  // Implementation for image upload
}

function removeHeroMedia(itemId) {
  if (confirm("Are you sure you want to remove this media?")) {
    console.log(`Remove hero media for item ${itemId}`);
    // Implementation for media removal
  }
}

function uploadSliderImage(itemId, slotNumber) {
  console.log(`Upload slider image ${slotNumber} for item ${itemId}`);
  // Implementation for slider image upload
}

// Initialize when DOM is loaded
document.addEventListener("DOMContentLoaded", () => {
  new PageEditor();
});
// Additional helper functions
function duplicatePage() {
  if (confirm("Are you sure you want to duplicate this page?")) {
    const pageId = document.querySelector('input[name="Id"]').value;
    window.location.href = `/Content/DuplicatePage/${pageId}`;
  }
}

function deletePage() {
  if (
    confirm(
      "Are you sure you want to delete this page? This action cannot be undone."
    )
  ) {
    const pageId = document.querySelector('input[name="Id"]').value;
    fetch(`/Content/DeletePage/${pageId}`, {
      method: "DELETE",
      headers: {
        RequestVerificationToken: document.querySelector(
          'input[name="__RequestVerificationToken"]'
        ).value,
      },
    })
      .then((response) => response.json())
      .then((result) => {
        if (result.success) {
          window.location.href = "/Content/Pages";
        } else {
          alert(result.message);
        }
      })
      .catch((error) => {
        alert("An error occurred while deleting the page.");
      });
  }
}

function duplicateSection(sectionId) {
  console.log(`Duplicate section ${sectionId}`);
  // Implementation for duplicating section
}

function editSectionItems(sectionId) {
  console.log(`Edit section items for ${sectionId}`);
  // Implementation for editing section items
}

async function addSectionItem(sectionId) {
  try {
    const response = await fetch(
      `/Content/GetSectionItemModal?id=0&sectionId=${sectionId}`
    );

    if (response.ok) {
      const html = await response.text();
      showSectionItemModal(html);
    } else {
      alert("Failed to load section item form");
    }
  } catch (error) {
    console.error("Error loading section item form:", error);
    alert("An error occurred while loading the form");
  }
}

async function editSectionItem(itemId) {
  try {
    const response = await fetch(
      `/Content/GetSectionItemModal?id=${itemId}&sectionId=0`
    );

    if (response.ok) {
      const html = await response.text();
      showSectionItemModal(html);
    } else {
      alert("Failed to load section item form");
    }
  } catch (error) {
    console.error("Error loading section item form:", error);
    alert("An error occurred while loading the form");
  }
}

// SEO Preview Updates
document.addEventListener("DOMContentLoaded", function () {
  // Update SEO preview when fields change
  const metaTitleInput = document.querySelector(
    'input[name="SEOParameter.MetaTitle"]'
  );
  const metaDescInput = document.querySelector(
    'textarea[name="SEOParameter.MetaDescription"]'
  );
  const canonicalInput = document.querySelector(
    'input[name="SEOParameter.CanonicalURL"]'
  );

  if (metaTitleInput) {
    metaTitleInput.addEventListener("input", function () {
      const preview = document.getElementById("seo-title-preview");
      if (preview) {
        preview.textContent =
          this.value ||
          document.querySelector('input[name="Name"]').value ||
          "Page Title";
      }
    });
  }

  if (metaDescInput) {
    metaDescInput.addEventListener("input", function () {
      const preview = document.getElementById(
        "seo-description-preview"
      );
      if (preview) {
        preview.textContent =
          this.value ||
          document.querySelector('textarea[name="Description"]')
            .value ||
          "Page description will appear here...";
      }
    });
  }

  if (canonicalInput) {
    canonicalInput.addEventListener("input", function () {
      const preview = document.getElementById("seo-url-preview");
      if (preview) {
        preview.textContent =
          this.value ||
          `https://example.com/${
            document.querySelector('input[name="Code"]').value
          }`;
      }
    });
  }
});

// Auto-save functionality
let autoSaveTimer;
function enableAutoSave() {
  const form = document.getElementById("pageEditForm");
  if (form) {
    form.addEventListener("input", function () {
      clearTimeout(autoSaveTimer);
      autoSaveTimer = setTimeout(() => {
        const pageEditor = new PageEditor();
        pageEditor.saveDraft();
      }, 30000); // Auto-save after 30 seconds of inactivity
    });
  }
}

// Initialize auto-save
document.addEventListener("DOMContentLoaded", function () {
  enableAutoSave();

  // Initialize page type change handler
  const pageTypeSelect = document.getElementById("pageTypeSelect");
  if (pageTypeSelect) {
    // Show content selection if page type is already selected and not None
    if (pageTypeSelect.value && pageTypeSelect.value !== "0") {
      handlePageTypeChange(pageTypeSelect.value);
    }
  }
});

// Handle page type changes
async function handlePageTypeChange(pageType) {
  const dynamicContentDiv = document.getElementById(
    "dynamicContentSelection"
  );
  const linkedContentSelect = document.getElementById(
    "linkedContentSelect"
  );

  if (!dynamicContentDiv || !linkedContentSelect) return;

  // Hide content selection for None type
  if (!pageType || pageType === "0") {
    dynamicContentDiv.classList.add("hidden");
    return;
  }

  // Show content selection for specific types
  const contentTypes = ["3", "4", "5", "6", "7", "8", "9"]; // Article, Product, Catalog, Category, Brand, Tag, Blog

  if (contentTypes.includes(pageType)) {
    dynamicContentDiv.classList.remove("hidden");
    await loadContentByType(pageType);
  } else {
    dynamicContentDiv.classList.add("hidden");
  }
}

// Load content based on page type
async function loadContentByType(pageType) {
  const linkedContentSelect = document.getElementById(
    "linkedContentSelect"
  );
  if (!linkedContentSelect) return;

  try {
    // Clear existing options except the first one
    while (linkedContentSelect.children.length > 1) {
      linkedContentSelect.removeChild(linkedContentSelect.lastChild);
    }

    // Show loading state
    const loadingOption = document.createElement("option");
    loadingOption.value = "";
    loadingOption.textContent = "Loading...";
    linkedContentSelect.appendChild(loadingOption);

    const response = await fetch(
      `/Content/GetContentByType?pageType=${pageType}`
    );
    const result = await response.json();

    // Remove loading option
    linkedContentSelect.removeChild(loadingOption);

    if (
      result.success &&
      result.content &&
      result.content.length > 0
    ) {
      result.content.forEach((item) => {
        const option = document.createElement("option");
        option.value = item.id;
        option.textContent = item.name || item.title;
        linkedContentSelect.appendChild(option);
      });
    } else {
      const noContentOption = document.createElement("option");
      noContentOption.value = "";
      noContentOption.textContent = `No ${getPageTypeName(
        pageType
      ).toLowerCase()} content available`;
      linkedContentSelect.appendChild(noContentOption);
    }
  } catch (error) {
    console.error("Error loading content:", error);

    // Remove loading option and show error
    while (linkedContentSelect.children.length > 1) {
      linkedContentSelect.removeChild(linkedContentSelect.lastChild);
    }

    const errorOption = document.createElement("option");
    errorOption.value = "";
    errorOption.textContent = "Error loading content";
    linkedContentSelect.appendChild(errorOption);
  }
}

// Get page type name for display
function getPageTypeName(pageType) {
  const pageTypeNames = {
    1: "Home",
    2: "Article",
    3: "Product",
    4: "Catalog",
    5: "Category",
    6: "Brand",
    7: "Tag",
    8: "Blog",
    9: "Document",
    10: "UserProfile",
  };
  return pageTypeNames[pageType] || "Content";
}

// Make function globally available
window.handlePageTypeChange = handlePageTypeChange;
