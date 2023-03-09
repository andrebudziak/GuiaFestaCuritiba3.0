using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SiteGuiaFestaCuritiba3._0.Controllers
{
    public class AnuncioController : Controller
    {
        // GET: Anuncio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Incluir_Anuncio(int? id, string SearchCliente, string nome, Models.Anuncio a)
        {
            ViewBag.Id_Cliente = id;
            ViewBag.searchCli = SearchCliente;
            ViewBag.NomeCliente = nome;

            int pageSize = 5;
            int totalpages = 0;
            int totalRecords = 0;

            if (a.iCliente == null)
            {
                Models.Cliente c = new Models.Cliente();
                if (!String.IsNullOrEmpty(SearchCliente))
                {
                    a.iCliente = c.Listar(0, SearchCliente);
                }
                else
                {
                    a.iCliente = c.Listar(0, "0");
                }
            }

            //counts number of files in db
            totalRecords = Convert.ToInt32(a.iCliente.Count.ToString());
            //calculates number of pages that can be formed with pagesize=5
            totalpages = (totalRecords / pageSize) + ((totalRecords % pageSize) > 0 ? 1 : 0);

            ViewBag.TotalRows = totalRecords;
            ViewBag.PageSize = pageSize;

            return PartialView("~/Views/Admin/Anuncio/Create.cshtml", a);

        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Salvar_Anuncio(Models.Anuncio a, string command, string SearchCliente,int? idCliente)
        {

            int pageSize = 5;
            int totalpages = 0;
            int totalRecords = 0;
            List<Models.Anuncio> res = new List<Models.Anuncio>();

            if (command == "Salvar")
            {
                if (a != null)
                {
                    if (ViewBag.Id_Cliente != null)
                        a.codigo_cliente = ViewBag.Id_Cliente;

                    a.Salvar(a);
                }
                res = a.Listar(0, "0");

                return View("~/Views/Admin/Anuncio/Index.cshtml", res);

            }
            if (command == "Pesquisar")
            {

                if (a.iCliente == null)
                {
                    Models.Cliente c = new Models.Cliente();
                    if (!String.IsNullOrEmpty(SearchCliente))
                    {
                        a.iCliente = c.Listar(0, SearchCliente);
                    }
                    else
                    {
                        a.iCliente = c.Listar(0, "0");
                    }
                }

                //counts number of files in db
                totalRecords = Convert.ToInt32(a.iCliente.Count.ToString());
                //calculates number of pages that can be formed with pagesize=5
                totalpages = (totalRecords / pageSize) + ((totalRecords % pageSize) > 0 ? 1 : 0);

                ViewBag.TotalRows = totalRecords;
                ViewBag.PageSize = totalpages;

                return PartialView("_BuscaCliente", a.iCliente);
            }

            return (null);

        }
        public ActionResult Editar_Anuncio(int id)
        {
            Models.Anuncio a = new Models.Anuncio();
            a = a.Editar(id);

            return View("~/Views/Admin/Anuncio/Edit.cshtml", a);
        }

        public ActionResult Excluir_Anuncio(int id)
        {
            Models.Anuncio a = new Models.Anuncio();

            a.Excluir(id);

            List<Models.Anuncio> res = new List<Models.Anuncio>();
            res = a.Listar(0, "0");

            return View("~/Views/Admin/Anuncio/Index.cshtml", res);
        }

        public ActionResult Listar_Anuncio(string searchString)
        {
            ViewBag.CurrentFilter = searchString;

            Models.Anuncio a = new Models.Anuncio();

            List<Models.Anuncio> res = new List<Models.Anuncio>();

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


            return View("~/Views/Admin/Anuncio/Index.cshtml", res);
        }


    }
}