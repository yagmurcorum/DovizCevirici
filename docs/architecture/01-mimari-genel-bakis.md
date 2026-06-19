# Mimari Genel Bakış

DovizCevirici, öğrenme odaklı ve klasör bazlı katmanlı mimari yaklaşımıyla geliştirilmiş bir Windows Forms uygulamasıdır.

Bu proje production seviyesinde bir finans sistemi değildir. Amaç, public bir API'nin Postman ile incelenmesi ve aynı API'nin Windows Forms uygulaması içinde katmanlı sorumluluk ayrımıyla tüketilmesidir.

## Mimari Yaklaşım

Projede temel olarak aşağıdaki katmanlar kullanılmıştır:

```text
Presentation
Application
Domain
Infrastructure
```

Bu yapı sayesinde kullanıcı arayüzü, iş akışı, modeller ve API iletişimi birbirinden ayrılmıştır.

## Genel Akış

Uygulamanın temel çalışma akışı aşağıdaki gibidir:

```text
Form1
→ ConversionRequest
→ CurrencyConversionService
→ FrankfurterApiClient
→ Frankfurter API
→ ExchangeRateResponse
→ ConversionResult
→ Form1 / lblResult
```

## Akış Açıklaması

1. Kullanıcı Windows Forms ekranında kaynak para birimini, hedef para birimini ve tutarı girer.
2. `Form1`, kullanıcı girdilerinden bir `ConversionRequest` nesnesi oluşturur.
3. `CurrencyConversionService`, request bilgisini doğrular.
4. Validation başarılıysa `FrankfurterApiClient` üzerinden Frankfurter API'ye istek gönderilir.
5. API response içerisindeki `rate` alanı okunur.
6. Application katmanı dönüşüm sonucunu hesaplar.
7. Sonuç `ConversionResult` nesnesi ile Presentation katmanına döner.
8. `Form1`, sonucu kullanıcıya Label üzerinde gösterir.

## Bonus Akış

Bonus özellikler kapsamında uygulama açılışında popüler döviz kurları otomatik olarak yüklenir ve DataGridView üzerinde gösterilir.

Bu akış aşağıdaki gibidir:

```text
Form1 Load Event
→ LoadPopularRatesAsync
→ CurrencyConversionService.GetPopularRatesAsync
→ FrankfurterApiClient.GetRatesAsync
→ Frankfurter API
→ ExchangeRateResponse List
→ DataGridView

## Katmanlı Mimari Kullanım Nedeni

Bu projede katmanlı yapı kullanılmasının temel nedenleri şunlardır:

- Form içerisine API çağrısı yazılmasını engellemek
- JSON parse işlemini UI kodundan ayırmak
- Validation ve dönüşüm hesabını tek bir yerde toplamak
- Kodun okunabilirliğini artırmak
- Küçük bir projede temel kurumsal yazılım geliştirme alışkanlıklarını pratik etmek

## Bu Mimari Ne Değildir?

Bu yapı aşağıdaki iddiaları taşımaz:

- Production seviyesinde enterprise architecture değildir.
- Ayrı bir backend API değildir.
- Database veya repository pattern içeren bir yapı değildir.
- Çok katmanlı dağıtık sistem mimarisi değildir.

Bu proje için kullanılan yaklaşım, öğrenme odaklı ve sadeleştirilmiş bir layered Windows Forms uygulama yapısıdır.

## Önemli Mimari Kararlar

| Karar                                          | Açıklama                                                                                 |
| ---------------------------------------------- | ---------------------------------------------------------------------------------------- |
| Windows Forms doğrudan API'ye bağlanır         | Ayrı backend API kapsam dışıdır                                                          |
| API çağrısı Form içinde yapılmaz               | Infrastructure katmanında yönetilir                                                      |
| Validation Application katmanında yapılır      | UI yalnızca kullanıcı etkileşimini yönetir                                               |
| Finansal hesaplamada `decimal` kullanılır      | Para ve kur hesapları için daha uygun veri tipidir                                       |
| JSON parse işlemi Infrastructure katmanındadır | API response okuma teknik sorumluluktur                                                  |
| Popüler kur listesi otomatik yüklenir          | Uygulama açıldığında USD bazlı popüler kurlar DataGridView üzerinde gösterilir           |
| DataGridView sadece gösterim sorumluluğu taşır | API çağrısı ve veri hazırlama yine Application ve Infrastructure katmanlarında yönetilir |
| API response alanları görünür hale getirilir   | `date`, `base`, `quote` ve `rate` alanları kullanıcıya tablo üzerinde gösterilir         |

