using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class changeColumnsInPropertiesRents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_AspNetUsers_RenterId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesRents_Properties_PropertyId",
                table: "PropertiesRents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertiesRents",
                table: "PropertiesRents");

            migrationBuilder.DropIndex(
                name: "IX_Properties_RenterId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PropertiesRents");

            migrationBuilder.DropColumn(
                name: "RenterId",
                table: "Properties");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "PropertiesRents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertiesRents",
                table: "PropertiesRents",
                columns: new[] { "UserId", "PropertyId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36259667-f68f-4475-a7ce-576de48ece18", "AQAAAAEAACcQAAAAEAVwie7hdQlOl3CHN9xivAXbFL5PyKkm92SW/kz0hrrAnhY0OEB82StPWeTnN0jMrw==", "1757346a-5f7b-4466-a319-6f32a119bf65" });

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesRents_AspNetUsers_UserId",
                table: "PropertiesRents",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesRents_Properties_PropertyId",
                table: "PropertiesRents",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesRents_AspNetUsers_UserId",
                table: "PropertiesRents");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesRents_Properties_PropertyId",
                table: "PropertiesRents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertiesRents",
                table: "PropertiesRents");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PropertiesRents");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PropertiesRents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "RenterId",
                table: "Properties",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertiesRents",
                table: "PropertiesRents",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b770543-0de3-4151-b92f-0436f600e388", "AQAAAAEAACcQAAAAEJqpbFlWiM+eWmQJWN37zLl605NqX89BBUrx5nybDK3QaHNv8vGNa08QmEeS3JJiRg==", "c9762122-0c2d-4072-a084-db37f5aa7659" });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_RenterId",
                table: "Properties",
                column: "RenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_AspNetUsers_RenterId",
                table: "Properties",
                column: "RenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesRents_Properties_PropertyId",
                table: "PropertiesRents",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
