using CommandApi.Commands;
using CommandApi.Commands.SwaggerExamples;
using JsonSubTypes;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
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

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<Handler>());

builder.Services.AddSwaggerGen(options =>
{
    options.UseOneOfForPolymorphism();
    options.ExampleFilters();
});
builder.Services.AddSwaggerExamplesFromAssemblyOf<AlterarEnderecoCommandExample>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program { }
