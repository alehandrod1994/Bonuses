using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Bonuses.BL.Model
{
	/// <summary>
	/// Документ.
	/// </summary>
	[DataContract]
	public abstract class Document
	{
		/// <summary>
		/// Создаёт новый документ.
		/// </summary>
		/// <param name="path"> Полный путь файла. </param>
		public Document() { }

		/// <summary>
		/// Создаёт новый документ.
		/// </summary>
		/// <param name="path"> Полный путь файла. </param>
		public Document(string path) : this(path, "") { }

		/// <summary>
		/// Создаёт новый документ.
		/// </summary>
		/// <param name="path"> Полный путь файла. </param>
		/// <param name="sourceDirectory"> Корневая папка. </param>
		public Document(string path, string sourceDirectory)
		{
			if (string.IsNullOrWhiteSpace(path))
			{
				throw new ArgumentNullException("Путь файла не может быть пустым.", nameof(path));
			}

			if (string.IsNullOrWhiteSpace(sourceDirectory))
			{
				throw new ArgumentNullException("Путь к корневой папке не может быть пустым.", nameof(sourceDirectory));
			}

			Path = path;
			FileName = GetFileName();
			SourceDirectory = sourceDirectory;
		}

		/// <summary>
		/// Название документа.
		/// </summary>
		[DataMember]
		public string Name { get; set; }

		/// <summary>
		/// Тип.
		/// </summary>
		[DataMember]
		public string Type { get; set; }


		/// <summary>
		/// Корневая папка.
		/// </summary>
		[DataMember]
		public string SourceDirectory { get; set; } = "";

		/// <summary>
		/// Полный путь файла.
		/// </summary>
		[DataMember]
		public string Path { get; set; } = "";

		/// <summary>
		/// Имя файла.
		/// </summary>
		[DataMember]
		public string FileName { get; set; } = "";

		/// <summary>
		/// Расширение файла.
		/// </summary>
		[DataMember]
		public string Extention { get; set; }

		/// <summary>
		/// Возвращает имя файла.
		/// </summary>
		/// <returns></returns>
		protected string GetFileName()
		{
			//if (Path != "")
			//{
				return new FileInfo(Path).Name;
			//}

			//return "";
		}

		public override string ToString()
		{
			return Path;
		}
	}
}
