using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Homework_08
{
    class CollectionDepartment
    {
        // Списки типа данных Department
        public List<Department> departmentList = new List<Department> { };


        /// <summary>
        /// Метод сериализации List<Departments>
        /// </summary>
        /// <param name="DepartmentsList">Коллекция для сериализации</param>
        /// <param name="Path">Путь к файлу</param>
        public void SerializeXML(string Path, List<Department> DepartmentsList)
        {
            // Создаем сериализатор на основе указанного типа 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Department>));

            // Создаем поток для сохранения данных
            Stream fStream = new FileStream(Path, FileMode.Create, FileAccess.Write);

            // Запускаем процесс сериализации
            xmlSerializer.Serialize(fStream, DepartmentsList);

            // Закрываем поток
            fStream.Close();
        }


        /// <summary>
        /// Метод десериализации List<Departments>
        /// </summary>
        /// <param name="Path">Путь к файлу</param>
        public List<Department> DeserializeXML(string Path)
        {
            List<Department> tempWorkerCol;
            // Создаем сериализатор на основе указанного типа 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Department>));

            // Создаем поток для чтения данных
            Stream fStream = new FileStream(Path, FileMode.Open, FileAccess.Read);

            // Запускаем процесс десериализации
            tempWorkerCol = xmlSerializer.Deserialize(fStream) as List<Department>;

            // Закрываем поток
            fStream.Close();

            // Возвращаем результат
            return tempWorkerCol;
        }


        /// <summary>
        /// Метод десериализации и сериализации List<Departments>
        /// </summary>
        /// <param name="flag">Флаг выбора действия</param>
        /// <param name="Path">Путь</param>
        /// <param name="DepartmentList">Список Departments</param>
        /// <returns></returns>
        public List<Department> JSON(bool flag, string Path, List<Department> DepartmentList = null)
        {
            string json;
            if (flag == true)
            {
                // чтение из файла в потоке
                json = File.ReadAllText(Path);
                // десериализации
                DepartmentList = JsonConvert.DeserializeObject<List<Department>>(json);

            }
            else
            {
                // сериализации
                json = JsonConvert.SerializeObject(DepartmentList);
                // чтение в файл в потоке
                File.WriteAllText(Path, json);
            }
            return DepartmentList;
        }


        public void CountGeneratingSyntheticData(int n)
        {
            // Цикл создания нового Departments и добавления его в список workerList
            for (uint i = 0; i < n; i++)
            {
                System.Threading.Thread.Sleep(100);
                departmentList.Add(new Department(
                GeneratingSyntheticData(0),
                DateTime.Parse(GeneratingSyntheticData(1)),
                Convert.ToUInt32(GeneratingSyntheticData(2))));
            }
        }


        /// <summary>
        /// Генерация синтетических данных
        /// </summary>
        /// <param name="flag">Флаг выбора действия</param>
        /// <returns></returns>
        public string GeneratingSyntheticData(int flag)
        {

            string line = "", uppercaseAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ", alphabet = "abcdefghijklmnopqrstuvwxyz";

            Random random = new Random();
            switch (flag)
            {
                // Генерация текстовых значений (Фамилия, имя, департамент)
                case 0:
                    line += uppercaseAlphabet[random.Next(0, uppercaseAlphabet.Length)];

                    for (int i = 0; i < random.Next(7, 15); i++)
                        line += alphabet[random.Next(0, alphabet.Length)];
                    break;
                // Генерация возраста
                case 1:
                    DateTime start = new DateTime(1995, 1, 1);
                    int range = (DateTime.Today - start).Days;
                    line = (start.AddDays(random.Next(range))).ToString();
                    break;
                // Генерация проектов
                case 2:
                    line += random.Next(1, 100);
                    break;
            }
            return line;
        }


        /// <summary>
        /// Вывод в консоль
        /// </summary>
        /// <param name="DepartmentList">Спиоск Departments</param>
        public void Print(List<Department> DepartmentList)
        {
            //Запись названия свойств в список
            List<string> getProperties = GetProperties(DepartmentList);

            //Вывод шапки таблицы в консоль
            Console.WriteLine("{0,15} {1,20} {2,5}", getProperties[0], getProperties[1], getProperties[2]);

            // Цикл вызова метода, который отображает Departments
            for (int i = 0; i < DepartmentList.Count; i++)
                Console.WriteLine(DepartmentList[i].Print());
        }


        /// <summary>
        /// Метод добавления нового Departments
        /// </summary>
        /// <param name="DepartmentList">Список Departments</param>
        public void AddData(List<Department> DepartmentList)
        {
            Console.WriteLine("Ввидете данные через Enter попорядку");

            GetProperties(DepartmentList);

            // Добавление в список нового Departments
            DepartmentList.Add(new Department(
                    Console.ReadLine(),
                    DateTime.Parse(Console.ReadLine()),
                    Convert.ToUInt32(Console.ReadLine())));

        }


        /// <summary>
        /// Метод получения свойства класса Departments
        /// </summary>
        /// <param name="DepartmentList">Список Departments</param>
        /// <returns></returns>
        public List<string> GetProperties(List<Department> DepartmentList, int flag = 0)
        {
            List<string> properties = new List<string> { };
            int i = 1;
            // Получение свойств класса Departments
            foreach (var property in DepartmentList[0].GetType().GetProperties())
            {
                // Пропуск свойств
                if (property.Name == "UniqueNumber" && (flag == 1 || flag == 2))
                    continue;

                if (property.Name == "Department" && flag == 2)
                    continue;

                // вывод и добавление названия свойст класса Properties
                Console.WriteLine($"{i} - {property.Name}");
                properties.Add(property.Name);
                i++;
            }
            Console.WriteLine();
            return properties;
        }


        /// <summary>
        /// Метод удаления Departments
        /// </summary>
        /// <param name="DepartmentList">Спиоск Departments</param>
        /// <param name="id">Номер строки</param>
        public void DelData(List<Department> DepartmentList, int id)
        {
            // Удаление из списка по индексу
            DepartmentList.RemoveAt(id - 1);
        }


        /// <summary>
        /// Метод редактирования Departments
        /// </summary>
        /// <param name="workerList">Список Departments</param>
        /// <param name="id">Порядковый номер строки Departments</param>
        public void EditData(List<Department> DepartmentList, int id)
        {
            // Присвоение новых значений свойствам
            Console.Write("Введите название: ");
            DepartmentList[id - 1].NameDepartment = Console.ReadLine();
            Console.Write("Введите дату в формате DD.MM.YYYY (пример 10.10.1337): ");
            DepartmentList[id - 1].DateCreation = DateTime.Parse(Console.ReadLine());
            Console.Write("Введите кол-во сотрудников: ");
            DepartmentList[id - 1].CountWorker = Convert.ToUInt32(Console.ReadLine());
        }
    }
}
