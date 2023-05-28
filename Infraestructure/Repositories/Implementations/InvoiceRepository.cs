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
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Invoice> Create(Invoice entity)
        {
            _context.Invoices.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Invoice?> Delete(int id)
        {
            var model = await _context.Invoices.FindAsync(id);

            if (model != null)
            {
                model.Status = 0;

                _context.Invoices.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Invoice?> Find(int id)
            => await _context.Invoices.Include(f => f.InvoiceStatus)
                                      .Include(f => f.InvoiceItems)
                                      .Include(f => f.Subject)
                                      .Include(f => f.PaymentTerm)
                                      .Where(f => f.Id == id).FirstOrDefaultAsync();

        public async Task<IList<Invoice>> FindAll()
            => await _context.Invoices.Where(f => f.Status == 1).ToListAsync();

        public async Task<List<Invoice>> ListarInvoicesPorUsuario(int? idUsuario, int? status)
        {
            var response = await _context.Invoices
                .Include(f => f.InvoiceStatus)
                                                            .Include(f => f.InvoiceItems)
                                                                                  .Include(f => f.Subject)
                                                                                  .Include(f => f.InvoiceIssuer)
                                                            .Include(f => f.PaymentTerm)
                                      .Where(f => (!idUsuario.HasValue || f.IdUsuario == idUsuario)
                                                   && (!status.HasValue || f.Status == status))
                                      .ToListAsync();

            return response;
        }

        public async Task<Invoice?> Update(Invoice entity)
        {
            var model = await _context.Invoices.FindAsync(entity.Id);

            if (model != null)
            {
                model.ProjectDescription = entity.ProjectDescription;
                model.InvoiceDate = entity.InvoiceDate;
                model.IdPaymentTerm = entity.IdPaymentTerm;
                model.IdInvoiceStatus = entity.IdInvoiceStatus;
                model.IdSubject = entity.IdSubject;
                model.IdInvoiceIssuer = entity.IdInvoiceIssuer;

                _context.Invoices.Update(model);
                await _context.SaveChangesAsync();
            }

            return entity;
        }
    }
}
