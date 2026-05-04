using Microsoft.AspNetCore.Mvc;
using PessoasApi.Controllers;
using PessoasApi.Model;
using System;
using Xunit;

namespace PessoasApi.Tests.Controllers;

public class PessoasControllerTests
{
    private readonly PessoasController _controller = new();

    [Fact]
    public void Get_DeveRetornarOkResult()
    {
        var result = _controller.Get();
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Get_DeveRetornarListaDePessoas()
    {
        var result = _controller.Get();
        var okResult = Assert.IsType<OkObjectResult>(result);
        var pessoas = Assert.IsAssignableFrom<Pessoa[]>(okResult.Value);
        Assert.NotEmpty(pessoas);
    }

    [Fact]
    public void Get_DeveRetornarDuasPessoas()
    {
        var result = _controller.Get();
        var okResult = Assert.IsType<OkObjectResult>(result);
        var pessoas = (Pessoa[])okResult.Value!;
        Assert.Equal(2, pessoas.Length);
    }

    [Fact]
    public void GetById_ComIdDePessoaFisica_DeveRetornarPessoaFisica()
    {
        var result = _controller.Get(10);
        var okResult = Assert.IsType<OkObjectResult>(result);
        var pessoa = Assert.IsType<PessoaFisica>(okResult.Value);
        Assert.Equal(10, pessoa.Id);
    }

    [Fact]
    public void GetById_ComIdDePessoaJuridica_DeveRetornarPessoaJuridica()
    {
        var result = _controller.Get(20);
        var okResult = Assert.IsType<OkObjectResult>(result);
        var pessoa = Assert.IsType<PessoaJuridica>(okResult.Value);
        Assert.Equal(20, pessoa.Id);
    }

    [Fact]
    public void GetById_ComIdInexistente_DeveRetornarNotFound()
    {
        var result = _controller.Get(999);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Post_ComPessoaFisica_DeveRetornarNomeDoTipoNoResultado()
    {
        var pessoa = new PessoaFisica
        {
            Id = 1,
            Nome = "João",
            Cpf = "111.222.333-44",
            Nascimento = new DateTime(1990, 5, 15)
        };

        var result = _controller.Post(pessoa);

        Assert.Contains("PessoaFisica", result);
    }

    [Fact]
    public void Post_ComPessoaFisica_DeveConterResumoNaResposta()
    {
        var pessoa = new PessoaFisica
        {
            Id = 1,
            Nome = "João",
            Cpf = "111.222.333-44",
            Nascimento = new DateTime(1990, 5, 15)
        };

        var result = _controller.Post(pessoa);

        Assert.Contains("João", result);
        Assert.Contains("111.222.333-44", result);
    }

    [Fact]
    public void Post_ComPessoaJuridica_DeveRetornarNomeDoTipoERazaoSocial()
    {
        var pessoa = new PessoaJuridica
        {
            Id = 2,
            Nome = "Empresa",
            RazaoSocial = "Empresa LTDA",
            Cnpj = "00.111.222/0001-33"
        };

        var result = _controller.Post(pessoa);

        Assert.Contains("PessoaJuridica", result);
        Assert.Contains("Empresa LTDA", result);
    }
}
