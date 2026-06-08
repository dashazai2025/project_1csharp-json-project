using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.Json;
using System.IO;


namespace ConsoleApp24
{
    public static class Vector
    {
        public static IVectorable SumSt(IVectorable a, IVectorable b)
        {
            if (a == null || b == null)
                throw new NullReferenceException("Один из векторов не создан");
            if (a.Length != b.Length)
                throw new FormatException("Разные размерности");
            ArrayVector result = new ArrayVector(a.Length);
            for (int i = 1; i <= a.Length; i++)
            {
                result[i] = a[i] + b[i];
            }
            return result;
        }

        public static void OutputVector(ArrayVector v, Stream output)
        {
            if (v == null)
                throw new ArgumentNullException("v", "Вектор не должен быть пустым");
            if (output == null)
                throw new ArgumentNullException("output", "Поток не должен быть пустым");
            BinaryWriter writer = new BinaryWriter(output);
            writer.Write(v.Length); 
            for (int i = 1; i <= v.Length; i++)
            {
                writer.Write(v[i]); 
            }

            writer.Flush();
        }

       
        public static ArrayVector InputVector(Stream input)
        {
            if (input == null)
                throw new ArgumentNullException("input", "Поток не должен быть пустым");
            BinaryReader reader = new BinaryReader(input);       
            int size = reader.ReadInt32(); // читаем размер        
            ArrayVector v = new ArrayVector(size);
            for (int i = 1; i <= size; i++)
            {
                v[i] = reader.ReadInt32();
            }
            return v;
        }

        public static void WriteVector(ArrayVector v, TextWriter output)
        {
            if (v == null)
                throw new ArgumentNullException("v", "Вектор не должен быть пустым");
            if (output == null)
                throw new ArgumentNullException("output", "Поток не должен быть пустым");
            output.WriteLine(v.ToString());
            output.Flush();
        }

        public static ArrayVector ReadVector(TextReader input)
        {
            if (input == null)
                throw new ArgumentNullException("input", "Поток не должен быть пустым");
            string line = input.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
                throw new Exception("Файл пустой");
            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int size = int.Parse(parts[0]);
            ArrayVector v = new ArrayVector(size);
            for (int i = 1; i <= size; i++)
            {
                v[i] = int.Parse(parts[i]);
            }
            return v;
        }

        public static void SerializeArrayVector(ArrayVector vector, string fileName)
        {
            if (vector == null)
                throw new ArgumentNullException("vector", "Вектор не должен быть пустым");

            string json = JsonSerializer.Serialize(vector);
            File.WriteAllText(fileName, json);
        }

        public static ArrayVector DeserializeArrayVector(string fileName)
        {
            string json = File.ReadAllText(fileName);
            ArrayVector vector = JsonSerializer.Deserialize<ArrayVector>(json);

            if (vector == null)
                throw new Exception("Не удалось восстановить ArrayVector");

            return vector;
        }

        public static void SerializeLinkedListVector(LinkListVector vector, string fileName)
        {
            if (vector == null)
                throw new ArgumentNullException("vector", "Вектор не должен быть пустым");

            int[] data = vector.ToArray();
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(fileName, json);
        }

        public static LinkListVector DeserializeLinkedListVector(string fileName)
        {
            string json = File.ReadAllText(fileName);
            int[] data = JsonSerializer.Deserialize<int[]>(json);

            if (data == null)
                throw new Exception("Не удалось восстановить LinkedListVector");

            LinkListVector vector = new LinkListVector(data.Length);

            for (int i = 0; i < data.Length; i++)
            {
                vector[i + 1] = data[i];
            }

            return vector;
        }
    }
}