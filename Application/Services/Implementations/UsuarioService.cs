using Application.Dtos;
using Application.Services.Abstractions;
using AutoMapper;
using Core.Security.Entities;
using Domain;
using Infraestructure.Repositories.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<UsuarioDto> Create(UsuarioCreateDto dto)
        {
            var entity = _mapper.Map<Usuario>(dto);
            var response = await _usuarioRepository.Create(entity);

            return _mapper.Map<UsuarioDto>(response);
        }

        public Task<UsuarioDto?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioDto?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UsuarioDto>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioResponseDto?> LoginAsync(UsuarioLoginDto dto)
        {
            var response = await _usuarioRepository.LoginAsync(dto.Email, dto.Password);
            var usuario = _mapper.Map<UsuarioResponseDto>(response);

            var jwtSecrectKey = _configuration.GetSection("Security:JwtSecrectKey").Value?.ToString();
            usuario.Security = JwtSecurity(jwtSecrectKey);

            return usuario;
        }

        public Task<UsuarioDto?> Update(UsuarioDto dto)
        {
            throw new NotImplementedException();
        }

        private SecurityEntity JwtSecurity(string jwtSecrectKey)
        {
            var utcNow = DateTime.UtcNow;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString())
            };
            var expiredDateTime = utcNow.AddDays(1);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            //Key + credentials
            var key = Encoding.ASCII.GetBytes(jwtSecrectKey);
            var symmetricSecurityKey = new SymmetricSecurityKey(key);
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(claims: claims, expires: expiredDateTime, notBefore: utcNow, signingCredentials: signingCredentials);
            string token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new SecurityEntity()
            {
                TokenType = "Bearer",
                AccesToken = token,
                ExpiresOn = expiredDateTime
            };
        }
    }
}
