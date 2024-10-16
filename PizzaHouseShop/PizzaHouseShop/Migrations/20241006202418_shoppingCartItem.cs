using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHouseShop.Migrations
{
    public partial class shoppingCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllergyInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPizzaOfTheWeek = table.Column<bool>(type: "bit", nullable: false),
                    InStock = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.PizzaId);
                    table.ForeignKey(
                        name: "FK_Pizza_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 1, "Vegan pizza", "Short description" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 2, "Ham pizza", "Short description" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 3, "Chesse pizza", "Short description" });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "PizzaId", "AllergyInformation", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "InStock", "IsPizzaOfTheWeek", "LongDescription", "Name", "Price", "ShortDescription" },
                values: new object[,]
                {
                    { 1, "No allergens", 1, "", "", true, false, "Regardess what else comes atop your pizza, a few fresh basil leaves will taste amazing with it. This simple sumertime pizza would make a delicious cookout appetizer or light dinner paired with a salad.", "Fresh Basil pizza", 15.95m, "Grilled Tomato-Peach Pizza" },
                    { 2, "Gluten", 3, "", "", true, true, "The Extra Cheese pizza is a deliciously rich option featuring a generous layer of melted mozzarella, creating a gooey, savory bite in every slice. Its cheesy goodness makes it a perfect comfort food for cheese lovers.", "Extra Cheese pizza", 16.95m, "Deep-Dish Skillet Pizza" },
                    { 3, "No allergens", 2, "", "", false, false, "The Ham pizza offers a savory combination of tender, smoky ham slices atop a crispy crust, layered with tangy tomato sauce and melted cheese. This classic pizza brings a satisfying balance of flavors.", "Ham pizza", 17.95m, "Fig, Ham, and Ricotta Pizza" },
                    { 4, "Gluten", 2, "", "", true, false, "The Sausage pizza features flavorful, seasoned sausage crumbles scattered over a bed of melted cheese and tangy tomato sauce. Its robust, savory taste makes it a hearty option.", "Sausage pizza", 14.95m, "Sausage and Kale Pesto Pizza" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_CategoryId",
                table: "Pizza",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_PizzaId",
                table: "ShoppingCartItem",
                column: "PizzaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItem");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
