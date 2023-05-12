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
    public class PaymentTermService : IPaymentTermService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentTermRepository _paymentTermRepository;

        public PaymentTermService(IPaymentTermRepository paymentTermRepository, IMapper mapper)
        {
            _paymentTermRepository = paymentTermRepository;
            _mapper = mapper;
        }

        public async Task<IList<PaymentTermDto>> FindAll()
        {
            var response = await _paymentTermRepository.FindAll();

            return _mapper.Map<IList<PaymentTermDto>>(response);
        }
    }
}
