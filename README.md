# DovizCevirici

DovizCevirici, Frankfurter API üzerinden döviz kuru verisi alan ve bu veriyi Windows Forms arayüzünde kullanarak temel döviz çevirme işlemi yapan öğrenme odaklı bir masaüstü uygulamasıdır.

Bu repository, ayrı bir backend API projesi değildir. Repository; Frankfurter API keşfi, Postman test çıktıları, Windows Forms uygulaması ve ilgili proje dokümantasyonunu temsil eder.

## Domain Tanımı

DovizCevirici; kullanıcının seçtiği kaynak para birimi, hedef para birimi ve tutar bilgisine göre Frankfurter API üzerinden güncel kur bilgisini alır, `rate` değerini kullanarak dönüşüm sonucunu hesaplar ve sonucu Windows Forms arayüzünde gösterir.

## MVP Kapsamı

Bu projenin MVP kapsamı aşağıdaki maddelerden oluşur:

- Frankfurter API'nin Postman ile incelenmesi
- API endpoint ve query parameter yapısının anlaşılması
- JSON response içerisindeki `rate` alanının analiz edilmesi
- Postman üzerinde alınan örnek JSON response çıktılarının `postman/` klasörü altında saklanması
- Windows Forms App ile temel kullanıcı arayüzünün oluşturulması
- Kaynak para birimi, hedef para birimi ve tutar girişinin alınması
- API üzerinden kur bilgisinin çekilmesi
- Döviz çevirme sonucunun kullanıcıya gösterilmesi
- Geçersiz kullanıcı girişleri için anlamlı hata mesajları verilmesi
- README ve docs klasörü altında proje dokümantasyonunun hazırlanması

## Bonus Özellikler

MVP kapsamı tamamlandıktan sonra uygulamaya aşağıdaki bonus özellikler eklenmiştir:

- Windows Forms arayüzünde seçili para birimlerini listeleyen bir DataGridView eklenmiştir.
- Frankfurter API response içinde yer alan `date`, `base`, `quote` ve `rate` alanları DataGridView üzerinde gösterilmiştir.
- Uygulama açıldığında USD bazlı seçili kur listesi otomatik olarak yüklenmektedir.

Bu bonus geliştirmeler, temel döviz çevirme akışını değiştirmeden API response görünürlüğünü artırmak ve kullanıcıya başlangıçta örnek kur bilgilerini göstermek amacıyla eklenmiştir.

Görev dokümanındaki “popüler para birimleri” bonus maddesi kapsamında, uygulamada USD bazlı seçili örnek para birimleri listelenmiştir. Hedef para birimleri `TRY`, `EUR`, `GBP`, `CHF` ve `JPY` olarak belirlenmiştir. Bu seçim, resmi bir popülerlik sıralaması iddiası taşımadan; uygulamanın API listeleme, çoklu kur response okuma ve DataGridView gösterimi davranışını sade şekilde göstermek amacıyla yapılmıştır.


## Kapsam Dışı

Bu proje kapsamında aşağıdaki başlıklar yer almamaktadır:

- Ayrı bir backend API geliştirme
- Veri Tabanı kullanımı
- Authentication / Authorization
- Production deployment
- CI/CD pipeline
- Gelişmiş logging veya monitoring
- Gerçek zamanlı finansal işlem sistemi geliştirme

## Kullanılan Teknolojiler

- C#
- .NET 8
- Windows Forms App
- HttpClient
- Newtonsoft.Json
- Frankfurter API
- Postman
- Git / GitHub

## Proje Yapısı

```text
DovizCevirici/
├── .github/
├── src/
│   └── DovizCevirici/
│       ├── Application/
│       ├── Domain/
│       │   └── Models/
│       ├── Infrastructure/
│       ├── Presentation/
│       ├── Form1.cs
│       ├── Program.cs
│       └── DovizCevirici.csproj
├── docs/
│   ├── 00-dokumantasyon-indeksi.md
│   ├── 01-proje-genel-bakis.md
│   ├── 02-isimlendirme-standardi.md
│   ├── architecture/
│   │   ├── 01-mimari-genel-bakis.md
│   │   └── 02-katman-sorumluluklari.md
│   ├── api-kesfi/
│   │   └── 01-postman-api-kesfi.md
│   └── validation/
│       └── 01-dogrulama-ve-karsilastirma.md
├── postman/
│   ├── usd-try-ornek-response.json
│   └── usd-coklu-para-birimi-response.json
├── README.md
├── .gitignore
└── DovizCevirici.sln
```

## Quick Start

Projeyi klonlayın:

```bash
git clone https://github.com/yagmurcorum/DovizCevirici.git
```

Proje klasörüne gidin:

```bash
cd DovizCevirici
```

Solution dosyasını build edin:

```bash
dotnet build DovizCevirici.sln
```

Uygulamayı terminalden çalıştırmak için:

```bash
dotnet run --project src/DovizCevirici/DovizCevirici.csproj
```

Alternatif olarak Visual Studio 2022 ile `DovizCevirici.sln` dosyasını açıp Start butonu ile uygulamayı çalıştırabilirsiniz.

## Dokümantasyon Haritası

Detaylı proje dokümantasyonu `docs/` klasörü altında tutulmaktadır.

- [Dokümantasyon İndeksi](docs/00-dokumantasyon-indeksi.md)
- [Proje Genel Bakış](docs/01-proje-genel-bakis.md)
- [İsimlendirme Standardı](docs/02-isimlendirme-standardi.md)
- [Mimari Genel Bakış](docs/architecture/01-mimari-genel-bakis.md)
- [Katman Sorumlulukları](docs/architecture/02-katman-sorumluluklari.md)
- [API Keşfi ve Postman](docs/api-kesfi/01-postman-api-kesfi.md)
- [Doğrulama ve Karşılaştırma](docs/validation/01-dogrulama-ve-karsilastirma.md)

## Postman Dosyaları

Postman üzerinde alınan örnek JSON response çıktıları repository kökünde yer alan `postman/` klasörü altında tutulmaktadır.

```text
postman/
├── usd-try-ornek-response.json
└── usd-coklu-para-birimi-response.json
```

Bu dosyalar, API keşfi sırasında incelenen örnek response yapılarını ham JSON formatında göstermektedir.

## Mevcut Durum

MVP kapsamındaki temel geliştirme, API keşfi, uygulama testi ve dokümantasyon hazırlığı tamamlanmıştır.

Bonus kapsamda DataGridView ile popüler kur listesi gösterimi, API response alanlarının görünür hale getirilmesi ve uygulama açılışında otomatik kur yükleme özellikleri eklenmiştir.

Bu proje öğrenme ve staj görevi kapsamında hazırlanmıştır.
