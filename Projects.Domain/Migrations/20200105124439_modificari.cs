using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projects.Domain.Migrations
{
    public partial class modificari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUsers_User_UserId",
                table: "ProjectUsers");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_ProjectUsers_UserId",
                table: "ProjectUsers");

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

            migrationBuilder.CreateTable(
                name: "Invitations",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(nullable: false),
                    SenderId = table.Column<Guid>(nullable: false),
                    ReceiverId = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => new { x.ProjectId, x.SenderId, x.ReceiverId });
                    table.ForeignKey(
                        name: "FK_Invitations_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invitations");

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

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_UserId",
                table: "ProjectUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUsers_User_UserId",
                table: "ProjectUsers",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
