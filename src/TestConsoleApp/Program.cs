using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Eurdep.NET;
using Eurdep.NET.Format.v2_1;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var coord1 = new GeoCoordinate(50.1, 2.35689);
            var coord2 = new GeoCoordinate(-10.87, -197);
            var coord3 = new GeoCoordinate("N50.2", "E2.345");
            var coord4 = new GeoCoordinate("E50.2", "W-180");

            //var list = new List<Locality>();
            //list.Add(new Locality()
            //{
            //    LocalityCode = "BE01",
            //    LocalityName = "Loc1",
            //    Coordinates = new GeoCoordinate(50.456, 2.1)
            //});
            //list.Add(new Locality()
            //{
            //    LocalityCode = "BE02",
            //    LocalityName = "Loc2",
            //    Coordinates = new GeoCoordinate(50.456, 2.1),
            //    HeightAboveSea = 5
            //});

            //var file = new EurdepV21File();
            //file.LocalityList = list;
            //file.BuildFile();
        }
    }
}
