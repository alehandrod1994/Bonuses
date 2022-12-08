using System;
using System.Runtime.Serialization;

namespace Bonuses.BL.Model
{
	/// <summary>
	/// Нарушение.
	/// </summary>
	[DataContract]
	public class Detection
	{
		/// <summary>
		/// Создаёт новый экземпляр класса Detection.
		/// </summary>
		/// <param name="name"> Наименование. </param>
		/// <param name="description"> Описание. </param>
		public Detection(string name, string description)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("Наименование нарушения не может быть пустым.", nameof(name));
			}

			if (string.IsNullOrWhiteSpace(description))
			{
				throw new ArgumentNullException("Описание нарушения не может быть пустым.", nameof(description));
			}

			Name = name;
			Description = description;
		}

		/// <summary>
		/// Наименование.
		/// </summary>
		[DataMember]
		public string Name { get; private set; }

		/// <summary>
		/// Описание.
		/// </summary>
		[DataMember]
		public string Description { get; private set; }

		public override string ToString()
		{
			return Name;
		}
	}
}
