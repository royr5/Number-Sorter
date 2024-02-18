using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Number_Sorter.Migrations
{
    /// <inheritdoc />
    public partial class initialsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NumberSort",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SortedNumbers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortedDirection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortTime = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberSort", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumberSort");
        }
    }
}
