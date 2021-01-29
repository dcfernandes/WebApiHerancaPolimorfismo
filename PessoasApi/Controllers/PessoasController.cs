// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PessoasApi.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using PessoasApi.Model;
    using Swashbuckle.AspNetCore.Annotations;
    using System;

    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Pessoa[]), StatusCodes.Status200OK)]
        public IActionResult Get() => Ok(pessoas);

        // GET api/<PessoasController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Pessoa), StatusCodes.Status200OK)]
        public IActionResult Get(int id)
        {
            var result = Array.Find(pessoas, p => p.Id == id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        public string Post([FromBody] Pessoa pessoa)
        {
            return pessoa.GetType().Name;
        }

        private readonly Pessoa[] pessoas = new Pessoa[] {
                    new PessoaFisica() {
                    Id = 10,
                    Nome = "Pessoa Fisica 1",
                    Cpf = "XXXXXXXXXXXXXXX",
                    Nascimento = DateTime.Today.AddYears(18),
                    DadosSaude = new DadosSaude(){Fumante = false, PraticaEsporte = true }
                },
                    new PessoaJuridica() {
                    Id = 20,
                    Nome = "Pessoa Juridica 1",
                    Cnpj = "YYYYYYYYYYYYYYYYYYY",
                    RazaoSocial = "Razao Social 1"
                }
            };
    }
}
