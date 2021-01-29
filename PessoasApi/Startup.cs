namespace PessoasApi
{
    using JsonSubTypes;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using PessoasApi.Model;
    using System;
    using System.IO;
    using System.Reflection;

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
            //Tratando o aspnet core para conseguir ler e responder subclasses
            services.AddControllers().AddNewtonsoftJson(options =>
                                     {
                                         options.SerializerSettings.Converters.Add(
                                             JsonSubtypesConverterBuilder
                                             .Of(typeof(Pessoa), nameof(Pessoa.Tipo))
                                             .RegisterSubtype(typeof(PessoaFisica), "Fisica")
                                             .RegisterSubtype(typeof(PessoaJuridica), "Juridica")
                                             .Build()
                                         );
                                     })
                ;

            var entryAssembly = Assembly.GetEntryAssembly();
            services.AddSwaggerGen(options =>
            {
                var xmlFile = $"{entryAssembly.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                options.UseOneOfForPolymorphism();

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


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
