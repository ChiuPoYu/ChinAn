namespace WebApi.Models.DtoModels
{
    public class MaintenanceRecordDto
    {
        public required string PlateNumber { get; set; }
        public required int UserId { get; set; }
        public required DateOnly Date { get; set; }
        public required int Mileage { get; set; }
        public required string MaintenanceItems { get; set; }
        public required string Description { get; set; }
        public required int Cost { get; set; }
        public string? Technician { get; set; }
    }
}
