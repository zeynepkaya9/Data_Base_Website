using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace YazLabProje2.Models
{
    public class Dosyalar
    {

        public string dosyaAdi { get; set; }
        public string Extension { get; set; }
        public string DateTime { get; set; }
        public string FilePath { get; set; }

        public double sizeKB  { get; set; }
        public double sizeMB { get; set; }
        public double sizeGB { get; set; }




    }
}