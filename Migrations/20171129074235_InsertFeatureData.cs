using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vega.Migrations
{
    public partial class InsertFeatureData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Features(Name) VALUES ('feature1') ");
            migrationBuilder.Sql("INSERT INTO Features(Name) VALUES ('feature2') ");
            migrationBuilder.Sql("INSERT INTO Features(Name) VALUES ('feature3') ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE TOP 3 FROM Features");
        }
    }
}
