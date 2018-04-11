using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TimeClock.Models;

namespace TimeClock.Forms
{
    public partial class Roster : Form
    {
        private static List<Button> buttons = new List<Button>();

        private static List<Button> SunButtons = new List<Button>();
        private static List<Button> MonButtons = new List<Button>();
        private static List<Button> TueButtons = new List<Button>();
        private static List<Button> WedButtons = new List<Button>();
        private static List<Button> ThuButtons = new List<Button>();
        private static List<Button> FriButtons = new List<Button>();
        private static List<Button> SatButtons = new List<Button>();


        System.Drawing.Color staffColour = System.Drawing.Color.Transparent;

        public Roster()
        {
            InitializeComponent();
            this.TopMost = true;
        }



        private void Roster_Load(object sender, EventArgs e)
        {
            //var c = GetAll(this, typeof(Button));
            //MessageBox.Show("Total Controls: " + c.Count());
            //MessageBox.Show(SunButtons.Count.ToString());
            //MessageBox.Show(buttons.Count.ToString());
        }

 
        //https://stackoverflow.com/questions/3419159/how-to-get-all-child-controls-of-a-windows-forms-form-of-a-specific-type-button#answer-3426721
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();


            
            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }



        void MyButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;

            List<Button> buttonList = getButtonList(button);
            int indexOfValue = buttonList.IndexOf(button);
            //MessageBox.Show(indexOfValue.ToString());

           

            MessageBox.Show(button.Name);
            SelectUserForRoster rosterUsers = new SelectUserForRoster();
            rosterUsers.ShowDialog();

            StaffModel model = rosterUsers.staffModel;

            staffColour = DoStaffStuff(model);

            for (int i = 0; i < 4; i++)
            {
                Button b = buttonList[indexOfValue + i];
                b.BackColor = staffColour;
            }

        }

        private System.Drawing.Color DoStaffStuff(StaffModel model)
        {
           // MessageBox.Show(model.name);
            switch (model.name)
            {
                case "Tania":
                    staffColour = System.Drawing.Color.Chartreuse;
                    break;
                case "Robert":
                    staffColour = System.Drawing.Color.Tomato;
                    break;
                case "Mary":
                    staffColour = System.Drawing.Color.Turquoise;
                    break;
                case "Jenny":
                    staffColour = System.Drawing.Color.Violet;
                    break;
                case "Jeremy":
                    staffColour = System.Drawing.Color.Purple;
                    break;
                case "Phill":
                    staffColour = System.Drawing.Color.Yellow;
                    break;
                case "Guest":
                    staffColour = System.Drawing.Color.Pink;
                    break;
                case "Admin":
                    staffColour = System.Drawing.Color.PeachPuff;
                    break;

            }
            return staffColour;
        }

        private List<Button> getButtonList(Button button)
        {
            List<Button> output = new List<Button>();

            string daySubString = button.Text.Substring(0, 3);

            switch (daySubString)
            {
                case "Sun":
                    output = SunButtons;
                    break;
                case "Mon":
                    output = MonButtons;
                    break;
                case "Tue":
                    output = TueButtons;
                    break;
                case "Wed":
                    output = WedButtons;
                    break;
                case "Thu":
                    output = ThuButtons;
                    break;
                case "Fri":
                    output = FriButtons;
                    break;
                case "Sat":
                    output = SatButtons;
                    break;
            }

            return output;
        }

        private void button521_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
