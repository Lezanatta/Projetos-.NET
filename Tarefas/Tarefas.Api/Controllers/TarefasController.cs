using Biblioteca.Tarefas;
using Biblioteca.Tarefas.Models;
using Biblioteca.Tarefas.Service;
using Microsoft.AspNetCore.Mvc;
using Tarefas.Api.Service;

namespace Tarefas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private const int _notExisteExcecao = 0;
        private readonly IRepositoryTarefa _repoTarefa;
        public TarefasController() => _repoTarefa = new RepositoryTarefa();

        [HttpGet("/listaTarefas")]
        public ActionResult<Tarefa> Get() => Ok(new ControleTarefas(_repoTarefa).GetListaTarefas());

        [HttpGet("/tarefa")]
        public JsonResult GetTarefa(int cdTarefa)
        {
            var retorno = TratamentoExcecao.TratarExcecaoTarefaException<Tarefa>(() =>
            {
                return new ControleTarefas(_repoTarefa).GetTarefa(cdTarefa);
            });
            return (retorno.IcExcecao == _notExisteExcecao) ? new JsonResult(retorno.Resultado) : new JsonResult(retorno.Resultado);
        }

        [HttpPut]
        public ActionResult AtualizarTarefa(Tarefa tarefa)
        {
            var retorno = TratamentoExcecao.TratarExcecaoTarefaException(() =>
            {
                new ControleTarefas(_repoTarefa).AtualizarTarefa(tarefa);
            });
            return (retorno.IcExcecao == _notExisteExcecao) ? Ok() : BadRequest(retorno.Descricao);
        }

        [HttpDelete]
        public ActionResult ExcluirTarefa(int cdTarefa)
        {
            var retorno = TratamentoExcecao.TratarExcecaoTarefaException(() =>
            {
                new ControleTarefas(_repoTarefa).ExcluirTarefa(cdTarefa);
            });
            return (retorno.IcExcecao == _notExisteExcecao) ? Ok() : BadRequest(retorno.Descricao);
        }

        [HttpPost]
        public ActionResult InserirTarefa(Tarefa tarefa)
        {
            var retorno = TratamentoExcecao.TratarExcecaoTarefaException(() =>
            {
                new ControleTarefas(_repoTarefa).InserirTarefa(tarefa);
            });
            return (retorno.IcExcecao == _notExisteExcecao) ? Ok() : BadRequest(retorno.Descricao);
        }
    } 
}