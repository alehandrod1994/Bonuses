using System;
using System.Runtime.Serialization;

namespace Bonuses.BL.Model
{
	/// <summary>
	/// Должность.
	/// </summary>
	[DataContract]
	public class Position
	{
		/// <summary>
		/// Создаёт новый экземпляр класса Position.
		/// </summary>
		/// <param name="name"> Название. </param>
		public Position(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("Название должности не может быть пустым.", nameof(name));
			}

			Name = name;
		}

		/// <summary>
		/// Название.
		/// </summary>
		[DataMember]
		public string Name { get; private set; }

		public override string ToString()
		{
			return Name;
		}

		public override bool Equals(object obj)
		{
			return Name == ((Position)obj).Name;
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
	}
}
