using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Status { get; set; } = 1;

        public virtual ICollection<Invoice>? Invoices { get; set; }
    }
}
