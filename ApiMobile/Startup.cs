using ApiMobile.Models;
using ApiMobile.Repositorio;
using ApiMobile.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiMobile
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Adiciona serviços ao contêiner.
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            // Adiciona o DbContext ao contêiner
            // Obtenha a string de conexão do arquivo appsettings.json
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

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
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}