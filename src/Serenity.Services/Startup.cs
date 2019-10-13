using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serenity.CrossCutting.Contracts.Security;
using Serenity.CrossCutting.Security;
using Serenity.Infra.Data.Contacts.Repositories;
using Serenity.Infra.Data.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using System.Data.SqlClient;

namespace Serenity.Services
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var connectionString = Configuration.GetConnectionString("SerenityDB");

            services.AddTransient<ICriptografia, Criptografia>();

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1",
                new Info
                {
                    Title = "Projeto Serenity",
                    Version = "v1",
                    Description = "API utilizando ASP.NET core com autenticação JWT.",
                    Contact = new Contact
                    {
                        Name = "Luiz Guilherme Bandeira",
                        Url = "https://github.com/arkanael",
                        Email = "arkanael@gmail.com"
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Pojeto ASP.NET CORE 2.2 WEB API");
            });
        }
    }
}
