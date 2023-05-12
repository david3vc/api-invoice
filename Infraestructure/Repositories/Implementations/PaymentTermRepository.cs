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
    public class PaymentTermRepository : IPaymentTermRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentTermRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<PaymentTerm>> FindAll()
        => await _context.PaymentTerms.ToListAsync();
    }
}
