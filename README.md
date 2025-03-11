# Kargo Takip Backend - .NET 9 Web API

## 📌 Proje Tanıtımı
Bu proje, kargo takibini yönetmek için geliştirilen bir **.NET 9 Web API** uygulamasıdır. **Clean Architecture** ve **CQRS** mimarisi temel alınarak inşa edilmiştir. JWT kimlik doğrulama, OData ile filtreleme ve FluentValidation ile veri doğrulama gibi modern backend geliştirme teknikleri kullanılmıştır.

## 🚀 Özellikler
- **Kimlik Doğrulama:** JWT tabanlı authentication ve authorization
- **CQRS Pattern:** Komut ve sorguların ayrıştırılması
- **Minimal API:** Hafif ve performanslı endpoint yapısı
- **OData Desteği:** Veri filtreleme, sıralama ve arama desteği
- **FluentValidation:** Model doğrulama
- **Mapster:** DTO ve model dönüşümleri için
- **Result Pattern:** API sonuçlarını yönetmek için
- **Generic Repository & Unit of Work:** Veritabanı işlemlerini yönetmek için
- **Options Pattern:** Yapılandırmaları yönetmek için
- **MS SQL Desteği:** Veritabanı yönetimi
- **Scrutor:** Bağımlılık yönetimi

## 📂 Proje Yapısı
```bash
├── Application
│   ├── Features (CQRS Komut & Sorgular)
│   ├── Interfaces (Arayüzler)
│   ├── Mappings (Mapster Konfigürasyonları)
│   ├── Validators (FluentValidation)
├── Domain
│   ├── Entities (Veri modelleri)
│   ├── Common (Ortak modeller & Result Pattern)
├── Infrastructure
│   ├── Persistence (EF Core ve MS SQL işlemleri)
│   ├── Identity (JWT ve Kimlik Doğrulama)
│   ├── Options Pattern 
├── API (Minimal API & Controller’lar)
│   ├── Middlewares
│   ├── Routes
```

## 🛠️ Kurulum ve Çalıştırma
Aşağıdaki adımları takip ederek projeyi çalıştırabilirsiniz:

```bash
# Bağımlılıkları yükleyin
dotnet restore

# Veritabanını güncelleyin
dotnet ef database update

# Uygulamayı çalıştırın
dotnet run
```

Varsayılan olarak API `http://localhost:5000` adresinde çalışacaktır.

## 🔧 Kullanılan Teknolojiler
- **Backend:** .NET 9 Web API
- **Veritabanı:** MS SQL Server
- **Kimlik Doğrulama:** JWT Bearer Token
- **Patternler:** CQRS, Clean Architecture, Options Pattern, Result Pattern, Unit of Work, Generic Repository
- **Veri İşleme:** OData, Mapster, FluentValidation
- **API:** Minimal API, MediatR

## 📌 Örnek API Kullanımı
### 1️⃣ Kullanıcı Girişi
```http
POST /api/auth/login
```
```json
{
  "email": "admin@example.com",
  "password": "Admin123!"
}
```
Yanıt:
```json
{
  "data": {
    "accessToken": "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEyZTdhNGI1LTQzYmYtNDAyYy1iNTdlLTJmZDEwNmVjMDY4OSIsIm5iZiI6MTc0MTY5MTg3NSwiZXhwIjoxNzQxNzc4Mjc1LCJpc3MiOiJFbXJlIENhbiIsImF1ZCI6IkVtcmUgQ2FuIn0.kqcylMEq3POQiluBmoe3CyrgQB2jx6EUjEag7YJr6fgSbjhn7TquoXK0dypqAnU0187PfWaXxY9aFR1kL121FA"
  },
}
```

### 2️⃣ Kargo Listesi
```http
GET /odata/kargolar?$count=true&$top=10&$skip=0
```
Yanıt:
```json
[
  {
    "id": 1,
    "trackingNumber": "ABC123456",
    "status": "Delivered"
  }
]
```

## 📌 Geliştirici Notları
- **OData desteği sayesinde** filtreleme ve sıralama işlemleri kolayca yapılabilir.
- **Result Pattern kullanıldığı için**, API yanıtları her zaman belirli bir formatta döner.
- **FluentValidation sayesinde** isteklerdeki hatalar detaylı şekilde döndürülür.

🚀 Projeyi geliştirmek veya katkıda bulunmak için Pull Request açabilirsiniz!

