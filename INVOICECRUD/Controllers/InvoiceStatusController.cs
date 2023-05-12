using Application.Dtos;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace INVOICECRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceStatusController : ControllerBase
    {
        private readonly IInvoiceStatusService _invoiceStatusService;

        public InvoiceStatusController(IInvoiceStatusService invoiceStatusService)
        {
            _invoiceStatusService = invoiceStatusService;
        }

        [HttpGet]
        public async Task<IEnumerable<InvoiceStatusDto>> Get()
            => await _invoiceStatusService.FindAll();
    }
}
