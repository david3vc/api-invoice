using Application.Dtos;
using Application.Services.Abstractions;
using AutoMapper;
using Infraestructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class InvoiceStatusService : IInvoiceStatusService
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceStatusRepository _invoiceStatusRepository;

        public InvoiceStatusService(IInvoiceStatusRepository invoiceStatusRepository, IMapper mapper)
        {
            _invoiceStatusRepository = invoiceStatusRepository;
            _mapper = mapper;
        }

        public async Task<IList<InvoiceStatusDto>> FindAll()
        {
            var response = await _invoiceStatusRepository.FindAll();

            return _mapper.Map<IList<InvoiceStatusDto>>(response);
        }
    }
}
