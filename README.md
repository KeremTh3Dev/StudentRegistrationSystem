
# Student Registration System

C# ile yazılmış, komut satırında çalışan öğrenci, ders ve not kayıt uygulaması. Kayıtlar tamamlandığında liste `.txt` dosyası olarak kaydedilir.

## Özellikler

- Öğrenci kaydı: ad, soyad ve öğrenci numarası (1-10000)
- Ders kaydı: ders adı ve AKTS (1-10)
- Not girişi: her öğrenci için kayıtlı tüm derslere not (0-100)
- Kaydetmeden önce düzenleme: ad, soyad, numara, ders adı, AKTS ve not
- Listeyi masaüstüne ya da seçtiğin bir dizine `.txt` olarak kaydetme
- Ad, soyad ve ders adında boşluk kullanılabilir (ör. `Ahmet Yılmaz`, `Veri Yapıları`)

## Komutlar

| Komut | Açıklama |
|---|---|
| `ogrenciekle` | Öğrenci kayıt moduna girer |
| `dersekle` | Ders kayıt moduna girer |
| `notekle` | Tüm öğrenciler için tüm derslerin notlarını sırayla ister |
| `kaydetvecik` | Listeyi gösterir, düzenleme sorar, dosyaya kaydeder ve programdan çıkar |

Kayıt, not ve düzenleme modlarında `q` yazarak ana menüye dönebilirsin.

## Kullanım Sırası

1. `ogrenciekle` ile en az bir öğrenci ekle.
2. `dersekle` ile en az bir ders ekle.
3. `notekle` ile notları gir.
4. `kaydetvecik` ile listeyi kaydet.

Notlar girilmeden de kaydedilebilir. Bu durumda öğrencinin altında "Not kaydı yok." yazar.

## Dikkat Edilecekler

- Veriler yalnızca program açıkken bellekte tutulur. Program kapandığında kaybolur, kalıcı olan tek çıktı kaydedilen `.txt` dosyasıdır.
- `notekle` her çalıştığında öğrencilerin önceki notlarının yerine yeni girilenleri yazar. Çıkmak için `q` yazarsan o oturumda girilen notlar kaydedilmez, eski notlar korunur.
- Düzenleme sırasında bir dersin adını ya da AKTS değerini değiştirirsen, o dersi alan tüm öğrencilerde değişir.

## Çıktı Formatı

Dosya adı `ogrenci_listesi_yyyyMMdd_HHmmss.txt` biçimindedir ve UTF-8 olarak kaydedilir:

```
 [1] 101 no Ahmet Yılmaz adlı öğrencinin notları:
(1) Matematik (5 AKTS): 85p
(2) Fizik (4 AKTS): 70p
```

Varsayılan konum masaüstüdür. Masaüstü klasörü bulunamazsa kullanıcının ana klasörüne kaydedilir.
