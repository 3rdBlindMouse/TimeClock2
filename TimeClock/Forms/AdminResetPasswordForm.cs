using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using TimeClock.Forms;
using TimeClock;
using TimeClock.Models;
using System.Collections.Generic;
using System.Linq;

namespace TimeClock
{
    public partial class AdminReserPasswordForm : Form
    {

        private static Dictionary<Button, StaffModel> staffButts = new Dictionary<Button, StaffModel>();
        List<StaffModel> staff = new List<StaffModel>();
        List<Button> buttons = new List<Button>();

        public AdminReserPasswordForm(Dictionary<Button, StaffModel> sb)
        {
            InitializeComponent();
            this.TopMost = true;
            staffButts = sb;
            fillButtons(staffButts);
        }

        private void fillButtons(Dictionary<Button, StaffModel> staffButts)
        {
            staff = new List<StaffModel>();
            buttons = new List<Button>();


            foreach (KeyValuePair<Button, StaffModel> kvp in staffButts)
            {
                buttons.Add(kvp.Key);
                staff.Add(kvp.Value);
            }



            for (int i = 0; i < buttons.Capacity; i++)
            {
                buttons[i].Text = ($"{staff[i].name}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetPassword(sender);                       
        }

        private void ResetPassword(object sender)
        {
            StaffModel s = new StaffModel();
            Button b = sender as Button;

            // ************************************************ //
            //TODO figure out why i couldnt just use b as the Key

            // MessageBox.Show($"{b} + {b.GetType()}");
            foreach (KeyValuePair<Button, StaffModel> kvp in staffButts)
            {
                if (kvp.Key.Text == b.Text)
                {
                    s = kvp.Value;
                    GlobalConfig.Connection.ResetPassword(s);
                    MessageBox.Show($"Password for {s.name} Reset");
                }
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetPassword(sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetPassword(sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetPassword(sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ResetPassword(sender);
        }


        private void button6_Click(object sender, EventArgs e)
        {
            ResetPassword(sender);
        }



        private void button7_Click(object sender, EventArgs e)
        {
            ResetPassword(sender);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ResetPassword(sender);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
