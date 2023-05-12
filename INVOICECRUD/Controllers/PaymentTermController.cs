using Application.Dtos;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace INVOICECRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTermController : ControllerBase
    {
        private readonly IPaymentTermService _paymentTermService;

        public PaymentTermController(IPaymentTermService paymentTermService)
        {
            _paymentTermService = paymentTermService;
        }

        [HttpGet]
        public async Task<IEnumerable<PaymentTermDto>> Get()
            => await _paymentTermService.FindAll();
    }
}
