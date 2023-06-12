using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscountManagment.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class FixColleagueDiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemved",
                table: "ColleagueDiscounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRemved",
                table: "ColleagueDiscounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
