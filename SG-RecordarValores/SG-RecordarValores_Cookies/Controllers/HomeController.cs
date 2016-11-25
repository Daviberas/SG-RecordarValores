using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SG_RecordarValores_Cookies.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (!Request.Cookies.AllKeys.Contains("contador"))
            {
                HttpCookie cookie = new HttpCookie("contador", "0");
                cookie.Expires = DateTime.Now.AddDays(7);

                Response.Cookies.Add(cookie);

                ViewBag.contador = 0;
            }
            else
            {
                HttpCookie cookie = Request.Cookies["contador"];

                ViewBag.contador = Convert.ToInt32(cookie.Value);
            }

            return View();
        }

        [HttpPost, ActionName("Index")]
        public ActionResult IndexPost()
        {
            HttpCookie cookie = Request.Cookies["contador"];

            int contador = Convert.ToInt32(cookie.Value);
            contador++;

            ViewBag.contador = contador;

            cookie.Value = Convert.ToString(contador);
            cookie.Expires = DateTime.Now.AddDays(7);
            Response.SetCookie(cookie);

            return View();
        }
    }
}