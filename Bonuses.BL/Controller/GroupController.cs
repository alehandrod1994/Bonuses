using Bonuses.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bonuses.BL.Controller
{
	/// <summary>
	/// Контроллер отдела.
	/// </summary>
	public class GroupController : ControllerBase
	{
		/// <summary>
		/// Создаёт новый контроллер отдела.
		/// </summary>
		public GroupController()
		{
			Group = GetGroup();
		}

		/// <summary>
		/// Отдел.
		/// </summary>
		public Group Group { get; set; }

		// <summary>
		/// Событие, которое происходит при изменении названия отдела.
		/// </summary>
		public event EventHandler OnNameChanged;

		/// <summary>
		/// Изменяет название отдела.
		/// </summary>
		/// <param name="group"> Название отдела. </param>
		public void Change(Group group)
		{
			Group = group;
			Save();
			OnNameChanged?.Invoke(Group, null);
		}

		/// <summary>
		/// Возвращает отдел.
		/// </summary>
		/// <returns> Отдел. </returns>
		private Group GetGroup()
		{
			List<Group> groups = Load<Group>();
			return groups.Count > 0 ? groups.First() : new Group();
		}

		/// <summary>
		/// Сохраняет данные.
		/// </summary>
		private void Save()
		{
			Save(new List<Group>() { Group });
		}
	}
}
