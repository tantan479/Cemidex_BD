using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cemidex_BD.Models;

public class Anuidade
{
    [Key]
    public int IDAnuidade { get; set; }
    public Venda Venda { get; set; }
    [ForeignKey("Venda")]
    public int IDVenda { get; set; }
}