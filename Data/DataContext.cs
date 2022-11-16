using Microsoft.EntityFrameworkCore;
using Cemidex_BD.Models;
namespace Cemidex_BD.Data;

public class DataContext : DbContext
{
    public DbSet<Administrador> Administradores { get; set; }
    public DbSet<Anuidade> Anuidades { get; set; }
    public DbSet<Exumacao> Exumacaos { get; set; }
    public DbSet<Falecido> Falecidos { get; set; }
    public DbSet<Jazigo> Jazigos { get; set; }
    public DbSet<Localizacao> Localizacaos { get; set; }
    public DbSet<Memorial> Memorials { get; set; }
    public DbSet<Mensalidade> Mensalidades { get; set; }
    public DbSet<PlanoFunebre> PlanoFunebres { get; set; }
    public DbSet<Requerente> Requerentes { get; set; }
    public DbSet<Sepultamento> Sepultamentos { get; set; }
    public DbSet<Transferencia> Transferencias { get; set; }
    public DbSet<Venda> Vendas { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options){}
}

