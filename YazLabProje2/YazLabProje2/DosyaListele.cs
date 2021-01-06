using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using YazLabProje2.Models;


namespace YazLabProje2
{
    public class DosyaListele
    {
        List<Dosyalar> dosyaIsimler = new List<Dosyalar>();
        public List<Dosyalar> listele(string dosyaAd)
        {
           
            DirectoryInfo fileInfo = new DirectoryInfo(dosyaAd);

            string[] fileArray = Directory.GetDirectories(dosyaAd);


            foreach (FileInfo e2 in fileInfo.GetFiles())
            {

                dosyaIsimler.Add(new Dosyalar { dosyaAdi = e2.Name,
                    Extension = e2.Extension, 
                    DateTime = e2.LastWriteTime.ToShortDateString(),
                    sizeKB = e2.Length / 1024.0,
                    sizeMB = e2.Length / 1048576.0,
                    sizeGB = e2.Length / 1073741824.0
                });

            }
            foreach (string x in fileArray)
            {
                listele(x);
            }

            return dosyaIsimler;
        }
        public List<Dosyalar> Waranandosya = new List<Dosyalar>();
        public List<Dosyalar> WindowsAra(string aranan)
        {
            string dosyaYol = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            foreach (var x in listele2(dosyaYol))
            {
                if (aranan == x.dosyaAdi)
                {
                    Waranandosya.Add(new Dosyalar { dosyaAdi = x.dosyaAdi });
                }
            }
            return Waranandosya;

        }

        public List<Dosyalar> listele2(string dosyaAd)
        {

            DirectoryInfo fileInfo = new DirectoryInfo(dosyaAd);

            string[] fileArray = Directory.GetDirectories(dosyaAd);


            foreach (FileInfo e2 in fileInfo.GetFiles())
            {

                dosyaIsimler.Add(new Dosyalar { dosyaAdi = e2.Name });

            }
            foreach (string x in fileArray)
            {
                listele2(x);
            }

            return dosyaIsimler;
        }

    }
}