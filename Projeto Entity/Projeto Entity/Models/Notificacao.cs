using LinqToDB;
using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Entity.Models;

internal class Notificacao
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [SequenceName(ProviderName.Oracle, "NOTIFICACAO_SEQ")]
    public int CD_NOT { get; set; }
    public string? NOME { get; set; }
    public string? CIDADE { get; set; }
}
