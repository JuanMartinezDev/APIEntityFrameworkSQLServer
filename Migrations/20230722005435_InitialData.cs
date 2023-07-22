using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Description", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("0f3f7d9e-7c2a-4460-8149-aeac90e73f02"), null, "Actividades personales", 50 },
                    { new Guid("0f3f7d9e-7c2a-4460-8149-aeac90e73f74"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("0f3f7d9e-7c2a-4460-8149-aeac90e73f10"), new Guid("0f3f7d9e-7c2a-4460-8149-aeac90e73f74"), null, new DateTime(2023, 7, 21, 19, 54, 35, 115, DateTimeKind.Local).AddTicks(7847), 1, "Pago de servicios publicos" },
                    { new Guid("0f3f7d9e-7c2a-4460-8149-aeac90e73f11"), new Guid("0f3f7d9e-7c2a-4460-8149-aeac90e73f02"), null, new DateTime(2023, 7, 21, 19, 54, 35, 115, DateTimeKind.Local).AddTicks(7863), 0, "Terminar de ver peliculas Netflix" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("0f3f7d9e-7c2a-4460-8149-aeac90e73f10"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("0f3f7d9e-7c2a-4460-8149-aeac90e73f11"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("0f3f7d9e-7c2a-4460-8149-aeac90e73f02"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("0f3f7d9e-7c2a-4460-8149-aeac90e73f74"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
