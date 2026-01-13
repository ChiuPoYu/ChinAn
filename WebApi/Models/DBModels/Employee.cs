using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models.DBModels;

/// <summary>
/// 員工資料
/// 包含員工基本資訊及其負責的預約
/// </summary>
public class Employee
{
    /// <summary>
    /// 員工編號
    /// </summary>
    [Key]
    [Comment("員工編號")]
    public int Id { get; set; }

    /// <summary>
    /// 員工姓名
    /// </summary>
    [MaxLength(50)]
    [Comment("員工姓名")]
    public string Name { get; set; }

    /// <summary>
    /// 員工電話
    /// </summary>
    [MaxLength(20)]
    [Comment("員工電話")]
    public string Phone { get; set; }

    public ICollection<Booking> AssignedBookings { get; set; }
}