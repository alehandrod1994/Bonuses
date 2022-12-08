using Bonuses.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bonuses.BL.Controller
{
	/// <summary>
	/// Контроллер сотрудника.
	/// </summary>
	public class EmployeeController : ControllerBase
	{
		/// <summary>
		/// Создаёт новый контроллер сотрудника.
		/// </summary>
		public EmployeeController()
		{
			Employees = GetEmployees();
		}

		/// <summary>
		/// Список сотрудников.
		/// </summary>
		public List<Employee> Employees { get; set; }

		/// <summary>
		/// Имя нового сотрудника.
		/// </summary>
		public string NewEmployee { get; set; } = "";

		/// <summary>
		/// Событие, которое происходит при добавлении нового сотрудника.
		/// </summary>
		public event EventHandler OnNewEmployeeAdded;

		/// <summary>
		/// Добавляет нового сотрудника.
		/// </summary>
		public void Add(Employee employee)
		{
			Employees.Add(employee);
			NewEmployee = "";
			Save();          
			OnNewEmployeeAdded?.Invoke(employee, null);
		}

		/// <summary>
		/// Возвращает сотрудника из общего списка при его наличии.
		/// </summary>
		/// <param name="employeeName"> Имя сотрудника для поиска. </param>
		/// <param name="employee"> Найденный сотрудник. </param>
		/// <returns> True, если сотрудник найден; в противном случае - false. </returns>
		public bool TryGetEmployee(string employeeName, out Employee employee)
		{
			employee = Employees.FirstOrDefault(e => e.Name == employeeName);
			return employee != null;
		}

		/// <summary>
		/// Перезаписывает данные.
		/// </summary>
		/// <param name="employees"> Список сотрудников. </param>
		public void ReWrite(List<Employee> employees)
		{
			Employees = employees;
			Save();
		}

		/// <summary>
		/// Возвращает список сотрудников.
		/// </summary>
		/// <returns> Список сотрудников. </returns>
		private List<Employee> GetEmployees()
		{
			//var employees = new List<Employee>();
			//using (var sr = new StreamReader("Employees.txt", Encoding.UTF8))
			//{
			//    while (!sr.EndOfStream)
			//    {
			//        string item = sr.ReadLine();
			//        int index = item.IndexOf("=");
			//        string name = item.Substring(0, index);
			//        string position = item.Substring(index + 1);
			//        var employee = new Employee(name, position);
			//        employees.Add(employee);
			//    }

			//    return employees;
			//}

			return Load<Employee>() ?? new List<Employee>();
		}

		/// <summary>
		/// Сохраняет данные.
		/// </summary>
		private void Save()
		{
			//using (var sw = new StreamWriter("Employees.txt", true, Encoding.UTF8))
			//{
			//    sw.WriteLine("Бизюр Ольга Викторовна=Диспетчер ГПУ ОТБ отдела ИТСБ СТАБ");
			//}

			Save(Employees);
		}

	   
	}
}
