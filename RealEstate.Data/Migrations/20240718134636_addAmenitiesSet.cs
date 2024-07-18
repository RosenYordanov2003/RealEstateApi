using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class addAmenitiesSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenity_AmenityCategory_AmenityCategoryId",
                table: "Amenity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Amenity",
                table: "Amenity");

            migrationBuilder.RenameTable(
                name: "Amenity",
                newName: "Amenities");

            migrationBuilder.RenameIndex(
                name: "IX_Amenity_AmenityCategoryId",
                table: "Amenities",
                newName: "IX_Amenities_AmenityCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amenities",
                table: "Amenities",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff565ab9-ae3f-4f55-a2fd-9179b0d42a3d", "AQAAAAEAACcQAAAAEIhpt2fuujqqgqbaa9up8k3nbYEAzFlFrK3nUzMHhBCJhVQSyZEFwt+4Qvv5KQBhYw==", "2a7e616e-33f9-4852-ab83-db372ec58fa0" });

            migrationBuilder.AddForeignKey(
                name: "FK_Amenities_AmenityCategory_AmenityCategoryId",
                table: "Amenities",
                column: "AmenityCategoryId",
                principalTable: "AmenityCategory",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenities_AmenityCategory_AmenityCategoryId",
                table: "Amenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Amenities",
                table: "Amenities");

            migrationBuilder.RenameTable(
                name: "Amenities",
                newName: "Amenity");

            migrationBuilder.RenameIndex(
                name: "IX_Amenities_AmenityCategoryId",
                table: "Amenity",
                newName: "IX_Amenity_AmenityCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amenity",
                table: "Amenity",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c6dae3a-a1c8-48e7-b316-0c2e55999335", "AQAAAAEAACcQAAAAEODte9T/6XMG+pQTKc2s7Hpf2QFLV7vdyKs1FffmpXV2uox9CU4MZoX3kdridY3tpw==", "87c5ab72-439f-4603-a451-38c30abc2e76" });

            migrationBuilder.AddForeignKey(
                name: "FK_Amenity_AmenityCategory_AmenityCategoryId",
                table: "Amenity",
                column: "AmenityCategoryId",
                principalTable: "AmenityCategory",
                principalColumn: "Id");
        }
    }
}
