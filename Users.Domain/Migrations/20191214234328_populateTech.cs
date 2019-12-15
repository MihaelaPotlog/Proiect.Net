using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Users.Domain.Migrations
{
    public partial class populateTech : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("37855913-4c6b-439a-8c07-89cc8308a8b7"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9a756242-25f0-4d41-b6fd-ef1de1219c47"));

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("215afa03-b189-4495-a7be-a88b7e5eb8c5"), "Java" },
                    { new Guid("e99327fd-0911-48dc-b668-ec6edb966431"), "JavaScript" },
                    { new Guid("39c92b76-86d0-462e-9d72-83a72aff92e5"), ".Net" },
                    { new Guid("a384ce15-423c-4c79-ae02-9e98e144148f"), "C#" },
                    { new Guid("1407a7e3-dbaa-4543-a2c5-5f0d4872aef4"), "Unity" },
                    { new Guid("c29ed288-a07e-4f08-9d64-fc7523104c25"), "Node.js" },
                    { new Guid("1493ac2e-f113-4b55-aa23-84224da81bec"), "Angular" },
                    { new Guid("4c42b797-c133-4951-be60-e36a87d09654"), "React" },
                    { new Guid("686b6807-e575-4046-9137-7968156781a8"), "Vue" },
                    { new Guid("7deff3f1-9c61-4ed4-9662-17ddb8389551"), "Express" },
                    { new Guid("e673bd68-55c9-4db0-b4f7-f71d4648a9be"), "Swift" },
                    { new Guid("29a0bea2-67d4-4037-829e-32a5d6faccbf"), "MongoDb" },
                    { new Guid("275152a0-0dbe-418d-aa1c-c69b5d72318e"), "C++" },
                    { new Guid("b19dd1a2-697b-4795-bb48-e9769a80f483"), "Python" },
                    { new Guid("6a9f552d-02dc-436b-9721-e03f8c8fd56c"), "C" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1407a7e3-dbaa-4543-a2c5-5f0d4872aef4"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1493ac2e-f113-4b55-aa23-84224da81bec"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("215afa03-b189-4495-a7be-a88b7e5eb8c5"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("275152a0-0dbe-418d-aa1c-c69b5d72318e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("29a0bea2-67d4-4037-829e-32a5d6faccbf"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("39c92b76-86d0-462e-9d72-83a72aff92e5"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4c42b797-c133-4951-be60-e36a87d09654"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("686b6807-e575-4046-9137-7968156781a8"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6a9f552d-02dc-436b-9721-e03f8c8fd56c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7deff3f1-9c61-4ed4-9662-17ddb8389551"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a384ce15-423c-4c79-ae02-9e98e144148f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b19dd1a2-697b-4795-bb48-e9769a80f483"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c29ed288-a07e-4f08-9d64-fc7523104c25"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e673bd68-55c9-4db0-b4f7-f71d4648a9be"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e99327fd-0911-48dc-b668-ec6edb966431"));

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("9a756242-25f0-4d41-b6fd-ef1de1219c47"), "Java" });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("37855913-4c6b-439a-8c07-89cc8308a8b7"), "JavaScript" });
        }
    }
}
