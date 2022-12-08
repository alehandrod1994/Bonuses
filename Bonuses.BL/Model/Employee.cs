using System;
using System.Runtime.Serialization;

namespace Bonuses.BL.Model
{
	/// <summary>
	/// Сотрудник.
	/// </summary>
	[DataContract]
	public class Employee
	{
		/// <summary>
		/// Создаёт новый экземпляр класса Employee.
		/// </summary>
		/// <param name="name"> Имя. </param>
		/// <param name="position"> Должность. </param>
		public Employee(string name, Position position)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("Имя сотрудника не может быть пустым.", nameof(name));
			}

			if (position is null)
			{
				throw new ArgumentNullException("Должность сотрудника не может быть пустой.", nameof(position));
			}

			Name = name;
			Position = position;
		}

		/// <summary>
		/// Имя.
		/// </summary>
		[DataMember]
		public string Name { get; set; }

		/// <summary>
		/// Должность.
		/// </summary>
		[DataMember]
		public Position Position { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}
