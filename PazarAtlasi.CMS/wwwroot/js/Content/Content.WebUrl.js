// WebUrl CRUD İşlemleri
document.addEventListener("DOMContentLoaded", function () {
  // DOM elementlerini seç
  const createButton = document.getElementById("create-weburl");
  const searchInput = document.getElementById("search-weburl");
  const webUrlList = document.getElementById("weburl-list");

  // Modalları seç
  const createModal = document.getElementById("createWebUrlModal");
  const editModal = document.getElementById("editWebUrlModal");
  const deleteModal = document.getElementById("deleteWebUrlModal");

  // Formları seç
  const createForm = document.getElementById("createWebUrlForm");
  const editForm = document.getElementById("editWebUrlForm");
  const deleteForm = document.getElementById("deleteWebUrlForm");

  // Modal kapatma butonları
  const closeButtons = document.querySelectorAll(".close-modal");

  // API endpoint'leri
  const API_ENDPOINTS = {
    getAll: "/api/weburl",
    getById: "/api/weburl/",
    create: "/api/weburl",
    update: "/api/weburl/",
    delete: "/api/weburl/",
    getMenuStructure: "/api/menu/structure", // Menü yapısını almak için
    updateMenuUrl: "/api/menu/update-url", // Menü URL'sini güncellemek için
  };

  // Sayfalama değişkenleri
  let currentPage = 1;
  let totalPages = 1;
  let pageSize = 10;

  // WebURL verileri için cache
  let webUrlData = [];

  // Menü yapısı verisi
  let menuStructure = [];

  // Sayfayı yükle
  loadWebUrls();
  loadMenuStructure();

  // Modal aç-kapa işlemleri
  function openModal(modal) {
    modal.classList.remove("hidden");
    document.body.classList.add("overflow-hidden");
  }

  function closeModal(modal) {
    modal.classList.add("hidden");
    document.body.classList.remove("overflow-hidden");
  }

  closeButtons.forEach((button) => {
    button.addEventListener("click", function () {
      const modal = this.closest('[id$="Modal"]');
      closeModal(modal);
    });
  });

  // Yeni WebURL oluşturma modalını aç
  createButton.addEventListener("click", function () {
    // Form alanlarını temizle
    createForm.reset();
    // Mevcut menü ID'lerini select dropdown'a ekle
    populateMenuIdDropdown(
      document.getElementById("menu-id-select"),
      null
    );
    // Modalı aç
    openModal(createModal);
  });

  // Menü yapısını yükle
  function loadMenuStructure() {
    // API isteği (örnek olarak mocklanmış veri)
    // fetch(API_ENDPOINTS.getMenuStructure)

    // Mock veri - headerMenus örneğinden
    setTimeout(() => {
      menuStructure = [
        {
          id: "about",
          label: "Hakkımızda",
          type: "megamenu",
          url: "/hakkimizda",
        },
        {
          id: "services",
          label: "Hizmetlerimiz",
          type: "servicetabs",
          url: "/hizmetlerimiz",
        },
        {
          id: "solutions",
          label: "Çözümlerimiz",
          type: "categorized",
          url: "/cozumlerimiz",
        },
        {
          id: "blog",
          label: "Blog",
          type: "megamenu",
          url: "/blog",
        },
        {
          id: "datacenter",
          label: "Veri Merkezi",
          type: "link",
          url: "/system-status",
        },
        {
          id: "contact",
          label: "İletişim",
          type: "dropdown",
          url: "/iletisim",
        },
      ];
    }, 300);
  }

  // Menü ID'lerini dropdown'a ekle
  function populateMenuIdDropdown(selectElement, selectedId) {
    if (!selectElement) return;

    // Önceki seçenekleri temizle
    selectElement.innerHTML =
      '<option value="">Seçiniz (Menü ile ilişkilendirme için)</option>';

    // Menü yapısından ID'leri ve etiketleri ekle
    menuStructure.forEach((menu) => {
      const option = document.createElement("option");
      option.value = menu.id;
      option.textContent = `${menu.label} (${menu.type})`;
      if (selectedId && menu.id === selectedId) {
        option.selected = true;
      }
      selectElement.appendChild(option);
    });
  }

  // WebURL listesini yükle
  function loadWebUrls(page = 1, search = "") {
    currentPage = page;

    // API isteği (örnek olarak mocklanmış veri)
    // Gerçek uygulamada fetch ile API çağrısı yapılacak
    // fetch(`${API_ENDPOINTS.getAll}?page=${page}&pageSize=${pageSize}&search=${search}`)

    // Mock veri
    setTimeout(() => {
      webUrlData = [
        {
          id: 1,
          name: "Ana Sayfa",
          url: "/",
          controller: "Home",
          action: "Index",
          description: "Ana sayfa linki",
          template: "Homepage",
          status: 1,
          menuId: null,
        },
        {
          id: 2,
          name: "Hakkımızda",
          url: "/hakkimizda",
          controller: "Home",
          action: "About",
          description: "Şirket hakkında bilgiler",
          template: "Default",
          status: 1,
          menuId: "about",
        },
        {
          id: 3,
          name: "Hizmetlerimiz",
          url: "/hizmetlerimiz",
          controller: "Home",
          action: "Services",
          description: "Hizmetlerimiz sayfası",
          template: "Default",
          status: 1,
          menuId: "services",
        },
        {
          id: 4,
          name: "Çözümlerimiz",
          url: "/cozumlerimiz",
          controller: "Home",
          action: "Solutions",
          description: "Çözümlerimiz sayfası",
          template: "Default",
          status: 1,
          menuId: "solutions",
        },
        {
          id: 5,
          name: "Blog",
          url: "/blog",
          controller: "Blog",
          action: "Index",
          description: "Blog ana sayfası",
          template: "BlogIndex",
          status: 1,
          menuId: "blog",
        },
        {
          id: 6,
          name: "Veri Merkezi",
          url: "/system-status",
          controller: "System",
          action: "Status",
          description: "Sistem durumu sayfası",
          template: "SystemStatus",
          status: 1,
          menuId: "datacenter",
        },
        {
          id: 7,
          name: "İletişim",
          url: "/iletisim",
          controller: "Home",
          action: "Contact",
          description: "İletişim bilgileri",
          template: "ContactPage",
          status: 1,
          menuId: "contact",
        },
      ];

      // Arama filtrelemesi
      if (search) {
        webUrlData = webUrlData.filter(
          (item) =>
            item.name.toLowerCase().includes(search.toLowerCase()) ||
            item.url.toLowerCase().includes(search.toLowerCase()) ||
            (item.menuId &&
              item.menuId
                .toLowerCase()
                .includes(search.toLowerCase()))
        );
      }

      renderWebUrls(webUrlData);

      // Sayfalama hesapla
      totalPages = Math.ceil(webUrlData.length / pageSize);
      updatePagination();
    }, 300);
  }

  // WebURL listesini render et
  function renderWebUrls(data) {
    // Tablo içeriğini temizle
    webUrlList.innerHTML = "";

    if (data.length === 0) {
      const emptyRow = document.createElement("tr");
      emptyRow.innerHTML = `
                <td colspan="7" class="px-6 py-4 text-center text-slate-500">
                    Kayıt bulunamadı
                </td>
            `;
      webUrlList.appendChild(emptyRow);
      document.getElementById("total-rows").textContent = 0;
      return;
    }

    // Toplam kayıt sayısını güncelle
    document.getElementById("total-rows").textContent = data.length;

    // Her kayıt için satır oluştur
    data.forEach((item) => {
      // Menü tipini ve etiketini bul (varsa)
      let menuInfo = { label: "-", type: "-" };
      if (item.menuId) {
        const menuItem = menuStructure.find(
          (m) => m.id === item.menuId
        );
        if (menuItem) {
          menuInfo.label = menuItem.label;
          menuInfo.type = menuItem.type;
        }
      }

      const row = document.createElement("tr");
      row.className = "hover:bg-slate-50";
      row.innerHTML = `
                <td class="px-6 py-4 whitespace-nowrap">
                    <div class="text-sm font-medium text-slate-900">${
                      item.name
                    }</div>
                    <div class="text-xs text-slate-500">${
                      item.description || ""
                    }</div>
                </td>
                <td class="px-6 py-4 whitespace-nowrap">
                    <span class="text-sm text-slate-700">${
                      item.url
                    }</span>
                </td>
                <td class="px-6 py-4 whitespace-nowrap">
                    <span class="text-sm text-slate-700">${
                      item.controller
                    }/${item.action}</span>
                </td>
                <td class="px-6 py-4 whitespace-nowrap">
                    <span class="text-sm text-slate-700">${
                      item.template || "-"
                    }</span>
                </td>
                <td class="px-6 py-4 whitespace-nowrap">
                    ${
                      item.menuId
                        ? `<div class="flex flex-col">
                        <span class="text-sm text-slate-700">${
                          menuInfo.label
                        }</span>
                        <span class="text-xs px-2 py-0.5 rounded-full ${getMenuTypeClass(
                          menuInfo.type
                        )}">${menuInfo.type}</span>
                      </div>`
                        : '<span class="text-xs text-slate-500">İlişkilendirilmemiş</span>'
                    }
                </td>
                <td class="px-6 py-4 whitespace-nowrap">
                    <span class="px-2 py-1 text-xs font-medium rounded-full ${
                      item.status
                        ? "bg-green-100 text-green-800"
                        : "bg-red-100 text-red-800"
                    }">
                        ${item.status ? "Aktif" : "Pasif"}
                    </span>
                </td>
                <td class="px-6 py-4 whitespace-nowrap text-right text-sm">
                    <button class="text-indigo-600 hover:text-indigo-900 mr-3" data-action="edit" data-id="${
                      item.id
                    }">
                        <i class="fas fa-edit"></i>
                    </button>
                    <button class="text-red-600 hover:text-red-900" data-action="delete" data-id="${
                      item.id
                    }">
                        <i class="fas fa-trash-alt"></i>
                    </button>
                </td>
            `;

      webUrlList.appendChild(row);
    });

    // Edit ve delete butonları için event listener ekle
    document
      .querySelectorAll('[data-action="edit"]')
      .forEach((button) => {
        button.addEventListener("click", function () {
          const id = this.getAttribute("data-id");
          editWebUrl(id);
        });
      });

    document
      .querySelectorAll('[data-action="delete"]')
      .forEach((button) => {
        button.addEventListener("click", function () {
          const id = this.getAttribute("data-id");
          deleteWebUrl(id);
        });
      });
  }

  // Menü tipine göre CSS sınıfı döndür
  function getMenuTypeClass(type) {
    switch (type) {
      case "megamenu":
        return "bg-blue-100 text-blue-800";
      case "servicetabs":
        return "bg-indigo-100 text-indigo-800";
      case "categorized":
        return "bg-purple-100 text-purple-800";
      case "dropdown":
        return "bg-amber-100 text-amber-800";
      case "link":
        return "bg-green-100 text-green-800";
      default:
        return "bg-slate-100 text-slate-800";
    }
  }

  // Sayfalamayı güncelle
  function updatePagination() {
    const paginationContainer = document.querySelector(
      ".p-4.border-t .flex.space-x-1"
    );
    if (!paginationContainer) return;

    paginationContainer.innerHTML = "";

    // Önceki sayfa butonu
    const prevButton = document.createElement("button");
    prevButton.className = `p-2 text-sm rounded border border-slate-200 bg-white text-slate-600 hover:bg-slate-50 ${
      currentPage === 1 ? "opacity-50 cursor-not-allowed" : ""
    }`;
    prevButton.innerHTML = '<i class="fas fa-chevron-left"></i>';
    prevButton.disabled = currentPage === 1;
    prevButton.addEventListener("click", () => {
      if (currentPage > 1)
        loadWebUrls(currentPage - 1, searchInput.value);
    });
    paginationContainer.appendChild(prevButton);

    // Sayfa numaraları
    for (let i = 1; i <= totalPages; i++) {
      const pageButton = document.createElement("button");
      pageButton.className = `p-2 text-sm rounded border border-slate-200 ${
        currentPage === i
          ? "bg-purple-700 text-white hover:bg-purple-800"
          : "bg-white text-slate-600 hover:bg-slate-50"
      }`;
      pageButton.textContent = i;
      pageButton.addEventListener("click", () =>
        loadWebUrls(i, searchInput.value)
      );
      paginationContainer.appendChild(pageButton);
    }

    // Sonraki sayfa butonu
    const nextButton = document.createElement("button");
    nextButton.className = `p-2 text-sm rounded border border-slate-200 bg-white text-slate-600 hover:bg-slate-50 ${
      currentPage === totalPages
        ? "opacity-50 cursor-not-allowed"
        : ""
    }`;
    nextButton.innerHTML = '<i class="fas fa-chevron-right"></i>';
    nextButton.disabled = currentPage === totalPages;
    nextButton.addEventListener("click", () => {
      if (currentPage < totalPages)
        loadWebUrls(currentPage + 1, searchInput.value);
    });
    paginationContainer.appendChild(nextButton);
  }

  // Arama işlemi
  if (searchInput) {
    searchInput.addEventListener(
      "input",
      debounce(function () {
        loadWebUrls(1, this.value);
      }, 500)
    );
  }

  // Yeni WebURL oluşturma formu
  if (createForm) {
    createForm.addEventListener("submit", function (e) {
      e.preventDefault();

      const formData = new FormData(this);
      const newWebUrl = {
        name: formData.get("name"),
        url: formData.get("url"),
        controller: formData.get("controller"),
        action: formData.get("action"),
        description: formData.get("description"),
        template: formData.get("template"),
        status: parseInt(formData.get("status")),
        menuId: formData.get("menuId") || null,
      };

      // API isteği (örnek olarak mocklanmış)
      // fetch(API_ENDPOINTS.create, {
      //     method: 'POST',
      //     headers: { 'Content-Type': 'application/json' },
      //     body: JSON.stringify(newWebUrl)
      // })

      // Mock başarılı yanıt
      setTimeout(() => {
        // Menü bağlantısı varsa, ilgili menüyü de güncelle
        if (newWebUrl.menuId) {
          const menuIndex = menuStructure.findIndex(
            (m) => m.id === newWebUrl.menuId
          );
          if (menuIndex !== -1) {
            menuStructure[menuIndex].url = newWebUrl.url;

            // API isteği - Menü URL'sini güncelle
            // fetch(API_ENDPOINTS.updateMenuUrl, {
            //   method: 'PUT',
            //   headers: { 'Content-Type': 'application/json' },
            //   body: JSON.stringify({ menuId: newWebUrl.menuId, url: newWebUrl.url })
            // })
          }
        }

        showToast("URL başarıyla oluşturuldu.", "success");
        closeModal(createModal);
        loadWebUrls();
      }, 500);
    });
  }

  // WebURL düzenleme
  function editWebUrl(id) {
    // API isteği (örnek olarak mock veri)
    // fetch(`${API_ENDPOINTS.getById}${id}`)

    // Mock veri - gerçek uygulamada API'dan gelecek
    const webUrl = webUrlData.find((item) => item.id == id);

    if (webUrl) {
      // Form alanlarını doldur
      document.getElementById("edit-id").value = webUrl.id;
      document.getElementById("edit-name").value = webUrl.name;
      document.getElementById("edit-url").value = webUrl.url;
      document.getElementById("edit-controller").value =
        webUrl.controller;
      document.getElementById("edit-action").value = webUrl.action;
      document.getElementById("edit-description").value =
        webUrl.description;
      document.getElementById("edit-template").value =
        webUrl.template;

      // Menü ID dropdown'ı doldur
      if (document.getElementById("edit-menu-id")) {
        populateMenuIdDropdown(
          document.getElementById("edit-menu-id"),
          webUrl.menuId
        );
      }

      if (webUrl.status === 1) {
        document.getElementById("edit-status-active").checked = true;
      } else {
        document.getElementById(
          "edit-status-inactive"
        ).checked = true;
      }

      // Modalı aç
      openModal(editModal);
    }
  }

  // WebURL güncelleme formu
  if (editForm) {
    editForm.addEventListener("submit", function (e) {
      e.preventDefault();

      const formData = new FormData(this);
      const id = formData.get("id");
      const previousUrl =
        webUrlData.find((item) => item.id == id)?.url || "";
      const updatedWebUrl = {
        id: id,
        name: formData.get("name"),
        url: formData.get("url"),
        controller: formData.get("controller"),
        action: formData.get("action"),
        description: formData.get("description"),
        template: formData.get("template"),
        status: parseInt(formData.get("status")),
        menuId: formData.get("menuId") || null,
      };

      // API isteği (örnek olarak mocklanmış)
      // fetch(`${API_ENDPOINTS.update}${id}`, {
      //     method: 'PUT',
      //     headers: { 'Content-Type': 'application/json' },
      //     body: JSON.stringify(updatedWebUrl)
      // })

      // Mock başarılı yanıt
      setTimeout(() => {
        // URL değiştiyse ve menü bağlantısı varsa, ilgili menüyü de güncelle
        if (
          updatedWebUrl.url !== previousUrl &&
          updatedWebUrl.menuId
        ) {
          const menuIndex = menuStructure.findIndex(
            (m) => m.id === updatedWebUrl.menuId
          );
          if (menuIndex !== -1) {
            menuStructure[menuIndex].url = updatedWebUrl.url;

            // API isteği - Menü URL'sini güncelle
            // fetch(API_ENDPOINTS.updateMenuUrl, {
            //   method: 'PUT',
            //   headers: { 'Content-Type': 'application/json' },
            //   body: JSON.stringify({ menuId: updatedWebUrl.menuId, url: updatedWebUrl.url })
            // })
          }
        }

        showToast("URL başarıyla güncellendi.", "success");
        closeModal(editModal);
        loadWebUrls();
      }, 500);
    });
  }

  // WebURL silme
  function deleteWebUrl(id) {
    // Silinecek WebURL bilgilerini bul
    const webUrl = webUrlData.find((item) => item.id == id);

    if (webUrl) {
      // Silme modalında bilgileri göster
      document.getElementById("delete-id").value = webUrl.id;
      document.getElementById("delete-name").textContent =
        webUrl.name;
      document.getElementById("delete-url").textContent = webUrl.url;

      // Menü bağlantısı varsa uyarı göster
      const deleteWarning = document.getElementById(
        "delete-menu-warning"
      );
      if (deleteWarning) {
        if (webUrl.menuId) {
          const menuItem = menuStructure.find(
            (m) => m.id === webUrl.menuId
          );
          deleteWarning.innerHTML = `
            <div class="bg-red-50 p-3 rounded-lg text-red-700 text-sm mb-3">
              <i class="fas fa-exclamation-circle mr-2"></i>
              Bu URL <strong>${
                menuItem ? menuItem.label : webUrl.menuId
              }</strong> menüsüyle ilişkilendirilmiş.
              Silme işlemi menü ilişkisini kaldıracaktır.
            </div>
          `;
          deleteWarning.classList.remove("hidden");
        } else {
          deleteWarning.classList.add("hidden");
        }
      }

      // Modalı aç
      openModal(deleteModal);
    }
  }

  // WebURL silme formu
  if (deleteForm) {
    deleteForm.addEventListener("submit", function (e) {
      e.preventDefault();

      const id = document.getElementById("delete-id").value;
      const webUrl = webUrlData.find((item) => item.id == id);

      // API isteği (örnek olarak mocklanmış)
      // fetch(`${API_ENDPOINTS.delete}${id}`, {
      //     method: 'DELETE'
      // })

      // Mock başarılı yanıt
      setTimeout(() => {
        // Menü bağlantısı varsa, menüdeki URL referansını kaldır
        if (webUrl && webUrl.menuId) {
          const menuIndex = menuStructure.findIndex(
            (m) => m.id === webUrl.menuId
          );
          if (menuIndex !== -1) {
            menuStructure[menuIndex].url = "#";

            // API isteği - Menü URL'sini güncelle
            // fetch(API_ENDPOINTS.updateMenuUrl, {
            //   method: 'PUT',
            //   headers: { 'Content-Type': 'application/json' },
            //   body: JSON.stringify({ menuId: webUrl.menuId, url: "#" })
            // })
          }
        }

        showToast("URL başarıyla silindi.", "success");
        closeModal(deleteModal);
        loadWebUrls();
      }, 500);
    });
  }

  // Toast mesajı göster
  function showToast(message, type = "info") {
    // Toast container oluştur (yoksa)
    let toastContainer = document.getElementById("toast-container");

    if (!toastContainer) {
      toastContainer = document.createElement("div");
      toastContainer.id = "toast-container";
      toastContainer.className =
        "fixed top-4 right-4 z-50 flex flex-col items-end space-y-2";
      document.body.appendChild(toastContainer);
    }

    // Toast mesajı oluştur
    const toast = document.createElement("div");
    toast.className = `p-3 rounded-lg shadow-lg flex items-center max-w-md transform transition-all duration-300 translate-x-full`;

    // Toast tipine göre stil ekle
    switch (type) {
      case "success":
        toast.classList.add("bg-green-500", "text-white");
        break;
      case "error":
        toast.classList.add("bg-red-500", "text-white");
        break;
      case "warning":
        toast.classList.add("bg-amber-500", "text-white");
        break;
      default:
        toast.classList.add("bg-blue-500", "text-white");
    }

    // Toast içeriği
    toast.innerHTML = `
            <div class="mr-2">
                <i class="fas ${
                  type === "success"
                    ? "fa-check-circle"
                    : type === "error"
                    ? "fa-times-circle"
                    : type === "warning"
                    ? "fa-exclamation-triangle"
                    : "fa-info-circle"
                }"></i>
            </div>
            <div>${message}</div>
        `;

    // Toastı containera ekle
    toastContainer.appendChild(toast);

    // Animasyon için bekle
    setTimeout(() => {
      toast.classList.remove("translate-x-full");
    }, 10);

    // Toastı belirli süre sonra kaldır
    setTimeout(() => {
      toast.classList.add("translate-x-full", "opacity-0");
      setTimeout(() => {
        toast.remove();
        // Container boşsa container'ı kaldır
        if (toastContainer.children.length === 0) {
          toastContainer.remove();
        }
      }, 300);
    }, 3000);
  }

  // Debounce yardımcı fonksiyonu
  function debounce(func, delay) {
    let timeout;
    return function () {
      const context = this;
      const args = arguments;
      clearTimeout(timeout);
      timeout = setTimeout(() => func.apply(context, args), delay);
    };
  }
});
