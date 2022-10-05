using Bonuses.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonuses.BL.Controller
{
	public class KpiController : ControllerBase
	{
		public KpiController()
		{
			Kpi = GetPath();
		}

		public Kpi Kpi { get; }

		public Kpi GetPath()
		{
			List<Kpi> kpis = Load<Kpi>();
			return kpis.Count > 0 ? kpis.First() : new Kpi();
		}

		public string AutoImport(string sourceFolder, string keyFolder, string month, string keyFile)
		{
			string nextFolder = "";
			DirectoryInfo dir = new DirectoryInfo(sourceFolder);
			foreach (DirectoryInfo directory in dir.GetDirectories())
			{
				if (directory.Name.ToString().ToUpper().Contains(keyFolder) && directory.Name.ToString().ToUpper().Contains(month.ToUpper()))
				{
					nextFolder = directory.Name;

					break;
				}
			}
			
			dir = new DirectoryInfo(sourceFolder + nextFolder);
			foreach (FileInfo files in dir.GetFiles())
			{
				if ((files.Name.ToString().ToUpper().Contains(keyFile) || files.Name.ToString().ToUpper().Contains(month.ToUpper()))
					&& !files.Name.ToString().Contains("$"))
				{
					Kpi.Path = sourceFolder + nextFolder + @"\" + files.Name;
					var fi = new FileInfo(Kpi.Path);
					Kpi.FileName = fi.Name;

					break;
				}
			}

			return Kpi.Path;
		}

		//public void Import();
		public string DragDrop(string key, Month[] months, string file, string fullPath)
		{
			var fi = new FileInfo(file);

			if (file.ToUpper().Contains(key))
			{					
				Kpi.Path = file;
				Kpi.FileName = fi.Name;
				fullPath = file;
			}
			else
			{
				for (int i = 0; i < months.Length; i++)
				{
					if (file.Contains(months[i].Name))
					{
						Kpi.Path = file;
						Kpi.FileName = fi.Name;
						fullPath = file;
						break;
					}
				}
			}

			Save();

			return fullPath;
		}

		private void Save()
		{
			Save(new List<Kpi>() { Kpi });
		}
	}
}
