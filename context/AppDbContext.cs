using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace estoqueMVC2.context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Produto> Produtos { get; set; }
        public DbSet<Models.ItemEstoque> ItensEstoque { get; set; }
        public DbSet<Models.Estoque> Estoques { get; set; }
        public DbSet<Models.Relatorio> Relatorios { get; set; }

    }
}