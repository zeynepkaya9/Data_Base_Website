using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace YazLabProje2
{
    public class DosyaListele
    {
        public void listele(string dosyaAd)
        {
            DirectoryInfo fileInfo = new DirectoryInfo(dosyaAd);

            string[] fileArray = Directory.GetDirectories(dosyaAd);


            foreach (FileInfo e2 in fileInfo.GetFiles())
            {

                Console.WriteLine(e2.Name);
            }
            foreach (string x in fileArray)
            {
                listele(x);
            }
        }
    }
}