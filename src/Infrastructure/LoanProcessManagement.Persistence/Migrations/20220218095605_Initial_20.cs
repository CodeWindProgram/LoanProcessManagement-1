using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanProcessManagement.Persistence.Migrations
{
    public partial class Initial_20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isCibilCheckRequired",
                table: "LpmLeadApplicantsDetails",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "isCibilCheckSubmitSuccess",
                table: "LpmLeadApplicantsDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isGstRequired",
                table: "LpmLeadApplicantsDetails",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "isGstSubmitSuccess",
                table: "LpmLeadApplicantsDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isItrRequired",
                table: "LpmLeadApplicantsDetails",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "isItrSubmitSuccess",
                table: "LpmLeadApplicantsDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isPerfiosRequired",
                table: "LpmLeadApplicantsDetails",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "isPerfiosSubmitSuccess",
                table: "LpmLeadApplicantsDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ApplicantDetailId",
                table: "LPMGSTEnquiryDetails",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 12, 18, 15, 26, 3, 76, DateTimeKind.Local).AddTicks(654));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 11, 18, 15, 26, 3, 76, DateTimeKind.Local).AddTicks(254));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2022, 6, 18, 15, 26, 3, 76, DateTimeKind.Local).AddTicks(587));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 10, 18, 15, 26, 3, 76, DateTimeKind.Local).AddTicks(723));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2022, 6, 18, 15, 26, 3, 76, DateTimeKind.Local).AddTicks(517));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2022, 8, 18, 15, 26, 3, 72, DateTimeKind.Local).AddTicks(8605));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 2, 18, 15, 26, 3, 76, DateTimeKind.Local).AddTicks(6396));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2022, 2, 18, 15, 26, 3, 76, DateTimeKind.Local).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 2, 18, 15, 26, 3, 76, DateTimeKind.Local).AddTicks(3953));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 2, 18, 15, 26, 3, 76, DateTimeKind.Local).AddTicks(5975));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2022, 2, 18, 15, 26, 3, 76, DateTimeKind.Local).AddTicks(6583));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 2, 18, 15, 26, 3, 76, DateTimeKind.Local).AddTicks(6457));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2022, 2, 18, 15, 26, 3, 76, DateTimeKind.Local).AddTicks(6524));

            migrationBuilder.CreateIndex(
                name: "IX_LPMGSTEnquiryDetails_ApplicantDetailId",
                table: "LPMGSTEnquiryDetails",
                column: "ApplicantDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_LPMGSTEnquiryDetails_LpmLeadApplicantsDetails_ApplicantDetailId",
                table: "LPMGSTEnquiryDetails",
                column: "ApplicantDetailId",
                principalTable: "LpmLeadApplicantsDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LPMGSTEnquiryDetails_LpmLeadApplicantsDetails_ApplicantDetailId",
                table: "LPMGSTEnquiryDetails");

            migrationBuilder.DropIndex(
                name: "IX_LPMGSTEnquiryDetails_ApplicantDetailId",
                table: "LPMGSTEnquiryDetails");

            migrationBuilder.DropColumn(
                name: "isCibilCheckRequired",
                table: "LpmLeadApplicantsDetails");

            migrationBuilder.DropColumn(
                name: "isCibilCheckSubmitSuccess",
                table: "LpmLeadApplicantsDetails");

            migrationBuilder.DropColumn(
                name: "isGstRequired",
                table: "LpmLeadApplicantsDetails");

            migrationBuilder.DropColumn(
                name: "isGstSubmitSuccess",
                table: "LpmLeadApplicantsDetails");

            migrationBuilder.DropColumn(
                name: "isItrRequired",
                table: "LpmLeadApplicantsDetails");

            migrationBuilder.DropColumn(
                name: "isItrSubmitSuccess",
                table: "LpmLeadApplicantsDetails");

            migrationBuilder.DropColumn(
                name: "isPerfiosRequired",
                table: "LpmLeadApplicantsDetails");

            migrationBuilder.DropColumn(
                name: "isPerfiosSubmitSuccess",
                table: "LpmLeadApplicantsDetails");

            migrationBuilder.DropColumn(
                name: "ApplicantDetailId",
                table: "LPMGSTEnquiryDetails");

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
        }
    }
}
