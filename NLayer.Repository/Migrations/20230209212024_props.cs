using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    /// <inheritdoc />
    public partial class props : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Products",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Categories",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<string>(
                name: "Declaration",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Declaration", "Image", "IsDelete", "Name" },
                values: new object[] { new DateTime(2023, 2, 10, 0, 20, 24, 95, DateTimeKind.Local).AddTicks(9687), "Test acıklama", "1.jpg", false, "Red Dead 2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Declaration", "Image", "IsDelete", "Name" },
                values: new object[] { new DateTime(2023, 2, 10, 0, 20, 24, 95, DateTimeKind.Local).AddTicks(9698), "Test acıklama", "2.jpg", false, "God Of War" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Declaration", "Image", "IsDelete", "Name" },
                values: new object[] { new DateTime(2023, 2, 10, 0, 20, 24, 95, DateTimeKind.Local).AddTicks(9699), "Test acıklama", "3.jpg", false, "Last of part 1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Declaration", "Image", "IsDelete", "Name" },
                values: new object[] { new DateTime(2023, 2, 10, 0, 20, 24, 95, DateTimeKind.Local).AddTicks(9701), "Test acıklama", "4.jpg", false, "Last of part 2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Declaration",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Products",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Categories",
                newName: "CreateDate");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2023, 1, 31, 20, 40, 54, 372, DateTimeKind.Local).AddTicks(9151), "SMTkalem" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2023, 1, 31, 20, 40, 54, 372, DateTimeKind.Local).AddTicks(9161), "CodiKalem" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2023, 1, 31, 20, 40, 54, 372, DateTimeKind.Local).AddTicks(9162), "SMTKitap" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2023, 1, 31, 20, 40, 54, 372, DateTimeKind.Local).AddTicks(9163), "CodiDefter" });
        }
    }
}
