using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CARDs",
                columns: table => new
                {
                    CardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Card_Exp_Date = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Card_Name = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Card_Cvc = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARDs", x => x.CardID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERs",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card_No = table.Column<int>(type: "int", nullable: false),
                    CardID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERs", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_CUSTOMERs_CARDs_CardID",
                        column: x => x.CardID,
                        principalTable: "CARDs",
                        principalColumn: "CardID");
                });

            migrationBuilder.CreateTable(
                name: "BOOKs",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Book_Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Book_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOKs", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_BOOKs_CUSTOMERs_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CUSTOMERs",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "ORDERs",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Quantity = table.Column<int>(type: "int", nullable: true),
                    Order_Payment_Method = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Order_Total_Price = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Card_No = table.Column<int>(type: "int", nullable: false),
                    CardID = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERs", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_ORDERs_CARDs_CardID",
                        column: x => x.CardID,
                        principalTable: "CARDs",
                        principalColumn: "CardID");
                    table.ForeignKey(
                        name: "FK_ORDERs_CUSTOMERs_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CUSTOMERs",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOOKs_CustomerId",
                table: "BOOKs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERs_CardID",
                table: "CUSTOMERs",
                column: "CardID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERs_CardID",
                table: "ORDERs",
                column: "CardID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERs_CustomerId",
                table: "ORDERs",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BOOKs");

            migrationBuilder.DropTable(
                name: "ORDERs");

            migrationBuilder.DropTable(
                name: "CUSTOMERs");

            migrationBuilder.DropTable(
                name: "CARDs");
        }
    }
}
