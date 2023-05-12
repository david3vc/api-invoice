using Domain;
using Infraestructure.Context;
using Infraestructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories.Implementations
{
    public class InvoiceStatusRepository : IInvoiceStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<InvoiceStatus>> FindAll()
        => await _context.InvoiceStatuses.ToListAsync();
    }
}
