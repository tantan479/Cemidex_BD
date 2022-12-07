using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cemidex_BD.Models;

public class Memorial{
    [Key]
    public int IDMemorial { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")][StringLength(10000)]
    public string Descricao { get; set; }

    public Falecido Falecido { get; set; }

    [ForeignKey("Falecido")]
    public int IDFalecido { get; set; }
}