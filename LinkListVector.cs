using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace ConsoleApp24
{
    [Serializable]
    public class LinkListVector : IVectorable, IComparable, ICloneable
    {
        private class Node
        {
            public int value = 0;
            public Node next = null;
        }

        private Node head;

        public LinkListVector(int n)
        {
            if (n <= 0)
                throw new Exception("Неправильный формат");
            for (int i = 0; i < n; i++)
                AddEnd(0);

        }

        public LinkListVector() : this(5) { }

        public int Length
        {
            get
            {
                int count = 0;
                Node currentNode = head;
                while (currentNode != null)
                {
                    count++;
                    currentNode = currentNode.next;
                }
                return count;
            }
        }

        public int this[int i]
        {
            get
            {
                if (i < 1 || i > Length)
                    throw new IndexOutOfRangeException();
                Node t = head;
                for (int k = 1; k < i; k++)
                    t = t.next;
                return t.value;
            }
            set
            {
                if (i < 1 || i > Length)
                    throw new IndexOutOfRangeException();
                Node t = head;
                for (int k = 1; k < i; k++)
                    t = t.next;
                t.value = value;
            }
        }
        public double GetNorm()
        {
            double s = 0;
            Node t = head;
            while (t != null)
            {
                s += t.value * t.value;
                t = t.next;
            }
            return Math.Sqrt(s);
        }
        public void AddEnd(int x)
        {
            Node n = new Node();
            n.value = x;
            if (head == null)
                head = n;
            else
            {
                Node t = head;
                while (t.next != null)
                    t = t.next;
                t.next = n;
            }
        }

        public override string ToString()
        {
            string result = Length + " ";
            Node t = head;

            while (t != null)
            {
                result += t.value + " ";
                t = t.next;
            }

            return result.Trim();
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
            for (int i = 1; i <= this.Length; i++)
            {
                hash = hash * 31 + this[i];
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
            LinkListVector copy = new LinkListVector(this.Length);
            for (int i = 1; i <= this.Length; i++)
            {
                copy[i] = this[i];
            }
            return copy;
        }

        public int[] ToArray()
        {
            int[] arr = new int[Length];
            Node t = head;
            int i = 0;

            while (t != null)
            {
                arr[i] = t.value;
                t = t.next;
                i++;
            }

            return arr;
        }
    }
}