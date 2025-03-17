using CsvHelper;
using MP_NewSystem.Helper;
using MP_NewSystem.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace MP_NewSystem.Services
{
    public class CSVReaderService : ICSVReader
    {
        private readonly string _teamsFileName = "Teams.csv";
        private readonly string _teamsLocationFileName = "teamslatlong.csv";

        /// <summary>
        /// Read Employee Info from the csv file.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MPException"></exception>
        public List<EmployeeInfo> GetEmployeesInformation()
        {
            if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), _teamsFileName))){
                throw new MPException("Please copy Teams.csv from StaticFiles to exe file directory.");
            }

            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), _teamsFileName)))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<EmployeeInfo>().ToList();
            }
        }

        /// <summary>
        /// Read Team info from csv file.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MPException"></exception>
        public List<Team> GetTeamsLocation()
        {
            if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), _teamsFileName))){
                throw new MPException("Please copy teamslatlong.csv from StaticFiles to exe file directory.");
            }

            using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), _teamsLocationFileName)))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Team>().ToList();
            }
        }
    }
}
