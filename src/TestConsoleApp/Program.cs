using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            var list = new List<Locality>();
            list.Add(new Locality()
            {
                LocalityCode = "BE01",
                LocalityName = "Loc1",
                Coordinates = new GeoCoordinate(50.456, 2.1)
            });
            list.Add(new Locality()
            {
                LocalityCode = "BE02",
                LocalityName = "Loc2",
                Coordinates = new GeoCoordinate(50.456, 2.1),
                HeightAboveSea = 5
            });

            var file = new EurdepV21File();
            file.LocalityList = list;
            file.BuildFile();
        }
    }
}
