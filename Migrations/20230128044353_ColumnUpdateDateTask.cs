using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoEfNet7.Migrations
{
    /// <inheritdoc />
    public partial class ColumnUpdateDateTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Task",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Task");
        }
    }
}
