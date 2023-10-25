using System.ComponentModel.DataAnnotations;

namespace Projeto_Entity.Models;

internal class NotificacaoControl
{
    [Key]
    public int CD_CONTROL { get; set; }
    public int CD_NOT { get; set; }
    public int CD_REPOSITORIO { get; set; }
    public Notificacao? Notificacao { get; set; }
}
