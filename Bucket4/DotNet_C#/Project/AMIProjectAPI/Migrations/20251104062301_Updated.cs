using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMIProjectAPI.Migrations
{
    /// <inheritdoc />
    public partial class Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrgUnit",
                columns: table => new
                {
                    OrgUnitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Substation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Feeder = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DTR = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrgUnit__4A793B8E52AAD40D", x => x.OrgUnitID);
                });

            migrationBuilder.CreateTable(
                name: "Tariff",
                columns: table => new
                {
                    TariffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TariffName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EffectiveFrom = table.Column<DateOnly>(type: "date", nullable: false),
                    EffectiveTo = table.Column<DateOnly>(type: "date", nullable: true),
                    BaseRate = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tariff__EBAF9D9318D8DF06", x => x.TariffID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Active")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CCAC216BFCFA", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Consumer",
                columns: table => new
                {
                    ConsumerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TariffId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, defaultValue: "Active"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: false, defaultValueSql: "(sysutcdatetime())"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "admin"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Consumer__63BBE99A68520A2C", x => x.ConsumerID);
                    table.ForeignKey(
                        name: "FK__Consumer__Tariff__3864608B",
                        column: x => x.TariffId,
                        principalTable: "Tariff",
                        principalColumn: "TariffID");
                });

            migrationBuilder.CreateTable(
                name: "TariffSlab",
                columns: table => new
                {
                    SlabId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TariffID = table.Column<int>(type: "int", nullable: false),
                    FromKwh = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ToKwh = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    RatePerKwh = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TariffSl__D6169921146B4B55", x => x.SlabId);
                    table.ForeignKey(
                        name: "FK__TariffSla__Tarif__3493CFA7",
                        column: x => x.TariffID,
                        principalTable: "Tariff",
                        principalColumn: "TariffID");
                });

            migrationBuilder.CreateTable(
                name: "ConsumerLogin",
                columns: table => new
                {
                    ConsumerLoginID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumerID = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Active")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Consumer__E6D708D7971BF8D5", x => x.ConsumerLoginID);
                    table.ForeignKey(
                        name: "FK__ConsumerL__Consu__5D95E53A",
                        column: x => x.ConsumerID,
                        principalTable: "Consumer",
                        principalColumn: "ConsumerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meter",
                columns: table => new
                {
                    MeterSerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ConsumerID = table.Column<int>(type: "int", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ICCID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IMSI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Firmware = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrgUnitId = table.Column<int>(type: "int", nullable: false),
                    InstallDate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, defaultValue: "Active")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Meter__5C498B0F61327F6F", x => x.MeterSerialNo);
                    table.ForeignKey(
                        name: "FK__Meter__ConsumerI__40058253",
                        column: x => x.ConsumerID,
                        principalTable: "Consumer",
                        principalColumn: "ConsumerID");
                    table.ForeignKey(
                        name: "FK__Meter__OrgUnitId__41EDCAC5",
                        column: x => x.OrgUnitId,
                        principalTable: "OrgUnit",
                        principalColumn: "OrgUnitID");
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    BillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeterID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MonthStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MonthlyConsumptionkWh = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BaseRate = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SlabRate = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Pending"),
                    GeneratedAt = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: false, defaultValueSql: "(sysutcdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bill__11F2FC4A01285CBF", x => x.BillID);
                    table.ForeignKey(
                        name: "FK__Bill__MeterID__4C6B5938",
                        column: x => x.MeterID,
                        principalTable: "Meter",
                        principalColumn: "MeterSerialNo");
                });

            migrationBuilder.CreateTable(
                name: "DailyConsumption",
                columns: table => new
                {
                    MeterID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ConsumptionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ConsumptionkWh = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__DailyCons__Meter__45BE5BA9",
                        column: x => x.MeterID,
                        principalTable: "Meter",
                        principalColumn: "MeterSerialNo");
                });

            migrationBuilder.CreateTable(
                name: "MonthlyConsumption",
                columns: table => new
                {
                    MeterID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MonthStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ConsumptionkWh = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyConsumption", x => new { x.MeterID, x.MonthStartDate });
                    table.ForeignKey(
                        name: "FK__MonthlyCo__Meter__489AC854",
                        column: x => x.MeterID,
                        principalTable: "Meter",
                        principalColumn: "MeterSerialNo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_MeterID",
                table: "Bill",
                column: "MeterID");

            migrationBuilder.CreateIndex(
                name: "IX_Consumer_TariffId",
                table: "Consumer",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "UQ__Consumer__536C85E4CE88D471",
                table: "ConsumerLogin",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Consumer__63BBE99B15E0A00D",
                table: "ConsumerLogin",
                column: "ConsumerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyConsumption_MeterID",
                table: "DailyConsumption",
                column: "MeterID");

            migrationBuilder.CreateIndex(
                name: "IX_Meter_ConsumerID",
                table: "Meter",
                column: "ConsumerID");

            migrationBuilder.CreateIndex(
                name: "IX_Meter_OrgUnitId",
                table: "Meter",
                column: "OrgUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffSlab_TariffID",
                table: "TariffSlab",
                column: "TariffID");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__536C85E42780D375",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "ConsumerLogin");

            migrationBuilder.DropTable(
                name: "DailyConsumption");

            migrationBuilder.DropTable(
                name: "MonthlyConsumption");

            migrationBuilder.DropTable(
                name: "TariffSlab");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Meter");

            migrationBuilder.DropTable(
                name: "Consumer");

            migrationBuilder.DropTable(
                name: "OrgUnit");

            migrationBuilder.DropTable(
                name: "Tariff");
        }
    }
}
