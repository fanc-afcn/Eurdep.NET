namespace Eurdep.NET.Format.v2_1
{
    /// <summary>
    /// Represents the EURDEP structure of the "LOCALITY" section
    /// </summary>
    public class LocalityItem
    {
        public GeoCoordinate Coordinates { get; set; }

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
                    return Coordinates.Latitude;

                return null;
            }
            set
            {
                if(this.Coordinates == null)
                    this.Coordinates = new GeoCoordinate();

                this.Coordinates.Latitude = value;
            }
        }

        [EurdepField("LONGITUDE", true, 4)]
        public string Longitude 
        {
            get
            {
                if (this.Coordinates != null)
                    return this.Coordinates.Longitude;

                return null;
            }
            set
            {
                if (this.Coordinates == null)
                    this.Coordinates = new GeoCoordinate();

                this.Coordinates.Longitude = value;
            }
        }

        [EurdepField("HEIGHT_ABOVE_LAND", false, 5)]
        public int? HeightAboveLand { get; set; }

        [EurdepField("HEIGHT_ABOVE_SEA", false, 6)]
        public int? HeightAboveSea { get; set; }

        [EurdepField("NUTS", false, 7)]
        public string Nuts { get; set; }
    }
}
