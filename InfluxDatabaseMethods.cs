using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdysTech.InfluxDB.Client.Net;
using InfluxDB.Net;
using InfluxDB.Net.Models;
using InfluxDB.Net.Enums;
using Microsoft.Office.Core;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace RealiseApp
{
    public class InfluxDatabaseMethods
    {
        static public Label label = new Label();
        async public static Task Init()
        {
            int count2 = dataClass.countOfElements / 100;
            int count = ((dataClass.countOfDays+100)/100);
         //====================================================================================Коннект в бд============
            string nameDB = "Process";
            InfluxDBClient client = new InfluxDBClient("http://localhost:8086", "root", "root");
            await client.CreateDatabaseAsync(nameDB);
            InfluxDatabase name = new InfluxDatabase(nameDB);
            var m = await client.DropDatabaseAsync(name);
            await client.CreateDatabaseAsync(nameDB);
            for (int i = 0; i < dataClass.countOfDays; i++)
            {
                var valMixed1 = new InfluxDatapoint<InfluxValueField>();
                var valMixed2 = new InfluxDatapoint<InfluxValueField>();
                var valMixed3 = new InfluxDatapoint<InfluxValueField>();
                var valMixed4 = new InfluxDatapoint<InfluxValueField>();
                var valMixed5 = new InfluxDatapoint<InfluxValueField>();
                valMixed1.UtcTimestamp = rmseClass.rmseDates[i].ToUniversalTime();
                valMixed2.UtcTimestamp = rmseClass.rmseDates[i].ToUniversalTime();
                valMixed3.UtcTimestamp = rmseClass.rmseDates[i].ToUniversalTime();
                valMixed4.UtcTimestamp = rmseClass.rmseDates[i].ToUniversalTime();
                valMixed5.UtcTimestamp = rmseClass.rmseDates[i].ToUniversalTime();
                valMixed1.MeasurementName = "RmseValuesForAlgOne";
                valMixed2.MeasurementName = "RmseValuesForAlgTwo";
                valMixed3.MeasurementName = "RmseValuesForAlgThree";
                valMixed4.MeasurementName = "RmseValuesForAlgFour";
                valMixed5.MeasurementName = "RmseValuesForAlgFive";
                double[] values = new double[5];
                values[0] = rmseClass.ValuesRMSE1[i];
                values[1] = rmseClass.ValuesRMSE2[i];
                values[2] = rmseClass.ValuesRMSE3[i];
                values[3] = rmseClass.ValuesRMSE4[i];
                values[4] = rmseClass.ValuesRMSE5[i];
                valMixed1.Fields.Add("value", new InfluxValueField(values[0]));
                valMixed2.Fields.Add("value", new InfluxValueField(values[1]));
                valMixed3.Fields.Add("value", new InfluxValueField(values[2]));
                valMixed4.Fields.Add("value", new InfluxValueField(values[3]));
                valMixed5.Fields.Add("value", new InfluxValueField(values[4]));
                var r = await client.PostPointAsync(nameDB, valMixed1);
                var s = await client.PostPointAsync(nameDB, valMixed2);
                var t = await client.PostPointAsync(nameDB, valMixed3);
                var u = await client.PostPointAsync(nameDB, valMixed4);
                var f = await client.PostPointAsync(nameDB, valMixed5);
                label.Text = $"Запись значений RMSE (Выполнено {i/count}%)";
            }  
            for (int i = 0; i < dataClass.countOfElements; i++)
            {
                var valMixed6 = new InfluxDatapoint<InfluxValueField>();
                var valMixed7 = new InfluxDatapoint<InfluxValueField>();
                var valMixed8 = new InfluxDatapoint<InfluxValueField>();
                var valMixed9 = new InfluxDatapoint<InfluxValueField>();
                var valMixed10 = new InfluxDatapoint<InfluxValueField>();
                var valMixed11 = new InfluxDatapoint<InfluxValueField>();
                valMixed6.UtcTimestamp = dataClass.famousDates[i].ToUniversalTime();
                valMixed7.UtcTimestamp = dataClass.famousDates[i].ToUniversalTime();
                valMixed8.UtcTimestamp = dataClass.famousDates[i].ToUniversalTime();
                valMixed9.UtcTimestamp = dataClass.famousDates[i].ToUniversalTime();
                valMixed10.UtcTimestamp = dataClass.famousDates[i].ToUniversalTime();
                valMixed11.UtcTimestamp = dataClass.famousDates[i].ToUniversalTime();
                valMixed6.MeasurementName = "ValuesOne";
                valMixed7.MeasurementName = "ValuesTwo";
                valMixed8.MeasurementName = "ValuesThree";
                valMixed9.MeasurementName = "ValuesFour";
                valMixed10.MeasurementName = "ValuesFive";
                valMixed11.MeasurementName = "FamousValues";
                double[] values1 = new double[6];
                values1[0] = logicClass.ValuesLog1[i];
                values1[1] = logicClass.ValuesLog2[i];
                values1[2] = logicClass.ValuesLog3[i];
                values1[3] = logicClass.ValuesLog4[i];
                values1[4] = logicClass.ValuesLog5[i];
                values1[5] = dataClass.famousValues[i];
                valMixed6.Fields.Add("value", new InfluxValueField(values1[0]));
                valMixed7.Fields.Add("value", new InfluxValueField(values1[1]));
                valMixed8.Fields.Add("value", new InfluxValueField(values1[2]));
                valMixed9.Fields.Add("value", new InfluxValueField(values1[3]));
                valMixed10.Fields.Add("value", new InfluxValueField(values1[4]));
                valMixed11.Fields.Add("value", new InfluxValueField(values1[5]));
                var r1 = await client.PostPointAsync(nameDB, valMixed6);
                var s1 = await client.PostPointAsync(nameDB, valMixed7);
                var t1 = await client.PostPointAsync(nameDB, valMixed8);
                var u1 = await client.PostPointAsync(nameDB, valMixed9);
                var f1 = await client.PostPointAsync(nameDB, valMixed10);
                var f2 = await client.PostPointAsync(nameDB, valMixed11);
                label.Text = $"Запись значений алгоритмов (Выполнено {i/count2}%)";
            }
        }
    }
}
