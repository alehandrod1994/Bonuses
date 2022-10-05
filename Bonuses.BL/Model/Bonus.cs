using System;

namespace Bonuses.BL.Model
{
    public class Bonus
    {
        public Bonus(Employee employee, Detection detection, int count)
        {
            if (employee is null)
            {
                throw new ArgumentNullException("Поле сотрудник не может быть пустым.", nameof(employee));
            }

            if (detection is null)
            {
                throw new ArgumentNullException("Поле нарушение не может быть пустым.", nameof(detection));
            }

            if (count <= 0)
            {
                throw new ArgumentException("задан неверный пароль пользователя", nameof(count));
            }

            Employee = employee;
            Detection = detection;
            Count = count;
        }

        public Employee Employee { get; set; }
        public Detection Detection { get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            return $"{Employee}, {Detection}, {Count}";
        }
    }
}
