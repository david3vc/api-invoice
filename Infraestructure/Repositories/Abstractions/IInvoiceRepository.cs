using Domain;
using Infraestructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories.Abstractions
{
    public interface IInvoiceRepository : IRepositoryCrud<Invoice, int> 
    {
        Task<List<Invoice>> ListarInvoicesPorUsuario(InvoicePeticion request);
    }
}
