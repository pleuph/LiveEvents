using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveEvents.Data.Migrations
{
    /// <inheritdoc />
    public partial class MinorAdjustments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SignupDate",
                table: "LiveEventParticipant");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "LiveEventParticipant",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "LiveEventParticipant",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "LiveEvent",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "LiveEvent",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "LiveEventParticipant");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "LiveEventParticipant");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "LiveEvent");

            migrationBuilder.AddColumn<DateTime>(
                name: "SignupDate",
                table: "LiveEventParticipant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "LiveEvent",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getutcdate()");
        }
    }
}
