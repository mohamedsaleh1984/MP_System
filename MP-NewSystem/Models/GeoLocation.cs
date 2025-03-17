namespace MP_NewSystem.Models
{
    public class GeoLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public override string ToString()
        {
            return $"GeoLocation lat:{Latitude}, Long:{Longitude}";
        }
    }
}
