
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hospital2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Doktorlarimiz()
        {
            return View();
        }
        public ActionResult Kurumsal()
        {
            return View();
        }
        public ActionResult KalitePolitikamiz()
        {
            return View();
        } 
        public ActionResult MisyonVizyon()
        {
            return View();
        }
        public ActionResult Randevu()
        {
            return View();
        }
        public ActionResult Sonuclar()
        {
            return View();
        }
        public ActionResult SHKS()
        {
            return View();
        }
        public ActionResult Iletisim()
        {
            return View();
        }
        public ActionResult KayitOl()
        {
            return View();
        }
    }
}