using System;
using System.Runtime.Serialization;

namespace Bonuses.BL.Model
{
    [DataContract]
    public class Report
    {
        public Report() 
        {
            Path = "";
            FileName = "";
        }

        public Report(string path, string fileName)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("Неверно задано расположение файла.", nameof(path));
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException("Неверно задано имя файла.", nameof(fileName));
            }

            Path = path;
            FileName = fileName;
        }

        [DataMember]
        public string Path { get; set; }

        [DataMember]
        public string FileName { get; set; }

        public override string ToString()
        {
            return Path;
        }
    }
}
