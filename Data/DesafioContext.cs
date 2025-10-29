using Desafio.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Desafio.Data
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions<DesafioContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Endereco> Endereco { get; set; }

        public DbSet<Contato> Contato { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cliente>()
                .HasOne(e => e.Endereco)
                .WithOne(c => c.Cliente)
                .HasForeignKey<Endereco>(e => e.IdCliente)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .HasOne(e => e.Contato)
                .WithOne(c => c.Cliente)
                .HasForeignKey<Contato>(e => e.IdCliente)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
            .Property(c => c.DataCadastro)
            .HasDefaultValueSql("FORMAT(GETDATE(), 'dd/MM/yyyy HH:mm:ss')");

        }
    }
}
