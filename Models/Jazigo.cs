using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cemidex_BD.Models;

public class Jazigo
{
    [Key]
    public int IDJazigo { get; set; }

    public Localizacao Localizacao { get; set; }
    [ForeignKey("Localizacao")]
    public int IDLocal { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")][Display(Name = "Número de Espaços")]
    public int NumEspacos { get; set; }
}