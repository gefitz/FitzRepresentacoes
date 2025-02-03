using FitzRepresentacoes.Models;
using Microsoft.EntityFrameworkCore;

namespace FitzRepresentacoes.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<CidadeModel> Cidades { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<TipoProdutoModel> TpProdutos { get; set; }
        public DbSet<LogModel> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Relações de tabela

            #region Pedido
            modelBuilder.Entity<PedidoModel>().HasOne(c => c.Cliente);
            modelBuilder.Entity<PedidoModel>().HasOne(u => u.Usuario);
            modelBuilder.Entity<PedidoModel>().HasOne(p => p.Produto);
            #endregion

            #region Usuario
            modelBuilder.Entity<UsuarioModel>().HasOne(c => c.Cidade);
            #endregion

            #region Produto
            modelBuilder.Entity<ProdutoModel>().HasOne(tp => tp.TpProduto);
            #endregion

            #region Cliente
            modelBuilder.Entity<ClienteModel>().HasOne(c => c.Cidade);
            modelBuilder.Entity<ClienteModel>().HasMany(p => p.Pedidos);
            #endregion

            #endregion
        }
    }
}
