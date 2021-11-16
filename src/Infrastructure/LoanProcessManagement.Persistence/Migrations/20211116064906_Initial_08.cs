using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanProcessManagement.Persistence.Migrations
{
    public partial class Initial_08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LpmLoanProductSchemeMappings_LpmLoanProductMasters_LpmLoanProductMasterId",
                table: "LpmLoanProductSchemeMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_LpmLoanProductSchemeMappings_LpmLoanSchemeMasters_LpmLoanSchemeMasterId",
                table: "LpmLoanProductSchemeMappings");

            migrationBuilder.DropIndex(
                name: "IX_LpmLoanProductSchemeMappings_LpmLoanProductMasterId",
                table: "LpmLoanProductSchemeMappings");

            migrationBuilder.DropIndex(
                name: "IX_LpmLoanProductSchemeMappings_LpmLoanSchemeMasterId",
                table: "LpmLoanProductSchemeMappings");

            migrationBuilder.DropColumn(
                name: "LpmLoanProductMasterId",
                table: "LpmLoanProductSchemeMappings");

            migrationBuilder.DropColumn(
                name: "LpmLoanSchemeMasterId",
                table: "LpmLoanProductSchemeMappings");

            migrationBuilder.AddColumn<string>(
                name: "AnnualTurnOverInLastFy",
                table: "LpmLeadMasters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExemptedCategory",
                table: "LpmLeadMasters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsApplicantExemptedFromGst",
                table: "LpmLeadMasters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeOfFirms",
                table: "LpmLeadMasters",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_LpmLoanProductSchemeMappings_ProductID",
                table: "LpmLoanProductSchemeMappings",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_LpmLoanProductSchemeMappings_SchemeID",
                table: "LpmLoanProductSchemeMappings",
                column: "SchemeID");

            migrationBuilder.AddForeignKey(
                name: "FK_LpmLoanProductSchemeMappings_LpmLoanProductMasters_ProductID",
                table: "LpmLoanProductSchemeMappings",
                column: "ProductID",
                principalTable: "LpmLoanProductMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LpmLoanProductSchemeMappings_LpmLoanSchemeMasters_SchemeID",
                table: "LpmLoanProductSchemeMappings",
                column: "SchemeID",
                principalTable: "LpmLoanSchemeMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LpmLoanProductSchemeMappings_LpmLoanProductMasters_ProductID",
                table: "LpmLoanProductSchemeMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_LpmLoanProductSchemeMappings_LpmLoanSchemeMasters_SchemeID",
                table: "LpmLoanProductSchemeMappings");

            migrationBuilder.DropIndex(
                name: "IX_LpmLoanProductSchemeMappings_ProductID",
                table: "LpmLoanProductSchemeMappings");

            migrationBuilder.DropIndex(
                name: "IX_LpmLoanProductSchemeMappings_SchemeID",
                table: "LpmLoanProductSchemeMappings");

            migrationBuilder.DropColumn(
                name: "AnnualTurnOverInLastFy",
                table: "LpmLeadMasters");

            migrationBuilder.DropColumn(
                name: "ExemptedCategory",
                table: "LpmLeadMasters");

            migrationBuilder.DropColumn(
                name: "IsApplicantExemptedFromGst",
                table: "LpmLeadMasters");

            migrationBuilder.DropColumn(
                name: "TypeOfFirms",
                table: "LpmLeadMasters");

            migrationBuilder.AddColumn<long>(
                name: "LpmLoanProductMasterId",
                table: "LpmLoanProductSchemeMappings",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LpmLoanSchemeMasterId",
                table: "LpmLoanProductSchemeMappings",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 9, 11, 17, 25, 40, 258, DateTimeKind.Local).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 8, 11, 17, 25, 40, 258, DateTimeKind.Local).AddTicks(8028));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2022, 3, 11, 17, 25, 40, 258, DateTimeKind.Local).AddTicks(8364));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 7, 11, 17, 25, 40, 258, DateTimeKind.Local).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2022, 3, 11, 17, 25, 40, 258, DateTimeKind.Local).AddTicks(8327));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2022, 5, 11, 17, 25, 40, 257, DateTimeKind.Local).AddTicks(1848));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 17, 25, 40, 259, DateTimeKind.Local).AddTicks(2113));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 17, 25, 40, 259, DateTimeKind.Local).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 17, 25, 40, 259, DateTimeKind.Local).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 17, 25, 40, 259, DateTimeKind.Local).AddTicks(2015));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 17, 25, 40, 259, DateTimeKind.Local).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 17, 25, 40, 259, DateTimeKind.Local).AddTicks(2139));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 17, 25, 40, 259, DateTimeKind.Local).AddTicks(2171));

            migrationBuilder.CreateIndex(
                name: "IX_LpmLoanProductSchemeMappings_LpmLoanProductMasterId",
                table: "LpmLoanProductSchemeMappings",
                column: "LpmLoanProductMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_LpmLoanProductSchemeMappings_LpmLoanSchemeMasterId",
                table: "LpmLoanProductSchemeMappings",
                column: "LpmLoanSchemeMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_LpmLoanProductSchemeMappings_LpmLoanProductMasters_LpmLoanProductMasterId",
                table: "LpmLoanProductSchemeMappings",
                column: "LpmLoanProductMasterId",
                principalTable: "LpmLoanProductMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LpmLoanProductSchemeMappings_LpmLoanSchemeMasters_LpmLoanSchemeMasterId",
                table: "LpmLoanProductSchemeMappings",
                column: "LpmLoanSchemeMasterId",
                principalTable: "LpmLoanSchemeMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
