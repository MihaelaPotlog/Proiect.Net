using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projects.Domain.Migrations
{
    public partial class populateTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a739af89-b1f9-4c46-afe8-04ba3688812e"), "Java" },
                    { new Guid("5b3252a0-c632-453b-a53d-908a3aac8532"), "JavaScript" },
                    { new Guid("e6170ad3-d4e7-4fd9-877c-4dcac284b404"), ".Net" },
                    { new Guid("90ff5a6e-bb7b-4bee-9f87-0a419af29610"), "C#" },
                    { new Guid("815e3d5d-6f6a-4485-a90a-e7052ba94cc3"), "Unity" },
                    { new Guid("e40d49ce-3f7b-473e-9a70-7a05d3f028f9"), "Node.js" },
                    { new Guid("ceb93b62-a1c3-4f38-af79-61165d7adace"), "Angular" },
                    { new Guid("5918de07-e128-4d49-aa37-5d43d5b8a2e7"), "React" },
                    { new Guid("6de4d2a9-ef02-4f22-ba7f-33411f4df1a9"), "Vue" },
                    { new Guid("89cc84b3-bba8-43e9-b835-f7f442956713"), "Express" },
                    { new Guid("6bb360d1-3600-44aa-8cd5-803ebc9e9b25"), "Swift" },
                    { new Guid("c38cb208-dbee-490d-8f80-40325c988fb5"), "MongoDb" },
                    { new Guid("44ef72e6-c436-461e-bf13-3aba4d47a950"), "C++" },
                    { new Guid("c6b430ad-0f69-4a72-9580-42406e7b0149"), "Python" },
                    { new Guid("f83ebe3f-a926-4e62-81cf-4cf3da00e91c"), "C" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("44ef72e6-c436-461e-bf13-3aba4d47a950"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5918de07-e128-4d49-aa37-5d43d5b8a2e7"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5b3252a0-c632-453b-a53d-908a3aac8532"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6bb360d1-3600-44aa-8cd5-803ebc9e9b25"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6de4d2a9-ef02-4f22-ba7f-33411f4df1a9"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("815e3d5d-6f6a-4485-a90a-e7052ba94cc3"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("89cc84b3-bba8-43e9-b835-f7f442956713"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("90ff5a6e-bb7b-4bee-9f87-0a419af29610"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a739af89-b1f9-4c46-afe8-04ba3688812e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c38cb208-dbee-490d-8f80-40325c988fb5"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c6b430ad-0f69-4a72-9580-42406e7b0149"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ceb93b62-a1c3-4f38-af79-61165d7adace"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e40d49ce-3f7b-473e-9a70-7a05d3f028f9"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e6170ad3-d4e7-4fd9-877c-4dcac284b404"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f83ebe3f-a926-4e62-81cf-4cf3da00e91c"));
        }
    }
}
