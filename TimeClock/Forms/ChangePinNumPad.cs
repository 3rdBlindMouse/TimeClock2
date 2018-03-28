using System;
using System.Text;
using System.Windows.Forms;
using TimeClock.Models;

namespace TimeClock
{
    public partial class ChangePinNumPad : Form
    {

        int numCount = 0;
        int pinSets = 0;
        StringBuilder pass = new StringBuilder();
        StaffModel sm = new StaffModel();
        internal bool passwordValid;

        public ChangePinNumPad(StaffModel staff)
        {
            sm = staff;
            InitializeComponent();
            nameLabel.Text = $"{sm.name} Enter A New Pin";
            this.TopMost = true;


        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numCount++;
            appendPass(1);
            fillInBoxes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numCount++;
            appendPass(2);
            fillInBoxes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numCount++;
            appendPass(3);
            fillInBoxes();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numCount++;
            appendPass(4);
            fillInBoxes();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numCount++;
            appendPass(5);
            fillInBoxes();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            numCount++;
            appendPass(6);
            fillInBoxes();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            numCount++;
            appendPass(7);
            fillInBoxes();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            numCount++;
            appendPass(8);
            fillInBoxes();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            numCount++;
            appendPass(9);
            fillInBoxes();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            numCount++;
            appendPass(0);
            fillInBoxes();
        }


        private void appendPass(int x)
        {
            pass.Append(x);
            welcomeLabel.Text = pass.Length.ToString();
            if (pass.Length == 4)
            {
                sm.pass = SecurePasswordHasher.Hash(pass.ToString());
                GlobalConfig.Connection.NewPassword(sm);
                this.Close();
            }
        }

        private void checkPasswordsMatch(StringBuilder pass)
        {
            if (SecurePasswordHasher.Verify(pass.ToString(), sm.pass))
            {
                //MessageBox.Show("Success");
                //LoginLogoutForm lf = new LoginLogoutForm(sm);
                this.Close();
                //lf.ShowDialog();
                passwordValid = true;
            }
            else
            {
                //MessageBox.Show("Fail");
                passwordValid = false;
            }

        }

        private void fillInBoxes()
        {
            switch (numCount)
            {
                case 1:
                    displayButton1.Text = "#";
                    break;
                case 2:
                    displayButton2.Text = "#";
                    break;
                case 3:
                    displayButton3.Text = "#";
                    break;
                case 4:
                    displayButton4.Text = "#";
                    break;


            }
        }


        private void unfillBoxes()
        {
            numCount--;
            if (numCount < 0)
            {
                numCount = 0;
            }

            switch (numCount)
            {

                case 0:
                    displayButton1.Text = "";
                    break;
                case 1:
                    displayButton2.Text = "";
                    break;
                case 2:
                    displayButton3.Text = "";
                    break;
                case 3:
                    displayButton4.Text = "";
                    break;


            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            unfillBoxes();
        }

        private void ChangePinNimPad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.FormOwnerClosing)
                this.Owner.Close();
        }

    }
}
