using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp24
{
    class VectorNormComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            IVectorable v1 = x as IVectorable;
            IVectorable v2 = y as IVectorable;
            if (v1 == null || v2 == null)
                throw new ArgumentException("Один из объектов не является вектором");

            return v1.GetNorm().CompareTo(v2.GetNorm());
        }
    }
}
