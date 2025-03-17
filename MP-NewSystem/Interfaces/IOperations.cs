using MP_NewSystem.Models;
using System.Collections.Generic;

namespace MP_NewSystem.Interfaces
{
    public interface IOperations
    {
        List<SalesTeam> FormTeams();
        Station GetNearestStation(GeoLocation startLocation,List<Station> allStations,int TeamSize);
        Station GetNearestStation(GeoLocation startLocation,List<Station> allStations);
    }
}
