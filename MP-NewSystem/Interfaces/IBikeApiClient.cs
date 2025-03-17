using MP_NewSystem.Models;

namespace MP_NewSystem.Interfaces
{
    public interface IBikeApiClient
    {
        ApiResult GetStationInformation();
        ApiResult GetStationStatus();
    }
}
