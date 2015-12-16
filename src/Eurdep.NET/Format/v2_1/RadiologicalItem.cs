using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eurdep.NET.Format.v2_1.Enums;

namespace Eurdep.NET.Format.v2_1
{
    public class RadiologicalItem
    {
        //MANDATORY

        public GeoCoordinate Coordinates { get; set; }

        [EurdepField("LOCALITY_CODE", true, 1)]
        public string LocalityCode { get; set; }

        [EurdepField("BEGIN", true, 2)]
        public DateTime BeginDateUTC { get; set; }

        [EurdepField("END", true, 3)]
        public DateTime EndDateUTC { get; set; }


        //mandatory but is already set in locality
        [EurdepField("LATITUDE", false, 4)]
        public string Latitude
        {
            get
            {
                if (this.Coordinates != null)
                    return Coordinates.Latitude;

                return null;
            }
            set
            {
                if (this.Coordinates == null)
                    this.Coordinates = new GeoCoordinate();

                this.Coordinates.Latitude = value;
            }
        }

        //mandatory but is already set in locality
        [EurdepField("LONGITUDE", false, 5)]
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

        [EurdepField("NUCLIDE", true, 6)]
        public Nuclide Nuclide { get; set; }

        [EurdepField("SAMPLE_TYPE", true, 7)]
        public SampleType SampleType { get; set; }

        [EurdepField("UNIT", true, 8)]
        public MeasuringUnit Unit { get; set; }

        [EurdepField("VALUE", true, 9)]
        public double Value { get; set; }

        //RECOMMENDED

        [EurdepField("APPARATUS", false, 10)]
        public ApparatusType Apparatus { get; set; }

        [EurdepField("NUTS", false, 11)]
        public string Nuts { get; set; }

        [EurdepField("SAMPLE_TREATMENT", false, 12)]
        public SampleTreatment SampleTreatment { get; set; }

        [EurdepField("UNCERTAINTY", false, 13)]
        public double? Uncertainty { get; set; }

        [EurdepField("UNCERTAINTY_TYPE", false, 14)]
        public UncertaintyType UncertaintyType { get; set; }

        [EurdepField("UNCERTAINTY_UNIT", false, 15)]
        public MeasuringUnit UncertaintyUnit { get; set; }

        [EurdepField("VALUE_CONSTRAINT", false, 16)]
        public Constraint ValueConstraint { get; set; }

        //OPTIONAL



    }
}
