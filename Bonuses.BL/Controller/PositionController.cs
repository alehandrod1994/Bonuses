using Bonuses.BL.Model;
using System.Collections.Generic;

namespace Bonuses.BL.Controller
{
    /// <summary>
    /// Контроллер должности.
    /// </summary>
    public class PositionController : ControllerBase
	{
		/// <summary>
		/// Создаёт новый контроллер должности.
		/// </summary>
		/// <param name="employees"> Список сотрудников. </param>
		public PositionController(List<Employee> employees)
		{
			Positions = GetPositions(employees);
		}

		/// <summary>
		/// Список должностей.
		/// </summary>
		public List<Position> Positions { get; private set; }

		/// <summary>
		/// Добавить должность.
		/// </summary>
		/// <param name="position"> Должность. </param>
		public void Add(Position position)
		{
			if (!Positions.Contains(position))
			{
				Positions.Add(position);
			}
		}

		/// <summary>
		/// Перезаписывает данные.
		/// </summary>
		/// <param name="employees"> Список сотрудников. </param>
		public void ReWrite(List<Employee> employees)
		{
			Positions = GetPositions(employees);
			Save();
		}

		/// <summary>
		/// Возвращает список должностей.
		/// </summary>
		/// <param name="employees"> Список сотрудников. </param>
		/// <returns> Список должностей. </returns>
		private List<Position> GetPositions(List<Employee> employees)
		{
			var positions = new List<Position>();
			foreach(var employee in employees)
			{
				if (!positions.Contains(employee.Position))
				{
					positions.Add(employee.Position);
				}								
			}

			return positions;
		}

		/// <summary>
		/// Сохраняет данные.
		/// </summary>
		private void Save()
		{
			Save(Positions);
		}


	}
}
