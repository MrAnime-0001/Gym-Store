using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gym_Store.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImageUrl", "Name", "Price", "Quantity", "Type" },
                values: new object[,]
                {
                    { 1, "/Gym_Store/Images/Optimum Nutrition Gold Standard 100% Whey.jpg", "Optimum Nutrition Gold Standard 100% Whey French Vanilla", 98.95m, "2.27 kg", "Protein Powder" },
                    { 2, "/Gym_Store/Images/Myprotein Impact Whey Isolate.jpg", "Myprotein Impact Whey Isolate", 70.50m, "1 kg", "Protein Powder" },
                    { 3, "/Gym_Store/Images/INC Creatine Monohydrate.jpg", "INC Creatine Monohydrate", 39.95m, "500 g", "Creatine Supplement" },
                    { 4, "/Gym_Store/Images/EHP Labs Pride Pre-Workout Blue Slushie.jpg", "EHP Labs Pride Pre-Workout Blue Slushie", 79.95m, "40 Serves", "Pre-Workout" },
                    { 5, "/Gym_Store/Images/EHP Labs Pride Pre-Workout Raspberry Twizzle.jpg", "EHP Labs Pride Pre-Workout Raspberry Twizzle", 79.95m, "40 Serves", "Pre-Workout" },
                    { 6, "/Gym_Store/Images/Optimum Nutrition Gold Standard Pre-Workout Green Apple.jpg", "Optimum Nutrition Gold Standard Pre-Workout Green Apple", 39.90m, "30 Serves", "Pre-Workout" },
                    { 7, "/Gym_Store/Images/Optimum Nutrition Gold Standard Pre-Workout Blueberry Lemonade.jpg", "Optimum Nutrition Gold Standard Pre-Workout Blueberry Lemonade", 39.90m, "30 Serves", "Pre-Workout" },
                    { 8, "/Gym_Store/Images/Musashi Pre-Workout Purple Grape.jpg", "Musashi Pre-Workout Purple Grape", 29.99m, "225 g", "Pre-Workout" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
