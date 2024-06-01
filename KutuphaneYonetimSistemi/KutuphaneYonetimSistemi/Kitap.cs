using System;

/// <summary>
/// Kitap bilgilerini tutmak için kullanılacak.
/// </summary>
class Kitap
{
    /// <summary>
    /// Kitap id
    /// </summary>
    public string ISBN { get; set; }
    /// <summary>
    /// Kaitabın adı
    /// </summary>
    public string kitapAdi { get; set; }
    /// <summary>
    /// Kitabın yazarı
    /// </summary>
    public string yazari { get; set; }
    /// <summary>
    /// Kitabın yayinlanma yılı
    /// </summary>
    public string yayinYili { get; set; }
    /// <summary>
    /// Kitap şu anda mevcut mu
    /// </summary>
    public bool mevcutMu { get; set; }

    public Kitap (string ISBN, string kitapAdi, string yazari, string yayinYili, bool mevcutMu)
    {
        this.ISBN = ISBN;
        this.kitapAdi = kitapAdi;
        this.yazari = yazari;
        this.yayinYili = yayinYili;
        this.mevcutMu = mevcutMu;
    }
}