using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAdsAI.Infrastructure.Persistence.Migrations;

public partial class AddCampaignImageColumns : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "ImageFileName",
            table: "campaigns",
            type: "character varying(300)",
            maxLength: 300,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "ImageContentType",
            table: "campaigns",
            type: "character varying(120)",
            maxLength: 120,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "ImageBase64Data",
            table: "campaigns",
            type: "text",
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "ImageFileName",
            table: "campaigns");

        migrationBuilder.DropColumn(
            name: "ImageContentType",
            table: "campaigns");

        migrationBuilder.DropColumn(
            name: "ImageBase64Data",
            table: "campaigns");
    }
}
