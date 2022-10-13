using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonuses.BL.Model
{
    public class Log
    {
        public Log(Status status, string message, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException("Текст сообщения не может быть пустым.", nameof(message));
            }

            if (date.Year < 2000)
            {
                throw new ArgumentException("Неправильно задана дата.", nameof(date));
            }

            Status = status;
            Message = message;
            Date = date;
        }

        public Status Status { get; private set; }
        public string Message { get; private set; }
        public DateTime Date { get; private set; }
    }
}
