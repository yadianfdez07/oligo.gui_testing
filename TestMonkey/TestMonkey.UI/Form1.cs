using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMonkey.UI
{
    public partial class Form1 : Form
    {
        private StringBuilder smtInfo;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                button1.Text = "Start";
                SaveSmartInfo(smtInfo.ToString());
            }
            else
            {
                timer1.Enabled = true;
                button1.Text = "Stop";
                smtInfo = new StringBuilder();
            }
        }

        private void SaveSmartInfo(string info)
        {
            var fileToSave = @"C:\_tmp\smartInfo.csv";
            FileInfo fileInfo = new FileInfo(fileToSave);
            StreamWriter sw = fileInfo.CreateText();
            sw.Write(info);
            sw.Close();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = (int) numericUpDown1.Value * 1000;

            Random random = new Random();
            int x = random.Next();
            int y = random.Next();

            smtInfo.Append(x + ", " + y + ", ");

            MouseAPI.MoveMouse(this.Handle.ToInt32(), x, y);
            MouseAPI.ClickMouse(UI.MouseButtons.Right, 0, 0, 0, 0);
            MouseAPI.ClickMouse(UI.MouseButtons.Left, 0, 0, 0, 0);

            int wHdl = 0;
            StringBuilder clsName = new StringBuilder();
            StringBuilder wndText = new StringBuilder();

            MouseAPI.GetSmartInfo(ref wHdl, ref clsName, ref wndText);
            smtInfo.Append(wHdl + ", " + clsName.ToString() + ", " + wndText.ToString() + "\n");
        }
    }
}
