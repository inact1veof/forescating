using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.ML;
using System.Collections.Immutable;
using System.Globalization;
using System.Runtime.InteropServices;
using RealiseAppML.Model;
using System.Windows.Forms;

namespace RealiseApp
{
    public static class logicClass
    {
        static public Label label = new Label();
        public static int day = 0;
        public static int numberOfDays = logicClass.searchNumber(Program.date);
        //======Хранение данных========================================================================|
        //====Алгоритм 1: копирование значения предыдущего дня

        public static DateTime[] DatesLog1 = null;
        public static double[] ValuesLog1 = null;

        //====Алгоритм 2: копирование значения того же дня неделю назад

        public static DateTime[] DatesLog2 = null;
        public static double[] ValuesLog2 = null;

        //====Алгоритм 3: комбинация алгоритма 1 и 2 (0.5 alg1 + 0.5 alg2)

        public static DateTime[] DatesLog3 = null;
        public static double[] ValuesLog3 = null;

        //====Алгоритм 4: авторегрессия

        public static DateTime[] DatesLog4 = null;
        public static double[] ValuesLog4 = null;

        //====Алгоритм 5: 10 из 10

        public static DateTime[] DatesLog5 = null;
        public static double[] ValuesLog5 = null;

        //=============================================================================================|
        //методы заполнения массивов

        // 1 - Определение номера дня (позиция в массиве)
        // 2 - Вычисление дня недели для номера
        // 3 - Реализация всех алгоритмов (в этом классе)
        // 4 - Функция для запуска прогона
        // 5 - Запись результатов в массив выше
        // 6 - Передача управления в RMSE
        public static int searchNumber(DateTime inputDate)
        {
            int outnumber = 0;
            DateTime firstDate = new DateTime(2015, 01, 01, 0, 00, 00);
            TimeSpan outDate = new TimeSpan();
            outDate = inputDate - firstDate;
            outnumber = (int)outDate.TotalHours;
            day = (int)(outnumber / 24);
            return outnumber;
        }
        #region Алгоритм 1
        public static double Alg1logic(int numberofDay)
        {
            DatesLog1 = new DateTime[dataClass.countOfElements];
            ValuesLog1 = new double[dataClass.countOfElements];
            double result = 0;
            for (int i = 0; i < dataClass.hoursInDay - 1; i++)
            {
                ValuesLog1[i] = 0;
            }
            for (int j = dataClass.hoursInDay; j < dataClass.countOfElements; j++)
            {
                ValuesLog1[j] = dataClass.famousValues[j - dataClass.hoursInDay];
            }
            result = ValuesLog1[numberofDay];
            return result;
        }
        #endregion
        #region Алгоритм 2
        public static double Alg2logic(int numberofDay)
        {
            DatesLog2 = new DateTime[dataClass.countOfElements];
            ValuesLog2 = new double[dataClass.countOfElements];
            double result = 0;
            for (int i = 0; i < (7 * dataClass.hoursInDay) - 1; i++)
            {
                ValuesLog2[i] = 0;
            }
            for (int j = (7 * dataClass.hoursInDay); j < dataClass.countOfElements; j++)
            {
                ValuesLog2[j] = dataClass.famousValues[j - (7 * dataClass.hoursInDay)];
            }
            result = ValuesLog2[numberofDay];
            return result;
        }
        #endregion
        #region Алгоритм 3
        public static double Alg3logic(int numberofDay)
        {
            double a = 0.5;
            double b = 0.5;
            DatesLog3 = new DateTime[dataClass.countOfElements];
            ValuesLog3 = new double[dataClass.countOfElements];
            double result = 0;
            for (int i = 0; i < dataClass.countOfElements; i++)
            {
                ValuesLog3[i] = a * ValuesLog1[i] + b * ValuesLog2[i];
            }
            CoefClass[] masRes = new CoefClass[6];
            for (int i = 0; i < 6; i++)
            {
                masRes[i] = new CoefClass();
            }
            double FixRmse = 100;
            double TempRmse = 99;
            for (int i = 0; i < dataClass.countOfElements; i++)
            {
                do
                {
                    if (TempRmse < FixRmse) FixRmse = TempRmse;
                    //=============================================================================================================
                    a += 0.01;
                    masRes[0].Avalue = a;
                    masRes[0].Bvalue = b;
                    masRes[0].ResultAlgoritm = a * ValuesLog1[i] + b * ValuesLog2[i];
                    masRes[0].ResultRmse = rmseClass.SearchRmseForOneRes(dataClass.famousValues[i], masRes[0].ResultAlgoritm);
                    //=============================================================================================================
                    b += -0.01;
                    masRes[1].Avalue = a;
                    masRes[1].Bvalue = b;
                    masRes[1].ResultAlgoritm = a * ValuesLog1[i] + b * ValuesLog2[i];
                    masRes[1].ResultRmse = rmseClass.SearchRmseForOneRes(dataClass.famousValues[i], masRes[1].ResultAlgoritm);
                    a += -0.01;
                    b += 0.01;
                    //=============================================================================================================
                    b += 0.01;
                    masRes[2].Avalue = a;
                    masRes[2].Bvalue = b;
                    masRes[2].ResultAlgoritm = a * ValuesLog1[i] + b * ValuesLog2[i];
                    masRes[2].ResultRmse = rmseClass.SearchRmseForOneRes(dataClass.famousValues[i], masRes[2].ResultAlgoritm);
                    b += -0.01;
                    //=============================================================================================================
                    b += -0.01;
                    masRes[3].Avalue = a;
                    masRes[3].Bvalue = b;
                    masRes[3].ResultAlgoritm = a * ValuesLog1[i] + b * ValuesLog2[i];
                    masRes[3].ResultRmse = rmseClass.SearchRmseForOneRes(dataClass.famousValues[i], masRes[3].ResultAlgoritm);
                    b += 0.01;
                    //=============================================================================================================
                    b += 0.01;
                    a += -0.01;
                    masRes[4].Avalue = a;
                    masRes[4].Bvalue = b;
                    masRes[4].ResultAlgoritm = a * ValuesLog1[i] + b * ValuesLog2[i];
                    masRes[4].ResultRmse = rmseClass.SearchRmseForOneRes(dataClass.famousValues[i], masRes[4].ResultAlgoritm);
                    b += -0.01;
                    //=============================================================================================================
                    masRes[5].Avalue = a;
                    masRes[5].Bvalue = b;
                    masRes[5].ResultAlgoritm = a * ValuesLog1[i] + b * ValuesLog2[i];
                    masRes[5].ResultRmse = rmseClass.SearchRmseForOneRes(dataClass.famousValues[i], masRes[5].ResultAlgoritm);
                    a += 0.01;
                    //===================================Подсчет результата========================================================
                    Array.Sort(masRes, new SortByRmse());
                    a = masRes[0].Avalue;
                    b = masRes[0].Bvalue;
                    TempRmse = masRes[0].ResultRmse;
                } while (TempRmse < FixRmse && Math.Abs(TempRmse) > 0.01);
                ValuesLog3[i] = masRes[0].ResultAlgoritm;
            }
            //for (int i = 0; i < dataClass.countOfElements; i++)
            //{
            //    ValuesLog3[i] = (a * ValuesLog1[i]) + (b * ValuesLog2[i]);
            //}
            result = ValuesLog3[numberofDay];
            return result;
        }
        #endregion
        #region Алгоритм 4
        public static double Alg4Logic(int numberOfDay)
        {
            int step = dataClass.countOfElements / 100;
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            DatesLog4 = new DateTime[dataClass.countOfElements];
            ValuesLog4 = new double[dataClass.countOfElements];
            for (int i = 0; i < dataClass.countOfElements; i++)
            {
                ModelInput input = new ModelInput()
                {
                    Alg1 = (float)logicClass.ValuesLog1[i],
                    Alg2 = (float)logicClass.ValuesLog2[i],
                    Alg3 = (float)logicClass.ValuesLog3[i],
                    Alg5 = (float)logicClass.ValuesLog5[i]
                };
                var prediction = ConsumeModel.Predict(input);
                ValuesLog4[i] = prediction.Score;
                label.Text = $"Выполняется вычисление значений алгоритмов (Выполнено {i/step}%)";
            }
            double result = 0;
            result = ValuesLog4[numberOfDay];
            return result;
        }
        #endregion
        #region Алгоритм 5
        public static double Alg5Logic(int numberOfDay)
        {
            double result = 0;
            DatesLog5 = new DateTime[dataClass.countOfElements];
            ValuesLog5 = new double[dataClass.countOfElements];
            double sum = 0;
            for (int i = 0; i < (10 * dataClass.hoursInDay); i++)
            {
                ValuesLog5[i] = 0;
            }
            for (int i = (10 * dataClass.hoursInDay); i < dataClass.countOfElements; i++)
            {
                for (int j = 1; j <= (10 * dataClass.hoursInDay); j++)
                {
                    sum += dataClass.famousValues[i - j];
                }
                ValuesLog5[i] = sum / (10 * dataClass.hoursInDay);
                sum = 0;
            }
            result = ValuesLog5[numberOfDay];
            return result;
        }
        #endregion

        #region Модель обучения
        public static string SearchDayOfWeek(int number)
        {
            string NameOfday;
            DateTime temp = new DateTime();
            temp = dataClass.famousDates[number];
            NameOfday = temp.DayOfWeek.ToString();
            return NameOfday;
        }
        public static string[] SearchBestMethod()
        {
            string[] NamesOfAlgs = new string[7];
            ClassValueRmseAlg[] AlgOneSumms = new ClassValueRmseAlg[7];
            ClassValueRmseAlg[] AlgTwoSumms = new ClassValueRmseAlg[7];
            ClassValueRmseAlg[] AlgThreeSumms = new ClassValueRmseAlg[7];
            ClassValueRmseAlg[] AlgFourSumms = new ClassValueRmseAlg[7];
            ClassValueRmseAlg[] AlgFiveSumms = new ClassValueRmseAlg[7];
            string[] names = new string[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            for (int i = 0; i < 7; i++)
            {
                AlgOneSumms[i] = new ClassValueRmseAlg();
                AlgTwoSumms[i] = new ClassValueRmseAlg();
                AlgThreeSumms[i] = new ClassValueRmseAlg();
                AlgFourSumms[i] = new ClassValueRmseAlg();
                AlgFiveSumms[i] = new ClassValueRmseAlg();
            }
            #region 1 алгоритм
            for (int i = 0; i < 7; i++)
            {
                AlgOneSumms[i].NameAlg = names[i];
            }
            for (int i =0; i < dataClass.countOfDays; i++)
            {
                if (SearchDayOfWeek(i) == "Monday")
                { 

                    AlgOneSumms[0].Val += rmseClass.ValuesRMSE1[i];
                }
                else
                if (SearchDayOfWeek(i) == "Tuesday")
                {
                    AlgOneSumms[1].Val += rmseClass.ValuesRMSE1[i];
                }
                else
                if (SearchDayOfWeek(i) == "Wednesday")
                {
                    AlgOneSumms[2].Val += rmseClass.ValuesRMSE1[i];
                }
                else
                if (SearchDayOfWeek(i) == "Thursday")
                {
                    AlgOneSumms[3].Val += rmseClass.ValuesRMSE1[i];
                }
                else
                if (SearchDayOfWeek(i) == "Friday")
                {
                    AlgOneSumms[4].Val += rmseClass.ValuesRMSE1[i];
                }
                else
                if (SearchDayOfWeek(i) == "Saturday")
                {
                    AlgOneSumms[5].Val += rmseClass.ValuesRMSE1[i];
                }
                else
                if (SearchDayOfWeek(i) == "Sunday")
                {
                    AlgOneSumms[6].Val += rmseClass.ValuesRMSE1[i];
                }           
            }
            #endregion
            #region 2 алгоритм
            for (int i = 0; i < 7; i++)
            {
                AlgTwoSumms[i].NameAlg = names[i];
            }
            for (int i = 0; i < dataClass.countOfDays; i++)
            {
                if (SearchDayOfWeek(i) == "Monday")
                {

                    AlgTwoSumms[0].Val += rmseClass.ValuesRMSE2[i];
                }
                else
                if (SearchDayOfWeek(i) == "Tuesday")
                {
                    AlgTwoSumms[1].Val += rmseClass.ValuesRMSE2[i];
                }
                else
                if (SearchDayOfWeek(i) == "Wednesday")
                {
                    AlgTwoSumms[2].Val += rmseClass.ValuesRMSE2[i];
                }
                else
                if (SearchDayOfWeek(i) == "Thursday")
                {
                    AlgTwoSumms[3].Val += rmseClass.ValuesRMSE2[i];
                }
                else
                if (SearchDayOfWeek(i) == "Friday")
                {
                    AlgTwoSumms[4].Val += rmseClass.ValuesRMSE2[i];
                }
                else
                if (SearchDayOfWeek(i) == "Saturday")
                {
                    AlgTwoSumms[5].Val += rmseClass.ValuesRMSE2[i];
                }
                else
                if (SearchDayOfWeek(i) == "Sunday")
                {
                    AlgTwoSumms[6].Val += rmseClass.ValuesRMSE2[i];
                }
            }
            #endregion
            #region 3 алгоритм
            for (int i = 0; i < 7; i++)
            {
                AlgThreeSumms[i].NameAlg = names[i];
            }
            for (int i = 0; i < dataClass.countOfDays; i++)
            {
                if (SearchDayOfWeek(i) == "Monday")
                {

                    AlgThreeSumms[0].Val += rmseClass.ValuesRMSE3[i];
                }
                else
                if (SearchDayOfWeek(i) == "Tuesday")
                {
                    AlgThreeSumms[1].Val += rmseClass.ValuesRMSE3[i];
                }
                else
                if (SearchDayOfWeek(i) == "Wednesday")
                {
                    AlgThreeSumms[2].Val += rmseClass.ValuesRMSE3[i];
                }
                else
                if (SearchDayOfWeek(i) == "Thursday")
                {
                    AlgThreeSumms[3].Val += rmseClass.ValuesRMSE3[i];
                }
                else
                if (SearchDayOfWeek(i) == "Friday")
                {
                    AlgThreeSumms[4].Val += rmseClass.ValuesRMSE3[i];
                }
                else
                if (SearchDayOfWeek(i) == "Saturday")
                {
                    AlgThreeSumms[5].Val += rmseClass.ValuesRMSE3[i];
                }
                else
                if (SearchDayOfWeek(i) == "Sunday")
                {
                    AlgThreeSumms[6].Val += rmseClass.ValuesRMSE3[i];
                }
            }
            #endregion
            #region 4 алгоритм
            for (int i = 0; i < 7; i++)
            {
                AlgFourSumms[i].NameAlg = names[i];
            }
            for (int i = 0; i < dataClass.countOfDays; i++)
            {
                if (SearchDayOfWeek(i) == "Monday")
                {

                    AlgFourSumms[0].Val += rmseClass.ValuesRMSE4[i];
                }
                else
                if (SearchDayOfWeek(i) == "Tuesday")
                {
                    AlgFourSumms[1].Val += rmseClass.ValuesRMSE4[i];
                }
                else
                if (SearchDayOfWeek(i) == "Wednesday")
                {
                    AlgFourSumms[2].Val += rmseClass.ValuesRMSE4[i];
                }
                else
                if (SearchDayOfWeek(i) == "Thursday")
                {
                    AlgFourSumms[3].Val += rmseClass.ValuesRMSE4[i];
                }
                else
                if (SearchDayOfWeek(i) == "Friday")
                {
                    AlgFourSumms[4].Val += rmseClass.ValuesRMSE4[i];
                }
                else
                if (SearchDayOfWeek(i) == "Saturday")
                {
                    AlgFourSumms[5].Val += rmseClass.ValuesRMSE4[i];
                }
                else
                if (SearchDayOfWeek(i) == "Sunday")
                {
                    AlgFourSumms[6].Val += rmseClass.ValuesRMSE4[i];
                }
            }
            #endregion
            #region 5 алгоритм
            for (int i = 0; i < 7; i++)
            {
                AlgFiveSumms[i].NameAlg = names[i];
            }
            for (int i = 0; i < dataClass.countOfDays; i++)
            {
                if (SearchDayOfWeek(i) == "Monday")
                {

                    AlgFiveSumms[0].Val += rmseClass.ValuesRMSE5[i];
                }
                else
                if (SearchDayOfWeek(i) == "Tuesday")
                {
                    AlgFiveSumms[1].Val += rmseClass.ValuesRMSE5[i];
                }
                else
                if (SearchDayOfWeek(i) == "Wednesday")
                {
                    AlgFiveSumms[2].Val += rmseClass.ValuesRMSE5[i];
                }
                else
                if (SearchDayOfWeek(i) == "Thursday")
                {
                    AlgFiveSumms[3].Val += rmseClass.ValuesRMSE5[i];
                }
                else
                if (SearchDayOfWeek(i) == "Friday")
                {
                    AlgFiveSumms[4].Val += rmseClass.ValuesRMSE5[i];
                }
                else
                if (SearchDayOfWeek(i) == "Saturday")
                {
                    AlgFiveSumms[5].Val += rmseClass.ValuesRMSE5[i];
                }
                else
                if (SearchDayOfWeek(i) == "Sunday")
                {
                    AlgFiveSumms[6].Val += rmseClass.ValuesRMSE5[i];
                }
            }
            #endregion
            #region Конвертация массивов
            ClassValueRmseAlg[] masMonday = new ClassValueRmseAlg[5];
            masMonday[0] = AlgOneSumms[0];
            masMonday[1] = AlgTwoSumms[0];
            masMonday[2] = AlgThreeSumms[0];
            masMonday[3] = AlgFourSumms[0];
            masMonday[4] = AlgFiveSumms[0];
            masMonday[0].NameAlg = "Алгоритм 1";
            masMonday[1].NameAlg = "Алгоритм 2";
            masMonday[2].NameAlg = "Алгоритм 3";
            masMonday[3].NameAlg = "Алгоритм 4";
            masMonday[4].NameAlg = "Алгоритм 5";
            ClassValueRmseAlg[] masTuesday = new ClassValueRmseAlg[5];
            masTuesday[0] = AlgOneSumms[1];
            masTuesday[1] = AlgTwoSumms[1];
            masTuesday[2] = AlgThreeSumms[1];
            masTuesday[3] = AlgFourSumms[1];
            masTuesday[4] = AlgFiveSumms[1];
            masTuesday[0].NameAlg = "Алгоритм 1";
            masTuesday[1].NameAlg = "Алгоритм 2";
            masTuesday[2].NameAlg = "Алгоритм 3";
            masTuesday[3].NameAlg = "Алгоритм 4";
            masTuesday[4].NameAlg = "Алгоритм 5";
            ClassValueRmseAlg[] masWednesday = new ClassValueRmseAlg[5];
            masWednesday[0] = AlgOneSumms[2];
            masWednesday[1] = AlgTwoSumms[2];
            masWednesday[2] = AlgThreeSumms[2];
            masWednesday[3] = AlgFourSumms[2];
            masWednesday[4] = AlgFiveSumms[2];
            masWednesday[0].NameAlg = "Алгоритм 1";
            masWednesday[1].NameAlg = "Алгоритм 2";
            masWednesday[2].NameAlg = "Алгоритм 3";
            masWednesday[3].NameAlg = "Алгоритм 4";
            masWednesday[4].NameAlg = "Алгоритм 5";
            ClassValueRmseAlg[] masThursday = new ClassValueRmseAlg[5];
            masThursday[0] = AlgOneSumms[3];
            masThursday[1] = AlgTwoSumms[3];
            masThursday[2] = AlgThreeSumms[3];
            masThursday[3] = AlgFourSumms[3];
            masThursday[4] = AlgFiveSumms[3];
            masThursday[0].NameAlg = "Алгоритм 1";
            masThursday[1].NameAlg = "Алгоритм 2";
            masThursday[2].NameAlg = "Алгоритм 3";
            masThursday[3].NameAlg = "Алгоритм 4";
            masThursday[4].NameAlg = "Алгоритм 5";
            ClassValueRmseAlg[] masFriday = new ClassValueRmseAlg[5];
            masFriday[0] = AlgOneSumms[4];
            masFriday[1] = AlgTwoSumms[4];
            masFriday[2] = AlgThreeSumms[4];
            masFriday[3] = AlgFourSumms[4];
            masFriday[4] = AlgFiveSumms[4];
            masFriday[0].NameAlg = "Алгоритм 1";
            masFriday[1].NameAlg = "Алгоритм 2";
            masFriday[2].NameAlg = "Алгоритм 3";
            masFriday[3].NameAlg = "Алгоритм 4";
            masFriday[4].NameAlg = "Алгоритм 5";
            ClassValueRmseAlg[] masSaturday = new ClassValueRmseAlg[5];
            masSaturday[0] = AlgOneSumms[5];
            masSaturday[1] = AlgTwoSumms[5];
            masSaturday[2] = AlgThreeSumms[5];
            masSaturday[3] = AlgFourSumms[5];
            masSaturday[4] = AlgFiveSumms[5];
            masSaturday[0].NameAlg = "Алгоритм 1";
            masSaturday[1].NameAlg = "Алгоритм 2";
            masSaturday[2].NameAlg = "Алгоритм 3";
            masSaturday[3].NameAlg = "Алгоритм 4";
            masSaturday[4].NameAlg = "Алгоритм 5";
            ClassValueRmseAlg[] masSunday = new ClassValueRmseAlg[5];
            masSunday[0] = AlgOneSumms[6];
            masSunday[1] = AlgTwoSumms[6];
            masSunday[2] = AlgThreeSumms[6];
            masSunday[3] = AlgFourSumms[6];
            masSunday[4] = AlgFiveSumms[6];
            masSunday[0].NameAlg = "Алгоритм 1";
            masSunday[1].NameAlg = "Алгоритм 2";
            masSunday[2].NameAlg = "Алгоритм 3";
            masSunday[3].NameAlg = "Алгоритм 4";
            masSunday[4].NameAlg = "Алгоритм 5";
            #endregion
            Array.Sort(masMonday, new SortByValue());
            Array.Sort(masTuesday, new SortByValue());
            Array.Sort(masWednesday, new SortByValue());
            Array.Sort(masThursday, new SortByValue());
            Array.Sort(masFriday, new SortByValue());
            Array.Sort(masSaturday, new SortByValue());
            Array.Sort(masSunday, new SortByValue());
            NamesOfAlgs[0] = masMonday[0].NameAlg;
            NamesOfAlgs[1] = masTuesday[0].NameAlg;
            NamesOfAlgs[2] = masWednesday[0].NameAlg;
            NamesOfAlgs[3] = masThursday[0].NameAlg;
            NamesOfAlgs[4] = masFriday[0].NameAlg;
            NamesOfAlgs[5] = masSaturday[0].NameAlg;
            NamesOfAlgs[6] = masSunday[0].NameAlg;
            return NamesOfAlgs;
        }

        public static string SearchBestForConc(int number)
        {
            string NameOfAlg = null;
            ClassValueRmseAlg[] Results = new ClassValueRmseAlg[5];
            for (int i = 0; i < 5; i++)
            {
                Results[i] = new ClassValueRmseAlg();
            }
            Results[0].NameAlg = "Алгоритм 1";
            Results[1].NameAlg = "Алгоритм 2";
            Results[2].NameAlg = "Алгоритм 3";
            Results[3].NameAlg = "Алгоритм 4";
            Results[4].NameAlg = "Алгоритм 5";
            Results[0].Val = rmseClass.ValuesRMSE1[number];
            Results[1].Val = rmseClass.ValuesRMSE2[number];
            Results[2].Val = rmseClass.ValuesRMSE3[number];
            Results[3].Val = rmseClass.ValuesRMSE4[number];
            Results[4].Val = rmseClass.ValuesRMSE5[number];
            Array.Sort(Results, new SortByValue());
            NameOfAlg = Results[0].NameAlg;
            return NameOfAlg;
        }
        #endregion
        //конец
    }
}
