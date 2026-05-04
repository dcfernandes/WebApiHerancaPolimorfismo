using CommandApi.Commands;
using CommandApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CommandApi.Tests.Controllers;

public class CommandsControllerTests
{
    private readonly Mock<IMediator> _mediatorMock = new();
    private readonly CommandsController _controller;

    public CommandsControllerTests()
    {
        _controller = new CommandsController(_mediatorMock.Object);
    }

    [Fact]
    public async Task Post_ComCommand_DeveRetornarOkResult()
    {
        var command = new AlterarEnderecoCommand
        {
            Logradouro = "Rua Teste",
            Numero = "1",
            Bairro = "Bairro",
            Cidade = "Cidade",
            Estado = "SP"
        };

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<CommandBase>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("Resultado do handler");

        var result = await _controller.Post(command);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Post_ComCommand_DeveRetornarValorDoHandler()
    {
        var command = new AlterarTelefoneCommand { DDD = "21", Numero = "99999" };

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<CommandBase>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("Resposta do handler");

        var result = await _controller.Post(command);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Resposta do handler", okResult.Value);
    }

    [Fact]
    public async Task Post_DeveEnviarCommandParaMediator()
    {
        var command = new AlterarTelefoneCommand { DDD = "11", Numero = "88888" };

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<CommandBase>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("ok");

        await _controller.Post(command);

        _mediatorMock.Verify(
            m => m.Send(It.Is<CommandBase>(c => c == command), It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
