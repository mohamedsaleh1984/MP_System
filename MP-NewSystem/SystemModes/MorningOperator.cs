using MP_NewSystem.Helper;
using MP_NewSystem.Interfaces;
using MP_NewSystem.Models;
using MP_NewSystem.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MP_NewSystem.SystemModes
{
    public class MorningOperator:SystemOperator
    {
        public MorningOperator(IBikeApiClient bikeApiClient, ICSVReader csvReader, LogWriter logWriter, IOperations operations)
                        : base(bikeApiClient, csvReader, logWriter, operations) { }
        public override void Operate()
        {
            ApiResult apiResult = _BikeApiClient.GetStationInformation();
            if (!apiResult.Successful)
            {
                Console.WriteLine(apiResult.ErrorMessage);
                throw new MPException("Failed to fetch Bikes Stations...");
            }

            List<SalesTeam> teams = _operations.FormTeams();

            StartWork(teams, apiResult.root.Data.Stations);
        }
        public void StartWork(List<SalesTeam> teams, List<Station> stations)
        {
            foreach (var team in teams)
            {
                SalesTeam teamWithoutDriver = team;

                //Remove Driver from the team...
                teamWithoutDriver.TeamMembers = teamWithoutDriver.TeamMembers.Where(tm => !tm.IsDriver()).ToList();

                int teamSize = teamWithoutDriver.TeamMembers.Count();

                //Assuming the center of sales area is what we fetched from the csv file.
                GeoLocation geoLocation = new GeoLocation()
                {
                    Latitude = team.Lat,
                    Longitude = team.Long
                };

                //Compute Nearest Point...
                Station nearestStation = _operations.GetNearestStation(geoLocation, stations, teamSize);
                if(nearestStation != null)
                {
                    AssignTeamToStation(teamWithoutDriver, nearestStation);
                    //Notify Driver
                    EmployeeInfo driver = team.TeamMembers.Where(x => x.IsDriver()).FirstOrDefault();
                    if (driver != null)
                    {
                        _logWriter.WriteLogEmployee(driver, nearestStation);
                    }
                }
            }
        }

        public void AssignTeamToStation(SalesTeam team, Station station)
        {
            _logWriter.WriteLogTeam(team,station);
        }
    }
}
