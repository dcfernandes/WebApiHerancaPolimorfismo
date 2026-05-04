using JsonSubTypes;
using PessoasApi.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Converters.Add(
            JsonSubtypesConverterBuilder
                .Of(typeof(Pessoa), nameof(Pessoa.Tipo))
                .RegisterSubtype(typeof(PessoaFisica), "Fisica")
                .RegisterSubtype(typeof(PessoaJuridica), "Juridica")
                .Build()
        );
    });

builder.Services.AddSwaggerGen(options => options.UseOneOfForPolymorphism());

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program { }
