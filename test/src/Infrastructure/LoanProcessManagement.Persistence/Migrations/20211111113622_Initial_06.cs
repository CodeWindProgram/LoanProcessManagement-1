using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanProcessManagement.Persistence.Migrations
{
    public partial class Initial_06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSanctionedPlanReceived",
                table: "LpmLeadMasters");

            migrationBuilder.DropColumn(
                name: "PropertyType",
                table: "LpmLeadMasters");

            migrationBuilder.AddColumn<long>(
                name: "IsSanctionedPlanReceivedID",
                table: "LpmLeadMasters",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LpmLoanPropertyTypePropertyID",
                table: "LpmLeadMasters",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LpmLoanSanctionedPlanIsSanctionedPlanReceivedID",
                table: "LpmLeadMasters",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PropertyID",
                table: "LpmLeadMasters",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LpmLoanPropertyTypes",
                columns: table => new
                {
                    PropertyID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    PropertyType = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LpmLoanPropertyTypes", x => x.PropertyID);
                });

            migrationBuilder.CreateTable(
                name: "LpmLoanSanctionedPlans",
                columns: table => new
                {
                    IsSanctionedPlanReceivedID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    IsSanctionedPlanReceivedType = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LpmLoanSanctionedPlans", x => x.IsSanctionedPlanReceivedID);
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 9, 11, 17, 6, 20, 964, DateTimeKind.Local).AddTicks(5609));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 8, 11, 17, 6, 20, 964, DateTimeKind.Local).AddTicks(5185));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2022, 3, 11, 17, 6, 20, 964, DateTimeKind.Local).AddTicks(5546));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 7, 11, 17, 6, 20, 964, DateTimeKind.Local).AddTicks(5685));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2022, 3, 11, 17, 6, 20, 964, DateTimeKind.Local).AddTicks(5463));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2022, 5, 11, 17, 6, 20, 961, DateTimeKind.Local).AddTicks(1477));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 17, 6, 20, 965, DateTimeKind.Local).AddTicks(281));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 17, 6, 20, 965, DateTimeKind.Local).AddTicks(213));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 17, 6, 20, 964, DateTimeKind.Local).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 17, 6, 20, 965, DateTimeKind.Local).AddTicks(83));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 17, 6, 20, 965, DateTimeKind.Local).AddTicks(478));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 17, 6, 20, 965, DateTimeKind.Local).AddTicks(346));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 17, 6, 20, 965, DateTimeKind.Local).AddTicks(415));

            migrationBuilder.CreateIndex(
                name: "IX_LpmLeadMasters_LpmLoanPropertyTypePropertyID",
                table: "LpmLeadMasters",
                column: "LpmLoanPropertyTypePropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_LpmLeadMasters_LpmLoanSanctionedPlanIsSanctionedPlanReceivedID",
                table: "LpmLeadMasters",
                column: "LpmLoanSanctionedPlanIsSanctionedPlanReceivedID");

            migrationBuilder.AddForeignKey(
                name: "FK_LpmLeadMasters_LpmLoanPropertyTypes_LpmLoanPropertyTypePropertyID",
                table: "LpmLeadMasters",
                column: "LpmLoanPropertyTypePropertyID",
                principalTable: "LpmLoanPropertyTypes",
                principalColumn: "PropertyID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LpmLeadMasters_LpmLoanSanctionedPlans_LpmLoanSanctionedPlanIsSanctionedPlanReceivedID",
                table: "LpmLeadMasters",
                column: "LpmLoanSanctionedPlanIsSanctionedPlanReceivedID",
                principalTable: "LpmLoanSanctionedPlans",
                principalColumn: "IsSanctionedPlanReceivedID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LpmLeadMasters_LpmLoanPropertyTypes_LpmLoanPropertyTypePropertyID",
                table: "LpmLeadMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_LpmLeadMasters_LpmLoanSanctionedPlans_LpmLoanSanctionedPlanIsSanctionedPlanReceivedID",
                table: "LpmLeadMasters");

            migrationBuilder.DropTable(
                name: "LpmLoanPropertyTypes");

            migrationBuilder.DropTable(
                name: "LpmLoanSanctionedPlans");

            migrationBuilder.DropIndex(
                name: "IX_LpmLeadMasters_LpmLoanPropertyTypePropertyID",
                table: "LpmLeadMasters");

            migrationBuilder.DropIndex(
                name: "IX_LpmLeadMasters_LpmLoanSanctionedPlanIsSanctionedPlanReceivedID",
                table: "LpmLeadMasters");

            migrationBuilder.DropColumn(
                name: "IsSanctionedPlanReceivedID",
                table: "LpmLeadMasters");

            migrationBuilder.DropColumn(
                name: "LpmLoanPropertyTypePropertyID",
                table: "LpmLeadMasters");

            migrationBuilder.DropColumn(
                name: "LpmLoanSanctionedPlanIsSanctionedPlanReceivedID",
                table: "LpmLeadMasters");

            migrationBuilder.DropColumn(
                name: "PropertyID",
                table: "LpmLeadMasters");

            migrationBuilder.AddColumn<string>(
                name: "IsSanctionedPlanReceived",
                table: "LpmLeadMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertyType",
                table: "LpmLeadMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 9, 10, 19, 7, 19, 972, DateTimeKind.Local).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 8, 10, 19, 7, 19, 972, DateTimeKind.Local).AddTicks(9273));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2022, 3, 10, 19, 7, 19, 972, DateTimeKind.Local).AddTicks(9676));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 7, 10, 19, 7, 19, 972, DateTimeKind.Local).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2022, 3, 10, 19, 7, 19, 972, DateTimeKind.Local).AddTicks(9627));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2022, 5, 10, 19, 7, 19, 971, DateTimeKind.Local).AddTicks(2848));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 10, 19, 7, 19, 973, DateTimeKind.Local).AddTicks(3227));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 10, 19, 7, 19, 973, DateTimeKind.Local).AddTicks(3190));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 10, 19, 7, 19, 973, DateTimeKind.Local).AddTicks(1546));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 10, 19, 7, 19, 973, DateTimeKind.Local).AddTicks(3113));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 10, 19, 7, 19, 973, DateTimeKind.Local).AddTicks(3334));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 10, 19, 7, 19, 973, DateTimeKind.Local).AddTicks(3262));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 10, 19, 7, 19, 973, DateTimeKind.Local).AddTicks(3300));
        }
    }
}
