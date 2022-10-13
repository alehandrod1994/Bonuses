using Bonuses.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Bonuses.BL.Controller
{
	public class LogController
	{
		private readonly string _path = "data\\logs.txt";
		private readonly Dictionary<Status, string> _messages = new Dictionary<Status, string>();

		public LogController(string documentName)
		{
			_messages.Add(Status.Cancel, "Отмена.");
			_messages.Add(Status.Failed, $"Не удалось открыть файл \"{documentName}\". Возможно, он сейчас используется.");
			_messages.Add(Status.Pause, "Остановлено.");
			_messages.Add(Status.Success, "Успешно.");	
	}

	public void Save(Log log)
	{
		using (var sw = new StreamWriter(_path, true))
		{
			sw.WriteLine($"{log.Date} = {log.Message}");
		}
	}
}
}
