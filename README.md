# Library-Automation
Bu proje, C# Windows Forms kullanılarak geliştirilmiş katmanlı mimariye sahip bir Kütüphane Otomasyon Sistemidir. Temel amaç; kitap, üye ve ödünç alma işlemlerinin düzenli, sürdürülebilir ve anlaşılır bir yapıda yönetilmesini sağlamaktır.

[Youtube Linki]()

### Projenin Amacı
Kütüphane içindeki kitapların yönetilmesi
Üye kayıtlarının tutulması ve silinmesi
Kitapların ödünç verilmesi ve iade süreçlerinin kontrolü
Katmanlı mimari (Entity – DAL – BLL – UI) kullanarak bakımı kolay bir yapı oluşturmak <br/>

### Kullanılan Teknolojiler
C# (.NET Framework)
Windows Forms (WinForms)
Katmanlı Mimari
Entity Layer
Data Access Layer (DAL)
Business Logic Layer (BLL)
UI (Forms)
SQL Server (isteğe bağlı / LocalDB)

## Katmanlar ve Görevleri
#### EntityLayer
Veri modellerini içerir.
Book
Member
Borrow
Category
#### DAL (Data Access Layer)
Veritabanı işlemleri burada yapılır.
Ekleme
Silme
Listeleme
#### BLL (Business Logic Layer)
İş kurallarını ve kontrolleri içerir.
Veri doğrulama
DAL çağrıları
#### UI (Windows Forms)
Kullanıcı arayüzü katmanıdır.
LoginForm
MainForm
BookForm
MemberForm
BorrowForm

## Özellikler
#### Giriş Sistemi
Kullanıcı adı ve parola kontrolü
Parola alanı gizli (PasswordChar aktif)
#### Üye İşlemleri
Üye ekleme
Üye silme
Üye listeleme
#### Kitap İşlemleri
Kitap ekleme
Kitap silme
Kategoriye göre kitap yönetimi
#### Ödünç Alma (Borrow)
Üye & kitap seçimi (ComboBox)
Teslim tarihi belirleme
İade durumu takibi
#### Form Yönetimi
Alt formlar açıldığında MainForm gizlenir
Geri butonu veya X ile kapatıldığında MainForm tekrar gösterilir
Tüm formlar tam ekran açılır

## UML Diyagramı
Proje için sınıf ilişkilerini gösteren UML diyagramı oluşturulmuştur.

## Kurulum ve Çalıştırma
Projeyi klonlayın <br/>
`git clone https://github.com/kullanici-adi/library-automation.git` <br/>
Visual Studio ile açın <br/>
Gerekirse veritabanı bağlantı ayarlarını düzenleyin <br/>
Projeyi çalıştırın <br/>

## Notlar
Proje, genişletilebilir yapıda tasarlanmıştır. Yeni modüller eklemek kolaydır.
