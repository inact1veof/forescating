namespace RealiseApp
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.inputDate = new System.Windows.Forms.DateTimePicker();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.inputHour = new System.Windows.Forms.ComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.buttonInput = new MetroFramework.Controls.MetroButton();
            this.buttonStart = new MetroFramework.Controls.MetroButton();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.buttonOpenGrafana = new MetroFramework.Controls.MetroButton();
            this.fileStatusLabel = new MetroFramework.Controls.MetroLabel();
            this.labelRes1 = new MetroFramework.Controls.MetroLabel();
            this.labelRes2 = new MetroFramework.Controls.MetroLabel();
            this.labelRes3 = new MetroFramework.Controls.MetroLabel();
            this.labelRes4 = new MetroFramework.Controls.MetroLabel();
            this.labelRes5 = new MetroFramework.Controls.MetroLabel();
            this.labelDailyName = new MetroFramework.Controls.MetroLabel();
            this.labelBestAlgName = new MetroFramework.Controls.MetroLabel();
            this.labelRmse1 = new MetroFramework.Controls.MetroLabel();
            this.labelRmse2 = new MetroFramework.Controls.MetroLabel();
            this.labelRmse3 = new MetroFramework.Controls.MetroLabel();
            this.labelRmse4 = new MetroFramework.Controls.MetroLabel();
            this.labelRmse5 = new MetroFramework.Controls.MetroLabel();
            this.bestAlgConc = new MetroFramework.Controls.MetroLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(645, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Данная программа предназначена для краткосрочного прогнозирования значений времен" +
    "ного ряда";
            this.metroLabel1.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 85);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(470, 19);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Для начала работы выберите дату, на которое спрогнозировать значение:";
            this.metroLabel2.Click += new System.EventHandler(this.metroLabel2_Click);
            // 
            // inputDate
            // 
            this.inputDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inputDate.Location = new System.Drawing.Point(494, 85);
            this.inputDate.MaxDate = new System.DateTime(2015, 12, 31, 23, 0, 0, 0);
            this.inputDate.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.inputDate.Name = "inputDate";
            this.inputDate.Size = new System.Drawing.Size(170, 22);
            this.inputDate.TabIndex = 2;
            this.inputDate.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Location = new System.Drawing.Point(-15, -15);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(16, 16);
            this.metroProgressSpinner1.TabIndex = 3;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(194, 119);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(378, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Укажите время, на которое необходимо составить прогноз:";
            // 
            // inputHour
            // 
            this.inputHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputHour.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputHour.FormattingEnabled = true;
            this.inputHour.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.inputHour.Location = new System.Drawing.Point(578, 119);
            this.inputHour.Name = "inputHour";
            this.inputHour.Size = new System.Drawing.Size(86, 24);
            this.inputHour.TabIndex = 5;
            this.inputHour.SelectedIndexChanged += new System.EventHandler(this.inputHour_SelectedIndexChanged);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(33, 173);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(348, 133);
            this.metroLabel4.TabIndex = 6;
            this.metroLabel4.Text = "Алгоритмы работы:\r\n1. Копирование значения предыдущего дня\r\n2. Копирование значен" +
    "ия такого же дня неделю назад\r\n3. Комбинация алгоритмов копирования\r\n4. Авторегр" +
    "ессия\r\n5. Метод \"10 из 10\"\r\n";
            this.metroLabel4.Click += new System.EventHandler(this.metroLabel4_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.Location = new System.Drawing.Point(458, 173);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(188, 23);
            this.metroLabel5.TabIndex = 7;
            this.metroLabel5.Text = "Выберите файл с данными:";
            this.metroLabel5.Click += new System.EventHandler(this.metroLabel5_Click);
            // 
            // buttonInput
            // 
            this.buttonInput.Enabled = false;
            this.buttonInput.Location = new System.Drawing.Point(458, 199);
            this.buttonInput.Name = "buttonInput";
            this.buttonInput.Size = new System.Drawing.Size(177, 56);
            this.buttonInput.TabIndex = 8;
            this.buttonInput.Text = "Выбрать файл";
            this.buttonInput.Click += new System.EventHandler(this.buttonInput_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(33, 390);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(631, 39);
            this.buttonStart.TabIndex = 9;
            this.buttonStart.Text = "Начать работу";
            this.buttonStart.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel6.Location = new System.Drawing.Point(784, 13);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(182, 25);
            this.metroLabel6.TabIndex = 10;
            this.metroLabel6.Text = "Результаты работы";
            // 
            // metroLabel7
            // 
            this.metroLabel7.Location = new System.Drawing.Point(697, 60);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(256, 283);
            this.metroLabel7.TabIndex = 11;
            this.metroLabel7.Text = resources.GetString("metroLabel7.Text");
            // 
            // buttonOpenGrafana
            // 
            this.buttonOpenGrafana.Enabled = false;
            this.buttonOpenGrafana.Location = new System.Drawing.Point(697, 390);
            this.buttonOpenGrafana.Name = "buttonOpenGrafana";
            this.buttonOpenGrafana.Size = new System.Drawing.Size(294, 39);
            this.buttonOpenGrafana.TabIndex = 12;
            this.buttonOpenGrafana.Text = "Посмотреть визуализацию";
            this.buttonOpenGrafana.Click += new System.EventHandler(this.buttonOpenGrafana_Click);
            // 
            // fileStatusLabel
            // 
            this.fileStatusLabel.BackColor = System.Drawing.Color.White;
            this.fileStatusLabel.ForeColor = System.Drawing.Color.Lime;
            this.fileStatusLabel.Location = new System.Drawing.Point(458, 287);
            this.fileStatusLabel.Name = "fileStatusLabel";
            this.fileStatusLabel.Size = new System.Drawing.Size(177, 56);
            this.fileStatusLabel.TabIndex = 13;
            this.fileStatusLabel.Click += new System.EventHandler(this.fileStatusLabel_Click);
            // 
            // labelRes1
            // 
            this.labelRes1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.labelRes1.Location = new System.Drawing.Point(772, 98);
            this.labelRes1.Name = "labelRes1";
            this.labelRes1.Size = new System.Drawing.Size(75, 25);
            this.labelRes1.TabIndex = 14;
            // 
            // labelRes2
            // 
            this.labelRes2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.labelRes2.Location = new System.Drawing.Point(773, 136);
            this.labelRes2.Name = "labelRes2";
            this.labelRes2.Size = new System.Drawing.Size(74, 29);
            this.labelRes2.TabIndex = 15;
            // 
            // labelRes3
            // 
            this.labelRes3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.labelRes3.Location = new System.Drawing.Point(774, 173);
            this.labelRes3.Name = "labelRes3";
            this.labelRes3.Size = new System.Drawing.Size(73, 26);
            this.labelRes3.TabIndex = 16;
            // 
            // labelRes4
            // 
            this.labelRes4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.labelRes4.Location = new System.Drawing.Point(774, 212);
            this.labelRes4.Name = "labelRes4";
            this.labelRes4.Size = new System.Drawing.Size(73, 23);
            this.labelRes4.TabIndex = 17;
            // 
            // labelRes5
            // 
            this.labelRes5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.labelRes5.Location = new System.Drawing.Point(773, 250);
            this.labelRes5.Name = "labelRes5";
            this.labelRes5.Size = new System.Drawing.Size(74, 27);
            this.labelRes5.TabIndex = 18;
            // 
            // labelDailyName
            // 
            this.labelDailyName.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.labelDailyName.Location = new System.Drawing.Point(784, 60);
            this.labelDailyName.Name = "labelDailyName";
            this.labelDailyName.Size = new System.Drawing.Size(127, 23);
            this.labelDailyName.TabIndex = 19;
            // 
            // labelBestAlgName
            // 
            this.labelBestAlgName.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.labelBestAlgName.Location = new System.Drawing.Point(959, 287);
            this.labelBestAlgName.Name = "labelBestAlgName";
            this.labelBestAlgName.Size = new System.Drawing.Size(117, 23);
            this.labelBestAlgName.TabIndex = 20;
            // 
            // labelRmse1
            // 
            this.labelRmse1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.labelRmse1.Location = new System.Drawing.Point(900, 98);
            this.labelRmse1.Name = "labelRmse1";
            this.labelRmse1.Size = new System.Drawing.Size(157, 23);
            this.labelRmse1.TabIndex = 21;
            this.labelRmse1.Click += new System.EventHandler(this.labelRmse1_Click);
            // 
            // labelRmse2
            // 
            this.labelRmse2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.labelRmse2.Location = new System.Drawing.Point(900, 136);
            this.labelRmse2.Name = "labelRmse2";
            this.labelRmse2.Size = new System.Drawing.Size(157, 23);
            this.labelRmse2.TabIndex = 22;
            // 
            // labelRmse3
            // 
            this.labelRmse3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.labelRmse3.Location = new System.Drawing.Point(900, 173);
            this.labelRmse3.Name = "labelRmse3";
            this.labelRmse3.Size = new System.Drawing.Size(159, 23);
            this.labelRmse3.TabIndex = 23;
            // 
            // labelRmse4
            // 
            this.labelRmse4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.labelRmse4.Location = new System.Drawing.Point(900, 212);
            this.labelRmse4.Name = "labelRmse4";
            this.labelRmse4.Size = new System.Drawing.Size(157, 23);
            this.labelRmse4.TabIndex = 24;
            // 
            // labelRmse5
            // 
            this.labelRmse5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.labelRmse5.Location = new System.Drawing.Point(900, 250);
            this.labelRmse5.Name = "labelRmse5";
            this.labelRmse5.Size = new System.Drawing.Size(159, 23);
            this.labelRmse5.TabIndex = 25;
            // 
            // bestAlgConc
            // 
            this.bestAlgConc.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.bestAlgConc.Location = new System.Drawing.Point(937, 328);
            this.bestAlgConc.Name = "bestAlgConc";
            this.bestAlgConc.Size = new System.Drawing.Size(139, 23);
            this.bestAlgConc.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(696, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 18);
            this.label1.TabIndex = 27;
            this.label1.Text = "Импорт данных в БД";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(231, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(433, 18);
            this.label2.TabIndex = 28;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 441);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bestAlgConc);
            this.Controls.Add(this.labelRmse5);
            this.Controls.Add(this.labelRmse4);
            this.Controls.Add(this.labelRmse3);
            this.Controls.Add(this.labelRmse2);
            this.Controls.Add(this.labelRmse1);
            this.Controls.Add(this.labelBestAlgName);
            this.Controls.Add(this.labelDailyName);
            this.Controls.Add(this.labelRes5);
            this.Controls.Add(this.labelRes4);
            this.Controls.Add(this.labelRes3);
            this.Controls.Add(this.labelRes2);
            this.Controls.Add(this.labelRes1);
            this.Controls.Add(this.fileStatusLabel);
            this.Controls.Add(this.buttonOpenGrafana);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonInput);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.inputHour);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroProgressSpinner1);
            this.Controls.Add(this.inputDate);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainForm";
            this.Padding = new System.Windows.Forms.Padding(30, 83, 30, 28);
            this.Resizable = false;
            this.Text = "Прогнозирование временных рядов";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.DateTimePicker inputDate;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.ComboBox inputHour;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton buttonInput;
        private MetroFramework.Controls.MetroButton buttonStart;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroButton buttonOpenGrafana;
        private MetroFramework.Controls.MetroLabel fileStatusLabel;
        private MetroFramework.Controls.MetroLabel labelRes1;
        private MetroFramework.Controls.MetroLabel labelRes2;
        private MetroFramework.Controls.MetroLabel labelRes3;
        private MetroFramework.Controls.MetroLabel labelRes4;
        private MetroFramework.Controls.MetroLabel labelRes5;
        private MetroFramework.Controls.MetroLabel labelDailyName;
        private MetroFramework.Controls.MetroLabel labelBestAlgName;
        private MetroFramework.Controls.MetroLabel labelRmse1;
        private MetroFramework.Controls.MetroLabel labelRmse2;
        private MetroFramework.Controls.MetroLabel labelRmse3;
        private MetroFramework.Controls.MetroLabel labelRmse4;
        private MetroFramework.Controls.MetroLabel labelRmse5;
        private MetroFramework.Controls.MetroLabel bestAlgConc;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
    }
}