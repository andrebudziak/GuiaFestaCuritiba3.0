using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SiteGuiaFestaCuritiba3._0.Models
{
    public class Anuncio_Link
    {
        private WebService ws = new WebService();

        public int codigo { get; set; }
        public int codigo_anuncio { get; set; }
        public string nome_fantasia { get; set; }
        public string orkut { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string gmais { get; set; }
        public string pinterest { get; set; }
        public Anuncio_Link iLink { get; set; }
        public List<Anuncio> iAnuncio { get; set; }
        public List<Anuncio_Link> Listar(int id, string nome)
        {
            DataSet ds = ws.ConsultaLink(id, nome);
            return (from row in ds.Tables[0].AsEnumerable()
                    select new Anuncio_Link
                    {
                        codigo = row.Field<Int32>("codigo"),
                        codigo_anuncio = row.Field<Int32>("codigo_anuncio"),
                        nome_fantasia = row.Field<string>("nome_fantasia"),
                        orkut = row.Field<string>("orkut"),
                        facebook = row.Field<string>("facebook"),
                        twitter = row.Field<string>("twitter"),
                        gmais = row.Field<string>("gmais"),
                        pinterest = row.Field<string>("pinterest")

                    }).ToList();
        }

        public Anuncio_Link Editar(int id)
        {
            DataSet ds = ws.ConsultaLink(id, "0");
            return (from row in ds.Tables[0].AsEnumerable()
                    select new Anuncio_Link
                    {
                        codigo = row.Field<Int32>("codigo"),
                        codigo_anuncio = row.Field<Int32>("codigo_anuncio"),
                        nome_fantasia = row.Field<string>("nome_fantasia"),
                        orkut = row.Field<string>("orkut"),
                        facebook = row.Field<string>("facebook"),
                        twitter = row.Field<string>("twitter"),
                        gmais = row.Field<string>("gmais"),
                        pinterest = row.Field<string>("pinterest")

                    }).Single();
        }

        public void Salvar(Anuncio_Link a)
        {
            ws.IncluirLink(a.codigo, a.codigo_anuncio,a.orkut,a.facebook,a.twitter,a.pinterest);
        }

        public void Excluir(int id)
        {
            ws.ExcluirLink(id);
        }

    }
}