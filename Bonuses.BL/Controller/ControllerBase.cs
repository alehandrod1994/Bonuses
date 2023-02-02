using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Bonuses.BL.Controller
{
	/// <summary>
	/// Базовый контроллер.
	/// </summary>
	public abstract class ControllerBase
	{
		/// <summary>
		/// Сохраняет данные.
		/// </summary>
		/// <typeparam name="T"> Класс сохраняемого элемента. </typeparam>
		/// <param name="item"> Список элементов для сохранения. </param>
		protected void Save<T>(List<T> item) where T : class
		{
			var formatter = new DataContractJsonSerializer(typeof(List<T>));
			var fileName = $"data\\{typeof(T).Name}s.json";

			using (var fs = new FileStream(fileName, FileMode.Create))
			{
				formatter.WriteObject(fs, item);
			}
		}

		/// <summary>
		/// Загружает данные.
		/// </summary>
		/// <typeparam name="T"> Класс загружаемого элемента. </typeparam>
		/// <returns> Список элементов. </returns>
		protected List<T> Load<T>() where T : class
		{
			if (!Directory.Exists("data"))
			{
				Directory.CreateDirectory("data");
			}

			var formatter = new DataContractJsonSerializer(typeof(List<T>));
			var fileName = $"data\\{typeof(T).Name}s.json";		

			using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
			{
				return fs.Length > 0 && formatter.ReadObject(fs) is List<T> items ? items : new List<T>();
			}
		}
	}
}
