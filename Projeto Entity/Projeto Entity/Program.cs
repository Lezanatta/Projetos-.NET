using Microsoft.EntityFrameworkCore;
using Projeto_Entity.Context;
using Projeto_Entity.Models;

using (var context = new ProjetoContext())
{
    var notificacao = new Notificacao()
    {
        CIDADE = "Jandira",
        NOME = "Leandro"
    };
    using (var connection = context.Database.GetDbConnection())
    {
        connection.Open();

        using (var command = connection.CreateCommand())
        {
            command.CommandText = "select GetNextValueFromSequence('NOTIFICACAO_SEQ') from dual";
            int result = Convert.ToInt32(command.exe);
        }
    }
}