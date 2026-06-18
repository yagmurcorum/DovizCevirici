# API Keşfi ve Postman

Bu doküman, DovizCevirici projesinde kullanılan Frankfurter API'nin Postman üzerinde nasıl incelendiğini ve response yapısının nasıl yorumlandığını açıklar.

## API Seçimi

Bu proje kapsamında Frankfurter API seçilmiştir.

Frankfurter API'nin tercih edilme nedenleri:

- JSON formatında response döndürmesi
- API key gerektirmemesi
- Kayıt zorunluluğu olmaması
- TRY, USD ve EUR gibi temel para birimlerini desteklemesi
- Basit endpoint ve query parameter yapısına sahip olması
- Windows Forms uygulaması içinde kolay tüketilebilir olması

## Kullanılan Endpoint

```text
https://api.frankfurter.dev/v2/rates
```

## Query Parameter Yapısı

| Parameter | Açıklama |
|---|---|
| `base` | Kaynak para birimini belirtir |
| `quotes` | Hedef para birimini veya para birimlerini belirtir |

## Örnek Postman İsteği

```text
GET https://api.frankfurter.dev/v2/rates?base=USD&quotes=TRY
```

Bu istekte:

- Kaynak para birimi: `USD`
- Hedef para birimi: `TRY`

## Örnek JSON Response

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

## Response Alanları

| Alan | Açıklama |
|---|---|
| `date` | Kur bilgisinin ait olduğu tarih |
| `base` | Kaynak para birimi |
| `quote` | Hedef para birimi |
| `rate` | Kaynak para biriminin hedef para birimi karşılığı |

## Rate Alanının Kullanımı

Windows Forms uygulamasında dönüşüm hesabı için response içindeki `rate` alanı kullanılır.

Örnek:

```text
Tutar: 100
Base: USD
Quote: TRY
Rate: 46.341
```

Hesaplama:

```text
100 x 46.341 = 4634.1 TRY
```

## Endpoint ve Rate Alanı Notu

Kullanılan endpoint adı `/v2/rates` şeklindedir. Ancak bu endpoint'in döndürdüğü response formatında uygulamada kullanılan asıl kur değeri `rate` alanıdır.

Bu nedenle uygulama tarafında JSON response içerisinden `rate` değeri okunur ve dönüşüm hesabında bu değer kullanılır.

## Çoklu Para Birimi Response Örneği

Aşağıdaki örnekte USD baz alınarak birden fazla hedef para birimi için response alınmıştır.

```json
[
  {
    "date": "2026-06-18",
    "base": "USD",
    "quote": "CHF",
    "rate": 0.79434
  },
  {
    "date": "2026-06-18",
    "base": "USD",
    "quote": "EUR",
    "rate": 0.86357
  },
  {
    "date": "2026-06-18",
    "base": "USD",
    "quote": "GBP",
    "rate": 0.74686
  },
  {
    "date": "2026-06-18",
    "base": "USD",
    "quote": "JPY",
    "rate": 160.47
  },
  {
    "date": "2026-06-18",
    "base": "USD",
    "quote": "TRY",
    "rate": 46.348
  }
]
```

## Postman'den Uygulamaya Geçiş

Postman üzerinde test edilen yaklaşım Windows Forms uygulamasında aynı mantıkla kullanılmıştır.

Postman'de kullanılan istek:

```text
GET https://api.frankfurter.dev/v2/rates?base=USD&quotes=TRY
```

Windows Forms uygulamasında oluşturulan istek mantığı:

```text
base = kullanıcının seçtiği kaynak para birimi
quotes = kullanıcının seçtiği hedef para birimi
```

API'den dönen `rate` değeri Application katmanında dönüşüm hesabında kullanılır.

## İlgili Postman Artefact Dosyaları

Postman üzerinde alınan örnek JSON response çıktıları repository kökünde yer alan `postman/` klasörü altında saklanmaktadır.

```text
postman/
├── usd-try-ornek-response.json
└── usd-coklu-para-birimi-response.json
```

Bu dosyalar, API keşfi sırasında incelenen örnek response yapılarını ham JSON formatında göstermektedir.

## Sonuç

Postman testi sonucunda Frankfurter API'nin proje kapsamında kullanılabilir olduğu doğrulanmıştır. API response yapısı incelenmiş, dönüşüm hesabında kullanılacak değerin `rate` alanı olduğu netleştirilmiş ve aynı yaklaşım Windows Forms uygulamasına taşınmıştır.