using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Eurdep.NET;
using Eurdep.NET.Format.v2_1;
using Eurdep.NET.Format.v2_1.Enums;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var header = new Header();
            var localities = new List<LocalityItem>();
            var radiologicals = new List<RadiologicalItem>();

            header.Originator = "FANC";
            header.Carrier = Carrier.FTP;
            header.Importance = Importance.NORMAL;
            header.CountryCode = "BE";
            header.MessageId = Guid.NewGuid().ToString();
        
            localities.Add(new LocalityItem()
            {
                LocalityCode = "BE01",
                LocalityName = "Loc1",
                Coordinates = new GeoCoordinate(50.456, 2.1)
            });
            localities.Add(new LocalityItem()
            {
                LocalityCode = "BE02",
                LocalityName = "Loc2",
                Coordinates = new GeoCoordinate(50.456, 2.1),
                HeightAboveSea = 5
            });

            radiologicals.Add(new RadiologicalItem()
            {
                LocalityCode = "BE01",
                BeginDateUTC = new DateTime(2015,1,1,0,0,0, DateTimeKind.Utc),
                EndDateUTC = new DateTime(2015,1,1,1,0,0, DateTimeKind.Utc),
                Nuclide = Nuclide.T_GAMMA,
                SampleType = SampleType.A,
                Unit = MeasuringUnit.USV_H,
                Value = 0.55
            });
            radiologicals.Add(new RadiologicalItem()
            {
                LocalityCode = "BE02",
                BeginDateUTC = new DateTime(2015, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                EndDateUTC = new DateTime(2015, 1, 1, 1, 0, 0, DateTimeKind.Utc),
                Nuclide = Nuclide.T_GAMMA,
                SampleType = SampleType.A,
                Unit = MeasuringUnit.USV_H,
                Value = 0.76
            });

            var file = new EurdepFile();
            file.Header = header;
            file.LocalityItemList = localities;
            file.RadiologicalItemList = radiologicals;
            var sb = file.BuildFile();
            var str = sb.ToString();
        }
    }
}
