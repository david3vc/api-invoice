using Application.Dtos;
using Application.Services.Abstractions;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace INVOICECRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<UsuarioDto> Post([FromBody] UsuarioCreateDto request)
        {
            var response = await _usuarioService.Create(request);

            if (response == null) throw new Exception("Error");

            return response;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<UsuarioResponseDto> Post([FromBody] UsuarioLoginDto request)
        {
            var response = await _usuarioService.LoginAsync(request);

            if (response == null) throw new Exception("Error");

            return response;
        }
    }
}
