using System.Collections.Generic;

namespace MP_NewSystem.Models
{
    public class SalesTeam : Team
    {
        public IList<EmployeeInfo> TeamMembers { get; set; }
    }
}
