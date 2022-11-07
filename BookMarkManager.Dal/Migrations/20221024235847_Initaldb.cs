using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BookMarkManager.Dal.Migrations
{
    public partial class Initaldb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookMarks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    URL = table.Column<string>(type: "text", nullable: true),
                    FolderId = table.Column<int>(type: "integer", nullable: true),
                    Createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookMarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookMarks_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookMarks",
                columns: new[] { "Id", "Createdat", "FolderId", "Name", "URL", "Updatedat" },
                values: new object[] { 4, new DateTime(2022, 10, 25, 2, 58, 47, 70, DateTimeKind.Local).AddTicks(3102), null, "Wolt", "https://wolt.com/", new DateTime(2022, 10, 25, 2, 58, 47, 70, DateTimeKind.Local).AddTicks(3115) });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Createdat", "Description", "Name", "Updatedat" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 25, 2, 58, 47, 61, DateTimeKind.Local).AddTicks(9603), "This folder Contains Online Shops", "OnlineShops", new DateTime(2022, 10, 25, 2, 58, 47, 67, DateTimeKind.Local).AddTicks(1840) },
                    { 2, new DateTime(2022, 10, 25, 2, 58, 47, 69, DateTimeKind.Local).AddTicks(5489), "This folder Contains News", "NEWS", new DateTime(2022, 10, 25, 2, 58, 47, 69, DateTimeKind.Local).AddTicks(5592) }
                });

            migrationBuilder.InsertData(
                table: "BookMarks",
                columns: new[] { "Id", "Createdat", "FolderId", "Name", "URL", "Updatedat" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 25, 2, 58, 47, 70, DateTimeKind.Local).AddTicks(1120), 1, "IKEA", "https://www.ikea.com/", new DateTime(2022, 10, 25, 2, 58, 47, 70, DateTimeKind.Local).AddTicks(1902) },
                    { 2, new DateTime(2022, 10, 25, 2, 58, 47, 70, DateTimeKind.Local).AddTicks(2957), 1, "Amazon", "https://www.amazon.de/", new DateTime(2022, 10, 25, 2, 58, 47, 70, DateTimeKind.Local).AddTicks(2990) },
                    { 3, new DateTime(2022, 10, 25, 2, 58, 47, 70, DateTimeKind.Local).AddTicks(3043), 2, "BBC", "https://www.bbc.co.uk/", new DateTime(2022, 10, 25, 2, 58, 47, 70, DateTimeKind.Local).AddTicks(3057) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookMarks_FolderId",
                table: "BookMarks",
                column: "FolderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookMarks");

            migrationBuilder.DropTable(
                name: "Folders");
        }
    }
}
