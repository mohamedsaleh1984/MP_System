namespace MP_NewSystem.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public override string ToString()
        {
            return $"Team {TeamID} ({Lat},{Long})";
        }
    }
}
