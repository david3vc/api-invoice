﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class InvoicePeticion
    {
        public int? IdUsuario { get; set; }
        public int? Draft { get; set; }
        public int? Pending { get; set; }
        public int? Paid { get; set; }
    }
}
