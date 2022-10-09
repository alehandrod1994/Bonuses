using System;
using System.Collections.Generic;

namespace Bonuses.BL.Model
{
	public class Table<T>
	{
		public Table(string[] headers)
		{
			if (headers is null)
			{
				throw new ArgumentNullException("Названия столбцов не могут быть пустыми.", nameof(headers));
			}

			Headers = headers;
			Rows = new List<T>();
		}

		public string[] Headers { get; }
		public List<T> Rows { get; }
	}
}
