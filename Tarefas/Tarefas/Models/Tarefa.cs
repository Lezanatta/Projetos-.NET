using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tarefas.Models;

public class Tarefa
{
    [Key]
    [JsonPropertyName("cd_Tarefa")]
    public int Cd_Tarefa { get; set; }
    [JsonPropertyName("descricao")]
    public string ? Descricao { get; set; }
    [JsonPropertyName("ic_Concluida")]
    public int Ic_Concluida { get; set; }
}
