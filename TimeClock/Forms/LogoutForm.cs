using System;
using System.Diagnostics;
using System.Windows.Forms;
using TimeClock.Models;

namespace TimeClock.Forms
{
    public partial class LogoutForm : Form
    {
        private static StaffModel sm = new StaffModel();

        public LogoutForm(StaffModel model)
        {
            sm = model;
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_Enter_1(object sender, EventArgs e)
        {
            Process.Start(@"C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe");
            // this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe");
        }
    }
}
