using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string? ProjectDescription { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int? IdPaymentTerm { get; set; }
        public int? IdInvoiceStatus { get; set; }
        public int? IdSubject { get; set; }
        public int? IdInvoiceIssuer { get; set; }
        public int? IdUsuario { get; set; }
        public int Status { get; set; }

        public InvoiceStatusDto? InvoiceStatus { get; set; }
        public PaymentTermDto? PaymentTerm { get; set; }
        public SubjectDto? Subject { get; set; }
        public InvoiceIssuerDto? InvoiceIssuer { get; set; }
        public List<InvoiceItemDto>? InvoiceItems { get; set; }
    }
}
