using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bonuses.BL.Model
{
	/// <summary>
	/// Документ "KPI".
	/// </summary>
	[DataContract]
	public class Kpi : Document
	{
		//public Kpi() 
		//{
		//    Path = "";
		//    FileName = "";
		//}

		//public Kpi(string path, string fileName)
		//{
		//    if (string.IsNullOrWhiteSpace(path))
		//    {
		//        throw new ArgumentNullException("Неверно задано расположение файла.", nameof(path));
		//    }

		//    if (string.IsNullOrWhiteSpace(fileName))
		//    {
		//        throw new ArgumentNullException("Неверно задано название файла.", nameof(fileName));
		//    }

		//    Path = path;
		//    FileName = fileName;
		//}

		//[DataMember]
		//public string Path { get; set; }

		//[DataMember]
		//public string FileName { get; set; }

		/// <summary>
		/// Создаёт новый экземпляр класса Kpi.
		/// </summary>
		public Kpi() 
		{
			SetProperties();
		}

		/// <summary>
		/// Создаёт новый экземпляр класса Kpi.
		/// </summary>
		/// <param name="path"> Полный путь файла. </param>
		public Kpi(string path) : base(path)
		{
			SetProperties();
		}

		/// <summary>
		/// Создаёт новый экземпляр класса Kpi.
		/// </summary>
		/// <param name="path"> Полный путь файла. </param>
		/// <param name="sourceDirectory"> Корневая папка. </param>
		public Kpi(string path, string sourceDirectory) : base(path, sourceDirectory)
		{
			SetProperties();
		}

		/// <summary>
		/// Устанавливает исходные значения.
		/// </summary>
		private void SetProperties()
		{
			Name = "KPI";
			Type = "Excel";
			Extention = ".xls";
		}

		public override string ToString()
		{
			return Path;
		}
	}
}
