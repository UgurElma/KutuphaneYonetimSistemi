using System.Collections.Generic;

/// <summary>
/// Kullanıcı bilgilerini tutmak için kullanılacak.
/// </summary>
class Kullanici
{
    /// <summary>
    /// Kullanıcı numarası
    /// </summary>
    public int kullaniciID { get; set; }
    /// <summary>
    /// Kullanıcının adı
    /// </summary>
    public string kullaniciAdi { get; set; }
    /// <summary>
    /// Kullanıcının soyadı
    /// </summary>
    public string kullaniciSoyadi { get; set; }
    /// <summary>
    /// Kullanıcının ödünç aldığı kitapların listesi
    /// </summary>
    public List<Kitap> oduncAlinanlar { get; set; }

    public Kullanici(int kullaniciID, string kullaniciAdi, string kullaniciSoyadi, List<Kitap> oduncAlinanlar)
    {
        this.kullaniciID = kullaniciID;
        this.kullaniciAdi = kullaniciAdi;
        this.kullaniciSoyadi = kullaniciSoyadi;
        this.oduncAlinanlar = oduncAlinanlar;
    }

    public string OduncAlma(Kitap kitap)
    {
        oduncAlinanlar.Add(kitap);
        kitap.mevcutMu = false;
        return kitap.kitapAdi + " kitabı " + kullaniciAdi + " " + kullaniciSoyadi + " kullanıcısına ödünç verildi.";
    }
    public string IadeAlma(Kitap kitap)
    {
        for (int i = 0; i < oduncAlinanlar.Count; i++)
        {
            if (oduncAlinanlar[i].ISBN == kitap.ISBN)
            {
                oduncAlinanlar.Remove(oduncAlinanlar[i]);
                break;
            }
        }
        kitap.mevcutMu = true;
        return kitap.kitapAdi + " kitabı " + kullaniciAdi + " " + kullaniciSoyadi + " kullanıcısından iade alındı.";
    }
}