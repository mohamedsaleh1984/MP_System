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
    public class AfternoonOperator : SystemOperator
    {
        public AfternoonOperator(IBikeApiClient bikeApiClient, ICSVReader csvReader, LogWriter logWriter, IOperations operations)
                        : base(bikeApiClient, csvReader, logWriter, operations) { }
        public override void Operate()
        {
            throw new MPException("NOT Implement yet");
        }
        public void StartWork(List<SalesTeam> teams, List<Station> stations)
        {
            throw new MPException("NOT Implement yet");
        }

        public void AssignTeamToStation(SalesTeam team, Station station)
        {
            throw new MPException("NOT Implement yet");
        }
    }
}
