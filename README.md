# 📊 DapperDatasetProject

## Genel Bakış

**DapperDatasetProject**, Kaggle'dan indirilen **10 milyon satırlık satış verisi** üzerinden kapsamlı analizler yapılmasını sağlayan, ASP.NET Core MVC + Dapper mimarisi ile geliştirilmiş bir **web tabanlı satış analizi ve görselleştirme uygulamasıdır**.
Proje; filtreleme, grafiksel raporlama ve özet analizlerle büyük veri kümeleri üzerinde etkili bir kullanıcı deneyimi sunar.

---

## 🚀 Temel Özellikler

* 🔎 Gelişmiş filtreleme: Ürün, kategori, müşteri, bölge, şehir vb.
* 📈 Dinamik grafikler: En çok satan ürünler, kategori bazlı satışlar, gelir analizi (Chart.js)
* 📋 Satış listesi: Büyük veri setinde arama ve sıralama
* 📊 Dashboard: Toplam satış sayısı, ortalama sipariş tutarı, toplam gelir gibi özet veriler
* ⚡ Yüksek performans: Dapper ile hızlı ve verimli SQL sorguları
* 🌐 Responsive ve modern arayüz (Bootstrap 4 + PurpleAdmin tema)
* 🇹🇷 Tam Türkçe dil desteği

---

## 🏗️ Proje Yapısı

```
DapperDatasetProject/
├── Controllers/
│   └── SalesController.cs          # Dashboard ve liste işlemleri
├── Models/
│   ├── Sales.cs                    # Veritabanı satış modeli
│   └── ErrorViewModel.cs
├── DTOs/
│   └── SalesDto.cs, DashboardDto.cs
├── Services/
│   └── SalesService.cs             # Dapper ile veri erişim mantığı
├── Context/
│   └── DapperContext.cs            # SQL Server bağlantısı
├── Views/
│   ├── Sales/
│   │   ├── Dashboard.cshtml        # Ana grafik paneli
│   │   └── List.cshtml             # Satış listesi ve filtreleme
│   └── Shared/
│       ├── _Layout.cshtml
│       └── Error.cshtml
├── wwwroot/                        # CSS, JS, görseller
├── appsettings.json               # DB connection string vs.
├── Program.cs / Startup.cs
└── DapperDatasetProject.csproj
```

---

## 🧩 Kullanım Senaryoları

### 1. **Dashboard Paneli**

* Toplam satış sayısı
* Toplam gelir
* Ortalama satış tutarı
* Grafiklerle en çok satan ürün/kategori/şehir vs.

### 2. **Filtrelenebilir Satış Listesi**

* Ürün adı, müşteri adı, kategori, bölge, şehir gibi alanlara göre filtreleme
* Arama kutusu ile dinamik sonuçlar

### 3. **Veri Görselleştirme**

* Chart.js ile bar, pie ve line grafik türleri
* Gerçek zamanlı veriye göre grafik güncelleme

---

## ⚙️ Teknolojiler

| Katman     | Teknoloji                       |
| ---------- | ------------------------------- |
| Backend    | ASP.NET Core MVC, Dapper        |
| Frontend   | Bootstrap 4, jQuery, Chart.js   |
| Veritabanı | SQL Server (10M+ veri desteği)  |
| Tema       | PurpleAdmin Free Admin Template |
| Dil        | Türkçe                          |

---

## 📥 Veri Seti

* **Kaynak**: [[Kaggle - Sales Dataset (10M+ Satır)](https://www.kaggle.com/)](https://www.kaggle.com/datasets/omercolakoglu/10million-rows-turkish-market-sales-dataset)
* **Kapsam**: Ürün, müşteri, sipariş tarihi, bölge, şehir, kategori, fiyat vb.
* **Not**: Veri ön işleme yapılmış ve normalize edilmiş biçimde SQL Server’a yüklenmiştir.

---

## 🔧 Geliştirici Notları

* Tüm veritabanı işlemleri Dapper ile gerçekleştirilmiştir (CRUD, filtreleme, aggregation).
* Büyük veri setleriyle çalışabilmek için optimize sorgular ve DTO yapısı kullanılmıştır.
* Kod yapısı katmanlı mimari ilkesine göre ayrılmıştır (Controller - Service - DTO - View).

---

## 📸 Ekran Görüntüleri

https://github.com/user-attachments/assets/fd691a52-5d46-4dfd-9d0e-563c3d1c430d



https://github.com/user-attachments/assets/db4d5214-8915-48f3-98e0-91eb59286a66


<img width="1915" height="911" alt="Ekran görüntüsü 2025-08-02 225244" src="https://github.com/user-attachments/assets/e3669755-cf0d-46fe-88a5-7c28895146c1" />

<img width="1915" height="908" alt="Ekran görüntüsü 2025-08-02 225256" src="https://github.com/user-attachments/assets/9849e863-c46c-442c-86d3-3a0d4542f496" />
<img width="1912" height="910" alt="Ekran görüntüsü 2025-08-02 225309" src="https://github.com/user-attachments/assets/f70f743f-9036-4afb-9e7e-bbbbdc910a7b" />
<img width="1916" height="912" alt="Ekran görüntüsü 2025-08-02 225317" src="https://github.com/user-attachments/assets/5d864121-6a64-4040-95c2-d603d1933ed0" />
<img width="1916" height="1076" alt="Ekran görüntüsü 2025-08-02 225346" src="https://github.com/user-attachments/assets/07adc39d-0d74-412c-a736-d713cb942465" />


---
