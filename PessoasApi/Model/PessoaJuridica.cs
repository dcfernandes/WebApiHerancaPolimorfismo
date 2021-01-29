namespace PessoasApi.Model
{
    public class PessoaJuridica : Pessoa
    {
        public override string Tipo => "Juridica";
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
    }
}
