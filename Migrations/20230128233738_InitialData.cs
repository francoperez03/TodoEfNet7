using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoEfNet7.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("4d7c7344-73a4-4ced-9bd6-93591a400254"), null, "Actividades personales", 50 },
                    { new Guid("e3799547-fa23-450c-86a5-35dd27f685e9"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreationDate", "Description", "PriorityTask", "Title", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("673f244d-657b-46fe-a7fc-fe1fbe3e542e"), new Guid("4d7c7344-73a4-4ced-9bd6-93591a400254"), new DateTime(2023, 1, 28, 20, 37, 38, 275, DateTimeKind.Local).AddTicks(8240), null, 0, "Terminar de ver peliculas en Netflix", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a4a744c3-e994-458d-b260-0b896b752192"), new Guid("e3799547-fa23-450c-86a5-35dd27f685e9"), new DateTime(2023, 1, 28, 20, 37, 38, 275, DateTimeKind.Local).AddTicks(8210), null, 1, "Pago de servicios publicos", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("673f244d-657b-46fe-a7fc-fe1fbe3e542e"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("a4a744c3-e994-458d-b260-0b896b752192"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("4d7c7344-73a4-4ced-9bd6-93591a400254"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("e3799547-fa23-450c-86a5-35dd27f685e9"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
