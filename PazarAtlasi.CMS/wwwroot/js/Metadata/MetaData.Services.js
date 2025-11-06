/**
 * MetaData Services - AJAX Request Handler for Metadata Operations
 * Handles all AJAX requests for DataSchema, Product, Category, etc.
 */

// Prevent redeclaration
if (typeof MetaDataServices === "undefined") {
  var MetaDataServices = (function () {
    "use strict";

    // Private variables
    let baseUrl = "";
    let defaultHeaders = {
      "Content-Type": "application/json",
      "X-Requested-With": "XMLHttpRequest",
    };

    // Initialize
    function init() {
      baseUrl = window.location.origin;

      // Add CSRF token to default headers
      const token = $(
        'input[name="__RequestVerificationToken"]'
      ).val();
      if (token) {
        defaultHeaders["RequestVerificationToken"] = token;
      }
    }

    // Generic AJAX request handler
    function makeRequest(options) {
      const defaultOptions = {
        method: "GET",
        headers: defaultHeaders,
        timeout: 30000,
      };

      const config = { ...defaultOptions, ...options };

      return new Promise((resolve, reject) => {
        $.ajax({
          url: config.url,
          type: config.method,
          data: config.data,
          headers: config.headers,
          timeout: config.timeout,
          success: function (response) {
            resolve(response);
          },
          error: function (xhr, status, error) {
            const errorResponse = {
              status: xhr.status,
              statusText: xhr.statusText,
              message: error,
              response: xhr.responseJSON || xhr.responseText,
            };
            reject(errorResponse);
          },
        });
      });
    }

    // DataSchema Services
    const dataSchemaServices = {
      // Get field types
      getFieldTypes: function () {
        return makeRequest({
          url: `${baseUrl}/Metadata/GetFieldTypes`,
          method: "GET",
        });
      },

      // Create data schema
      create: function (schemaData) {
        return makeRequest({
          url: `${baseUrl}/Metadata/CreateDataSchema`,
          method: "POST",
          data: schemaData,
          headers: {
            ...defaultHeaders,
            "Content-Type": "application/x-www-form-urlencoded",
          },
        });
      },

      // Update data schema
      update: function (id, schemaData) {
        return makeRequest({
          url: `${baseUrl}/Metadata/EditDataSchema/${id}`,
          method: "POST",
          data: schemaData,
          headers: {
            ...defaultHeaders,
            "Content-Type": "application/x-www-form-urlencoded",
          },
        });
      },

      // Delete data schema
      delete: function (id) {
        return makeRequest({
          url: `${baseUrl}/Metadata/DeleteDataSchema`,
          method: "POST",
          data: { id: id },
          headers: {
            ...defaultHeaders,
            "Content-Type": "application/x-www-form-urlencoded",
          },
        });
      },

      // Get schema details
      getDetails: function (id) {
        return makeRequest({
          url: `${baseUrl}/Metadata/DataSchemaDetails/${id}`,
          method: "GET",
        });
      },
    };

    // Product Services
    const productServices = {
      // Get available schemas for product
      getAvailableSchemas: function () {
        return makeRequest({
          url: `${baseUrl}/Metadata/GetAvailableSchemas`,
          method: "GET",
        });
      },

      // Get schema fields
      getSchemaFields: function (schemaId) {
        return makeRequest({
          url: `${baseUrl}/Metadata/GetSchemaFields/${schemaId}`,
          method: "GET",
        });
      },

      // Create product with schema data
      createWithSchema: function (productData) {
        return makeRequest({
          url: `${baseUrl}/Metadata/CreateProductWithSchema`,
          method: "POST",
          data: productData,
          headers: {
            ...defaultHeaders,
            "Content-Type": "application/x-www-form-urlencoded",
          },
        });
      },

      // Update product schema values
      updateSchemaValues: function (
        productId,
        schemaId,
        fieldValues
      ) {
        return makeRequest({
          url: `${baseUrl}/Metadata/UpdateProductSchemaValues`,
          method: "POST",
          data: {
            productId: productId,
            schemaId: schemaId,
            fieldValues: fieldValues,
          },
          headers: {
            ...defaultHeaders,
            "Content-Type": "application/x-www-form-urlencoded",
          },
        });
      },
    };

    // Category Services
    const categoryServices = {
      // Get category hierarchy
      getHierarchy: function () {
        return makeRequest({
          url: `${baseUrl}/Metadata/GetCategoryHierarchy`,
          method: "GET",
        });
      },

      // Create category
      create: function (categoryData) {
        return makeRequest({
          url: `${baseUrl}/Metadata/CreateCategory`,
          method: "POST",
          data: categoryData,
          headers: {
            ...defaultHeaders,
            "Content-Type": "application/x-www-form-urlencoded",
          },
        });
      },
    };

    // File Upload Services
    const fileServices = {
      // Upload image
      uploadImage: function (file, folder = null) {
        const formData = new FormData();
        formData.append("file", file);
        if (folder) {
          formData.append("folder", folder);
        }

        return makeRequest({
          url: `${baseUrl}/Content/UploadImage`,
          method: "POST",
          data: formData,
          headers: {
            "X-Requested-With": "XMLHttpRequest",
            RequestVerificationToken:
              defaultHeaders["RequestVerificationToken"],
          },
        });
      },

      // Upload video
      uploadVideo: function (file, folder = null) {
        const formData = new FormData();
        formData.append("file", file);
        if (folder) {
          formData.append("folder", folder);
        }

        return makeRequest({
          url: `${baseUrl}/Content/UploadVideo`,
          method: "POST",
          data: formData,
          headers: {
            "X-Requested-With": "XMLHttpRequest",
            RequestVerificationToken:
              defaultHeaders["RequestVerificationToken"],
          },
        });
      },

      // Delete media
      deleteMedia: function (url) {
        return makeRequest({
          url: `${baseUrl}/Content/DeleteMedia`,
          method: "POST",
          data: { url: url },
          headers: {
            ...defaultHeaders,
            "Content-Type": "application/x-www-form-urlencoded",
          },
        });
      },
    };

    // Utility functions
    const utils = {
      // Show loading spinner
      showLoading: function (element) {
        if (element) {
          element.innerHTML =
            '<i class="fas fa-spinner fa-spin mr-2"></i>Yükleniyor...';
          element.disabled = true;
        }
      },

      // Hide loading spinner
      hideLoading: function (element, originalText) {
        if (element) {
          element.innerHTML = originalText;
          element.disabled = false;
        }
      },

      // Show success message
      showSuccess: function (message, title = "Başarılı!") {
        Swal.fire({
          title: title,
          text: message,
          icon: "success",
          timer: 3000,
          showConfirmButton: false,
        });
      },

      // Show error message
      showError: function (message, title = "Hata!") {
        Swal.fire({
          title: title,
          text: message,
          icon: "error",
          confirmButtonText: "Tamam",
        });
      },

      // Show confirmation dialog
      showConfirmation: function (
        title,
        text,
        confirmText = "Evet",
        cancelText = "İptal"
      ) {
        return Swal.fire({
          title: title,
          text: text,
          icon: "question",
          showCancelButton: true,
          confirmButtonColor: "#3b82f6",
          cancelButtonColor: "#6b7280",
          confirmButtonText: confirmText,
          cancelButtonText: cancelText,
        });
      },

      // Debounce function
      debounce: function (func, wait) {
        let timeout;
        return function executedFunction(...args) {
          const later = () => {
            clearTimeout(timeout);
            func(...args);
          };
          clearTimeout(timeout);
          timeout = setTimeout(later, wait);
        };
      },

      // Generate unique ID
      generateId: function () {
        return "id_" + Math.random().toString(36).substr(2, 9);
      },

      // Format date
      formatDate: function (date, format = "dd.MM.yyyy") {
        if (!date) return "";
        const d = new Date(date);
        const day = String(d.getDate()).padStart(2, "0");
        const month = String(d.getMonth() + 1).padStart(2, "0");
        const year = d.getFullYear();

        return format
          .replace("dd", day)
          .replace("MM", month)
          .replace("yyyy", year);
      },

      // Validate form
      validateForm: function (formElement) {
        if (!formElement) return false;

        const requiredFields =
          formElement.querySelectorAll("[required]");
        let isValid = true;

        requiredFields.forEach((field) => {
          if (!field.value.trim()) {
            field.classList.add("border-red-500");
            isValid = false;
          } else {
            field.classList.remove("border-red-500");
          }
        });

        return isValid;
      },
    };

    // Public API
    return {
      init: init,
      dataSchema: dataSchemaServices,
      product: productServices,
      category: categoryServices,
      file: fileServices,
      utils: utils,
    };
  })();

  // Auto-initialize when DOM is ready
  $(document).ready(function () {
    MetaDataServices.init();
  });
}
