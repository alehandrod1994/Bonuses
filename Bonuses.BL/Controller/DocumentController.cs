using Bonuses.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Bonuses.BL.Controller
{
	/// <summary>
	/// Базовый контроллер документа.
	/// </summary>
	public abstract class DocumentController : ControllerBase
	{
		/// <summary>
		/// Автоматически импортирует файл.
		/// </summary>
		/// <param name="sourceFolder"> Исходная папка. </param>
		/// <param name="keyFolder"> Ключевая фраза для поиска папки. </param>
		/// <param name="month"> Месяц. </param>
		/// <param name="keyFile"> Ключевая фраза для поиска файла. </param>
		/// <param name="extention"> Расширение. </param>
		/// <returns> Путь к файлу. </returns>
		protected string AutoImport(string sourceFolder, string keyFolder, string month, string keyFile, string extention)
		{
			string path;

			if (!Directory.Exists(sourceFolder)) return "";
			path = FindFiles(sourceFolder, keyFile, extention);

			if (path != "") return path;
			path = FindDirectories(sourceFolder, keyFolder, month);

			if (!Directory.Exists(path)) return "";
			path = FindFiles(path, keyFile, extention);

			return path;
		}

		/// <summary>
		/// Ищет папку.
		/// </summary>
		/// <param name="sourceFolder"> Исходная папка. </param>
		/// <param name="keyFolder"> Ключевая фраза для поиска папки. </param>
		/// <param name="month"> Месяц. </param>
		/// <returns> Путь к папке. </returns>
		private string FindDirectories(string sourceFolder, string keyFolder, string month)
		{
			string nextFolder = "";

			var dir = new DirectoryInfo(sourceFolder);
			foreach (DirectoryInfo directory in dir.GetDirectories())
			{
				if (directory.Name.ToUpper().Contains(keyFolder) && directory.Name.ToUpper().Contains(month.ToUpper()))
				{
					nextFolder = directory.FullName;
					break;
				}
			}

			return nextFolder;
		}

		/// <summary>
		/// Ищет файл.
		/// </summary>
		/// <param name="sourceFolder"> Исходная папка. </param>
		/// <param name="keyFile"> Ключевая фраза для поиска файла. </param>
		/// <param name="extention"> Расширение. </param>
		/// <returns> Путь к файлу. </returns>
		private string FindFiles(string sourceFolder, string keyFile, string extention)
		{
			string path = "";

			var dir = new DirectoryInfo(sourceFolder);
			foreach (FileInfo file in dir.GetFiles())
			{
				if (file.Name.ToUpper().Contains(keyFile.ToUpper()) && file.Name.ToUpper().Contains(extention.ToUpper()) && !file.Name.Contains("$"))
				{
					path = file.FullName;
					break;
				}
			}

			return path;
		}		
	}
}
