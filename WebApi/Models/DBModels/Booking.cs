using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.Enums;

namespace WebApi.Models.DBModels;

/// <summary>
/// 保養預約資料
/// </summary>
public class Booking
{
    /// <summary>
    /// 預定編號
    /// </summary>
    [Key]
    [Comment("預定編號")]
    public int Id { get; set; }

    /// <summary>
    /// 員工編號
    /// </summary>
    [Comment("員工編號")]
    public int EmployeeId { get; set; }

    /// <summary>
    /// 車輛編號
    /// </summary>
    [Comment("車輛編號")]
    public int VehicleId { get; set; }

    /// <summary>
    /// 預定日期
    /// </summary>
    [Comment("預定日期")]
    public DateTime BookingDate { get; set; }
    
    /// <summary>
    /// 預定狀態
    /// </summary>
    [Comment("預定狀態")]
    public BookingStatus Status { get; set; }

    /// <summary>
    /// 員工資訊
    /// </summary>
    public Employee Employee { get; set; }

    /// <summary>
    /// 車輛資訊
    /// </summary>
    public Vehicle Vehicle { get; set; }
}

