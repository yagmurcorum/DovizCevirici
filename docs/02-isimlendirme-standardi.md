# İsimlendirme Standardı

Bu doküman, DovizCevirici projesinde kullanılan isimlendirme standartlarını açıklar.

Amaç, repository, solution, proje, klasör, dosya ve kod seviyesinde tutarlı bir isimlendirme yapısı oluşturmaktır.

## Proje Seviyesi İsimlendirme

| Alan | Kullanılan İsim | Açıklama |
|---|---|---|
| Repository adı | `DovizCevirici` | GitHub repository adı |
| Solution adı | `DovizCevirici.sln` | Visual Studio solution dosyası |
| Project adı | `DovizCevirici` | Windows Forms App proje adı |
| Ana namespace | `DovizCevirici` | Uygulamanın temel namespace değeri |

## Klasör İsimlendirme

Proje içerisinde temel klasör isimleri İngilizce ve PascalCase kullanılarak oluşturulmuştur.

```text
Application
Domain
Infrastructure
Presentation
```

Bu tercih, C# ve .NET projelerinde yaygın kullanılan teknik klasör isimlendirme pratikleriyle uyumludur.

Dokümantasyon klasörlerinde ise Türkçe içerik tercih edilmiştir.

```text
docs
architecture
api-kesfi
validation
postman
```

## Markdown Dosya İsimlendirme

Markdown dokümanlarında aşağıdaki standart kullanılmıştır:

- Küçük harf
- Kelimeler arasında tire
- Türkçe karakter kullanmadan Türkçe isimlendirme
- Gerektiğinde sıralama numarası

Örnekler:

```text
00-dokumantasyon-indeksi.md
01-proje-genel-bakis.md
02-isimlendirme-standardi.md
01-mimari-genel-bakis.md
01-postman-api-kesfi.md
01-dogrulama-ve-karsilastirma.md
```

Dosya adlarında Türkçe karakter kullanılmamasının nedeni; terminal, Git, URL ve işletim sistemi uyumluluğunu korumaktır. Dosya içeriklerindeki başlıklarda ise tam Türkçe ifadeler kullanılabilir.

## C# Kod İsimlendirme

| Yapı | Standart | Örnek |
|---|---|---|
| Class | PascalCase | `CurrencyConversionService` |
| Method | PascalCase | `ConvertAsync` |
| Property | PascalCase | `SourceCurrency` |
| Private field | `_camelCase` | `_frankfurterApiClient` |
| Local variable | camelCase | `convertedAmount` |
| Async method | `Async` suffix | `GetRateAsync` |

## UI Control İsimlendirme

Windows Forms kontrollerinde kısa ve anlamlı prefix kullanılmıştır.

| Kontrol | İsim | Açıklama |
|---|---|---|
| ComboBox | `cmbSourceCurrency` | Kaynak para birimi seçimi |
| ComboBox | `cmbTargetCurrency` | Hedef para birimi seçimi |
| TextBox | `txtAmount` | Tutar girişi |
| Button | `btnConvert` | Çevirme işlemini başlatan buton |
| Label | `lblResult` | Sonucun gösterildiği alan |

## Model İsimlendirme

Domain modelleri uygulama içindeki temel veri yapılarını temsil eder.

| Model | Sorumluluk |
|---|---|
| `ConversionRequest` | Kullanıcıdan alınan dönüşüm isteğini temsil eder |
| `ConversionResult` | Hesaplanan dönüşüm sonucunu temsil eder |
| `ExchangeRateResponse` | Frankfurter API response modelini temsil eder |
| `ValidationResult` | Validation sonucunu temsil eder |

## Standart Kararı

Bu projede kod tarafında C# ve .NET ekosistemine uygun İngilizce teknik isimlendirme korunmuştur. Dokümantasyon tarafında ise Türkçe açıklamalar ve Türkçe doküman başlıkları kullanılmıştır.

Bu ayrım, hem teknik standartlara uyumu hem de teslim dokümantasyonunun anlaşılır olmasını sağlar.