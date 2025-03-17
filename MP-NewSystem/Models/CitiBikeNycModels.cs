using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP_NewSystem.Models
{
    public class Root
    {
        [JsonProperty("data")]
        public Data Data;

        [JsonProperty("last_updated")]
        public int LastUpdated;

        [JsonProperty("ttl")]
        public int Ttl;
    }

    public class Station
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("short_name")]
        public string ShortName;

        [JsonProperty("lon")]
        public double Lon;

        [JsonProperty("eightd_station_services")]
        public List<object> EightdStationServices;

        [JsonProperty("rental_methods")]
        public List<string> RentalMethods;

        [JsonProperty("region_id")]
        public string RegionId;

        [JsonProperty("lat")]
        public double Lat;

        [JsonProperty("rental_uris")]
        public RentalUris RentalUris;

        [JsonProperty("has_kiosk")]
        public bool HasKiosk;

        [JsonProperty("station_type")]
        public string StationType;

        [JsonProperty("station_id")]
        public string StationId;

        [JsonProperty("capacity")]
        public int Capacity;

        [JsonProperty("legacy_id")]
        public string LegacyId;

        [JsonProperty("electric_bike_surcharge_waiver")]
        public bool ElectricBikeSurchargeWaiver;

        [JsonProperty("external_id")]
        public string ExternalId;

        [JsonProperty("eightd_has_key_dispenser")]
        public bool EightdHasKeyDispenser;


        public override string ToString()
        {
            string strStation = $"Station {ShortName} : ({Lon},{Lat})";
            return strStation;
        }
    }

    public class Data
    {
        [JsonProperty("stations")]
        public List<Station> Stations;
    }

    public class RentalUris
    {
        [JsonProperty("android")]
        public string Android;

        [JsonProperty("ios")]
        public string Ios;
    }
}
