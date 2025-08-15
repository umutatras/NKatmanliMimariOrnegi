# NKatmanliMimariOrnegi

Bu proje, .NET 6 ve Entity Framework Core kullanılarak geliştirilmiş, çok katmanlı (N-Layered) mimari örneğidir. Proje, katmanlar arası bağımlılıkları azaltmak ve sürdürülebilir, test edilebilir bir yapı sunmak amacıyla tasarlanmıştır.
Katmanlar ve Sorumlulukları

1. Entities Katmanı
   • Amaç: Veritabanı tablolarını temsil eden POCO (Plain Old CLR Object) sınıflarını içerir.
   • Örnek: Product gibi temel varlık sınıfları burada bulunur.
2. DataAccess Katmanı
   • Amaç: Veritabanı işlemlerinin gerçekleştirildiği katmandır.
   • Bileşenler:
   • DbContext: NKatmanliMimariOrnegiDbContext ile veritabanı bağlantısı ve tabloların yönetimi sağlanır.
   • Repository: Generic Repository<T> sınıfı ile temel CRUD işlemleri soyutlanır.
   • IRepository: Repository pattern için arayüzdür, test edilebilirlik ve bağımlılıkların azaltılması için kullanılır.
3. Business Katmanı
   • Amaç: İş kurallarının ve uygulama mantığının yazıldığı katmandır.
   • Bileşenler:
   • Service Sınıfları: Örneğin, ProductService ile ürünlere ait iş kuralları uygulanır.
   • Interfaces: Servislerin arayüzleri, bağımlılıkların gevşek tutulmasını sağlar.
   • Exceptions: Özel iş kuralı hataları için exception sınıfları (ör. BadRequestException).
4. DTOs Katmanı
   • Amaç: Veri transfer nesneleri ile katmanlar arası veri taşınmasını sağlar. (Örneğin, API ile istemci arasında.)
5. SharedLibrary Katmanı
   • Amaç: Ortak kullanılacak enum, helper veya sabitlerin tutulduğu katmandır.
   • Örnek: OrderByType enum'u.
   Bağımlılıkların Çözülmesi
   • Dependency Injection: Business.DependencyResolvers.Microsoft.DependencyExtension ile servisler ve repository'ler DI konteynerine eklenir.
   • Kullanım:
   services.AddDependencies(configuration);
   Repository Kullanımı
   • CRUD işlemleri: Tüm temel işlemler generic repository üzerinden yapılır.
   • Örnek:
   await \_repository.AddAsync(product);
   var products = await \_repository.GetAllAsync();
   Proje Yapısı
   NKatmanliMimariOrnegi.Entities/
   NKatmanliMimariOrnegi.DataAccess/
   NKatmanliMimariOrnegi.Business/
   NKatmanliMimariOrnegi.DTOs/
   NKatmanliMimariOrnegi.SharedLibrary/
   Teknolojiler
   • .NET 6
   • Entity Framework Core 6
   • Microsoft Dependency Injection

---

Bu yapı, katmanlar arası bağımlılıkları azaltır, kodun test edilebilirliğini ve sürdürülebilirliğini artırır. Her katman yalnızca kendi sorumluluğundaki işlemleri gerçekleştirir ve diğer katmanlarla arayüzler üzerinden iletişim kurar.
