using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.DBModels;

public class Vehicle
{
    /// <summary>
    /// 車牌號碼
    /// </summary>
    [Key]
    [MaxLength(10)]
    [Comment("車牌號碼")]
    public string PlateNumber { get; set; } = null!;

    /// <summary>
    /// 車型
    /// </summary>
    [Comment("車型")]
    public string? Model { get; set; }

    /// <summary>
    /// 當前里程數
    /// </summary>
    [Comment("當前里程數")]
    public int? CurrentMileage { get; set; }

    /// <summary>
    /// 使用者 ID
    /// </summary>
    [Comment("使用者 ID")]
    public int? CustomerId { get; set; }

    /// <summary>
    /// 建立時間
    /// </summary>
    [Comment("建立時間")]
    public DateTime? CreateDateTime { get; set; }

    /// <summary>
    /// 建立者
    /// </summary>
    [Comment("建立者")]
    public DateTime? CreateBy { get; set; }

    /// <summary>
    /// 更新時間
    /// </summary>
    [Comment("更新時間")]
    public DateTime? UpdateDateTime { get; set; }

    /// <summary>
    /// 更新者
    /// </summary>
    [Comment("更新者")]
    public DateTime? UpdateBy { get; set; }

    /// <summary>
    /// 維修記錄集合
    /// </summary>
    [Comment("維修記錄集合")]
    public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

    /// <summary>
    /// 使用者
    /// </summary>
    [Comment("使用者")]
    public virtual Customer? Customer { get; set; }
}
