using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealiseApp
{
    public class SortByRmse : IComparer<CoefClass>
    {
        public int Compare(CoefClass ob1, CoefClass ob2)
        {
            CoefClass temp1 = (CoefClass)ob1;
            CoefClass temp2 = (CoefClass)ob2;
            if (temp1.ResultRmse > temp2.ResultRmse)
                return 1;
            else if (temp1.ResultRmse < temp2.ResultRmse)
                return -1;
            else
                return 0;
        }
    }
    public class CoefClass
    {
        public double Avalue { get; set; }
        public double Bvalue { get; set; }
        public double ResultRmse { get; set; }
        public double ResultAlgoritm { get; set; }

        public CoefClass(double Aval, double Bval, double Res, double Result)
        {
            Avalue = Aval;
            Bvalue = Bval;
            ResultRmse = Res;
            ResultAlgoritm = Result;
        }
        public CoefClass()
        {
            Avalue = 0;
            Bvalue = 0;
            ResultRmse = 0;
            ResultAlgoritm = 0;
        }
    }
}
