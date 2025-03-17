using MP_NewSystem.Models;
using System.Collections.Generic;

namespace MP_NewSystem.Services
{
    public interface ICSVReader
    {
        List<EmployeeInfo> GetEmployeesInformation();
        List<Team> GetTeamsLocation();
    }
}
