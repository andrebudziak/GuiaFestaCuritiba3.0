using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SiteGuiaFestaCuritiba3._0.Models
{
    public class Banner
    {

        private WebService ws = new WebService();

        public int codigo { get; set; }
        public int codigo_cliente { get; set; }
        public int codigo_local_banner { get; set; }
        public string descricao { get; set; }
        public int largura { get; set; }
        public int altura { get; set; }
        public int status { get; set; }
        public string miniatura { get; set; }
        public string nome_fantasia { get; set; }
        public string site { get; set; }
        public string telefone { get; set; }
        public string local_banner { get; set; }
        public List<Cliente> iCliente { get; set; }
        public List<Local_Banner> iLocalBanner { get; set; }
        public List<Banner> Listar(int id, string nome)
        {
            DataSet ds = ws.ConsultaBanner(id, nome);
            return (from row in ds.Tables[0].AsEnumerable()
                    select new Banner
                    {
                        codigo = row.Field<int>("codigo"),
                        nome_fantasia = row.Field<string>("nome_fantasia"),
                        descricao = row.Field<string>("descricao"),
                        codigo_local_banner = row.Field<int>("codigo_local_banner"),
                        altura = row.Field<int>("altura"),
                        largura = row.Field<int>("largura"),
                        status = row.Field<int>("codigo_status"),
                        codigo_cliente = row.Field<int>("codigo_cliente"),
                        miniatura = row.Field<string>("miniatura"),
                        local_banner = row.Field<string>("local")

        }).ToList();
        }

        public Banner Editar(int id)
        {
            DataSet ds = ws.ConsultaBanner(id, "0");
            return (from row in ds.Tables[0].AsEnumerable()
                    select new Banner
                    {
                        codigo = row.Field<int>("codigo"),
                        nome_fantasia = row.Field<string>("nome_fantasia"),
                        descricao = row.Field<string>("descricao"),
                        codigo_local_banner = row.Field<int>("codigo_local_banner"),
                        altura = row.Field<int>("altura"),
                        largura = row.Field<int>("largura"),
                        status = row.Field<int>("codigo_status"),
                        codigo_cliente = row.Field<int>("codigo_cliente"),
                        miniatura = row.Field<string>("miniatura"),
                        local_banner = row.Field<string>("local")

                    }).Single();
        }

        public void Salvar(Banner a)
        {
            ws.IncluirBanner(a.codigo, a.descricao, a.codigo_local_banner, a.largura, a.altura, a.status, a.codigo_cliente, a.miniatura);
        }

        public void Excluir(int id)
        {
            ws.ExcluirBanner(id);
        }

    }
}