using System;
using System.IO;

namespace Bonuses.BL.Model
{
    public class Document
    {
        public Document() { }

        public Document(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("Неверно задано расположение файла.", nameof(path));
            }

            Path = path;
            FileName = GetFileName();
        }

        public string Name { get; set; } 
        public string Type { get; set; }
        public string Path { get; set; } = "";
        public string FileName { get; set; } = "";
        public string Extention { get; set; }

        protected string GetFileName()
        {
            return new FileInfo(Path).Name;
        }

        public override string ToString()
        {
            return Path;
        }
    }
}
