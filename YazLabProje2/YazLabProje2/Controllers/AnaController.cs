using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YazLabProje2.Models;

namespace YazLabProje2.Controllers
{
    public class AnaController : Controller
    {
        // GET: Ana

        public ViewResult Index()
        {
            return View();
        }
        public ActionResult WindowsSearch(string aranan)
        {
            string dosyaYol = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DosyaListele islemler = new DosyaListele();
            List<Dosyalar> ListeView2 = new List<Dosyalar>();
            foreach (var item in islemler.listele2(dosyaYol))
            {
                ListeView2.Add(new Dosyalar { dosyaAdi = item.dosyaAdi });

            }
            return View(ListeView2);
        }
        public ActionResult SQLSearch()
        {
            string dosyaYol= Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DosyaListele islemler = new DosyaListele();
            List<Dosyalar> ListeView1 = new List<Dosyalar>();
            foreach (var item in islemler.listele(dosyaYol))
            {
                ListeView1.Add(new Dosyalar { dosyaAdi = item.dosyaAdi, 
                    Extension=item.Extension,
                    DateTime=item.DateTime,
                    sizeKB=item.sizeKB, 
                    sizeMB=item.sizeMB,
                    sizeGB = item.sizeGB
                });


            }


            return View(ListeView1);
        }
        public ViewResult WindowsAraSubmit(string aranan)
        {

            List<Dosyalar> ListeView3 = new List<Dosyalar>();
            DosyaListele islemler = new DosyaListele();
            foreach (var item in islemler.WindowsAra(aranan))
            {
                ListeView3.Add(new Dosyalar { dosyaAdi = item.dosyaAdi });

            }
            return View(ListeView3);
        }
    }
}