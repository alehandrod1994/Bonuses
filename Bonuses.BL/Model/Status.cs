using System;

namespace Bonuses.BL.Model
{
    /// <summary>
    /// Статус выполнения подсчёта.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Стоп.
        /// </summary>
        Stop,

        /// <summary>
        /// Не удалось подключиться к файлу.
        /// </summary>
        Failed,

        /// <summary>
        /// Найден новый сотрудник.
        /// </summary>
        NewEmployeeFound,

        /// <summary>
        /// Не удалось сохранить файл.
        /// </summary>
        NotSave,

        /// <summary>
        /// Готов к выполнению подсчёта.
        /// </summary>
        Start,

        /// <summary>
        /// Успешное завершение подсчёта.
        /// </summary>
        Success,

        /// <summary>
        /// Неизвестные данные.
        /// </summary>
        UnknownData
    }
}
