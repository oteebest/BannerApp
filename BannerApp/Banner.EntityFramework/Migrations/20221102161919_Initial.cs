using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banner.EntityFramework.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LinkUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Online = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BannerActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BannerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Event = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannerActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BannerActivities_Banners_BannerId",
                        column: x => x.BannerId,
                        principalTable: "Banners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BannerActivities_BannerId",
                table: "BannerActivities",
                column: "BannerId");

            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[GetSummary] @date datetimeoffset 
                                    AS
                                    BEGIN

                                    declare @searchDate datetime
                                    set @searchDate = DATEADD(dd, DATEDIFF(dd, 0, @date), 0)

                                    DECLARE @BannerStats table(  
                                        BannerId uniqueidentifier NOT NULL, 
                                        Title nvarchar(200),  
                                        ImageUrl nvarchar(200), 
	                                    Date date NOT NULL,
	                                    Hour int NOT NULL,
                                        Impressions int not null,
	                                    Clicks int not null
	                                    );

                                    Declare @hourCounter int = 1;

                                          declare @startDateTime datetime, @endDatetime datetime;

	                                      While @hourCounter <= 24
	                                      Begin
	     
		                                     set @startDateTime = DATEADD(hh, @hourCounter-1, @searchDate);
		                                     set @endDatetime = DATEADD(mi, 60, @startDateTime);

		                                     print(@startDateTime);
		                                     print(@endDatetime);

	                                         insert into @BannerStats(BannerId,Title,ImageUrl,Date,Hour,Impressions,Clicks)
		                                     select Id,Title, ImageUrl, @searchDate,@hourCounter,(select count(*) from BannerActivities BA where BA.BannerId =
		                                     Banners.Id and BA.Event = 0 and BA.CreatedOn >= @startDateTime and BA.CreatedOn < @endDatetime  ),(select count(*) from BannerActivities BA where BA.BannerId =
		                                     Banners.Id and BA.Event = 1 and BA.CreatedOn >= @startDateTime and BA.CreatedOn < @endDatetime )  from Banners 
		 
	                                         set @hourCounter = @hourCounter + 1;
	                                      end
	  
	                                    select * from @BannerStats

                                    END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BannerActivities");

            migrationBuilder.DropTable(
                name: "Banners");
        }
    }
}
