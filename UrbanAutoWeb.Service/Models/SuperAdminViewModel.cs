using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanAutoWeb.Service.Models
{
    public class SuperAdminViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? ReturnUrl { get; set; }
        public string? ErrorMsg { get; set; }
    }
}
