using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealiseApp
{
    public class SortByValue : IComparer<ClassValueRmseAlg>
    {
        public int Compare(ClassValueRmseAlg ob1, ClassValueRmseAlg ob2)
        {
            ClassValueRmseAlg temp1 = (ClassValueRmseAlg)ob1;
            ClassValueRmseAlg temp2 = (ClassValueRmseAlg)ob2;
            if (temp1.Val > temp2.Val)
                return 1;
            else if (temp1.Val < temp2.Val)
                return -1;
            else
                return 0;
        }
    }
    public class ClassValueRmseAlg
    {
        public string NameAlg { get; set; }
        public double Val { get; set; }

        public ClassValueRmseAlg()
        {
            NameAlg = "none";
            Val = 0;
        }
        public ClassValueRmseAlg(string name, double vale)
        {
            NameAlg = name;
            Val = vale;
        }

    }
}
