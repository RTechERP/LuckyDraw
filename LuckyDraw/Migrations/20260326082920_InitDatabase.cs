using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuckyDraw.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    EmailAdress = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmartWarehouseSolutions = table.Column<bool>(type: "bit", nullable: true, comment: "Giải pháp quản lý kho thông minh/Smart Warehouse Solutions"),
                    MachineVisionSolutions = table.Column<bool>(type: "bit", nullable: true, comment: "Giải pháp xử lý ảnh công nghiệp Machine Vision/Machine Vision Industrial Image Processing Solutions"),
                    AGVnAMRSolutions = table.Column<bool>(type: "bit", nullable: true),
                    AutomaticMachineManufacturingSolutions = table.Column<bool>(type: "bit", nullable: true),
                    AutomationEquipmentinProduction = table.Column<bool>(type: "bit", nullable: true),
                    IoTSolutions = table.Column<bool>(type: "bit", nullable: true),
                    OtherSolutions = table.Column<bool>(type: "bit", nullable: true),
                    MailChannel = table.Column<bool>(type: "bit", nullable: true),
                    WebsiteChannel = table.Column<bool>(type: "bit", nullable: true),
                    FacebookChannel = table.Column<bool>(type: "bit", nullable: true),
                    PartnersChannel = table.Column<bool>(type: "bit", nullable: true),
                    OtherChannel = table.Column<bool>(type: "bit", nullable: true),
                    LuckyNumber = table.Column<int>(type: "int", nullable: true),
                    YearValue = table.Column<int>(type: "int", nullable: true),
                    GameScore = table.Column<int>(type: "int", nullable: true),
                    IsPlayedGame = table.Column<bool>(type: "bit", nullable: true),
                    TimeStartGame = table.Column<DateTime>(type: "datetime", nullable: true),
                    TimeEndGame = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Prize",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrizeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuckyNumber = table.Column<int>(type: "int", nullable: true),
                    YearValue = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prize", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PrizeStudent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrizeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LuckyNumber = table.Column<int>(type: "int", nullable: true),
                    YearValue = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrizeStudent", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    SchoolYear = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MechatronicsEngineeringTechnology = table.Column<bool>(type: "bit", nullable: true, comment: "Công nghệ kỹ thuật cơ điện tử"),
                    MechanicalEngineeringTechnology = table.Column<bool>(type: "bit", nullable: true, comment: "Công nghệ kỹ thuật cơ khí"),
                    ElectronicsandTelecommunicationsEngineeringTechnology = table.Column<bool>(type: "bit", nullable: true, comment: "Công nghệ kỹ thuật điện tử - viễn thông"),
                    ElectricalandElectronicsEngineeringTechnology = table.Column<bool>(type: "bit", nullable: true, comment: "Công nghệ kỹ thuật điện, điện tử"),
                    ControlandAutomationEngineeringTechnology = table.Column<bool>(type: "bit", nullable: true, comment: "Công nghệ kỹ thuật điều khiển và tự động hóa"),
                    ChemicalEngineeringTechnology = table.Column<bool>(type: "bit", nullable: true, comment: "Công nghệ kỹ thuật hóa học"),
                    ThermalEngineeringTechnology = table.Column<bool>(type: "bit", nullable: true, comment: "Công nghệ kỹ thuật nhiệt"),
                    AutomotiveEngineeringTechnology = table.Column<bool>(type: "bit", nullable: true, comment: "Công nghệ kỹ thuật ô tô"),
                    InformationSystems = table.Column<bool>(type: "bit", nullable: true, comment: "Hệ thống thông tin"),
                    Accounting = table.Column<bool>(type: "bit", nullable: true, comment: "Kế toán"),
                    ComputerScience = table.Column<bool>(type: "bit", nullable: true, comment: "Khoa học máy tính"),
                    SoftwareEngineering = table.Column<bool>(type: "bit", nullable: true, comment: "Kỹ thuật phần mềm"),
                    EnglishLanguage = table.Column<bool>(type: "bit", nullable: true, comment: "Ngôn ngữ Anh"),
                    BusinessAdministration = table.Column<bool>(type: "bit", nullable: true, comment: "Quản trị kinh doanh"),
                    FinanceandBanking = table.Column<bool>(type: "bit", nullable: true, comment: "Tài chính - Ngân hàng"),
                    OtherMajor = table.Column<bool>(type: "bit", nullable: true),
                    LuckyNumber = table.Column<int>(type: "int", nullable: true),
                    YearValue = table.Column<int>(type: "int", nullable: true),
                    Major = table.Column<int>(type: "int", nullable: true, comment: "1.MechatronicsEngineeringTechnology; 2.MechanicalEngineeringTechnology	\r\n3. ElectronicsandTelecommunicationsEngineeringTechnology	\r\n4. ElectricalandElectronicsEngineeringTechnology	\r\n5. ControlandAutomationEngineeringTechnology	\r\n6. ChemicalEngineeringTechnology	\r\n7. ThermalEngineeringTechnology	\r\n8. AutomotiveEngineeringTechnology	\r\n9. InformationSystems\r\n10. Accounting	\r\n11. ComputerScience\r\n12. SoftwareEngineering	\r\n13. EnglishLanguage	\r\n14. BusinessAdministration	\r\n15. FinanceandBanking	\r\n16. OtherMajor")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "unique_Phone_Year_Customer",
                table: "Customer",
                columns: new[] { "PhoneNumber", "YearValue", "LuckyNumber" },
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL AND [YearValue] IS NOT NULL AND [LuckyNumber] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Prize");

            migrationBuilder.DropTable(
                name: "PrizeStudent");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
