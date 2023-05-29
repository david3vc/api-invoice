using Application.Dtos;
using Application.Services.Abstractions;
using AutoMapper;
using Domain;
using Infraestructure.Repositories.Abstractions;
using Infraestructure.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class InvoiceIssuerService : IInvoiceIssuerService
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceIssuerRepository _invoiceIssuerRepository;

        public InvoiceIssuerService(IMapper mapper, IInvoiceIssuerRepository invoiceIssuerRepository)
        {
            _mapper = mapper;
            _invoiceIssuerRepository = invoiceIssuerRepository;
        }

        public async Task<InvoiceIssuerDto> Create(InvoiceIssuerFormDto dto)
        {
            var entity = _mapper.Map<InvoiceIssuer>(dto);
            var response = await _invoiceIssuerRepository.Create(entity);

            return _mapper.Map<InvoiceIssuerDto>(response);
        }

        public Task<InvoiceIssuerDto?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceIssuerDto?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<InvoiceIssuerDto>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<InvoiceIssuerDto?> Update(InvoiceIssuerDto dto)
        {
            var entity = _mapper.Map<InvoiceIssuer>(dto);
            var response = await _invoiceIssuerRepository.Update(entity);

            return _mapper.Map<InvoiceIssuerDto>(response);
        }
    }
}
