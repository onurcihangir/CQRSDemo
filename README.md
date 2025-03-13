# Meter System API

A .NET-based metering system that implements CQRS pattern with TimescaleDB for time-series data management. This system provides efficient handling of meter readings and consumption data using modern architectural patterns.

## 🚀 Features

- CQRS pattern implementation using MediatR
- Time-series data management with TimescaleDB
- Generic Repository pattern
- Robust error handling and validation
- Comprehensive API documentation
- API Gateway options with Ocelot and GraphQL

## 🛠 Technologies & Patterns

- **.NET 8.0**
- **TimescaleDB** - Time-series database built on PostgreSQL
- **Entity Framework Core** - ORM for data access
- **MediatR** - For CQRS implementation
- **AutoMapper** - For object mapping
- **Swagger/OpenAPI** - API documentation
- **Ocelot** - API Gateway
- **GraphQL** - API Gateway

## 🏗 Architecture

The solution follows Clean Architecture principles with these layers:

- **MeterSystem.API** - REST API endpoints and configuration
- **MeterSystem.Application** - Application logic, CQRS handlers
- **MeterSystem.Domain** - Domain entities and interfaces
- **MeterSystem.Infrastructure** - Data access and external services
- **MeterSystem.APIGateway** - API Gateway using Ocelot
- **GraphQL.Gateway** - API Gateway using GraphQL

## 🚦 Getting Started

### Prerequisites

- .NET 8.0 SDK
- PostgreSQL 14+ with TimescaleDB extension
- Visual Studio 2022 / VS Code

### Installation

1. Clone the repository

```bash
 git clone https://github.com/onurcihangir/MeterSystem.git
 cd MeterSystem
```

2. Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DbConnectionString": "Host=localhost;Port=5432;Database=meter_system;User ID=postgres;Password=your_password"
  }
}
```

3. Run database migrations

```bash
dotnet ef database update --project MeterSystem.Infrastructure
```

4. Run the application

```bash
dotnet run --project MeterSystem.API
```

## 📈 Performance Considerations

- Uses TimescaleDB hypertables for efficient time-series data storage
- Implements query/command separation for optimized read/write operations
- Supports data compression for historical readings

## 🤝 Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the GNU General Public License v3.0 - see the [LICENSE](LICENSE) file for details.

---

# Sayaç Sistemi API

TimescaleDB kullanarak zaman serisi verilerini yöneten CQRS desenini uygulayan .NET tabanlı bir sayaç sistemidir. Bu sistem, modern mimari desenler kullanarak sayaç okumalarını ve tüketim verilerini verimli bir şekilde yönetir.

## 🚀 Özellikler

- MediatR kullanarak CQRS deseninin uygulanması
- TimescaleDB ile zaman serisi verilerinin yönetimi
- Generic Repository deseni
- Güçlü hata yönetimi ve doğrulama mekanizması
- Kapsamlı API dokümantasyonu
- Ocelot ve GraphQL ile API Gateway opsiyonları

## 🛠 Teknolojiler & Desenler

- **.NET 8.0**
- **TimescaleDB** - PostgreSQL tabanlı zaman serisi veritabanı
- **Entity Framework Core** - Veri erişimi için ORM
- **MediatR** - CQRS uygulamaları için
- **AutoMapper** - Nesne dönüşümü için
- **Swagger/OpenAPI** - API dokümantasyonu
- **Ocelot** - API Gateway
- **GraphQL** - API Gateway

## 🏗 Mimari

Bu çözüm, Clean Architecture prensiplerini takip eder ve şu katmanlara sahiptir:

- **MeterSystem.API** - REST API uç noktaları ve konfigürasyonlar
- **MeterSystem.Application** - Uygulama mantığı ve CQRS işleyicileri
- **MeterSystem.Domain** - Alan (Domain) varlıkları ve arayüzler
- **MeterSystem.Infrastructure** - Veri erişimi ve harici servisler
- **MeterSystem.APIGateway** - Ocelot API Gateway 
- **GraphQL.Gateway** - GraphQL API Gateway

## 🚦 Başlangıç

### Gereksinimler

- .NET 8.0 SDK
- TimescaleDB uzantısına sahip PostgreSQL 14+
- Visual Studio 2022 / VS Code

### Kurulum

1. Depoyu klonlayın

```bash
 git clone https://github.com/onurcihangir/MeterSystem.git
 cd MeterSystem
```

2. `appsettings.json` dosyasında bağlantı dizesini güncelleyin:

```json
{
  "ConnectionStrings": {
    "DbConnectionString": "Host=localhost;Port=5432;Database=meter_system;User ID=postgres;Password=your_password"
  }
}
```

3. Veritabanı güncellemelerini çalıştırın:

```bash
dotnet ef database update --project MeterSystem.Infrastructure
```

4. Uygulamayı çalıştırın:

```bash
dotnet run --project MeterSystem.API
```

## 📈 Performans Dikkat Noktaları

- Verimli zaman serisi veri saklaması için TimescaleDB hipertabloları kullanır
- Okuma/yazma işlemlerini optimize etmek için sorgu/komut ayrımı uygular
- Geçmiş okumalar için veri sıkıştırmayı destekler

## 🤝 Katkıda Bulunma

1. Depoyu forklayın
2. Özellik dalınızı oluşturun (`git checkout -b feature/AmazingFeature`)
3. Değişikliklerinizi commitleyin (`git commit -m 'Add some AmazingFeature'`)
4. Dalı uzak depoya gönderin (`git push origin feature/AmazingFeature`)
5. Bir Pull Request oluşturun

## 📄 Lisans

Bu proje GNU Genel Kamu Lisansı v3.0 altında lisanslanmıştır - detaylar için [LICENSE](LICENSE) dosyasına bakın.

