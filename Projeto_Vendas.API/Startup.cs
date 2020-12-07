using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Projeto_Vendas_Lib.Infra.Context;
using Projeto_Vendas_Lib.Domain;
using Projeto_Vendas_Lib.Service;
using Autofac;
using Projeto_Vendas_Lib.IOC;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.IO;

namespace Projeto_Vendas.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ProjetoContext>(opt => opt.UseInMemoryDatabase("ProjetoVendas"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Projeto API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "William Gontijo",
                        Email = "william854@live.com",
                        Url = new Uri("https://www.linkedin.com/in/william-gontijo-543628142/"),
                    },
                   
                });
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);


            });
            }

        //Configurando o AUTOFAC
        public void ConfigureContainer(ContainerBuilder builder) => builder.RegisterModule(new ModuleIOC());


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var scope = app.ApplicationServices.CreateScope();
            var service = scope.ServiceProvider.GetService<ProjetoContext>();

            AdicionarDadosIniciais(service);

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto Vendas");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AdicionarDadosIniciais(ProjetoContext context)
        {
            Cliente cliente = new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = "Joao Cliente",
                Email = "JoaoCliente@yahoo.com",
                CPF = "064.6464.54.5454",
                EnderecodeEntrega = "Rua X, Bairro Y, Cidade J",
                Telefone = "31 3131-3131"

            };
            context.Clientes.Add(cliente);

            Vendedor vendedor = new Vendedor
            {
                Id = Guid.NewGuid(),
                Nome = "Claudio Vendedor",
                Email = "ClaudioVendedor@yahoo.com",
                CPF = "111.111111.1111",
                Telefone = "31 3232-3232"
            };
            context.Vendedores.Add(vendedor);
            context.SaveChanges();
        }
    }
}
