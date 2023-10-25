using Biblioteca.Tarefas.Context;
using Biblioteca.Tarefas.Exceptions;
using Biblioteca.Tarefas.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Biblioteca.Tarefas.Service;

public class RepositoryTarefa : IRepositoryTarefa
{
    public void AtualizarTarefa(Tarefa tarefa) 
    {
        try
        {
            using var context = new ContextTarefas();
            context.TAREFAS.Update(tarefa);
            context.SaveChanges();
        }catch(DbUpdateException e)
        {
            throw new DataBaseException("Erro ao atualizar os dados da tarefa...");
        }

    }
    public void ExcluirTarefa(int cdTarefa) 
    {
        try
        {
            using var context = new ContextTarefas();
            var tarefa = context.TAREFAS.FirstOrDefault(tar => tar.Cd_Tarefa == cdTarefa);
            context.TAREFAS.Remove(tarefa);
            context.SaveChanges();
        }
        catch(ArgumentNullException e){
            throw new DataBaseException("Erro ao excluir tarefa...");
        }
    }
    public List<Tarefa> GetListaTarefas()
    {
        using var context = new ContextTarefas();
        return context.TAREFAS.ToList();
    }

    public Tarefa GetTarefa(int cdTarefa) {
        using var context = new ContextTarefas();
        var resultado = context.TAREFAS.Select(tarefa => tarefa.Cd_Tarefa).ToList().Contains(cdTarefa);
        return (resultado) ? context.TAREFAS.Where(tarefa => tarefa.Cd_Tarefa == cdTarefa).FirstOrDefault() :
            throw new TarefaException("Tarefa não encontrada com esse id");
    }
    public void InserirTarefa(Tarefa tarefa) 
    {
        try
        {
            using var context = new ContextTarefas();
            var isExisteTarefaId = context.TAREFAS.Select(tar => tar.Cd_Tarefa).ToList().Contains(tarefa.Cd_Tarefa);
            if(isExisteTarefaId)
            {
                throw new CdTarefaException("Tarefa não pode ser incluída com esse id...");
            }
            context.TAREFAS.Add(tarefa);
            context.SaveChanges();
        }
        catch (DbUpdateException e)
        {
            throw new DataBaseException("Erro ao inserir os dados da tarefa...");
        }
    }
}
