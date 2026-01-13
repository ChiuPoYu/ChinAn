using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.DBModels;

public partial class Customer
{
    /// <summary>
    /// 客戶編號 (PK)
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// 客戶姓名
    /// </summary>
    [MaxLength(50)]
    [Comment("客戶姓名")]
    public string? Name { get; set; }

    /// <summary>
    /// 客戶電話
    /// </summary>
    [MaxLength(20)]
    [Comment("客戶電話")]
    public string? Phone { get; set; }

    /// <summary>
    /// 客戶地址
    /// </summary>
    [MaxLength(100)]
    [Comment("客戶地址")]
    public string? Email { get; set; }

    /// <summary>
    /// 建立日期
    /// </summary>
    public DateTime? CreateDateTime { get; set; }

    /// <summary>
    /// 建立人
    /// </summary>
    public DateTime? CreateBy { get; set; }

    /// <summary>
    /// 更新日期
    /// </summary>
    public DateTime? UpdateDateTime { get; set; }

    /// <summary>
    /// 更新人
    /// </summary>
    public DateTime? UpdateBy { get; set; }

    /// <summary>
    /// 保養紀錄
    /// </summary>
    public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

    /// <summary>
    /// 車輛資訊
    /// </summary>
    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
