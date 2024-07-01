using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class addQueryFilterInPropertyEntityConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7847dd2-336e-4bcf-a783-3f90dbbbeb9a", "AQAAAAEAACcQAAAAEBbdC5TguADqMBaJ3VWPFdI2ny2bkJN30vvaKalZ47U465J4Bfr2qTjSz9KsN058/A==", "4d6c0ab8-688b-437a-9cb3-b78bf28521be" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfb534ff-617d-4806-a644-bc8f85778515", "AQAAAAEAACcQAAAAEF/jTyMEPp9/gkSy4oZU3d+Zi71a/YNowmtL71iBOJSv68tSTo4wmMdymMKvjiRzHg==", "50455ebd-2f22-465f-9453-4c144c4539a7" });
        }
    }
}
