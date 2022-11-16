using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cemidex_BD.Models;

public class Transferencia{
    [Key]
    public int IDTransferencia { get; set; }

    public Jazigo Jazigo { get; set; }
    public Jazigo Jazigo1 { get; set; }
    
    [ForeignKey("Jazigo")]
    public int IDJazigo1 { get; set; }
    [ForeignKey("Jazigo1")]
    public int IDJazigo2 { get; set; }

    public Sepultamento Sepultamento { get; set; }
    [ForeignKey("Sepultamento")]
    public int IDSepultamento { get; set; }

    public string IDS {get; set;}

    public Administrador Administrador { get; set; }
    [ForeignKey("Administrador")]
    public int IDAdm { get; set; }

    [Required][StringLength(512)]
    public string Motivo { get; set; }
}