using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Tokenizer;

namespace SiteGuiaFestaCuritiba3._0.Controllers
{
    public class CategoriaController : Controller
    {

        private WebService ws = new WebService();
        // GET: Categoria
        public ActionResult Index(string categoria = "0",int id = 0, string ord = "0")
        {
            if (categoria == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.Categoria = categoria;
            ViewBag.Categoria_id = id;

            SiteGuiaFestaCuritiba3._0.Models.Anuncio a = new Models.Anuncio();

            List<SiteGuiaFestaCuritiba3._0.Models.Anuncio> res = new List<Models.Anuncio>();

            if (ord !="0")
                res = a.OrdenarTela(ViewBag.Categoria_id, "0", ord);
            else
               res = a.ListarTela(id, "0");

            return View(res);
        }


    }
}