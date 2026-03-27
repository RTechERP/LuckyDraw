using System;
using System.Collections.Generic;

namespace LuckyDraw.Models;

public partial class Customer
{
    public int ID { get; set; }

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? EmailAdress { get; set; }

    public string? Company { get; set; }

    /// <summary>
    /// Giải pháp quản lý kho thông minh/Smart Warehouse Solutions
    /// </summary>
    public bool? SmartWarehouseSolutions { get; set; }

    /// <summary>
    /// Giải pháp xử lý ảnh công nghiệp Machine Vision/Machine Vision Industrial Image Processing Solutions
    /// </summary>
    public bool? MachineVisionSolutions { get; set; }

    public bool? AGVnAMRSolutions { get; set; }

    public bool? AutomaticMachineManufacturingSolutions { get; set; }

    public bool? AutomationEquipmentinProduction { get; set; }

    public bool? IoTSolutions { get; set; }

    public bool? OtherSolutions { get; set; }

    public bool? MailChannel { get; set; }

    public bool? WebsiteChannel { get; set; }

    public bool? FacebookChannel { get; set; }

    public bool? PartnersChannel { get; set; }

    public bool? OtherChannel { get; set; }

    public int? LuckyNumber { get; set; }

    public int? YearValue { get; set; }

    public int? GameScore { get; set; }

    public bool? IsPlayedGame { get; set; }

    public DateTime? TimeStartGame { get; set; }

    public DateTime? TimeEndGame { get; set; }

    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    /// 1:Nam; 2: Nữ; 3: Khác
    /// </summary>
    public int? Gender { get; set; }
}
