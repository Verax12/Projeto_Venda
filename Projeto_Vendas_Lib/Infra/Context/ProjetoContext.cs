using Microsoft.EntityFrameworkCore;
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
    }
}

