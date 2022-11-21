using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPZLab04.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    tID = table.Column<int>(name: "t_ID", type: "int", nullable: false),
                    name = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    surname = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.tID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Surname = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    AverageMath = table.Column<double>(type: "float", nullable: true),
                    AverageEnglish = table.Column<double>(type: "float", nullable: true),
                    AveragePhilosophy = table.Column<double>(type: "float", nullable: true),
                    tID = table.Column<int>(name: "t_ID", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_1", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Student_Teacher",
                        column: x => x.tID,
                        principalTable: "Teacher",
                        principalColumn: "t_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_t_ID",
                table: "Student",
                column: "t_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
