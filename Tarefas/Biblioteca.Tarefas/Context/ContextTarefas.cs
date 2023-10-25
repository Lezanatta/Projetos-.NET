using Microsoft.EntityFrameworkCore;
using Biblioteca.Tarefas.Models;
namespace Biblioteca.Tarefas.Context;

internal class ContextTarefas : DbContext
{
    public DbSet<Tarefa> TAREFAS { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.UseOracle("Data Source=localhost:1521/xe;User ID=system;Password=Le123456789;");
}
