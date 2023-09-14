using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Работа3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form frmNew = new Form();
        int minHeight = 500;
        int minWidth = 500;
        MenuStrip mnuMain = new MenuStrip();
        ToolStripMenuItem mnuStartRun = new ToolStripMenuItem();
        ToolStripMenuItem mnuStart = new ToolStripMenuItem();
        ToolStripMenuItem mnuStartReset = new ToolStripMenuItem();
        ToolStripMenuItem mnuFile = new ToolStripMenuItem();
        ToolStripMenuItem mnuHelp = new ToolStripMenuItem();
        ToolStripMenuItem mnuHelpShow = new ToolStripMenuItem();
        ListBox lstBox = new ListBox();
        Button btnRes = new Button();
        double[] Arr = new double[4];
        double[] ArrY = new double[4];

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Resize += FrmMain_Resize;
            mnuStartRun.Click += StartRun;
            mnuStart.DropDownItems.Add(mnuStartRun);
            mnuStartReset.Click += StartReset;
            mnuStartReset.Enabled = false;
            mnuStart.DropDownItems.Add(mnuStartReset);
            mnuFile.DropDownItems.Add(mnuStart);
            mnuHelp.DropDownItems.Add(mnuHelpShow);
            mnuMain.Items.Add(mnuFile);
            mnuHelp.Visible = false;
            mnuMain.Items.Add(mnuHelp);
            mnuMain.Parent = this;
            mnuHelpShow.Click += HelpShow;
            frmNew.Load += FrmNew_Load;
            btnRes.Click += BtnRes;

            
            mnuFile.Text = "Файл";
            mnuStart.Text = "Старт";
            mnuStartRun.Text = "Начало работы";
            mnuStartReset.Text = "Сброс";
            mnuHelp.Text = "Справка";
            mnuHelpShow.Text = "Показать справку";

            
            btnRes.Name = "btnRes";
            btnRes.Text = "Выполнить";
            btnRes.Height = 30;
            btnRes.Width = 80;
            btnRes.Parent = this;
            btnRes.Visible = false;

            
            Width = minWidth;
            Height = minHeight;
            Repositioning();

            
            lstBox.Visible = false;
            lstBox.Top = 30;
            lstBox.Left = 30;
            lstBox.Height = Height - 90; 
            lstBox.Width = Width - 70; 
            lstBox.Parent = this;
            
            string[] lstElms = { "Первый", "Второй", "Третий", "Четвертый", "Пятый", "Шестой", "Седьмой", "Восьмой", "Девятый", "Десятый", "Одиннадцатый" };
            
            foreach (string str in lstElms) { lstBox.Items.Add(str); }
        }

        private void Repositioning() 
        {
            btnRes.Left = Width / 2 - 50;
            btnRes.Top = Height / 2 + 90;
            lstBox.Left = btnRes.Left - 170;
            lstBox.Top = btnRes.Top - 310;
        }
        private void BtnRes(object sender, EventArgs e)
        {
            Read();
            int index = lstBox.SelectedIndex;
            switch (index)
            {
                case 0:
                    for (int i = 0; i < Arr.Length; i++)
                    {
                        Arr[i] = Math.Tan(Arr[i] * Math.PI / 180);
                        Res();
                    }
                    break;
                case 1:
                    for (int i = 0; i < Arr.Length; i++)
                    {
                        Arr[i] = Math.Log(Arr[i], 2);
                        Res();
                    }
                    break;
                case 2:
                    for (int i = 0; i < Arr.Length; i++)
                    {
                        Arr[i] = Math.Log10(Arr[i]);
                        Res();
                    }
                    break;
                case 3:
                    for (int i = 0; i < Arr.Length; i++)
                    {
                        Arr[i] = Math.Log(Arr[i]) / Arr[i];
                        Res();
                    }
                    break;
                case 4:
                    for (int i = 0; i < Arr.Length; i++)
                    {
                        Arr[i] = Math.Log(Arr[i]);
                        Res();
                    }
                    break;
                case 5:
                    for (int i = 0; i < Arr.Length; i++)
                    {
                        Arr[i] = Math.Sin(Arr[i] * Math.PI / 180);
                        Res();
                    }
                    break;
                case 6:
                    for (int i = 0; i < Arr.Length; i++)
                    {
                        Arr[i] = Math.Atan(Arr[i] * Math.PI / 180);
                        Res();
                    }
                    break;
                case 7:
                    for (int i = 0; i < Arr.Length; i++)
                    {
                        Arr[i] = Math.Acos(Arr[i] * Math.PI / 180);
                        Res();
                    }
                    break;
                case 8:
                    for (int i = 0; i < Arr.Length; i++)
                    {
                        Arr[i] = Math.Sqrt(Arr[i]);
                        Res();
                    }
                    break;
                case 9:
                    for (int i = 0; i < Arr.Length; i++)
                    {
                        Arr[i] = Arr[i] * Arr[i];
                        Res();
                    }
                    break;
                case 10:
                    for (int i = 0; i < Arr.Length; i++)
                    {
                        Arr[i] = Math.Cos(Arr[i] * Math.PI / 180);
                        Res();
                    }
                    break;
            }
        }

        private void FrmNew_Load(object sender, EventArgs e)
        {
            frmNew.FormBorderStyle = FormBorderStyle.FixedSingle; 

        frmNew.Width = 500;
            frmNew.Height = 500;
            frmNew.Text = "Справка";
            frmNew.Name = "frmNew";
            Spravka();
        }

        private void HelpShow(object sender, EventArgs e) => frmNew.ShowDialog();
        private void StartReset(object sender, EventArgs e)
        {
            mnuStartReset.Enabled = true;
            btnRes.Visible = false;
            mnuHelp.Visible = false;
            lstBox.Visible = false;
        }

        private void StartRun(object sender, EventArgs e)
        {
            mnuStartReset.Enabled = true;
            mnuHelp.Visible = true;
            btnRes.Visible = true;
            lstBox.Visible = true;
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            Repositioning();
            if (Height < minHeight) { Height = minHeight; }
            if (Width < minWidth) { Width = minWidth; }
        }

        public void Res()
        {
            StreamWriter sw = new StreamWriter("D:\\Результат.txt");
            for (int i = 0; i < Arr.Length; i++)
            {
                sw.WriteLine(ArrY[i] + " ; " + Arr[i]);
            }
            sw.Close();
        }
        public void Read()
        {
            using (Stream stream = new FileStream(@"D:\Данные.txt", FileMode.Open))
            using (TextReader reader = new StreamReader(stream))
            {
                string contents = reader.ReadToEnd();
                contents = contents.Replace("{", "").Replace("}", "");
                var values = new List<double>();
                foreach (string s in contents.Split(','))
                {
                    try
                    {
                        values.Add(double.Parse(s));
                    }
                    catch (FormatException fe)
                    {
                        
                    }
                    catch (OverflowException oe)
                    {
                        
                    }
                }
                for (int i = 0; i < values.Count; i++)
                {
                    Arr[i] = values[i];
                    ArrY[i] = values[i];
                }
            }
        }
        public void Spravka() 
        {
            TextBox Spravka = new TextBox();
            Spravka.ReadOnly = true;
            frmNew.Controls.Add(Spravka);
            Spravka.Dock = System.Windows.Forms.DockStyle.Fill;
            Spravka.Multiline = true;
            Spravka.Text = "info";
            Spravka.Show();
        }

        
    }
}
