using Application.Dtos;
using Application.Services.Abstractions;
using Application.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace INVOICECRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IEnumerable<SubjectDto>> Get()
            => await _subjectService.FindAll();

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<SubjectDto> Get(int id)
        {
            var response = await _subjectService.Find(id);

            if (response == null) throw new Exception("Subject no encontrado");

            return response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<SubjectDto> Post([FromBody] SubjectFormDto request)
        {
            var response = await _subjectService.Create(request);

            if (response == null) throw new Exception("Error");

            return response;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<SubjectDto> Put([FromBody] SubjectDto request)
        {
            var response = await _subjectService.Update(request);

            if (response == null) throw new Exception("Error");

            return response;
        }
    }
}
