using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class InvoiceFormDto
    {
        public string? ProjectDescription { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int? IdInvoiceStatus { get; set; }
        public int? IdSubject { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdInvoiceIssuer { get; set; }
        public PaymentTermDto? PaymentTerm { get; set; }
        public InvoiceStatusDto? InvoiceStatus { get; set; }
        public SubjectFormDto? Subject { get; set; }
        public InvoiceIssuerFormDto? InvoiceIssuer { get; set; }
        public List<InvoiceItemFormDto>? InvoiceItems { get; set; }
    }
}
