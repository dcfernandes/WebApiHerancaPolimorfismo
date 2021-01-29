using Newtonsoft.Json;

namespace CommandApi.Commands
{
    public class AlterarTelefoneCommand : CommandBase
    {
        public override string CommandName => "AlterarTelefone";
        [JsonRequired]
        public string DDD { get; set; }

        [JsonRequired]
        public string Numero { get; set; }
    }
}
