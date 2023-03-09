using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SiteGuiaFestaCuritiba3._0.Models
{
    public class Local_Banner
    {
        private WebService ws = new WebService();

        public int codigo { get; set; }
        public string descricao { get; set; }
        public int prioridade { get; set; }

        public List<Local_Banner> Listar(int id, string nome)
        {
            DataSet ds = ws.ConsultaLocalBanner(id, nome);
            return (from row in ds.Tables[0].AsEnumerable()
                    select new Local_Banner
                    {
                        codigo = row.Field<int>("codigo"),
                        descricao = row.Field<string>("descricao")

                    }).ToList();
        }

        public Local_Banner Editar(int id)
        {
            DataSet ds = ws.ConsultaLocalBanner(id, "0");
            return (from row in ds.Tables[0].AsEnumerable()
                    select new Local_Banner
                    {
                        codigo = row.Field<int>("codigo"),
                        descricao = row.Field<string>("descricao")

                    }).Single();
        }

        public void Salvar(Local_Banner a)
        {
            //ws.IncluirBanner(a.codigo, a.descricao, a.codigo_local_banner, a.largura, a.altura, a.status, a.codigo_cliente, a.miniatura);
        }

        public void Excluir(int id)
        {
            //ws.ExcluirBanner(id);
        }



    }
}