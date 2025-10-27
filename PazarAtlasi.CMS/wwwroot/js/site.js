// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// DOM elements
const sidebar = document.getElementById("sidebar");
const mainContent = document.querySelector(".main-content");
const menuBtn = document.getElementById("menu-btn");
const submenuItems = document.querySelectorAll(
  ".sidebar-item.has-submenu"
);
const searchInput = document.querySelector(".search-box input");
const dropdownMenus = document.querySelectorAll(".dropdown");
const profileDropdown = document.querySelector(".profile-dropdown");
const profileButton = document.querySelector(
  ".profile-dropdown .profile-link"
);
const profileMenu = document.querySelector(
  ".profile-dropdown .dropdown-menu"
);
const languageDropdown = document.querySelector(".language-dropdown");
const languageButton = document.querySelector(
  ".language-dropdown .language-link"
);
const languageMenu = document.querySelector(
  ".language-dropdown .language-menu"
);

// Set initial state on page load
if (mainContent) {
  mainContent.style.marginLeft = "var(--sidebar-collapsed-width)";
  document.documentElement.style.setProperty(
    "--sidebar-width",
    "var(--sidebar-collapsed-width)"
  );
}

// Function to update sidebar state and appearance
function updateSidebarState(isCollapsed) {
  if (!sidebar || !mainContent) return;

  if (isCollapsed) {
    sidebar.classList.add("collapsed");
    mainContent.style.marginLeft = "var(--sidebar-collapsed-width)";
    document.documentElement.style.setProperty(
      "--sidebar-width",
      "var(--sidebar-collapsed-width)"
    );
  } else {
    sidebar.classList.remove("collapsed");
    mainContent.style.marginLeft = "250px";
    document.documentElement.style.setProperty(
      "--sidebar-width",
      "250px"
    );
  }

  // Save state to localStorage
  localStorage.setItem("sidebar-collapsed", isCollapsed);
}

// Force sidebar to be collapsed by default - executed immediately
if (sidebar && mainContent) {
  // Default to collapsed
  updateSidebarState(true);
}

// Toggle sidebar on menu button click
if (menuBtn) {
  menuBtn.addEventListener("click", function () {
    console.log("Menu button clicked");

    // Get current state
    const isCurrentlyCollapsed =
      sidebar.classList.contains("collapsed");

    // Toggle to the opposite state
    updateSidebarState(!isCurrentlyCollapsed);

    // Explicitly save the state for hover control
    localStorage.setItem("sidebar-collapsed", !isCurrentlyCollapsed);

    // Force DOM reflow to ensure styles are applied
    sidebar.offsetHeight;
  });
}

// Toggle submenu on sidebar item click
submenuItems.forEach((item) => {
  const link = item.querySelector(".sidebar-link");
  link.addEventListener("click", function (e) {
    e.preventDefault();

    // Close any other open submenus
    if (!item.classList.contains("active")) {
      submenuItems.forEach((i) => {
        if (i !== item && i.classList.contains("active")) {
          i.classList.remove("active");
          const submenu = i.querySelector(".sidebar-submenu");
          submenu.style.maxHeight = "0px";
        }
      });
    }

    // Toggle active class on clicked item
    item.classList.toggle("active");

    // Toggle submenu height
    const submenu = item.querySelector(".sidebar-submenu");
    if (item.classList.contains("active")) {
      submenu.style.maxHeight = submenu.scrollHeight + "px";
    } else {
      submenu.style.maxHeight = "0px";
    }
  });
});

// Initialize dropdown menus
dropdownMenus.forEach((dropdown) => {
  const button = dropdown.querySelector("button");
  const menu = dropdown.querySelector("ul");

  if (button && menu) {
    button.addEventListener("click", (e) => {
      e.stopPropagation();
      menu.classList.toggle("hidden");
    });

    // Close when clicking outside
    document.addEventListener("click", () => {
      menu.classList.add("hidden");
    });

    // Prevent closing when clicking the menu itself
    menu.addEventListener("click", (e) => {
      e.stopPropagation();
    });
  }
});

// Profile dropdown toggle with fix for hover issue
if (profileButton && profileMenu) {
  // Click event for toggling dropdown
  profileButton.addEventListener("click", (e) => {
    e.preventDefault();
    e.stopPropagation();
    profileMenu.classList.toggle("hidden");

    // Close language menu when opening profile menu
    if (languageMenu) {
      languageMenu.classList.add("hidden");
    }
  });

  // Close when clicking outside
  document.addEventListener("click", () => {
    profileMenu.classList.add("hidden");
  });

  // Prevent menu from closing when clicking inside it
  profileMenu.addEventListener("click", (e) => {
    e.stopPropagation();
  });

  // Prevent mouseleave from closing the menu
  const handleMenuInteraction = () => {
    profileMenu.classList.contains("hidden")
      ? null
      : profileMenu.classList.remove("hidden");
  };

  profileDropdown.addEventListener(
    "mouseenter",
    handleMenuInteraction
  );
  profileMenu.addEventListener("mouseenter", handleMenuInteraction);
}

// Language dropdown toggle
if (languageButton && languageMenu) {
  // Click event for toggling dropdown
  languageButton.addEventListener("click", (e) => {
    e.preventDefault();
    e.stopPropagation();
    languageMenu.classList.toggle("hidden");

    // Close profile menu when opening language menu
    if (profileMenu) {
      profileMenu.classList.add("hidden");
    }
  });

  // Close when clicking outside
  document.addEventListener("click", () => {
    languageMenu.classList.add("hidden");
  });

  // Prevent closing when clicking the menu itself
  languageMenu.addEventListener("click", (e) => {
    e.stopPropagation();
  });
}

// Notification icons animation
const notificationIcons = document.querySelectorAll(
  ".notification-icon"
);
notificationIcons.forEach((icon) => {
  icon.addEventListener("click", (e) => {
    e.preventDefault();

    // Add pulse animation class
    icon.classList.add("animate-pulse");

    // Remove after animation completes
    setTimeout(() => {
      icon.classList.remove("animate-pulse");
    }, 1000);
  });
});

// Auto-collapse sidebar on small screens
function checkScreenSize() {
  if (!sidebar || !mainContent) return;

  if (window.innerWidth <= 992) {
    // Only collapse on small screens if it's not already opened by user
    if (!localStorage.getItem("sidebar-opened-by-user")) {
      updateSidebarState(true);
    }
  } else {
    // On desktop, respect the last state set by the user
    const savedState = localStorage.getItem("sidebar-collapsed");
    if (savedState !== null) {
      updateSidebarState(savedState === "true");
    } else {
      // Default to collapsed if no saved state
      updateSidebarState(true);
    }
  }
}

// Add smooth transitions to card elements
function animateCards() {
  // Add staggered animation to cards
  const cards = document.querySelectorAll(".dashboard .rounded-xl");

  cards.forEach((card, index) => {
    card.style.opacity = "0";
    card.style.transform = "translateY(20px)";

    setTimeout(() => {
      card.style.transition = "all 0.4s ease";
      card.style.opacity = "1";
      card.style.transform = "translateY(0)";
    }, 100 + index * 50);
  });
}

// Set active menu item based on current page
function setActiveMenuItem() {
  const currentPath = window.location.pathname;
  const menuLinks = document.querySelectorAll(".sidebar-link");

  menuLinks.forEach((link) => {
    const href = link.getAttribute("href");
    if (
      href &&
      href !== "#" &&
      (href === currentPath || currentPath.startsWith(href))
    ) {
      const item = link.closest(".sidebar-item");
      item.classList.add("active");

      // If it's a submenu item, expand parent menu
      const parentSubmenu = link.closest(".sidebar-submenu");
      if (parentSubmenu) {
        const parentItem = parentSubmenu.closest(".sidebar-item");
        parentItem.classList.add("active");
        parentSubmenu.style.maxHeight =
          parentSubmenu.scrollHeight + "px";
      }
    }
  });
}

// Initialize
document.addEventListener("DOMContentLoaded", function () {
  // Check if there is a saved state
  const savedState = localStorage.getItem("sidebar-collapsed");

  // Always start in collapsed mode if there's no saved state
  if (savedState === null) {
    updateSidebarState(true);
  } else {
    // Otherwise respect the saved state
    updateSidebarState(savedState === "true");
  }

  // Initialize components
  animateCards();
  setActiveMenuItem();
  checkScreenSize();

  // Check window resize
  window.addEventListener("resize", checkScreenSize);
});

// Focus effect on search input
if (searchInput) {
  searchInput.addEventListener("focus", () => {
    searchInput.parentElement.classList.add("focused");
  });

  searchInput.addEventListener("blur", () => {
    searchInput.parentElement.classList.remove("focused");
  });
}

// Add CSS to support animations and hover behavior
const style = document.createElement("style");
style.textContent = `
.icon-pulse {
    animation: iconPulse 0.6s ease;
}

@keyframes iconPulse {
    0% { transform: scale(1); }
    50% { transform: scale(1.2); }
    100% { transform: scale(1); }
}

.search-box.focused input {
    background-color: white;
    box-shadow: 0 0 0 2px rgba(91, 33, 182, 0.2);
}

.profile-dropdown .dropdown-menu {
    pointer-events: auto;
}

.language-dropdown .language-menu {
    pointer-events: auto;
}

/* Ensure element level styles for sidebar */
#sidebar {
    transition: width 0.3s ease;
}

#sidebar.collapsed {
    width: var(--sidebar-collapsed-width) !important;
}

/* Special hover styles with high priority */
#sidebar:hover {
    width: 250px !important;
}

#sidebar:hover .sidebar-header h3,
#sidebar:hover .sidebar-link span,
#sidebar:hover .dropdown-icon {
    opacity: 1 !important;
    visibility: visible !important;
    transition: opacity 0.1s ease-in !important;
}

/* Hide elements in collapsed state */
.sidebar.collapsed .sidebar-header h3,
.sidebar.collapsed .sidebar-link span,
.sidebar.collapsed .dropdown-icon {
    opacity: 0 !important;
    visibility: hidden !important;
    transition: opacity 0.2s, visibility 0.2s;
}
`;
document.head.appendChild(style);

// Add event listener for hover on the sidebar
if (sidebar) {
  sidebar.addEventListener("mouseenter", function () {
    // Force opacity on text elements
    const textElements = sidebar.querySelectorAll(
      ".sidebar-header h3, .sidebar-link span, .dropdown-icon"
    );
    textElements.forEach((el) => {
      el.style.opacity = "1";
      el.style.visibility = "visible";
    });
  });

  sidebar.addEventListener("mouseleave", function () {
    if (sidebar.classList.contains("collapsed")) {
      // Hide text elements again when mouse leaves
      const textElements = sidebar.querySelectorAll(
        ".sidebar-header h3, .sidebar-link span, .dropdown-icon"
      );
      textElements.forEach((el) => {
        el.style.opacity = "0";
        el.style.visibility = "hidden";
      });
    }
  });
}

// ==================== SWEETALERT2 HELPER ====================
// Global SweetAlert2 helper with beautiful custom styling

window.SwalHelper = {
  // Default configuration
  defaultConfig: {
    customClass: {
      popup: "swal-custom-popup",
      title: "swal-custom-title",
      content: "swal-custom-content",
      confirmButton: "swal-custom-confirm",
      cancelButton: "swal-custom-cancel",
      denyButton: "swal-custom-deny",
    },
    buttonsStyling: false,
    showClass: {
      popup: "animate__animated animate__fadeInDown animate__faster",
    },
    hideClass: {
      popup: "animate__animated animate__fadeOutUp animate__faster",
    },
  },

  // Success alert
  success: function (title, text = "", options = {}) {
    return Swal.fire({
      ...this.defaultConfig,
      icon: "success",
      title: title,
      text: text,
      confirmButtonText: "Tamam",
      iconColor: "#10b981",
      ...options,
    });
  },

  // Error alert
  error: function (title, text = "", options = {}) {
    return Swal.fire({
      ...this.defaultConfig,
      icon: "error",
      title: title,
      text: text,
      confirmButtonText: "Tamam",
      iconColor: "#ef4444",
      ...options,
    });
  },

  // Warning alert
  warning: function (title, text = "", options = {}) {
    return Swal.fire({
      ...this.defaultConfig,
      icon: "warning",
      title: title,
      text: text,
      confirmButtonText: "Tamam",
      iconColor: "#f59e0b",
      ...options,
    });
  },

  // Info alert
  info: function (title, text = "", options = {}) {
    return Swal.fire({
      ...this.defaultConfig,
      icon: "info",
      title: title,
      text: text,
      confirmButtonText: "Tamam",
      iconColor: "#3b82f6",
      ...options,
    });
  },

  // Confirmation dialog
  confirm: function (title, text = "", options = {}) {
    return Swal.fire({
      ...this.defaultConfig,
      icon: "question",
      title: title,
      text: text,
      showCancelButton: true,
      confirmButtonText: "Evet",
      cancelButtonText: "Hayır",
      iconColor: "#8b5cf6",
      focusCancel: true,
      reverseButtons: true,
      ...options,
    });
  },

  // Delete confirmation with custom styling
  confirmDelete: function (
    title = "Bu öğeyi silmek istediğinizden emin misiniz?",
    text = "Bu işlem geri alınamaz!",
    options = {}
  ) {
    return Swal.fire({
      ...this.defaultConfig,
      icon: "warning",
      title: title,
      text: text,
      showCancelButton: true,
      confirmButtonText: '<i class="fas fa-trash mr-2"></i>Evet, Sil',
      cancelButtonText: '<i class="fas fa-times mr-2"></i>İptal',
      iconColor: "#ef4444",
      focusCancel: true,
      reverseButtons: true,
      customClass: {
        ...this.defaultConfig.customClass,
        confirmButton: "swal-custom-confirm swal-delete-confirm",
        cancelButton: "swal-custom-cancel",
      },
      ...options,
    });
  },

  // Loading/Processing dialog
  loading: function (
    title = "İşleniyor...",
    text = "Lütfen bekleyin"
  ) {
    return Swal.fire({
      ...this.defaultConfig,
      title: title,
      text: text,
      allowOutsideClick: false,
      allowEscapeKey: false,
      showConfirmButton: false,
      didOpen: () => {
        Swal.showLoading();
      },
    });
  },

  // Toast notification
  toast: function (title, icon = "success", position = "top-end") {
    return Swal.fire({
      toast: true,
      position: position,
      icon: icon,
      title: title,
      showConfirmButton: false,
      showCloseButton: false,
      backdrop: false,
      timer: 3000,
      timerProgressBar: true,
      customClass: {
        popup: "swal-toast-popup",
      },
      didOpen: (toast) => {
        toast.addEventListener("mouseenter", Swal.stopTimer);
        toast.addEventListener("mouseleave", Swal.resumeTimer);
      },
    });
  },
};

// Add custom CSS for SweetAlert2
const swalStyle = document.createElement("style");
swalStyle.textContent = `
/* SweetAlert2 Custom Styles */
.swal-custom-popup {
  border-radius: 16px !important;
  box-shadow: 0 25px 50px -12px rgba(0, 0, 0, 0.25) !important;
  border: 1px solid rgba(226, 232, 240, 0.8) !important;
  font-family: 'Inter', sans-serif !important;
}

.swal-custom-title {
  font-size: 1.5rem !important;
  font-weight: 600 !important;
  color: #1e293b !important;
  margin-bottom: 0.5rem !important;
}

.swal-custom-content {
  font-size: 0.95rem !important;
  color: #64748b !important;
  line-height: 1.6 !important;
}

.swal-custom-confirm {
  background: linear-gradient(135deg, #8b5cf6 0%, #7c3aed 100%) !important;
  color: white !important;
  border: none !important;
  border-radius: 10px !important;
  padding: 12px 24px !important;
  font-weight: 500 !important;
  font-size: 0.9rem !important;
  transition: all 0.2s ease !important;
  box-shadow: 0 4px 12px rgba(139, 92, 246, 0.3) !important;
}

.swal-custom-confirm:hover {
  transform: translateY(-1px) !important;
  box-shadow: 0 6px 16px rgba(139, 92, 246, 0.4) !important;
}

.swal-delete-confirm {
  background: linear-gradient(135deg, #ef4444 0%, #dc2626 100%) !important;
  box-shadow: 0 4px 12px rgba(239, 68, 68, 0.3) !important;
}

.swal-delete-confirm:hover {
  box-shadow: 0 6px 16px rgba(239, 68, 68, 0.4) !important;
}

.swal-custom-cancel {
  background: #f8fafc !important;
  color: #64748b !important;
  border: 1px solid #e2e8f0 !important;
  border-radius: 10px !important;
  padding: 12px 24px !important;
  font-weight: 500 !important;
  font-size: 0.9rem !important;
  transition: all 0.2s ease !important;
  margin-right: 8px !important;
}

.swal-custom-cancel:hover {
  background: #e2e8f0 !important;
  color: #475569 !important;
  transform: translateY(-1px) !important;
}

.swal-custom-deny {
  background: linear-gradient(135deg, #ef4444 0%, #dc2626 100%) !important;
  color: white !important;
  border: none !important;
  border-radius: 10px !important;
  padding: 12px 24px !important;
  font-weight: 500 !important;
  font-size: 0.9rem !important;
  transition: all 0.2s ease !important;
  box-shadow: 0 4px 12px rgba(239, 68, 68, 0.3) !important;
}

.swal-custom-deny:hover {
  transform: translateY(-1px) !important;
  box-shadow: 0 6px 16px rgba(239, 68, 68, 0.4) !important;
}

/* Toast styles */
.swal-toast-popup {
  border-radius: 12px !important;
  box-shadow: 0 10px 25px -5px rgba(0, 0, 0, 0.1), 0 10px 10px -5px rgba(0, 0, 0, 0.04) !important;
  border: 1px solid rgba(226, 232, 240, 0.8) !important;
}

/* Icon animations */
.swal2-icon {
  border: none !important;
}

.swal2-icon.swal2-success {
  border-color: #10b981 !important;
  color: #10b981 !important;
}

.swal2-icon.swal2-error {
  border-color: #ef4444 !important;
  color: #ef4444 !important;
}

.swal2-icon.swal2-warning {
  border-color: #f59e0b !important;
  color: #f59e0b !important;
}

.swal2-icon.swal2-info {
  border-color: #3b82f6 !important;
  color: #3b82f6 !important;
}

.swal2-icon.swal2-question {
  border-color: #8b5cf6 !important;
  color: #8b5cf6 !important;
}

/* Loading spinner */
.swal2-loader {
  border-color: #8b5cf6 transparent #8b5cf6 transparent !important;
}

/* Progress bar */
.swal2-timer-progress-bar {
  background: linear-gradient(135deg, #8b5cf6 0%, #7c3aed 100%) !important;
}

/* Backdrop */
.swal2-backdrop-show {
  background: rgba(0, 0, 0, 0.4) !important;
  backdrop-filter: blur(4px) !important;
}

/* Animation classes (requires animate.css or custom animations) */
@keyframes fadeInDown {
  from {
    opacity: 0;
    transform: translate3d(0, -100%, 0);
  }
  to {
    opacity: 1;
    transform: translate3d(0, 0, 0);
  }
}

@keyframes fadeOutUp {
  from {
    opacity: 1;
  }
  to {
    opacity: 0;
    transform: translate3d(0, -100%, 0);
  }
}

.animate__animated {
  animation-duration: 0.3s;
  animation-fill-mode: both;
}

.animate__faster {
  animation-duration: 0.2s;
}

.animate__fadeInDown {
  animation-name: fadeInDown;
}

.animate__fadeOutUp {
  animation-name: fadeOutUp;
}
`;
document.head.appendChild(swalStyle);
