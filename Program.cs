using System;
using System.Collections;
using System.Text.Json;
using System.IO;

namespace ConsoleApp26
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nЛабораторная работа №5, выполнила Зайцева Дарья");
                Console.WriteLine("1 - Работа с ArrayVector");
                Console.WriteLine("2 - Работа с LinkedListVector");
                Console.WriteLine("3 - Сложение векторов");
                Console.WriteLine("4 - Операции");
                Console.WriteLine("5 - Работа с массивом векторов");
                Console.WriteLine("6 - Байтовый поток");
                Console.WriteLine("7 - Символьный поток");
                Console.WriteLine("8 - Сериализация");
                Console.WriteLine("0 - Выход");
                Console.Write("Выберите пункт: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Task1();
                            break;
                        case 2:
                            Task2();
                            break;
                        case 3:
                            Task3();
                            break;
                        case 4:
                            Task4();
                            break;
                        case 5:
                            Task5();
                            break;
                        case 6:
                            Task6();
                            break;
                        case 7:
                            Task7();
                            break;
                        case 8:
                            Task8();
                            break;
                        case 0:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Нет такого пункта.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Нужно вводить число.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
        }

        static void Task1()
        {
            try
            {
                Console.Write("Введите размер ArrayVector: ");
                int n = int.Parse(Console.ReadLine());

                IVectorable vector = new ArrayVector(n);

                for (int i = 1; i <= n; i++)
                {
                    Console.Write("Элемент " + i + ": ");
                    vector[i] = int.Parse(Console.ReadLine());
                }

                bool back = false;

                while (!back)
                {
                    Console.WriteLine("\n--- Работа с ArrayVector ---");
                    Console.WriteLine("1 - Показать вектор");
                    Console.WriteLine("2 - Найти модуль");
                    Console.WriteLine("3 - Изменить элемент");
                    Console.WriteLine("4 - Глубокое клонирование");
                    Console.WriteLine("0 - Назад");
                    Console.Write("Выберите действие: ");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Вектор: " + vector);
                            break;

                        case 2:
                            Console.WriteLine("Модуль: " + vector.GetNorm());
                            break;

                        case 3:
                            Console.Write("Введите индекс: ");
                            int index = int.Parse(Console.ReadLine());
                            Console.Write("Введите новое значение: ");
                            int value = int.Parse(Console.ReadLine());
                            vector[index] = value;
                            Console.WriteLine("Новый вектор: " + vector);
                            break;

                        case 4:
                            {
                                IVectorable clone = (IVectorable)((ICloneable)vector).Clone();

                                Console.WriteLine("\nОригинал: " + vector);
                                Console.WriteLine("Клон:     " + clone);

                                Console.Write("Введите индекс элемента, который хотите изменить в клоне: ");
                                int cloneIndex = int.Parse(Console.ReadLine());

                                Console.Write("Введите новое значение: ");
                                int newValue = int.Parse(Console.ReadLine());

                                clone[cloneIndex] = newValue;

                                Console.WriteLine("\nПосле изменения клона:");
                                Console.WriteLine("Оригинал: " + vector);
                                Console.WriteLine("Клон:     " + clone);
                            }
                            break;

                        case 0:
                            back = true;
                            break;

                        default:
                            Console.WriteLine("Нет такого пункта.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        static void Task2()
        {
            try
            {
                Console.Write("Введите размер LinkedListVector: ");
                int n = int.Parse(Console.ReadLine());

                IVectorable vector = new LinkListVector(n);

                for (int i = 1; i <= n; i++)
                {
                    Console.Write("Элемент " + i + ": ");
                    vector[i] = int.Parse(Console.ReadLine());
                }

                bool back = false;

                while (!back)
                {
                    Console.WriteLine("\n--- Работа с LinkedListVector ---");
                    Console.WriteLine("1 - Показать вектор");
                    Console.WriteLine("2 - Найти модуль");
                    Console.WriteLine("3 - Изменить элемент");
                    Console.WriteLine("4 - Глубокое клонирование");
                    Console.WriteLine("0 - Назад");
                    Console.Write("Выберите действие: ");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Вектор: " + vector);
                            break;

                        case 2:
                            Console.WriteLine("Модуль: " + vector.GetNorm());
                            break;

                        case 3:
                            Console.Write("Введите индекс: ");
                            int index = int.Parse(Console.ReadLine());
                            Console.Write("Введите новое значение: ");
                            int value = int.Parse(Console.ReadLine());
                            vector[index] = value;
                            Console.WriteLine("Новый вектор: " + vector);
                            break;

                        case 4:
                            {
                                IVectorable clone = (IVectorable)((ICloneable)vector).Clone();

                                Console.WriteLine("\nОригинал: " + vector);
                                Console.WriteLine("Клон:     " + clone);

                                Console.Write("Введите индекс элемента, который хотите изменить в клоне: ");
                                int cloneIndex = int.Parse(Console.ReadLine());

                                Console.Write("Введите новое значение: ");
                                int newValue = int.Parse(Console.ReadLine());

                                clone[cloneIndex] = newValue;

                                Console.WriteLine("\nПосле изменения клона:");
                                Console.WriteLine("Оригинал: " + vector);
                                Console.WriteLine("Клон:     " + clone);
                            }
                            break;

                        case 0:
                            back = true;
                            break;

                        default:
                            Console.WriteLine("Нет такого пункта.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        static void Task3()
        {
            try
            {
                Console.WriteLine("\n--- Сложение векторов ---");

                Console.Write("Введите размер векторов: ");
                int n = int.Parse(Console.ReadLine());

                Console.Write("Выберите тип первого вектора (1 - ArrayVector, 2 - LinkedListVector): ");
                int type1 = int.Parse(Console.ReadLine());

                IVectorable v1;
                if (type1 == 1)
                    v1 = new ArrayVector(n);
                else if (type1 == 2)
                    v1 = new LinkListVector(n);
                else
                    throw new ArgumentException("Неверный тип первого вектора.");

                Console.WriteLine("Введите элементы первого вектора:");
                for (int i = 1; i <= n; i++)
                {
                    Console.Write("Элемент " + i + ": ");
                    v1[i] = int.Parse(Console.ReadLine());
                }

                Console.Write("Выберите тип второго вектора (1 - ArrayVector, 2 - LinkedListVector): ");
                int type2 = int.Parse(Console.ReadLine());

                IVectorable v2;
                if (type2 == 1)
                    v2 = new ArrayVector(n);
                else if (type2 == 2)
                    v2 = new LinkListVector(n);
                else
                    throw new ArgumentException("Неверный тип второго вектора.");

                Console.WriteLine("Введите элементы второго вектора:");
                for (int i = 1; i <= n; i++)
                {
                    Console.Write("Элемент " + i + ": ");
                    v2[i] = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("\nПервый вектор: " + v1);
                Console.WriteLine("Второй вектор: " + v2);
                Console.WriteLine("Сумма: " + Vector.SumSt(v1, v2));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        static void Task4()
        {
            try
            {
                IVectorable v1 = InputVector("Первый вектор");
                IVectorable v2 = InputVector("Второй вектор");

                bool back = false;

                while (!back)
                {
                    Console.WriteLine("Операции сравнения");
                    Console.WriteLine("1 - CompareTo (по числу координат)");
                    Console.WriteLine("2 - Compare (по модулю)");
                    Console.WriteLine("0 - Назад");
                    Console.Write("Выберите пункт: ");
                    int choice;
                    while (!int.TryParse(Console.ReadLine(), out choice))
                        Console.Write("Ошибка. Введите число: ");
                    switch (choice)
                    {
                        case 1:
                            CompareToVectors(v1, v2);
                            break;

                        case 2:
                            CompareVectors(v1, v2);
                            break;

                        case 0:
                            back = true;
                            break;

                        default:
                            Console.WriteLine("Нет такого пункта.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        static void Task5()
        {
            try
            {
                Console.Write("Введите количество векторов в массиве: ");
                int n;
                while (!int.TryParse(Console.ReadLine(), out n))
                    Console.Write("Ошибка. Введите число: ");

                if (n <= 0)
                    throw new ArgumentException("Количество векторов должно быть больше нуля.");

                IVectorable[] vectors = new IVectorable[n];

                for (int i = 0; i < n; i++)
                {
                    vectors[i] = InputVector("Вектор " + (i + 1));
                }

                Console.WriteLine("Исходный массив векторов:");
                for (int i = 0; i < vectors.Length; i++)
                {
                    Console.WriteLine("vectors[" + i + "] = " + vectors[i] + ", модуль = " + vectors[i].GetNorm());
                }

                IVectorable min = vectors[0];
                IVectorable max = vectors[0];

                for (int i = 1; i < vectors.Length; i++)
                {
                    if (((IComparable)vectors[i]).CompareTo(min) < 0)
                        min = vectors[i];

                    if (((IComparable)vectors[i]).CompareTo(max) > 0)
                        max = vectors[i];
                }

                Console.WriteLine("Векторы с минимальным числом координат:");
                for (int i = 0; i < vectors.Length; i++)
                {
                    if (((IComparable)vectors[i]).CompareTo(min) == 0)
                        Console.WriteLine(vectors[i]);
                }

                Console.WriteLine("Векторы с максимальным числом координат:");
                for (int i = 0; i < vectors.Length; i++)
                {
                    if (((IComparable)vectors[i]).CompareTo(max) == 0)
                        Console.WriteLine(vectors[i]);
                }

                Array.Sort(vectors, new VectorNormComparer());

                Console.WriteLine("Массив после сортировки по возрастанию модулей:");
                for (int i = 0; i < vectors.Length; i++)
                {
                    Console.WriteLine("vectors[" + i + "] = " + vectors[i] + ", модуль = " + vectors[i].GetNorm());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        static void CompareToVectors(IVectorable v1, IVectorable v2)
        {
            int result = ((IComparable)v1).CompareTo(v2);

            Console.WriteLine("\nПервый вектор: " + v1);
            Console.WriteLine("Второй вектор: " + v2);

            if (result < 0)
                Console.WriteLine("Первый вектор меньше второго по числу координат.");
            else if (result > 0)
                Console.WriteLine("Первый вектор больше второго по числу координат.");
            else
                Console.WriteLine("Векторы равны по числу координат.");
        }

        static void CompareVectors(IVectorable v1, IVectorable v2)
        {
            VectorNormComparer comparer = new VectorNormComparer();
            int result = comparer.Compare(v1, v2);

            Console.WriteLine("\nПервый вектор: " + v1 + ", модуль = " + v1.GetNorm());
            Console.WriteLine("Второй вектор: " + v2 + ", модуль = " + v2.GetNorm());

            if (result < 0)
                Console.WriteLine("Первый вектор меньше второго по модулю.");
            else if (result > 0)
                Console.WriteLine("Первый вектор больше второго по модулю.");
            else
                Console.WriteLine("Модули векторов равны.");
        }

        static IVectorable InputVector(string name)
        {
            Console.WriteLine("\n" + name);
            Console.Write("Выберите тип вектора (1 - ArrayVector, 2 - LinkedListVector): ");
            int type;
            while (!int.TryParse(Console.ReadLine(), out type))
                Console.Write("Ошибка. Введите число: ");

            Console.Write("Введите размер вектора: ");
            int size;
            while (!int.TryParse(Console.ReadLine(), out size))
                Console.Write("Ошибка. Введите число: ");

            IVectorable vector;

            if (type == 1)
                vector = new ArrayVector(size);
            else if (type == 2)
                vector = new LinkListVector(size);
            else
                throw new ArgumentException("Неверный тип вектора.");

            Console.WriteLine("Введите элементы:");
            for (int i = 1; i <= size; i++)
            {
                Console.Write("Элемент " + i + ": ");
                int value;
                while (!int.TryParse(Console.ReadLine(), out value))
                    Console.Write("Ошибка. Введите число: ");
                vector[i] = value;
            }

            return vector;
        }

        static void Task6()
        {
            try
            {
                Console.Write("Введите размер ArrayVector: ");
                int size;
                while (!int.TryParse(Console.ReadLine(), out size))
                    Console.Write("Ошибка. Введите число: ");

                ArrayVector vector = new ArrayVector(size);

                Console.WriteLine("Введите элементы:");
                for (int i = 1; i <= size; i++)
                {
                    Console.Write("Элемент " + i + ": ");
                    int value;
                    while (!int.TryParse(Console.ReadLine(), out value))
                        Console.Write("Ошибка. Введите число: ");
                    vector[i] = value;
                }

                using (FileStream fs = new FileStream("vector.txt", FileMode.Create))
                {
                    Vector.OutputVector(vector, fs);
                }

                Console.WriteLine("Вектор записан в байтовый файл.");

                ArrayVector readVector;
                using (FileStream fs = new FileStream("vector.txt", FileMode.Open))
                {
                    readVector = Vector.InputVector(fs);
                }

                Console.WriteLine("Считанный вектор: " + readVector);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        static void Task7()
        {
            try
            {              
                Console.Write("Введите размер ArrayVector: ");
                int size;
                while (!int.TryParse(Console.ReadLine(), out size))
                    Console.Write("Ошибка. Введите число: ");

                ArrayVector vector = new ArrayVector(size);

                Console.WriteLine("Введите элементы:");
                for (int i = 1; i <= size; i++)
                {
                    Console.Write("Элемент " + i + ": ");
                    int value;
                    while (!int.TryParse(Console.ReadLine(), out value))
                        Console.Write("Ошибка. Введите число: ");
                    vector[i] = value;
                }

                using (StreamWriter writer = new StreamWriter("vectora.txt"))
                {
                    Vector.WriteVector(vector, writer);
                }

                Console.WriteLine("Вектор записан в текстовый файл.");

                ArrayVector readVector;
                using (StreamReader reader = new StreamReader("vectora.txt"))
                {
                    readVector = Vector.ReadVector(reader);
                }

                Console.WriteLine("Считанный вектор: " + readVector);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        static void Task8()
        {
            try
            {
                Console.WriteLine("1 - ArrayVector");
                Console.WriteLine("2 - LinkedListVector");
                Console.Write("Выберите тип: ");

                int type;
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.Write("Ошибка. Введите число: ");

                if (type == 1)
                {
                    Console.Write("Введите размер ArrayVector: ");
                    int size;
                    while (!int.TryParse(Console.ReadLine(), out size))
                        Console.Write("Ошибка. Введите число: ");

                    ArrayVector vector = new ArrayVector(size);

                    Console.WriteLine("Введите элементы:");
                    for (int i = 1; i <= size; i++)
                    {
                        Console.Write("Элемент " + i + ": ");
                        int value;
                        while (!int.TryParse(Console.ReadLine(), out value))
                            Console.Write("Ошибка. Введите число: ");
                        vector[i] = value;
                    }

                    string fileName = "arrayvector.json";

                    Vector.SerializeArrayVector(vector, fileName);
                    ArrayVector loaded = Vector.DeserializeArrayVector(fileName);

                    Console.WriteLine("Исходный объект: " + vector);
                    Console.WriteLine("Считанный объект: " + loaded);
                    Console.WriteLine("Равны ли объекты: " + vector.Equals(loaded));
                }
                else if (type == 2)
                {
                    Console.Write("Введите размер LinkedListVector: ");
                    int size;
                    while (!int.TryParse(Console.ReadLine(), out size))
                        Console.Write("Ошибка. Введите число: ");

                    LinkListVector vector = new LinkListVector(size);

                    Console.WriteLine("Введите элементы:");
                    for (int i = 1; i <= size; i++)
                    {
                        Console.Write("Элемент " + i + ": ");
                        int value;
                        while (!int.TryParse(Console.ReadLine(), out value))
                            Console.Write("Ошибка. Введите число: ");
                        vector[i] = value;
                    }

                    string fileName = "linkedlistvector.json";

                    Vector.SerializeLinkedListVector(vector, fileName);
                    LinkListVector loaded = Vector.DeserializeLinkedListVector(fileName);

                    Console.WriteLine("Исходный объект: " + vector);
                    Console.WriteLine("Считанный объект: " + loaded);
                    Console.WriteLine("Равны ли объекты: " + vector.Equals(loaded));
                }
                else
                {
                    Console.WriteLine("Нет такого пункта.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}




