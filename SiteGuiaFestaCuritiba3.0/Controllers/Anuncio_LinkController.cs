using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteGuiaFestaCuritiba3._0.Controllers
{
    public class Anuncio_LinkController : Controller
    {
        // GET: Anuncio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Incluir_Link(int? id, string SearchCliente, string nome, Models.Anuncio_Link a)
        {
            ViewBag.Id_Cliente = id;
            ViewBag.searchCli = SearchCliente;
            ViewBag.NomeCliente = nome;

            int pageSize = 5;
            int totalpages = 0;
            int totalRecords = 0;

            if (a.iAnuncio == null)
            {
                Models.Anuncio c = new Models.Anuncio();
                if (!String.IsNullOrEmpty(SearchCliente))
                {
                    a.iAnuncio = c.Listar(0, SearchCliente);
                }
                else
                {
                    a.iAnuncio = c.Listar(0, "0");
                }
            }

            //counts number of files in db
            totalRecords = Convert.ToInt32(a.iAnuncio.Count.ToString());
            //calculates number of pages that can be formed with pagesize=5
            totalpages = (totalRecords / pageSize) + ((totalRecords % pageSize) > 0 ? 1 : 0);

            ViewBag.TotalRows = totalRecords;
            ViewBag.PageSize = pageSize;

            return PartialView("~/Views/Admin/Link_Anuncio/Create.cshtml", a);

        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Salvar_Link(Models.Anuncio_Link a, string command, string SearchCliente, int? idCliente)
        {

            int pageSize = 5;
            int totalpages = 0;
            int totalRecords = 0;
            List<Models.Anuncio_Link> res = new List<Models.Anuncio_Link>();

            if (command == "Salvar")
            {
                if (a != null)
                {
                    if (ViewBag.Id_Cliente != null)
                        a.codigo_anuncio = ViewBag.Id_Cliente;

                    a.Salvar(a);
                }
                res = a.Listar(0, "0");

                return View("~/Views/Admin/Link_Anuncio/Index.cshtml", res);

            }
            if (command == "Pesquisar")
            {

                if (a.iAnuncio == null)
                {
                    Models.Anuncio c = new Models.Anuncio();
                    if (!String.IsNullOrEmpty(SearchCliente))
                    {
                        a.iAnuncio = c.Listar(0, SearchCliente);
                    }
                    else
                    {
                        a.iAnuncio = c.Listar(0, "0");
                    }
                }

                //counts number of files in db
                totalRecords = Convert.ToInt32(a.iAnuncio.Count.ToString());
                //calculates number of pages that can be formed with pagesize=5
                totalpages = (totalRecords / pageSize) + ((totalRecords % pageSize) > 0 ? 1 : 0);

                ViewBag.TotalRows = totalRecords;
                ViewBag.PageSize = totalpages;

                return PartialView("_BuscaAnuncio", a.iAnuncio);
            }

            return (null);

        }
        public ActionResult Editar_Link(int id)
        {
            Models.Anuncio_Link a = new Models.Anuncio_Link();
            a = a.Editar(id);

            return View("~/Views/Admin/Link_Anuncio/Edit.cshtml", a);
        }

        public ActionResult Excluir_Link(int id)
        {
            Models.Anuncio_Link a = new Models.Anuncio_Link();

            a.Excluir(id);

            List<Models.Anuncio_Link> res = new List<Models.Anuncio_Link>();
            res = a.Listar(0, "0");

            return View("~/Views/Admin/Link_Anuncio/Index.cshtml", res);
        }

        public ActionResult Listar_Link(string searchString)
        {
            ViewBag.CurrentFilter = searchString;

            Models.Anuncio_Link a = new Models.Anuncio_Link();

            List<Models.Anuncio_Link> res = new List<Models.Anuncio_Link>();

            int pageSize = 20;
            int totalpages = 0;
            int totalRecords = 0;

            if (!String.IsNullOrEmpty(searchString))
            {
                res = a.Listar(0, searchString);
                //counts number of files in db
                totalRecords = Convert.ToInt32(res.Count.ToString());
                //calculates number of pages that can be formed with pagesize=5
                totalpages = (totalRecords / pageSize) + ((totalRecords % pageSize) > 0 ? 1 : 0);

            }
            else
            {
                res = a.Listar(0, "0");
                //counts number of files in db
                totalRecords = Convert.ToInt32(res.Count.ToString());
                //calculates number of pages that can be formed with pagesize=5
                totalpages = (totalRecords / pageSize) + ((totalRecords % pageSize) > 0 ? 1 : 0);
            }

            ViewBag.TotalRows = totalRecords;
            ViewBag.PageSize = pageSize;


            return View("~/Views/Admin/Link_Anuncio/Index.cshtml", res);
        }

    }
}