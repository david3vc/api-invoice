using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Maps
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            
            CreateMap<Usuario, UsuarioResponseDto>();
            CreateMap<Usuario, UsuarioResponseDto>().ReverseMap();
        }
    }
}
