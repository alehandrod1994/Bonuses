﻿using System;
using System.Runtime.Serialization;

namespace Bonuses.BL.Model
{
    [DataContract]
    public class Kpi
    {
        public Kpi() { }
        public Kpi(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("Неверно задано расположение файла.", nameof(path));
            }

            Path = path;
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
