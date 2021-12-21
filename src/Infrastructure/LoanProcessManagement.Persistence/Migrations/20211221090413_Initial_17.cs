using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanProcessManagement.Persistence.Migrations
{
    public partial class Initial_17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lpmAgencyMasters",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyName = table.Column<string>(nullable: true),
                    Agency_type = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lpmAgencyMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lpmLeadHoSanctionQueries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lead_Id = table.Column<long>(nullable: true),
                    Query_Status = table.Column<string>(nullable: false),
                    HoSanction_query_comment = table.Column<string>(nullable: true),
                    HoSanction_query_commentResponse = table.Column<string>(nullable: true),
                    Query_Date = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lpmLeadHoSanctionQueries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lpmLeadHoSanctionQueries_LpmLeadMasters_lead_Id",
                        column: x => x.lead_Id,
                        principalTable: "LpmLeadMasters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "lpmThirdPartyCheckDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lead_Id = table.Column<long>(nullable: true),
                    valuerAgencyId = table.Column<long>(nullable: true),
                    ValuerDocumentOut_Date = table.Column<DateTime>(nullable: false),
                    ValuerDocumentIn_Date = table.Column<DateTime>(nullable: false),
                    valuerAgencyDocuments = table.Column<string>(nullable: false),
                    valuerAgencyComment = table.Column<string>(nullable: true),
                    valuerAgencyStatus = table.Column<int>(nullable: false),
                    legalAgencyId = table.Column<long>(nullable: true),
                    LegalDocumentOut_Date = table.Column<DateTime>(nullable: false),
                    LegalDocumentIn_Date = table.Column<DateTime>(nullable: false),
                    legalAgencyDocuments = table.Column<string>(nullable: false),
                    legalAgencyComment = table.Column<string>(nullable: true),
                    legalAgencyStatus = table.Column<int>(nullable: false),
                    fiAgencyId = table.Column<long>(nullable: true),
                    fiDocumentOut_Date = table.Column<DateTime>(nullable: false),
                    fiDocumentIn_Date = table.Column<DateTime>(nullable: false),
                    fiAgencyDocuments = table.Column<string>(nullable: false),
                    fiAgencyComment = table.Column<string>(nullable: true),
                    fiAgencyStatus = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lpmThirdPartyCheckDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lpmThirdPartyCheckDetails_lpmAgencyMasters_fiAgencyId",
                        column: x => x.fiAgencyId,
                        principalTable: "lpmAgencyMasters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_lpmThirdPartyCheckDetails_LpmLeadMasters_lead_Id",
                        column: x => x.lead_Id,
                        principalTable: "LpmLeadMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lpmThirdPartyCheckDetails_lpmAgencyMasters_legalAgencyId",
                        column: x => x.legalAgencyId,
                        principalTable: "lpmAgencyMasters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_lpmThirdPartyCheckDetails_lpmAgencyMasters_valuerAgencyId",
                        column: x => x.valuerAgencyId,
                        principalTable: "lpmAgencyMasters",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 10, 21, 14, 34, 12, 447, DateTimeKind.Local).AddTicks(4849));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 9, 21, 14, 34, 12, 447, DateTimeKind.Local).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2022, 4, 21, 14, 34, 12, 447, DateTimeKind.Local).AddTicks(4782));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 8, 21, 14, 34, 12, 447, DateTimeKind.Local).AddTicks(4926));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2022, 4, 21, 14, 34, 12, 447, DateTimeKind.Local).AddTicks(4704));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2022, 6, 21, 14, 34, 12, 444, DateTimeKind.Local).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 21, 14, 34, 12, 447, DateTimeKind.Local).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 21, 14, 34, 12, 447, DateTimeKind.Local).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 21, 14, 34, 12, 447, DateTimeKind.Local).AddTicks(7674));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 21, 14, 34, 12, 447, DateTimeKind.Local).AddTicks(9576));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 21, 14, 34, 12, 447, DateTimeKind.Local).AddTicks(9975));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 21, 14, 34, 12, 447, DateTimeKind.Local).AddTicks(9847));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 21, 14, 34, 12, 447, DateTimeKind.Local).AddTicks(9919));

            migrationBuilder.CreateIndex(
                name: "IX_lpmLeadHoSanctionQueries_lead_Id",
                table: "lpmLeadHoSanctionQueries",
                column: "lead_Id");

            migrationBuilder.CreateIndex(
                name: "IX_lpmThirdPartyCheckDetails_fiAgencyId",
                table: "lpmThirdPartyCheckDetails",
                column: "fiAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_lpmThirdPartyCheckDetails_lead_Id",
                table: "lpmThirdPartyCheckDetails",
                column: "lead_Id",
                unique: true,
                filter: "[lead_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_lpmThirdPartyCheckDetails_legalAgencyId",
                table: "lpmThirdPartyCheckDetails",
                column: "legalAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_lpmThirdPartyCheckDetails_valuerAgencyId",
                table: "lpmThirdPartyCheckDetails",
                column: "valuerAgencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lpmLeadHoSanctionQueries");

            migrationBuilder.DropTable(
                name: "lpmThirdPartyCheckDetails");

            migrationBuilder.DropTable(
                name: "lpmAgencyMasters");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 10, 17, 14, 30, 30, 723, DateTimeKind.Local).AddTicks(8563));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 9, 17, 14, 30, 30, 723, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2022, 4, 17, 14, 30, 30, 723, DateTimeKind.Local).AddTicks(8539));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 8, 17, 14, 30, 30, 723, DateTimeKind.Local).AddTicks(8588));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2022, 4, 17, 14, 30, 30, 723, DateTimeKind.Local).AddTicks(8512));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2022, 6, 17, 14, 30, 30, 722, DateTimeKind.Local).AddTicks(9871));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 17, 14, 30, 30, 723, DateTimeKind.Local).AddTicks(9859));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 17, 14, 30, 30, 723, DateTimeKind.Local).AddTicks(9839));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 17, 14, 30, 30, 723, DateTimeKind.Local).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 17, 14, 30, 30, 723, DateTimeKind.Local).AddTicks(9793));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 17, 14, 30, 30, 723, DateTimeKind.Local).AddTicks(9913));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 17, 14, 30, 30, 723, DateTimeKind.Local).AddTicks(9877));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2021, 12, 17, 14, 30, 30, 723, DateTimeKind.Local).AddTicks(9896));
        }
    }
}
