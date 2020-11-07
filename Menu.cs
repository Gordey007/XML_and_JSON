using System;

namespace Homework_08
{
    class Menu
    {
        #region Конструкторы

        public Menu(CollectionWorker CollectionWorker)
        {
            this.collectionWorker = CollectionWorker;
        }

        public Menu(CollectionDepartment CollectionDepartment)
        {
            this.collectionDepartment = CollectionDepartment;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Метод выбора методов классов рабочего или департамента
        /// </summary>
        /// <param name="case_">Указатель на метод</param>
        /// <param name="collectionCase">Указатель на класс</param>
        public void MenuCase(uint case_, int collectionCase)
        { 
            // Оператор выбора
            switch (case_)
            {
                // Создания синтетических данных 
                case 0:
                    Console.WriteLine();
                    Console.Write("Ввидите количество рабочих или департаментов: ");
                    int n = Convert.ToInt32(Console.ReadLine());

                    if (collectionCase == 1)
                    {
                        collectionWorker.workerList.Clear();
                        collectionWorker.CountGeneratingSyntheticData(n);

                        // Вызов Метода, который выводит информацию в консоль
                        CollectionWorker.Print(CollectionWorker.workerList);
                    }
                    else
                    {
                        collectionDepartment.departmentList.Clear();
                        collectionDepartment.CountGeneratingSyntheticData(n);

                        // Вызов Метода, который выводит информацию в консоль
                        collectionDepartment.Print(collectionDepartment.departmentList);
                    }                                  
                    Console.WriteLine();
                    break;
                case 1:
                    Console.WriteLine();
                    // Вызов Метода, который десериализует данные из xml файла
                    if (collectionCase == 1)
                    {
                        CollectionWorker.workerList = CollectionWorker.DeserializeXML(@"D:\workerListXML");
                        CollectionWorker.Print(CollectionWorker.workerList);
                    }
                    else
                    {
                        CollectionDepartment.departmentList = CollectionDepartment.DeserializeXML(@"D:\departmentListXML");
                        CollectionDepartment.Print(CollectionDepartment.departmentList);
                    }
                    Console.WriteLine();
                    break;
                case 2:
                    // Вызов Метода, который серелизует данные в xml файл
                    if (collectionCase == 1)
                        CollectionWorker.SerializeXML(@"D:\workerListXML", CollectionWorker.workerList);
                    else
                        CollectionDepartment.SerializeXML(@"D:\departmentListXML", CollectionDepartment.departmentList);
                    break;
                case 3:
                    // Вызов Метода, который десериализует данные из json файла
                    if (collectionCase == 1)
                    {
                        CollectionWorker.workerList = CollectionWorker.JSON(true, @"D:\workerListJSON.json");
                        CollectionWorker.Print(CollectionWorker.workerList);
                    }
                    else
                    {
                        CollectionDepartment.departmentList = CollectionDepartment.JSON(true, @"D:\departmentListJSON.json");
                        CollectionDepartment.Print(CollectionDepartment.departmentList);
                    }
                    Console.WriteLine();
                    break;
                case 4:
                    // Вызов Метода, который серелизует данные в json файл
                    if (collectionCase == 1)
                        CollectionWorker.JSON(false, @"D:\workerListJSON.json", CollectionWorker.workerList);
                    else
                        CollectionDepartment.JSON(false, @"D:\departmentListJSON.json", CollectionDepartment.departmentList);
                    break;
                case 5:
                    Console.WriteLine();
                    // Вызов Метода, который добавляет нового Departments
                    if (collectionCase == 1)
                    {
                        CollectionWorker.AddData(CollectionWorker.workerList);
                        CollectionWorker.Print(CollectionWorker.workerList);
                    }
                    else
                    {
                        CollectionDepartment.AddData(CollectionDepartment.departmentList);
                        CollectionWorker.Print(CollectionWorker.workerList);
                    }         
                    Console.WriteLine();
                    break;
                case 6:
                    Console.Write("Ввидите номер строки: ");
                    // Вызов Метода, который редактирует данные выбранного Departments
                    if (collectionCase == 1)
                    {
                        CollectionWorker.EditData(CollectionWorker.workerList, Convert.ToInt32(Console.ReadLine()));
                        CollectionWorker.Print(CollectionWorker.workerList);
                    }
                    else
                    {
                        CollectionDepartment.EditData(CollectionDepartment.departmentList, Convert.ToInt32(Console.ReadLine()));
                        CollectionDepartment.Print(CollectionDepartment.departmentList);
                    }
                    Console.WriteLine();
                    break;
                case 7:
                    Console.Write("Ввидите номер строки: ");
                    // Вызов Метода, который удаляет Departments
                    if (collectionCase == 1)
                    {
                        CollectionWorker.DelData(CollectionWorker.workerList, Convert.ToInt32(Console.ReadLine()));
                        CollectionWorker.Print(CollectionWorker.workerList);
                    }
                    else
                    {
                        CollectionDepartment.DelData(CollectionDepartment.departmentList, Convert.ToInt32(Console.ReadLine()));
                        CollectionWorker.Print(CollectionWorker.workerList);
                    }
                    break;
                case 8:
                    if (collectionCase == 1)
                    {
                        Console.WriteLine();
                        // Вызов Метода, который получает свойства Departments
                        CollectionWorker.GetProperties(CollectionWorker.workerList, 1);
                        Console.Write("Ввидите номер поля: ");
                        // Вызов Метода сортировки
                        CollectionWorker.workerList = CollectionWorker.SortWorkerList(CollectionWorker.workerList, 1, Convert.ToUInt32(Console.ReadLine()));
                        CollectionWorker.Print(CollectionWorker.workerList);
                        Console.WriteLine();
                    }
                    break;
                case 9:
                    if (collectionCase == 1)
                    {
                        Console.WriteLine();
                        CollectionWorker.GetProperties(CollectionWorker.workerList, 1);
                        Console.WriteLine("Ввидите номера двух полей через Enter: ");
                        CollectionWorker.workerList = CollectionWorker.SortWorkerList(CollectionWorker.workerList, 2, Convert.ToUInt32(Console.ReadLine()), Convert.ToUInt32(Console.ReadLine()));
                        CollectionWorker.Print(CollectionWorker.workerList);
                        Console.WriteLine();
                    }       
                    break;
                case 10:
                    if (collectionCase == 1)
                    {
                        Console.WriteLine();
                        CollectionWorker.GetProperties(CollectionWorker.workerList, 2);
                        Console.WriteLine("Ввидите номера двух полей через Enter: ");
                        CollectionWorker.workerList = CollectionWorker.SortWorkerList(CollectionWorker.workerList, 3, Convert.ToUInt32(Console.ReadLine()), Convert.ToUInt32(Console.ReadLine()));
                        CollectionWorker.Print(CollectionWorker.workerList);
                        Console.WriteLine();
                    }     
                    break;
            }
        }


        /// <summary>
        /// Метод вывода меню
        /// </summary>
        /// <param name="collectionCase">Указатель на класс</param>
        public void MenuText(int collectionCase)
        {
            if (collectionCase == 1)
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
            else
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
              "\n8 - Выход из программы");

                Console.Write("> ");
            }
        }

        #endregion

        #region Свойства

        /// <summary>
        /// Наименование
        /// </summary>
        public CollectionWorker CollectionWorker { get { return this.collectionWorker; } set { this.collectionWorker = value; } }

        /// <summary>
        /// Наименование
        /// </summary>
        public CollectionDepartment CollectionDepartment { get { return this.collectionDepartment; } set { this.collectionDepartment = value; } }

        #endregion

        #region Поля

        /// <summary>
        /// Поле "Уникальный номер"
        /// </summary>
        private CollectionWorker collectionWorker;


        /// <summary>
        /// Поле "Уникальный номер"
        /// </summary>
        private CollectionDepartment collectionDepartment;

        #endregion
    }
}
