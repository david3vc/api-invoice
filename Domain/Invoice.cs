using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Invoice
    {
        public int Id { get; set; }
        public string? ProjectDescription { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int? IdPaymentTerm { get; set; }
        public int? IdInvoiceStatus { get; set; }
        public int? IdSubject { get; set; }
        public int? IdInvoiceItem { get; set; }
        public int Status { get; set; } = 1;

        public virtual InvoiceItem? InvoiceItem { get; set; }
        public virtual InvoiceStatus? InvoiceStatus { get; set; }
        public virtual PaymentTerm? PaymentTerm { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual Usuario? Usuario { get; set; }
}
}
