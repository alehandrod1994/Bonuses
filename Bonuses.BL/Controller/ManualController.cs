using Bonuses.BL.Model;
using System.IO;
using Word = Microsoft.Office.Interop.Word;

namespace Bonuses.BL.Controller
{
    /// <summary>
    /// Контроллер к инструкции.
    /// </summary>
    public class ManualController
	{
		private Word.Application _app;
		private Word.Document _doc;

		private Status _status = Status.Start;

		/// <summary>
		/// Открывает подсказку.
		/// </summary>
		/// <param name="bookmarkName"> Наименование закладки. </param>
		/// <returns> Статус выполнения. </returns>
		public Status OpenManual(string bookmarkName)
		{
			if (!OpenConnection())
			{
				ShutdownConnection();
				_status = Status.Failed;
				return _status;
			}

			Word.Bookmarks bookmarks = _doc.Bookmarks;
			foreach (Word.Bookmark bookmark in bookmarks)
			{
				if (bookmark.Name == bookmarkName)
				{
					_app.Selection.GoTo(Word.WdGoToItem.wdGoToBookmark, Name: bookmark);
					break;
				}
			}
			
			_status = Status.Success;
			return _status;
		}

		/// <summary>
		/// Открывает подключение к документу.
		/// </summary>
		/// <returns> True, если подключение прошло успешно; в противном случае - false. </returns>
		private bool OpenConnection()
		{
			string path = Directory.GetCurrentDirectory() + @"\manual\Подсчёт премирования. Инструкция по эксплуатации.docx";

			try
			{
				_app = new Word.Application() { Visible = true };
				_doc = _app.Documents.Open(path, ReadOnly: false, Visible: true);
				_doc.Activate();
				return true;
			}
			catch
			{
				_status = Status.Failed;
				return false;
			}
		}

		/// <summary>
		/// Сбрасывает подключение к файлу.
		/// </summary>
		/// <returns> True, если сбрасывание прошло успешно; в противном случае - false. </returns>
		private bool ShutdownConnection()
		{
			try
			{
				_app.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
				_app.Quit();
				_app = null;
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
