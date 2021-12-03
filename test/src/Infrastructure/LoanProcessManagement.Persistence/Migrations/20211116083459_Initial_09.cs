using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanProcessManagement.Persistence.Migrations
{
    public partial class Initial_09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LpmLeadProcessCycles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    lead_Id = table.Column<long>(nullable: false),
                    CurrentStatus = table.Column<long>(nullable: true),
                    DateOfAction = table.Column<DateTime>(nullable: true),
                    LoanProductID = table.Column<long>(nullable: true),
                    InsuranceProductID = table.Column<long>(nullable: true),
                    LoanAmount = table.Column<long>(nullable: true),
                    InsuranceAmount = table.Column<long>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LpmLeadProcessCycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LpmLeadProcessCycles_LpmLeadStatusMasters_CurrentStatus",
                        column: x => x.CurrentStatus,
                        principalTable: "LpmLeadStatusMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LpmLeadProcessCycles_LpmLoanProductMasters_InsuranceProductID",
                        column: x => x.InsuranceProductID,
                        principalTable: "LpmLoanProductMasters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LpmLeadProcessCycles_LpmLoanProductMasters_LoanProductID",
                        column: x => x.LoanProductID,
                        principalTable: "LpmLoanProductMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LpmLeadProcessCycles_LpmLeadMasters_lead_Id",
                        column: x => x.lead_Id,
                        principalTable: "LpmLeadMasters",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 9, 16, 14, 4, 59, 1, DateTimeKind.Local).AddTicks(3568));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 8, 16, 14, 4, 59, 1, DateTimeKind.Local).AddTicks(3202));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2022, 3, 16, 14, 4, 59, 1, DateTimeKind.Local).AddTicks(3512));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 7, 16, 14, 4, 59, 1, DateTimeKind.Local).AddTicks(3630));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2022, 3, 16, 14, 4, 59, 1, DateTimeKind.Local).AddTicks(3445));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2022, 5, 16, 14, 4, 58, 998, DateTimeKind.Local).AddTicks(137));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 16, 14, 4, 59, 2, DateTimeKind.Local).AddTicks(754));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 16, 14, 4, 59, 2, DateTimeKind.Local).AddTicks(714));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 16, 14, 4, 59, 1, DateTimeKind.Local).AddTicks(8580));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 16, 14, 4, 59, 2, DateTimeKind.Local).AddTicks(626));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 16, 14, 4, 59, 2, DateTimeKind.Local).AddTicks(872));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 16, 14, 4, 59, 2, DateTimeKind.Local).AddTicks(791));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 16, 14, 4, 59, 2, DateTimeKind.Local).AddTicks(836));

            migrationBuilder.CreateIndex(
                name: "IX_LpmLeadProcessCycles_CurrentStatus",
                table: "LpmLeadProcessCycles",
                column: "CurrentStatus");

            migrationBuilder.CreateIndex(
                name: "IX_LpmLeadProcessCycles_InsuranceProductID",
                table: "LpmLeadProcessCycles",
                column: "InsuranceProductID");

            migrationBuilder.CreateIndex(
                name: "IX_LpmLeadProcessCycles_LoanProductID",
                table: "LpmLeadProcessCycles",
                column: "LoanProductID");

            migrationBuilder.CreateIndex(
                name: "IX_LpmLeadProcessCycles_lead_Id",
                table: "LpmLeadProcessCycles",
                column: "lead_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LpmLeadProcessCycles");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 9, 16, 12, 19, 5, 75, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 8, 16, 12, 19, 5, 75, DateTimeKind.Local).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2022, 3, 16, 12, 19, 5, 75, DateTimeKind.Local).AddTicks(7690));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 7, 16, 12, 19, 5, 75, DateTimeKind.Local).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2022, 3, 16, 12, 19, 5, 75, DateTimeKind.Local).AddTicks(7624));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2022, 5, 16, 12, 19, 5, 73, DateTimeKind.Local).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 16, 12, 19, 5, 76, DateTimeKind.Local).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 16, 12, 19, 5, 76, DateTimeKind.Local).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 16, 12, 19, 5, 76, DateTimeKind.Local).AddTicks(95));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 16, 12, 19, 5, 76, DateTimeKind.Local).AddTicks(1620));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 16, 12, 19, 5, 76, DateTimeKind.Local).AddTicks(1901));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 16, 12, 19, 5, 76, DateTimeKind.Local).AddTicks(1815));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 16, 12, 19, 5, 76, DateTimeKind.Local).AddTicks(1859));
        }
    }
}
