using Bonuses.BL.Model;
using System;
using System.Collections.Generic;

namespace Bonuses.BL.Controller
{
	/// <summary>
	/// Контроллер нарушений.
	/// </summary>
	public class DetectionController : ControllerBase
	{
		/// <summary>
		/// Создаёт новый контроллер нарушений.
		/// </summary>
		public DetectionController()
		{
			Detections = GetDetections();
		}

		/// <summary>
		/// Список нарушений.
		/// </summary>
		public List<Detection> Detections { get; private set; }

		/// <summary>
		/// Перезаписывает данные.
		/// </summary>
		/// <param name="detections"> Список нарушений. </param>
		public void ReWrite(List<Detection> detections)
		{
			Detections = detections;
			Save();
		}

		/// <summary>
		/// Возвращает список нарушений.
		/// </summary>
		/// <returns> Список нарушений. </returns>
		private List<Detection> GetDetections()
		{
			return Load<Detection>() ?? new List<Detection>();
		}

		/// <summary>
		/// Сохраняет данные.
		/// </summary>
		private void Save()
		{
			Save(Detections);
		}

		
	}
}
