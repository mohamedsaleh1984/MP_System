using MP_NewSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP_NewSystem.Helper
{
    /// <summary>
    /// Common Functionaloties 
    /// </summary>
    public class Utilities
    {
        /// <summary>
        /// Compute the distance between two points based on raw lat, long values.
        /// </summary>
        /// <param name="lat1"></param>
        /// <param name="long1"></param>
        /// <param name="lat2"></param>
        /// <param name="long2"></param>
        /// <returns></returns>
        public static double Distance(double lat1, double long1, double lat2, double long2)
        {
            return Math.Sqrt(Math.Pow(lat1 - lat2, 2) + Math.Pow(long1 - long2, 2));
        }

        /// <summary>
        /// Compute the distance between two points based on GeoLocation
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static double Distance(GeoLocation from, GeoLocation to)
        {
            return Math.Sqrt(Math.Pow(from.Latitude - to.Latitude, 2) + Math.Pow(from.Longitude - to.Longitude, 2));
        }
    }
}
