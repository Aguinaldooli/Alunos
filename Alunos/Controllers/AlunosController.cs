using Alunos.Models;
using Alunos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    //Retorna os dados em formato json

    //A classe herda do ControllerBase que é do framework
    public class AlunosController : ControllerBase
    {
        private IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            //_alunoService salva o contexto dos métodos da interface
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
        {
            try
            {
                var alunos = await _alunoService.GetAlunos();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error ao obter alunos");
            }
        }
    }
}
