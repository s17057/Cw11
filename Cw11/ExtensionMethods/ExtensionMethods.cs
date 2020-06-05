using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11.Models;
using System.Reflection;

namespace Cw11.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static void SetProperty(this Doctor doc, String propName, Object val)
        {
            if (val != null)
            {
                Type type = doc.GetType();
                PropertyInfo prop = type.GetProperty(propName);
                prop.SetValue(doc, val, null);
            }
        }
    }
}
