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

            var member = typeof(Locality);
            var properties = member.GetProperties().Where(p => Attribute.IsDefined(p, typeof(EurdepFieldAttribute)));
            IEnumerable<PropertyInfo> mandatoryProperties =
                properties.Where(
                    p =>
                        ((EurdepFieldAttribute) Attribute.GetCustomAttribute(p, typeof (EurdepFieldAttribute)))
                            .Mandatory);

            //IEnumerable<PropertyInfo> propertiesContainingData = properties.Where(p => p.GetValue(list[0]) != null);


            foreach (var prop in properties.OrderBy(p => ((EurdepFieldAttribute)Attribute.GetCustomAttribute(p, typeof(EurdepFieldAttribute))).Order))
            {
                var eurdepFieldAttr = (EurdepFieldAttribute) Attribute.GetCustomAttribute(prop, typeof(EurdepFieldAttribute));
                if(eurdepFieldAttr.Mandatory)
                    Console.WriteLine(eurdepFieldAttr.FieldName);
            }
        }
    }
}
