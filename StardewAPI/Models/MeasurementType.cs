namespace StardewAPI.Models
{
    public class MeasurementType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Measurement> Measurements { get; set; }
    }
}
