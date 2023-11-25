﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagement.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitSlidesT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    PictureALt = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Heading = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    BtnText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slides");
        }
    }
}
