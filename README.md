# Student Registration & Grade Management System

C# ile geliştirilmiş, komut satırı üzerinden çalışan öğrenci kayıt ve not yönetim sistemi.

## Özellikler

- **Öğrenci Kaydı (`ogrencikaydet`):** Kullanıcıdan sırasıyla isim, soyisim ve öğrenci numarası alır.
- **Not Girişi (`ogrencinotugir`):** Kayıtlı öğrencilere sistem üzerinden not tanımlaması yapar.
- **Hesaplama ve Sıralama:** Notları harf notuna (A+, A, F vb.) çevirir ve başarı sırasına göre dizer.
- **Raporlama (`listeyikaydet`):** Oluşturulan listeyi masaüstüne `.txt` dosyası olarak kaydeder.

## Çalışma Mantığı

1. `ogrencikaydet` komutu ile öğrenci ekleme döngüsü başlar. `listeyikaydet` denilene kadar kayıt alınır.
2. `ogrencinotugir` komutu ile öğrencilere not girilir. `listeyikaydet` komutu geldiğinde notlar hesaplanır, sıralanır ve dosya olarak aktarılır.
3. Hatalı komut girildiğinde uyarı verilir ve ana menüye dönülür.
