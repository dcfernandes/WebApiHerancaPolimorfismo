namespace CommandApi
{
    using CommandApi.Commands;
    using CommandApi.Commands.SwaggerExamples;
    using CommandApi.Filters;
    using JsonSubTypes;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Swashbuckle.AspNetCore.Filters;
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
            services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(
                    JsonSubtypesConverterBuilder
                    .Of(typeof(CommandBase), nameof(CommandBase.CommandName))
                    .RegisterSubtype(typeof(AlterarEnderecoCommand), "AlterarEndereco")
                    .RegisterSubtype(typeof(AlterarTelefoneCommand), "AlterarTelefone")
                    .Build()
                );
            });

            var entryAssembly = Assembly.GetEntryAssembly();
            services.AddSwaggerGen(options =>
            {
                var xmlFile = $"{entryAssembly.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                //options.UseAllOfForInheritance();
                options.UseOneOfForPolymorphism();

                options.ExampleFilters();
            });
            services.AddSwaggerExamplesFromAssemblyOf<AlterarEnderecoCommandExample>();

            services.AddMediatR(entryAssembly);
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
