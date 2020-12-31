using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YazLabProje2.Controllers
{
    public class AnaController : Controller
    {
        // GET: Ana
        public ViewResult Index()
        {
            return View();
        }
        public ActionResult WindowsSearch()
        {
            return View();
        }
        public ActionResult SQLSearch()
        {
          
            return View();
        }
    }
}