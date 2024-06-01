using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Kitap ve kullanıcı bilgilerini yönetmek için kullanılacak.
/// </summary>
class KutuphaneYonetici
{
    /// <summary>
    /// Kitaplar.txt yolu
    /// </summary>
    string pathbooks = "\\Kitaplar.txt";
    /// <summary>
    /// Kullanıcılar.txt yolu
    /// </summary>
    string pathusers = "\\Kullanicilar.txt";
    /// <summary>
    /// Bütün kitapların tutulduğu liste
    /// </summary>
    List<Kitap> kitaplar;
    /// <summary>
    /// Bütün kullanıcıların tutulduğu liste
    /// </summary>
    List<Kullanici> kullanicilar;

    public KutuphaneYonetici()
    {
        kitaplar = new List<Kitap>();
        kullanicilar = new List<Kullanici>();
        if (!File.Exists(pathbooks))
            File.Create(pathbooks).Close();
        else
            KitaplariDosyadanOku();
        if (!File.Exists(pathusers))
            File.Create(pathusers).Close();
        else
            KullanıcılarıDosyadanOku();
    }

    /// <summary>
    /// Kitap ekleme fonksiyonu
    /// </summary>
    /// <param name="ISBN"></param>
    /// <param name="kitapAdi"></param>
    /// <param name="yazari"></param>
    /// <param name="yayinYili"></param>
    /// <returns></returns>
    public string KitapEkle(string ISBN, string kitapAdi, string yazari, string yayinYili)
    {
        if (ISBN == string.Empty || kitapAdi == string.Empty || yazari == string.Empty || yayinYili == string.Empty)
            return "İşlem başarısız! Eksik veri girdiniz.";
        else if (int.Parse(ISBN) > 0)
        {
            for (int i = 0; i < kitaplar.Count; i++)
            {
                if (kitaplar[i].ISBN == ISBN)
                {
                    return "İşlem başarısız! Farklı bir ISBN giriniz.";
                }
            }
        }
        else
        {
            return "İşlem başarısız! Pozitif bir ISBN giriniz.";
        }
        kitaplar.Add(new Kitap(ISBN, kitapAdi, yazari, yayinYili, true));
        return "Kitap başarıyla eklendi!\nISBN: " + ISBN + ", Kitap Adı: " + kitapAdi + ", Yazar: " + yazari + ", Yayın Yılı: " + yayinYili + " ";
    }
    /// <summary>
    /// Kitapları listeleme fonksiyonu
    /// </summary>
    public void KitaplariListele()
    {
        if (kitaplar.Count == 0) 
        {
            Console.Write("Kayıt bulunamadı!");
            return; 
        }
        for (int i = 0; i < kitaplar.Count; i++)
        {
            Console.WriteLine((i + 1) + ". ISBN: " + kitaplar[i].ISBN + ", Kitap Adı: " + kitaplar[i].kitapAdi + ", Yazar: " + kitaplar[i].yazari + ", Yayın Yılı: " + kitaplar[i].yayinYili + ", Mevcut Mu?: " + kitaplar[i].mevcutMu);
        }
    }
    /// <summary>
    /// Kullanıcı ekleme fonskiyonu
    /// </summary>
    /// <param name="kullaniciID"></param>
    /// <param name="kullaniciAdi"></param>
    /// <param name="kullaniciSoyadi"></param>
    /// <returns></returns>
    public string KullaniciEkle(int kullaniciID, string kullaniciAdi, string kullaniciSoyadi)
    {
        if (kullaniciAdi == string.Empty || kullaniciSoyadi == string.Empty)
        {
            return "İşlem başarısız! Eksik veri girdiniz.";
        }
        else if (kullaniciID > 0)
        {
            for (int i = 0; i < kullanicilar.Count; i++)
            {
                if (kullanicilar[i].kullaniciID == kullaniciID)
                {
                    return "İşlem başarısız! Farklı bir kullanıcı ID giriniz.";
                }
            }
        }
        else
        {
            return "İşlem başarısız! Pozitif bir kullanıcı ID giriniz.";
        }
        kullanicilar.Add(new Kullanici(kullaniciID, kullaniciAdi, kullaniciSoyadi, new List<Kitap>()));
        return "Kullanıcı başarıyla eklendi!\nKullanıcı ID: " + kullaniciID + ", İsim: " + kullaniciAdi + ", Soyad: " + kullaniciSoyadi + " ";
    }
    /// <summary>
    /// Kullanıcıları listeleme fonksiyonu
    /// </summary>
    public void KullanicilariListele()
    {
        if (kullanicilar.Count == 0)
        {
            Console.Write("Kayıt bulunamadı!");
            return;
        }
        for (int i = 0; i < kullanicilar.Count; i++)
        {
            Console.WriteLine((i + 1) + ". Kullanıcı ID: " + kullanicilar[i].kullaniciID + ", İsim: " + kullanicilar[i].kullaniciAdi + ", Soy isim: " + kullanicilar[i].kullaniciSoyadi + "");
        }
    }
    /// <summary>
    /// Kitap Ödünç Verme
    /// </summary>
    /// <param name="kullaniciID"></param>
    /// <param name="ISBN"></param>
    /// <returns></returns>
    public string KitapOduncVerme(int kullaniciID, string ISBN)
    {
        string yanit = string.Empty;
        Kitap kitap = null; 
        for (int i = 0; i < kitaplar.Count; i++)
        {
            if (kitaplar[i].ISBN == ISBN && kitaplar[i].mevcutMu)
            {
                kitap = kitaplar[i];
                break;
            }
        }
        for (int i = 0; i < kullanicilar.Count; i++)
        {
            if (kullanicilar[i].kullaniciID == kullaniciID && kitap != null)
            {
                yanit = kullanicilar[i].OduncAlma(kitap);
                break;
            }
        }
        if (yanit == string.Empty)
            yanit = "İşlem yapılamadı!";
        return yanit;
    }
    /// <summary>
    /// Kitap iade alma fonksiyonu
    /// </summary>
    /// <param name="kullaniciID"></param>
    /// <param name="ISBN"></param>
    /// <returns></returns>
    public string KitapIadeAlma(int kullaniciID, string ISBN)
    {
        string yanit = string.Empty;
        Kitap kitap = null;
        for (int i = 0; i < kitaplar.Count; i++)
        {
            if (kitaplar[i].ISBN == ISBN && !kitaplar[i].mevcutMu)
            {
                kitap = kitaplar[i];
                break;
            }
        }
        for (int i = 0; i < kullanicilar.Count; i++)
        {
            if (kullanicilar[i].kullaniciID == kullaniciID && kitap != null)
            {
                for (int j = 0; j < kullanicilar[i].oduncAlinanlar.Count; j++)
                {
                    if (kullanicilar[i].oduncAlinanlar[j].ISBN == kitap.ISBN)
                    {
                        yanit = kullanicilar[i].IadeAlma(kitap);
                        break;
                    }
                }
            }
        }
        if (yanit == string.Empty)
            yanit = "İşlem yapılamadı!";
        return yanit;
    }
    /// <summary>
    /// Kitapları dosyaya yazma fonksiyonu
    /// </summary>
    /// <returns></returns>
    public string KitaplariDosyayaYaz()
    {
        using (FileStream fs = new FileStream(pathbooks,FileMode.Truncate)) { }
        using (StreamWriter streamWriter = new StreamWriter(pathbooks, false))
        {
            for (int i = 0; i < kitaplar.Count; i++)
            {
                streamWriter.WriteLine(kitaplar[i].ISBN + "+" + kitaplar[i].kitapAdi + "+" + kitaplar[i].yazari + "+" + kitaplar[i].yayinYili + "+" + kitaplar[i].mevcutMu.ToString());
            }
        }
        return "Kitap bilgileri “Kitaplar.txt” dosyasına kaydedildi.";
    }
    /// <summary>
    /// Kitapları dosyadan sisteme yazma
    /// </summary>
    /// <returns></returns>
    public string KitaplariDosyadanOku()
    {
        using (StreamReader streamReader = new StreamReader(pathbooks))
        {
            kitaplar.Clear();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                var parts = line.Split('+');
                kitaplar.Add(new Kitap(parts[0], parts[1], parts[2], parts[3], Convert.ToBoolean(parts[4])));
            }
        }
        return "Kitap bilgileri “Kitaplar.txt” dosyasından okundu ve sisteme yüklendi.";
    }
    /// <summary>
    /// Kullanıcıları dosyaya yazma
    /// </summary>
    /// <returns></returns>
    public string KullanicilariDosyayaYaz()
    {
        using (FileStream fileStream = new FileStream(pathusers, FileMode.Truncate)) { }
        using (StreamWriter streamWriter = new StreamWriter(pathusers, false))
        {
            for (int i = 0; i < kullanicilar.Count; i++)
            {
                if (kullanicilar[i].oduncAlinanlar.Count > 0)
                {
                    streamWriter.Write(kullanicilar[i].kullaniciID + "+" + kullanicilar[i].kullaniciAdi + "+" + kullanicilar[i].kullaniciSoyadi);
                    for (int j = 0; j < kullanicilar[i].oduncAlinanlar.Count; j++)
                    {
                        streamWriter.Write("+" + kullanicilar[i].oduncAlinanlar[j].ISBN + ";" + kullanicilar[i].oduncAlinanlar[j].kitapAdi + ";" + kullanicilar[i].oduncAlinanlar[j].yazari + ";" + kullanicilar[i].oduncAlinanlar[j].yayinYili + ";" + kullanicilar[i].oduncAlinanlar[j].mevcutMu);
                    }
                    streamWriter.WriteLine();
                }
                else
                {
                    streamWriter.WriteLine(kullanicilar[i].kullaniciID + "+" + kullanicilar[i].kullaniciAdi + "+" + kullanicilar[i].kullaniciSoyadi);
                }
            }
        }
        return "Kullanıcı bilgileri “Kullanicilar.txt” dosyasına kaydedildi.";
    }
    /// <summary>
    /// Kullanıcıları dosyadan okur
    /// </summary>
    /// <returns></returns>
    public string KullanıcılarıDosyadanOku()
    {
        using (StreamReader streamReader = new StreamReader(pathusers))
        {
            kullanicilar.Clear();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                List<Kitap> oduncListesi = new List<Kitap>();
                var parts = line.Split('+');
                if (parts.Length > 3)
                {
                    for (int i = 3; i < parts.Length; i++)
                    {
                        var parts2 = parts[i].Split(';');
                        oduncListesi.Add(new Kitap(parts2[0], parts2[1], parts2[2], parts2[3], Convert.ToBoolean(parts2[4])));
                    }
                    kullanicilar.Add(new Kullanici(int.Parse(parts[0]), parts[1], parts[2], oduncListesi));
                }
                else
                {
                    kullanicilar.Add(new Kullanici(int.Parse(parts[0]), parts[1], parts[2], new List<Kitap>()));
                }
            }
        }
        return "Kitap bilgileri “Kitaplar.txt” dosyasından okundu ve sisteme yüklendi.";
    }
}