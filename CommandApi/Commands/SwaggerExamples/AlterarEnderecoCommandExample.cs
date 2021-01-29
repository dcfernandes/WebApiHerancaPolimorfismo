namespace CommandApi.Commands.SwaggerExamples
{
    using Swashbuckle.AspNetCore.Filters;
    using System;
    using System.Collections.Generic;

    public class AlterarEnderecoCommandExample : IExamplesProvider<Dictionary<string, CommandBase>>
    {
        public Dictionary<string, CommandBase> GetExamples()
        {
            var exemplos = new Dictionary<string, CommandBase>();
            exemplos.Add("Comando para Altera o Endereço", new AlterarEnderecoCommand()
            {
                Logradouro = "Avenida Rio Branco",
                Numero = "1",
                Complemento = "Bloco 1",
                Bairro = "Centro",
                Cidade = "Rio de Janeiro",
                Estado = "RJ"
            });

            exemplos.Add("Comando para Altera o Telefone", new AlterarTelefoneCommand()
            {
                DDD = "21",
                Numero = "9087654321"
            });

            return exemplos;
        }
    }
}
