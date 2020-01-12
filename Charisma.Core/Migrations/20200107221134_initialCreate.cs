using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Charisma.Core.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CharismaMenu");

            migrationBuilder.CreateTable(
                name: "MenuItemTypes",
                schema: "CharismaMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemSubTypes",
                schema: "CharismaMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    OwnerId = table.Column<int>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemSubTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItemSubTypes_MenuItemTypes_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "CharismaMenu",
                        principalTable: "MenuItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                schema: "CharismaMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Fee = table.Column<double>(nullable: false),
                    WaitingTime = table.Column<TimeSpan>(nullable: false, defaultValue: new TimeSpan(0, 0, 0, 0, 0)),
                    IsAvailable = table.Column<bool>(nullable: false, defaultValue: true),
                    SubTypeId = table.Column<int>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_MenuItemSubTypes_SubTypeId",
                        column: x => x.SubTypeId,
                        principalSchema: "CharismaMenu",
                        principalTable: "MenuItemSubTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                schema: "CharismaMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    MenuItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Menu_MenuItemId",
                        column: x => x.MenuItemId,
                        principalSchema: "CharismaMenu",
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MenuItemId",
                schema: "CharismaMenu",
                table: "Ingredients",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_SubTypeId",
                schema: "CharismaMenu",
                table: "Menu",
                column: "SubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemSubTypes_OwnerId",
                schema: "CharismaMenu",
                table: "MenuItemSubTypes",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients",
                schema: "CharismaMenu");

            migrationBuilder.DropTable(
                name: "Menu",
                schema: "CharismaMenu");

            migrationBuilder.DropTable(
                name: "MenuItemSubTypes",
                schema: "CharismaMenu");

            migrationBuilder.DropTable(
                name: "MenuItemTypes",
                schema: "CharismaMenu");
        }
    }
}
