using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bonuses.BL.Model
{
    [DataContract]
    public class Kpi : Document
    {
        //public Kpi() 
        //{
        //    Path = "";
        //    FileName = "";
        //}

        //public Kpi(string path, string fileName)
        //{
        //    if (string.IsNullOrWhiteSpace(path))
        //    {
        //        throw new ArgumentNullException("Неверно задано расположение файла.", nameof(path));
        //    }

        //    if (string.IsNullOrWhiteSpace(fileName))
        //    {
        //        throw new ArgumentNullException("Неверно задано название файла.", nameof(fileName));
        //    }

        //    Path = path;
        //    FileName = fileName;
        //}

        //[DataMember]
        //public string Path { get; set; }

        //[DataMember]
        //public string FileName { get; set; }

        public Kpi() 
        {
            SetProperties();
        }

        public Kpi(string path) : base(path)
        {
            SetProperties();
        }

        public Kpi(string path, string sourceDirectory) : base(path, sourceDirectory)
        {
            SetProperties();
        }

        private void SetProperties()
        {
            Name = "KPI";
            Type = "Excel";
            Extention = ".xls";
        }

        public override string ToString()
        {
            return Path;
        }
    }
}
