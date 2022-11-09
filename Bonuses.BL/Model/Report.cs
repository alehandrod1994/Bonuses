using System;
using System.Runtime.Serialization;

namespace Bonuses.BL.Model
{
    [DataContract]
    public class Report : Document
    {
        //public Report() 
        //{
        //    Path = "";
        //    FileName = "";
        //}

        //public Report(string path, string fileName)
        //{
        //    if (string.IsNullOrWhiteSpace(path))
        //    {
        //        throw new ArgumentNullException("Неверно задано расположение файла.", nameof(path));
        //    }

        //    if (string.IsNullOrWhiteSpace(fileName))
        //    {
        //        throw new ArgumentNullException("Неверно задано имя файла.", nameof(fileName));
        //    }

        //    Path = path;
        //    FileName = fileName;
        //}

        //[DataMember]
        //public string Path { get; set; }

        //[DataMember]
        //public string FileName { get; set; }

        public Report() 
        {
            SetProperties();
        }

        public Report(string path) : base(path)
        {
            SetProperties();
        }

        public Report(string path, string sourceDirectory) : base(path, sourceDirectory)
        {
            SetProperties();
        }

        private void SetProperties()
        {
            Name = "О показателях";
            Type = "Word";
            Extention = ".doc";
        }

        public override string ToString()
        {
            return Path;
        }
    }
}
