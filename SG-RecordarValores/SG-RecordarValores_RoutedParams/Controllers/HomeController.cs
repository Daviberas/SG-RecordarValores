using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SG_RecordarValores_RoutedParams.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? id)
        {
            ViewBag.contador = id;
            return View();
        }

        [HttpPost, ActionName("Index")]
        public ActionResult IndexPost(int? id)
        {
            int contador = 1;
            if (id != null)
            {
                contador = (int) id + 1;
            }

            return RedirectToAction("Index", new { id = contador });
        }
    }
}