using System;
using System.Linq;

namespace Bonuses.BL.Model
{
	/// <summary>
	/// Дата.
	/// </summary>
	public class Date
	{
		/// <summary>
		/// Создаёт новый экземпляр класса Date.
		/// </summary>
		public Date()
		{
			Months = new Month[]
			{
				new Month(1, "Январь", "Января"),
				new Month(2, "Февраль", "Февраля"),
				new Month(3, "Март", "Марта"),
				new Month(4, "Апрель", "Апреля"),
				new Month(5, "Май", "Мая"),
				new Month(6, "Июнь", "Июня"),
				new Month(7, "Июль", "Июля"),
				new Month(8, "Август", "Августа"),
				new Month(9, "Сентябрь", "Сентября"),
				new Month(10, "Октябрь", "Октября"),
				new Month(11, "Ноябрь", "Ноября"),
				new Month(12, "Декабрь", "Декабря")
			};

			TodayMonth = GetTodayMonth();
			Year = DateTime.Today.Year;
		}

		/// <summary>
		/// Список месяцев.
		/// </summary>
		public Month[] Months { get; }

		/// <summary>
		/// Текущий месяц.
		/// </summary>
		public Month TodayMonth { get; set; }

		/// <summary>
		/// Год.
		/// </summary>
		public int Year { get; set; }

		/// <summary>
		/// Возвращает текущий месяц.
		/// </summary>
		/// <returns></returns>
		public Month GetTodayMonth()
		{
			int monthNumber = DateTime.Today.Month;
			return Months[monthNumber - 1];
		}

		public override string ToString()
		{
			return DateTime.Today.ToString();
		}
	}
}
