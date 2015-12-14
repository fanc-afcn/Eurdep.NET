using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurdep.NET
{
    /// <summary>
    /// Property used to describe a EURDEP field in a EURDEP sectoin
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class EurdepFieldAttribute : Attribute
    {
        public readonly string FieldName;
        public readonly bool Mandatory;
        public readonly int Order;

        public EurdepFieldAttribute(string fieldName, bool mandatory, int order)
        {
            this.FieldName = fieldName;
            this.Mandatory = mandatory;
            this.Order = order;
        }
    }
}
