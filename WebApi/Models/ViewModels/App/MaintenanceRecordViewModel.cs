using WebApi.Models.DBModels;

namespace WebApi.Models.ViewModels.App
{
    public class MaintenanceRecordViewModel
    {
        public required int VehicleId { get; set; }
        public required DateOnly Date { get; set; }
        public required int Mileage { get; set; }
        public required ICollection<MaintenanceItem> MaintenanceItems { get; set; }
        public required string Description { get; set; }
        public required int Cost { get; set; }
        public string? Technician { get; set; }
    }
}
