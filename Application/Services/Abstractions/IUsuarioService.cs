using Application.Core;
using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstractions
{
    public interface IUsuarioService : IServiceCrud<UsuarioDto, UsuarioCreateDto, int>
    {
        Task<UsuarioResponseDto?> LoginAsync(UsuarioLoginDto dto);
    }
}
