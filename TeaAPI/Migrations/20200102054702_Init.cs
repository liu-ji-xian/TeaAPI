using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeaAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    GId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GNo = table.Column<string>(nullable: true),
                    GoodsPicture = table.Column<string>(nullable: true),
                    GName = table.Column<string>(nullable: true),
                    GPrice = table.Column<float>(nullable: false),
                    GNum = table.Column<int>(nullable: false),
                    GRemark = table.Column<string>(nullable: true),
                    GType = table.Column<int>(nullable: false),
                    GState = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.GId);
                });

            migrationBuilder.CreateTable(
                name: "GoodsType",
                columns: table => new
                {
                    GTId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GTName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsType", x => x.GTId);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Mid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Mid);
                });

            migrationBuilder.CreateTable(
                name: "OrderInfo",
                columns: table => new
                {
                    OIId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OINode = table.Column<string>(nullable: true),
                    GNos = table.Column<string>(nullable: true),
                    GNum = table.Column<int>(nullable: false),
                    Gremark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInfo", x => x.OIId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ONo = table.Column<string>(nullable: true),
                    OName = table.Column<string>(nullable: true),
                    OPhone = table.Column<string>(nullable: true),
                    Oaddress = table.Column<string>(nullable: true),
                    UIds = table.Column<string>(nullable: true),
                    OStartTime = table.Column<DateTime>(nullable: false),
                    OendTime = table.Column<DateTime>(nullable: false),
                    Ostate = table.Column<string>(nullable: true),
                    Omoney = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingTrolley",
                columns: table => new
                {
                    SIId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GTNum = table.Column<int>(nullable: false),
                    GNos = table.Column<string>(nullable: true),
                    UNos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingTrolley", x => x.SIId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UNo = table.Column<string>(nullable: true),
                    UName = table.Column<string>(nullable: true),
                    URealName = table.Column<string>(nullable: true),
                    Ubirthday = table.Column<DateTime>(nullable: false),
                    UType = table.Column<string>(nullable: true),
                    UPass = table.Column<string>(nullable: true),
                    ConsigneeName = table.Column<string>(nullable: true),
                    ConsigneePhone = table.Column<string>(nullable: true),
                    ConsigneeAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "GoodsType");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "OrderInfo");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ShoppingTrolley");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
