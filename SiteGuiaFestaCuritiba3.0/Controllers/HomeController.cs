using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SiteGuiaFestaCuritiba3._0.Controllers
{
    public class HomeController : Controller
    {
        private WebService ws = new WebService();
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        [Route("Categoria/{tipo_categoria}")]
        public ActionResult Categoria(int? tipo_categoria)
        {
            if (tipo_categoria == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var r = ws.montamenuJson(tipo_categoria.ToString());
            var s = r.Replace(@"\", string.Empty);
            string rest = s.Trim().Substring(1, (s.Length) - 2);

            var menu = JsonConvert.DeserializeObject<List<Models.Menu>>(rest);
            return PartialView(menu);
        }

        [ChildActionOnly]
        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        public ActionResult BannerPrincipal()
        {
            var r = ws.montaBannerPermutaJSON(1);
            var s = r.Replace(@"\", string.Empty);
            string rest = s.Trim().Substring(1, (s.Length) - 2);

            var banner = JsonConvert.DeserializeObject<List<Models.Banner>>(rest);
            return PartialView(banner);
        }


        [ChildActionOnly]
        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        public ActionResult BannerLateral()
        {
            var r = ws.montabannerlateralJSon("2");
            var s = r.Replace(@"\", string.Empty);
            string rest = s.Trim().Substring(1, (s.Length) - 2);

            var banner = JsonConvert.DeserializeObject<List<Models.Banner>>(rest);
            return PartialView(banner);
        }

        [ChildActionOnly]
        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        public ActionResult Noticia()
        {
            var r = ws.ConsultaNoticaJson(0, "0", 1);
            var s = r.Replace(@"\", string.Empty);
            string rest = s.Trim().Substring(1, (s.Length) - 2);

            var noticia = JsonConvert.DeserializeObject<List<Models.Noticia>>(rest);             
            return PartialView(noticia);
        }      

    }
}