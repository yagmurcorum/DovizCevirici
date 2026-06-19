# Proje Genel Bakış

## Proje Adı

DovizCevirici

## Repository Kapsamı

Bu repository, Frankfurter API kullanılarak geliştirilen Windows Forms tabanlı döviz çevirici masaüstü uygulamasını temsil eder.

Repository içerisinde yalnızca uygulama kodları değil; aynı zamanda API keşfi, Postman test çıktıları, doğrulama notları ve proje dokümantasyonu da yer almaktadır.

Bu proje ayrı bir backend API değildir. Windows Forms uygulaması doğrudan Frankfurter API'ye HTTP isteği gönderir.

## Domain Tanımı

DovizCevirici; kullanıcının seçtiği kaynak para birimi, hedef para birimi ve tutar bilgisine göre döviz kuru verisini alır, ilgili kur değerini kullanarak dönüşüm hesabı yapar ve sonucu kullanıcıya gösterir.

Bu domain kapsamında temel kavramlar şunlardır:

| Kavram | Açıklama |
|---|---|
| Kaynak Para Birimi | Kullanıcının çevirmek istediği para birimi |
| Hedef Para Birimi | Dönüştürülmek istenen para birimi |
| Tutar | Kullanıcı tarafından girilen sayısal değer |
| Rate | API response içerisinden okunan döviz kuru değeri |
| Dönüşüm Sonucu | Tutar ile rate değerinin çarpılmasıyla hesaplanan sonuç |

## Proje Amacı

Bu projenin amacı, public bir döviz kuru API'sinin önce Postman ile keşfedilmesi, response yapısının anlaşılması ve ardından aynı API'nin Windows Forms uygulaması içinde kullanılmasıdır.

Bu çalışma ile aşağıdaki konular pratik edilmiştir:

- API endpoint yapısını okuma
- Query parameter mantığını anlama
- Postman ile GET isteği gönderme
- JSON response analizi yapma
- C# içinde HttpClient kullanma
- Newtonsoft.Json ile JSON parse etme
- Windows Forms arayüzünde kullanıcı girdisi alma
- Katmanlı sorumluluk ayrımı kurma
- Kullanıcıya anlamlı hata mesajları gösterme
- README ve docs yapısı ile teslim edilebilir repository hazırlama

## MVP Kapsamı

MVP kapsamında aşağıdaki özellikler tamamlanmıştır:

- Frankfurter API seçimi
- Postman üzerinde temel API isteğinin test edilmesi
- API response alanlarının incelenmesi
- `rate` alanının döviz kuru değeri olarak kullanılması
- Windows Forms App projesinin oluşturulması
- Kaynak ve hedef para birimi ComboBox alanlarının oluşturulması
- Tutar TextBox alanının oluşturulması
- Çevir butonunun eklenmesi
- Sonuç Label alanının oluşturulması
- API'den kur bilgisinin çekilmesi
- Dönüşüm hesabının yapılması
- Boş, geçersiz, sıfır ve negatif tutar girişlerinin kontrol edilmesi
- Kaynak ve hedef para biriminin aynı seçilmesi durumunda kullanıcıya uyarı verilmesi
- README ve teknik dokümantasyonun hazırlanması

## Bonus Kapsamı

MVP kapsamı tamamlandıktan sonra uygulamaya görev dokümanında belirtilen opsiyonel bonus özellikler eklenmiştir.

Bonus kapsamındaki geliştirmeler şunlardır:

| Bonus | Açıklama |
|---|---|
| Popüler para birimlerini listeleme | Windows Forms arayüzüne eklenen DataGridView üzerinde USD bazlı popüler kur listesi gösterilir |
| API response alanı gösterimi | Frankfurter API response içinde yer alan `date`, `base`, `quote` ve `rate` alanları kullanıcıya gösterilir |
| Otomatik kur yükleme | Uygulama açıldığında popüler kur listesi otomatik olarak yüklenir |

Görev dokümanındaki “popüler para birimleri” bonus maddesi kapsamında, uygulamada USD bazlı seçili örnek para birimleri listelenmiştir. Hedef para birimleri TRY, EUR, GBP, CHF ve JPY olarak belirlenmiştir.

Bu seçim, resmi bir popülerlik sıralaması iddiası taşımadan; farklı para birimlerinin tek API isteğiyle alınmasını, DataGridView üzerinde listelenmesini ve API response alanlarının kullanıcıya gösterilmesini sağlamak amacıyla yapılmıştır.

## Kapsam Dışı

Aşağıdaki konular bu projenin kapsamı dışındadır:

- Ayrı bir backend API geliştirme
- Web uygulaması geliştirme
- Veri Tabanı kullanımı
- Kullanıcı girişi veya yetkilendirme
- Production seviyesinde hata yönetimi
- CI/CD pipeline kurulumu
- Deployment süreci
- Gelişmiş finansal analiz sistemi

## Roadmap Özeti

| Gün | Odak | Çıktı |
|---|---|---|
| Day 1 | API keşfi ve Postman testi | Endpoint, query parameter ve response analizi |
| Day 2 | Windows Forms geliştirme | Temel uygulama akışı ve API entegrasyonu |
| Day 3 | Doğrulama ve dokümantasyon | Testler, README, docs ve teslim hazırlığı |

## Teslim Çıktıları

Teslim kapsamında aşağıdaki çıktılar hazırlanmıştır:

- Windows Forms uygulaması
- Frankfurter API entegrasyonu
- Postman API keşfi dokümantasyonu
- Örnek JSON response dosyaları
- README.md
- Mimari ve doğrulama dokümanları
- GitHub repository düzeni
- DataGridView ile popüler kur listesi gösterimi
- Uygulama açılışında otomatik kur yükleme
- API response içindeki `date`, `base`, `quote` ve `rate` alanlarının kullanıcıya gösterilmesi