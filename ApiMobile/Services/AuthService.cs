using ApiMobile.Models;
using ApiMobile.Repositorios;
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

        public JwtAuthentication GenerateJwtToken(UsuarioAutentificado user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Secret"] ?? string.Empty);
            var expires = DateTime.UtcNow.AddDays(int.Parse(_config["Jwt:ExpirationInDays"] ?? string.Empty));

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                user.GetType() == typeof(Paciente) ? new Claim(ClaimTypes.Role, "Paciente") :
                user.GetType() == typeof(Medico) ? new Claim(ClaimTypes.Role, "Medico") :
                null
            }.Where(c => c != null).ToList();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
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