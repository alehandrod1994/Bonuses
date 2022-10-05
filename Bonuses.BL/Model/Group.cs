using System;
using System.Runtime.Serialization;

namespace Bonuses.BL.Model
{
    [DataContract]
    public class Group
    {
        public Group() { }

        public Group(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Неверно задано название отдела.", nameof(name));
            }

            Name = name;
        }

        [DataMember]
        public string Name { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
