using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class addSeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_SaleCategories_CategoryId",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Properties",
                newName: "SaleCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_CategoryId",
                table: "Properties",
                newName: "IX_Properties_SaleCategoryId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Properties",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FloorNumber",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"), 0, "b89abe86-2f2a-4180-a73c-a983d024d721", "bobi123@gmail.com", false, false, null, "BOBI123@GMAIL.COM", "BOBI", "AQAAAAEAACcQAAAAEBc4ADHvi5oq32WHKSWrBscWN5BtoruuxLOrjmehk7AN9KqoI3JvUrtmdupNwe5+Vw==", null, false, "58d8315c-733d-4b52-9f80-84c1d6367213", false, "Bobi" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sofia" },
                    { 2, "Plovdiv" },
                    { 3, "Varna" },
                    { 4, "Burgas" }
                });

            migrationBuilder.UpdateData(
                table: "PropertyCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Apartment");

            migrationBuilder.InsertData(
                table: "PropertyCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Studio" });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "BathRoomsCount", "BedRoomsCount", "CityId", "Description", "FloorNumber", "Latitude", "Longitude", "Name", "OwnerId", "Price", "PropertyCategoryId", "RenterId", "SaleCategoryId", "SquareMeters" },
                values: new object[] { new Guid("a3447384-56ea-485d-98d7-0020ad5dc217"), "квартал Витоша", 2, 3, 1, "Тристаен апартамент в новострояща се сграда разположен е на втори жилищен етаж. Състои се от: коридор, всекидневна с кухненски бокс и тераса,   две спални, едната с гардеробна и собствена баня с тоалетна,   баня с тоалетна и тераса. Жилището се издава  на шпакловка и замазка, с външни врати с многоточково заключване, ВиК до тапа, електрозахранване по проект. Сградата ще бъде присъединена към Газификационна мрежа.", 2, 42.64060043988789m, 23.32371168076406m, "Тристаен Апартамент", new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"), 900m, 2, null, 2, 104m });

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_SaleCategories_SaleCategoryId",
                table: "Properties",
                column: "SaleCategoryId",
                principalTable: "SaleCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_SaleCategories_SaleCategoryId",
                table: "Properties");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("a3447384-56ea-485d-98d7-0020ad5dc217"));

            migrationBuilder.DeleteData(
                table: "PropertyCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "FloorNumber",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "SaleCategoryId",
                table: "Properties",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_SaleCategoryId",
                table: "Properties",
                newName: "IX_Properties_CategoryId");

            migrationBuilder.UpdateData(
                table: "PropertyCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Apartments");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_SaleCategories_CategoryId",
                table: "Properties",
                column: "CategoryId",
                principalTable: "SaleCategories",
                principalColumn: "Id");
        }
    }
}
