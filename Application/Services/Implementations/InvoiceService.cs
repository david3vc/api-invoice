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
        private readonly IInvoiceItemService _invoiceItemService;
        private readonly ISubjectService _subjectService;
        private readonly IInvoiceIssuerService _invoiceIssuerService;

        public InvoiceService(
                                IMapper mapper, 
                                IInvoiceRepository invoiceRepository, 
                                IInvoiceItemService invoiceItemService, 
                                ISubjectService subjectService, 
                                IInvoiceIssuerService invoiceIssuerService
                             )
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _invoiceItemService = invoiceItemService;
            _subjectService = subjectService;
            _invoiceIssuerService = invoiceIssuerService;
        }

        public async Task<InvoiceDto> Create(InvoiceFormDto dto)
        {
            if(dto.Subject != null)
            {
                var responseSubject = await _subjectService.Create(dto.Subject);
                dto.IdSubject = responseSubject.Id;
            }

            if(dto.InvoiceIssuer != null)
            {
                var responseInvoiceIssuer = await _invoiceIssuerService.Create(dto.InvoiceIssuer);
                dto.IdInvoiceIssuer = responseInvoiceIssuer.Id;
            }

            //var entity = _mapper.Map<Invoice>(dto);
            var entity = new Invoice();

            entity.IdInvoiceIssuer = dto.IdInvoiceIssuer != null ? dto.IdInvoiceIssuer : null;
            entity.IdSubject = dto.IdSubject != null ? dto.IdSubject : null;
            entity.InvoiceDate = dto.InvoiceDate;
            entity.ProjectDescription = dto.ProjectDescription;
            entity.IdUsuario = dto.IdUsuario;
            entity.IdPaymentTerm = dto.PaymentTerm != null ? dto.PaymentTerm.Id : null;
            entity.IdInvoiceStatus = dto.InvoiceStatus != null ? dto.InvoiceStatus.Id : null;
            //entity.IdSubject = dto.Subject != null ? dto.Subject.Id : null;
            //entity.IdInvoiceIssuer = dto.InvoiceIssuer != null ? dto.InvoiceIssuer.Id : null;

            var response = await _invoiceRepository.Create(entity);

            if(dto.InvoiceItems != null)
            {
                foreach(var item in dto.InvoiceItems)
                {
                    item.IdInvoice = response.Id;
                    await _invoiceItemService.Create(item);
                }
            }

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

        public async Task<List<InvoiceDto>> ListarInvoicesPorUsuario(int? idUsuario, int? status)
        {
            var response = await _invoiceRepository.ListarInvoicesPorUsuario(idUsuario, status);

            return _mapper.Map<List<InvoiceDto>>(response);
        }

        public async Task<InvoiceDto?> Update(InvoiceDto dto)
        {
            var entity = _mapper.Map<Invoice>(dto);
            var response = await _invoiceRepository.Update(entity);

            return _mapper.Map<InvoiceDto>(response);
        }
    }
}
