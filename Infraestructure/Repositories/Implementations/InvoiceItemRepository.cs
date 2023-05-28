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
    public class InvoiceItemRepository : IInvoiceItemRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<InvoiceItem> Create(InvoiceItem entity)
        {
            _context.InvoiceItems.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<InvoiceItem?> Delete(int id)
        {
            var model = await _context.InvoiceItems.FindAsync(id);

            if (model != null)
            {
                model.Status = 0;

                _context.InvoiceItems.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<InvoiceItem?> Find(int id)
            => await _context.InvoiceItems.FindAsync(id);

        public async Task<IList<InvoiceItem>> FindAll()
            => await _context.InvoiceItems.Where(f => f.Status == 1).ToListAsync();

        public async Task<InvoiceItem?> Update(InvoiceItem entity)
        {
            var model = await _context.InvoiceItems.FindAsync(entity.Id);

            if (model != null)
            {
                model.Name = entity.Name;
                model.Quantity = entity.Quantity;
                model.Price = entity.Price;
                model.Total = entity.Total;
                model.IdInvoice = entity.IdInvoice;

                _context.InvoiceItems.Update(model);
                await _context.SaveChangesAsync();
            }

            return entity;
        }
    }
}
