using Biblioteca.Tarefas.Models;
using Biblioteca.Tarefas.Service;

namespace Biblioteca.Tarefas;

public class ControleTarefas
{
    private readonly IRepositoryTarefa _repository;
    public ControleTarefas(IRepositoryTarefa repository) => _repository = repository;
    public Tarefa GetTarefa(int cdTarefa) => _repository.GetTarefa(cdTarefa);
    public List<Tarefa> GetListaTarefas() => _repository.GetListaTarefas();
    public void AtualizarTarefa(Tarefa tarefa) => _repository.AtualizarTarefa(tarefa);
    public void InserirTarefa(Tarefa tarefa) => _repository.InserirTarefa(tarefa);
    public void ExcluirTarefa(int cdTarefa) => _repository.ExcluirTarefa(cdTarefa);
}
