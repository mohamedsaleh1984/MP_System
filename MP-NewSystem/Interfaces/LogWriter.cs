using MP_NewSystem.Helper;
using MP_NewSystem.Models;
using System.Collections.Generic;

namespace MP_NewSystem.Interfaces
{
    public abstract class LogWriter
    {
        public abstract void WriteLog(LogEntry entry);
        public abstract void WriteLogTeam(SalesTeam team, Station station);
        public abstract void WriteLogTeam(List<EmployeeInfo> team, Station station);
        public abstract void WriteLogEmployee(EmployeeInfo employee, Station station);
        public string GenerateMessage(EmployeeInfo e, Station station)
        {
            if (e == null)
                return "";

            string message = "";

            if (GlobalAppSettings.IsMorning())
            {
                if (e.IsDriver())
                {
                    message = $"Good Morning {e.Employee}, Your destination for this morning will be the {station.Name} station";
                }

                if (e.IsLeader())
                {
                    message = $"Good Morning {e.Employee}, You are assigned to Team Number {e.Team} Van today";
                }
                else
                {
                    message = $"Good Morning {e.Employee}, Your CitiBike will be at the {station} station";
                }
            }
            
            if (GlobalAppSettings.IsEvening())
            {
                if (!e.IsDriver())
                {
                    message = $"Good evening {e.Employee}, Please proceed to the ({station.Name} station) for pickup.";

                }

                if (e.IsDriver())
                {
                    message = $"Good evening {e.Employee}, Your first pickup this evening is at the ({station.Name} station)";
                }
            }

            if (GlobalAppSettings.IsAfternoon())
            {
                if (!e.IsDriver())
                {
                    message = $"Good afternoon {e.Employee}, We are at {station.Name} station.";

                }

                if (e.IsDriver())
                {
                    message = $"Good Afternoon {e.Employee}, You need to drive towards {station.Name} station";
                }
            }
            return message;
        }
    }
}
