using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Bonuses.BL.Controller
{
    public abstract class ControllerBase
    {
        protected void Save<T>(List<T> item) where T : class
        {
            var formatter = new DataContractJsonSerializer(typeof(List<T>));
            var fileName = $"{typeof(T).Name}s.json";

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.WriteObject(fs, item);
            }
        }

        protected List<T> Load<T>() where T : class
        {
            var formatter = new DataContractJsonSerializer(typeof(List<T>));
            var fileName = $"{typeof(T).Name}s.json";

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return fs.Length > 0 && formatter.ReadObject(fs) is List<T> items ? items : new List<T>();
            }
        }
    }
}
