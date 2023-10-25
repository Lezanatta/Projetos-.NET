using Microsoft.AspNetCore.Mvc;
using Tarefas.Models;

namespace Web.Tarefas.Service;

public interface IServiceTarefas
{
    public List<Tarefa> ObterTarefas(DateTime dtinicio, DateTime dtFim);
}
