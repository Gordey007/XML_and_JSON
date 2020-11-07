
namespace Homework_08
{
    public class Worker
    {
        #region Конструкторы

        public Worker()
        {

        }


        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="UniqueNumber">Уникальный номер</param>
        /// <param name="FirstName">Имя</param>
        /// <param name="LastName">Фамилия</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Department">Департамент</param>
        /// <param name="Salary">Оплата труда</param>
        /// <param name="NumberProjects">Количество проектов</param>
        public Worker(uint UniqueNumber, string FirstName, string LastName, uint Age, string Department, uint Salary, uint NumberProjects)
        {
            this.uniqueNumber = UniqueNumber;
            this.firstName = FirstName;
            this.lastName = LastName;
            this.age = Age;
            this.department = Department;
            this.salary = Salary;
            this.numberProjects = NumberProjects;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Метод вывода консоль
        /// </summary>
        /// <returns>Стракоку для вывода </returns>
        public string Print()
        {
            return $"{this.uniqueNumber,5} {this.firstName,15} {this.lastName,15} {this.age,5} {this.department,15} {this.salary,10} {this.numberProjects,5}";
        }

        #endregion

        #region Свойства

        /// <summary>
        /// Уникальный номер
        /// </summary>
        public uint UniqueNumber { get { return this.uniqueNumber; } set { this.uniqueNumber = value; } }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get { return this.firstName; } set { this.firstName = value; } }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get { return this.lastName; } set { this.lastName = value; } }

        /// <summary>
        /// Возраст
        /// </summary>
        public uint Age { get { return this.age; } set { this.age = value; } }

        /// <summary>
        /// Отдел
        /// </summary>
        public string Department { get { return this.department; } set { this.department = value; } }

        /// <summary>
        /// Оплата труда
        /// </summary>
        public uint Salary { get { return this.salary; } set { this.salary = value; } }

        /// <summary>
        /// Количество проектов
        /// </summary>
        public uint NumberProjects { get { return this.numberProjects; } set { this.numberProjects = value; } }

        #endregion

        #region Поля

        /// <summary>
        /// Поле "Уникальный номер"
        /// </summary>
        private uint uniqueNumber;
        /// <summary>
        /// Поле "Имя"
        /// </summary>
        private string firstName;

        /// <summary>
        /// Поле "Фамилия"
        /// </summary>
        private string lastName;

        /// <summary>
        /// Поле "Возраст"
        /// </summary>
        private uint age;

        /// <summary>
        /// Поле "Отдел"
        /// </summary>
        private string department;

        /// <summary>
        /// Поле "Оплата труда"
        /// </summary>
        private uint salary;

        /// <summary>
        /// Количество проектов
        /// </summary>
        private uint numberProjects;

        #endregion
    }
}
