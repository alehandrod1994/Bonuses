using System;
using System.Runtime.Serialization;

namespace Bonuses.BL.Model
{
	/// <summary>
	/// Документ "О показателях".
	/// </summary>
	[DataContract]
	public class Report : Document
	{
		/// <summary>
		/// Создаёт новый экземпляр класса Report.
		/// </summary>
		public Report() 
		{
			SetProperties();
		}

		/// <summary>
		/// Создаёт новый экземпляр класса Report.
		/// </summary>
		/// <param name="path"> Полный путь файла. </param>
		public Report(string path) : base(path)
		{
			SetProperties();
		}

		/// <summary>
		/// Создаёт новый экземпляр класса Report.
		/// </summary>
		/// <param name="path"> Полный путь файла. </param>
		/// <param name="sourceDirectory"> Корневая папка. </param>
		public Report(string path, string sourceDirectory) : base(path, sourceDirectory)
		{
			SetProperties();
		}

		/// <summary>
		/// Устанавливает исходные значения.
		/// </summary>
		private void SetProperties()
		{
			Name = "О показателях";
			Type = "Word";
			Extention = ".doc";
		}

		public override string ToString()
		{
			return Path;
		}
	}
}
