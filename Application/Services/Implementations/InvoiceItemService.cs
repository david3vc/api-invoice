using Application.Dtos;
using Application.Services.Abstractions;
using AutoMapper;
using Domain;
using Infraestructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class InvoiceItemService : IInvoiceItemService
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceItemRepository _invoiceItemRepository;

        public InvoiceItemService(IInvoiceItemRepository invoiceItemRepository, IMapper mapper)
        {
            _mapper = mapper;
            _invoiceItemRepository = invoiceItemRepository;
        }

        public async Task<InvoiceItemDto> Create(InvoiceItemFormDto dto)
        {
            var entity = _mapper.Map<InvoiceItem>(dto);
            var response = await _invoiceItemRepository.Create(entity);

            return _mapper.Map<InvoiceItemDto>(response);
        }

        public async Task<InvoiceItemDto?> Delete(int id)
        {
            var response = await _invoiceItemRepository.Delete(id);

            return _mapper.Map<InvoiceItemDto>(response);
        }

        public async Task<InvoiceItemDto?> Find(int id)
        {
            var response = await _invoiceItemRepository.Find(id);

            return _mapper.Map<InvoiceItemDto>(response);
        }

        public async Task<IList<InvoiceItemDto>> FindAll()
        {
            var response = await _invoiceItemRepository.FindAll();

            return _mapper.Map<IList<InvoiceItemDto>>(response);
        }

        public async Task<InvoiceItemDto?> Update(InvoiceItemDto dto)
        {
            var entity = _mapper.Map<InvoiceItem>(dto);
            var response = await _invoiceItemRepository.Update(entity);

            return _mapper.Map<InvoiceItemDto>(response);
        }
    }
}
