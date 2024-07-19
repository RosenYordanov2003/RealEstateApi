using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Data.Migrations
{
    public partial class addRelationBetweenUserAndSubscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b27008d-350b-4843-af07-be921ec32578", "AQAAAAEAACcQAAAAELbZLCL+0zF/OD+es4ybGLWUWukNYRP/zRKmAYD1UG5kaJJZr70YSCqISjn+DNKUyQ==", "f7b25ed5-7548-4f2d-a143-f0bf095c9bc0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7d6ee68-2a6d-4a1a-b640-b26fceb74254"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74b34122-4c01-4cc4-8c5a-ded91c63ab15", "AQAAAAEAACcQAAAAEGvtkmel1UfJQu0pDK4HkEc+oegopLiN4tYXnA2TkEOFJkOrgS1xOapZ3DMW+XEXoA==", "2031f90f-299c-4614-9924-39e2018513d3" });
        }
    }
}
