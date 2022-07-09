using StardewAPI.Models;

namespace StardewAPI.Services
{
    public static class DataService
    {
        // DataService.cs is an in-memory repository for saving data temporarily during development. 
        // The class seeds to values in the constructor and provides a few HTTP methods. 
        static List<Measurement> Measurements { get; }
        static int nextId = 3;

        static DataService()
        {
            Measurements = new List<Measurement>
            {
                new Measurement { Id = 1, ReportingDeviceId = 1, MeasuredValue = 12.5M, MeasurementDate = DateTime.Now  }, 
                new Measurement { Id = 2, ReportingDeviceId = 1, MeasuredValue = 0.88M, MeasurementDate = DateTime.Now  },
            };
        }

        public static List<Measurement> GetAll() => Measurements;

        public static Measurement? Get(int id) => Measurements.FirstOrDefault(m => m.Id == id);

        public static void AddMeasurement(decimal value)
        {
            var measurement = new Measurement(); 

            measurement.Id = nextId++;
            measurement.ReportingDeviceId = 1;
            measurement.MeasuredValue = value;
            measurement.MeasurementDate = DateTime.Now;
            Measurements.Add(measurement);
        }

        public static void DeleteMeasurement(int id)
        {
            var measurement = Get(id);
            if (measurement is null)
                return;
            Measurements.Remove(measurement); 
        }
    }
}
