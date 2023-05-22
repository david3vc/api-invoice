using Domain;
using Infraestructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories.Abstractions
{
    public interface IUsuarioRepository : IRepositoryCrud<Usuario, int> 
    {
        Task<Usuario?> LoginAsync(string nombreUsuario, string clave);
    }
}
