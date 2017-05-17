using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EtsyClone.Migrations
{
    public partial class ChangeUserProfileIdFromStringToIntInAddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_UserProfiles_UserProfileId1",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_UserProfileId1",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UserProfileId1",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileId",
                table: "Addresses",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserProfileId",
                table: "Addresses",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_UserProfiles_UserProfileId",
                table: "Addresses",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_UserProfiles_UserProfileId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_UserProfileId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId1",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserProfileId",
                table: "Addresses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserProfileId1",
                table: "Addresses",
                column: "UserProfileId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_UserProfiles_UserProfileId1",
                table: "Addresses",
                column: "UserProfileId1",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
