using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteGuiaFestaCuritiba3._0.Models
{
    public class User
    {
        private WebService ws = new WebService();

        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembre-me")]
        public bool RememberMe { get; set; }

        public bool IsValid(string _username, string _password)
        {
            if (ws.authenticateUser(_username, _password) == 0)
                return false;
            else
                return true;

        }
    }
}