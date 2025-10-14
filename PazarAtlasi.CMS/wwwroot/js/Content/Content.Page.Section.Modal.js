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
   * Select template
   */
  function selectTemplate(templateId) {
    currentSection.templateId = parseInt(templateId) || null;
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
        TemplateId: currentSection.templateId,
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
