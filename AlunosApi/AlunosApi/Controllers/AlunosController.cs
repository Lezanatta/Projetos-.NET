using AlunosApi.Models;
using AlunosApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlunosApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlunosController : ControllerBase
{
    private readonly IAlunoService _service;
    public AlunosController(IAlunoService service)
        => _service = service;

    [HttpGet]
    public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
    {
        try
        {
            var alunos = await _service.Getalunos();
            return Ok(alunos);
        }
        catch (Exception)
        {
            return BadRequest("Erro ao consultar os alunos...");
        }
    }

    [HttpGet("AlunosPorNome")]
    public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunosByName([FromQuery] string nome)
    {
        try
        {
            var alunos = await _service.GetAlunosByNome(nome);
            if (alunos == null)
                return NotFound($"Não existem alunos com o nome {nome} na base de dados.");
            return Ok(alunos);
        }
        catch (Exception)
        {
            return BadRequest("Erro ao consultar o aluno por nome...");
        }
    }
    [HttpGet("{id:int}", Name = "GetAluno")]
    public async Task<ActionResult<Aluno>> GetAluno(int id)
    {
        try
        {
            var aluno = await _service.GetAluno(id);
            if (aluno == null)
            {
                return NotFound("Aluno não encontrado...");
            }
            return Ok(aluno);
        }
        catch (Exception)
        {

            return BadRequest("Requisição indisponível...");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Create(Aluno aluno)
    {
        try
        {
            await _service.CreateAluno(aluno);
            return CreatedAtRoute(nameof(GetAluno), new { id = aluno.Id }, aluno);  
        }
        catch (Exception)
        {

            return BadRequest("Requisição indisponível...");
        }     
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id,[FromBody] Aluno aluno)
    {
        try
        {
            if(aluno.Id == id)
            {
                await _service.UpdateAluno(aluno);
                return Ok($"Aluno com id = {id} alterado com sucesso!");
            }
            else
            {
                return BadRequest("Dados inconsistentes...");   
            }
        }
        catch (Exception)
        {

            return BadRequest("Requisição indisponível...");
        }
    }

    [HttpDelete("id:int")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var aluno = await _service.GetAluno(id);
            if (aluno == null)
            {
                return NotFound($"Aluno com Id = {id} não encontrado...");
            }
            else
            {
                await _service.DeleteAluno(aluno);
                return Ok($"Aluno com id = {id} deletado com sucesso!");
            }
        }
        catch (Exception)
        {
            return BadRequest("Requisição indisponível...");
        }        
    }
}

