using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class InvoiceStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Invoice>? Invoices { get; set; }
    }
}
