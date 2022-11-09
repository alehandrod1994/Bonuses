using System;

namespace Bonuses.BL.Model
{
	public class Month
	{
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

		public int Number { get; }
		public string Name { get; }
		public string OfName { get; }

		public override string ToString()
		{
			return Name;
		}
	}
}
