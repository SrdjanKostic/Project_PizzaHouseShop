using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHouseShop.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "PizzaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3);
        }
    }
}
