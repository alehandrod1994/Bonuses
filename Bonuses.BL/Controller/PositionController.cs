using Bonuses.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

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

		public void ReWrite(List<Employee> employees)
		{
			Positions = GetPositions(employees);
			Save();
		}

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

		private void Save()
		{
			Save(Positions);
		}


	}
}
