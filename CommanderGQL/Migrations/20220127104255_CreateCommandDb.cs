using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommanderGQL.Migrations
{
    public partial class CreateCommandDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "commands",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    how_to = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    command_line = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    platform_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_commands", x => x.id);
                    table.ForeignKey(
                        name: "fk_commands_platforms_platform_id",
                        column: x => x.platform_id,
                        principalTable: "platforms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_commands_platform_id",
                table: "commands",
                column: "platform_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "commands");
        }
    }
}
