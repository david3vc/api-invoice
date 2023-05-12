using Application.Dtos;
using Application.Services.Abstractions;
using Application.Services.Implementations;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Mvc;

namespace INVOICECRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemController : ControllerBase
    {
        private readonly IInvoiceItemService _invoiceItemService;

        public InvoiceItemController(IInvoiceItemService invoiceItemService)
        {
            _invoiceItemService = invoiceItemService;
        }

        [HttpGet]
        public async Task<IEnumerable<InvoiceItemDto>> Get()
            => await _invoiceItemService.FindAll();

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvoiceItemDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<InvoiceItemDto> Get(int id)
        {
            var response = await _invoiceItemService.Find(id);

            if (response == null) throw new Exception("Invoice no encontrado");

            return response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvoiceItemDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<InvoiceItemDto> Post([FromBody] InvoiceItemFormDto request)
        {
            var response = await _invoiceItemService.Create(request);

            if (response == null) throw new Exception("Error");

            return response;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvoiceItemDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<InvoiceItemDto> Put([FromBody] InvoiceItemDto request)
        {
            var response = await _invoiceItemService.Update(request);

            if (response == null) throw new Exception("Error");

            return response;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvoiceItemDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<InvoiceItemDto> Delete(int id)
        {
            var response = await _invoiceItemService.Delete(id);

            if (response == null) throw new Exception("Invoice no encontrado");

            return response;
        }
    }
}
