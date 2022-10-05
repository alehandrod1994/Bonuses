using System;

namespace Bonuses.BL.Model
{
    public abstract class Document
    {
        public Document(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("Неверно задано расположение файла.", nameof(path));
            }

            Path = path;
        }

        public string Path { get; }
        public string FileName { get; set; }

        public override string ToString()
        {
            return Path;
        }
    }
}
