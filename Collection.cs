using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Homework_08
{
    class Collection
    {
        //Worker worker = new Worker();

        // Списки типа данных Worker и Department
        public List<Worker> workerList = new List<Worker> { };
        public List<Department> departments = new List<Department> { };


        /// <summary>
        /// Метод сериализации List<Worker>
        /// </summary>
        /// <param name="СoncreteWorker">Коллекция для сериализации</param>
        /// <param name="Path">Путь к файлу</param>
        public void SerializeWorkerListXML(string Path, List<Worker> WorkerList = null, List<Department> DepartmentList = null)
        {
            // Создаем сериализатор на основе указанного типа 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Worker>));

            // Создаем поток для сохранения данных
            Stream fStream = new FileStream(Path, FileMode.Create, FileAccess.Write);

            // Запускаем процесс сериализации
            xmlSerializer.Serialize(fStream, WorkerList);

            // Закрываем поток
            fStream.Close();
        }


        /// <summary>
        /// Метод десериализации List<Worker>
        /// </summary>
        /// <param name="СoncreteWorker">Экземпляр для сериализации</param>
        /// <param name="Path">Путь к файлу</param>
        public List<Worker> DeserializeWorkerListXML(string Path)
        {
            List<Worker> tempWorkerCol;
            // Создаем сериализатор на основе указанного типа 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Worker>));

            // Создаем поток для чтения данных
            Stream fStream = new FileStream(Path, FileMode.Open, FileAccess.Read);

            // Запускаем процесс десериализации
            tempWorkerCol = xmlSerializer.Deserialize(fStream) as List<Worker>;

            // Закрываем поток
            fStream.Close();

            // Возвращаем результат
            return tempWorkerCol;
        }


        /// <summary>
        /// Метод десериализации и сериализации List<Worker>
        /// </summary>
        /// <param name="flag">Флаг выбора действия</param>
        /// <param name="Path">Путь</param>
        /// <param name="WorkerList">Список Worker</param>
        /// <returns></returns>
        public List<Worker> JSON(bool flag, string Path, List<Worker> WorkerList = null)
        {
            string json;
            if (flag == true)
            {
                // чтение из файла в потоке
                json = File.ReadAllText(Path);
                // десериализации
                WorkerList = JsonConvert.DeserializeObject<List<Worker>>(json);

            }
            else
            {
                // сериализации
                json = JsonConvert.SerializeObject(WorkerList);
                // чтение в файл в потоке
                File.WriteAllText(Path, json);
            }
            return WorkerList;
        }


        public void CountGeneratingSyntheticData(int n)
        {
            uint j = 0;
            // Цикл создания нового Worker и добавления его в список workerList
            for (uint i = 0; i < n; i++)
            {
                System.Threading.Thread.Sleep(100);
                workerList.Add(new Worker(
                i + 1,
                GeneratingSyntheticData(0),
                GeneratingSyntheticData(0),
                Convert.ToUInt32(GeneratingSyntheticData(1)),
                GeneratingSyntheticData(0),
                Convert.ToUInt32(GeneratingSyntheticData(2)),
                Convert.ToUInt32(GeneratingSyntheticData(3))));
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
                    line += random.Next(18, 80);
                    break;
                // Генерация зарплаты
                case 2:
                    line += random.Next(35_000, 1_000_000);
                    break;
                // Генерация проектов
                case 3:
                    line += random.Next(1, 10);
                    break;
            }
            return line;
        }


        /// <summary>
        /// Вывод в консоль
        /// </summary>
        /// <param name="workerList">Спиоск Worker</param>
        public void Print(List<Worker> workerList)
        {
            // Запись названия свойств в список
            //List<string> getProperties = GetProperties(workerList);

            // Вывод шапки таблицы в консоль
            //Console.WriteLine("{0,5} {1,5} {2,15} {3,5} {4,15} {5,10} {6,5}", getProperties[0], getProperties[1], getProperties[2], getProperties[3], getProperties[4], getProperties[5], getProperties[6]);

            // Цикл вызова метода, который отображает Worker
            for (int i = 0; i < workerList.Count; i++)
                Console.WriteLine(workerList[i].Print());
        }


        /// <summary>
        /// Метод добавления нового Worker
        /// </summary>
        /// <param name="workerList">Список Worker</param>
        public void AddData(List<Worker> workerList)
        {
            Console.WriteLine("Ввидете данные через Enter попорядку");

            GetProperties(workerList);

            // Добавление в список нового Worker
            workerList.Add(new Worker(
                    Convert.ToUInt32(Console.ReadLine()),
                    Console.ReadLine(),
                    Console.ReadLine(),
                    Convert.ToUInt32(Console.ReadLine()),
                    Console.ReadLine(),
                    Convert.ToUInt32(Console.ReadLine()),
                    Convert.ToUInt32(Console.ReadLine())));
        }


        /// <summary>
        /// Метод получения свойства класса Worker
        /// </summary>
        /// <param name="workerList">Список Worker</param>
        /// <returns></returns>
        public List<string> GetProperties(List<Worker> workerList, int flag = 0)
        {
            List<string> properties = new List<string> { };
            int i = 1;
            // Получение свойств класса Worker
            foreach (var property in workerList[0].GetType().GetProperties())
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
            return properties;
        }


        /// <summary>
        /// Метод удаления Worker
        /// </summary>
        /// <param name="workerList">Спиоск Worker</param>
        /// <param name="id"></param>
        public void DelData(List<Worker> workerList, int id)
        {
            // Удаление из списка по индексу
            workerList.RemoveAt(id - 1);
        }


        /// <summary>
        /// Метод редактирования Worker
        /// </summary>
        /// <param name="workerList">Список Worker</param>
        /// <param name="id">Порядковый номер строки Worker</param>
        public void EditData(List<Worker> workerList, int id)
        {
            // Присвоение новых значений свойствам
            Console.Write("Ввидите имя: ");
            workerList[id - 1].FirstName = Console.ReadLine();
            Console.Write("Ввидите фамилию: ");
            workerList[id - 1].LastName = Console.ReadLine();
            Console.Write("Ввидите возраст: ");
            workerList[id - 1].Age = Convert.ToUInt32(Console.ReadLine());
            Console.Write("Ввидите отдел: ");
            workerList[id - 1].Department = Console.ReadLine();
            Console.Write("Ввидите оплату труда: ");
            workerList[id - 1].Salary = Convert.ToUInt32(Console.ReadLine());
            Console.Write("Ввидите количество проектов: ");
            workerList[id - 1].NumberProjects = Convert.ToUInt32(Console.ReadLine());
        }


        /// <summary>
        /// Метод сортировки
        /// </summary>
        /// <param name="workerList">Список Worker</param>
        /// <param name="flag">Флаг выбора действий</param>
        /// <param name="fields">Выбор поелй</param>
        /// <returns></returns>
        public List<Worker> SortWorkerList(List<Worker> workerList, uint flag, uint fields = 0)
        {
            switch (flag)
            {
                // сортировка по одному полю
                case 1:
                    switch (fields)
                    {
                        // сортировка по полям
                        case 1:
                            workerList.Sort(delegate (Worker us1, Worker us2)
                            { return us1.FirstName.CompareTo(us2.FirstName); });
                            break;
                        case 2:
                            workerList.Sort(delegate (Worker us1, Worker us2)
                            { return us1.LastName.CompareTo(us2.LastName); });
                            break;
                        case 3:
                            workerList.Sort(delegate (Worker us1, Worker us2)
                            { return us1.Age.CompareTo(us2.Age); });
                            break;
                        case 4:
                            workerList.Sort(delegate (Worker us1, Worker us2)
                            { return us1.Department.CompareTo(us2.Department); });
                            break;
                        case 5:
                            workerList.Sort(delegate (Worker us1, Worker us2)
                            { return us1.Salary.CompareTo(us2.Salary); });
                            break;
                        case 6:
                            workerList.Sort(delegate (Worker us1, Worker us2)
                            { return us1.NumberProjects.CompareTo(us2.NumberProjects); });
                            break;
                    }
                    break;
                // сортировка по двум полям
                case 2:
                    switch (fields)
                    {
                        case 12:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList());
                            break;
                        case 13:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.FirstName).ThenBy(x => x.Age).ToList());
                            break;
                        case 14:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.FirstName).ThenBy(x => x.Department).ToList());
                            break;
                        case 15:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.FirstName).ThenBy(x => x.Salary).ToList());
                            break;
                        case 16:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.FirstName).ThenBy(x => x.NumberProjects).ToList());
                            break;
                        case 23:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.LastName).ThenBy(x => x.Age).ToList());
                            break;
                        case 24:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.LastName).ThenBy(x => x.Department).ToList());
                            break;
                        case 25:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.LastName).ThenBy(x => x.Salary).ToList());
                            break;
                        case 26:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.LastName).ThenBy(x => x.NumberProjects).ToList());
                            break;
                        case 34:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.Age).ThenBy(x => x.Department).ToList());
                            break;
                        case 35:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.Age).ThenBy(x => x.Salary).ToList());
                            break;
                        case 36:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.Age).ThenBy(x => x.NumberProjects).ToList());
                            break;
                        case 45:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.Department).ThenBy(x => x.NumberProjects).ToList());
                            break;
                        case 46:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.Department).ThenBy(x => x.NumberProjects).ToList());
                            break;
                        case 56:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.Salary).ThenBy(x => x.NumberProjects).ToList());
                            break;
                    }
                    break;
                // Сортировка по двум полям относительно полю департамента 
                case 3:
                    switch (fields)
                    {
                        case 12:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.Department).ThenBy(x => x.FirstName).ThenBy(x => x.LastName).ToList());
                            break;
                        case 13:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.Department).ThenBy(x => x.FirstName).ThenBy(x => x.Age).ToList());
                            break;
                        case 14:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.Department).ThenBy(x => x.FirstName).ThenBy(x => x.Salary).ToList());
                            break;
                        case 15:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.Department).ThenBy(x => x.FirstName).ThenBy(x => x.NumberProjects).ToList());
                            break;
                        case 23:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.Department).ThenBy(x => x.LastName).ThenBy(x => x.Age).ToList());
                            break;
                        case 24:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.Department).ThenBy(x => x.LastName).ThenBy(x => x.Salary).ToList());
                            break;
                        case 25:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.Department).ThenBy(x => x.LastName).ThenBy(x => x.NumberProjects).ToList());
                            break;
                        case 34:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.Department).ThenBy(x => x.Age).ThenBy(x => x.Salary).ToList());
                            break;
                        case 35:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.Department).ThenBy(x => x.Age).ThenBy(x => x.NumberProjects).ToList());
                            break;
                        case 45:
                            workerList = new List<Worker>(workerList.OrderBy(x => x.Salary).ThenBy(x => x.NumberProjects).ToList());
                            break;
                    }
                    break;
            }
            return workerList;
        }
    }
}
