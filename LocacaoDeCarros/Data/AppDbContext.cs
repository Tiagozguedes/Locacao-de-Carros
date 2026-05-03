using LocacaoDeCarros.Models;
using Microsoft.EntityFrameworkCore;

namespace LocacaoDeCarros.Data;
//A
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Carro> Carros { get; set; }
}
