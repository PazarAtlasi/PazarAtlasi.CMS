/**
 * Layout Management JavaScript
 * Handles layout editing, schema visualization, and section position management
 */

// Layout Management Object
window.LayoutManager = {
  currentLayoutId: null,

  // Initialize layout manager
  init: function (layoutId) {
    this.currentLayoutId = layoutId;
    this.bindEvents();
    this.initializeSchema();
  },

  // Bind event listeners
  bindEvents: function () {
    // Add hover effects to schema sections
    const schemaItems = document.querySelectorAll(
      ".schema-section-item"
    );
    schemaItems.forEach((item) => {
      item.addEventListener("mouseenter", function () {
        this.style.transform = "scale(1.05)";
        this.style.transition = "transform 0.2s ease";
      });

      item.addEventListener("mouseleave", function () {
        this.style.transform = "scale(1)";
      });
    });
  },

  // Initialize schema visualization
  initializeSchema: function () {
    console.log(
      "Layout schema initialized for layout:",
      this.currentLayoutId
    );
  },

  // Toggle section settings
  toggleSectionSettings: function (sectionId) {
    const settings = document.getElementById(
      `sectionSettings_${sectionId}`
    );
    if (settings) {
      if (settings.style.display === "none") {
        settings.style.display = "block";
      } else {
        settings.style.display = "none";
      }
    }
  },

  // Toggle schema view
  toggleSchemaView: function () {
    const schema =
      document.querySelector(".layout-schema").parentElement
        .parentElement;
    const toggleText = document.getElementById("schemaToggleText");

    if (schema.style.display === "none") {
      schema.style.display = "block";
      toggleText.textContent = "Hide Schema";
    } else {
      schema.style.display = "none";
      toggleText.textContent = "Show Schema";
    }
  },

  // Update section position and refresh schema
  updateSectionPosition: async function (sectionId, newPosition) {
    try {
      // Show loading state
      this.showNotification("Updating section position...", "info");

      // Update position on server
      const result = await ContentServices.updateSectionPosition(
        this.currentLayoutId,
        sectionId,
        newPosition
      );

      if (result.success) {
        // Update the schema view
        await this.refreshLayoutSchema();

        // Show success notification
        this.showNotification(result.message, "success");
      } else {
        this.showNotification(
          result.message || "Failed to update section position",
          "error"
        );
      }
    } catch (error) {
      console.error("Error updating section position:", error);
      this.showNotification(
        "An error occurred while updating section position",
        "error"
      );
    }
  },

  // Refresh layout schema
  refreshLayoutSchema: async function () {
    try {
      const result = await ContentServices.getLayoutSchema(
        this.currentLayoutId
      );

      if (result.success) {
        this.updateSchemaVisualization(result.schema);
      } else {
        console.error("Failed to refresh schema:", result.message);
      }
    } catch (error) {
      console.error("Error refreshing layout schema:", error);
    }
  },

  // Update schema visualization
  updateSchemaVisualization: function (schema) {
    // Update header sections
    this.updateSchemaSection("header", schema.header);

    // Update content sections
    this.updateSchemaSection("content", schema.content);

    // Update sidebar sections
    this.updateSchemaSection("sidebar", schema.sidebar);

    // Update footer sections
    this.updateSchemaSection("footer", schema.footer);
  },

  // Update individual schema section
  updateSchemaSection: function (position, sections) {
    const container = document.querySelector(
      `[data-position="${position}"]`
    );
    if (!container) return;

    // Clear existing items (except placeholder and default content)
    const existingItems = container.querySelectorAll(
      ".schema-section-item"
    );
    existingItems.forEach((item) => item.remove());

    // Add updated sections
    sections.forEach((section) => {
      const sectionElement = document.createElement("div");
      sectionElement.className = `schema-section-item bg-${this.getPositionColor(
        position
      )}-100 border border-${this.getPositionColor(
        position
      )}-300 rounded px-3 py-1 text-xs font-medium text-${this.getPositionColor(
        position
      )}-800 flex items-center`;
      sectionElement.innerHTML = `
                <i class="fas fa-layer-group mr-1"></i>
                ${section.key || section.type}
            `;

      // Insert before placeholder
      const placeholder = container.querySelector(
        ".schema-placeholder"
      );
      if (placeholder) {
        container.insertBefore(sectionElement, placeholder);
      } else {
        container.appendChild(sectionElement);
      }
    });

    // Update section count
    const countElement = container.parentElement.querySelector(
      ".text-xs.text-slate-500"
    );
    if (countElement) {
      countElement.textContent = `${sections.length} sections`;
    }

    // Show/hide placeholder
    const placeholder = container.querySelector(
      ".schema-placeholder"
    );
    if (placeholder) {
      placeholder.style.display =
        sections.length > 0 ? "none" : "flex";
    }
  },

  // Get position color
  getPositionColor: function (position) {
    switch (position) {
      case "header":
        return "blue";
      case "content":
        return "green";
      case "sidebar":
        return "purple";
      case "footer":
        return "orange";
      default:
        return "gray";
    }
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
function toggleSectionSettings(sectionId) {
  LayoutManager.toggleSectionSettings(sectionId);
}

function toggleSchemaView() {
  LayoutManager.toggleSchemaView();
}

function updateSectionPosition(sectionId, newPosition) {
  LayoutManager.updateSectionPosition(sectionId, newPosition);
}

function showNotification(message, type) {
  LayoutManager.showNotification(message, type);
}

// Initialize when DOM is ready
document.addEventListener("DOMContentLoaded", function () {
  // Layout manager will be initialized from the layout edit page
  console.log("Layout management scripts loaded");
});
