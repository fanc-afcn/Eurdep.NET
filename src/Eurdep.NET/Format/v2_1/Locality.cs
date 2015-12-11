namespace Eurdep.NET.Format.v2_1
{
    public class Locality
    {
        public string LocalityName { get; set; }
        public string LocalityCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int? HeightAboveLand { get; set; }
        public int? HeightAboveSea { get; set; }
        public string Nuts { get; set; }
    }
}
