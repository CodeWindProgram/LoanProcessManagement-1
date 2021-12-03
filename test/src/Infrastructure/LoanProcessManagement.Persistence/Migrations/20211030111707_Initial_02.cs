using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanProcessManagement.Persistence.Migrations
{
    public partial class Initial_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LgId",
                table: "LpmMenuMasters",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LpmLeadStatusMaster",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    StatusDescription = table.Column<string>(nullable: true),
                    SerialOrder = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LpmLeadStatusMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LpmLoanProductMaster",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ProductType = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    ProducDescription = table.Column<string>(nullable: true),
                    SerialOrder = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LpmLoanProductMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LpmLeadMaster",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    lead_Id = table.Column<string>(nullable: true),
                    FormNo = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CustomerResidenceaddress = table.Column<string>(nullable: true),
                    CustomerResidencePincode = table.Column<string>(nullable: true),
                    CustomerOfficeaddress = table.Column<string>(nullable: true),
                    CustomerOfficePincode = table.Column<string>(nullable: true),
                    CustomerPhone = table.Column<string>(nullable: true),
                    CustomerPhone_Alternate = table.Column<string>(nullable: true),
                    CustomerEmail = table.Column<string>(nullable: true),
                    ProductID = table.Column<long>(nullable: false),
                    CurrentStatus = table.Column<long>(nullable: false),
                    CustomerType = table.Column<string>(nullable: true),
                    BranchID = table.Column<long>(nullable: false),
                    Customer_latitude = table.Column<string>(nullable: true),
                    Customer_longitude = table.Column<string>(nullable: true),
                    Lead_assignee_Id = table.Column<string>(nullable: true),
                    Appointment_Date = table.Column<DateTime>(nullable: false),
                    Conversion_date = table.Column<DateTime>(nullable: false),
                    Disbursal_date = table.Column<string>(nullable: true),
                    Industry_Major = table.Column<string>(nullable: true),
                    Sale_type = table.Column<string>(nullable: true),
                    EmploymentType = table.Column<string>(nullable: true),
                    NationalityType = table.Column<string>(nullable: true),
                    IsPropertyIdentified = table.Column<string>(nullable: true),
                    PropertyPincode = table.Column<string>(nullable: true),
                    PropertyUnderConstruction = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    UnitName = table.Column<string>(nullable: true),
                    ProjectAddress = table.Column<string>(nullable: true),
                    IsSanctionedPlanReceived = table.Column<string>(nullable: true),
                    LostLeadReasonID = table.Column<long>(nullable: false),
                    LostLeadComment = table.Column<string>(nullable: true),
                    RejectLeadReasonID = table.Column<long>(nullable: false),
                    RejectedLeadComment = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    GoggleLatitude = table.Column<string>(nullable: true),
                    GoggleLongitude = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LpmLeadMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LpmLeadMaster_LpmBranchMasters_BranchID",
                        column: x => x.BranchID,
                        principalTable: "LpmBranchMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LpmLeadMaster_LpmLeadStatusMaster_CurrentStatus",
                        column: x => x.CurrentStatus,
                        principalTable: "LpmLeadStatusMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LpmLeadMaster_LpmLoanProductMaster_ProductID",
                        column: x => x.ProductID,
                        principalTable: "LpmLoanProductMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 8, 30, 16, 47, 6, 116, DateTimeKind.Local).AddTicks(6164));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 7, 30, 16, 47, 6, 116, DateTimeKind.Local).AddTicks(5793));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2022, 2, 28, 16, 47, 6, 116, DateTimeKind.Local).AddTicks(6106));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 6, 30, 16, 47, 6, 116, DateTimeKind.Local).AddTicks(6233));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2022, 2, 28, 16, 47, 6, 116, DateTimeKind.Local).AddTicks(6038));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2022, 4, 30, 16, 47, 6, 114, DateTimeKind.Local).AddTicks(3476));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 30, 16, 47, 6, 117, DateTimeKind.Local).AddTicks(931));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 30, 16, 47, 6, 117, DateTimeKind.Local).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 30, 16, 47, 6, 116, DateTimeKind.Local).AddTicks(9028));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 30, 16, 47, 6, 117, DateTimeKind.Local).AddTicks(756));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 30, 16, 47, 6, 117, DateTimeKind.Local).AddTicks(1102));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 30, 16, 47, 6, 117, DateTimeKind.Local).AddTicks(987));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 30, 16, 47, 6, 117, DateTimeKind.Local).AddTicks(1050));

            migrationBuilder.CreateIndex(
                name: "IX_LpmLeadMaster_BranchID",
                table: "LpmLeadMaster",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_LpmLeadMaster_CurrentStatus",
                table: "LpmLeadMaster",
                column: "CurrentStatus");

            migrationBuilder.CreateIndex(
                name: "IX_LpmLeadMaster_ProductID",
                table: "LpmLeadMaster",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LpmLeadMaster");

            migrationBuilder.DropTable(
                name: "LpmLeadStatusMaster");

            migrationBuilder.DropTable(
                name: "LpmLoanProductMaster");

            migrationBuilder.DropColumn(
                name: "LgId",
                table: "LpmMenuMasters");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 8, 22, 1, 43, 45, 414, DateTimeKind.Local).AddTicks(5236));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 7, 22, 1, 43, 45, 414, DateTimeKind.Local).AddTicks(5063));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2022, 2, 22, 1, 43, 45, 414, DateTimeKind.Local).AddTicks(5209));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 6, 22, 1, 43, 45, 414, DateTimeKind.Local).AddTicks(5266));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2022, 2, 22, 1, 43, 45, 414, DateTimeKind.Local).AddTicks(5176));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2022, 4, 22, 1, 43, 45, 413, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 22, 1, 43, 45, 414, DateTimeKind.Local).AddTicks(7520));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 22, 1, 43, 45, 414, DateTimeKind.Local).AddTicks(7493));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 22, 1, 43, 45, 414, DateTimeKind.Local).AddTicks(6565));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 22, 1, 43, 45, 414, DateTimeKind.Local).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 22, 1, 43, 45, 414, DateTimeKind.Local).AddTicks(7599));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 22, 1, 43, 45, 414, DateTimeKind.Local).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 22, 1, 43, 45, 414, DateTimeKind.Local).AddTicks(7575));
        }
    }
}
