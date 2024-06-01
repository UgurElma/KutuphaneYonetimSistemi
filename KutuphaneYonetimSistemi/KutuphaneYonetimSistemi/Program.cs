using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

internal class Program
{
    static void Main()
    {
    Restart:
        KutuphaneYonetici kutuphaneYonetici = new KutuphaneYonetici();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("KÜTÜPHANE SİSTEMİ\n0 ---> Uygulamadan Çıkış\n1 ---> Kitap Ekleme\n2 ---> Kitapları Listeleme\n3 ---> Kullanıcı Ekleme\n4 ---> Kullanıcıları Listeleme\n5 ---> Kitap Ödünç Verme\n6 ---> Kitap İade Alma\n7 ---> Kitapları Dosyaya Yaz\n8 ---> Dosyadan Kitapları Oku\n9 ---> Kullanıcıları Dosyaya Yaz\n10 ---> Dosyadan Kullanıcıları Oku\n11 ---> Kayıt yapmadan uygulamayı yeniden başlat");
            try
            {
                Console.Write("----------------------------------------\nLütfen, yapmak istediğiniz işlemi giriniz: ");
                int operation = int.Parse(Console.ReadLine());
                if (operation == 0)
                {
                    Console.Clear();
                    Console.Write("Uygualama kapatıldı!");
                    Console.ReadKey();
                    break;
                }
                else if (operation == 1)
                {
                    Console.Clear();
                    Console.WriteLine(">>>  Kitap Ekleme  <<<");
                    Console.Write("ISBN: ");
                    string ISBN = Console.ReadLine();
                    Console.Write("Kitap Adı: ");
                    string kitapAdi = Console.ReadLine();
                    Console.Write("Yazarı: ");
                    string yazari = Console.ReadLine();
                    Console.Write("Yayın Yılı: ");
                    string yayinYili = Console.ReadLine();
                    Console.Write(kutuphaneYonetici.KitapEkle(ISBN, kitapAdi, yazari, yayinYili));
                    Console.ReadKey();
                }
                else if (operation == 2)
                {
                    Console.Clear();
                    Console.WriteLine(">>>  Kitapları Listeleme  <<<");
                    kutuphaneYonetici.KitaplariListele();
                    Console.ReadKey();
                }
                else if (operation == 3)
                {
                    while (true)
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine(">>>  Kullanıcı Ekleme  <<<");
                            Console.Write("Kullanıcı ID: ");
                            int kullaniciID = int.Parse(Console.ReadLine());
                            Console.Write("Kullanıcı Adı: ");
                            string kullaniciAdi = Console.ReadLine();
                            Console.Write("Kullanıcı Soyadı: ");
                            string kullaniciSoyadi = Console.ReadLine();
                            Console.Write(kutuphaneYonetici.KullaniciEkle(kullaniciID, kullaniciAdi, kullaniciSoyadi));
                            Console.ReadKey();
                            break;
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message + " Devam etmek için klavyeden bir tuşa basınız."); Console.ReadKey(); }
                    }
                }
                else if (operation == 4)
                {
                    Console.Clear();
                    Console.WriteLine(">>>  Kullanıcıları Listeleme  <<<");
                    kutuphaneYonetici.KullanicilariListele();
                    Console.ReadKey();
                }
                else if (operation == 5)
                {
                    while (true)
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine(">>>  Kitap Ödünç Verme  <<<");
                            Console.Write("Kullanıcı ID: ");
                            int kullaniciID = int.Parse(Console.ReadLine());
                            Console.Write("ISBN: ");
                            string ISBN = Console.ReadLine();
                            Console.Write(kutuphaneYonetici.KitapOduncVerme(kullaniciID, ISBN));
                            Console.ReadKey();
                            break;
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message + " Devam etmek için klavyeden bir tuşa basınız."); Console.ReadKey(); }
                    }
                }
                else if (operation == 6)
                {
                    while (true)
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine(">>>  Kitap İade Alma  <<<");
                            Console.Write("Kullanıcı ID: ");
                            int kullaniciID = int.Parse(Console.ReadLine());
                            Console.Write("ISBN: ");
                            string ISBN = Console.ReadLine();
                            Console.Write(kutuphaneYonetici.KitapIadeAlma(kullaniciID, ISBN));
                            Console.ReadKey();
                            break;
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message + " Devam etmek için klavyeden bir tuşa basınız."); Console.ReadKey(); }
                    }
                }
                else if (operation == 7)
                {
                    Console.Clear();
                    Console.WriteLine(">>>  Kitapları Dosyaya Yaz  <<<");
                    Console.Write(kutuphaneYonetici.KitaplariDosyayaYaz());
                    Console.ReadKey();
                }
                else if (operation == 8)
                {
                    Console.Clear();
                    Console.WriteLine(">>>  Dosyadan Kitapları Oku  <<<");
                    Console.Write(kutuphaneYonetici.KitaplariDosyadanOku());
                    Console.ReadKey();
                }
                else if (operation == 9)
                {
                    Console.Clear();
                    Console.WriteLine(">>>  Kullanıcıları Dosyaya Yaz  <<<");
                    Console.Write(kutuphaneYonetici.KullanicilariDosyayaYaz());
                    Console.ReadKey();
                }
                else if (operation == 10)
                {
                    Console.Clear();
                    Console.WriteLine(">>>  Dosyadan Kullanıcıları Oku  <<<");
                    Console.Write(kutuphaneYonetici.KullanıcılarıDosyadanOku());
                    Console.ReadKey();
                }
                else if (operation == 11)
                {
                    goto Restart;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Yanlış işlem seçimi! Devam etmek için klavyeden bir tuşa basınız.");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); Console.ReadKey();
            }
        }
    }
}