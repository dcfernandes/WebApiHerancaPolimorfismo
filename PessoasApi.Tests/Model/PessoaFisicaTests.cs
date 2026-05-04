using PessoasApi.Model;
using System;
using Xunit;

namespace PessoasApi.Tests.Model;

public class PessoaFisicaTests
{
    [Fact]
    public void Tipo_DeveRetornarFisica()
    {
        var pessoa = new PessoaFisica();
        Assert.Equal("Fisica", pessoa.Tipo);
    }

    [Fact]
    public void DeveHerdarDePessoa()
    {
        var pessoa = new PessoaFisica();
        Assert.IsAssignableFrom<Pessoa>(pessoa);
    }

    [Fact]
    public void Resumo_DeveConterNome()
    {
        var pessoa = new PessoaFisica
        {
            Nome = "João Silva",
            Nascimento = new DateTime(1990, 1, 15),
            Cpf = "123.456.789-00"
        };

        Assert.Contains("João Silva", pessoa.Resumo());
    }

    [Fact]
    public void Resumo_DeveConterDataDeNascimentoFormatada()
    {
        var pessoa = new PessoaFisica
        {
            Nome = "Maria",
            Nascimento = new DateTime(1990, 1, 15),
            Cpf = "111"
        };

        Assert.Contains("15/01/1990", pessoa.Resumo());
    }

    [Fact]
    public void Resumo_DeveConterCpf()
    {
        var pessoa = new PessoaFisica
        {
            Nome = "João",
            Nascimento = DateTime.Today,
            Cpf = "123.456.789-00"
        };

        Assert.Contains("123.456.789-00", pessoa.Resumo());
    }

    [Fact]
    public void Resumo_DeveConterTipoFisica()
    {
        var pessoa = new PessoaFisica { Nome = "Teste", Nascimento = DateTime.Today, Cpf = "000" };
        Assert.Contains("Fisica", pessoa.Resumo());
    }

    [Fact]
    public void Id_DeveSerAtribuido()
    {
        var pessoa = new PessoaFisica { Id = 42 };
        Assert.Equal(42, pessoa.Id);
    }

    [Fact]
    public void DadosSaude_DevemSerAtribuidos()
    {
        var dados = new DadosSaude { Fumante = true, PraticaEsporte = false };
        var pessoa = new PessoaFisica { DadosSaude = dados };

        Assert.True(pessoa.DadosSaude.Fumante);
        Assert.False(pessoa.DadosSaude.PraticaEsporte);
    }
}
