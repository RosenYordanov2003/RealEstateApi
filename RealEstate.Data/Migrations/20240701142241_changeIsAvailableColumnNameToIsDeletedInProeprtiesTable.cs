using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class changeIsAvailableColumnNameToIsDeletedInProeprtiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "Properties",
                newName: "IsDeleted");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a9a4094-aa73-4e22-a06a-350934f7abfb", "AQAAAAEAACcQAAAAEDyXXSVxlgZO3hhbgYPzZtw+zjNv/XG4NnbMYUxPOU+hgUbOZBugMqJv5JH9fFLkzg==", "065d1212-fc58-43ee-a2fa-5b8a39269a6b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Properties",
                newName: "IsAvailable");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7847dd2-336e-4bcf-a783-3f90dbbbeb9a", "AQAAAAEAACcQAAAAEBbdC5TguADqMBaJ3VWPFdI2ny2bkJN30vvaKalZ47U465J4Bfr2qTjSz9KsN058/A==", "4d6c0ab8-688b-437a-9cb3-b78bf28521be" });
        }
    }
}
