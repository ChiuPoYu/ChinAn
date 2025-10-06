using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class MaintenanceRecord
{
    public int Id { get; set; }

    public string? PlateNumber { get; set; }

    public int? UserId { get; set; }

    public DateOnly? Date { get; set; }

    public int? Mileage { get; set; }

    public string? MaintenanceItems { get; set; }

    public string? Description { get; set; }

    public int? Cost { get; set; }

    public string? Technician { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? CreateBy { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public DateTime? UpdateBy { get; set; }

    public virtual Vehicle? PlateNumberNavigation { get; set; }

    public virtual Customer? User { get; set; }
}
