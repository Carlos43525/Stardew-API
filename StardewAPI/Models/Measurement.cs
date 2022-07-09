namespace StardewAPI.Models
{
    public class Measurement
    {
        public int Id { get; set; }
        public int ReportingDeviceId { get; set; }
        public int MeasurementTypeId { get; set; }
        public decimal MeasuredValue { get; set; }
        public DateTime MeasurementDate { get; set; }
    }
}
