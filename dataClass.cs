using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace RealiseApp
{
    class dataClass
    {
        //====================Раздел основных значений========================

        public const int hoursInDay = 24;
        public static int countOfElements = 0;
        public static int countOfDays = 0;

        //==========================================================
        public static DateTime[] famousDates = null;
        public static double[] famousValues = null;

        //методы инициализации и заполнения массивов
        [STAThread]
        public static void Init()
        {
            //string directory = @"C:\Games\file.txt";
            //using (StreamWriter print = File.CreateText(directory))
            //{
            //    for (int i = 0; i < dataClass.famousValues.Length; i++)
            //    {
            //        print.WriteLine(Convert.ToString(dataClass.famousValues[i]));
            //    }
            //}
        }

        //печать [временно]
        //public static void printDates()
        //{
        //    for (int i = 0; i < countOfElements; i++)
        //    {
        //        Console.WriteLine("Дата: {0} , Значение: {1}", famousDates[i], famousValues[i]);
        //    }            
        //}
        //конец
    }
}
