using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Bonuses.BL.Model
{
    [DataContract]
    public class Document
    {
        public Document() { }

        public Document(string path) : this(path, "") { }

        public Document(string path, string sourceDirectory)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("Неверно задано расположение файла.", nameof(path));
            }

            if (string.IsNullOrWhiteSpace(sourceDirectory))
            {
                throw new ArgumentNullException("Неверно задано исходная папка расположения файла.", nameof(sourceDirectory));
            }

            Path = path;
            FileName = GetFileName();
            SourceDirectory = sourceDirectory;
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string SourceDirectory { get; set; } = "";

        [DataMember]
        public string Path { get; set; } = "";

        [DataMember]
        public string FileName { get; set; } = "";

        [DataMember]
        public string Extention { get; set; }

        protected string GetFileName()
        {
            //if (Path != "")
            //{
                return new FileInfo(Path).Name;
            //}

            //return "";
        }

        public override string ToString()
        {
            return Path;
        }
    }
}
