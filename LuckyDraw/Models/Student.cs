using System;
using System.Collections.Generic;

namespace LuckyDraw.Models;

public partial class Student
{
    public int ID { get; set; }

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? SchoolYear { get; set; }

    /// <summary>
    /// Công nghệ kỹ thuật cơ điện tử
    /// </summary>
    public bool? MechatronicsEngineeringTechnology { get; set; }

    /// <summary>
    /// Công nghệ kỹ thuật cơ khí
    /// </summary>
    public bool? MechanicalEngineeringTechnology { get; set; }

    /// <summary>
    /// Công nghệ kỹ thuật điện tử - viễn thông
    /// </summary>
    public bool? ElectronicsandTelecommunicationsEngineeringTechnology { get; set; }

    /// <summary>
    /// Công nghệ kỹ thuật điện, điện tử
    /// </summary>
    public bool? ElectricalandElectronicsEngineeringTechnology { get; set; }

    /// <summary>
    /// Công nghệ kỹ thuật điều khiển và tự động hóa
    /// </summary>
    public bool? ControlandAutomationEngineeringTechnology { get; set; }

    /// <summary>
    /// Công nghệ kỹ thuật hóa học
    /// </summary>
    public bool? ChemicalEngineeringTechnology { get; set; }

    /// <summary>
    /// Công nghệ kỹ thuật nhiệt
    /// </summary>
    public bool? ThermalEngineeringTechnology { get; set; }

    /// <summary>
    /// Công nghệ kỹ thuật ô tô
    /// </summary>
    public bool? AutomotiveEngineeringTechnology { get; set; }

    /// <summary>
    /// Hệ thống thông tin
    /// </summary>
    public bool? InformationSystems { get; set; }

    /// <summary>
    /// Kế toán
    /// </summary>
    public bool? Accounting { get; set; }

    /// <summary>
    /// Khoa học máy tính
    /// </summary>
    public bool? ComputerScience { get; set; }

    /// <summary>
    /// Kỹ thuật phần mềm
    /// </summary>
    public bool? SoftwareEngineering { get; set; }

    /// <summary>
    /// Ngôn ngữ Anh
    /// </summary>
    public bool? EnglishLanguage { get; set; }

    /// <summary>
    /// Quản trị kinh doanh
    /// </summary>
    public bool? BusinessAdministration { get; set; }

    /// <summary>
    /// Tài chính - Ngân hàng
    /// </summary>
    public bool? FinanceandBanking { get; set; }

    public bool? OtherMajor { get; set; }

    public int? LuckyNumber { get; set; }

    public int? YearValue { get; set; }

    /// <summary>
    /// 1.MechatronicsEngineeringTechnology; 2.MechanicalEngineeringTechnology	
    /// 3. ElectronicsandTelecommunicationsEngineeringTechnology	
    /// 4. ElectricalandElectronicsEngineeringTechnology	
    /// 5. ControlandAutomationEngineeringTechnology	
    /// 6. ChemicalEngineeringTechnology	
    /// 7. ThermalEngineeringTechnology	
    /// 8. AutomotiveEngineeringTechnology	
    /// 9. InformationSystems
    /// 10. Accounting	
    /// 11. ComputerScience
    /// 12. SoftwareEngineering	
    /// 13. EnglishLanguage	
    /// 14. BusinessAdministration	
    /// 15. FinanceandBanking	
    /// 16. OtherMajor
    /// </summary>
    public int? Major { get; set; }
}
