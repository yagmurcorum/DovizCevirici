# Dokümantasyon İndeksi

Bu klasör, DovizCevirici projesine ait proje tanımı, isimlendirme standardı, mimari yaklaşım, API keşfi ve doğrulama dokümanlarını içerir.

Amaç, repository'ye ilk kez giren bir kişinin projenin kapsamını, teknik yaklaşımını ve teslim durumunu hızlıca anlayabilmesini sağlamaktır.

## Dokümantasyon Yapısı

| Doküman | Açıklama |
|---|---|
| [Proje Genel Bakış](01-proje-genel-bakis.md) | Projenin amacı, domain tanımı, kapsamı ve teslim çıktıları |
| [İsimlendirme Standardı](02-isimlendirme-standardi.md) | Repository, solution, proje, dosya ve kod isimlendirme kararları |
| [Mimari Genel Bakış](architecture/01-mimari-genel-bakis.md) | Uygulamanın genel mimari yaklaşımı ve veri akışı |
| [Katman Sorumlulukları](architecture/02-katman-sorumluluklari.md) | Presentation, Application, Domain ve Infrastructure katmanlarının sorumlulukları |
| [API Keşfi ve Postman](api-kesfi/01-postman-api-kesfi.md) | Frankfurter API'nin Postman üzerinde incelenmesi ve JSON response analizi |
| [Doğrulama ve Karşılaştırma](validation/01-dogrulama-ve-karsilastirma.md) | Test senaryoları, Postman-Windows Forms karşılaştırması ve teslim kontrolü |

## Dokümantasyon Yaklaşımı

README.md dosyası projenin ana giriş noktası olarak sade tutulmuştur. Daha detaylı teknik açıklamalar ilgili dokümanlara ayrılmıştır.

Bu yaklaşım sayesinde:

- README dosyası okunabilir kalır.
- Teknik kararlar ilgili başlıklarda takip edilir.
- API keşfi, mimari kararlar ve doğrulama adımları birbirine karışmaz.
- Proje büyüse bile dokümantasyon düzeni korunabilir.