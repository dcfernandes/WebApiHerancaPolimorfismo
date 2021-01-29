namespace CommandApi.Controllers
{
    using CommandApi.Commands;
    using CommandApi.Commands.SwaggerExamples;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Filters;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CommandsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPatch]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerRequestExample(typeof(CommandBase), typeof(AlterarEnderecoCommandExample))]
        public async Task<IActionResult> Post([FromBody] CommandBase command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}

/*
{
   "commandName":"AlterarTelefone",
   "ddd":"21",
   "numero":"8671891601"
}

{
   "commandName":"AlterarEndereco",
   "logradouro":"Avenida Rio Branco",
   "numero":"1",
   "complemento":"Portão A",
   "bairro": "Centro",
   "cidade": "Rio de Janeiro",
   "estado": "RJ"
}


*/