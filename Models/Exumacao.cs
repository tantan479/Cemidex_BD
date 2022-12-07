using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Cemidex_BD.Models;

public class Exumacao
{
    [Key]
    public int IDExumacao { get; set; }

    public Administrador Administrador { get; set; }
    [ForeignKey("Administrador")]
    public int IDAdministrador { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")][StringLength(256)]
    public string Motivo { get; set; }

}