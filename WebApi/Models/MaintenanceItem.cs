using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class MaintenanceItem
{
    public int ItemId { get; set; }

    public string? ItemName { get; set; }

    public int? Price { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? CreateBy { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public DateTime? UpdateBy { get; set; }
}
