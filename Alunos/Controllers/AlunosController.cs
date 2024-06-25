using Alunos.Models;
using Alunos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Produces("application/json")]
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
                return Ok(alunos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error ao obter alunos");

            }
        }

        [HttpGet("AlunosPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunosByNome([FromQuery] string nome)
        {
            try
            {
                var alunos = await _alunoService.GetAlunosByNome(nome);
                if (alunos == null)
                    return NotFound($"Não existe aluno com esse nome {nome}");
                return Ok(alunos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error ao obter alunos");

            }

        }
        [HttpGet("{id:int}", Name = "GetAluno")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            try
            {
                var aluno = await _alunoService.GetAluno(id);
                if (aluno == null)
                    return NotFound($"não existe aluno com essa essa id:{id}");
                return Ok(aluno);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error ao obter aluno");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create(Aluno aluno)
        {
            try
            {
                await _alunoService.CreateAluno(aluno);
                return CreatedAtRoute(nameof(GetAluno), new { id = aluno.Id }, aluno);
            }
            catch
            {
                return BadRequest("Request inválido");
            }

        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Editar(int id,[FromBody]Aluno aluno)
        {

            try
            {
                if (aluno.Id == id )
                {
                    await _alunoService.UpdateAluno(aluno);
                    return Ok($"aluno com id={id} foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Dados errados");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }


        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {

            try
            {
                var aluno = await _alunoService.GetAluno(id);
                if (aluno != null)
                 await _alunoService.DeleteAluno(aluno);
                return Ok($"Aluno de id:{id} foi deletado com sucesso");
            }
            catch
            {
                return BadRequest("Request inválido");
            }


        }
    }
}
