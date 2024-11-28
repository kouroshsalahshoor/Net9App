using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Categories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "JobCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "JobCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "JobCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedOn",
                table: "JobCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedOn",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedOn",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Mejeri" },
                    { 2, null, null, null, null, "Pasta" },
                    { 3, null, null, null, null, "Spagetti" },
                    { 4, null, null, null, null, "Ris" },
                    { 5, null, null, null, null, "Matgryn" },
                    { 6, null, null, null, null, "Konserver" },
                    { 7, null, null, null, null, "Kryddor" },
                    { 8, null, null, null, null, "Oljor" },
                    { 9, null, null, null, null, "Såser" },
                    { 10, null, null, null, null, "Kaffe" },
                    { 11, null, null, null, null, "Te" },
                    { 12, null, null, null, null, "Flingor" },
                    { 13, null, null, null, null, "Gryn" },
                    { 14, null, null, null, null, "Musli" },
                    { 15, null, null, null, null, "Sylt" },
                    { 16, null, null, null, null, "Marmelad" },
                    { 17, null, null, null, null, "Mjöl" },
                    { 18, null, null, null, null, "Bakelser" },
                    { 19, null, null, null, null, "Dessert" },
                    { 20, null, null, null, null, "Övrig Skafferi" },
                    { 21, null, null, null, null, "Färdigmat" },
                    { 22, null, null, null, null, "Spannmål" },
                    { 23, null, null, null, null, "Honung & Söcker" },
                    { 24, null, null, null, null, "Bröd" },
                    { 25, null, null, null, null, "Bageri" },
                    { 26, null, null, null, null, "Glass" },
                    { 27, null, null, null, null, "Godis" },
                    { 28, null, null, null, null, "Chocklad" },
                    { 29, null, null, null, null, "Chips" },
                    { 30, null, null, null, null, "Nötter" },
                    { 31, null, null, null, null, "Torkade frukt" },
                    { 32, null, null, null, null, "Fröer" },
                    { 33, null, null, null, null, "Tuggummi" },
                    { 34, null, null, null, null, "Lakris" },
                    { 35, null, null, null, null, "övrig Godis & snack" },
                    { 36, null, null, null, null, "Rotfrukter" },
                    { 37, null, null, null, null, "Grönsaker" },
                    { 38, null, null, null, null, "Frukt & bär" },
                    { 39, null, null, null, null, "Nöt Kött" },
                    { 40, null, null, null, null, "Gris Kött" },
                    { 41, null, null, null, null, "Fågel" },
                    { 42, null, null, null, null, "Fisk & skaldjur" },
                    { 43, null, null, null, null, "Läsk" },
                    { 44, null, null, null, null, "Vatten" },
                    { 45, null, null, null, null, "Juice" },
                    { 46, null, null, null, null, "Smoothie" },
                    { 47, null, null, null, null, "Saft" },
                    { 48, null, null, null, null, "Energ & Sport Dryck" },
                    { 49, null, null, null, null, "Växtbaserade Dryck" },
                    { 50, null, null, null, null, "Övrig Dryck" },
                    { 51, null, null, null, null, "Hem & Hushåll" },
                    { 52, null, null, null, null, "Hund & katt" },
                    { 53, null, null, null, null, "Blommor & växter" }
                });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn" },
                values: new object[] { null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "JobCategories");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "JobCategories");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "JobCategories");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "JobCategories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "Countries");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
