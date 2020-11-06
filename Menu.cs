using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08
{
    class Menu
    {
        public Menu(Collection Collection)
        {
            this.collection = Collection;
        }

        #region Методы

        public void MenuCase(uint case_)
        { 
            // Оператор выбора
            switch (case_)
            {
                // Создания синтетических данных 
                case 0:
                    Console.WriteLine();
                    collection.workerList.Clear();
                    Console.Write("Ввидите количество рабочих: ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    collection.CountGeneratingSyntheticData(n);

                    // Вызов Метода, который выводит информацию в консоль
                    //Print(collection.workerList);
                    collection.Print(collection.workerList);
                    Console.WriteLine();
                    break;
                case 1:
                    Console.WriteLine();
                    // Вызов Метода, который десериализует данные из xml файла
                    collection.workerList = collection.DeserializeWorkerListXML(@"D:\workerListXML");
                    collection.Print(collection.workerList);
                    Console.WriteLine();
                    break;
                case 2:
                    // Вызов Метода, который серелизует данные в xml файл
                    collection.SerializeWorkerListXML(@"D:\workerListXML", collection.workerList);
                    break;
                case 3:
                    // Вызов Метода, который десериализует данные из json файла
                    collection.workerList = collection.JSON(true, @"D:\workerListJSON.json");
                    collection.Print(collection.workerList);
                    Console.WriteLine();
                    break;
                case 4:
                    // Вызов Метода, который серелизует данные в json файл
                    collection.JSON(false, @"D:\workerListJSON.json", collection.workerList);
                    break;
                case 5:
                    Console.WriteLine();
                    // Вызов Метода, который добавляет нового Worker
                    collection.AddData(collection.workerList);
                    collection.Print(collection.workerList);
                    Console.WriteLine();
                    break;
                case 6:
                    Console.Write("Ввидите номер строки: ");
                    // Вызов Метода, который редактирует данные выбранного Worker
                    collection.EditData(collection.workerList, Convert.ToInt32(Console.ReadLine()));
                    collection.Print(collection.workerList);
                    Console.WriteLine();
                    break;
                case 7:
                    Console.Write("Ввидите номер строки: ");
                    // Вызов Метода, который удаляет Worker
                    collection.DelData(collection.workerList, Convert.ToInt32(Console.ReadLine()));
                    collection.Print(collection.workerList);
                    break;
                case 8:
                    Console.WriteLine();
                    // Вызов Метода, который получает свойства Worker
                    collection.GetProperties(collection.workerList, 1);
                    Console.Write("Ввидите номер поля: ");
                    // Вызов Метода сортировки
                    collection.workerList = collection.SortWorkerList(collection.workerList, 1, Convert.ToUInt32(Console.ReadLine()));
                    collection.Print(collection.workerList);
                    Console.WriteLine();
                    break;
                case 9:
                    Console.WriteLine();
                    collection.GetProperties(collection.workerList, 1);
                    Console.Write("Ввидите номера двух полей без пробела и не через Enter (пример \"12\", \"35\"): ");
                    collection.workerList = collection.SortWorkerList(collection.workerList, 2, Convert.ToUInt32(Console.ReadLine()));
                    collection.Print(collection.workerList);
                    Console.WriteLine();
                    break;
                case 10:
                    Console.WriteLine();
                    collection.GetProperties(collection.workerList, 2);
                    Console.Write("Ввидите номера двух полей без пробела и не через Enter (пример \"12\", \"35\"): ");
                    collection.workerList = collection.SortWorkerList(collection.workerList, 3, Convert.ToUInt32(Console.ReadLine()));
                    collection.Print(collection.workerList);
                    Console.WriteLine();
                    break;
            }
        }


        public void MenuText()
        {
            Console.WriteLine("Ввидете команду." +
               "\n0 - Сгенерировать синтетические данные" +
               "\n1 - Импортировать данные из XML файла." +
               "\n2 - Экспортировать данные в XML файл." +
               "\n3 - Импортировать данные из JSON файла." +
               "\n4 - Экспортировать данные в JSON файл." +
               "\n5 - Добавить данные" +
               "\n6 - Редаткировать данные." +
               "\n7 - Удалить данные" +
               "\n8 - Упорядочивание по одному полю возраст" +
               "\n9 - Упорядочивание по двум полям" +
               "\n10 - Упорядочивание по двум полям в рамках одного департамента" +
               "\n11 - Выход из программы");

            Console.Write("> ");
        }

        #endregion

        #region Свойства

        /// <summary>
        /// Наименование
        /// </summary>
        public Collection Collection { get { return this.collection; } set { this.collection = value; } }

        #endregion

        #region Поля

        /// <summary>
        /// Поле "Уникальный номер"
        /// </summary>
        private Collection collection;

        #endregion
    }
}
