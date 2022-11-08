using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banner.EntityFramework.Migrations
{
    public partial class initial : Migration
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

            migrationBuilder.Sql(@"Create Procedure GetBannerStats @date datetimeoffset
                                AS
                                BEGIN
                                  declare @searchStartDate datetime, @searchEndDate datetime;

                                  set @searchStartDate = DATEADD(dd, DATEDIFF(dd, 0, @date), 0);
                                  set @searchEndDate = DATEADD(dd, 1, @searchStartDate);

		                                with BannerPivot as (
		                                SELECT  Id,Title,Date,EventName, [1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14],[15],
		                                [16],[17],[18],[19],[20],[21],[22],[23],[24]
		                                FROM   (
		                                select B.Id, B.Title,BA.Event EventName,BA.Event, DatePart(hh, BA.CreatedOn) Hour,DATEADD(dd, DATEDIFF(dd, 0,BA.CreatedOn), 0) Date
		                                from Banners B left join BannerActivities BA
		                                on B.Id = BA.BannerId
		                                where BA.CreatedOn >= @searchStartDate and BA.CreatedOn <  @searchEndDate		
		                                Group by B.Id,B.Title, BA.Event,BA.CreatedOn ) p
		                                PIVOT  
		                                (  
		                                COUNT (Event)  
		                                FOR Hour IN  
		                                ( [1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14],[15],
		                                [16],[17],[18],[19],[20],[21],[22],[23],[24])  
		                                ) AS pvt  ),

		                                BannerUnPivot as (
		                                SELECT Id,Title, Date,EventName ,Hour,Number
		                                FROM   
		                                   (SELECT Id,Title,Date,EventName, [1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14],[15],
		                                [16],[17],[18],[19],[20],[21],[22],[23],[24]
		                                   FROM BannerPivot) p  
		                                UNPIVOT  
		                                   (Number FOR Hour IN   
			                                  ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14],[15],
		                                [16],[17],[18],[19],[20],[21],[22],[23],[24])  
		                                )AS unpvt )

		                                select Id BannerId,Title,Date,cast(Hour as int) Hour,(select sum(Number) from BannerUnPivot subTable where subTable.id = BannerUnPivot.Id 
		                                and subTable.Hour = BannerUnPivot.Hour and subTable.EventName = 0 ) Impressions,
		                                (select sum(Number) from BannerUnPivot subTable where subTable.id = BannerUnPivot.Id 
		                                and subTable.Hour = BannerUnPivot.Hour and subTable.EventName = 1 ) Clicks from BannerUnPivot
		                                group by Id, Title,Date,Hour
		                                order by Hour asc, Title

                                End");
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
