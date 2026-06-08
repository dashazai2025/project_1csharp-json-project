using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    public interface IVectorable
    {
        int Length { get; }
        int this[int i] { get; set; }
        double GetNorm();
    }
}

