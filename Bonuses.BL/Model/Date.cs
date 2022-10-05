using System;
using System.Linq;

namespace Bonuses.BL.Model
{
	public class Date
	{
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
				new Month(10, "Октябрь", "Октябрь"),
				new Month(11, "Ноябрь", "Ноября"),
				new Month(12, "Декабрь", "Декабря")
			};

			TodayMonth = GetTodayMonth();
			Year = DateTime.Today.Year;
		}

		public Month[] Months { get; }

		public Month TodayMonth { get; }
		public int Year { get; }

		public Month GetTodayMonth()
		{
			int monthNumber = DateTime.Today.Month;
			return Months.SingleOrDefault(m => m.Number == monthNumber);
		}
	}
}
