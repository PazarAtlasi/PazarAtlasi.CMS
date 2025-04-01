// Menu Data Structure
const headerMenus = [
  {
    id: "about",
    label: "Hakkımızda",
    type: "megamenu",
    content: {
      description: {
        title: "Biz Kimiz?",
        text: "Yazılım geliştirme, DevOps ve bulut çözümleri alanında uzmanlaşmış güvenilir teknoloji ortağınız.",
        linkText: "Daha fazla bilgi",
        linkUrl: "#",
      },
      quickLinks: {
        title: "Hızlı Erişim",
        links: [
          { text: "Misyon & Vizyon", url: "#" },
          { text: "Ekibimiz", url: "#" },
          { text: "Kariyer", url: "#" },
          { text: "Basın Odası", url: "#" },
        ],
      },
      features: {
        title: "Neden sentinelit.net?",
        items: [
          {
            title: "10+ Yıllık Deneyim",
            description: "Sektörde uzun yıllara dayanan tecrübe",
          },
          {
            title: "Microsoft ve AWS Sertifikalı Ekip",
            description: "Uzman ve sertifikalı mühendisler",
          },
          {
            title: "200+ Başarılı Proje",
            description: "Tamamlanan projelerle kanıtlanmış başarı",
          },
        ],
      },
    },
  },
  {
    id: "services",
    label: "Hizmetlerimiz",
    type: "servicetabs",
    tabs: [
      {
        id: "managed",
        label: "Managed Services",
        icon: "server",
      },
      {
        id: "cloud",
        label: "Cloud Solutions",
        icon: "cloud",
      },
      {
        id: "security",
        label: "Security Services",
        icon: "shield",
      },
      {
        id: "database",
        label: "Database Management",
        icon: "database",
      },
      {
        id: "monitoring",
        label: "Monitoring & Optimization",
        icon: "activity",
      },
      {
        id: "premium",
        label: "Premium Consulting",
        icon: "zap",
        isPremium: true,
      },
    ],
    tabContent: {
      managed: [
        {
          id: "multi-cloud",
          title: "Multi-Cloud Management",
          icon: "cloud",
          description:
            "Bulut uzmanlarımızla çoklu bulut stratejilerinizi hızlandırın.",
        },
        {
          id: "hybrid-cloud",
          title: "Hybrid-Cloud Management",
          icon: "refresh-cw",
          description:
            "DevOps ve NetOps ekipleriniz için çalışmayı sorunsuz hale getirin.",
        },
        {
          id: "monitoring",
          title: "Monitoring Management",
          icon: "monitor",
          description:
            "Buluttaki performansınızı gerçek zamanlı izleyin.",
        },
        {
          id: "container",
          title: "Container Management",
          icon: "cpu",
          description:
            "Mevcut iş akışlarını modernleştirin, uygulama dağıtımını hızlandırın.",
        },
      ],
      cloud: [
        {
          id: "public-cloud",
          title: "Public Cloud Management",
          icon: "globe",
          description:
            "Her işletme için yönetilebilen bulut çözümlerinden yararlanın.",
        },
        {
          id: "cloud-migration",
          title: "Cloud Migration",
          icon: "refresh-cw",
          description:
            "Buluta güvenli ve kesintisiz bir şekilde geçiş yapın.",
        },
        {
          id: "cloud-optimization",
          title: "Cloud Optimization",
          icon: "pie-chart",
          description:
            "Cloud optimizasyon ile kurumsal verimliliğinizi arttırın.",
        },
        {
          id: "cloud-consulting",
          title: "Cloud Consulting",
          icon: "cloud",
          description:
            "En iyilerin tercihi Bulutistan ile işletmenizi buluta taşıyın!",
        },
      ],
      security: [
        {
          id: "cloud-security",
          title: "Cloud Security",
          icon: "shield",
          description:
            "Riski azaltın ve güvenlik yatırımlarınızı en üst düzeye çıkarın.",
        },
        {
          id: "zero-trust",
          title: "Zero Trust Security",
          icon: "shield",
          description:
            "Kimlik doğrulama ve yetkilendirme süreçlerini güçlendirin.",
        },
        {
          id: "managed-security",
          title: "Managed Security Service",
          icon: "shield",
          description:
            "Uçtan uca güvenlik hizmetleri ile işletmenizi koruyun.",
        },
        {
          id: "data-protection",
          title: "Sensitive Data Discovery & Protection",
          icon: "search",
          description: "Hassas verileri tespit edin ve koruyun.",
        },
      ],
      database: [
        {
          id: "database-management",
          title: "Database Management",
          icon: "database",
          description:
            "Doğru veri tabanı yönetim stratejisi ile kurumsal büyüme sağlayın.",
        },
        {
          id: "data-migration",
          title: "Database Migration",
          icon: "refresh-cw",
          description:
            "Veritabanlarınızı sorunsuz bir şekilde taşıyın ve modernleştirin.",
        },
        {
          id: "db-performance",
          title: "Database Performance Tuning",
          icon: "activity",
          description:
            "Veritabanı performansınızı optimize edin ve maliyetleri düşürün.",
        },
        {
          id: "backup-recovery",
          title: "Backup & Recovery",
          icon: "refresh-cw",
          description:
            "Veri kaybı riskini azaltın ve hızlı kurtarma çözümleri edinin.",
        },
      ],
      monitoring: [
        {
          id: "performance-monitoring",
          title: "Performance Monitoring",
          icon: "activity",
          description:
            "Sistem performansınızı 7/24 izleyin ve sorunları önceden tespit edin.",
        },
        {
          id: "system-health",
          title: "System Health Check",
          icon: "activity",
          description:
            "Sistemlerinizin sağlık durumunu düzenli olarak kontrol edin.",
        },
        {
          id: "cost-optimization",
          title: "Cost Optimization",
          icon: "pie-chart",
          description:
            "Bulut maliyetlerinizi optimize edin ve gereksiz harcamaları azaltın.",
        },
        {
          id: "capacity-planning",
          title: "Capacity Planning",
          icon: "pie-chart",
          description:
            "Gelecekteki ihtiyaçlarınızı planlamak için kapasite analizleri yapın.",
        },
      ],
      premium: [
        {
          id: "premium-consulting",
          title: "Premium Consulting",
          icon: "zap",
          description:
            "Üst düzey danışmanlık ile dijital dönüşümünüzü hızlandırın.",
        },
        {
          id: "cto-as-service",
          title: "CTO as a Service",
          icon: "zap",
          description:
            "Uzman CTO hizmetimizle teknoloji stratejinizi güçlendirin.",
        },
        {
          id: "digital-transformation",
          title: "Digital Transformation",
          icon: "refresh-cw",
          description:
            "Dijital dönüşüm sürecinizi profesyonellerle yönetin.",
        },
        {
          id: "strategic-planning",
          title: "Strategic IT Planning",
          icon: "pie-chart",
          description:
            "Uzun vadeli teknoloji planlaması için stratejik destek alın.",
        },
      ],
    },
  },
  {
    id: "solutions",
    label: "Çözümlerimiz",
    type: "categorized",
    categories: [
      {
        id: "software",
        label: "Yazılım Geliştirme",
        icon: "code",
      },
      {
        id: "devops",
        label: "DevOps",
        icon: "server",
      },
      {
        id: "hosting",
        label: "Hosting Çözümleri",
        icon: "database",
      },
      {
        id: "cloud",
        label: "Bulut Desteği",
        icon: "cloud",
      },
      {
        id: "security",
        label: "Güvenlik Çözümleri",
        icon: "shield",
      },
    ],
    categoryContent: {
      software: {
        title: "Yazılım Geliştirme Hizmetlerimiz",
        color: "blue",
        items: [
          {
            title: "Özel Yazılım Çözümleri",
            description:
              "İşletmenizin ihtiyaçlarına özel yazılım çözümleri geliştiriyoruz.",
          },
          {
            title: "Web Uygulamaları",
            description:
              "Modern ve responsive web uygulamaları geliştirme hizmetleri.",
          },
          {
            title: "Mobil Uygulamalar",
            description:
              "iOS ve Android için native ve cross-platform mobil uygulama geliştirme.",
          },
          {
            title: "API Entegrasyonları",
            description:
              "Üçüncü parti servislerle entegrasyon ve API geliştirme hizmetleri.",
          },
        ],
      },
      devops: {
        title: "DevOps Hizmetlerimiz",
        color: "indigo",
        items: [
          {
            title: "CI/CD Pipeline Kurulumu",
            description:
              "Sürekli entegrasyon ve sürekli dağıtım pipeline'ları ile geliştirme süreçlerinizi otomatikleştirin.",
          },
          {
            title: "Kubernetes Orkestrasyonu",
            description:
              "Konteyner yönetimi ve orkestrasyon çözümleri ile uygulamalarınızı ölçeklendirin.",
          },
          {
            title: "Altyapı Otomasyonu",
            description:
              "Infrastructure as Code (IaC) ile altyapınızı otomatikleştirin ve yönetin.",
          },
          {
            title: "Monitoring & Logging",
            description:
              "Sistem izleme, log yönetimi ve alarm mekanizmaları ile kesintisiz hizmet sağlayın.",
          },
        ],
      },
      hosting: {
        title: "Hosting Çözümlerimiz",
        color: "blue",
        items: [
          {
            title: "Yönetilen VPS Sunucular",
            description:
              "Yüksek performanslı, tam yönetilen sanal özel sunucu çözümleri.",
          },
          {
            title: "Veritabanı Hosting",
            description:
              "Yüksek erişilebilirliğe sahip, güvenli ve ölçeklenebilir veritabanı çözümleri.",
          },
          {
            title: "Felaket Kurtarma",
            description:
              "Veri kaybını önleyen ve hızlı kurtarma sağlayan felaket kurtarma çözümleri.",
          },
          {
            title: "Yüksek Performanslı Web Hosting",
            description:
              "Hızlı ve güvenli web hosting çözümleri ile web sitelerinizi barındırın.",
          },
        ],
      },
      cloud: {
        title: "Bulut Desteği Hizmetlerimiz",
        color: "indigo",
        items: [
          {
            title: "Azure Çözümleri",
            description:
              "Microsoft Azure üzerinde bulut çözümleri ve danışmanlık hizmetleri.",
          },
          {
            title: "AWS Çözümleri",
            description:
              "Amazon Web Services üzerinde güvenilir ve ölçeklenebilir bulut hizmetleri.",
          },
          {
            title: "Buluta Geçiş Stratejisi",
            description:
              "Mevcut sistemlerinizi buluta taşımak için kapsamlı geçiş planları ve stratejileri.",
          },
          {
            title: "Maliyet Optimizasyonu",
            description:
              "Bulut harcamalarınızı optimize ederek maksimum değer elde etmenizi sağlayan hizmetler.",
          },
        ],
      },
      security: {
        title: "Güvenlik Çözümlerimiz",
        color: "blue",
        items: [
          {
            title: "Ağ Güvenliği",
            description:
              "Firewall, VPN ve ağ izleme ile güvenli bir ağ altyapısı oluşturun.",
          },
          {
            title: "Uygulama Güvenliği",
            description:
              "Web uygulamaları ve API'ler için güvenlik testleri ve koruma hizmetleri.",
          },
          {
            title: "Veri Güvenliği",
            description:
              "Verilerinizi korumak için şifreleme, yedekleme ve erişim kontrolü çözümleri.",
          },
          {
            title: "Güvenlik Denetimi",
            description:
              "Sistemlerinizi ve uygulamalarınızı düzenli güvenlik taramaları ile koruyun.",
          },
        ],
      },
    },
  },
  {
    id: "blog",
    label: "Blog",
    type: "megamenu",
    content: {
      description: {
        title: "Teknoloji Blogumuz",
        text: "En son teknoloji trendleri, en iyi uygulamalar ve teknik içgörülerle ilgili makalelerimiz.",
        linkText: "Tüm blog yazıları",
        linkUrl: "#",
      },
      categories: {
        title: "Kategoriler",
        links: [
          { text: "Bulut Trendleri", url: "#" },
          { text: "DevOps En İyi Uygulamaları", url: "#" },
          { text: "Yazılım İnovasyonları", url: "#" },
          { text: "Teknoloji Liderliği", url: "#" },
        ],
      },
      featuredPosts: {
        title: "Öne Çıkan Yazılar",
        posts: [
          {
            title:
              "Kubernetes ile Ölçeklenebilir Mikroservis Mimarisi",
            image: "/api/placeholder/400/300",
            date: "14 Mart 2025",
            readTime: "10 dk okuma",
          },
          {
            title:
              "Azure ve AWS Karşılaştırması: Hangisi Sizin İçin Daha İyi?",
            image: "/api/placeholder/400/300",
            date: "8 Mart 2025",
            readTime: "8 dk okuma",
          },
        ],
      },
    },
  },
  {
    id: "datacenter",
    label: "Veri Merkezi",
    type: "link",
    url: "/system-status",
    showStatus: true,
    status: "online",
  },
  {
    id: "contact",
    label: "İletişim",
    type: "dropdown",
    content: {
      title: "Bize Ulaşın",
      contactInfo: [
        {
          type: "email",
          label: "E-posta",
          value: "info@sentinelit.net",
          icon: "mail",
        },
        {
          type: "address",
          label: "Ofis",
          value: "Levent, İstanbul\nTürkiye",
          icon: "map-pin",
        },
      ],
      cta: {
        text: "İletişim Formu",
        url: "#",
      },
    },
  },
];

// Menu rendering helper functions would be added here in a real implementation
// This is just the data structure for now

// Export the data to be used in other files
if (typeof module !== "undefined") {
  module.exports = {
    headerMenus,
  };
}
