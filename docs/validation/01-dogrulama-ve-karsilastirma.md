# Doğrulama ve Karşılaştırma

Bu doküman, DovizCevirici projesinin Day 3 kapsamında yapılan final doğrulama, Postman-Windows Forms karşılaştırması ve teslim hazırlığı kontrollerini açıklar.

## Doğrulama Amacı

Bu doğrulama çalışmasının amacı, uygulamanın yalnızca build almasını değil; temel kullanıcı senaryolarında beklenen şekilde çalıştığını, geçersiz girişleri yönettiğini, Postman'de görülen API verisiyle aynı mantıkta hesaplama yaptığını ve repository'nin teslim edilebilir durumda olduğunu kontrol etmektir.

## Build Kontrolü

Solution root üzerinden build alınmıştır.

Kullanılan komut:

```bash
dotnet build DovizCevirici.sln
```

Beklenen sonuç:

```text
Build succeeded.
```

## Geçerli Dönüşüm Senaryoları

Aşağıdaki temel dönüşüm senaryoları test edilmiştir:

| Senaryo | Tutar | Beklenen Sonuç |
|---|---:|---|
| USD -> TRY | 100 | Sonuç Label üzerinde gösterilir |
| EUR -> TRY | 100 | Sonuç Label üzerinde gösterilir |
| TRY -> USD | 100 | Sonuç Label üzerinde gösterilir |

Bu senaryolarda uygulamanın API'den kur bilgisi aldığı ve sonucu kullanıcıya gösterdiği doğrulanmıştır.

## Bonus Özellik Doğrulamaları

MVP doğrulama senaryolarına ek olarak bonus özellikler için aşağıdaki kontroller yapılmıştır:

| Bonus Özellik | Kontrol | Beklenen Sonuç |
|---|---|---|
| DataGridView ile popüler para birimlerini listeleme | Uygulama arayüzünde popüler kurlar tablosu kontrol edildi | DataGridView üzerinde popüler kur listesi görüntülenir |
| API response alanı gösterimi | DataGridView kolonları kontrol edildi | `date`, `base`, `quote` ve `rate` alanları kullanıcıya gösterilir |
| Uygulama açılışında otomatik yükleme | Uygulama başlatıldıktan sonra tablo kontrol edildi | Kullanıcı butona basmadan popüler kur listesi otomatik yüklenir |

Test edilen popüler kur listesi USD bazlıdır ve aşağıdaki hedef para birimlerini içerir:

```text
TRY
EUR
GBP
CHF
JPY

## Geçersiz Kullanıcı Girişi Senaryoları

Aşağıdaki hatalı giriş senaryoları test edilmiştir:

| Senaryo | Giriş | Beklenen Davranış |
|---|---|---|
| Boş tutar | Boş TextBox | Kullanıcıya uyarı mesajı gösterilir |
| Sayısal olmayan değer | `abc` | Kullanıcıya uyarı mesajı gösterilir |
| Sıfır değer | `0` | Kullanıcıya uyarı mesajı gösterilir |
| Negatif değer | `-50` | Kullanıcıya uyarı mesajı gösterilir |
| Aynı para birimi | USD -> USD | Kullanıcıya uyarı mesajı gösterilir |

Beklenen kullanıcı mesajları:

```text
Tutar sayısal bir değer olmalıdır.
Tutar sıfırdan büyük olmalıdır.
Kaynak ve hedef para birimi aynı olamaz.
```

## API Kaynaklı Hata Yönetimi

Infrastructure katmanında API bağlantısı, zaman aşımı ve response formatı ile ilgili hata durumları için kullanıcıya daha anlaşılır mesajlar gösterilecek şekilde hata yönetimi yapılmıştır.

Örnek hata mesajları:

```text
API bağlantısı sırasında bir sorun oluştu. Lütfen internet bağlantınızı kontrol edin.
API isteği zaman aşımına uğradı. Lütfen tekrar deneyin.
API yanıtı beklenen formatta okunamadı.
```

## Postman ve Windows Forms Karşılaştırması

Postman üzerinde kullanılan istek:

```text
GET https://api.frankfurter.dev/v2/rates?base=USD&quotes=TRY
```

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

Windows Forms uygulamasında aynı mantık kullanılır:

```text
Kaynak Para Birimi = USD
Hedef Para Birimi = TRY
Tutar = 100
```

Hesaplama mantığı:

```text
100 x rate = dönüşüm sonucu
```

Örnek:

```text
100 x 46.341 = 4634.1 TRY
```

Postman'de görülen `rate` değeri ile Windows Forms uygulamasında kullanılan `rate` değeri aynı API response mantığına dayanmaktadır.

Kur değerleri zamana göre değişebileceği için farklı zamanlarda yapılan testlerde küçük farklılıklar oluşabilir. Bu durum API'nin güncel veri döndürmesinden kaynaklanır.

## Repository Temizliği

Teslim öncesinde repository içerisinde gereksiz build çıktılarının bulunmaması kontrol edilmiştir.

Kontrol edilmesi gereken dosya ve klasörler:

```text
.vs
bin
obj
```

Bu tür dosyalar `.gitignore` kapsamında tutulmalı ve GitHub repository içerisinde yer almamalıdır.

## Final Checklist

| Kontrol                                                                     | Durum      |
| --------------------------------------------------------------------------- | ---------- |
| USD, EUR ve TRY senaryoları test edildi                                     | Tamamlandı |
| Postman sonucu ile Windows Forms sonucu karşılaştırıldı                     | Tamamlandı |
| Geçersiz kullanıcı girişleri yönetildi                                      | Tamamlandı |
| API kaynaklı hata mesajları düzenlendi                                      | Tamamlandı |
| README.md proje amacını açıklıyor                                           | Tamamlandı |
| README.md kullanılan teknolojileri içeriyor                                 | Tamamlandı |
| README.md çalıştırma adımlarını içeriyor                                    | Tamamlandı |
| README.md dokümantasyon haritasını içeriyor                                 | Tamamlandı |
| DataGridView ile popüler para birimleri listelendi                          | Tamamlandı |
| API response içindeki `date`, `base`, `quote` ve `rate` alanları gösterildi | Tamamlandı |
| Uygulama açılışında popüler kurlar otomatik yüklendi                        | Tamamlandı |
| Bonus geliştirmeler sonrası manuel çevirme akışı tekrar test edildi         | Tamamlandı |
| Repository gereksiz dosyalardan temizlendi                                  | Tamamlandı |
| Final build başarılı                                                        | Tamamlandı |
| Final commit ve push tamamlandı                                             | Tamamlandı |
| Repository teslim edilebilir durumda                                        | Tamamlandı |


## Sonuç

DovizCevirici projesi MVP kapsamı doğrultusunda test edilmiş, Postman API keşfi ile Windows Forms uygulamasındaki API kullanım yaklaşımı karşılaştırılmış ve repository teslim edilebilir hale getirilmiştir.

Bonus kapsamda DataGridView ile popüler kur listesi gösterimi, API response alanlarının kullanıcıya sunulması ve uygulama açılışında otomatik kur yükleme özellikleri eklenmiştir.

Bu geliştirmeler sonrasında manuel döviz çevirme akışının çalışmaya devam ettiği doğrulanmıştır.