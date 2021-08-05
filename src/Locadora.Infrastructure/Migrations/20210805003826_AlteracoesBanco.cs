using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Infrastructure.Migrations
{
    public partial class AlteracoesBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluguel_Produto_ProdutoId",
                table: "Aluguel");

            migrationBuilder.DropForeignKey(
                name: "FK_Aluguel_Usuario_UsuarioId",
                table: "Aluguel");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Endereco_EnderecoId",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aluguel",
                table: "Aluguel");

            migrationBuilder.DropIndex(
                name: "IX_Aluguel_ProdutoId",
                table: "Aluguel");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Aluguel");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "Produtos");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "Enderecos");

            migrationBuilder.RenameTable(
                name: "Aluguel",
                newName: "Alugueis");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_EnderecoId",
                table: "Usuarios",
                newName: "IX_Usuarios_EnderecoId");

            migrationBuilder.RenameColumn(
                name: "prazo",
                table: "Alugueis",
                newName: "Prazo");

            migrationBuilder.RenameIndex(
                name: "IX_Aluguel_UsuarioId",
                table: "Alugueis",
                newName: "IX_Alugueis_UsuarioId");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Debito",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "AluguelId",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alugueis",
                table: "Alugueis",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_AluguelId",
                table: "Produtos",
                column: "AluguelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alugueis_Usuarios_UsuarioId",
                table: "Alugueis",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Alugueis_AluguelId",
                table: "Produtos",
                column: "AluguelId",
                principalTable: "Alugueis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Enderecos_EnderecoId",
                table: "Usuarios",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alugueis_Usuarios_UsuarioId",
                table: "Alugueis");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Alugueis_AluguelId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Enderecos_EnderecoId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_AluguelId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alugueis",
                table: "Alugueis");

            migrationBuilder.DropColumn(
                name: "Debito",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AluguelId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Produto");

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "Endereco");

            migrationBuilder.RenameTable(
                name: "Alugueis",
                newName: "Aluguel");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_EnderecoId",
                table: "Usuario",
                newName: "IX_Usuario_EnderecoId");

            migrationBuilder.RenameColumn(
                name: "Prazo",
                table: "Aluguel",
                newName: "prazo");

            migrationBuilder.RenameIndex(
                name: "IX_Alugueis_UsuarioId",
                table: "Aluguel",
                newName: "IX_Aluguel_UsuarioId");

            migrationBuilder.AlterColumn<int>(
                name: "Telefone",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "Aluguel",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aluguel",
                table: "Aluguel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Aluguel_ProdutoId",
                table: "Aluguel",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluguel_Produto_ProdutoId",
                table: "Aluguel",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Aluguel_Usuario_UsuarioId",
                table: "Aluguel",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Endereco_EnderecoId",
                table: "Usuario",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
