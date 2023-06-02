using Application.Core;
using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstractions
{
    public interface IInvoiceService : IServiceCrud<InvoiceDto, InvoiceFormDto, int> 
    {
        Task<List<InvoiceDto>> ListarInvoicesPorUsuario(InvoicePeticionDto request);
        Task<InvoiceDto> MarkAsPaid(int id);
    }
}
