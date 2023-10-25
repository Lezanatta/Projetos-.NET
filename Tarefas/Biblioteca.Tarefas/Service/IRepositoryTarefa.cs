using Biblioteca.Tarefas.Models;

namespace Biblioteca.Tarefas.Service;

public interface IRepositoryTarefa
{
    public Tarefa GetTarefa(int cdTarefa);
    public List<Tarefa> GetListaTarefas();
    public void InserirTarefa(Tarefa tareffa);
    public void AtualizarTarefa(Tarefa tarefa);
    public void ExcluirTarefa(int cdTarefa);
}
