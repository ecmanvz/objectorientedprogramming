/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2014-2015 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: 01
**				ÖĞRENCİ ADI............: ECEM AMANVERMEZ
**				ÖĞRENCİ NUMARASI.......: G181210022
**              DERSİN ALINDIĞI GRUP...: 1B
****************************************************************************/







using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;            //dosya islemleri icin gerekli kutuphane 

namespace odev1
{
    class Ogrenci               //sınıf olusturdum
    {
        public string ad, soyad, numara, harfNotu;              //degiskenleri tanimladim
        public double odev1, odev2, vize, final, ortalama;
        public double odev1Yuzde, odev2Yuzde, vizeYuzde, finalYuzde;

        public void Oku(Ogrenci ogr , string yazi)          //text okumak icin bir metot tanımladım
        {
      

            string[] dizi = yazi.Split(' ');                //satır satır okumak icin

            ogr.ad = dizi[0];                               //satirdaki degiskenleri okumasi icin dizi olusturdum
            ogr.soyad = dizi[1];
            ogr.numara = dizi[2];
            ogr.odev1 = Double.Parse(dizi[3]);
            ogr.odev2 = Double.Parse(dizi[4]);
            ogr.vize = Double.Parse(dizi[5]);
            ogr.final = Double.Parse(dizi[6]);
            ogr.odev1Yuzde = Double.Parse(dizi[7]);
            ogr.odev2Yuzde = Double.Parse(dizi[8]);
            ogr.vizeYuzde = Double.Parse(dizi[9]);
            ogr.finalYuzde = Double.Parse(dizi[10]);
        }

        public int KayitSay()       //sinif mevcudunu saymasi icin bir metot olusturdum
        {
            int kayitSayisi = 0;
            string dosyaYolu = @"C:\Users\ECEM\Desktop\kayit.txt";      //text dosyasinin kayit yerini belirttim 
            FileStream fs = new FileStream(dosyaYolu, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string yazi = sr.ReadLine();


            while (yazi != null)        //kayitlari saymasi icin dongu olusturdum
            {
                kayitSayisi++;
                yazi = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
            return kayitSayisi;

        }

        public void Hesapla(Ogrenci ogr)        //ogrencilerin notlarini hesaplamak icin metot
        {
            ogr.ortalama = ogr.odev1 * (ogr.odev1Yuzde / 100) + ogr.odev2 * (ogr.odev2Yuzde / 100) + ogr.vize * (ogr.vizeYuzde / 100) + ogr.final * (ogr.finalYuzde / 100);

            if(ogr.ortalama <=100 && ogr.ortalama >=90)
            {
                ogr.harfNotu = "AA";
            }
            else if(ogr.ortalama <90  && ogr.ortalama >=85)
            {
                ogr.harfNotu = "BA";
            }
            else if(ogr.ortalama < 85 && ogr.ortalama >= 80)
            {
                ogr.harfNotu = "BB";
            }
            else if (ogr.ortalama < 80 && ogr.ortalama >= 75)
            {
                ogr.harfNotu = "CB";
            }
            else if (ogr.ortalama <75 && ogr.ortalama >= 65)
            {
                ogr.harfNotu = "CC";
            }
            else if(ogr.ortalama < 65 && ogr.ortalama >= 58)
            {
                ogr.harfNotu = "DC";
            }
            else if(ogr.ortalama < 58 && ogr.ortalama >= 50)
            {
                ogr.harfNotu = "DD";
            }
            else if(ogr.ortalama < 50 && ogr.ortalama >= 40)
            {
                ogr.harfNotu = "FD";
            }
            else 
            {
                ogr.harfNotu = "FF";
            }
        }

        public void Istatistik(Ogrenci[] ogrler)                //sinif istatistigini hesaplamak icin metot
        {
            double AA = 0, BA = 0, BB = 0, CB = 0, CC = 0, DC = 0, DD = 0, FD = 0, FF = 0;
            for (int i = 0; i < ogrler.Length; i++)             //harf notlarini saymasi icin dongu olusturdum
            {

                if (ogrler[i].harfNotu=="AA")
                {
                    AA++;
                }
                else if(ogrler[i].harfNotu == "BA")
                {
                    BA++;
                }
                else if(ogrler[i].harfNotu == "BB")
                {
                    BB++;
                }
                else if(ogrler[i].harfNotu == "CB")
                {
                    CB++;
                }
                else if(ogrler[i].harfNotu == "CC")
                {
                    CC++;
                }
                else if(ogrler[i].harfNotu == "DC")
                {
                    DC++;
                }
                else if(ogrler[i].harfNotu == "DD")
                {
                    DD++;
                }
                else if (ogrler[i].harfNotu == "FD")
                {
                    FD++;
                }
                else 
                {
                    FF++;
                }

            }

            //ekrana sinif istatistigini hesaplayip yazdirmak ve harf notu sayisini yazdirmak icin
            Console.WriteLine("AA Alan Öğrenci Sayisi :{0}, Yüzdesi : %{1}", AA,(AA / ogrler.Count()) * 100);
            Console.WriteLine("BA Alan Öğrenci Sayisi :{0}, Yüzdesi : %{1}", BA,(BA / ogrler.Count()) * 100);
            Console.WriteLine("BB Alan Öğrenci Sayisi :{0}, Yüzdesi : %{1}", BB,(BB / ogrler.Count()) * 100);
            Console.WriteLine("CB Alan Öğrenci Sayisi :{0}, Yüzdesi : %{1}", CB,(CB / ogrler.Count()) * 100);
            Console.WriteLine("CC Alan Öğrenci Sayisi :{0}, Yüzdesi : %{1}", CC,(CC / ogrler.Count()) * 100);
            Console.WriteLine("DC Alan Öğrenci Sayisi :{0}, Yüzdesi : %{1}", DC,(DC / ogrler.Count()) * 100);
            Console.WriteLine("DD Alan Öğrenci Sayisi :{0}, Yüzdesi : %{1}", DD,(DD / ogrler.Count()) * 100);
            Console.WriteLine("FD Alan Öğrenci Sayisi :{0}, Yüzdesi : %{1}", FD,(FD / ogrler.Count()) * 100);
            Console.WriteLine("FF Alan Öğrenci Sayisi :{0}, Yüzdesi : %{1}", FF,(FF / ogrler.Count()) * 100);

        }

        public void Process(Ogrenci ogr , Ogrenci[] ogrenciler , int sayi)
        {
            string dosyaYolu = @"C:\Users\ECEM\Desktop\kayit.txt";          //dosya yolunu belirttim
            FileStream fs = new FileStream(dosyaYolu, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string yazi;  

            for (int i = 0; i < sayi; i++)          //ogrencileri sayan ve istatistik hesaplayan fonksiyonlar icin döngü olusturdum 
            {
               yazi = sr.ReadLine();
             
                ogr.Oku(ogr,yazi);
                ogr.Hesapla(ogr);
                ogrenciler[i] = ogr;
                ogr = new Ogrenci();

            }

            ogr.Istatistik(ogrenciler);
            Console.ReadKey();
        }

    }

    class Program       //ogrenci nesnesi icin yeni sınıf 
    {

        static void Main(string[] args)       
        {
            Ogrenci ogr = new Ogrenci();        //ogrenci sinifindan yeni ogrenci nesnesi olusturdum

            int sayi = ogr.KayitSay();
            
            Ogrenci[] ogrenciler = new Ogrenci[sayi]; 

            ogr.Process(ogr, ogrenciler, sayi);
           

        }
    }
}
