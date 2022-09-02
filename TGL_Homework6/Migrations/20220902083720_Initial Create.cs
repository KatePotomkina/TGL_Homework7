using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGL_Homework6.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breed",
                columns: table => new
                {
                    Breed_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breed", x => x.Breed_Id);
                });

            migrationBuilder.CreateTable(
                name: "Puppies",
                columns: table => new
                {
                    Puppy_Id = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    Name = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    Breed_Id = table.Column<int>(type: "int", nullable: false),
                    Owner = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puppies", x => x.Puppy_Id);
                    table.ForeignKey(
                        name: "Breed_Id",
                        column: x => x.Breed_Id,
                        principalTable: "Breed",
                        principalColumn: "Breed_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Puppies_Breed_Id",
                table: "Puppies",
                column: "Breed_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Puppies");

            migrationBuilder.DropTable(
                name: "Breed");
        }
    }
}
