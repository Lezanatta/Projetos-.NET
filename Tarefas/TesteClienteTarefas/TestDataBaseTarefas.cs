using Biblioteca.Tarefas;
using Biblioteca.Tarefas.Exceptions;
using Biblioteca.Tarefas.Models;
using Biblioteca.Tarefas.Service;

namespace TesteClienteTarefas
{
    public class TestDataBaseTarefas
    {
        [Fact]
        public void TestGetListaTarefas()
        {
            var controle = new ControleTarefas(new RepositoryTarefa());
            var tarefas = controle.GetListaTarefas();
            Assert.NotNull(tarefas);
        }
        [Fact]
        public void TestGetTarefa()
        {
            var controle = new ControleTarefas(new RepositoryTarefa());
            var tarefa = controle.GetTarefa(1);
            Assert.NotNull(tarefa);
        }
        [Fact]
        public void TestExceptionGetTarefa()
        {
            var controle = new ControleTarefas(new RepositoryTarefa());
            var cd = controle.GetListaTarefas().Select(tarefa => tarefa.Cd_Tarefa).Max();
            Assert.Throws<TarefaException>(() =>
                controle.GetTarefa(cd + 1)
            );
        }
        [Fact]
        public void TestExceptionInserirTarefa()
        {
            var controle = new ControleTarefas(new RepositoryTarefa());
            var tarefa = new Tarefa()
            {
                Cd_Tarefa = 0,
                Descricao = null,
                Ic_Concluida = 0
            };
            Assert.Throws<DataBaseException>(() =>
                controle.InserirTarefa(tarefa)
            );
        }
        [Fact]
        public void TestExceptionAtualizarTarefa()
        {
            var controle = new ControleTarefas(new RepositoryTarefa());
            var tarefa = new Tarefa()
            {
                Cd_Tarefa = 0,
                Descricao = null,
                Ic_Concluida = 0
            };
            Assert.Throws<DataBaseException>(() =>
                    controle.AtualizarTarefa(tarefa)
                );
        }        
        [Fact]
        public void TestExceptionExcluirTarefa()
        {
            var controle = new ControleTarefas(new RepositoryTarefa());
            var cd = controle.GetListaTarefas().Select(tar => tar.Cd_Tarefa).Max();
            var tarefa = new Tarefa()
            {
                Cd_Tarefa = 0,
                Descricao = null,
                Ic_Concluida = 0
            };
            Assert.Throws<DataBaseException>(() =>
                    controle.ExcluirTarefa(cd + 1)
               );
        }
    }
}