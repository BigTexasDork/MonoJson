using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace ConsoleApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<int>(isNullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BotanicalName = table.Column<string>(isNullable: true),
                    CompEase = table.Column<string>(isNullable: true),
                    CostDate = table.Column<DateTime>(isNullable: false),
                    Description = table.Column<string>(isNullable: true),
                    Division = table.Column<string>(isNullable: true),
                    ItemNumber = table.Column<string>(isNullable: true),
                    LaborHours = table.Column<double>(isNullable: false),
                    MaterialCost = table.Column<double>(isNullable: false),
                    Name = table.Column<string>(isNullable: true),
                    Price = table.Column<double>(isNullable: false),
                    RoundedPrice = table.Column<double>(isNullable: false),
                    Size = table.Column<string>(isNullable: true),
                    Taxable = table.Column<bool>(isNullable: false),
                    Warranty = table.Column<bool>(isNullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Item");
        }
    }
}
