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
        public ActionResult SQLSearch(string komut)
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
                    sizeGB = item.sizeGB,
                    FilePath=item.FilePath
                   
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
        public ActionResult SQLAraSubmit(string komut)
        {
            string dosyaYol = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DosyaListele islemler = new DosyaListele();
            List<Dosyalar> ListeView1 = new List<Dosyalar>();
            string hataMesaj;
            string normalMesaj = komut;
            string[] CommandSplit = komut.Split(' ');
            if (CommandSplit[0] != "INSERT" && CommandSplit[0] != "SELECT" && CommandSplit[0] != "DELETE")
            {
               hataMesaj = "Syntax Hatası! İlk kelimeniz insert,select veya delete olmalıdır.";
                ViewBag.mesaj = hataMesaj;
                ListeView1.Add(new Dosyalar
                {
                    dosyaAdi = null,
                    Extension = null,
                    DateTime = null,
                    sizeKB = 0.000,
                    sizeMB = 0.000,
                    sizeGB = 0.000,
                    FilePath = null

                });

            }//Hatalı Kısım
            else
            {
                if (CommandSplit[0] == "SELECT") 
                {
                    if (CommandSplit.Length == 1)
                    {
                        hataMesaj = "SQL Yapısına Aykırı!";
                        ViewBag.mesaj = hataMesaj;
                        ListeView1.Add(new Dosyalar
                        {
                            dosyaAdi = null,
                            Extension = null,
                            DateTime = null,
                            sizeKB = 0.000,
                            sizeMB = 0.000,
                            sizeGB = 0.000,
                            FilePath = null

                        });
                    }//Hata
                    else if(CommandSplit[1] == "*") 
                    {
                        if (CommandSplit.Length == 2)
                        {
                            hataMesaj = "SQL Yapısına Aykırı!";
                            ViewBag.mesaj = hataMesaj;
                            ListeView1.Add(new Dosyalar
                            {
                                dosyaAdi = null,
                                Extension = null,
                                DateTime = null,
                                sizeKB = 0.000,
                                sizeMB = 0.000,
                                sizeGB = 0.000,
                                FilePath = null

                            });

                        }//Hatalı Kısım
                        else if (CommandSplit[2] == "from")
                        {
                            if (CommandSplit.Length == 3)
                            {
                                hataMesaj = "SQL Yapısına Aykırı!";
                                ViewBag.mesaj = hataMesaj;
                                ListeView1.Add(new Dosyalar
                                {
                                    dosyaAdi = null,
                                    Extension = null,
                                    DateTime = null,
                                    sizeKB = 0.000,
                                    sizeMB = 0.000,
                                    sizeGB = 0.000,
                                    FilePath = null

                                });

                            }//Hatalı Kısım
                            else if (CommandSplit[3] == "C:")
                            {
                                foreach (var item in islemler.listele(dosyaYol))
                                {
                                    ListeView1.Add(new Dosyalar
                                    {
                                        dosyaAdi = item.dosyaAdi,
                                        Extension = item.Extension,
                                        DateTime = item.DateTime,
                                        sizeKB = item.sizeKB,
                                        sizeMB = item.sizeMB,
                                        sizeGB = item.sizeGB,
                                        FilePath = item.FilePath

                                    });
                                    ViewBag.mesaj = normalMesaj;
                                }
                            }
                            else
                            {
                                hataMesaj = "SQL Yapısına Aykırı!";
                                ViewBag.mesaj = hataMesaj;
                                ListeView1.Add(new Dosyalar
                                {
                                    dosyaAdi = null,
                                    Extension = null,
                                    DateTime = null,
                                    sizeKB = 0.000,
                                    sizeMB = 0.000,
                                    sizeGB = 0.000,
                                    FilePath = null

                                });
                            }//Hata
                        }
                        else
                        {
                            hataMesaj = "SQL Yapısına Aykırı!";
                            ViewBag.mesaj = hataMesaj;
                            ListeView1.Add(new Dosyalar
                            {
                                dosyaAdi = null,
                                Extension = null,
                                DateTime = null,
                                sizeKB = 0.000,
                                sizeMB = 0.000,
                                sizeGB = 0.000,
                                FilePath = null

                            });
                        }//Hata


                    }
                    else if (CommandSplit[1] == "name")
                    {
                        if (CommandSplit.Length == 2)
                        {
                            hataMesaj = "SQL Yapısına Aykırı!";
                            ViewBag.mesaj = hataMesaj;
                            ListeView1.Add(new Dosyalar
                            {
                                dosyaAdi = null,
                                Extension = null,
                                DateTime = null,
                                sizeKB = 0.000,
                                sizeMB = 0.000,
                                sizeGB = 0.000,
                                FilePath = null

                            });
                        }
                        else if (CommandSplit[2] == "from")
                        {
                            if (CommandSplit.Length == 3) 
                            {
                                hataMesaj = "SQL Yapısına Aykırı!";
                                ViewBag.mesaj = hataMesaj;
                                ListeView1.Add(new Dosyalar
                                {
                                    dosyaAdi = null,
                                    Extension = null,
                                    DateTime = null,
                                    sizeKB = 0.000,
                                    sizeMB = 0.000,
                                    sizeGB = 0.000,
                                    FilePath = null

                                });
                            }//Hata
                            else if (CommandSplit[3] == "C:")
                            {
                                foreach (var item in islemler.listele(dosyaYol))
                                {
                                    ListeView1.Add(new Dosyalar
                                    {
                                        dosyaAdi = item.dosyaAdi,
                                        Extension = null,
                                        DateTime = null,
                                        sizeKB = 0.00,
                                        sizeMB = 0.00,
                                        sizeGB = 0.00,
                                        FilePath = null

                                    });
                                    ViewBag.mesaj = normalMesaj;
                                }
                            }
                            else
                            {
                                hataMesaj = "SQL Yapısına Aykırı!";
                                ViewBag.mesaj = hataMesaj;
                                ListeView1.Add(new Dosyalar
                                {
                                    dosyaAdi = null,
                                    Extension = null,
                                    DateTime = null,
                                    sizeKB = 0.000,
                                    sizeMB = 0.000,
                                    sizeGB = 0.000,
                                    FilePath = null

                                });
                            }//Hata
                        }

                    }
                    else if (CommandSplit[1] == "extension")
                    {
                        if (CommandSplit.Length == 2)
                        {
                            hataMesaj = "SQL Yapısına Aykırı!";
                            ViewBag.mesaj = hataMesaj;
                            ListeView1.Add(new Dosyalar
                            {
                                dosyaAdi = null,
                                Extension = null,
                                DateTime = null,
                                sizeKB = 0.000,
                                sizeMB = 0.000,
                                sizeGB = 0.000,
                                FilePath = null

                            });
                        }
                        else if (CommandSplit[2] == "from")
                        {
                            if (CommandSplit.Length == 3)
                            {
                                hataMesaj = "SQL Yapısına Aykırı!";
                                ViewBag.mesaj = hataMesaj;
                                ListeView1.Add(new Dosyalar
                                {
                                    dosyaAdi = null,
                                    Extension = null,
                                    DateTime = null,
                                    sizeKB = 0.000,
                                    sizeMB = 0.000,
                                    sizeGB = 0.000,
                                    FilePath = null

                                });
                            }//Hata
                            else if (CommandSplit[3] == "C:")
                            {
                                foreach (var item in islemler.listele(dosyaYol))
                                {
                                    ListeView1.Add(new Dosyalar
                                    {
                                        dosyaAdi = null,
                                        Extension = item.Extension,
                                        DateTime = null,
                                        sizeKB = 0.00,
                                        sizeMB = 0.00,
                                        sizeGB = 0.00,
                                        FilePath = null

                                    });
                                    ViewBag.mesaj = normalMesaj;
                                }
                            }
                            else
                            {
                                hataMesaj = "SQL Yapısına Aykırı!";
                                ViewBag.mesaj = hataMesaj;
                                ListeView1.Add(new Dosyalar
                                {
                                    dosyaAdi = null,
                                    Extension = null,
                                    DateTime = null,
                                    sizeKB = 0.000,
                                    sizeMB = 0.000,
                                    sizeGB = 0.000,
                                    FilePath = null

                                });
                            }//Hata
                        }


                    }
                    else if (CommandSplit[1] == "date")
                    {
                        if (CommandSplit.Length == 2)
                        {
                            hataMesaj = "SQL Yapısına Aykırı!";
                            ViewBag.mesaj = hataMesaj;
                            ListeView1.Add(new Dosyalar
                            {
                                dosyaAdi = null,
                                Extension = null,
                                DateTime = null,
                                sizeKB = 0.000,
                                sizeMB = 0.000,
                                sizeGB = 0.000,
                                FilePath = null

                            });
                        }
                        else if (CommandSplit[2] == "from")
                        {
                            if (CommandSplit.Length == 3)
                            {
                                hataMesaj = "SQL Yapısına Aykırı!";
                                ViewBag.mesaj = hataMesaj;
                                ListeView1.Add(new Dosyalar
                                {
                                    dosyaAdi = null,
                                    Extension = null,
                                    DateTime = null,
                                    sizeKB = 0.000,
                                    sizeMB = 0.000,
                                    sizeGB = 0.000,
                                    FilePath = null

                                });
                            }//Hata
                            else if (CommandSplit[3] == "C:")
                            {
                                foreach (var item in islemler.listele(dosyaYol))
                                {
                                    ListeView1.Add(new Dosyalar
                                    {
                                        dosyaAdi = null,
                                        Extension = null,
                                        DateTime = item.DateTime,
                                        sizeKB = 0.00,
                                        sizeMB = 0.00,
                                        sizeGB = 0.00,
                                        FilePath = null

                                    });
                                    ViewBag.mesaj = normalMesaj;
                                }
                            }
                            else
                            {
                                hataMesaj = "SQL Yapısına Aykırı!";
                                ViewBag.mesaj = hataMesaj;
                                ListeView1.Add(new Dosyalar
                                {
                                    dosyaAdi = null,
                                    Extension = null,
                                    DateTime = null,
                                    sizeKB = 0.000,
                                    sizeMB = 0.000,
                                    sizeGB = 0.000,
                                    FilePath = null

                                });
                            }//Hata
                        }

                    }
                    else if (CommandSplit[1] == "sizeKB")
                    {
                        if (CommandSplit.Length == 2)
                        {
                            hataMesaj = "SQL Yapısına Aykırı!";
                            ViewBag.mesaj = hataMesaj;
                            ListeView1.Add(new Dosyalar
                            {
                                dosyaAdi = null,
                                Extension = null,
                                DateTime = null,
                                sizeKB = 0.000,
                                sizeMB = 0.000,
                                sizeGB = 0.000,
                                FilePath = null

                            });
                        }
                        else if (CommandSplit[2] == "from")
                        {
                            if (CommandSplit.Length == 3)
                            {
                                hataMesaj = "SQL Yapısına Aykırı!";
                                ViewBag.mesaj = hataMesaj;
                                ListeView1.Add(new Dosyalar
                                {
                                    dosyaAdi = null,
                                    Extension = null,
                                    DateTime = null,
                                    sizeKB = 0.000,
                                    sizeMB = 0.000,
                                    sizeGB = 0.000,
                                    FilePath = null

                                });
                            }//Hata
                            else if (CommandSplit[3] == "C:")
                            {
                                foreach (var item in islemler.listele(dosyaYol))
                                {
                                    ListeView1.Add(new Dosyalar
                                    {
                                        dosyaAdi = null,
                                        Extension = null,
                                        DateTime = null,
                                        sizeKB = item.sizeKB,
                                        sizeMB = 0.00,
                                        sizeGB = 0.00,
                                        FilePath = null

                                    });
                                    ViewBag.mesaj = normalMesaj;
                                }
                            }
                            else
                            {
                                hataMesaj = "SQL Yapısına Aykırı!";
                                ViewBag.mesaj = hataMesaj;
                                ListeView1.Add(new Dosyalar
                                {
                                    dosyaAdi = null,
                                    Extension = null,
                                    DateTime = null,
                                    sizeKB = 0.000,
                                    sizeMB = 0.000,
                                    sizeGB = 0.000,
                                    FilePath = null

                                });
                            }//Hata
                        }

                    }
                    else if (CommandSplit[1] == "sizeMB")
                    {
                        if (CommandSplit.Length == 2)
                        {
                            hataMesaj = "SQL Yapısına Aykırı!";
                            ViewBag.mesaj = hataMesaj;
                            ListeView1.Add(new Dosyalar
                            {
                                dosyaAdi = null,
                                Extension = null,
                                DateTime = null,
                                sizeKB = 0.000,
                                sizeMB = 0.000,
                                sizeGB = 0.000,
                                FilePath = null

                            });
                        }
                        else if (CommandSplit[2] == "from")
                        {
                            if (CommandSplit.Length == 3)
                            {
                                hataMesaj = "SQL Yapısına Aykırı!";
                                ViewBag.mesaj = hataMesaj;
                                ListeView1.Add(new Dosyalar
                                {
                                    dosyaAdi = null,
                                    Extension = null,
                                    DateTime = null,
                                    sizeKB = 0.000,
                                    sizeMB = 0.000,
                                    sizeGB = 0.000,
                                    FilePath = null

                                });
                            }//Hata
                            else if (CommandSplit[3] == "C:")
                            {
                                foreach (var item in islemler.listele(dosyaYol))
                                {
                                    ListeView1.Add(new Dosyalar
                                    {
                                        dosyaAdi = null,
                                        Extension = null,
                                        DateTime = null,
                                        sizeKB = 0.00,
                                        sizeMB = item.sizeMB,
                                        sizeGB = 0.00,
                                        FilePath = null

                                    });
                                    ViewBag.mesaj = normalMesaj;
                                }
                            }
                            else
                            {
                                hataMesaj = "SQL Yapısına Aykırı!";
                                ViewBag.mesaj = hataMesaj;
                                ListeView1.Add(new Dosyalar
                                {
                                    dosyaAdi = null,
                                    Extension = null,
                                    DateTime = null,
                                    sizeKB = 0.000,
                                    sizeMB = 0.000,
                                    sizeGB = 0.000,
                                    FilePath = null

                                });
                            }//Hata
                        }
                    }
                    else if (CommandSplit[1] == "sizeGB")
                    {
                        if (CommandSplit.Length == 2)
                        {
                            hataMesaj = "SQL Yapısına Aykırı!";
                            ViewBag.mesaj = hataMesaj;
                            ListeView1.Add(new Dosyalar
                            {
                                dosyaAdi = null,
                                Extension = null,
                                DateTime = null,
                                sizeKB = 0.000,
                                sizeMB = 0.000,
                                sizeGB = 0.000,
                                FilePath = null

                            });
                        }
                        else if (CommandSplit[2] == "from")
                        {
                            if (CommandSplit.Length == 3)
                            {
                                hataMesaj = "SQL Yapısına Aykırı!";
                                ViewBag.mesaj = hataMesaj;
                                ListeView1.Add(new Dosyalar
                                {
                                    dosyaAdi = null,
                                    Extension = null,
                                    DateTime = null,
                                    sizeKB = 0.000,
                                    sizeMB = 0.000,
                                    sizeGB = 0.000,
                                    FilePath = null

                                });
                            }//Hata
                            else if (CommandSplit[3] == "C:")
                            {
                                foreach (var item in islemler.listele(dosyaYol))
                                {
                                    ListeView1.Add(new Dosyalar
                                    {
                                        dosyaAdi = null,
                                        Extension = null,
                                        DateTime = null,
                                        sizeKB = 0.00,
                                        sizeMB = 0.00,
                                        sizeGB = item.sizeGB,
                                        FilePath = null

                                    });
                                    ViewBag.mesaj = normalMesaj;
                                }
                            }
                            else
                            {
                                hataMesaj = "SQL Yapısına Aykırı!";
                                ViewBag.mesaj = hataMesaj;
                                ListeView1.Add(new Dosyalar
                                {
                                    dosyaAdi = null,
                                    Extension = null,
                                    DateTime = null,
                                    sizeKB = 0.000,
                                    sizeMB = 0.000,
                                    sizeGB = 0.000,
                                    FilePath = null

                                });
                            }//Hata
                        }
                    }
                    else if (CommandSplit[1] == "filepath")
                    {
                        if (CommandSplit.Length == 2)
                        {
                            hataMesaj = "SQL Yapısına Aykırı!";
                            ViewBag.mesaj = hataMesaj;
                            ListeView1.Add(new Dosyalar
                            {
                                dosyaAdi = null,
                                Extension = null,
                                DateTime = null,
                                sizeKB = 0.000,
                                sizeMB = 0.000,
                                sizeGB = 0.000,
                                FilePath = null

                            });
                        }
                        else if (CommandSplit[2] == "from")
                        {
                            if (CommandSplit.Length == 3)
                            {
                                hataMesaj = "SQL Yapısına Aykırı!";
                                ViewBag.mesaj = hataMesaj;
                                ListeView1.Add(new Dosyalar
                                {
                                    dosyaAdi = null,
                                    Extension = null,
                                    DateTime = null,
                                    sizeKB = 0.000,
                                    sizeMB = 0.000,
                                    sizeGB = 0.000,
                                    FilePath = null

                                });
                            }//Hata
                            else if (CommandSplit[3] == "C:")
                            {
                                foreach (var item in islemler.listele(dosyaYol))
                                {
                                    ListeView1.Add(new Dosyalar
                                    {
                                        dosyaAdi = null,
                                        Extension = null,
                                        DateTime = null,
                                        sizeKB = 0.00,
                                        sizeMB = 0.00,
                                        sizeGB = 0.00,
                                        FilePath = item.FilePath

                                    });
                                    ViewBag.mesaj = normalMesaj;
                                }
                            }
                            else
                            {
                                hataMesaj = "SQL Yapısına Aykırı!";
                                ViewBag.mesaj = hataMesaj;
                                ListeView1.Add(new Dosyalar
                                {
                                    dosyaAdi = null,
                                    Extension = null,
                                    DateTime = null,
                                    sizeKB = 0.000,
                                    sizeMB = 0.000,
                                    sizeGB = 0.000,
                                    FilePath = null

                                });
                            }//Hata
                        }
                    }
                    else
                    {
                        hataMesaj = "SQL Yapısına Aykırı!";
                        ViewBag.mesaj = hataMesaj;
                        ListeView1.Add(new Dosyalar
                        {
                            dosyaAdi = null,
                            Extension = null,
                            DateTime = null,
                            sizeKB = 0.000,
                            sizeMB = 0.000,
                            sizeGB = 0.000,
                            FilePath = null

                        });
                    }//Hata


                }
                else if (CommandSplit[0] == "INSERT")
                {

                }
                else if (CommandSplit[0] == "DELETE")
                {

                }

            }



            

            return View(ListeView1);
        }

    }
}