using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinTrack_Pro.Migrations
{
    /// <inheritdoc />
    public partial class AccountTransactionRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.AddColumn<string>(
                name: "AccountHolder",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AccountHolder",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "Id");
        }
    }
}
