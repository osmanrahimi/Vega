using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vega.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                    migrationBuilder.Sql("INSERT INTO MAKES (NAME) VALUES('MAKE1');");
                    migrationBuilder.Sql("INSERT INTO MAKES (NAME) VALUES('MAKE2');");
                    migrationBuilder.Sql("INSERT INTO MAKES (NAME) VALUES('MAKE3');");

                    migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES('MAKE1-MODEL1',(select Id from makes where name='MAKE1'))");
                    migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES('MAKE1-MODEL2',(select Id from makes where name='MAKE1'))");
                    migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES('MAKE1-MODEL3',(select Id from makes where name='MAKE1'))");


                    migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES('MAKE2-MODEL1',(select Id from makes where name='MAKE2'))");
                    migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES('MAKE2-MODEL2',(select Id from makes where name='MAKE2'))");
                    migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES('MAKE2-MODEL3',(select Id from makes where name='MAKE2'))");

                    migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES('MAKE3-MODEL1',(select Id from makes where name='MAKE3'))");
                    migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES('MAKE3-MODEL2',(select Id from makes where name='MAKE3'))");
                    migrationBuilder.Sql("INSERT INTO MODELS (NAME,MAKEID) VALUES('MAKE3-MODEL3',(select Id from makes where name='MAKE3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM MAKES");
        }
    }
}
