using Application.Dtos;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace INVOICECRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<IEnumerable<InvoiceDto>> Get()
            => await _invoiceService.FindAll();

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvoiceDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<InvoiceDto> Get(int id)
        {
            var response = await _invoiceService.Find(id);

            if (response == null) throw new Exception("Invoice no encontrado");

            return response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvoiceDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<InvoiceDto> Post([FromBody] InvoiceFormDto request)
        {
            var response = await _invoiceService.Create(request);

            if (response == null) throw new Exception("Error");

            return response;
        }

        [HttpPost("ListarInvoicesPorUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvoiceDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<InvoiceDto>> ListarInvoicesPorUsuario([FromBody] InvoicePeticionDto request)
        {
            var response = await _invoiceService.ListarInvoicesPorUsuario(request);

            if (response == null) throw new Exception("Error");

            return response;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvoiceDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<InvoiceDto> Put([FromBody] InvoiceDto request)
        {
            var response = await _invoiceService.Update(request);

            if (response == null) throw new Exception("Error");

            return response;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvoiceDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<InvoiceDto> Delete(int id)
        {
            var response = await _invoiceService.Delete(id);

            if (response == null) throw new Exception("Invoice no encontrado");

            return response;
        }

        [HttpGet("MarkAsPaid/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvoiceDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<InvoiceDto> MarkAsPaid(int id)
        {
            var response = await _invoiceService.MarkAsPaid(id);

            if (response == null) throw new Exception("Invoice no encontrado");

            return response;
        }
    }
}
