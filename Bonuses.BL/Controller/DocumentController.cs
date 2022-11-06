using Bonuses.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Bonuses.BL.Controller
{
	public abstract class DocumentController : ControllerBase
	{
		public string AutoImport(string sourceFolder, string keyFolder, string month, string keyFile, string extention)
		{
			string nextFolder = "";
			string path = "";

			var dir = new DirectoryInfo(sourceFolder);
			foreach (DirectoryInfo directory in dir.GetDirectories())
			{
				if (directory.Name.ToUpper().Contains(keyFolder) && directory.Name.ToUpper().Contains(month.ToUpper()))
				{
					nextFolder = directory.Name;
					break;
				}
			}

			dir = new DirectoryInfo(sourceFolder + nextFolder);
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

		public void Import()
		{
			// Общий.
		}

		public void DragDrop()
		{
			// Общий.
		}
	}
}
