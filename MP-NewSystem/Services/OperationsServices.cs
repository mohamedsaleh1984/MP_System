using MP_NewSystem.Helper;
using MP_NewSystem.Interfaces;
using MP_NewSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MP_NewSystem.Services
{
    public class OperationsServices : IOperations
    {
        private readonly ICSVReader _csvReader;
        public OperationsServices(ICSVReader cSVReader)
        {
            _csvReader = cSVReader;
        }
        public List<SalesTeam> FormTeams()
        {
            //Fetch Employee Information
            List<EmployeeInfo> emps = _csvReader.GetEmployeesInformation();
            //Fetch Teams Locations
            List<Team> teams = _csvReader.GetTeamsLocation();

            return teams.GroupJoin(emps,
                                     team => team.TeamID,
                                     emp => emp.Team,
                                     (team, teamMembers) => new SalesTeam()
                                     {
                                         TeamMembers = teamMembers.ToList(),
                                         TeamID = team.TeamID,
                                         Lat = team.Lat,
                                         Long = team.Long,
                                     }).ToList();
        }

        /// <summary>
        /// Get the neared station to given position.
        /// </summary>
        /// <param name="startLocation"></param>
        /// <param name="allStations"></param>
        /// <param name="TeamSize"></param>
        /// <returns></returns>
        /// <exception cref="MPException"></exception>
        public Station GetNearestStation(GeoLocation startLocation,
                                           List<Station> allStations,
                                           int TeamSize)
        {
            if (allStations.Count == 0)
                throw new MPException("There is no stations...");

            if (TeamSize == 0)
                throw new MPException("Team size must be greater than zero...");

            //filter 
            allStations = allStations.Where(stat => stat.Capacity >= TeamSize).ToList();

            if (allStations.Count == 0)
            {
                Console.WriteLine("No Bikes available for the team size.");
                return null;
            }

            //Compute the nearest station...
            PriorityQueue<Station, double> queue = new();

            foreach (var station in allStations)
            {
                GeoLocation geoLocation = new()
                {
                    Latitude = station.Lat,
                    Longitude = station.Lon
                };

                double computedDistance = Utilities.Distance(startLocation, geoLocation);
                queue.Enqueue(station, computedDistance);
            }

            Station closestStation = queue.Dequeue();
            return closestStation;
        }

        /// <summary>
        /// Get the nearest station to the current location
        /// </summary>
        /// <param name="startLocation"></param>
        /// <param name="allStations"></param>
        /// <returns></returns>
        public Station GetNearestStation(GeoLocation startLocation, List<Station> allStations)
        {
            PriorityQueue<Station, double> queue = new();

            foreach (var station in allStations)
            {
                GeoLocation geoLocation = new()
                {
                    Latitude = station.Lat,
                    Longitude = station.Lon
                };

                double computedDistance = Utilities.Distance(startLocation, geoLocation);
                queue.Enqueue(station, computedDistance);
            }

            Station closestStation = queue.Dequeue();
            return closestStation;
        }
    }
}
