using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using TimeClock.Forms;
using TimeClock;
using TimeClock.Models;
using System.Collections.Generic;

namespace TimeClock
{
    public partial class SelectUserForRoster : Form
    {
        //private bool passwordValid = false;

        //private static StaffModel staffModel = new StaffModel();


        private static List<Button> buttons = new List<Button>();
        private static List<StaffModel> staff = new List<StaffModel>();
        private static Dictionary<Button, StaffModel> buttonStaff = new Dictionary<Button, StaffModel>();

        // used for clock
        Timer timer1 = new Timer();


        ShiftModel shift = new ShiftModel();

        public StaffModel staffModel { get; internal set; }

        public SelectUserForRoster()
        {
            InitializeComponent();
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8 };
            staff = GlobalConfig.Connection.getStaff();

            buttonStaff = fillDictionary(buttons, staff);

            //TO DO Create Button/StaffModel Dict.           
            this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            IntPtr intPtr = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            EdgeGestureUtil.DisableEdgeGestures(intPtr, true);
        }       
        /// <summary>
        /// Populates Dictionary with Buttons as Keys and StaffModels as values
        /// Checks to see if staffModel is logged in and alters button colours accordingly
        /// </summary>
        /// <param name="buttons"></param>
        /// <param name="staff"></param>
        /// <returns></returns>
        private Dictionary<Button, StaffModel> fillDictionary(List<Button> buttons, List<StaffModel> staff)
        {
            var x = new Dictionary<Button, StaffModel>();

            for (int i = 0; i < buttons.Capacity; i++)
            {
                x.Add(buttons[i], staff[i]);
                Button b = buttons[i];
                StaffModel s = staff[i];
                b.Text = ($"-- { s.name} --");
                if (s.loggedIn == true)
                {
                    b.BackColor = Color.DodgerBlue;
                    b.ForeColor = Color.Ivory;
                }
            }
            return x;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            staffModel = GlobalConfig.Connection.getStaffModel("Tania");
            this.Close();

            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            staffModel = GlobalConfig.Connection.getStaffModel("Robert");
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            staffModel = GlobalConfig.Connection.getStaffModel("Mary");
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            staffModel = GlobalConfig.Connection.getStaffModel("Jenny");
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            staffModel = GlobalConfig.Connection.getStaffModel("Jeremy");
            this.Close();

        }


        private void button6_Click(object sender, EventArgs e)
        {
            staffModel = GlobalConfig.Connection.getStaffModel("Phill");
            this.Close();

        }



        private void button7_Click(object sender, EventArgs e)
        {
            staffModel = GlobalConfig.Connection.getStaffModel("Guest");
            this.Close();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            staffModel = GlobalConfig.Connection.getStaffModel("Admin");
            this.Close();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //AdminForm adf = new AdminForm();
            //adf.ShowDialog(staff);
        }

       
        void button_Paint(object sender, PaintEventArgs e)
        {
            dynamic btn = (Button)sender;
            dynamic drawBrush = new SolidBrush(btn.ForeColor);
            dynamic sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            btn.Text = string.Empty;
            e.Graphics.DrawString(DateTime.Now.ToString(), btn.Font, drawBrush, e.ClipRectangle, sf);
            drawBrush.Dispose();
            sf.Dispose();
        }
    }
}
