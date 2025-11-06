using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AssetManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Add_New_Entities_And_Relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "PurchasePrice",
                table: "Assets",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Assets",
                newName: "AssetType");

            migrationBuilder.AddColumn<int>(
                name: "LifecycleStage",
                table: "Assets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RiskRating",
                table: "Assets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InformationSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SystemName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationalObjectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationalObjectives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataAssets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataOwner = table.Column<string>(type: "text", nullable: false),
                    DataQuality = table.Column<string>(type: "text", nullable: false),
                    SystemName = table.Column<string>(type: "text", nullable: false),
                    LastReviewed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    InformationSystemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataAssets_InformationSystems_InformationSystemId",
                        column: x => x.InformationSystemId,
                        principalTable: "InformationSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetObjectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObjectiveText = table.Column<string>(type: "text", nullable: false),
                    TargetDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    OrganisationalObjectiveId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetObjectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetObjectives_OrganisationalObjectives_OrganisationalObje~",
                        column: x => x.OrganisationalObjectiveId,
                        principalTable: "OrganisationalObjectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    AssetId = table.Column<int>(type: "integer", nullable: false),
                    AssetObjectiveId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_AssetObjectives_AssetObjectiveId",
                        column: x => x.AssetObjectiveId,
                        principalTable: "AssetObjectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RiskItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RiskType = table.Column<string>(type: "text", nullable: false),
                    Likelihood = table.Column<double>(type: "double precision", nullable: false),
                    Impact = table.Column<double>(type: "double precision", nullable: false),
                    MitigationPlan = table.Column<string>(type: "text", nullable: false),
                    AssetId = table.Column<int>(type: "integer", nullable: true),
                    ActivityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskItems_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RiskItems_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuditFindings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClauseReference = table.Column<string>(type: "text", nullable: false),
                    Severity = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AssetId = table.Column<int>(type: "integer", nullable: true),
                    DecisionRecordId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditFindings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditFindings_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DecisionRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssetId = table.Column<int>(type: "integer", nullable: false),
                    DecisionText = table.Column<string>(type: "text", nullable: false),
                    DecisionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Outcome = table.Column<string>(type: "text", nullable: false),
                    AuditFindingId = table.Column<int>(type: "integer", nullable: true),
                    AuditFindingId1 = table.Column<int>(type: "integer", nullable: true),
                    ActivityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecisionRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DecisionRecords_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DecisionRecords_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DecisionRecords_AuditFindings_AuditFindingId1",
                        column: x => x.AuditFindingId1,
                        principalTable: "AuditFindings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PredictiveActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DecisionRecordId = table.Column<int>(type: "integer", nullable: false),
                    ActionDescription = table.Column<string>(type: "text", nullable: false),
                    Responsible = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredictiveActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PredictiveActions_DecisionRecords_DecisionRecordId",
                        column: x => x.DecisionRecordId,
                        principalTable: "DecisionRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_AssetId",
                table: "Activities",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_AssetObjectiveId",
                table: "Activities",
                column: "AssetObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetObjectives_OrganisationalObjectiveId",
                table: "AssetObjectives",
                column: "OrganisationalObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditFindings_AssetId",
                table: "AuditFindings",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditFindings_DecisionRecordId",
                table: "AuditFindings",
                column: "DecisionRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_DataAssets_InformationSystemId",
                table: "DataAssets",
                column: "InformationSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_DecisionRecords_ActivityId",
                table: "DecisionRecords",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_DecisionRecords_AssetId",
                table: "DecisionRecords",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_DecisionRecords_AuditFindingId1",
                table: "DecisionRecords",
                column: "AuditFindingId1");

            migrationBuilder.CreateIndex(
                name: "IX_PredictiveActions_DecisionRecordId",
                table: "PredictiveActions",
                column: "DecisionRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskItems_ActivityId",
                table: "RiskItems",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskItems_AssetId",
                table: "RiskItems",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditFindings_DecisionRecords_DecisionRecordId",
                table: "AuditFindings",
                column: "DecisionRecordId",
                principalTable: "DecisionRecords",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AssetObjectives_AssetObjectiveId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_AuditFindings_DecisionRecords_DecisionRecordId",
                table: "AuditFindings");

            migrationBuilder.DropTable(
                name: "DataAssets");

            migrationBuilder.DropTable(
                name: "PredictiveActions");

            migrationBuilder.DropTable(
                name: "RiskItems");

            migrationBuilder.DropTable(
                name: "InformationSystems");

            migrationBuilder.DropTable(
                name: "AssetObjectives");

            migrationBuilder.DropTable(
                name: "OrganisationalObjectives");

            migrationBuilder.DropTable(
                name: "DecisionRecords");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "AuditFindings");

            migrationBuilder.DropColumn(
                name: "LifecycleStage",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "RiskRating",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Assets",
                newName: "PurchasePrice");

            migrationBuilder.RenameColumn(
                name: "AssetType",
                table: "Assets",
                newName: "Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "Assets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
