using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Eurdep.NET;
using Eurdep.NET.Format.v2_1;
using Eurdep.NET.Format.v2_1.Constants;

namespace TestConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await TestRead();
            //await TestWrite();
        }

        private static async Task TestRead()
        {
            using (var fs = new FileStream(@"D:\Dev\EurdepSampleFiles\NL201712041510-A11.EUR", FileMode.Open))
            {
                var eurdepFile = EurdepFile.ReadFromStream(fs);
            }
        }

        private static async Task TestWrite()
        {
            var header = new Header();
            var localities = new List<LocalityItem>();
            var radiologicals = new List<RadiologicalItem>();

            header.Originator = "FANC";
            header.Carrier = "FTP";
            header.Importance = "NORMAL";
            header.CountryCode = "BE";
            header.MessageId = Guid.NewGuid().ToString();
            header.SentUTC = DateTime.UtcNow;

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

            for (int i = 1; i <= 1; i++) //change to test different file sizes
            {
                radiologicals.Add(new RadiologicalItem()
                {
                    LocalityCode = "BE01",
                    BeginDateUTC = new DateTime(2015, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    EndDateUTC = new DateTime(2015, 1, 1, 1, 0, 0, DateTimeKind.Utc),
                    Nuclide = Nuclides.T_GAMMA,
                    SampleType = SampleTypes.A,
                    Unit = MeasuringUnits.USV_H,
                    Value = 0.55
                });
                radiologicals.Add(new RadiologicalItem()
                {
                    LocalityCode = "BE02",
                    BeginDateUTC = new DateTime(2015, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    EndDateUTC = new DateTime(2015, 1, 1, 1, 0, 0, DateTimeKind.Utc),
                    Nuclide = Nuclides.T_GAMMA,
                    SampleType = SampleTypes.A,
                    Unit = MeasuringUnits.USV_H,
                    Value = 0.76
                });
            }

            var file = new EurdepFile();
            file.Header = header;
            file.LocalityItemList = localities;
            file.RadiologicalItemList = radiologicals;

            using (var fs = new FileStream(@"D:\eurdeptest.txt", FileMode.Create))
            {
                await file.WriteToStreamAsync(fs);
            }
        }
    }
}
