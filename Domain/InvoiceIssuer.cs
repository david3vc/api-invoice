using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class InvoiceIssuer
    {
        public int Id { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? PostCode { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<Invoice>? Invoices { get; set; }
    }
}
