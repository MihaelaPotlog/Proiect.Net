using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projects.Domain.Migrations
{
    public partial class Modificari4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Invitations",
                table: "Invitations");

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0e00c228-7d39-4109-87b8-b6d11a89f003"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("1e4c2e44-e366-4ad8-8aab-55341fc7311a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("3293e537-c40c-4421-8aa3-2d6c1297cc48"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("43da652d-f503-45e5-bf47-46ddeaaccad6"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4c8afae6-56bc-4403-828a-b843414f0bd6"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6ea2d65f-14d0-4dd6-bd63-199f376cb978"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7b54fda9-e0de-49f4-b923-202ed1e0eba2"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("87f5df8d-677a-4d4c-8baf-54e4278fb23e"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("89e87ea5-066a-4b30-a1c7-328737fe9d63"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("96f11b84-7fb0-4e36-92f2-83754e60e638"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b1173779-d557-430c-ac11-eb9518e0b621"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c0c4b011-85f0-45f1-b794-92d9100a0264"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c7b796f8-e9d5-49b9-9952-ea6e2decea7a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e4e9b4df-f1da-48fc-88e5-861f06f5ce7d"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("ec986892-c991-48bf-b02a-317820524569"));

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Invitations");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Invitations");

            migrationBuilder.AddColumn<Guid>(
                name: "CollaboratorId",
                table: "Invitations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Invitations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "InvitationType",
                table: "Invitations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invitations",
                table: "Invitations",
                columns: new[] { "ProjectId", "CollaboratorId", "OwnerId" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Invitations",
                table: "Invitations");

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

            migrationBuilder.DropColumn(
                name: "CollaboratorId",
                table: "Invitations");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Invitations");

            migrationBuilder.DropColumn(
                name: "InvitationType",
                table: "Invitations");

            migrationBuilder.AddColumn<Guid>(
                name: "SenderId",
                table: "Invitations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReceiverId",
                table: "Invitations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invitations",
                table: "Invitations",
                columns: new[] { "ProjectId", "SenderId", "ReceiverId" });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("43da652d-f503-45e5-bf47-46ddeaaccad6"), "Java" },
                    { new Guid("1e4c2e44-e366-4ad8-8aab-55341fc7311a"), "JavaScript" },
                    { new Guid("89e87ea5-066a-4b30-a1c7-328737fe9d63"), ".Net" },
                    { new Guid("e4e9b4df-f1da-48fc-88e5-861f06f5ce7d"), "C#" },
                    { new Guid("c0c4b011-85f0-45f1-b794-92d9100a0264"), "Unity" },
                    { new Guid("7b54fda9-e0de-49f4-b923-202ed1e0eba2"), "Node.js" },
                    { new Guid("96f11b84-7fb0-4e36-92f2-83754e60e638"), "Angular" },
                    { new Guid("87f5df8d-677a-4d4c-8baf-54e4278fb23e"), "React" },
                    { new Guid("4c8afae6-56bc-4403-828a-b843414f0bd6"), "Vue" },
                    { new Guid("3293e537-c40c-4421-8aa3-2d6c1297cc48"), "Express" },
                    { new Guid("0e00c228-7d39-4109-87b8-b6d11a89f003"), "Swift" },
                    { new Guid("c7b796f8-e9d5-49b9-9952-ea6e2decea7a"), "MongoDb" },
                    { new Guid("6ea2d65f-14d0-4dd6-bd63-199f376cb978"), "C++" },
                    { new Guid("ec986892-c991-48bf-b02a-317820524569"), "Python" },
                    { new Guid("b1173779-d557-430c-ac11-eb9518e0b621"), "C" }
                });
        }
    }
}
