//using ApiMobile.Filters;
using ApiMobile.Mappers;
using ApiMobile.Models;
using ApiMobile.Repositorios;
using ApiMobile.Services;
using ApiMobile.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Prev Ler", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = @"JWT Authorization header using the Bearer scheme.
                                    \r\n\r\n Enter 'Bearer'[space] and then your token in the text input below.
                                        \r\n\r\nExample: Bearer ishduoiahbdo",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            services.AddHttpClient();
            services.AddSingleton<ICRMApiService, FakeCrmApiService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<RotinaPacienteService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new RotinaDiaSemanaProfile());
                mc.AddProfile(new RotinaExercicioProfile());
                mc.AddProfile(new RotinaProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

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

            //app.UseMiddleware<ErrorHandlingMiddleware>();

            //app.UseExceptionHandler("/error");

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