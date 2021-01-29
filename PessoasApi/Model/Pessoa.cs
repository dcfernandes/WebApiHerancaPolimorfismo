using Newtonsoft.Json;

namespace PessoasApi.Model
{
    public abstract class Pessoa
    {
        [JsonRequired]
        public abstract string Tipo { get; }
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
