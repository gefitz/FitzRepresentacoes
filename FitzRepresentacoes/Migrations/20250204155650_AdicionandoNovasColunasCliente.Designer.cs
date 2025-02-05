﻿// <auto-generated />
using System;
using FitzRepresentacoes.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitzRepresentacoes.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250204155650_AdicionandoNovasColunasCliente")]
    partial class AdicionandoNovasColunasCliente
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("FitzRepresentacoes.Models.CidadeModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("FitzRepresentacoes.Models.ClienteModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Cidadeid")
                        .HasColumnType("int");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("dthNascimeto")
                        .HasColumnType("datetime(6)");

                    b.HasKey("id");

                    b.HasIndex("Cidadeid");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("FitzRepresentacoes.Models.LogModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("InnerExecption")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Messagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("dthErro")
                        .HasColumnType("datetime(6)");

                    b.HasKey("id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("FitzRepresentacoes.Models.PedidoModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Clienteid")
                        .HasColumnType("int");

                    b.Property<short>("Finalizado")
                        .HasColumnType("smallint");

                    b.Property<int>("Produtoid")
                        .HasColumnType("int");

                    b.Property<int>("Usuarioid")
                        .HasColumnType("int");

                    b.Property<DateTime>("dthPedido")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("qtd")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Clienteid");

                    b.HasIndex("Produtoid");

                    b.HasIndex("Usuarioid");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("FitzRepresentacoes.Models.ProdutoModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TpProdutoid")
                        .HasColumnType("int");

                    b.Property<DateTime>("dthAlteracao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("dthCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("qtd")
                        .HasColumnType("int");

                    b.Property<float>("valor")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("TpProdutoid");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("FitzRepresentacoes.Models.TipoProdutoModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TpProduto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("TpProdutos");
                });

            modelBuilder.Entity("FitzRepresentacoes.Models.UsuarioModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Cidadeid")
                        .HasColumnType("int");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("Hash")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<DateTime>("dthNascimento")
                        .HasColumnType("datetime(6)");

                    b.HasKey("id");

                    b.HasIndex("Cidadeid");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("FitzRepresentacoes.Models.ClienteModel", b =>
                {
                    b.HasOne("FitzRepresentacoes.Models.CidadeModel", "Cidade")
                        .WithMany()
                        .HasForeignKey("Cidadeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("FitzRepresentacoes.Models.PedidoModel", b =>
                {
                    b.HasOne("FitzRepresentacoes.Models.ClienteModel", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("Clienteid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitzRepresentacoes.Models.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("Produtoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitzRepresentacoes.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("Usuarioid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Produto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FitzRepresentacoes.Models.ProdutoModel", b =>
                {
                    b.HasOne("FitzRepresentacoes.Models.TipoProdutoModel", "TpProduto")
                        .WithMany()
                        .HasForeignKey("TpProdutoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TpProduto");
                });

            modelBuilder.Entity("FitzRepresentacoes.Models.UsuarioModel", b =>
                {
                    b.HasOne("FitzRepresentacoes.Models.CidadeModel", "Cidade")
                        .WithMany()
                        .HasForeignKey("Cidadeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("FitzRepresentacoes.Models.ClienteModel", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
