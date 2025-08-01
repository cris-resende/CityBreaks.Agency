﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityBreaks.Agency.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletedAtToPacoteTuristico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PacotesTuristicos",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PacotesTuristicos");
        }
    }
}
