using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SiteGuiaFestaCuritiba3._0.Models
{
    public class Cliente
    {
        private WebService ws = new WebService();

        public int codigo { get; set; }
        public string razao_social { get; set; }
        public string cnpj { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string endereco { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string email { get; set; }
        public string responsavel { get; set; }
        public string telefone { get; set; }
        public string nome_fantasia { get; set; }
        public string login { get; set; }
        public string senha { get; set; }

        public List<Cliente> Listar(int id, string nome)
        {
            DataSet ds = ws.ConsultaCliente(id, nome);
            return (from row in ds.Tables[0].AsEnumerable()
                    select new Cliente
                    {
                        codigo = row.Field<Int32>("codigo"),
                        razao_social = row.Field<string>("razao_social"),                        
                        cnpj = row.Field<string>("cnpj"),
                        cpf = row.Field<string>("cpf"),
                        rg = row.Field<string>("rg"),
                        endereco = row.Field<string>("endereco"),
                        cep = row.Field<string>("cep"),
                        bairro = row.Field<string>("bairro"),
                        cidade = row.Field<string>("cidade"),
                        email = row.Field<string>("email"),
                        responsavel = row.Field<string>("responsavel"),
                        telefone = row.Field<string>("telefone"),
                        nome_fantasia = row.Field<string>("nome_fantasia")

                    }).ToList();
        }

        public Cliente Editar(int id)
        {
            DataSet ds = ws.ConsultaCliente(id, "0");
            return (from row in ds.Tables[0].AsEnumerable()
                    select new Cliente
                    {
                        codigo = row.Field<Int32>("codigo"),
                        razao_social = row.Field<string>("razao_social"),
                        cnpj = row.Field<string>("cnpj"),
                        cpf = row.Field<string>("cpf"),
                        rg = row.Field<string>("rg"),
                        endereco = row.Field<string>("endereco"),
                        cep = row.Field<string>("cep"),
                        bairro = row.Field<string>("bairro"),
                        cidade = row.Field<string>("cidade"),
                        email = row.Field<string>("email"),
                        responsavel = row.Field<string>("responsavel"),
                        telefone = row.Field<string>("telefone"),
                        nome_fantasia = row.Field<string>("nome_fantasia")

                    }).Single();
        }

        public List<Cliente> Ordenar(int id, string nome, string ord)
        {
            DataSet ds = ws.ConsultaCliente(id, nome);
            switch (ord)
            {
                case "codigo":
                    {
                        return (from row in ds.Tables[0].AsEnumerable()
                                select new Cliente
                                {
                                    codigo = row.Field<Int32>("codigo"),
                                    razao_social = row.Field<string>("razao_social"),
                                    cnpj = row.Field<string>("cnpj"),
                                    cpf = row.Field<string>("cpf"),
                                    rg = row.Field<string>("rg"),
                                    endereco = row.Field<string>("endereco"),
                                    cep = row.Field<string>("cep"),
                                    bairro = row.Field<string>("bairro"),
                                    cidade = row.Field<string>("cidade"),
                                    email = row.Field<string>("email"),
                                    responsavel = row.Field<string>("responsavel"),
                                    telefone = row.Field<string>("telefone"),
                                    nome_fantasia = row.Field<string>("nome_fantasia")

                                }).OrderBy(x => x.codigo).ToList();
                    }

            }
            return null;
        }

        public void Salvar(Cliente c)
        {
            ws.IncluirCliente(c.codigo,c.razao_social,c.cnpj,c.cpf,c.rg,c.endereco,c.cep,c.bairro,c.cidade,c.email,c.responsavel,c.telefone,c.nome_fantasia);
        }

        public void Excluir(int id)
        {
            ws.ExcluirCliente(id);
        }

    }
}