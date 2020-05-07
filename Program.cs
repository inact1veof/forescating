using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealiseApp
{
    static class Program
    {
        public static DateTime date;
        public static double result1 = 0;
        public static double result2 = 0;
        public static double result3 = 0;
        public static double result4 = 0;
        public static double result5 = 0;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }
        public async static Task MainProd()
        {
            date = mainForm.inputData;
            await Task.Run(() =>
            {
                int number = logicClass.searchNumber(date);
                result1 = logicClass.Alg1logic(number);
                result2 = logicClass.Alg2logic(number);
                result3 = logicClass.Alg3logic(number);
                result5 = logicClass.Alg5Logic(number);
                result4 = logicClass.Alg4Logic(number);
                rmseClass.Init();
                rmseClass.searchRMSE();
                rmseClass.searchRMSE1();
                rmseClass.searchRMSE5();
                rmseClass.searchRMSE3();
                rmseClass.searchRMSE4();
            });
        }
    }
}
