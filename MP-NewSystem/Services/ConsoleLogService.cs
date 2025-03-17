using CsvHelper;
using MP_NewSystem.Helper;
using MP_NewSystem.Interfaces;
using MP_NewSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_NewSystem.Services
{
    public class ConsoleLogService : LogWriter
    {
        public override void WriteLog(LogEntry entry)
        {
            Console.WriteLine(entry.Message);
        }
        public override void WriteLogEmployee(EmployeeInfo e, Station station)
        {
            string strMessage = GenerateMessage(e, station);
            LogEntry logEntry = new LogEntry()
            {
                Employee = e.Employee,
                ID = e.ID,
                Message = strMessage,
                Role = e.Role,
                StartedOn = e.StartedOn,
                Team = e.Team
            };
            WriteLog(logEntry);
        }

        public override void WriteLogTeam(SalesTeam team, Station station)
        {
            foreach (var e in team.TeamMembers.ToList())
            {
                WriteLogEmployee(e, station);
            }
        }

        public override void WriteLogTeam(List<EmployeeInfo> team, Station station)
        {
            foreach (var e in team)
            {
                WriteLogEmployee(e, station);
            }
        }
    }
}
