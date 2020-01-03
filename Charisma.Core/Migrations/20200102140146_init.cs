using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Charisma.Core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Menu");

            migrationBuilder.CreateTable(
                name: "MenuItemTypes",
                schema: "Menu",
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
                name: "Recipes",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemSubTypes",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    OwnerId = table.Column<int>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemSubTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItemSubTypes_MenuItemTypes_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "Menu",
                        principalTable: "MenuItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    RecipeId = table.Column<int>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "Menu",
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Fee = table.Column<double>(nullable: false),
                    WaitingTime = table.Column<TimeSpan>(nullable: false, defaultValue: new TimeSpan(0, 0, 0, 0, 0)),
                    IsAvailable = table.Column<bool>(nullable: false, defaultValue: true),
                    RecipeId = table.Column<int>(nullable: true),
                    SubTypeId = table.Column<int>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "Menu",
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menu_MenuItemSubTypes_SubTypeId",
                        column: x => x.SubTypeId,
                        principalSchema: "Menu",
                        principalTable: "MenuItemSubTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                schema: "Menu",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_RecipeId",
                schema: "Menu",
                table: "Menu",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_SubTypeId",
                schema: "Menu",
                table: "Menu",
                column: "SubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemSubTypes_OwnerId",
                schema: "Menu",
                table: "MenuItemSubTypes",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "Menu",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "Recipes",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "MenuItemSubTypes",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "MenuItemTypes",
                schema: "Menu");
        }
    }
}
