using Microsoft.EntityFrameworkCore;
using Projeto_Entity.Models;

namespace Projeto_Entity.Context;

internal class ProjetoContext: DbContext
{
    public DbSet<Notificacao> NOTIFICACAO { get; set; }
    public DbSet<NotificacaoControl> NOTIFICACAO_CONTROL { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
            "(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)" +
            "(SERVICE_NAME=xe)));User Id=system;Password=le123456789;"); 
    }

}
