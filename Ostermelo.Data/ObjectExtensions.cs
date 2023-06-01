using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ostermelo.Data
{
    public static class ObjectExtensions
    {
        public static T DeepCopy<T>(this T instance)
        {
            var json = JsonConvert.SerializeObject(instance);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
