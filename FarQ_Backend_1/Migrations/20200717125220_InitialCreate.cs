﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace FarQ_Backend_1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployerLink = table.Column<string>(nullable: true),
                    UserLink = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    HelpLink = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventID);
                });

            migrationBuilder.CreateTable(
                name: "EventOrganiser",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    EventID = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    EventIDs = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventOrganiser", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Interviewer",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    EventID = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviewer", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Pool",
                columns: table => new
                {
                    Booths = table.Column<string>(nullable: false),
                    QueueID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pool", x => x.Booths);
                });

            migrationBuilder.CreateTable(
                name: "Queue",
                columns: table => new
                {
                    QueueID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserIDs = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queue", x => x.QueueID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    EventID = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Booth",
                columns: table => new
                {
                    BoothID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Occupied = table.Column<bool>(nullable: false),
                    InterviewerName = table.Column<string>(nullable: true),
                    Payload = table.Column<string>(nullable: true),
                    CurrentUser = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    EventID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booth", x => x.BoothID);
                    table.ForeignKey(
                        name: "FK_Booth_Interviewer_InterviewerName",
                        column: x => x.InterviewerName,
                        principalTable: "Interviewer",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booth_InterviewerName",
                table: "Booth",
                column: "InterviewerName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booth");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "EventOrganiser");

            migrationBuilder.DropTable(
                name: "Pool");

            migrationBuilder.DropTable(
                name: "Queue");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Interviewer");
        }
    }
}
