using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerMonitoringSystem.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeatureValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureValues_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NormalFeatureValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormalFeatureValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NormalFeatureValues_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssueFeatureValues",
                columns: table => new
                {
                    IssueId = table.Column<int>(nullable: false),
                    FeatureValueId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueFeatureValues", x => new { x.IssueId, x.FeatureValueId });
                    table.ForeignKey(
                        name: "FK_IssueFeatureValues_FeatureValues_FeatureValueId",
                        column: x => x.FeatureValueId,
                        principalTable: "FeatureValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueFeatureValues_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "TotalPcUsage" },
                    { 24, "PsWattLessStated" },
                    { 23, "PsOverheating" },
                    { 22, "UsbPortsMalfuncion" },
                    { 21, "CoolingVentSpeedLowerStated" },
                    { 20, "RamFreqLowerStated" },
                    { 19, "RamDetection" },
                    { 18, "HddBeatSectors" },
                    { 16, "HddReadWriteSpeed" },
                    { 15, "MbElecConsume" },
                    { 14, "MbVoltageLevel" },
                    { 13, "GpuArtifactsWhileWorking" },
                    { 17, "SsdReadWriteSpeed" },
                    { 11, "GpuVoltageLevel" },
                    { 2, "TotalTermUsage" },
                    { 12, "GpuElecConsume" },
                    { 4, "NoiseWhileWorking" },
                    { 5, "UnnormalSoundsWhileWorking" },
                    { 6, "CpuOverheating" },
                    { 3, "TotalTimeFromLastClean" },
                    { 8, "CpuElecConsume" },
                    { 9, "CpuFreqLowerStated" },
                    { 10, "GpuOverheating" },
                    { 7, "CpuVoltageLevel" }
                });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 8, "Old PC / Long used term / Cleaned long ago", "Common issue" },
                    { 1, "Issue of the central processor. ", "CPU issue" },
                    { 2, "Issue of the grapichs processor. ", "GPU issue" },
                    { 3, "Issue of the motherboard. ", "MB issue" },
                    { 4, "Issue of the solid state drive. ", "SSD issue" },
                    { 5, "Issue of the hard disk drive. ", "HDD issue" },
                    { 6, "Issue of the cooling system. ", "Cooler issue" },
                    { 7, "Issue of the power supply. ", "PS issue" },
                    { 9, "Issue of the RA memory", "RAM issue" }
                });

            migrationBuilder.InsertData(
                table: "FeatureValues",
                columns: new[] { "Id", "FeatureId", "Value" },
                values: new object[,]
                {
                    { 1, 1, "[0, 5" },
                    { 43, 16, "Fluctuation" },
                    { 42, 16, "Lower than stated" },
                    { 41, 15, "Higher than stated" },
                    { 40, 15, "Normal" },
                    { 39, 15, "Low" },
                    { 38, 14, "Normal" },
                    { 44, 16, "Normal" },
                    { 37, 14, "Fluctuation" },
                    { 35, 13, "No" },
                    { 34, 13, "Yes" },
                    { 63, 24, "No" },
                    { 32, 12, "Normal" },
                    { 31, 12, "Low" },
                    { 30, 11, "Normal" },
                    { 36, 14, "Low" },
                    { 45, 17, "Lower than stated" },
                    { 46, 17, "Fluctuation" },
                    { 47, 17, "Normal" },
                    { 62, 24, "Yes" },
                    { 61, 23, "No" },
                    { 60, 23, "Yes" },
                    { 59, 22, "No malfunction" },
                    { 58, 22, "Front panel" },
                    { 57, 22, "Back panel" },
                    { 56, 21, "No" },
                    { 55, 21, "Yes" },
                    { 54, 20, "No" },
                    { 53, 20, "Yes" },
                    { 52, 19, "System doesn't decect any connected RAM" },
                    { 51, 19, "System detects not all connected RAM" },
                    { 50, 19, "System detects all connected RAM" },
                    { 49, 18, "No" },
                    { 48, 18, "Yes" },
                    { 29, 11, "Fluctuation" },
                    { 28, 11, "Low" },
                    { 33, 12, "Higher than stated" },
                    { 27, 10, "No" },
                    { 2, 1, "[6, 12" },
                    { 3, 2, "[0, 5]" },
                    { 4, 2, "[6, 12]" },
                    { 5, 3, "[0, 150]" },
                    { 6, 3, "[151, 240]" },
                    { 7, 4, "Quite" },
                    { 8, 4, "Normal" },
                    { 9, 4, "Loud" },
                    { 10, 5, "No" },
                    { 11, 5, "Motherboard signals" },
                    { 12, 5, "Loud cooler spin" },
                    { 13, 5, "Loud power supply cooler spin" },
                    { 15, 5, "Loud HDD cooler spin" },
                    { 16, 6, "Yes" },
                    { 17, 6, "No" },
                    { 14, 5, "Loud PC case cooler spin" },
                    { 26, 10, "Yes" },
                    { 19, 7, "Fluctuation" },
                    { 18, 7, "Low" },
                    { 23, 8, "Higher than stated" },
                    { 24, 9, "Yes" },
                    { 20, 7, "Normal" },
                    { 22, 8, "Normal" },
                    { 25, 9, "No" },
                    { 21, 8, "Low" }
                });

            migrationBuilder.InsertData(
                table: "NormalFeatureValues",
                columns: new[] { "Id", "FeatureId", "Value" },
                values: new object[,]
                {
                    { 6, 6, "No" },
                    { 21, 21, "No" },
                    { 2, 2, "[0, 5]" },
                    { 11, 11, "Normal" },
                    { 22, 22, "No malfunction" },
                    { 9, 9, "No" },
                    { 1, 1, "[0, 5" },
                    { 23, 23, "No" },
                    { 3, 3, "[0, 150]" },
                    { 20, 20, "No" },
                    { 19, 19, "System detects all connected RAM" },
                    { 12, 12, "Normal" },
                    { 4, 4, "Normal" },
                    { 18, 18, "No" },
                    { 13, 13, "No" },
                    { 17, 17, "Normal" },
                    { 7, 7, "Normal" },
                    { 10, 10, "No" },
                    { 16, 16, "Normal" },
                    { 5, 5, "None" },
                    { 14, 14, "Normal" },
                    { 15, 15, "Normal" },
                    { 8, 8, "Normal" },
                    { 24, 24, "No" }
                });

            migrationBuilder.InsertData(
                table: "IssueFeatureValues",
                columns: new[] { "IssueId", "FeatureValueId", "Id" },
                values: new object[,]
                {
                    { 8, 2, 1 },
                    { 2, 34, 22 },
                    { 3, 36, 23 },
                    { 3, 37, 24 },
                    { 3, 39, 25 },
                    { 3, 41, 26 },
                    { 5, 42, 27 },
                    { 5, 43, 28 },
                    { 2, 33, 21 },
                    { 4, 45, 29 },
                    { 5, 48, 31 },
                    { 9, 51, 32 },
                    { 9, 52, 33 },
                    { 9, 53, 34 },
                    { 6, 55, 35 },
                    { 3, 57, 36 },
                    { 3, 58, 37 },
                    { 4, 46, 30 },
                    { 7, 60, 38 },
                    { 2, 31, 20 },
                    { 2, 28, 18 },
                    { 8, 4, 2 },
                    { 8, 6, 3 },
                    { 8, 7, 4 },
                    { 8, 9, 5 },
                    { 3, 11, 6 },
                    { 6, 12, 7 },
                    { 7, 13, 8 },
                    { 2, 29, 19 },
                    { 6, 14, 9 },
                    { 1, 16, 11 },
                    { 1, 18, 12 },
                    { 1, 19, 13 },
                    { 1, 21, 14 },
                    { 1, 23, 15 },
                    { 1, 24, 16 },
                    { 2, 26, 17 },
                    { 5, 15, 10 },
                    { 7, 62, 39 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeatureValues_FeatureId",
                table: "FeatureValues",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueFeatureValues_FeatureValueId",
                table: "IssueFeatureValues",
                column: "FeatureValueId");

            migrationBuilder.CreateIndex(
                name: "IX_NormalFeatureValues_FeatureId",
                table: "NormalFeatureValues",
                column: "FeatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueFeatureValues");

            migrationBuilder.DropTable(
                name: "NormalFeatureValues");

            migrationBuilder.DropTable(
                name: "FeatureValues");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Features");
        }
    }
}
