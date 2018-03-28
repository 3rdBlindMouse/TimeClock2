using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TimeClock.Models;

namespace TimeClock.Forms
{



    public partial class AdminForm : Form
    {

        private static Dictionary<Button, StaffModel> staffButts = new Dictionary<Button, StaffModel>();


        public AdminForm(Dictionary<Button, StaffModel> sb)
        {
            InitializeComponent();
            this.TopMost = true;
            staffButts = sb;

           
        }



        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminReserPasswordForm reset = new AdminReserPasswordForm(staffButts);
            
            reset.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

      


        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
