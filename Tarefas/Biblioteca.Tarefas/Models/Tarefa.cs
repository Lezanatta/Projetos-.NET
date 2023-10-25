using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Tarefas.Models;

public class Tarefa
{
    [Key]
    [Column("CD_TAREFA")]
    public int Cd_Tarefa { get; set; }
    [Column("DESCRICAO")]
    public string ?Descricao { get; set; }
    [Column("IC_CONCLUIDA")]
    public int Ic_Concluida { get; set; }
}
