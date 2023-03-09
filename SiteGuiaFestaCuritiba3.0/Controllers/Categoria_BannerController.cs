using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteGuiaFestaCuritiba3._0.Controllers
{
    public class Categoria_BannerController : Controller
    {
        // GET: Anuncio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Incluir_Categoria_Banner(int? id, string SearchCliente, string nome, Models.Banner a)
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

            if (a.iLocalBanner == null)
            {
                Models.Local_Banner c = new Models.Local_Banner();
                if (!String.IsNullOrEmpty(SearchCliente))
                {
                    a.iLocalBanner = c.Listar(0, SearchCliente);
                }
                else
                {
                    a.iLocalBanner = c.Listar(0, "0");
                }
            }

            //counts number of files in db
            totalRecords = Convert.ToInt32(a.iCliente.Count.ToString());
            //calculates number of pages that can be formed with pagesize=5
            totalpages = (totalRecords / pageSize) + ((totalRecords % pageSize) > 0 ? 1 : 0);

            ViewBag.TotalRows = totalRecords;
            ViewBag.PageSize = pageSize;

            return PartialView("~/Views/Admin/Categoria_Banner/Create.cshtml", a);

        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Salvar_Categoria_Banner(Models.Banner a, string command, string SearchCliente, int? idCliente)
        {

            int pageSize = 5;
            int totalpages = 0;
            int totalRecords = 0;
            List<Models.Banner> res = new List<Models.Banner>();

            if (command == "Salvar")
            {
                if (a != null)
                {
                    if (ViewBag.Id_Cliente != null)
                        a.codigo_cliente = ViewBag.Id_Cliente;
                    List<Models.Banner> b = new List<Models.Banner>();
                    b = a.Listar(a.codigo, "0");
                    if (a.descricao == null)
                        a.descricao = b[0].descricao;

                    a.Salvar(a);
                }
                res = a.Listar(0, "0");

                return View("~/Views/Admin/Categoria_Banner/Index.cshtml", res);

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

            if (command == "PesquisarLocal")
            {

                if (a.iLocalBanner == null)
                {
                    Models.Local_Banner c = new Models.Local_Banner();
                    if (!String.IsNullOrEmpty(SearchCliente))
                    {
                        a.iLocalBanner = c.Listar(0, SearchCliente);
                    }
                    else
                    {
                        a.iLocalBanner = c.Listar(0, "0");
                    }
                }

                //counts number of files in db
                totalRecords = Convert.ToInt32(a.iLocalBanner.Count.ToString());
                //calculates number of pages that can be formed with pagesize=5
                totalpages = (totalRecords / pageSize) + ((totalRecords % pageSize) > 0 ? 1 : 0);

                ViewBag.TotalRows = totalRecords;
                ViewBag.PageSize = totalpages;

                return PartialView("_BuscaLocal", a.iLocalBanner);
            }

            return (null);

        }
        public ActionResult Editar_Categoria_Banner(int id)
        {
            int pageSize = 5;
            int totalpages = 0;
            int totalRecords = 0;

            Models.Banner a = new Models.Banner();

            a = a.Editar(id);

            if (a.iCliente == null)
            {
                Models.Cliente c = new Models.Cliente();
                a.iCliente = c.Listar(a.codigo_cliente, "0");
            }

            //counts number of files in db
            totalRecords = Convert.ToInt32(a.iCliente.Count.ToString());
            //calculates number of pages that can be formed with pagesize=5
            totalpages = (totalRecords / pageSize) + ((totalRecords % pageSize) > 0 ? 1 : 0);

            ViewBag.TotalRows = totalRecords;
            ViewBag.PageSize = pageSize;

            if (a.iLocalBanner == null)
            {
                Models.Local_Banner c = new Models.Local_Banner();
                a.iLocalBanner = c.Listar(0, "0");
            }

            //counts number of files in db
            totalRecords = Convert.ToInt32(a.iCliente.Count.ToString());
            //calculates number of pages that can be formed with pagesize=5
            totalpages = (totalRecords / pageSize) + ((totalRecords % pageSize) > 0 ? 1 : 0);

            ViewBag.TotalRows = totalRecords;
            ViewBag.PageSize = pageSize;

            return View("~/Views/Admin/Categoria_Banner/Edit.cshtml", a);
        }

        public ActionResult Excluir_Categoria_Banner(int id)
        {
            Models.Banner a = new Models.Banner();

            a.Excluir(id);

            List<Models.Banner> res = new List<Models.Banner>();
            res = a.Listar(0, "0");

            return View("~/Views/Admin/Categoria_Banner/Index.cshtml", res);
        }

        public ActionResult Listar_Categoria_Banner(string searchString)
        {
            ViewBag.CurrentFilter = searchString;

            Models.Categoria_Banner a = new Models.Categoria_Banner();

            List<Models.Categoria_Banner> res = new List<Models.Categoria_Banner>();

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


            return View("~/Views/Admin/Categoria_Banner/Index.cshtml", res);
        }

    }
}