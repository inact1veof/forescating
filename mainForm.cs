using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace RealiseApp
{
    public partial class mainForm : MetroForm
    {
        public static int shet = 0;
        public static DateTime inputData;
        public mainForm()
        {
            InitializeComponent();
            InfluxDatabaseMethods.label = label1;
            logicClass.label = label2;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            //получаем пути
            Process p1 = new Process();
            p1.StartInfo = new ProcessStartInfo("influxd.exe");
            p1.StartInfo.CreateNoWindow = true;
            p1.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + @"\bin\visual\database\influx\";
            p1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p1.Start();
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("grafana-server.exe");
            p.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + @"\bin\visual\database\grafana\bin\";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }
        private async void metroButton1_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            DateTime temp = new DateTime();
            temp = inputDate.Value;
            int day = temp.Day;
            int mount = temp.Month;
            int year = temp.Year;
            string TempStr = inputHour.Text;
            string FinalStr = TempStr.Substring(0, 2);
            int hour = Convert.ToInt32(FinalStr)-1;
            DateTime data = new DateTime(year, mount, day, hour, 0, 0);
            string dayOfWeekly = data.DayOfWeek.ToString();
            inputData = data;           
            await Program.MainProd();
            label2.Visible = false;
            labelDailyName.Text = dayOfWeekly;
            labelRes1.Text = Program.result1.ToString();
            labelRes2.Text = Program.result2.ToString();
            labelRes3.Text = Program.result3.ToString();
            labelRes4.Text = Program.result4.ToString();
            labelRes5.Text = Program.result5.ToString();
            labelRmse1.Text = rmseClass.ValuesRMSE1[logicClass.day].ToString();
            labelRmse2.Text = rmseClass.ValuesRMSE2[logicClass.day].ToString();
            labelRmse3.Text = rmseClass.ValuesRMSE3[logicClass.day].ToString();
            labelRmse4.Text = rmseClass.ValuesRMSE4[logicClass.day].ToString();
            labelRmse5.Text = rmseClass.ValuesRMSE5[logicClass.day].ToString();
            string[] resultsBest = logicClass.SearchBestMethod();
            string BestAlg = null;
            if (dayOfWeekly == "Monday")
            {
                BestAlg = resultsBest[0];
            }
            else
            if (dayOfWeekly == "Tuesday")
            {
                BestAlg = resultsBest[1];
            }
            else
            if (dayOfWeekly == "Wednesday")
            {
                BestAlg = resultsBest[2];
            }
            else
            if (dayOfWeekly == "Thursday")
            {
                BestAlg = resultsBest[3];
            }
            else
            if (dayOfWeekly == "Friday")
            {
                BestAlg = resultsBest[4];
            }
            else
            if (dayOfWeekly == "Saturday")
            {
                BestAlg = resultsBest[5];
            }
            else
            if (dayOfWeekly == "Sunday")
            {
                BestAlg = resultsBest[6];
            }
            labelBestAlgName.Text = BestAlg;
            string bestAlgNameForDay = logicClass.SearchBestForConc(logicClass.day);
            bestAlgConc.Text = bestAlgNameForDay;
            label1.Visible = true;
            await InfluxDatabaseMethods.Init();
            label1.Text = "Логин: admin Пароль: admin";
            buttonOpenGrafana.Enabled = true;
            dataClass.Init();
            buttonStart.Enabled = true;
        }
        public void buttonInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Данные|*.xls; *.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine();
            }
            else
            {
                Environment.Exit(0);
            }
            Excel.Application ObjWorkExcel = new Excel.Application();
            Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(ofd.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            Excel.Worksheet ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1];
            var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
            string[,] list = new string[lastCell.Column, lastCell.Row];
            int iLastRow = ObjWorkSheet.Cells[ObjWorkSheet.Rows.Count, "A"].End[Excel.XlDirection.xlUp].Row;  //последняя заполненная строка в столбце А
            var arrData = (object[,])ObjWorkSheet.Range["A1:Z" + iLastRow].Value;
            ObjWorkExcel.Quit();
            dataClass.countOfElements = arrData.GetLength(0);
            dataClass.famousDates = new DateTime[dataClass.countOfElements];
            dataClass.famousValues = new double[dataClass.countOfElements];
            dataClass.countOfDays = dataClass.countOfElements / 24;
            fileStatusLabel.ForeColor = Color.Green;
            if (arrData != null || arrData[0, 0] != null)
            {                
                fileStatusLabel.Text = "Импорт файла успешен!";
            }
            else fileStatusLabel.Text = "Ошибка при импорте файла, попробуйте еще раз";
            for (int i = 0; i < dataClass.countOfElements; i++)
            {
                dataClass.famousValues[i] = Convert.ToDouble(arrData[i + 1, 2]);
            }
            for (int i = 0; i < dataClass.countOfElements; i++)
            {
                dataClass.famousDates[i] = Convert.ToDateTime(arrData[i + 1, 1]);
            }
            buttonStart.Enabled = true;
            buttonInput.Enabled = false;
        }

        private void inputHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonInput.Enabled = true;
        }

        private void labelRmse1_Click(object sender, EventArgs e)
        {

        }

        private void fileStatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void buttonOpenGrafana_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:3000/?orgId=1");
        }

        private void progressBar_identify_Click(object sender, EventArgs e)
        {

        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
