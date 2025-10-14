/**
 * Mega Menü Editörü JavaScript Fonksiyonları
 */

// Global değişkenler
let activeMenuId = null;
let activeMenuData = null;
let menuItems = [];

// DOM yüklendikten sonra başla
document.addEventListener("DOMContentLoaded", function () {
  initializeMenuEditor();
});

/**
 * Menü editörünü başlatan ana fonksiyon
 */
function initializeMenuEditor() {
  // Verileri yükle
  menuItems = typeof headerMenus !== "undefined" ? headerMenus : [];

  // Gerekli olay dinleyicilerini bağla
  bindEventListeners();

  // Menü yapısını oluştur
  loadMenuStructure();

  // İlk yüklemede ilk eleman seçili olsun
  if (menuItems.length > 0) {
    selectMenu(menuItems[0].id);
  }
}

/**
 * Olay dinleyicilerini ekleme
 */
function bindEventListeners() {
  // Menü tipi değiştiğinde
  const menuTypeSelector = document.getElementById(
    "menu-type-selector"
  );
  if (menuTypeSelector) {
    menuTypeSelector.addEventListener("change", function () {
      const selectedType = this.value;
      switchMenuType(selectedType);
    });
  }

  // Menü öğesi ekleme butonu
  const addMenuButton = document.getElementById("add-menu-item");
  if (addMenuButton) {
    addMenuButton.addEventListener("click", addNewMenuItem);
  }

  // Değişiklikleri kaydetme butonu
  const saveButton = document.getElementById("save-menu-changes");
  if (saveButton) {
    saveButton.addEventListener("click", saveMenuChanges);
  }

  // Menü önizleme butonu
  const previewButton = document.getElementById("preview-menu");
  if (previewButton) {
    previewButton.addEventListener("click", generateMenuPreview);
  }

  // Diğer spesifik olay dinleyicileri
  bindMegaMenuEventListeners();
  bindServiceTabsEventListeners();
  bindCategorizedEventListeners();
  bindDropdownEventListeners();
  bindLinkEventListeners();
}

/**
 * Menü yapısını ekranda gösterme
 */
function loadMenuStructure() {
  const menuStructureEl = document.getElementById("menu-structure");
  if (!menuStructureEl) return;

  // Mevcut menü öğelerini işlemeden önce var olan eklenenleri temizle
  // Ancak "Menü Öğesi Ekle" butonunu koru
  const addButton = menuStructureEl.querySelector("#add-menu-item");
  menuStructureEl.innerHTML = "";
  if (addButton) {
    menuStructureEl.appendChild(addButton);
  }

  // Tüm menü öğelerini işle
  menuItems.forEach((menu) => {
    const menuItemEl = document.createElement("div");
    menuItemEl.className =
      "p-3 bg-slate-100 rounded-lg border border-slate-200 mb-2";
    menuItemEl.dataset.menuId = menu.id;

    // Eğer bu aktif seçili olan menüyse farklı stiller ekle
    if (activeMenuId === menu.id) {
      menuItemEl.classList.add("bg-purple-100", "border-purple-300");
    }

    // İçeriği oluştur
    menuItemEl.innerHTML = `
            <div class="flex items-center justify-between">
                <div class="flex items-center">
                    <i class="fas fa-bars text-purple-600 mr-3"></i>
                    <span class="font-medium text-slate-700">${
                      menu.label
                    }</span>
                </div>
                <div class="flex items-center">
                    <span class="px-2 py-1 text-xs bg-${getMenuTypeColor(
                      menu.type
                    )}-100 text-${getMenuTypeColor(
      menu.type
    )}-800 rounded">${menu.type}</span>
                    <button class="delete-menu-item ml-2 p-1 text-red-500 hover:bg-red-50 rounded" data-menu-id="${
                      menu.id
                    }">
                        <i class="fas fa-trash"></i>
                    </button>
                </div>
            </div>
        `;

    // Tıklama olayını ekle - bu menüyü seçmek için
    menuItemEl.addEventListener("click", function (e) {
      // Eğer tıklanan öğe silme butonu değilse
      if (!e.target.closest(".delete-menu-item")) {
        selectMenu(menu.id);
      }
    });

    // Silme butonuna tıklama olayı
    const deleteBtn = menuItemEl.querySelector(".delete-menu-item");
    if (deleteBtn) {
      deleteBtn.addEventListener("click", function (e) {
        e.stopPropagation();
        deleteMenuItem(menu.id);
      });
    }

    // Listeye ekle
    if (addButton) {
      menuStructureEl.insertBefore(menuItemEl, addButton);
    } else {
      menuStructureEl.appendChild(menuItemEl);
    }
  });
}

/**
 * Menü öğesi tipine göre renk döndürme
 */
function getMenuTypeColor(type) {
  switch (type) {
    case "megamenu":
      return "blue";
    case "servicetabs":
      return "indigo";
    case "categorized":
      return "purple";
    case "dropdown":
      return "green";
    case "link":
      return "gray";
    default:
      return "blue";
  }
}

/**
 * Bir menü öğesini seçme
 */
function selectMenu(menuId) {
  // Önceki aktif menüyü kaldır
  activeMenuId = menuId;

  // Menü verisini bul
  activeMenuData = menuItems.find((menu) => menu.id === menuId);

  if (!activeMenuData) {
    console.error("Menü bulunamadı:", menuId);
    return;
  }

  // UI'ı yeniden yükle
  loadMenuStructure(); // Vurgu için menü listesini güncelle
  populateMenuForm(activeMenuData); // Form alanlarını doldur

  // Menü tipini uygun editör görünümüne geçir
  const menuTypeSelector = document.getElementById(
    "menu-type-selector"
  );
  if (menuTypeSelector) {
    menuTypeSelector.value = activeMenuData.type;
    switchMenuType(activeMenuData.type);
  }
}

/**
 * Yeni bir menü öğesi ekleme
 */
function addNewMenuItem() {
  // Benzersiz id oluştur
  const newId = "menu-" + Date.now();

  // Yeni menü öğesi oluştur
  const newMenu = {
    id: newId,
    label: "Yeni Menü",
    type: "link",
    url: "#",
  };

  // Listeye ekle
  menuItems.push(newMenu);

  // UI'ı güncelle
  loadMenuStructure();
  selectMenu(newId);
}

/**
 * Bir menü öğesini silme
 */
function deleteMenuItem(menuId) {
  if (
    confirm("Bu menü öğesini silmek istediğinizden emin misiniz?")
  ) {
    // Veri yapısından kaldır
    menuItems = menuItems.filter((menu) => menu.id !== menuId);

    // UI'ı güncelle
    loadMenuStructure();

    // Eğer silinenle aynı aktif menü varsa, ilk menüyü seç veya boş görünüm göster
    if (activeMenuId === menuId) {
      if (menuItems.length > 0) {
        selectMenu(menuItems[0].id);
      } else {
        activeMenuId = null;
        activeMenuData = null;
        clearMenuForm();
      }
    }
  }
}

/**
 * Menü formunu temizleme
 */
function clearMenuForm() {
  const menuId = document.getElementById("menu-id");
  const menuLabel = document.getElementById("menu-label");
  const menuUrl = document.getElementById("menu-url");

  if (menuId) menuId.value = "";
  if (menuLabel) menuLabel.value = "";
  if (menuUrl) menuUrl.value = "";

  // Tüm editörleri gizle
  hideAllEditors();
}

/**
 * Menü tipine göre editör değiştirme
 */
function switchMenuType(type) {
  hideAllEditors();

  // Seçilen editörü göster
  const editor = document.getElementById(`${type}-editor`);
  if (editor) {
    editor.classList.remove("hidden");
  }

  // Aktif menünün tipini güncelle
  if (activeMenuData) {
    activeMenuData.type = type;
  }
}

/**
 * Tüm editörleri gizleme
 */
function hideAllEditors() {
  const editors = document.querySelectorAll(".menu-type-editor");
  editors.forEach((editor) => {
    editor.classList.add("hidden");
  });
}

/**
 * Menü verisini form alanlarına doldurma
 */
function populateMenuForm(menuData) {
  const menuId = document.getElementById("menu-id");
  const menuLabel = document.getElementById("menu-label");
  const menuUrl = document.getElementById("menu-url");

  if (menuId) menuId.value = menuData.id;
  if (menuLabel) menuLabel.value = menuData.label;
  if (menuUrl) menuUrl.value = menuData.url || "";

  // Menü tipine özel alanları doldur
  switch (menuData.type) {
    case "megamenu":
      populateMegaMenuForm(menuData);
      break;
    case "servicetabs":
      populateServiceTabsForm(menuData);
      break;
    case "categorized":
      populateCategorizedForm(menuData);
      break;
    case "dropdown":
      populateDropdownForm(menuData);
      break;
    case "link":
      populateLinkForm(menuData);
      break;
  }
}

/**
 * Değişiklikleri kaydetme
 */
function saveMenuChanges() {
  if (!activeMenuData) return;

  // Temel menü bilgilerini topla
  const menuId = document.getElementById("menu-id");
  const menuLabel = document.getElementById("menu-label");
  const menuUrl = document.getElementById("menu-url");

  if (menuId) activeMenuData.id = menuId.value;
  if (menuLabel) activeMenuData.label = menuLabel.value;
  if (menuUrl && activeMenuData.type === "link")
    activeMenuData.url = menuUrl.value;

  // Menü tipine özel bilgileri topla
  switch (activeMenuData.type) {
    case "megamenu":
      saveMegaMenuData();
      break;
    case "servicetabs":
      saveServiceTabsData();
      break;
    case "categorized":
      saveCategorizedData();
      break;
    case "dropdown":
      saveDropdownData();
      break;
    case "link":
      saveLinkData();
      break;
  }

  // UI'ı güncelle
  loadMenuStructure();

  // Veriyi bir yere kaydet (API çağrısı vb.) - Demo için sadece konsola yazdırıyoruz
  console.log(
    "Menü yapısı kaydedildi:",
    JSON.stringify(menuItems, null, 2)
  );
  alert("Menü değişiklikleri kaydedildi!");
}

/**
 * Menü önizlemesi oluşturma
 */
function generateMenuPreview() {
  if (!activeMenuData) return;

  const previewEl = document.getElementById("menu-preview");
  if (!previewEl) return;

  // Menü tipine göre uygun önizleme içeriği oluştur
  let previewContent = "";

  switch (activeMenuData.type) {
    case "megamenu":
      previewContent = generateMegaMenuPreview();
      break;
    case "servicetabs":
      previewContent = generateServiceTabsPreview();
      break;
    case "categorized":
      previewContent = generateCategorizedPreview();
      break;
    case "dropdown":
      previewContent = generateDropdownPreview();
      break;
    case "link":
      previewContent = generateLinkPreview();
      break;
    default:
      previewContent = `<div class="text-center text-slate-500 py-4">Önizleme bulunamadı.</div>`;
  }

  previewEl.innerHTML = previewContent;
}

// Diğer menü tipleri için spesifik fonksiyonlar - Basitlik için şimdilik içleri boş
function bindMegaMenuEventListeners() {}
function bindServiceTabsEventListeners() {}
function bindCategorizedEventListeners() {}
function bindDropdownEventListeners() {}
function bindLinkEventListeners() {}

function populateMegaMenuForm(menuData) {}
function populateServiceTabsForm(menuData) {}
function populateCategorizedForm(menuData) {}
function populateDropdownForm(menuData) {}
function populateLinkForm(menuData) {}

function saveMegaMenuData() {}
function saveServiceTabsData() {}
function saveCategorizedData() {}
function saveDropdownData() {}
function saveLinkData() {}

function generateMegaMenuPreview() {
  return `<div class="text-center text-slate-500 py-4">
        <h4 class="font-semibold text-purple-800 mb-2">Mega Menü Önizleme</h4>
        <p>Mega menü önizlemesi burada gösterilecek.</p>
    </div>`;
}

function generateServiceTabsPreview() {
  return `<div class="text-center text-slate-500 py-4">
        <h4 class="font-semibold text-indigo-800 mb-2">Servis Sekmeleri Önizleme</h4>
        <p>Servis sekmeleri önizlemesi burada gösterilecek.</p>
    </div>`;
}

function generateCategorizedPreview() {
  return `<div class="text-center text-slate-500 py-4">
        <h4 class="font-semibold text-purple-800 mb-2">Kategorize Menü Önizleme</h4>
        <p>Kategorize menü önizlemesi burada gösterilecek.</p>
    </div>`;
}

function generateDropdownPreview() {
  return `<div class="text-center text-slate-500 py-4">
        <h4 class="font-semibold text-green-800 mb-2">Açılır Menü Önizleme</h4>
        <p>Açılır menü önizlemesi burada gösterilecek.</p>
    </div>`;
}

function generateLinkPreview() {
  return `<div class="text-center text-slate-500 py-4">
        <h4 class="font-semibold text-gray-800 mb-2">Link Önizleme</h4>
        <p>Basit link önizlemesi burada gösterilecek.</p>
    </div>`;
}
