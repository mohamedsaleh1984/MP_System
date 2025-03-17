using CsvHelper;
using CsvHelper.Configuration;
using MP_NewSystem.Helper;
using MP_NewSystem.Interfaces;
using MP_NewSystem.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;

namespace MP_NewSystem.Services
{
    public class CSVFileLogService : LogWriter
    {
        private readonly string reportFileName = "System-Output.csv";
        public override void WriteLog(LogEntry entry)
        {
            if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), reportFileName)))
            {
                using (var writer = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), reportFileName)))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<LogEntryMap>();
                    csv.WriteHeader<LogEntry>();
                    csv.NextRecord();
                }
            }

            using (var writer = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), reportFileName),true)) 
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<LogEntryMap>();
                csv.WriteRecord(entry);
                csv.NextRecord();
            }
        }

        public override void WriteLogEmployee(EmployeeInfo employeeInfo, Station station)
        {
            string strMessage = GenerateMessage(employeeInfo, station);
            LogEntry logEntry = new LogEntry()
            {
                Employee = employeeInfo.Employee,
                ID = employeeInfo.ID,
                Message = strMessage,
                Role = employeeInfo.Role,
                StartedOn = employeeInfo.StartedOn,
                Team = employeeInfo.Team
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
