using Lanches_Mac.Models;
using Microsoft.EntityFrameworkCore;

namespace Lanches_Mac.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Categoria> Categorias  { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
    }
}
