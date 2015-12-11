using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurdep.NET
{
    public class GeoCoordinate
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public string LatitudeDecimalDisplay
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (this.Latitude > 0)
                    sb.Append("N");
                else
                    sb.Append("S");

                sb.Append(Math.Abs(this.Latitude).ToString("00.0000"));

                return sb.ToString().Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".");
            }
        }

        public string LongitudeDecimalDisplay
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (this.Longitude > 0)
                    sb.Append("E");
                else
                    sb.Append("W");

                sb.Append(Math.Abs(this.Longitude).ToString("000.0000"));

                return sb.ToString().Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".");
            }
        }

        public GeoCoordinate(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", Latitude, Longitude);
        }
    }
}
