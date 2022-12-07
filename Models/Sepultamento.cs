using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cemidex_BD.Models;

public class Sepultamento
{
    [Key]
    public int IDSepultamento { get; set; } 

    public Jazigo Jazigo { get; set; }
    [ForeignKey("Jazigo")]
    public int IDJazigo { get; set; }

    public Requerente Requerente { get; set; }
    [ForeignKey("Requerente")]
    public int IDRequerente { get; set; }

    public Falecido Falecido { get; set; }
    [ForeignKey("Falecido")]
    public int IDFalecido { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public DateTime Data { get; set; }
}