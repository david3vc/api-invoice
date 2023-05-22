using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class UsuarioResponseDto
    {
        public string? Email { get; set; }
        public int? Status { get; set; }
        public SecurityEntity? Security { get; set; }
    }
}
