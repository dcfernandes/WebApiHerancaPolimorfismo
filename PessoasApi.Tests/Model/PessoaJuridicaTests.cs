using PessoasApi.Model;
using Xunit;

namespace PessoasApi.Tests.Model;

public class PessoaJuridicaTests
{
    [Fact]
    public void Tipo_DeveRetornarJuridica()
    {
        var pessoa = new PessoaJuridica();
        Assert.Equal("Juridica", pessoa.Tipo);
    }

    [Fact]
    public void DeveHerdarDePessoa()
    {
        var pessoa = new PessoaJuridica();
        Assert.IsAssignableFrom<Pessoa>(pessoa);
    }

    [Fact]
    public void Resumo_DeveConterRazaoSocial()
    {
        var pessoa = new PessoaJuridica
        {
            RazaoSocial = "Empresa Teste LTDA",
            Cnpj = "11.222.333/0001-44"
        };

        Assert.Contains("Empresa Teste LTDA", pessoa.Resumo());
    }

    [Fact]
    public void Resumo_DeveConterCnpj()
    {
        var pessoa = new PessoaJuridica
        {
            RazaoSocial = "Empresa",
            Cnpj = "11.222.333/0001-44"
        };

        Assert.Contains("11.222.333/0001-44", pessoa.Resumo());
    }

    [Fact]
    public void Resumo_DeveConterTipoJuridica()
    {
        var pessoa = new PessoaJuridica { RazaoSocial = "Empresa", Cnpj = "000" };
        Assert.Contains("Juridica", pessoa.Resumo());
    }

    [Fact]
    public void Propriedades_DevemSerAtribuidas()
    {
        var pessoa = new PessoaJuridica
        {
            Id = 1,
            Nome = "Empresa LTDA",
            RazaoSocial = "Razão Social Teste",
            Cnpj = "12.345.678/0001-90"
        };

        Assert.Equal(1, pessoa.Id);
        Assert.Equal("Empresa LTDA", pessoa.Nome);
        Assert.Equal("Razão Social Teste", pessoa.RazaoSocial);
        Assert.Equal("12.345.678/0001-90", pessoa.Cnpj);
    }
}
