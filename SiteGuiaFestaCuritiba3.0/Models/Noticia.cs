using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteGuiaFestaCuritiba3._0.Models
{
    public class Noticia
    {
        public int codigo { get; set; }
        public int codigo_cliente { get; set; }
        public string noticia { get; set; }
        public int status { get; set; }
        public int tipo_noticia { get; set; }
        public int prioridade { get; set; }
        public string nome_fantasia { get; set; }
        public string site { get; set; }
        public string imagem_destaque { get; set; }

    }
}