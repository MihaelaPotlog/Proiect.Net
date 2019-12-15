using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projects.Domain.Migrations
{
    public partial class populateTech : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTechnologies",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(nullable: false),
                    TechnologieId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTechnologies", x => new { x.ProjectId, x.TechnologieId });
                    table.ForeignKey(
                        name: "FK_ProjectTechnologies_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTechnologies_Technologies_TechnologieId",
                        column: x => x.TechnologieId,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUsers",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUsers", x => new { x.ProjectId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ProjectUsers_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUsers_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("30ad2e71-56d9-44a0-864d-d2b53a097f40"), "Java" },
                    { new Guid("a5e32fcb-2576-48d6-aa60-dd464c91179e"), "JavaScript" },
                    { new Guid("d8e57ab4-de9a-4cd2-a814-9626b1287921"), ".Net" },
                    { new Guid("1c83f71f-18f3-4fe7-9010-6964e9907caf"), "C#" },
                    { new Guid("8d5cee13-eef5-439f-8b0c-08163464346b"), "Unity" },
                    { new Guid("618767ab-cd25-4b58-8f6a-1cb7c9592d60"), "Node.js" },
                    { new Guid("f862b3ce-8216-4496-953a-c7038739894a"), "Angular" },
                    { new Guid("bec40c4d-b1f2-4d29-b744-138a1536cc87"), "React" },
                    { new Guid("da7e8d5c-8d3a-4ae9-9ec9-a0661bed95ef"), "Vue" },
                    { new Guid("7033fd1e-fb60-4db6-b74a-0d7e2e781758"), "Express" },
                    { new Guid("fa72d3ec-ceb9-4c9f-9a4a-cf75db9abfdc"), "Swift" },
                    { new Guid("ab5c84ab-a47e-476d-a7d7-224b2c0956b6"), "MongoDb" },
                    { new Guid("ff2dcc27-f64a-4202-b430-9b3a27cc2bda"), "C++" },
                    { new Guid("1cac5531-dd49-4caf-b5cf-86754a6dd7b1"), "Python" },
                    { new Guid("86450be6-2cfd-4a7d-aba9-adf035963f4e"), "C" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTechnologies_TechnologieId",
                table: "ProjectTechnologies",
                column: "TechnologieId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_UserId",
                table: "ProjectUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTechnologies");

            migrationBuilder.DropTable(
                name: "ProjectUsers");

            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
