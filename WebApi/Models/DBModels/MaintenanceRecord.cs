using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.DBModels;

public class MaintenanceRecord
{
    /// <summary>
    /// 維修記錄 ID
    /// </summary>
    [Comment("維修記錄 ID")]
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// 技術人員 編號 (FK Employee.Id)
    /// </summary>
    [Comment("技術人員 編號")]
    public int? EmployeeId { get; set; }

    /// <summary>
    /// 車輛編號 (FK Vehicle.Id)
    /// </summary>
    [Comment("車輛編號")]
    public int VehicleId { get; set; }

    /// <summary>
    /// 客戶 ID (FK Customer.Id)
    /// </summary>
    [Comment("客戶 ID")]
    public int CustomerId { get; set; }

    /// <summary>
    /// 維修日期
    /// </summary>
    [Comment("維修日期")]
    public DateOnly? Date { get; set; }

    /// <summary>
    /// 當前里程數
    /// </summary>
    [Comment("當前里程數")]
    public int Mileage { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    [Comment("描述")]
    public string? Description { get; set; }

    /// <summary>
    /// 本次維修總費用
    /// </summary>
    [Comment("本次維修總費用")]
    public int TotalCost { get; set; }

    /// <summary>
    /// 建立時間
    /// </summary>
    [Comment("建立時間")]
    public DateTime CreateDateTime { get; set; }

    /// <summary>
    /// 建立者
    /// </summary>
    [Comment("建立者")]
    public DateTime CreateBy { get; set; }

    /// <summary>
    /// 更新時間
    /// </summary>
    [Comment("更新時間")]
    public DateTime UpdateDateTime { get; set; }

    /// <summary>
    /// 更新者
    /// </summary>
    [Comment("更新者")]
    public DateTime UpdateBy { get; set; }

    /// <summary>
    /// 車輛資訊
    /// </summary>
    public Vehicle Vehicle { get; set; }

    /// <summary>
    /// 技術人員資訊
    /// </summary>
    public Employee Employee { get; set; }

    /// <summary>
    /// 維修項目集合
    /// </summary>
    public ICollection<MaintenanceItem> MaintenanceItems { get; set; } = new List<MaintenanceItem>();
}
