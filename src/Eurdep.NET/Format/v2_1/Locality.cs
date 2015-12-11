namespace Eurdep.NET.Format.v2_1
{
    public class Locality
    {
        
        [EurdepField("LOCALITY_CODE", true, 1)]
        public string LocalityCode { get; set; }

        [EurdepField("LOCALITY_NAME", true, 2)]
        public string LocalityName { get; set; }

        [EurdepField("LATITUDE", true, 3)]
        public string Latitude
        {
            get
            {
                if(this.Coordinates != null)
                    return Coordinates.LatitudeDecimalDisplay;

                return null;
            }
        }

        [EurdepField("LONGITUDE", true, 4)]
        public string Longitude 
        {
            get
            {
                if (this.Coordinates != null)
                    return this.Coordinates.LongitudeDecimalDisplay;

                return null;
            }
        }

        [EurdepField("HEIGHT_ABOVE_LAND", false, 5)]
        public int? HeightAboveLand { get; set; }

        [EurdepField("HEIGHT_ABOVE_SEA", false, 6)]
        public int? HeightAboveSea { get; set; }

        [EurdepField("NUTS", false, 7)]
        public string Nuts { get; set; }

        public GeoCoordinate Coordinates { get; set; }
    }
}
