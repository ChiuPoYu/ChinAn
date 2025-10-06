using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Vehicle
{
    public string PlateNumber { get; set; } = null!;

    public string? Model { get; set; }

    public int? CurrentMileage { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? CreateBy { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public DateTime? UpdateBy { get; set; }

    public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

    public virtual Customer? User { get; set; }
}
