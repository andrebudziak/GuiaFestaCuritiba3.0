using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SiteGuiaFestaCuritiba3._0.Models
{
    public class Anuncio
    {
        private WebService ws = new WebService();

        public int codigo { get; set; }
        public string nome_fantasia { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string endereco { get; set; }
        public string orkut { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string gmais { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string site { get; set; }
        public int status { get; set; }
        public string logo { get; set; }
        public int codigo_cliente { get; set; }
        public string descricao { get; set; }
        public string informacoes { get; set; }
        public Anuncio iAnuncio { get; set; }
        public List<Cliente> iCliente { get; set; }  
        public List<Anuncio> Listar(int id, string nome)
        {
            DataSet ds = ws.ConsultaAnuncio(id, nome);
            return (from row in ds.Tables[0].AsEnumerable()
                    select new Anuncio
                    {
                        codigo = row.Field<Int32>("codigo"),
                        codigo_cliente = row.Field<Int32>("codigo_cliente"),
                        cep = row.Field<string>("cep"),
                        bairro = row.Field<string>("bairro"),
                        cidade = row.Field<string>("cidade"),
                        endereco = row.Field<string>("endereco"),
                        telefone = row.Field<string>("telefone"),
                        email = row.Field<string>("email"),
                        site = row.Field<string>("site"),
                        status = row.Field<Int32>("status"),
                        descricao = row.Field<string>("descricao"),
                        informacoes = row.Field<string>("informacoes"),
                        nome_fantasia = row.Field<string>("nome_fantasia")

                    }).ToList();
        }

        public Anuncio Editar(int id)
        {
            DataSet ds = ws.ConsultaAnuncio(id, "0");
            return (from row in ds.Tables[0].AsEnumerable()
                    select new Anuncio
                    {
                        codigo = row.Field<Int32>("codigo"),
                        codigo_cliente = row.Field<Int32>("codigo_cliente"),
                        cep = row.Field<string>("cep"),
                        bairro = row.Field<string>("bairro"),
                        cidade = row.Field<string>("cidade"),
                        endereco = row.Field<string>("endereco"),
                        telefone = row.Field<string>("telefone"),
                        email = row.Field<string>("email"),
                        site = row.Field<string>("site"),
                        status = row.Field<Int32>("status"),
                        descricao = row.Field<string>("descricao"),
                        nome_fantasia = row.Field<string>("nome_fantasia"),
                        informacoes = row.Field<string>("informacoes")

                    }).Single();
        }

        public List<Anuncio> ListarTela(int id, string nome)
        {
            DataSet ds = ws.ConsultaAnuncioTela(id, nome);
            return (from row in ds.Tables[0].AsEnumerable()
                    select new Anuncio
                    {
                        codigo = row.Field<Int32>("codigo"),
                        nome_fantasia = row.Field<string>("nome_fantasia"),
                        cep = row.Field<string>("cep"),
                        bairro = row.Field<string>("bairro"),
                        cidade = row.Field<string>("cidade"),
                        endereco = row.Field<string>("endereco"),
                        orkut = row.Field<string>("orkut"),
                        facebook = row.Field<string>("facebook"),
                        twitter = row.Field<string>("twitter"),
                        gmais = row.Field<string>("gmais"),
                        telefone = row.Field<string>("telefone"),
                        email = row.Field<string>("email"),
                        site = row.Field<string>("site"),
                        status = row.Field<Int32>("status"),
                        logo = row.Field<string>("logo"),
                        codigo_cliente = row.Field<Int32>("codigo_cliente"),
                        descricao = row.Field<string>("descricao"),
                        informacoes = row.Field<string>("informacoes")

                    }).ToList();
        }

        public List<Anuncio> Ordenar(int id, string nome, string ord)
        {
            DataSet ds = ws.ConsultaAnuncio(id, nome);
            switch (ord)
            {
                case "codigo":
                    {
                        return (from row in ds.Tables[0].AsEnumerable()
                                select new Anuncio
                                {
                                    codigo = row.Field<Int32>("codigo"),
                                    codigo_cliente = row.Field<Int32>("codigo_cliente"),
                                    cep = row.Field<string>("cep"),
                                    bairro = row.Field<string>("bairro"),
                                    cidade = row.Field<string>("cidade"),
                                    endereco = row.Field<string>("endereco"),
                                    telefone = row.Field<string>("telefone"),
                                    email = row.Field<string>("email"),
                                    site = row.Field<string>("site"),
                                    status = row.Field<Int32>("status"),
                                    descricao = row.Field<string>("descricao"),
                                    informacoes = row.Field<string>("informacoes"),
                                    nome_fantasia = row.Field<string>("nome_fantasia")

                                }).OrderBy(x => x.codigo).ToList();
                    }
                case "status":
                    {
                        return (from row in ds.Tables[0].AsEnumerable()
                                select new Anuncio
                                {
                                    codigo = row.Field<Int32>("codigo"),
                                    codigo_cliente = row.Field<Int32>("codigo_cliente"),
                                    cep = row.Field<string>("cep"),
                                    bairro = row.Field<string>("bairro"),
                                    cidade = row.Field<string>("cidade"),
                                    endereco = row.Field<string>("endereco"),
                                    telefone = row.Field<string>("telefone"),
                                    email = row.Field<string>("email"),
                                    site = row.Field<string>("site"),
                                    status = row.Field<Int32>("status"),
                                    descricao = row.Field<string>("descricao"),
                                    informacoes = row.Field<string>("informacoes"),
                                    nome_fantasia = row.Field<string>("nome_fantasia")

                                }).OrderBy(x => x.status).ToList();
                    }

            }
            return null;
        }


        public List<Anuncio> OrdenarTela(int id, string nome, string ord)
        {
            DataSet ds = ws.ConsultaAnuncioTela(id, nome);
            switch (ord)
            {
                case "Nome":
                    {
                        return (from row in ds.Tables[0].AsEnumerable()
                                select new Anuncio
                                {
                                    codigo = row.Field<Int32>("codigo"),
                                    nome_fantasia = row.Field<string>("nome_fantasia"),
                                    cep = row.Field<string>("cep"),
                                    bairro = row.Field<string>("bairro"),
                                    cidade = row.Field<string>("cidade"),
                                    endereco = row.Field<string>("endereco"),
                                    orkut = row.Field<string>("orkut"),
                                    facebook = row.Field<string>("facebook"),
                                    twitter = row.Field<string>("twitter"),
                                    gmais = row.Field<string>("gmais"),
                                    telefone = row.Field<string>("telefone"),
                                    email = row.Field<string>("email"),
                                    site = row.Field<string>("site"),
                                    status = row.Field<Int32>("status"),
                                    logo = row.Field<string>("logo"),
                                    codigo_cliente = row.Field<Int32>("codigo_cliente"),
                                    descricao = row.Field<string>("descricao"),
                                    informacoes = row.Field<string>("informacoes")

                                }).OrderBy(x => x.nome_fantasia).ToList();
                    }
                case "Bairro":
                    {
                        return (from row in ds.Tables[0].AsEnumerable()
                                select new Anuncio
                                {
                                    codigo = row.Field<Int32>("codigo"),
                                    nome_fantasia = row.Field<string>("nome_fantasia"),
                                    cep = row.Field<string>("cep"),
                                    bairro = row.Field<string>("bairro"),
                                    cidade = row.Field<string>("cidade"),
                                    endereco = row.Field<string>("endereco"),
                                    orkut = row.Field<string>("orkut"),
                                    facebook = row.Field<string>("facebook"),
                                    twitter = row.Field<string>("twitter"),
                                    gmais = row.Field<string>("gmais"),
                                    telefone = row.Field<string>("telefone"),
                                    email = row.Field<string>("email"),
                                    site = row.Field<string>("site"),
                                    status = row.Field<Int32>("status"),
                                    logo = row.Field<string>("logo"),
                                    codigo_cliente = row.Field<Int32>("codigo_cliente"),
                                    descricao = row.Field<string>("descricao"),
                                    informacoes = row.Field<string>("informacoes")

                                }).OrderBy(x => x.bairro).ToList();
                    }

            }
            return null;
        }

        public void Salvar(Anuncio a)
        {
            ws.IncluirAnuncio(a.codigo,a.codigo_cliente,a.cep,a.bairro,a.cidade,a.endereco,a.telefone,a.email,a.site,a.status,"0",a.descricao,a.informacoes);
        }

        public void Excluir(int id)
        {
            ws.ExcluirAnuncio(id);
        }     


    }
}