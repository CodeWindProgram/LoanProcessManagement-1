using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanProcessManagement.Persistence.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LpmUserMasters_BranchId",
                table: "LpmUserMasters");

            migrationBuilder.DropIndex(
                name: "IX_LpmUserMasters_UserRoleId",
                table: "LpmUserMasters");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 8, 21, 20, 2, 5, 866, DateTimeKind.Local).AddTicks(5812));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 7, 21, 20, 2, 5, 866, DateTimeKind.Local).AddTicks(5644));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2022, 2, 21, 20, 2, 5, 866, DateTimeKind.Local).AddTicks(5785));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 6, 21, 20, 2, 5, 866, DateTimeKind.Local).AddTicks(5843));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2022, 2, 21, 20, 2, 5, 866, DateTimeKind.Local).AddTicks(5755));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2022, 4, 21, 20, 2, 5, 865, DateTimeKind.Local).AddTicks(3192));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 21, 20, 2, 5, 866, DateTimeKind.Local).AddTicks(8052));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 21, 20, 2, 5, 866, DateTimeKind.Local).AddTicks(8022));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 21, 20, 2, 5, 866, DateTimeKind.Local).AddTicks(7119));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 21, 20, 2, 5, 866, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 21, 20, 2, 5, 866, DateTimeKind.Local).AddTicks(8131));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 21, 20, 2, 5, 866, DateTimeKind.Local).AddTicks(8079));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 21, 20, 2, 5, 866, DateTimeKind.Local).AddTicks(8107));

            migrationBuilder.CreateIndex(
                name: "IX_LpmUserMasters_BranchId",
                table: "LpmUserMasters",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LpmUserMasters_UserRoleId",
                table: "LpmUserMasters",
                column: "UserRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LpmUserMasters_BranchId",
                table: "LpmUserMasters");

            migrationBuilder.DropIndex(
                name: "IX_LpmUserMasters_UserRoleId",
                table: "LpmUserMasters");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 8, 21, 19, 55, 5, 297, DateTimeKind.Local).AddTicks(9250));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 7, 21, 19, 55, 5, 297, DateTimeKind.Local).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2022, 2, 21, 19, 55, 5, 297, DateTimeKind.Local).AddTicks(9223));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 6, 21, 19, 55, 5, 297, DateTimeKind.Local).AddTicks(9281));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2022, 2, 21, 19, 55, 5, 297, DateTimeKind.Local).AddTicks(9186));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2022, 4, 21, 19, 55, 5, 296, DateTimeKind.Local).AddTicks(5674));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 21, 19, 55, 5, 298, DateTimeKind.Local).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 21, 19, 55, 5, 298, DateTimeKind.Local).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 21, 19, 55, 5, 298, DateTimeKind.Local).AddTicks(595));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 21, 19, 55, 5, 298, DateTimeKind.Local).AddTicks(1894));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 21, 19, 55, 5, 298, DateTimeKind.Local).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 21, 19, 55, 5, 298, DateTimeKind.Local).AddTicks(2033));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2021, 10, 21, 19, 55, 5, 298, DateTimeKind.Local).AddTicks(2070));

            migrationBuilder.CreateIndex(
                name: "IX_LpmUserMasters_BranchId",
                table: "LpmUserMasters",
                column: "BranchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LpmUserMasters_UserRoleId",
                table: "LpmUserMasters",
                column: "UserRoleId",
                unique: true);
        }
    }
}
