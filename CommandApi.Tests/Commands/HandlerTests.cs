using CommandApi.Commands;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CommandApi.Tests.Commands;

public class HandlerTests
{
    private readonly Handler _handler = new();

    [Fact]
    public async Task Handle_AlterarEnderecoCommand_DeveRetornarMensagemFormatada()
    {
        var command = new AlterarEnderecoCommand
        {
            Logradouro = "Avenida Rio Branco",
            Numero = "1",
            Complemento = "Portão A",
            Bairro = "Centro",
            Cidade = "Rio de Janeiro",
            Estado = "RJ"
        };

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.StartsWith("Endereço alterado para:", result);
        Assert.Contains("Avenida Rio Branco", result);
        Assert.Contains("Rio de Janeiro", result);
        Assert.Contains("RJ", result);
    }

    [Fact]
    public async Task Handle_AlterarEnderecoCommand_ComComplemento_DeveIncluirComplemento()
    {
        var command = new AlterarEnderecoCommand
        {
            Logradouro = "Rua A",
            Numero = "10",
            Complemento = "Apto 5",
            Bairro = "Bairro B",
            Cidade = "Cidade C",
            Estado = "SP"
        };

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.Contains("Apto 5", result);
    }

    [Fact]
    public async Task Handle_AlterarTelefoneCommand_DeveRetornarMensagemFormatada()
    {
        var command = new AlterarTelefoneCommand
        {
            DDD = "21",
            Numero = "999999999"
        };

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.Equal("Telefone alterado para: (21) 999999999", result);
    }

    [Fact]
    public async Task Handle_AlterarTelefoneCommand_DeveConterDdd()
    {
        var command = new AlterarTelefoneCommand { DDD = "11", Numero = "12345678" };
        var result = await _handler.Handle(command, CancellationToken.None);
        Assert.Contains("(11)", result);
    }

    [Fact]
    public async Task Handle_AlterarTelefoneCommand_DeveConterNumero()
    {
        var command = new AlterarTelefoneCommand { DDD = "11", Numero = "12345678" };
        var result = await _handler.Handle(command, CancellationToken.None);
        Assert.Contains("12345678", result);
    }
}
