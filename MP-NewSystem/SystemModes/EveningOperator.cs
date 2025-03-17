using MP_NewSystem.Helper;
using MP_NewSystem.Interfaces;
using MP_NewSystem.Models;
using MP_NewSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MP_NewSystem.SystemModes
{
    public class EveningOperator : SystemOperator
    {
        public EveningOperator(IBikeApiClient bikeApiClient, ICSVReader csvReader, LogWriter logWriter, IOperations operations) 
                        : base(bikeApiClient, csvReader, logWriter, operations)
        { }

        public override void Operate()
        {
            ApiResult apiResult = _BikeApiClient.GetStationInformation();
            if (!apiResult.Successful)
            {
                Console.WriteLine(apiResult.ErrorMessage);
                throw new MPException("Failed to fetch Bikes Stations...");
            }

            List<SalesTeam > teams = _operations.FormTeams();
            StartWork(teams, apiResult.root.Data.Stations);
        }

       
        public void StartWork(List<SalesTeam > teams, List<Station> stations)
        {
            foreach (var team in teams)
            {
                SalesTeam  teamWithoutDriver = team;
                //Driver
                EmployeeInfo driver = team.TeamMembers.Where(x => x.IsDriver()).FirstOrDefault();
                if(driver!= null) {

                }

                //Sales Team
                teamWithoutDriver.TeamMembers = teamWithoutDriver.TeamMembers.Where(tm => !tm.IsDriver()).ToList();
                GeoLocation geoLocation = new GeoLocation()
                {
                    Latitude = team.Lat,
                    Longitude = team.Long
                };

                //Compute Nearest Point...
                Station nearestStation = _operations.GetNearestStation(geoLocation, stations);
                //nearestStation.Capacity = new Random().Next(1, 10);
                if (nearestStation != null)
                {
                    if (nearestStation.Capacity < teamWithoutDriver.TeamMembers.Count())
                    {
                        //Get Years of Experience
                        SalesTeam sortedByExp = SortBasedOnYearsOfExperience(teamWithoutDriver);
                        int teamSize =  sortedByExp.TeamMembers.Count();
                        Queue<EmployeeInfo> employeesQueue = CreateQueue(sortedByExp);
                        
                        while (teamSize > 0)
                        {
                            int sizeToTake = nearestStation.Capacity < teamSize ? nearestStation.Capacity : teamSize;
                            List<EmployeeInfo> employeeBatch = new List<EmployeeInfo>();
                            while(sizeToTake != 0) {
                                EmployeeInfo e = employeesQueue.Peek();
                                employeeBatch.Add(e);
                                employeesQueue.Dequeue();
                                teamSize--;
                                sizeToTake--;
                            }

                            AssignTeamToStation(employeeBatch, nearestStation);
                            //Remove the current Station for the search range
                            stations = ExcludeStation(stations, nearestStation);
                            nearestStation = _operations.GetNearestStation(geoLocation, stations);
                            //nearestStation.Capacity = new Random().Next(1,10);
                        }
                    }
                    else
                    {
                        AssignTeamToStation(teamWithoutDriver, nearestStation);
                    }
                }               
            }
        }
        public void AssignTeamToStation(List<EmployeeInfo> teamMembers, Station station)
        {
            _logWriter.WriteLogTeam(teamMembers, station);
        }
        public void AssignTeamToStation(SalesTeam team, Station station)
        {
            _logWriter.WriteLogTeam(team,station);
        }

        private List<Station> ExcludeStation(List<Station> stations, Station usedStation)
        {
            stations.Remove(usedStation);
            return stations;
        }

        private Queue<EmployeeInfo> CreateQueue(SalesTeam salesTeam)
        {
            Queue<EmployeeInfo> employeesQueue = new Queue<EmployeeInfo>();
            for (int i = 0; i < salesTeam.TeamMembers.Count(); i++)
                employeesQueue.Enqueue(salesTeam.TeamMembers[i]);
            return employeesQueue;
        }

        private SalesTeam SortBasedOnYearsOfExperience(SalesTeam team)
        {
            SalesTeam salesTeam = team;
            salesTeam.TeamMembers = salesTeam.TeamMembers.OrderBy(x => DateTime.Now.Year - DateTime.Parse(x.StartedOn).Year).ToList();
            return salesTeam;
        }
    }
}
