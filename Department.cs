using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
    class Department
    {
        #region Конструкторы

        public Department()
        {

        }


        /// <summary>
        /// Создание департамента
        /// </summary>
        /// <param name="NameDepartment">Наименование</param>
        /// <param name="DateCreation">Дата создания</param>
        /// <param name="CountWorker">Количество сотрудников</param>
        public Department (string NameDepartment, DateTime DateCreation, uint CountWorker)
        {
            this.nameDepartment = NameDepartment;
            this.dateCreation = DateCreation;
            this.countWorker = CountWorker;
        }

        #endregion

        #region Методы

        public string Print()
        {
            return $"{this.nameDepartment,5} {this.dateCreation,15} {this.countWorker,15}";
        }

        #endregion

        #region Свойства

        /// <summary>
        /// Наименование
        /// </summary>
        public string NameDepartment { get { return this.nameDepartment; } set { this.nameDepartment = value; } }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime DateCreation { get { return this.dateCreation; } set { this.dateCreation = value; } }

        /// <summary>
        /// Количество сотрудников
        /// </summary>
        public uint CountWorker { get { return this.countWorker; } set { this.countWorker = value; } }

        #endregion


        #region Поля

        /// <summary>
        /// Поле "Уникальный номер"
        /// </summary>
        private string nameDepartment;
        /// <summary>
        /// Поле "Имя"
        /// </summary>
        private DateTime dateCreation;

        /// <summary>
        /// Поле "Фамилия"
        /// </summary>
        private uint countWorker;

        #endregion

    }
}