# Katman Sorumlulukları

Bu doküman, DovizCevirici projesinde kullanılan katmanların sorumluluklarını açıklar.

Amaç, hangi kodun hangi katmanda yer alacağını ve hangi katmanda yer almaması gerektiğini netleştirmektir.

## Genel Katman Yapısı

```text
Presentation
Application
Domain
Infrastructure
```

## Presentation Katmanı

Presentation katmanı Windows Forms arayüzünden sorumludur.

Bu projede temel Presentation bileşeni `Form1` dosyasıdır.

### Sorumlulukları

- Kullanıcıdan kaynak para birimini almak
- Kullanıcıdan hedef para birimini almak
- Kullanıcıdan tutar bilgisini almak
- Çevir butonu ile işlemi başlatmak
- Sonucu kullanıcıya göstermek
- Kullanıcıya uyarı veya hata mesajı göstermek
- UI state yönetimi yapmak

### Yapmaması Gerekenler

- Frankfurter API'ye doğrudan istek atmamalıdır.
- JSON response parse etmemelidir.
- Dönüşüm hesabının ana iş kuralını taşımamalıdır.
- API hata yönetimini teknik detaylarıyla üstlenmemelidir.

## Application Katmanı

Application katmanı uygulamanın ana iş akışını yönetir.

Bu projede temel Application bileşeni `CurrencyConversionService` sınıfıdır.

### Sorumlulukları

- Kullanıcı isteğini doğrulamak
- Kaynak ve hedef para birimi kontrolü yapmak
- Tutarın geçerli olup olmadığını kontrol etmek
- Infrastructure katmanından kur bilgisini istemek
- Dönüşüm hesabını yapmak
- Presentation katmanına gösterilebilir sonuç döndürmek

### Yapmaması Gerekenler

- UI kontrolü yönetmemelidir.
- MessageBox göstermemelidir.
- TextBox veya ComboBox gibi Form elemanlarına erişmemelidir.
- HTTP isteği ve JSON parse detaylarını doğrudan yönetmemelidir.

## Domain Katmanı

Domain katmanı uygulamanın temel modellerini içerir.

Bu projede Domain katmanı, uygulama içinde kullanılan veri nesnelerini sade şekilde temsil eder.

### Sorumlulukları

- Conversion request modelini tutmak
- Conversion result modelini tutmak
- API response modelini tutmak
- Validation result modelini tutmak

### Yapmaması Gerekenler

- UI logic içermemelidir.
- HTTP isteği yapmamalıdır.
- JSON parse işlemi yapmamalıdır.
- Kullanıcıya mesaj göstermemelidir.

## Infrastructure Katmanı

Infrastructure katmanı dış sistemlerle iletişimden sorumludur.

Bu projede temel dış sistem Frankfurter API'dir.

### Sorumlulukları

- Frankfurter API endpoint'ine HTTP GET isteği göndermek
- Query parameter yapısını oluşturmak
- API response içeriğini okumak
- Newtonsoft.Json ile JSON parse işlemini yapmak
- Response içindeki `rate` değerini okumak
- API bağlantısı veya response formatı ile ilgili teknik hataları yönetmek

### Yapmaması Gerekenler

- Windows Forms UI elemanlarına erişmemelidir.
- MessageBox göstermemelidir.
- Kullanıcı arayüzü kararları vermemelidir.
- Business flow kararlarını tek başına yönetmemelidir.

## Katmanlara Göre Örnek Sorumluluk Dağılımı

| İşlem | Sorumlu Katman |
|---|---|
| Kullanıcının tutar girmesi | Presentation |
| Tutarın sıfırdan büyük olup olmadığını kontrol etme | Application |
| API'ye istek atma | Infrastructure |
| JSON response içerisinden `rate` değerini okuma | Infrastructure |
| Dönüşüm sonucunu hesaplama | Application |
| Sonucu ekranda gösterme | Presentation |
| Request ve result modellerini taşıma | Domain |

## Temel Standart

Bu projede Form kodu mümkün olduğunca sade tutulmuştur. Form, kullanıcıdan veri alır ve sonucu gösterir. API çağrısı, JSON parse ve dönüşüm akışı ilgili katmanlara ayrılmıştır.

Bu ayrım, küçük bir Windows Forms projesinde temel katmanlı mimari disiplinini göstermek amacıyla uygulanmıştır.