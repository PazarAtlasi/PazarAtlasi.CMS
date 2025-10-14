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

      // Load available pages and populate dropdown
      await loadAvailablePages();
      populatePageDropdown();

      // Set page value if provided
      if (pageId > 0) {
        const pageSelect = document.getElementById("modalPageId");
        if (pageSelect) {
          pageSelect.value = pageId;
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

    const templateContainer = document.getElementById(
      "templateSelectionContainer"
    );
    const templateGrid = document.getElementById("templateGrid");

    if (sectionType === "0" || !sectionType) {
      templateContainer.classList.add("hidden");
      document
        .getElementById("templateConfigContainer")
        .classList.add("hidden");
      return;
    }

    // Show loading state
    templateGrid.innerHTML = `
      <div class="col-span-full text-center py-8">
        <i class="fas fa-spinner fa-spin text-2xl text-purple-600 mb-2"></i>
        <p class="text-sm text-slate-600">Loading templates...</p>
      </div>
    `;
    templateContainer.classList.remove("hidden");

    try {
      // Load templates HTML from backend
      const html = await ContentServices.getTemplatesPartial(
        sectionType
      );
      templateGrid.innerHTML = html;
    } catch (error) {
      console.error("Error loading templates:", error);
      templateGrid.innerHTML = `
        <div class="col-span-full text-center py-8 text-red-500">
          <i class="fas fa-exclamation-circle text-3xl mb-2"></i>
          <p class="text-sm">Error loading templates</p>
        </div>
      `;
    }
  }

  /**
   * Select template
   */
  function selectTemplate(templateId) {
    currentSection.templateId = templateId;

    // Update UI - highlight selected template
    document.querySelectorAll(".template-card").forEach((card) => {
      if (parseInt(card.dataset.templateId) === templateId) {
        card.classList.remove("border-slate-200");
        card.classList.add("border-purple-600", "bg-purple-50");
      } else {
        card.classList.remove("border-purple-600", "bg-purple-50");
        card.classList.add("border-slate-200");
      }
    });

    // Load template configuration if needed
    loadTemplateConfig(templateId);
  }

  /**
   * Load template configuration
   */
  async function loadTemplateConfig(templateId) {
    try {
      const result = await ContentServices.getTemplatesBySectionType(
        currentSection.type
      );

      if (result.success && result.templates) {
        const template = result.templates.find(
          (t) => t.id === templateId
        );

        if (template && template.configurationSchema) {
          const configContainer = document.getElementById(
            "templateConfigContainer"
          );
          const configFields = document.getElementById(
            "templateConfigFields"
          );

          try {
            const schema = JSON.parse(template.configurationSchema);
            configFields.innerHTML = `
              <div class="space-y-4">
                <p class="text-sm text-slate-600">Template-specific configuration</p>
                <pre class="bg-slate-100 p-3 rounded text-xs overflow-auto">${JSON.stringify(
                  schema,
                  null,
                  2
                )}</pre>
              </div>
            `;
            configContainer.classList.remove("hidden");
          } catch (error) {
            configContainer.classList.add("hidden");
          }
        } else {
          document
            .getElementById("templateConfigContainer")
            .classList.add("hidden");
        }
      }
    } catch (error) {
      console.error("Error loading template config:", error);
    }
  }

  /**
   * Save section
   */
  async function save() {
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
        SectionItems: [],
        Translations: [],
      };

      const result = await ContentServices.saveSection(sectionData);

      if (result.success) {
        close();
        location.reload(); // Refresh page to show new section
      } else {
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

  /**
   * Populate page dropdown
   */
  function populatePageDropdown() {
    const select = document.getElementById("modalPageId");
    if (!select) return;

    // Clear existing options except first
    while (select.children.length > 1) {
      select.removeChild(select.lastChild);
    }

    // Add page options
    availablePages.forEach((page) => {
      const option = document.createElement("option");
      option.value = page.id;
      option.textContent = `${page.name} (${page.code})`;
      select.appendChild(option);
    });
  }

  // Public API
  return {
    show,
    close,
    handlePageChange,
    handleSectionTypeChange,
    selectTemplate,
    save,
  };
})();

// Make globally available
window.SectionModal = SectionModal;
