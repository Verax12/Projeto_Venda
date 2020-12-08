using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Vendas_Lib.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Vendas_Lib.Infra.Context
{
    public class ProjetoContext : DbContext
    {
        public ProjetoContext(DbContextOptions<ProjetoContext> options)
   : base(options)
        { }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venda>().HasOne(v => v.Cliente);
            modelBuilder.Entity<Venda>().HasOne(v => v.Vendedor);
            modelBuilder.Entity<Venda>().HasMany(v => v.Itens);
            //modelBuilder.Entity<Cliente>().HasMany(c => c.Vendas).WithOne(c => c.Cliente);
            //modelBuilder.Entity<Vendedor>().HasMany(c => c.Vendas).WithOne(c => c.Vendedor);
           

            // N - N
            //modelBuilder.Entity<VendaItem>().HasKey(x => new { x.ItemId, x.VendaId });
            //modelBuilder.Entity<VendaItem>().HasOne(x => x.Venda).WithMany(x => x.VendaItens).HasForeignKey(x => x.VendaId);
            //modelBuilder.Entity<VendaItem>().HasOne(x => x.Item).WithMany(x => x.VendaItens).HasForeignKey(x => x.ItemId);



        }
    }
}

