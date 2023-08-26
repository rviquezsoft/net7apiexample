using System;
using Microsoft.EntityFrameworkCore;


namespace API.Context
{
	public class APIContext:DbContext
	{
        public APIContext(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<SharedLibrary.Models.Cliente> Clientes { get; set; }
        public DbSet<SharedLibrary.Models.Usuario> Usuarios { get; set; }
        public DbSet<SharedLibrary.Models.Empleado> Empleados { get; set; }

        private readonly IConfiguration _config;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_config.GetConnectionString(SharedLibrary.Constants.CONNECTIONSTRINGNAME));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SharedLibrary.Models.Empleado>().HasKey(pk => new {pk.id,pk.dnsNumber});
        }
    }
}

