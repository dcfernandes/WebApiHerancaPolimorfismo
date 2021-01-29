using Newtonsoft.Json;

namespace CommandApi.Commands
{
    public class AlterarEnderecoCommand : CommandBase
    {
        public override string CommandName => "AlterarEndereco";

        [JsonRequired]
        public string Logradouro { get; set; }

        [JsonRequired]
        public string Numero { get; set; }
        public string Complemento { get; set; }

        [JsonRequired]
        public string Bairro { get; set; }

        [JsonRequired]
        public string Cidade { get; set; }

        [JsonRequired]
        public string Estado { get; set; }
    }
}
