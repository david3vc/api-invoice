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
    public class InvoiceIssuerRepository : IInvoiceIssuerRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceIssuerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<InvoiceIssuer> Create(InvoiceIssuer entity)
        {
            _context.InvoiceIssuers.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<InvoiceIssuer?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<InvoiceIssuer?> Find(int id)
            => await _context.InvoiceIssuers.FindAsync(id);

        public async Task<IList<InvoiceIssuer>> FindAll()
            => await _context.InvoiceIssuers.ToListAsync();

        public async Task<InvoiceIssuer?> Update(InvoiceIssuer entity)
        {
            var model = await _context.InvoiceIssuers.FindAsync(entity.Id);

            if (model != null)
            {
                model.StreetAddress = entity.StreetAddress;
                model.PostCode = entity.PostCode;
                model.City = entity.City;
                model.Country = entity.Country;

                _context.InvoiceIssuers.Update(model);
                await _context.SaveChangesAsync();
            }

            return entity;
        }
    }
}
