using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanProcessManagement.Persistence.Migrations
{
    public partial class Initial_12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LpmLeadQuerys",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    lead_Id = table.Column<long>(nullable: false),
                    Query_Status = table.Column<string>(nullable: false),
                    FormNo = table.Column<string>(nullable: true),
                    Query_Comment = table.Column<string>(nullable: true),
                    Query_Date = table.Column<DateTime>(nullable: false),
                    Tat = table.Column<int>(nullable: true),
                    IPSQueryType1 = table.Column<string>(nullable: true),
                    IPSQueryType2 = table.Column<string>(nullable: true),
                    IPSQueryType3 = table.Column<string>(nullable: true),
                    IPSQueryType4 = table.Column<string>(nullable: true),
                    IPSQueryType5 = table.Column<string>(nullable: true),
                    IPSQueryType_Comment = table.Column<string>(nullable: true),
                    IPSResponseType1 = table.Column<string>(nullable: true),
                    IPSResponseType2 = table.Column<string>(nullable: true),
                    IPSResponseType3 = table.Column<string>(nullable: true),
                    IPSResponseType4 = table.Column<string>(nullable: true),
                    IPSResponseType5 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LpmLeadQuerys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LpmLeadQuerys_LpmLeadMasters_lead_Id",
                        column: x => x.lead_Id,
                        principalTable: "LpmLeadMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 9, 19, 13, 49, 3, 671, DateTimeKind.Local).AddTicks(3751));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 8, 19, 13, 49, 3, 671, DateTimeKind.Local).AddTicks(3520));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2022, 3, 19, 13, 49, 3, 671, DateTimeKind.Local).AddTicks(3712));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 7, 19, 13, 49, 3, 671, DateTimeKind.Local).AddTicks(3792));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2022, 3, 19, 13, 49, 3, 671, DateTimeKind.Local).AddTicks(3666));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2022, 5, 19, 13, 49, 3, 669, DateTimeKind.Local).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 19, 13, 49, 3, 671, DateTimeKind.Local).AddTicks(6538));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 19, 13, 49, 3, 671, DateTimeKind.Local).AddTicks(6503));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 19, 13, 49, 3, 671, DateTimeKind.Local).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 19, 13, 49, 3, 671, DateTimeKind.Local).AddTicks(6437));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 19, 13, 49, 3, 671, DateTimeKind.Local).AddTicks(6721));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 19, 13, 49, 3, 671, DateTimeKind.Local).AddTicks(6571));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 19, 13, 49, 3, 671, DateTimeKind.Local).AddTicks(6605));

            migrationBuilder.CreateIndex(
                name: "IX_LpmLeadQuerys_lead_Id",
                table: "LpmLeadQuerys",
                column: "lead_Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LpmLeadQuerys");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 9, 19, 12, 5, 11, 836, DateTimeKind.Local).AddTicks(6559));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 8, 19, 12, 5, 11, 836, DateTimeKind.Local).AddTicks(6220));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2022, 3, 19, 12, 5, 11, 836, DateTimeKind.Local).AddTicks(6501));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 7, 19, 12, 5, 11, 836, DateTimeKind.Local).AddTicks(6625));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2022, 3, 19, 12, 5, 11, 836, DateTimeKind.Local).AddTicks(6436));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2022, 5, 19, 12, 5, 11, 834, DateTimeKind.Local).AddTicks(9294));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 19, 12, 5, 11, 837, DateTimeKind.Local).AddTicks(1087));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 19, 12, 5, 11, 837, DateTimeKind.Local).AddTicks(1024));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 19, 12, 5, 11, 836, DateTimeKind.Local).AddTicks(9107));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 19, 12, 5, 11, 837, DateTimeKind.Local).AddTicks(903));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 19, 12, 5, 11, 837, DateTimeKind.Local).AddTicks(1270));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 19, 12, 5, 11, 837, DateTimeKind.Local).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 19, 12, 5, 11, 837, DateTimeKind.Local).AddTicks(1211));
        }
    }
}
