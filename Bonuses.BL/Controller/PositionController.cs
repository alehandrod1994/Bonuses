using Bonuses.BL.Model;
using System;
using System.Collections.Generic;

namespace Bonuses.BL.Controller
{
	public class PositionController : ControllerBase
	{
		public PositionController(List<Employee> employees)
		{
			Positions = GetPositions(employees);
		}

		public List<Position> Positions { get; private set; }

		public void Add(Position position)
		{
			if (!Positions.Contains(position))
			{
				Positions.Add(position);
			}
		}

		private List<Position> GetPositions(List<Employee> employees)
		{
			var positions = new List<Position>();
			foreach (var employee in employees)
			{
				positions.Add(employee.Position);
				employees.RemoveAll(e => e.Position == employee.Position);
			}

			return positions;
		}

		public void Save(List<Employee> employees)
		{
			Positions = GetPositions(employees);
			Save(Positions);
		}
	}
}
