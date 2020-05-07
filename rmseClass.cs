using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealiseApp
{
    class rmseClass
    {
        public static DateTime[] rmseDates = null;
        //======Хранение данных о RMSE для каждого алгоритма===========================================|
        //====Алгоритм 1: копирование значения предыдущего дня

        public static double[] ValuesRMSE1 = null;

        //====Алгоритм 2: копирование значения того же дня неделю назад

        public static double[] ValuesRMSE2 = null;

        //====Алгоритм 3: комбинация алгоритма 1 и 2 (0.5 alg1 + 0.5 alg2)

        public static double[] ValuesRMSE3 = null;

        //====Алгоритм 4: авторегрессия

        public static double[] ValuesRMSE4 = null;

        //====Алгоритм 5: 10 из 10

        public static double[] ValuesRMSE5 = null;

        //=============================================================================================|
        public static void Init()
        {
            rmseDates = new DateTime[dataClass.countOfDays];
            for (int i = 0; i < dataClass.countOfDays; i++)
            {
                rmseDates[i] = new DateTime();
            }
            DateTime startDate = new DateTime(2015, 01, 01);
            rmseDates[0] = startDate;
            for (int i = 1; i < dataClass.countOfDays; i++)
            {
                rmseDates[i] = rmseDates[i - 1].AddDays(1);
            }
            ValuesRMSE1 = new double[dataClass.countOfDays];
            ValuesRMSE2 = new double[dataClass.countOfDays];
            ValuesRMSE3 = new double[dataClass.countOfDays];
            ValuesRMSE4 = new double[dataClass.countOfDays];
            ValuesRMSE5 = new double[dataClass.countOfDays];
        }
        //====Метод вычисления RMSE
        //==метод поиска rmse для одного значения
        public static double SearchRmseForOneRes(double RealValue, double ResValue)
        {
            double result = Math.Sqrt(Math.Pow((RealValue - ResValue), 2));
            return result;

        }

        public static void searchRMSE()
        {
            double temp = 0;
            double sum = 0;
            int count = 1;
            for (int i = 0; i < dataClass.hoursInDay - 1; i++)
            {
                sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog1[i]), 2);
            }
            temp = Math.Sqrt((sum / (dataClass.hoursInDay - 1)));
            ValuesRMSE1[0] = temp;
            sum = 0;
            temp = 0;
            //for (int i = 23; i < 47; i++)
            //{
            //    sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog1[i]), 2);
            //}
            //temp = Math.Sqrt((sum / (dataClass.hoursInDay)));
            //ValuesRMSE1[1] = temp;
            //sum = 0;
            //temp = 0;
            //for (int i = 47; i < 71; i++)
            //{
            //    sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog1[i]), 2);
            //}
            //temp = Math.Sqrt((sum / (dataClass.hoursInDay)));
            //ValuesRMSE1[2] = temp;
            //sum = 0;
            //temp = 0;
            //for (int i = 71; i < 95; i++)
            //{
            //    sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog1[i]), 2);
            //}
            //temp = Math.Sqrt((sum / (dataClass.hoursInDay)));
            //ValuesRMSE1[3] = temp;
            //sum = 0;
            //temp = 0;

            for (int j = 23; j < dataClass.countOfElements - (dataClass.hoursInDay+1); j += 24)
            {
                for (int i = j; i < j + 24; i++)
                {
                    sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog1[i]), 2);
                }
                temp = Math.Sqrt((sum / (dataClass.hoursInDay)));
                ValuesRMSE1[count] = temp;
                count++;
                sum = 0;
                temp = 0;
            }
        }
        public static void searchRMSE1()
        {
            double temp = 0;
            double sum = 0;
            int count = 1;
            for (int i = 0; i < dataClass.hoursInDay - 1; i++)
            {
                sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog2[i]), 2);
            }
            temp = Math.Sqrt((sum / (dataClass.hoursInDay - 1)));
            ValuesRMSE2[0] = temp;
            sum = 0;
            temp = 0;
            //for (int i = 23; i < 47; i++)
            //{
            //    sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog1[i]), 2);
            //}
            //temp = Math.Sqrt((sum / (dataClass.hoursInDay)));
            //ValuesRMSE1[1] = temp;
            //sum = 0;
            //temp = 0;
            //for (int i = 47; i < 71; i++)
            //{
            //    sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog1[i]), 2);
            //}
            //temp = Math.Sqrt((sum / (dataClass.hoursInDay)));
            //ValuesRMSE1[2] = temp;
            //sum = 0;
            //temp = 0;
            //for (int i = 71; i < 95; i++)
            //{
            //    sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog1[i]), 2);
            //}
            //temp = Math.Sqrt((sum / (dataClass.hoursInDay)));
            //ValuesRMSE1[3] = temp;
            //sum = 0;
            //temp = 0;

            for (int j = 23; j < dataClass.countOfElements - (dataClass.hoursInDay + 1); j += 24)
            {
                for (int i = j; i < j + 24; i++)
                {
                    sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog2[i]), 2);
                }
                temp = Math.Sqrt((sum / (dataClass.hoursInDay)));
                ValuesRMSE2[count] = temp;
                count++;
                sum = 0;
                temp = 0;
            }
        }
        public static void searchRMSE5()
        {
            double temp = 0;
            double sum = 0;
            int count = 1;
            for (int i = 0; i < dataClass.hoursInDay - 1; i++)
            {
                sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog5[i]), 2);
            }
            temp = Math.Sqrt((sum / (dataClass.hoursInDay - 1)));
            ValuesRMSE5[0] = temp;
            sum = 0;
            temp = 0;
            for (int j = 23; j < dataClass.countOfElements - (dataClass.hoursInDay + 1); j += 24)
            {
                for (int i = j; i < j + 24; i++)
                {
                    sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog5[i]), 2);
                }
                temp = Math.Sqrt((sum / (dataClass.hoursInDay)));
                ValuesRMSE5[count] = temp;
                count++;
                sum = 0;
                temp = 0;
            }
        }
        public static void searchRMSE3()
        {
            double temp = 0;
            double sum = 0;
            int count = 1;
            for (int i = 0; i < dataClass.hoursInDay - 1; i++)
            {
                sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog3[i]), 2);
            }
            temp = Math.Sqrt((sum / (dataClass.hoursInDay - 1)));
            ValuesRMSE3[0] = temp;
            sum = 0;
            temp = 0;
            //for (int i = 23; i < 47; i++)
            //{
            //    sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog1[i]), 2);
            //}
            //temp = Math.Sqrt((sum / (dataClass.hoursInDay)));
            //ValuesRMSE1[1] = temp;
            //sum = 0;
            //temp = 0;
            //for (int i = 47; i < 71; i++)
            //{
            //    sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog1[i]), 2);
            //}
            //temp = Math.Sqrt((sum / (dataClass.hoursInDay)));
            //ValuesRMSE1[2] = temp;
            //sum = 0;
            //temp = 0;
            //for (int i = 71; i < 95; i++)
            //{
            //    sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog1[i]), 2);
            //}
            //temp = Math.Sqrt((sum / (dataClass.hoursInDay)));
            //ValuesRMSE1[3] = temp;
            //sum = 0;
            //temp = 0;

            for (int j = 23; j < dataClass.countOfElements - (dataClass.hoursInDay + 1); j += 24)
            {
                for (int i = j; i < j + 24; i++)
                {
                    sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog3[i]), 2);
                }
                temp = Math.Sqrt((sum / (dataClass.hoursInDay)));
                ValuesRMSE3[count] = temp;
                count++;
                sum = 0;
                temp = 0;
            }
        }
        public static void searchRMSE4()
        {
            double temp = 0;
            double sum = 0;
            int count = 1;
            for (int i = 0; i < dataClass.hoursInDay - 1; i++)
            {
                sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog4[i]), 2);
            }
            temp = Math.Sqrt((sum / (dataClass.hoursInDay - 1)));
            ValuesRMSE4[0] = temp;
            sum = 0;
            temp = 0;
            //for (int i = 23; i < 47; i++)
            //{
            //    sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog1[i]), 2);
            //}
            //temp = Math.Sqrt((sum / (dataClass.hoursInDay)));
            //ValuesRMSE1[1] = temp;
            //sum = 0;
            //temp = 0;
            //for (int i = 47; i < 71; i++)
            //{
            //    sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog1[i]), 2);
            //}
            //temp = Math.Sqrt((sum / (dataClass.hoursInDay)));
            //ValuesRMSE1[2] = temp;
            //sum = 0;
            //temp = 0;
            //for (int i = 71; i < 95; i++)
            //{
            //    sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog1[i]), 2);
            //}
            //temp = Math.Sqrt((sum / (dataClass.hoursInDay)));
            //ValuesRMSE1[3] = temp;
            //sum = 0;
            //temp = 0;

            for (int j = 23; j < dataClass.countOfElements - (dataClass.hoursInDay + 1); j += 24)
            {
                for (int i = j; i < j + 24; i++)
                {
                    sum += Math.Pow((dataClass.famousValues[i] - logicClass.ValuesLog4[i]), 2);
                }
                temp = Math.Sqrt((sum / (dataClass.hoursInDay)));
                ValuesRMSE4[count] = temp;
                count++;
                sum = 0;
                temp = 0;
            }
        }
    }
}

