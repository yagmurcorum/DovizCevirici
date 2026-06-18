# DovizCevirici

DovizCevirici, Frankfurter API kullanılarak geliştirilen Windows Forms tabanlı bir döviz çevirici uygulamasıdır.

Bu proje kapsamında önce Frankfurter API Postman üzerinde incelenmiş, API response yapısı analiz edilmiş ve ardından aynı API Windows Forms uygulaması içinde kullanılarak temel döviz çevirme akışı geliştirilmiştir.

## Proje Amacı

Bu çalışmanın amacı, public bir döviz kuru API'sinin nasıl keşfedileceğini, Postman ile nasıl test edileceğini ve gerçek bir masaüstü uygulama içerisinde nasıl tüketileceğini uygulamalı olarak öğrenmektir.

Proje iki ana aşamadan oluşmaktadır:

1. Frankfurter API'nin Postman üzerinde incelenmesi
2. Aynı API'yi kullanan Windows Forms döviz çevirici uygulamasının geliştirilmesi

## Kullanılan Teknolojiler

* C#
* .NET 8
* Windows Forms App
* HttpClient
* Newtonsoft.Json
* Frankfurter API
* Postman
* Git / GitHub

## Proje Yapısı

```text
DovizCevirici/
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
├── postman/
├── README.md
├── .gitignore
└── DovizCevirici.sln
```

## Katman Sorumlulukları

### Presentation

Windows Forms ekranından sorumludur.

Bu katmanda kullanıcıdan kaynak para birimi, hedef para birimi ve tutar bilgisi alınır. Sonuç ve hata mesajları kullanıcıya gösterilir.

### Application

Uygulamanın ana iş akışını yönetir.

Kullanıcı isteğini doğrular, gerekli durumda Infrastructure katmanından kur bilgisini alır ve dönüşüm sonucunu hesaplar.

### Domain

Uygulamada kullanılan temel modelleri içerir.

Bu katmanda conversion request, conversion result, validation result ve API response modelleri bulunur.

### Infrastructure

Frankfurter API ile HTTP iletişimini yönetir.

API'ye GET isteği gönderir, JSON response'u Newtonsoft.Json ile parse eder ve response içindeki `rate` alanından kur bilgisini okur.

## API Kullanımı

Projede Frankfurter API kullanılmaktadır.

Kullanılan endpoint:

```text
https://api.frankfurter.dev/v2/rates
```

Örnek istek:

```text
https://api.frankfurter.dev/v2/rates?base=USD&quotes=TRY
```

Bu istekte:

* `base`: Kaynak para birimini belirtir.
* `quotes`: Hedef para birimini belirtir.
* `rate`: API response içinde döviz kuru değerinin bulunduğu alandır.

Örnek response:

```json
[
  {
    "date": "2026-06-18",
    "base": "USD",
    "quote": "TRY",
    "rate": 46.341
  }
]
```

Windows Forms uygulamasında hesaplama mantığı:

```text
Kullanıcı tutarı x rate = dönüşüm sonucu
```

## Uygulama Özellikleri

* Kaynak para birimi seçimi
* Hedef para birimi seçimi
* Kullanıcıdan tutar girişi alınması
* Frankfurter API'ye istek gönderilmesi
* API response içindeki `rate` değerinin okunması
* Döviz çevirme sonucunun ekranda gösterilmesi
* Boş, geçersiz, sıfır veya negatif tutar girişlerinde kullanıcıya Türkçe pop-up mesaj gösterilmesi
* Kaynak ve hedef para birimi aynı seçildiğinde kullanıcıya uyarı verilmesi
* Enter tuşu ile çevirme işleminin tetiklenmesi

## Çalıştırma Adımları

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

Uygulamayı çalıştırmak için Visual Studio 2022 ile `DovizCevirici.sln` dosyasını açın ve Start butonuna basın.

Alternatif olarak terminalden çalıştırmak için:

```bash
dotnet run --project src/DovizCevirici/DovizCevirici.csproj
```

## Postman ve Windows Forms Karşılaştırması

Postman üzerinde kullanılan API yaklaşımı ile Windows Forms uygulamasında kullanılan API yaklaşımı aynıdır.

Postman örneği:

```text
GET https://api.frankfurter.dev/v2/rates?base=USD&quotes=TRY
```

Postman response içinde gelen `rate` değeri, Windows Forms uygulamasında da aynı şekilde okunmaktadır.

Örnek senaryo:

```text
Kaynak Para Birimi: USD
Hedef Para Birimi: TRY
Tutar: 100
```

Hesaplama mantığı:

```text
100 x rate = dönüşüm sonucu
```

Bu nedenle Postman'de görülen ham JSON response ile Windows Forms uygulamasında ekrana yansıyan sonuç aynı API verisine dayanmaktadır.

## Test Edilen Senaryolar

* USD -> TRY dönüşümü
* EUR -> TRY dönüşümü
* TRY -> USD dönüşümü
* Boş tutar girişi
* Harf veya geçersiz değer girişi
* Sıfır tutar girişi
* Negatif tutar girişi
* Kaynak ve hedef para biriminin aynı seçilmesi
* Enter tuşu ile çevirme işleminin tetiklenmesi

## Kapsam Dışı

Bu proje kapsamında aşağıdaki geliştirmeler yapılmamıştır:

* Web uygulaması geliştirme
* Ayrı bir backend API geliştirme
* Veritabanı kullanımı
* Production deployment
* CI/CD süreci
* Bonus özellikler

## Notlar

Bu proje öğrenme ve staj görevi kapsamında geliştirilmiştir. Ana hedef, public bir API'nin Postman ile keşfedilmesi ve Windows Forms uygulaması içerisinde temel düzeyde tüketilmesidir.
