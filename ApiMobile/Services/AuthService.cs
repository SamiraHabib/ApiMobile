using ApiMobile.DTO;
using ApiMobile.Models;
using ApiMobile.Repositorios;
using ApiMobile.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace ApiMobile.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AuthService(IConfiguration config, IUsuarioRepositorio usuarioRepositorio)
        {
            _config = config;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<Usuario> ValidateCredentials(string userEmail, string userPassword)
        {
            var user = await _usuarioRepositorio.GetUserByUserEmailAsync(userEmail)
                       ?? throw new InvalidCredentialException("E-mail ou senha inválidos.");
            if (!BCrypt.Net.BCrypt.Verify(userPassword, user.SenhaEncriptada))
                throw new InvalidCredentialException("E-mail ou senha inválidos.");

            return user;
        }

        public JwtAuthentication GenerateJwtToken(UsuarioAutenticado user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Secret"]);
            var expires = DateTime.UtcNow.AddDays(int.Parse(_config["Jwt:ExpirationInDays"]));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"],
                Subject = new ClaimsIdentity(claims),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new JwtAuthentication
            {
                Token = tokenHandler.WriteToken(token),
                ExpiresAt = expires
            };
        }
    }
}