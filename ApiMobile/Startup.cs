using ApiMobile.Models;
using ApiMobile.Repositorios;
using ApiMobile.Services;
using ApiMobile.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiMobile
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Adiciona serviços ao contêiner.
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHttpClient();
            services.AddSingleton<ICRMApiService, CRMApiService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            // Adiciona o DbContext ao contêiner
            // Obtenha a string de conexão do arquivo appsettings.json
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            // Configure o DbContext para usar a string de conexão
            services.AddDbContext<ApiContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = _configuration["Jwt:Issuer"],
                        ValidAudience = _configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]))
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("PacientePolicy", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("role", "Paciente");
                });

                options.AddPolicy("MedicoPolicy", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("role", "Medico");
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiMobile v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}