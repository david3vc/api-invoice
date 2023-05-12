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
    public class InvoiceService : IInvoiceService
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IMapper mapper, IInvoiceRepository invoiceRepository)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<InvoiceDto> Create(InvoiceFormDto dto)
        {
            var entity = _mapper.Map<Invoice>(dto);
            var response = await _invoiceRepository.Create(entity);

            return _mapper.Map<InvoiceDto>(response);
        }

        public async Task<InvoiceDto?> Delete(int id)
        {
            var response = await _invoiceRepository.Delete(id);

            return _mapper.Map<InvoiceDto>(response);
        }

        public async Task<InvoiceDto?> Find(int id)
        {
            var response = await _invoiceRepository.Find(id);

            return _mapper.Map<InvoiceDto>(response);
        }

        public async Task<IList<InvoiceDto>> FindAll()
        {
            var response = await _invoiceRepository.FindAll();

            return _mapper.Map<IList<InvoiceDto>>(response);
        }

        public async Task<InvoiceDto?> Update(InvoiceDto dto)
        {
            var entity = _mapper.Map<Invoice>(dto);
            var response = await _invoiceRepository.Update(entity);

            return _mapper.Map<InvoiceDto>(response);
        }
    }
}
