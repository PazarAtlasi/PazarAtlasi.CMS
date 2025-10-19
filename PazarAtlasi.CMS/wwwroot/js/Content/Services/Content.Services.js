/**
 * Content Services - AJAX Request Handler
 * Tüm Content ile ilgili AJAX isteklerini yöneten servis katmanı
 * jQuery AJAX kullanarak daha okunaklı ve kontrol edilebilir
 */

const ContentServices = (function () {
    "use strict";

    // Base configuration
    const config = {
        baseUrl: "/Content",
    };

    /**
     * Helper: Get anti-forgery token
     */
    function getAntiForgeryToken() {
        const token = document.querySelector(
            'input[name="__RequestVerificationToken"]'
        );
        return token ? token.value : "";
    }

    /**
     * Helper: Build headers with anti-forgery token
     */
    function buildHeaders(additionalHeaders = {}) {
        const headers = {
            Accept: "application/json",
            ...additionalHeaders,
        };

        const token = getAntiForgeryToken();
        if (token) {
            headers["RequestVerificationToken"] = token;
        }

        return headers;
    }

    // ==================== PAGE SERVICES ====================

    /**
     * Get pages list with pagination
     */
    function getPages(payload) {
        const { page = 1, pageSize = 10 } = payload;
        return $.ajax({
            url: `${config.baseUrl}/Pages`,
            type: "GET",
            data: { page, pageSize },
            headers: buildHeaders(),
            dataType: "json",
        });
    }

    /**
     * Get page details by ID
     */
    function getPageDetails(pageId) {
        return $.ajax({
            url: `${config.baseUrl}/PageDetails/${pageId}`,
            type: "GET",
            headers: buildHeaders(),
            dataType: "json",
        });
    }

    /**
     * Get page edit data
     */
    function getPageEdit(pageId) {
        return $.ajax({
            url: `${config.baseUrl}/PageEdit/${pageId}`,
            type: "GET",
            headers: buildHeaders(),
            dataType: "html",
        });
    }

    /**
     * Save page draft
     */
    function saveDraft(pageId, formData) {
        return $.ajax({
            url: `${config.baseUrl}/SaveDraft/${pageId}`,
            type: "POST",
            headers: buildHeaders({ "Content-Type": "application/json" }),
            data: JSON.stringify(formData),
            dataType: "json",
        });
    }

    /**
     * Publish page
     */
    function publishPage(pageId) {
        return $.ajax({
            url: `${config.baseUrl}/PublishPage/${pageId}`,
            type: "POST",
            headers: buildHeaders(),
            dataType: "json",
        });
    }

    /**
     * Delete page
     */
    function deletePage(pageId) {
        return $.ajax({
            url: `${config.baseUrl}/DeletePage/${pageId}`,
            type: "DELETE",
            headers: buildHeaders(),
            dataType: "json",
        });
    }

    /**
     * Get available pages
     */
    function getAvailablePages() {
        return $.ajax({
            url: `${config.baseUrl}/GetAvailablePages`,
            type: "GET",
            headers: buildHeaders(),
            dataType: "json",
        });
    }

    /**
     * Get content by type
     */
    function getContentByType(pageType) {
        return $.ajax({
            url: `${config.baseUrl}/GetContentByType`,
            type: "GET",
            data: { pageType },
            headers: buildHeaders(),
            dataType: "json",
        });
    }

    // ==================== SECTION SERVICES ====================

    /**
     * Get section modal
     */
    function getSectionModal(id, pageId) {
        return $.ajax({
            url: `${config.baseUrl}/GetSectionModal`,
            type: "GET",
            data: { id, pageId },
            dataType: "html",
        });
    }

    /**
     * Get available templates by section type
     */
    function getTemplatesBySectionType(sectionType) {
        return $.ajax({
            url: `${config.baseUrl}/GetTemplatesBySectionType`,
            type: "GET",
            data: { sectionType },
            headers: buildHeaders(),
            dataType: "json",
        });
    }

    /**
     * Get new section item card as partial view HTML
     */
    function getNewSectionItemCard(templateId, sectionId = 0, itemIndex = 0) {
        return $.ajax({
            url: `${config.baseUrl}/GetNewSectionItemCard`,
            type: "GET",
            data: { templateId, sectionId, itemIndex },
            headers: buildHeaders(),
            dataType: "html",
        });
    }

    /**
     * Get new nested item card as partial view HTML
     */
    function getNewNestedItemCard(templateId, parentTempId, nestedIndex = 0) {
        return $.ajax({
            url: `${config.baseUrl}/GetNewNestedItemCard`,
            type: "GET",
            data: { templateId, parentTempId, nestedIndex },
            headers: buildHeaders(),
            dataType: "html",
        });
    }

    /**
     * Get templates partial view HTML
     */
    function getTemplatesPartial(sectionType) {
        return $.ajax({
            url: `${config.baseUrl}/GetTemplatesPartial`,
            type: "GET",
            data: { sectionType },
            headers: buildHeaders(),
            dataType: "html",
        });
    }

    /**
     * Get reusable sections
     */
    function getReusableSections() {
        return $.ajax({
            url: `${config.baseUrl}/GetReusableSections`,
            type: "GET",
            headers: buildHeaders(),
            dataType: "json",
        });
    }

    /**
     * Add reusable section to page
     */
    function addReusableSection(payload) {
        return $.ajax({
            url: `${config.baseUrl}/AddReusableSection`,
            type: "POST",
            headers: buildHeaders({ "Content-Type": "application/json" }),
            data: JSON.stringify(payload),
            dataType: "json",
        });
    }

    /**
     * Remove section from page
     */
    function removeSection(sectionId) {
        return $.ajax({
            url: `${config.baseUrl}/RemoveSection`,
            type: "POST",
            headers: buildHeaders({ "Content-Type": "application/json" }),
            data: JSON.stringify({ sectionId }),
            dataType: "json",
        });
    }

    /**
     * Save section
     */
    function saveSection(sectionData) {
        return $.ajax({
            url: `${config.baseUrl}/SaveSectionAjax`,
            type: "POST",
            headers: buildHeaders({ "Content-Type": "application/json" }),
            data: JSON.stringify(sectionData),
            dataType: "json",
        });
    }

    /**
     * Delete section
     */
    function deleteSection(sectionId) {
        return $.ajax({
            url: `${config.baseUrl}/DeleteSection`,
            type: "POST",
            headers: buildHeaders({ "Content-Type": "application/json" }),
            data: JSON.stringify({ id: sectionId }),
            dataType: "json",
        });
    }

    // ==================== SECTION ITEM SERVICES ====================

    /**
     * Save section item
     */
    function saveSectionItem(itemData) {
        return $.ajax({
            url: `${config.baseUrl}/SaveSectionItem`,
            type: "POST",
            headers: buildHeaders({ "Content-Type": "application/json" }),
            data: JSON.stringify(itemData),
            dataType: "json",
        });
    }

    // ==================== LAYOUT SERVICES ====================

    /**
     * Get available layouts
     */
    function getAvailableLayouts() {
        return $.ajax({
            url: `${config.baseUrl}/GetAvailableLayouts`,
            type: "GET",
            headers: buildHeaders(),
            dataType: "json",
        });
    }

    /**
     * Get layout sections with configuration
     */
    function getLayoutSections(layoutId) {
        return $.ajax({
            url: `${config.baseUrl}/GetLayoutSections`,
            type: "GET",
            data: { layoutId },
            headers: buildHeaders(),
            dataType: "json",
        });
    }

    /**
     * Delete layout
     */
    function deleteLayout(layoutId) {
        return $.ajax({
            url: `${config.baseUrl}/DeleteLayout`,
            type: "POST",
            headers: buildHeaders({ "Content-Type": "application/json" }),
            data: JSON.stringify({ id: layoutId }),
            dataType: "json",
        });
    }

    // ==================== MEDIA UPLOAD SERVICES ====================

    /**
     * Upload image
     */
    function uploadImage(file, folder = "images") {
        const formData = new FormData();
        formData.append("file", file);
        formData.append("folder", folder);

        return $.ajax({
            url: `${config.baseUrl}/UploadImage`,
            type: "POST",
            data: formData,
            processData: false,
            contentType: false,
            dataType: "json",
        });
    }

    /**
     * Upload video
     */
    function uploadVideo(file, folder = "videos") {
        const formData = new FormData();
        formData.append("file", file);
        formData.append("folder", folder);

        return $.ajax({
            url: `${config.baseUrl}/UploadVideo`,
            type: "POST",
            data: formData,
            processData: false,
            contentType: false,
            dataType: "json",
        });
    }

    /**
     * Upload document
     */
    function uploadDocument(file, folder = "documents") {
        const formData = new FormData();
        formData.append("file", file);
        formData.append("folder", folder);

        return $.ajax({
            url: `${config.baseUrl}/UploadImage`,
            type: "POST",
            data: formData,
            processData: false,
            contentType: false,
            dataType: "json",
        });
    }

    // ==================== PUBLIC API ====================
    return {
        // Page services
        getPages,
        getPageDetails,
        getPageEdit,
        saveDraft,
        publishPage,
        deletePage,
        getAvailablePages,
        getContentByType,

        // Section services
        getSectionModal,
        getTemplatesBySectionType,
        getNewSectionItemCard,
        getNewNestedItemCard,
        getTemplatesPartial,
        getReusableSections,
        addReusableSection,
        removeSection,
        saveSection,
        deleteSection,

        saveSectionItem,

        // Layout services
        getAvailableLayouts,
        getLayoutSections,
        deleteLayout,

        // Media upload services
        uploadImage,
        uploadVideo,
        uploadDocument,

        // Utility
        getAntiForgeryToken,
        buildHeaders,
    };
})();

// Export for use in other modules
if (typeof module !== "undefined" && module.exports) {
    module.exports = ContentServices;
}
