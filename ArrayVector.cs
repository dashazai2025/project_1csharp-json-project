using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.Json.Serialization;

namespace ConsoleApp24
{
    [Serializable] 
    public class ArrayVector : IVectorable, IComparable, ICloneable
    {
        public int[] coordinates { get; set; }

        public ArrayVector(int size)
        {
            if (size <= 0)
                throw new ArgumentException("Размер должен быть больше нуля");

            coordinates = new int[size];
        }

        public ArrayVector()
        {
            coordinates = new int[5];
        }

        [JsonConstructor]
        public ArrayVector(int[] coordinates)
        {
            this.coordinates = coordinates;
        }

        public int Length
        {
            get { return coordinates.Length; }
        }

        public int this[int i]
        {
            get
            {
                if (i < 1 || i > coordinates.Length)
                    throw new IndexOutOfRangeException("Индекс вне границ массива");
                return coordinates[i - 1];
            }
            set
            {
                if (i < 1 || i > coordinates.Length)
                    throw new IndexOutOfRangeException("Индекс вне границ массива");
                coordinates[i - 1] = value;
            }
        }

        public double GetNorm()
        {
            if (coordinates == null)
                throw new NullReferenceException("Массив не создан");

            if (coordinates.Length == 0)
                throw new InvalidOperationException("Массив пуст");

            double sum = 0;
            for (int i = 0; i < coordinates.Length; i++)
            {
                sum += coordinates[i] * coordinates[i];
            }
            return Math.Sqrt(sum);
        }

        public override string ToString()
        {
            return Length + " " + string.Join(" ", coordinates);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            IVectorable other = obj as IVectorable;
            if (other == null)
                return false;
            if (this.Length != other.Length)
                return false;
            for (int i = 1; i <= this.Length; i++)
            {
                if (this[i] != other[i])
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hash = Length;
            for (int i = 0; i < coordinates.Length; i++)
            {
                hash = hash * 31 + coordinates[i];
            }
            return hash;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            IVectorable other = obj as IVectorable;
            if (other == null)
                throw new ArgumentException("Объект не является вектором");

            return this.Length.CompareTo(other.Length);
        }

        public object Clone()
        {
            ArrayVector copy = new ArrayVector(this.Length);
            for (int i = 1; i <= this.Length; i++)
            {
                copy[i] = this[i];
            }
            return copy;
        }
    }
}

