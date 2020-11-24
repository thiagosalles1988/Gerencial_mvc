using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gerencial.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Sistema Gerencial";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Desenvolvido por Thiago A. Salles";

            return View();
        }
    }
}