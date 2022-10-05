using System;
using System.Runtime.Serialization;

namespace Bonuses.BL.Model
{
	[DataContract]
	public class Detection
	{
		public Detection(string name, string description)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("Неверно задано наименование нарушения.", nameof(name));
			}

			if (string.IsNullOrWhiteSpace(description))
			{
				throw new ArgumentNullException("Неверно задано описание нарушения.", nameof(description));
			}

			Name = name;
			Description = description;
		}

		[DataMember]
		public string Name { get; }

		[DataMember]
		public string Description { get; }

		public override string ToString()
		{
			return Name;
		}
	}
}
