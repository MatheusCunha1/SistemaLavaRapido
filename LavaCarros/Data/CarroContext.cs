using Microsoft.EntityFrameworkCore;

namespace LavaCarros.Data
{
    public class CarroContext : DbContext
    {
        public DbSet<Carro>? Carros { get; set; }
        public DbSet<ServicoLavagem>? ServicosLavagem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=127.0.0.1;Database=lavacarros;User=root;Password=;Port=3306;",
                new MySqlServerVersion(new Version(10, 4, 28)));
        }

    }
}
