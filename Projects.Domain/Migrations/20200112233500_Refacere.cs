using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projects.Domain.Migrations
{
    public partial class Refacere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0af66c94-733a-4040-8e2e-6fab9fe2e8d4"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0b9f08b4-7c81-4f66-b84b-11a3ade103d8"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("24d9dc8a-f1b6-4063-9b39-ff653c26eda4"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("3704c7b0-7951-48e3-a485-47c2a8fd6e48"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("47028ec5-3253-46fa-9b75-23371acbf615"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("52fe3080-847f-4f8e-bb0c-60564fdaac2d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6f69e9f9-5117-4552-8087-f3a1693d4029"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6f7c9d36-0b50-43b7-a03b-ccf643f7a484"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("855eb54e-3086-458a-a774-982d996b3cdb"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("87f9a6b1-9d9d-4e2f-b044-b57618d6abe6"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("97553466-5f5d-49dd-9f21-6441c1032c1f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a5f5da61-2241-4656-9007-3fbb401ad9a4"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("af89ceb0-8d02-40e8-983a-a5b225ed47a2"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c2464fc1-87b7-4b38-8b69-a6e69f1c758a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("dded65ad-5c19-4c24-b392-5a06e72b05e7"));

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("356a2151-d666-4be5-a0cc-d90336ab51c4"), "Java" },
                    { new Guid("a77e6e2b-8ebd-4c40-853f-a2d8a800f49c"), "JavaScript" },
                    { new Guid("c175769a-4cb4-4c03-974a-58e4fc8b12a5"), ".Net" },
                    { new Guid("4f6252fe-2e40-4c34-9da7-b186ed0d7958"), "C#" },
                    { new Guid("2f558a73-0007-4e1b-84e9-9b87ce544e2b"), "Unity" },
                    { new Guid("ee005f22-7313-4664-bd5b-cf1c1457e448"), "Node.js" },
                    { new Guid("b6347884-9580-45de-87bb-7f3181269d1c"), "Angular" },
                    { new Guid("f00907c8-d1be-49b6-b281-37cbfe63f262"), "React" },
                    { new Guid("d3460bbd-c2b1-4916-86b4-e723e77d8751"), "Vue" },
                    { new Guid("5c2fb546-c3c2-4780-b248-cd62a5f07eeb"), "Express" },
                    { new Guid("c7dc9263-979f-4911-a71d-6e2231939653"), "Swift" },
                    { new Guid("a66e368d-aeac-48f3-95b4-0c8f50f65b6c"), "MongoDb" },
                    { new Guid("41fce07d-721e-4f87-9879-31e428462702"), "C++" },
                    { new Guid("1654a6c0-6cef-4516-a3bf-321a2b98341f"), "Python" },
                    { new Guid("54a85e17-21a6-4d84-8ea6-32a64956776e"), "C" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1654a6c0-6cef-4516-a3bf-321a2b98341f"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("2f558a73-0007-4e1b-84e9-9b87ce544e2b"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("356a2151-d666-4be5-a0cc-d90336ab51c4"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("41fce07d-721e-4f87-9879-31e428462702"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4f6252fe-2e40-4c34-9da7-b186ed0d7958"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("54a85e17-21a6-4d84-8ea6-32a64956776e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5c2fb546-c3c2-4780-b248-cd62a5f07eeb"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a66e368d-aeac-48f3-95b4-0c8f50f65b6c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a77e6e2b-8ebd-4c40-853f-a2d8a800f49c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b6347884-9580-45de-87bb-7f3181269d1c"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c175769a-4cb4-4c03-974a-58e4fc8b12a5"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c7dc9263-979f-4911-a71d-6e2231939653"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("d3460bbd-c2b1-4916-86b4-e723e77d8751"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ee005f22-7313-4664-bd5b-cf1c1457e448"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f00907c8-d1be-49b6-b281-37cbfe63f262"));

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("af89ceb0-8d02-40e8-983a-a5b225ed47a2"), "Java" },
                    { new Guid("6f7c9d36-0b50-43b7-a03b-ccf643f7a484"), "JavaScript" },
                    { new Guid("6f69e9f9-5117-4552-8087-f3a1693d4029"), ".Net" },
                    { new Guid("52fe3080-847f-4f8e-bb0c-60564fdaac2d"), "C#" },
                    { new Guid("47028ec5-3253-46fa-9b75-23371acbf615"), "Unity" },
                    { new Guid("0af66c94-733a-4040-8e2e-6fab9fe2e8d4"), "Node.js" },
                    { new Guid("87f9a6b1-9d9d-4e2f-b044-b57618d6abe6"), "Angular" },
                    { new Guid("855eb54e-3086-458a-a774-982d996b3cdb"), "React" },
                    { new Guid("97553466-5f5d-49dd-9f21-6441c1032c1f"), "Vue" },
                    { new Guid("dded65ad-5c19-4c24-b392-5a06e72b05e7"), "Express" },
                    { new Guid("3704c7b0-7951-48e3-a485-47c2a8fd6e48"), "Swift" },
                    { new Guid("24d9dc8a-f1b6-4063-9b39-ff653c26eda4"), "MongoDb" },
                    { new Guid("0b9f08b4-7c81-4f66-b84b-11a3ade103d8"), "C++" },
                    { new Guid("c2464fc1-87b7-4b38-8b69-a6e69f1c758a"), "Python" },
                    { new Guid("a5f5da61-2241-4656-9007-3fbb401ad9a4"), "C" }
                });
        }
    }
}
