using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class re : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_CreatedBy",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_UpdatedBy",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CreatedBy",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UpdatedBy",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Users",
                newName: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "FullName");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CreatedBy",
                table: "Tickets",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UpdatedBy",
                table: "Tickets",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_CreatedBy",
                table: "Tickets",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_UpdatedBy",
                table: "Tickets",
                column: "UpdatedBy",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
