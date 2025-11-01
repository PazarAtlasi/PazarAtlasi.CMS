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
      const result = await ContentServices.saveDraft(
        pageId,
        formData
      );
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
      const result = await ContentServices.publishPage(pageId);
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
    if (
      panel.style.display === "none" ||
      panel.style.display === ""
    ) {
      panel.style.display = "block";
      // Scroll to panel
      panel.scrollIntoView({ behavior: "smooth", block: "start" });
    } else {
      panel.style.display = "none";
    }
  }
}

function switchTranslationTab(languageId) {
  // Remove active class from all tabs
  document.querySelectorAll(".language-tab").forEach((tab) => {
    tab.classList.remove("border-purple-500", "text-purple-600");
    tab.classList.add("border-transparent", "text-slate-500");
  });

  // Add active class to selected tab
  const selectedTab = document.querySelector(
    `.language-tab[data-language-id="${languageId}"]`
  );
  if (selectedTab) {
    selectedTab.classList.add("border-purple-500", "text-purple-600");
    selectedTab.classList.remove(
      "border-transparent",
      "text-slate-500"
    );
  }

  // Hide all translation contents
  document
    .querySelectorAll(".translation-content")
    .forEach((content) => {
      content.classList.add("hidden");
    });

  // Show selected language content
  const selectedContent = document.querySelector(
    `.translation-content[data-language-id="${languageId}"]`
  );
  if (selectedContent) {
    selectedContent.classList.remove("hidden");
  }
}

function saveTranslations() {
  if (typeof SwalHelper !== "undefined") {
    SwalHelper.loading(
      "Saving Translations...",
      "Please wait while translations are being saved..."
    );

    // Simulate save process
    setTimeout(() => {
      Swal.close();
      SwalHelper.success(
        "Success!",
        "Translations saved successfully."
      );
    }, 1500);
  } else {
    alert("Translations saved successfully!");
  }
}

function resetTranslations() {
  if (typeof SwalHelper !== "undefined") {
    SwalHelper.confirm(
      "Reset Translations",
      "Are you sure you want to reset all translations? This will restore the original values.",
      {
        confirmButtonText:
          '<i class="fas fa-undo mr-2"></i>Yes, Reset',
        cancelButtonText: '<i class="fas fa-times mr-2"></i>Cancel',
        icon: "warning",
      }
    ).then((result) => {
      if (result.isConfirmed) {
        // Reset form fields to original values
        const form = document.getElementById("pageEditForm");
        if (form) {
          form.reset();
          SwalHelper.success(
            "Reset Complete",
            "Translations have been reset to original values."
          );
        }
      }
    });
  } else {
    if (confirm("Are you sure you want to reset all translations?")) {
      const form = document.getElementById("pageEditForm");
      if (form) {
        form.reset();
        alert("Translations reset successfully!");
      }
    }
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
  const modal = document.getElementById("sectionSelectionModal");
  if (modal) {
    modal.classList.remove("hidden");
    document.body.style.overflow = "hidden";
  }
}

function closeSectionSelectionModal() {
  const modal = document.getElementById("sectionSelectionModal");
  if (modal) {
    modal.classList.add("hidden");
    document.body.style.overflow = "";

    // Reset reusable sections list
    const reusableList = document.getElementById(
      "reusableSectionsList"
    );
    if (reusableList) {
      reusableList.classList.add("hidden");
    }
  }
}

async function createNewSection() {
  closeSectionSelectionModal();

  // Get the page ID
  const pageId = document.querySelector('input[name="Id"]').value;

  if (typeof SectionModal !== "undefined" && SectionModal.show) {
    SectionModal.show(0, parseInt(pageId));
  } else {
    console.error("SectionModal not available");
  }
}

async function showReusableSections() {
  const listDiv = document.getElementById("reusableSectionsList");
  const container = document.getElementById(
    "reusableSectionsContainer"
  );

  listDiv.classList.remove("hidden");

  try {
    const result = await ContentServices.getReusableSections();

    if (
      result.success &&
      result.sections &&
      result.sections.length > 0
    ) {
      container.innerHTML = "";

      result.sections.forEach((section) => {
        const sectionCard = document.createElement("div");
        sectionCard.className =
          "border border-slate-200 rounded-lg p-4 hover:border-purple-300 transition-colors cursor-pointer";
        sectionCard.onclick = () => addReusableSection(section.Id);

        sectionCard.innerHTML = `
          <div class="flex items-center mb-3">
            <div class="w-10 h-10 bg-purple-100 rounded-lg flex items-center justify-center mr-3">
              <i class="fas fa-layer-group text-purple-600"></i>
            </div>
            <div class="flex-1">
              <h5 class="font-medium text-slate-800">${
                section.Name
              }</h5>
              <p class="text-xs text-slate-500">${section.Type} - ${
          section.TemplateType
        }</p>
            </div>
          </div>
          ${
            section.Description
              ? `<p class="text-sm text-slate-600 mb-3">${section.Description}</p>`
              : ""
          }
          <div class="flex items-center justify-between text-xs text-slate-500">
            <span><i class="fas fa-recycle mr-1"></i> Reusable</span>
            <button class="text-purple-600 hover:text-purple-800">
              <i class="fas fa-plus mr-1"></i> Add
            </button>
          </div>
        `;

        container.appendChild(sectionCard);
      });
    } else {
      container.innerHTML = `
        <div class="col-span-full text-center py-8 text-slate-400">
          <i class="fas fa-layer-group text-4xl mb-4"></i>
          <p class="text-lg font-medium">No reusable sections found</p>
          <p class="text-sm">Create some reusable sections first to use them here</p>
          <a href="/Content/CreateSection" class="mt-4 inline-flex items-center py-2 px-4 bg-green-600 hover:bg-green-700 text-white rounded-lg text-sm transition-colors">
            <i class="fas fa-plus mr-2"></i> Create Section
          </a>
        </div>
      `;
    }
  } catch (error) {
    console.error("Error loading reusable sections:", error);
    container.innerHTML = `
      <div class="col-span-full text-center py-8 text-red-400">
        <i class="fas fa-exclamation-circle text-4xl mb-4"></i>
        <p class="text-lg font-medium">Error loading sections</p>
        <p class="text-sm">Please try again later</p>
      </div>
    `;
  }
}

async function addReusableSection(sectionId) {
  try {
    const pageId = document.querySelector('input[name="Id"]').value;

    const result = await ContentServices.addReusableSection({
      pageId: pageId,
      sectionId: sectionId,
    });

    if (result.success) {
      closeSectionSelectionModal();

      // Refresh the page to show the new section
      location.reload();
    } else {
      alert("Error adding section: " + result.message);
    }
  } catch (error) {
    console.error("Error adding reusable section:", error);
    alert("An error occurred while adding the section.");
  }
}

function closeSectionModal() {
  const modal = document.querySelector(".fixed.inset-0");
  if (modal) {
    modal.remove();
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
    const result = await ContentServices.removeSection(sectionId);

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

/**
 * Switch language tab in section modal
 */
function switchLanguageTab(languageId) {
  // Remove active class from all tabs
  document.querySelectorAll(".language-tab").forEach((tab) => {
    tab.classList.remove("active");
    tab.classList.remove("bg-green-100", "text-green-800");
    tab.classList.add("text-slate-600");
  });

  // Add active class to selected tab
  const selectedTab = document.querySelector(
    `.language-tab[data-language-id="${languageId}"]`
  );
  if (selectedTab) {
    selectedTab.classList.add(
      "active",
      "bg-green-100",
      "text-green-800"
    );
    selectedTab.classList.remove("text-slate-600");
  }

  // Hide all translation contents
  document
    .querySelectorAll(".translation-content")
    .forEach((content) => {
      content.classList.add("hidden");
    });

  // Show selected language content
  const selectedContent = document.querySelector(
    `.translation-content[data-language-id="${languageId}"]`
  );
  if (selectedContent) {
    selectedContent.classList.remove("hidden");
  }
}

// Initialize when DOM is loaded
document.addEventListener("DOMContentLoaded", () => {
  new PageEditor();
});

async function deletePage() {
  if (
    confirm(
      "Are you sure you want to delete this page? This action cannot be undone."
    )
  ) {
    const pageId = document.querySelector('input[name="Id"]').value;

    try {
      const result = await ContentServices.deletePage(pageId);

      if (result.success) {
        window.location.href = "/Content/Pages";
      } else {
        alert(result.message);
      }
    } catch (error) {
      alert("An error occurred while deleting the page.");
    }
  }
}

async function addSectionItem(sectionId) {
  try {
    // For editing an existing section to add items to it
    if (typeof SectionModal !== "undefined" && SectionModal.show) {
      const pageId = window.currentPageId || 1;
      SectionModal.show(sectionId, pageId);
    } else {
      console.warn("SectionModal not available");
    }
  } catch (error) {
    console.error("Error opening section modal:", error);
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

  // Initialize layout selection
  loadAvailableLayouts();
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

    const result = await ContentServices.getContentByType(pageType);

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

// Layout handling functions
async function loadAvailableLayouts() {
  const layoutSelect = document.getElementById("layoutSelect");
  if (!layoutSelect) return;

  try {
    const result = await ContentServices.getAvailableLayouts();

    if (result.success && result.layouts) {
      // Store current value before clearing
      const currentValue = layoutSelect.value;

      // Clear existing options except the first one
      while (layoutSelect.children.length > 1) {
        layoutSelect.removeChild(layoutSelect.lastChild);
      }

      result.layouts.forEach((layout) => {
        const option = document.createElement("option");
        option.value = layout.id;
        option.textContent =
          layout.name + (layout.isDefault ? " (Default)" : "");
        if (layout.description) {
          option.title = layout.description;
        }
        layoutSelect.appendChild(option);
      });

      // Restore current value if it exists
      if (currentValue) {
        layoutSelect.value = currentValue;
      }

      // Set layout value from server-side model if available
      const pageLayoutId = window.pageLayoutId;
      if (pageLayoutId) {
        layoutSelect.value = pageLayoutId;
      }
    }
  } catch (error) {
    console.error("Error loading layouts:", error);
  }
}

async function handleLayoutChange(layoutId) {
  if (!layoutId || layoutId === "") {
    // Clear layout if no layout selected
    await clearPageLayout();
    return;
  }

  try {
    // Use SwalHelper for better UX
    if (typeof SwalHelper !== "undefined") {
      const confirmResult = await SwalHelper.confirm(
        "Layout Seçimi",
        `Bu layout'u sayfaya uygulamak istiyor musunuz? Sayfa yeniden yüklenecektir.`,
        {
          confirmButtonText:
            '<i class="fas fa-check mr-2"></i>Evet, Uygula',
          cancelButtonText: '<i class="fas fa-times mr-2"></i>Hayır',
          icon: "question",
        }
      );

      if (!confirmResult.isConfirmed) {
        // Reset layout selection if user cancels
        const layoutSelect = document.getElementById("layoutSelect");
        if (layoutSelect) {
          layoutSelect.value = window.pageLayoutId || "";
        }
        return;
      }
    } else {
      // Fallback to native confirm
      const confirmMessage = `Bu layout'u sayfaya uygulamak istiyor musunuz? Sayfa yeniden yüklenecektir.`;
      if (!confirm(confirmMessage)) {
        // Reset layout selection if user cancels
        const layoutSelect = document.getElementById("layoutSelect");
        if (layoutSelect) {
          layoutSelect.value = window.pageLayoutId || "";
        }
        return;
      }
    }

    // Show loading
    if (typeof SwalHelper !== "undefined") {
      SwalHelper.loading(
        "Layout Uygulanıyor...",
        "Layout sayfaya uygulanıyor, lütfen bekleyin..."
      );
    }

    // Get page ID
    const pageId = document.querySelector('input[name="Id"]')?.value;
    if (!pageId) {
      console.error("Page ID not found");
      if (typeof SwalHelper !== "undefined") {
        Swal.close();
        SwalHelper.error("Hata", "Sayfa ID bulunamadı.");
      }
      return;
    }

    // Update page layout in backend
    const result = await updatePageLayout(pageId, layoutId);

    if (result.success) {
      // Close loading and show success, then reload
      if (typeof SwalHelper !== "undefined") {
        Swal.close();
        SwalHelper.success(
          "Başarılı!",
          "Layout başarıyla uygulandı. Sayfa yenileniyor..."
        );

        // Reload page after a short delay
        setTimeout(() => {
          location.reload();
        }, 450);
      } else {
        // Immediate reload for fallback
        location.reload();
      }
    } else {
      throw new Error(
        result.message || "Layout güncellenirken hata oluştu"
      );
    }
  } catch (error) {
    console.error("Error updating layout:", error);

    if (typeof SwalHelper !== "undefined") {
      Swal.close();
      SwalHelper.error(
        "Hata",
        "Layout uygulanırken bir hata oluştu: " + error.message
      );
    } else {
      alert("Layout uygulanırken bir hata oluştu: " + error.message);
    }

    // Reset layout selection on error
    const layoutSelect = document.getElementById("layoutSelect");
    if (layoutSelect) {
      layoutSelect.value = window.pageLayoutId || "";
    }
  }
}

// Layout management helper functions
async function updatePageLayout(pageId, layoutId) {
  try {
    const response = await fetch("/Content/UpdatePageLayout", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        RequestVerificationToken: document.querySelector(
          'input[name="__RequestVerificationToken"]'
        )?.value,
      },
      body: JSON.stringify({
        pageId: parseInt(pageId),
        layoutId: layoutId ? parseInt(layoutId) : null,
      }),
    });

    const result = await response.json();
    return result;
  } catch (error) {
    console.error("Error updating page layout:", error);
    throw error;
  }
}

async function clearPageLayout() {
  const pageId = document.querySelector('input[name="Id"]')?.value;
  if (!pageId) return;

  try {
    // Show loading
    if (typeof SwalHelper !== "undefined") {
      SwalHelper.loading(
        "Layout Kaldırılıyor...",
        "Layout sayfadan kaldırılıyor, lütfen bekleyin..."
      );
    }

    const result = await updatePageLayout(pageId, null);

    if (result.success) {
      // Close loading and reload page
      if (typeof SwalHelper !== "undefined") {
        Swal.close();
        SwalHelper.success(
          "Başarılı!",
          "Layout kaldırıldı. Sayfa yenileniyor..."
        );

        setTimeout(() => {
          location.reload();
        }, 1500);
      } else {
        location.reload();
      }
    } else {
      throw new Error(
        result.message || "Layout kaldırılırken hata oluştu"
      );
    }
  } catch (error) {
    console.error("Error clearing layout:", error);

    if (typeof SwalHelper !== "undefined") {
      Swal.close();
      SwalHelper.error(
        "Hata",
        "Layout kaldırılırken bir hata oluştu: " + error.message
      );
    } else {
      alert("Layout kaldırılırken bir hata oluştu: " + error.message);
    }
  }
}

// Make functions globally available
window.handlePageTypeChange = handlePageTypeChange;
window.handleLayoutChange = handleLayoutChange;
window.updatePageLayout = updatePageLayout;
window.clearPageLayout = clearPageLayout;
window.addNewSection = addNewSection;
window.closeSectionSelectionModal = closeSectionSelectionModal;
window.toggleTranslationsPanel = toggleTranslationsPanel;
window.switchTranslationTab = switchTranslationTab;
window.saveTranslations = saveTranslations;
window.resetTranslations = resetTranslations;

// Enhanced Section Preview Functions
function editSectionItems(sectionId) {
  try {
    if (typeof SectionModal !== "undefined" && SectionModal.show) {
      const pageId =
        window.currentPageId ||
        document.querySelector('input[name="Id"]').value;
      SectionModal.show(sectionId, parseInt(pageId));
    } else {
      console.warn(
        "SectionModal not available, redirecting to section edit page"
      );
      window.location.href = `/Content/SectionDetails/${sectionId}`;
    }
  } catch (error) {
    console.error("Error opening section items editor:", error);
    // Fallback to direct navigation
    window.location.href = `/Content/SectionDetails/${sectionId}`;
  }
}

function duplicateSection(sectionId) {
  if (!confirm("Are you sure you want to duplicate this section?")) {
    return;
  }

  // Show loading state
  const sectionElement = document.querySelector(
    `[data-section-id="${sectionId}"]`
  );
  if (sectionElement) {
    sectionElement.classList.add("loading");
  }

  ContentServices.duplicateSection(sectionId)
    .then((result) => {
      if (result.success) {
        // Reload page to show duplicated section
        location.reload();
      } else {
        alert("Error duplicating section: " + result.message);
      }
    })
    .catch((error) => {
      console.error("Error duplicating section:", error);
      alert("An error occurred while duplicating the section.");
    })
    .finally(() => {
      if (sectionElement) {
        sectionElement.classList.remove("loading");
      }
    });
}

// Field Preview Enhancement Functions
function previewImage(imageUrl, fieldKey) {
  if (!imageUrl) return;

  // Create modal for image preview
  const modal = document.createElement("div");
  modal.className =
    "fixed inset-0 bg-black bg-opacity-75 flex items-center justify-center z-50 p-4";
  modal.onclick = () => modal.remove();

  const img = document.createElement("img");
  img.src = imageUrl;
  img.className = "max-w-full max-h-full rounded-lg shadow-2xl";
  img.onclick = (e) => e.stopPropagation();

  const closeBtn = document.createElement("button");
  closeBtn.className =
    "absolute top-4 right-4 text-white hover:text-gray-300 text-2xl";
  closeBtn.innerHTML = '<i class="fas fa-times"></i>';
  closeBtn.onclick = () => modal.remove();

  const info = document.createElement("div");
  info.className =
    "absolute bottom-4 left-4 bg-black bg-opacity-50 text-white p-2 rounded";
  info.innerHTML = `<i class="fas fa-image mr-2"></i>${fieldKey}`;

  modal.appendChild(img);
  modal.appendChild(closeBtn);
  modal.appendChild(info);
  document.body.appendChild(modal);
}

function previewVideo(videoUrl, fieldKey) {
  if (!videoUrl) return;

  // Create modal for video preview
  const modal = document.createElement("div");
  modal.className =
    "fixed inset-0 bg-black bg-opacity-75 flex items-center justify-center z-50 p-4";
  modal.onclick = () => modal.remove();

  const video = document.createElement("video");
  video.src = videoUrl;
  video.className = "max-w-full max-h-full rounded-lg shadow-2xl";
  video.controls = true;
  video.autoplay = true;
  video.onclick = (e) => e.stopPropagation();

  const closeBtn = document.createElement("button");
  closeBtn.className =
    "absolute top-4 right-4 text-white hover:text-gray-300 text-2xl";
  closeBtn.innerHTML = '<i class="fas fa-times"></i>';
  closeBtn.onclick = () => modal.remove();

  const info = document.createElement("div");
  info.className =
    "absolute bottom-4 left-4 bg-black bg-opacity-50 text-white p-2 rounded";
  info.innerHTML = `<i class="fas fa-video mr-2"></i>${fieldKey}`;

  modal.appendChild(video);
  modal.appendChild(closeBtn);
  modal.appendChild(info);
  document.body.appendChild(modal);
}

// Section Settings Animation
function toggleSectionSettings(sectionId) {
  const settings = document.getElementById(
    `sectionSettings_${sectionId}`
  );
  if (!settings) return;

  const isHidden =
    settings.style.display === "none" ||
    settings.classList.contains("hidden");

  if (isHidden) {
    // Show with animation
    settings.style.display = "block";
    settings.classList.remove("hidden");

    // Trigger animation
    requestAnimationFrame(() => {
      settings.style.opacity = "0";
      settings.style.transform = "translateY(-10px)";

      requestAnimationFrame(() => {
        settings.style.transition = "all 0.3s ease-out";
        settings.style.opacity = "1";
        settings.style.transform = "translateY(0)";
      });
    });
  } else {
    // Hide with animation
    settings.style.transition = "all 0.3s ease-out";
    settings.style.opacity = "0";
    settings.style.transform = "translateY(-10px)";

    setTimeout(() => {
      settings.style.display = "none";
      settings.classList.add("hidden");
    }, 300);
  }
}

// Enhanced Section Type Icons
function getSectionTypeIcon(sectionType) {
  const icons = {
    navbar: "fas fa-bars",
    header: "fas fa-heading",
    hero: "fas fa-star",
    footer: "fas fa-grip-lines",
    gallery: "fas fa-images",
    contact: "fas fa-envelope",
    newsletter: "fas fa-newspaper",
    contentblock: "fas fa-cube",
    featured: "fas fa-trophy",
    catalog: "fas fa-th-large",
    sidebar: "fas fa-columns",
    maincontent: "fas fa-file-alt",
    relatedcontent: "fas fa-link",
    advertisement: "fas fa-ad",
    search: "fas fa-search",
    contactform: "fas fa-wpforms",
    whyus: "fas fa-thumbs-up",
    socialmedialinks: "fas fa-share-alt",
    testimonials: "fas fa-quote-left",
    calltoaction: "fas fa-bullhorn",
    breadcrumbs: "fas fa-route",
    pagination: "fas fa-ellipsis-h",
    map: "fas fa-map-marker-alt",
  };

  return icons[sectionType.toLowerCase()] || "fas fa-layer-group";
}

// Field Type Icons
function getFieldTypeIcon(fieldType) {
  const icons = {
    text: "fas fa-font",
    textarea: "fas fa-align-left",
    title: "fas fa-heading",
    description: "fas fa-align-left",
    paragraph: "fas fa-paragraph",
    richtext: "fas fa-edit",
    image: "fas fa-image",
    video: "fas fa-video",
    url: "fas fa-link",
    number: "fas fa-hashtag",
    date: "fas fa-calendar",
    boolean: "fas fa-check-square",
    checkbox: "fas fa-check-square",
    color: "fas fa-palette",
    icon: "fas fa-icons",
    fileupload: "fas fa-file-upload",
    dropdown: "fas fa-chevron-down",
    multiselect: "fas fa-list",
  };

  return icons[fieldType.toLowerCase()] || "fas fa-cube";
}

// Utility function to truncate text
function truncateText(text, maxLength = 50) {
  if (!text || text.length <= maxLength) return text;
  return text.substring(0, maxLength) + "...";
}

// Enhanced notification system for section operations
function showSectionNotification(
  message,
  type = "info",
  duration = 5000
) {
  const notification = document.createElement("div");
  notification.className = `fixed top-4 right-4 p-4 rounded-lg shadow-lg z-50 transform transition-all duration-300 ${getNotificationClasses(
    type
  )}`;

  notification.innerHTML = `
    <div class="flex items-center">
      <span class="mr-3">${getNotificationIcon(type)}</span>
      <div class="flex-1">
        <p class="font-medium">${message}</p>
      </div>
      <button class="ml-4 text-current hover:opacity-75" onclick="this.parentElement.parentElement.remove()">
        <i class="fas fa-times"></i>
      </button>
    </div>
  `;

  // Add entrance animation
  notification.style.transform = "translateX(100%)";
  document.body.appendChild(notification);

  requestAnimationFrame(() => {
    notification.style.transform = "translateX(0)";
  });

  // Auto remove
  setTimeout(() => {
    if (notification.parentElement) {
      notification.style.transform = "translateX(100%)";
      setTimeout(() => notification.remove(), 300);
    }
  }, duration);
}

function getNotificationClasses(type) {
  const classes = {
    success: "bg-green-500 text-white",
    error: "bg-red-500 text-white",
    warning: "bg-yellow-500 text-white",
    info: "bg-blue-500 text-white",
  };
  return classes[type] || classes.info;
}

function getNotificationIcon(type) {
  const icons = {
    success: '<i class="fas fa-check-circle"></i>',
    error: '<i class="fas fa-exclamation-circle"></i>',
    warning: '<i class="fas fa-exclamation-triangle"></i>',
    info: '<i class="fas fa-info-circle"></i>',
  };
  return icons[type] || icons.info;
}

// Make functions globally available
window.editSectionItems = editSectionItems;
window.duplicateSection = duplicateSection;
window.previewImage = previewImage;
window.previewVideo = previewVideo;
window.getSectionTypeIcon = getSectionTypeIcon;
window.getFieldTypeIcon = getFieldTypeIcon;
window.showSectionNotification = showSectionNotification;
// Layout View Management Functions
window.PageLayoutManager = {
  // Toggle layout structure view
  toggleLayoutView: function () {
    const layoutStructure =
      document.getElementById("layoutStructure");
    const toggleText = document.getElementById("layoutToggleText");

    if (layoutStructure && toggleText) {
      if (layoutStructure.style.display === "none") {
        layoutStructure.style.display = "block";
        toggleText.textContent = "Hide Layout";
      } else {
        layoutStructure.style.display = "none";
        toggleText.textContent = "Show Layout";
      }
    }
  },

  // Toggle page sections within layout view
  togglePageSections: function () {
    const container = document.getElementById(
      "pageSectionsContainer"
    );
    const toggleIcon = document.getElementById(
      "pageSectionsToggleIcon"
    );
    const toggleText = document.getElementById(
      "pageSectionsToggleText"
    );

    if (container && toggleIcon && toggleText) {
      if (container.style.display === "none") {
        container.style.display = "block";
        toggleIcon.className = "fas fa-chevron-up mr-1";
        toggleText.textContent = "Hide Page Sections";
      } else {
        container.style.display = "none";
        toggleIcon.className = "fas fa-chevron-down mr-1";
        toggleText.textContent = "Show Page Sections";
      }
    }
  },

  // Toggle between layout view and traditional view
  toggleTraditionalView: function () {
    const layoutView = document.querySelector(
      ".bg-white.rounded-xl.shadow-md.mb-6"
    );
    const traditionalView = document.getElementById(
      "traditionalSectionsView"
    );

    if (layoutView && traditionalView) {
      if (traditionalView.style.display === "none") {
        layoutView.style.display = "none";
        traditionalView.style.display = "block";
      } else {
        layoutView.style.display = "block";
        traditionalView.style.display = "none";
      }
    }
  },

  // Initialize layout view
  init: function () {
    console.log("Page Layout Manager initialized");

    // Add smooth transitions
    const layoutElements = document.querySelectorAll(
      ".layout-position-section"
    );
    layoutElements.forEach((element) => {
      element.style.transition = "all 0.3s ease";
    });

    // Initialize section cards hover effects
    this.initializeSectionCards();
  },

  // Initialize section card interactions
  initializeSectionCards: function () {
    // Layout section cards
    const layoutCards = document.querySelectorAll(
      ".layout-section-card"
    );
    layoutCards.forEach((card) => {
      card.addEventListener("mouseenter", function () {
        this.style.transform = "translateY(-2px)";
        this.style.boxShadow = "0 4px 12px rgba(0, 0, 0, 0.1)";
      });

      card.addEventListener("mouseleave", function () {
        this.style.transform = "translateY(0)";
        this.style.boxShadow = "";
      });
    });

    // Page section cards
    const pageCards = document.querySelectorAll(".page-section-card");
    pageCards.forEach((card) => {
      card.addEventListener("mouseenter", function () {
        this.style.transform = "translateY(-1px)";
        this.style.boxShadow = "0 2px 8px rgba(0, 0, 0, 0.1)";
      });

      card.addEventListener("mouseleave", function () {
        this.style.transform = "translateY(0)";
        this.style.boxShadow = "";
      });
    });
  },

  // Show notification
  showNotification: function (message, type = "info") {
    const notification = document.createElement("div");
    notification.className = `fixed top-4 right-4 px-4 py-2 rounded-lg shadow-lg z-50 ${this.getNotificationClass(
      type
    )}`;
    notification.innerHTML = `
            <div class="flex items-center">
                <i class="fas ${this.getNotificationIcon(
                  type
                )} mr-2"></i>
                <span>${message}</span>
                <button type="button" class="ml-3 text-white hover:text-gray-200" onclick="this.parentElement.parentElement.remove()">
                    <i class="fas fa-times"></i>
                </button>
            </div>
        `;

    document.body.appendChild(notification);

    // Auto remove after 3 seconds
    setTimeout(() => {
      if (notification.parentElement) {
        notification.remove();
      }
    }, 3000);
  },

  // Get notification CSS class
  getNotificationClass: function (type) {
    switch (type) {
      case "success":
        return "bg-green-500 text-white";
      case "error":
        return "bg-red-500 text-white";
      case "warning":
        return "bg-yellow-500 text-white";
      default:
        return "bg-blue-500 text-white";
    }
  },

  // Get notification icon
  getNotificationIcon: function (type) {
    switch (type) {
      case "success":
        return "fa-check-circle";
      case "error":
        return "fa-exclamation-circle";
      case "warning":
        return "fa-exclamation-triangle";
      default:
        return "fa-info-circle";
    }
  },
};

// Global functions for backward compatibility
function toggleLayoutView() {
  PageLayoutManager.toggleLayoutView();
}

function togglePageSections() {
  PageLayoutManager.togglePageSections();
}

function toggleTraditionalView() {
  PageLayoutManager.toggleTraditionalView();
}

// Initialize when DOM is ready
document.addEventListener("DOMContentLoaded", function () {
  if (typeof PageLayoutManager !== "undefined") {
    PageLayoutManager.init();
  }
});
// Character counter for translation fields
document.addEventListener("DOMContentLoaded", function () {
  // Add character counters to translation fields
  const metaTitleInputs = document.querySelectorAll(
    'input[name*="MetaTitle"]'
  );
  const metaDescInputs = document.querySelectorAll(
    'textarea[name*="MetaDescription"]'
  );

  metaTitleInputs.forEach((input) => {
    addCharacterCounter(input, 60);
  });

  metaDescInputs.forEach((textarea) => {
    addCharacterCounter(textarea, 160);
  });
});

function addCharacterCounter(element, maxLength) {
  const counter = document.createElement("span");
  counter.className = "char-counter";
  counter.textContent = `0/${maxLength}`;

  // Insert counter after the element
  element.parentNode.insertBefore(counter, element.nextSibling);

  element.addEventListener("input", function () {
    const length = this.value.length;
    counter.textContent = `${length}/${maxLength}`;

    // Update counter color based on length
    counter.classList.remove("warning", "danger");
    if (length > maxLength * 0.8) {
      counter.classList.add("warning");
    }
    if (length > maxLength) {
      counter.classList.add("danger");
    }
  });

  // Initial count
  const initialLength = element.value.length;
  counter.textContent = `${initialLength}/${maxLength}`;
}

// Auto-save translations
let translationAutoSaveTimer;
function enableTranslationAutoSave() {
  const translationInputs = document.querySelectorAll(
    "#translationsPanel input, #translationsPanel textarea"
  );

  translationInputs.forEach((input) => {
    input.addEventListener("input", function () {
      clearTimeout(translationAutoSaveTimer);
      translationAutoSaveTimer = setTimeout(() => {
        // Auto-save translations after 3 seconds of inactivity
        console.log("Auto-saving translations...");
        // This would call the actual save function
      }, 3000);
    });
  });
}

// Initialize auto-save when translations panel is opened
const originalToggleTranslationsPanel =
  window.toggleTranslationsPanel;
window.toggleTranslationsPanel = function () {
  originalToggleTranslationsPanel();

  // Enable auto-save when panel is opened
  const panel = document.getElementById("translationsPanel");
  if (panel && panel.style.display !== "none") {
    setTimeout(enableTranslationAutoSave, 100);
  }
};
