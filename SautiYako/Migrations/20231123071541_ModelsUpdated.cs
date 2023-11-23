using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SautiYako.Migrations
{
    /// <inheritdoc />
    public partial class ModelsUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpeechToTexts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TranscribedText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeechToTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpeechToTexts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TextToSpeeches",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TextToRead = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VoiceSettings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextToSpeeches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextToSpeeches_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TextToSpeechLogs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TextToSpeechRequestId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudioFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TextToSpeechId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextToSpeechLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextToSpeechLogs_TextToSpeeches_TextToSpeechId",
                        column: x => x.TextToSpeechId,
                        principalTable: "TextToSpeeches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpeechToTexts_UserId",
                table: "SpeechToTexts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TextToSpeeches_UserId",
                table: "TextToSpeeches",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TextToSpeechLogs_TextToSpeechId",
                table: "TextToSpeechLogs",
                column: "TextToSpeechId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpeechToTexts");

            migrationBuilder.DropTable(
                name: "TextToSpeechLogs");

            migrationBuilder.DropTable(
                name: "TextToSpeeches");
        }
    }
}
