using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurdep.NET
{
    public class GeoCoordinate
    {
        private double latDbl;
        private double lonDbl;

        public Exception LatitudeException { get; private set; }
        public Exception LongitudeException { get; private set; }

        public bool IsValid
        {
            get { return (this.LatitudeException == null && this.LongitudeException == null); }
        }

        public double LatitudeDbl
        {
            get { return this.latDbl; }

            set
            {
                this.LatitudeException = null;

                if (value >= -90 && value <= 90)
                    this.latDbl = value;
                else
                    this.LatitudeException = new Exception("Value is out of valid range (-90 to 90)");
            }
        }

        public double LongitudeDbl
        {
            get { return this.lonDbl; }

            set
            {
                this.LongitudeException = null;

                if (value >= -180 && value <= 180)
                    this.lonDbl = value;
                else
                    this.LongitudeException = new Exception("Value is out of valid range (-180 to 180)");
            }
        }

        public string Latitude
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (this.LatitudeDbl > 0)
                    sb.Append("N");
                else
                    sb.Append("S");

                sb.Append(Math.Abs(this.LatitudeDbl).ToString("00.0000"));

                return sb.ToString().Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".");
            }
            set
            {
                this.LatitudeException = null;

                string cleanSource = value
                    .Replace(".", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
                    .Replace(",", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);

                int factor = 1;

                if (String.IsNullOrWhiteSpace(cleanSource))
                    this.LatitudeException = new Exception("NULL or empty string");
                else
                {
                    if (cleanSource.StartsWith("N", true, CultureInfo.CurrentCulture))
                        factor = 1;
                    else if (cleanSource.StartsWith("S", true, CultureInfo.CurrentCulture))
                        factor = -1;
                    else
                        this.LatitudeException = new Exception("Invalid first character");
                }

                double result;
                Double.TryParse(cleanSource.Substring(1), out result);
                result *= factor;

                this.LatitudeDbl = result;
            }
        }

        public string Longitude
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (this.LongitudeDbl > 0)
                    sb.Append("E");
                else
                    sb.Append("W");

                sb.Append(Math.Abs(this.LongitudeDbl).ToString("000.0000"));

                return sb.ToString().Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".");
            }
            set
            {
                this.LongitudeException = null;

                string cleanSource = value
                    .Replace(".", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
                    .Replace(",", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);

                int factor = 1;

                if (String.IsNullOrWhiteSpace(cleanSource))
                    this.LongitudeException = new Exception("NULL or empty string");
                else
                {
                    if (cleanSource.StartsWith("E", true, CultureInfo.CurrentCulture))
                        factor = 1;
                    else if (cleanSource.StartsWith("W", true, CultureInfo.CurrentCulture))
                        factor = -1;
                    else
                        this.LongitudeException = new Exception("Invalid first character");
                }

                double result;
                Double.TryParse(cleanSource.Substring(1), out result);
                result *= factor;

                this.LongitudeDbl = result;
            }
        }

        public GeoCoordinate()
        {
            
        }

        public GeoCoordinate(double latitude, double longitude)
        {
            this.LatitudeDbl = latitude;
            this.LongitudeDbl = longitude;
        }

        public GeoCoordinate(string latitude, string longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", LatitudeDbl, LongitudeDbl);
        }
    }
}
