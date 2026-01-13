using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace WebApi.Models.DBModels;

public partial class MaintenanceItem
{
    /// <summary>
    /// 維修項目 ID (FK MaintenanceRecord.Id)
    /// </summary>
    [Comment("維修紀錄 ID")]
    public int RecordId { get; set; }

    /// <summary>
    /// 維修項目 ID (FK Product.Id)
    /// </summary>
    [Comment("維修項目 ID")]
    public int ItemId { get; set; }

    /// <summary>
    /// 維修項目名稱
    /// </summary>
    [Comment("維修項目名稱")]
    public string? ItemName { get; set; }

    /// <summary>
    /// 數量
    /// </summary>
    [Comment("數量")]
    public int Amount { get; set; }

    /// <summary>
    /// 定價
    /// </summary>
    [Comment("定價")]
    public int Price { get; set; }

    /// <summary>
    /// 總價
    /// </summary>
    [Comment("總價")]
    public int? Cost { get; set; }

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
    
    ///<summary>
    /// 維修記錄
    /// </summary>
    public virtual MaintenanceRecord Record { get; set; }

    /// <summary>
    /// 商品資料
    /// </summary>
    public virtual Product Product { get; set; } = null!;
}
