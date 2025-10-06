using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? CreateBy { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public DateTime? UpdateBy { get; set; }

    public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
