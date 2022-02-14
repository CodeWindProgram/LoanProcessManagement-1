using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanProcessManagement.Persistence.Migrations
{
    public partial class Intial_19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LpmLeadIncomeAssessmentDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    FormNo = table.Column<string>(nullable: true),
                    lead_Id = table.Column<long>(nullable: false),
                    StartDate = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true),
                    EmployerName1 = table.Column<string>(nullable: true),
                    EmployerName2 = table.Column<string>(nullable: true),
                    EmployerName3 = table.Column<string>(nullable: true),
                    EmployerName4 = table.Column<string>(nullable: true),
                    EmployerName5 = table.Column<string>(nullable: true),
                    FileType = table.Column<string>(nullable: true),
                    Institution_Id = table.Column<long>(nullable: false),
                    DocumentType = table.Column<string>(nullable: true),
                    PdfFileName = table.Column<string>(nullable: true),
                    FilePassword = table.Column<string>(nullable: true),
                    ApplicantDetailId = table.Column<long>(nullable: false),
                    ApplicantType = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsSuccess = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LpmLeadIncomeAssessmentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LpmLeadIncomeAssessmentDetails_LpmLeadApplicantsDetails_ApplicantDetailId",
                        column: x => x.ApplicantDetailId,
                        principalTable: "LpmLeadApplicantsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lpmLeadInstitutionMasters",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Institution_Id = table.Column<long>(nullable: false),
                    Institution_Type = table.Column<string>(nullable: true),
                    Institution_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lpmLeadInstitutionMasters", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 12, 14, 15, 56, 50, 704, DateTimeKind.Local).AddTicks(1580));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 11, 14, 15, 56, 50, 704, DateTimeKind.Local).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2022, 6, 14, 15, 56, 50, 704, DateTimeKind.Local).AddTicks(1553));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 10, 14, 15, 56, 50, 704, DateTimeKind.Local).AddTicks(1610));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2022, 6, 14, 15, 56, 50, 704, DateTimeKind.Local).AddTicks(1521));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2022, 8, 14, 15, 56, 50, 701, DateTimeKind.Local).AddTicks(9782));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 2, 14, 15, 56, 50, 704, DateTimeKind.Local).AddTicks(4299));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2022, 2, 14, 15, 56, 50, 704, DateTimeKind.Local).AddTicks(4269));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 2, 14, 15, 56, 50, 704, DateTimeKind.Local).AddTicks(3228));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 2, 14, 15, 56, 50, 704, DateTimeKind.Local).AddTicks(4206));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2022, 2, 14, 15, 56, 50, 704, DateTimeKind.Local).AddTicks(4468));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 2, 14, 15, 56, 50, 704, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2022, 2, 14, 15, 56, 50, 704, DateTimeKind.Local).AddTicks(4439));

            migrationBuilder.CreateIndex(
                name: "IX_LpmLeadIncomeAssessmentDetails_ApplicantDetailId",
                table: "LpmLeadIncomeAssessmentDetails",
                column: "ApplicantDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LpmLeadIncomeAssessmentDetails");

            migrationBuilder.DropTable(
                name: "lpmLeadInstitutionMasters");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 10, 27, 22, 26, 29, 527, DateTimeKind.Local).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 9, 27, 22, 26, 29, 527, DateTimeKind.Local).AddTicks(2049));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2022, 4, 27, 22, 26, 29, 527, DateTimeKind.Local).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 8, 27, 22, 26, 29, 527, DateTimeKind.Local).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2022, 4, 27, 22, 26, 29, 527, DateTimeKind.Local).AddTicks(2168));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2022, 6, 27, 22, 26, 29, 525, DateTimeKind.Local).AddTicks(5889));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 27, 22, 26, 29, 527, DateTimeKind.Local).AddTicks(5163));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 27, 22, 26, 29, 527, DateTimeKind.Local).AddTicks(5130));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 27, 22, 26, 29, 527, DateTimeKind.Local).AddTicks(4030));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 27, 22, 26, 29, 527, DateTimeKind.Local).AddTicks(5069));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 27, 22, 26, 29, 527, DateTimeKind.Local).AddTicks(5259));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 27, 22, 26, 29, 527, DateTimeKind.Local).AddTicks(5194));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 27, 22, 26, 29, 527, DateTimeKind.Local).AddTicks(5230));
        }
    }
}
