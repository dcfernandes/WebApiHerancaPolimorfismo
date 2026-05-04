using CommandApi.Commands;
using Xunit;

namespace CommandApi.Tests.Commands;

public class AlterarTelefoneCommandTests
{
    [Fact]
    public void CommandName_DeveRetornarAlterarTelefone()
    {
        var command = new AlterarTelefoneCommand();
        Assert.Equal("AlterarTelefone", command.CommandName);
    }

    [Fact]
    public void DeveHerdarDeCommandBase()
    {
        var command = new AlterarTelefoneCommand();
        Assert.IsAssignableFrom<CommandBase>(command);
    }

    [Fact]
    public void Propriedades_DevemSerAtribuidas()
    {
        var command = new AlterarTelefoneCommand
        {
            DDD = "21",
            Numero = "999999999"
        };

        Assert.Equal("21", command.DDD);
        Assert.Equal("999999999", command.Numero);
    }
}
