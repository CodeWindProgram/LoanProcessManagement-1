using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanProcessManagement.Persistence.Migrations
{
    public partial class Initial_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LpmLeadMaster_LpmBranchMasters_BranchID",
                table: "LpmLeadMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_LpmLeadMaster_LpmLeadStatusMaster_CurrentStatus",
                table: "LpmLeadMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_LpmLeadMaster_LpmLoanProductMaster_ProductID",
                table: "LpmLeadMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LpmLoanProductMaster",
                table: "LpmLoanProductMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LpmLeadStatusMaster",
                table: "LpmLeadStatusMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LpmLeadMaster",
                table: "LpmLeadMaster");

            migrationBuilder.RenameTable(
                name: "LpmLoanProductMaster",
                newName: "LpmLoanProductMasters");

            migrationBuilder.RenameTable(
                name: "LpmLeadStatusMaster",
                newName: "LpmLeadStatusMasters");

            migrationBuilder.RenameTable(
                name: "LpmLeadMaster",
                newName: "LpmLeadMasters");

            migrationBuilder.RenameIndex(
                name: "IX_LpmLeadMaster_ProductID",
                table: "LpmLeadMasters",
                newName: "IX_LpmLeadMasters_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_LpmLeadMaster_CurrentStatus",
                table: "LpmLeadMasters",
                newName: "IX_LpmLeadMasters_CurrentStatus");

            migrationBuilder.RenameIndex(
                name: "IX_LpmLeadMaster_BranchID",
                table: "LpmLeadMasters",
                newName: "IX_LpmLeadMasters_BranchID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LpmLoanProductMasters",
                table: "LpmLoanProductMasters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LpmLeadStatusMasters",
                table: "LpmLeadStatusMasters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LpmLeadMasters",
                table: "LpmLeadMasters",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 9, 1, 15, 57, 3, 70, DateTimeKind.Local).AddTicks(1807));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 8, 1, 15, 57, 3, 70, DateTimeKind.Local).AddTicks(1620));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2022, 3, 1, 15, 57, 3, 70, DateTimeKind.Local).AddTicks(1777));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 7, 1, 15, 57, 3, 70, DateTimeKind.Local).AddTicks(1840));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2022, 3, 1, 15, 57, 3, 70, DateTimeKind.Local).AddTicks(1741));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2022, 5, 1, 15, 57, 3, 68, DateTimeKind.Local).AddTicks(9013));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 1, 15, 57, 3, 70, DateTimeKind.Local).AddTicks(4344));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 1, 15, 57, 3, 70, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 1, 15, 57, 3, 70, DateTimeKind.Local).AddTicks(3289));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 1, 15, 57, 3, 70, DateTimeKind.Local).AddTicks(4252));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 1, 15, 57, 3, 70, DateTimeKind.Local).AddTicks(4453));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 1, 15, 57, 3, 70, DateTimeKind.Local).AddTicks(4389));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 1, 15, 57, 3, 70, DateTimeKind.Local).AddTicks(4423));

            migrationBuilder.AddForeignKey(
                name: "FK_LpmLeadMasters_LpmBranchMasters_BranchID",
                table: "LpmLeadMasters",
                column: "BranchID",
                principalTable: "LpmBranchMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LpmLeadMasters_LpmLeadStatusMasters_CurrentStatus",
                table: "LpmLeadMasters",
                column: "CurrentStatus",
                principalTable: "LpmLeadStatusMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LpmLeadMasters_LpmLoanProductMasters_ProductID",
                table: "LpmLeadMasters",
                column: "ProductID",
                principalTable: "LpmLoanProductMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LpmLeadMasters_LpmBranchMasters_BranchID",
                table: "LpmLeadMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_LpmLeadMasters_LpmLeadStatusMasters_CurrentStatus",
                table: "LpmLeadMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_LpmLeadMasters_LpmLoanProductMasters_ProductID",
                table: "LpmLeadMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LpmLoanProductMasters",
                table: "LpmLoanProductMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LpmLeadStatusMasters",
                table: "LpmLeadStatusMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LpmLeadMasters",
                table: "LpmLeadMasters");

            migrationBuilder.RenameTable(
                name: "LpmLoanProductMasters",
                newName: "LpmLoanProductMaster");

            migrationBuilder.RenameTable(
                name: "LpmLeadStatusMasters",
                newName: "LpmLeadStatusMaster");

            migrationBuilder.RenameTable(
                name: "LpmLeadMasters",
                newName: "LpmLeadMaster");

            migrationBuilder.RenameIndex(
                name: "IX_LpmLeadMasters_ProductID",
                table: "LpmLeadMaster",
                newName: "IX_LpmLeadMaster_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_LpmLeadMasters_CurrentStatus",
                table: "LpmLeadMaster",
                newName: "IX_LpmLeadMaster_CurrentStatus");

            migrationBuilder.RenameIndex(
                name: "IX_LpmLeadMasters_BranchID",
                table: "LpmLeadMaster",
                newName: "IX_LpmLeadMaster_BranchID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LpmLoanProductMaster",
                table: "LpmLoanProductMaster",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LpmLeadStatusMaster",
                table: "LpmLeadStatusMaster",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LpmLeadMaster",
                table: "LpmLeadMaster",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_LpmLeadMaster_LpmBranchMasters_BranchID",
                table: "LpmLeadMaster",
                column: "BranchID",
                principalTable: "LpmBranchMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LpmLeadMaster_LpmLeadStatusMaster_CurrentStatus",
                table: "LpmLeadMaster",
                column: "CurrentStatus",
                principalTable: "LpmLeadStatusMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LpmLeadMaster_LpmLoanProductMaster_ProductID",
                table: "LpmLeadMaster",
                column: "ProductID",
                principalTable: "LpmLoanProductMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
