﻿using System;
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
        public int? IdPaymentTerm { get; set; }
        public int? IdInvoiceStatus { get; set; }
        public int? IdSubject { get; set; }
        public int? IdInvoiceItem { get; set; }
    }
}
