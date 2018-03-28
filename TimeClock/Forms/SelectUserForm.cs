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
    public partial class SelectUserForm : Form
    {
        private bool passwordValid = false;

        private static StaffModel staffModel = new StaffModel();


        private static List<Button> buttons = new List<Button>();
        private static List<StaffModel> staff = new List<StaffModel>();
        private static Dictionary<Button, StaffModel> buttonStaff = new Dictionary<Button, StaffModel>();

        // used for clock
        Timer timer1 = new Timer();


        ShiftModel shift = new ShiftModel();


        public SelectUserForm()
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

            doClockStuff();
            
        }

        private void doClockStuff()
        {
            clockButton.Enabled = false;
            clockButton.ForeColor = Color.Black;
            clockButton.Paint += button_Paint;

            clockButton.FlatAppearance.BorderSize = 0;

            //clockButton.FlatAppearance.MouseOverBackColor = clockButton.BackColor;
            //clockButton.BackColorChanged += (s, e) =>
            //{
            //    clockButton.FlatAppearance.MouseOverBackColor = clockButton.BackColor;
            //};

            // Clock display
            this.clockButton.Text = DateTime.Now.ToString();
            timer1.Tick += new EventHandler(timer1_Tick);
            this.timer1.Interval = 1000;
            this.timer1.Enabled = true;
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

            for (int i = 0; i < buttons.Capacity; i ++)
            {
                x.Add(buttons[i], staff[i]);
                Button b = buttons[i];
                StaffModel s = staff[i];
                b.Text = ($"{s.name}");
                if(s.loggedIn == true)
                {
                    b.BackColor = Color.DodgerBlue;
                    b.ForeColor = Color.Ivory;
                }
            }
            return x;
        }


        private void validateStaff(Button but, StaffModel model)
        {
            NumPad numPad = new NumPad(model);
            numPad.ShowDialog();
            this.passwordValid = numPad.passwordValid;
            if (passwordValid == true)
            {
                //if logging in
                if (model.loggedIn == false)
                {
                    but.BackColor = Color.DodgerBlue;
                    but.ForeColor = Color.Ivory;
                    model.loggedIn = true;
                    GlobalConfig.Connection.Login(model);
                    
                    shift.StaffID = model.staffID;
                    shift.LoginTime = DateTime.Now;
                    shift.LogoutTime = null;
                    GlobalConfig.Connection.CreateShift(shift);
                }
                else
                //logging out
                {
                    LogoutForm lo = new LogoutForm(model);
                    this.TopMost = false;
                    lo.ShowDialog();
                    but.BackColor = Color.White;
                    but.ForeColor = Color.DodgerBlue;
                    model.loggedIn = false;
                    shift.LogoutTime = DateTime.Now;
                    shift.StaffID = model.staffID;
                    GlobalConfig.Connection.Logout(model);
                    GlobalConfig.Connection.LogoutShift(shift);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            staffModel = GlobalConfig.Connection.getStaffModel("Tania");           
            validateStaff(button1, staffModel);             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            staffModel = GlobalConfig.Connection.getStaffModel("Robert");
            validateStaff(button2, staffModel);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            staffModel = GlobalConfig.Connection.getStaffModel("Mary");
            validateStaff(button3, staffModel);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            staffModel = GlobalConfig.Connection.getStaffModel("Jenny");
            validateStaff(button4, staffModel);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            staffModel = GlobalConfig.Connection.getStaffModel("Jeremy");
            validateStaff(button5, staffModel);
        }


        private void button6_Click(object sender, EventArgs e)
        {
            staffModel = GlobalConfig.Connection.getStaffModel("Phill");
            validateStaff(button6, staffModel);
        }

       

        private void button7_Click(object sender, EventArgs e)
        {
            staffModel = GlobalConfig.Connection.getStaffModel("Guest");
            validateStaff(button7, staffModel);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            staffModel = GlobalConfig.Connection.getStaffModel("Admin");
            validateStaff(button8, staffModel);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AdminForm adf = new AdminForm(buttonStaff);
            adf.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.clockButton.Text = DateTime.Now.ToString();
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
