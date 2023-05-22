using Core.Security.Entities;
using Core.Security.Services.Abstractions;
using Domain;
using Infraestructure.Context;
using Infraestructure.Repositories.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        //private readonly ISecurityService _securityService;

        public UsuarioRepository(ApplicationDbContext context/*, ISecurityService securityService*/)
        {
            _context = context;
            //_securityService = securityService;
        }

        private string HashPassword(string userName, string hashedPassword)
        {
            var passwordHasher = new PasswordHasher<string>();

            return passwordHasher.HashPassword(userName, hashedPassword);
        }

        private bool VerifyHashedPassword(string userName, string hashedPassword, string providedPassword)
        {
            var passwordHasher = new PasswordHasher<string>();

            var verificationResult = passwordHasher.VerifyHashedPassword(userName, hashedPassword, providedPassword);

            if (verificationResult == PasswordVerificationResult.Success) return true;

            return false;
        }

        

        public async Task<Usuario> Create(Usuario entity)
        {
            var entidad = await _context.Usuarios.FindAsync(entity.Id);

            if (entidad == null)
            {
                entidad = new Usuario();
            }

            entidad.Password = HashPassword(entity.Email, entity.Password);
            entidad.Email = entity.Email;
            entidad.Status = entity.Status;

            if (entity.Id == 0)
            {
                _context.Usuarios.Add(entidad);
            }
            else
            {
                _context.Usuarios.Update(entidad);
            }

            await _context.SaveChangesAsync();

            return entidad;
        }

        public Task<Usuario?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario?> Find(int id)
            => await _context.Usuarios.FindAsync(id);

        public Task<IList<Usuario>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario?> LoginAsync(string nombreUsuario, string clave)
        {
            var model = await _context.Usuarios.FirstOrDefaultAsync(e => e.Email == nombreUsuario);

            if (model == null) throw new Exception("Usuario no está registrado en nuestro sistema");

            var verificationResult = VerifyHashedPassword(nombreUsuario, model.Password, clave);
            if (!verificationResult) throw new Exception("Su contraseña no es correcta");

            if (model.Status == 0) throw new Exception("Usuario no está activo, comuníquese con área técnica");

            return model;
        }

        public Task<Usuario?> Update(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
