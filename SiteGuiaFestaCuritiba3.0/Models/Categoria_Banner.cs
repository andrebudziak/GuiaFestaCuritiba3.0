using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SiteGuiaFestaCuritiba3._0.Models
{
    public class Categoria_Banner
    {
        private WebService ws = new WebService();
        public int codigo { get; set; }
        public int codigo_categoria { get; set; }
        public int codigo_banner { get; set; }
        public string banner { get; set; }
        public string categoria { get; set; }
        public List<Local_Banner> iLocalBanner { get; set; }
        public List<Banner> iBanner { get; set; }

        public List<Categoria_Banner> Listar(int id,string nome)
        {
            DataSet ds = ws.ConsultaCategoriaBanner(id, nome);
            return (from row in ds.Tables[0].AsEnumerable()
                    select new Categoria_Banner
                    {
                        codigo = row.Field<int>("codigo"),
                        codigo_categoria = row.Field<int>("codigo_categoria"),
                        codigo_banner = row.Field<int>("codigo_banner"),
                        banner = row.Field<string>("banner"),
                        categoria = row.Field<string>("categoria")

                    }).ToList();
        }

        public Categoria_Banner Editar(int id)
        {
            DataSet ds = ws.ConsultaCategoriaBanner(id,"0");
            return (from row in ds.Tables[0].AsEnumerable()
                    select new Categoria_Banner
                    {
                        codigo = row.Field<int>("codigo"),
                        codigo_categoria = row.Field<int>("codigo_categoria"),
                        codigo_banner = row.Field<int>("codigo_banner"),
                        banner = row.Field<string>("banner"),
                        categoria = row.Field<string>("categoria")

                    }).Single();
        }

        public void Salvar(Categoria_Banner a)
        {
            ws.IncluirBannerCategoria(a.codigo, a.codigo_banner, a.codigo_categoria);
        }

        public void Excluir(int id)
        {
            ws.ExcluirCategoriaBanner(id);
        }


    }
}