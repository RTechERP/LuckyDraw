using System;
using System.Collections.Generic;
using LuckyDraw.Models;
using Microsoft.EntityFrameworkCore;

namespace LuckyDraw.Models.Context;

public partial class IndustryExhibitionRTCContext : DbContext
{
    public IndustryExhibitionRTCContext(DbContextOptions<IndustryExhibitionRTCContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Prize> Prizes { get; set; }

    public virtual DbSet<PrizeStudent> PrizeStudents { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.HasIndex(e => new { e.PhoneNumber, e.YearValue, e.LuckyNumber }, "unique_Phone_Year_Customer").IsUnique();

            entity.Property(e => e.EmailAdress).IsUnicode(false);
            entity.Property(e => e.MachineVisionSolutions).HasComment("Giải pháp xử lý ảnh công nghiệp Machine Vision/Machine Vision Industrial Image Processing Solutions");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.SmartWarehouseSolutions).HasComment("Giải pháp quản lý kho thông minh/Smart Warehouse Solutions");
            entity.Property(e => e.TimeEndGame).HasColumnType("datetime");
            entity.Property(e => e.TimeStartGame).HasColumnType("datetime");
        });

        modelBuilder.Entity<Prize>(entity =>
        {
            entity.ToTable("Prize");
        });

        modelBuilder.Entity<PrizeStudent>(entity =>
        {
            entity.ToTable("PrizeStudent");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.Accounting).HasComment("Kế toán");
            entity.Property(e => e.AutomotiveEngineeringTechnology).HasComment("Công nghệ kỹ thuật ô tô");
            entity.Property(e => e.BusinessAdministration).HasComment("Quản trị kinh doanh");
            entity.Property(e => e.ChemicalEngineeringTechnology).HasComment("Công nghệ kỹ thuật hóa học");
            entity.Property(e => e.ComputerScience).HasComment("Khoa học máy tính");
            entity.Property(e => e.ControlandAutomationEngineeringTechnology).HasComment("Công nghệ kỹ thuật điều khiển và tự động hóa");
            entity.Property(e => e.ElectricalandElectronicsEngineeringTechnology).HasComment("Công nghệ kỹ thuật điện, điện tử");
            entity.Property(e => e.ElectronicsandTelecommunicationsEngineeringTechnology).HasComment("Công nghệ kỹ thuật điện tử - viễn thông");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.EnglishLanguage).HasComment("Ngôn ngữ Anh");
            entity.Property(e => e.FinanceandBanking).HasComment("Tài chính - Ngân hàng");
            entity.Property(e => e.FullName).HasMaxLength(550);
            entity.Property(e => e.InformationSystems).HasComment("Hệ thống thông tin");
            entity.Property(e => e.Major).HasComment("1.MechatronicsEngineeringTechnology; 2.MechanicalEngineeringTechnology	\r\n3. ElectronicsandTelecommunicationsEngineeringTechnology	\r\n4. ElectricalandElectronicsEngineeringTechnology	\r\n5. ControlandAutomationEngineeringTechnology	\r\n6. ChemicalEngineeringTechnology	\r\n7. ThermalEngineeringTechnology	\r\n8. AutomotiveEngineeringTechnology	\r\n9. InformationSystems\r\n10. Accounting	\r\n11. ComputerScience\r\n12. SoftwareEngineering	\r\n13. EnglishLanguage	\r\n14. BusinessAdministration	\r\n15. FinanceandBanking	\r\n16. OtherMajor");
            entity.Property(e => e.MechanicalEngineeringTechnology).HasComment("Công nghệ kỹ thuật cơ khí");
            entity.Property(e => e.MechatronicsEngineeringTechnology).HasComment("Công nghệ kỹ thuật cơ điện tử");
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.SchoolYear)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SoftwareEngineering).HasComment("Kỹ thuật phần mềm");
            entity.Property(e => e.ThermalEngineeringTechnology).HasComment("Công nghệ kỹ thuật nhiệt");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
