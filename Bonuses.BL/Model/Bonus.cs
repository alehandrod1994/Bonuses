using System;

namespace Bonuses.BL.Model
{
	/// <summary>
	/// Премирование.
	/// </summary>
	public class Bonus
	{
		/// <summary>
		/// Создаёт новый экземпляр класса Bonus.
		/// </summary>
		/// <param name="employee"> Сотрудник. </param>
		/// <param name="detection"> Нарушение. </param>
		/// <param name="count"> Количество. </param>
		public Bonus(Employee employee, Detection detection, int count)
		{
			if (employee is null)
			{
				throw new ArgumentNullException("Поле сотрудник не может быть пустым.", nameof(employee));
			}

			if (detection is null)
			{
				throw new ArgumentNullException("Поле нарушение не может быть пустым.", nameof(detection));
			}

			if (count <= 0)
			{
				throw new ArgumentException("Количество нарушений не может быть меньше нуля.", nameof(count));
			}

			Employee = employee;
			Detection = detection;
			Count = count;
		}

		/// <summary>
		/// Сотрудник.
		/// </summary>
		public Employee Employee { get; set; }

		/// <summary>
		/// Нарушение.
		/// </summary>
		public Detection Detection { get; set; }

		/// <summary>
		/// Количество.
		/// </summary>
		public int Count { get; set; }

		public override string ToString()
		{
			return $"{Employee}, {Detection}, {Count}";
		}
	}
}
