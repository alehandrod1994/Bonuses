using System;
using System.Runtime.Serialization;

namespace Bonuses.BL.Model
{
    [DataContract]
    public class Employee
    {
        public Employee(string name, Position position)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Неверно задано имя диспетчера.", nameof(name));
            }

            if (position is null)
            {
                throw new ArgumentNullException("Неверно задана должность диспетчера.", nameof(position));
            }

            Name = name;
            Position = position;
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Position Position { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
