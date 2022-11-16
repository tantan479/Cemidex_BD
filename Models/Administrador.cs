using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cemidex_BD.Models;

public class Administrador
{
    [Key]
    public int IDAdministrador { get; set; }

    [StringLength(11)][Required]
    public string CPF { get; set; }
    [StringLength(32)][Required]
    public string Nome { get; set; }
    [StringLength(13)]
    public string Telefone { get; set; }
    [StringLength(256)][Required]
    public string Email { get; set; }

    [Required]
    public bool gerente { get; set; }

}