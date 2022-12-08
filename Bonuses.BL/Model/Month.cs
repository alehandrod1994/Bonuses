using System;

namespace Bonuses.BL.Model
{
	/// <summary>
	/// Месяц.
	/// </summary>
	public class Month
	{
		/// <summary>
		/// Создаёт новый экземпляр класса Month.
		/// </summary>
		/// <param name="number"> Номер. </param>
		/// <param name="name"> Название. </param>
		/// <param name="ofName"> Название в родительном падеже. </param>
		public Month(int number, string name, string ofName)
		{
			if (number < 1 || number > 12)
			{
				throw new ArgumentException("Номер месяца не может быть меньше 1 или больше 12.", nameof(number));
			}

			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("Название месяца не может быть пустым.", nameof(name));
			}

			if (string.IsNullOrWhiteSpace(ofName))
			{
				throw new ArgumentNullException("Название месяца в родительном падеже не может быть пустым.", nameof(ofName));
			}

			Number = number;
			Name = name;
			OfName = ofName;
		}

		/// <summary>
		/// Номер.
		/// </summary>
		public int Number { get; }

		/// <summary>
		/// Название.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Название в родительном падеже.
		/// </summary>
		public string OfName { get; }

		public override string ToString()
		{
			return Name;
		}
	}
}
