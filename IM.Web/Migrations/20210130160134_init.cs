using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IM.Web.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCash = table.Column<bool>(type: "bit", nullable: false),
                    IsFixIncome = table.Column<bool>(type: "bit", nullable: false),
                    IsConvertible = table.Column<bool>(type: "bit", nullable: false),
                    IsSwap = table.Column<bool>(type: "bit", nullable: false),
                    IsFuture = table.Column<bool>(type: "bit", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");
        }
    }
}
