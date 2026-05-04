using CommandApi.Commands;
using Xunit;

namespace CommandApi.Tests.Commands;

public class AlterarEnderecoCommandTests
{
    [Fact]
    public void CommandName_DeveRetornarAlterarEndereco()
    {
        var command = new AlterarEnderecoCommand();
        Assert.Equal("AlterarEndereco", command.CommandName);
    }

    [Fact]
    public void DeveHerdarDeCommandBase()
    {
        var command = new AlterarEnderecoCommand();
        Assert.IsAssignableFrom<CommandBase>(command);
    }

    [Fact]
    public void Propriedades_DevemSerAtribuidas()
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

        Assert.Equal("Avenida Rio Branco", command.Logradouro);
        Assert.Equal("1", command.Numero);
        Assert.Equal("Portão A", command.Complemento);
        Assert.Equal("Centro", command.Bairro);
        Assert.Equal("Rio de Janeiro", command.Cidade);
        Assert.Equal("RJ", command.Estado);
    }
}
