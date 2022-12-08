using System;
using System.Runtime.Serialization;

namespace Bonuses.BL.Model
{
	/// <summary>
	/// Отдел.
	/// </summary>
	[DataContract]
	public class Group
	{
		/// <summary>
		/// Создаёт новый экземпляр класса Group.
		/// </summary>
		public Group() { }

		/// <summary>
		/// Создаёт новый экземпляр класса Group.
		/// </summary>
		/// <param name="name"> Название. </param>
		public Group(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("Название отдела не может быть пустым.", nameof(name));
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
	}
}
