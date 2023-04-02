using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext
{
    public DbSet<Carro> Carro{get; set;}
    public DbSet<Cliente> Cliente{ get; set; } 
    public Contexto(DbContextOptions <Contexto> options): base(options){}
}