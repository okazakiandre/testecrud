using Microsoft.AspNetCore.Mvc;
using TesteCrud.Api.Domain;
using System;
using System.Threading.Tasks;

namespace TesteCrud.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private IClienteRepository CliRepo { get; }

        public ClientesController(IClienteRepository cli)
        {
            CliRepo = cli;
        }

        [HttpPost()]
        public async Task<IActionResult> Incluir([FromBody] Cliente cli)
        {
            var ret = await CliRepo.Incluir(cli);
            return Ok(new { sucesso = ret });
        }

        [HttpGet]
        public async Task<IActionResult> Consultar(string nomeParcial, DateTime? dataInicial, DateTime? dataFinal)
        {
            var ret = await CliRepo.Consultar(nomeParcial, dataInicial, dataFinal);
            return Ok(ret);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] Cliente cli)
        {
            var ret = await CliRepo.Atualizar(cli);
            return Ok(new { sucesso = true, docsAlterados = ret });
        }

        [HttpDelete("{cpfCnpj}")]
        public async Task<IActionResult> Excluir(long cpfCnpj)
        {
            var ret = await CliRepo.Excluir(cpfCnpj);
            return Ok(new { sucesso = true, docsAlterados = ret });
        }
    }
}
