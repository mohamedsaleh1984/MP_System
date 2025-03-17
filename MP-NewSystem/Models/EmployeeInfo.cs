using System;

namespace MP_NewSystem.Models
{
    public class EmployeeInfo 
    {
        public int ID { get; set; }
        public int Team { get; set; }
        public string Employee { get; set; }
        public string Role { get; set; }
        public string StartedOn { get; set; }
        public bool IsDriver()
        {
            return this.Role.Equals("Driver");
        }
        public bool IsLeader()
        {
            return this.Role.Equals("Leader");
        }
        public bool NotDriverNorLeader()
        {
            return !this.IsDriver() || !this.IsLeader();
        }

        public override string ToString()
        {
            string strToReturn = $"{ID} {Employee} {Role} {StartedOn}";
            return strToReturn;
        }

    }

}
