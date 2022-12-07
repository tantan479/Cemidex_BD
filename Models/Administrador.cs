using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Cemidex_BD.Models;

[Index(nameof(Email), IsUnique = true)]

public class Administrador
{
    [Key]
    public int IDAdministrador { get; set; }

    [StringLength(11)][Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string CPF { get; set; }

    [StringLength(32)][Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string Nome { get; set; }

    [StringLength(13)]
    public string Telefone { get; set; }

    [StringLength(256)][Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public bool Gerente { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Senha { get; set; }

    [NotMapped]
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirmação de Senha")]
    [Compare("Senha")]
    public string ConfSenha { get; set; }

}