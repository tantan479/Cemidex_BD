using System.ComponentModel.DataAnnotations;

namespace Cemidex_BD.Models;


public class Localizacao
{
    [Key]
    public int IDLocal { get; set; }

    [StringLength(16)][Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string Nome { get; set; }

    [StringLength(1024)][Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string Descricao { get; set; }
}