using System;
using System.Text;
using System.Windows.Forms;
using TimeClock.Models;

namespace TimeClock
{
    public partial class NumPad : Form
    {

        int count = 0;
        private StringBuilder pass = new StringBuilder();
        StaffModel sm = new StaffModel();
        internal bool passwordValid;

        public NumPad(StaffModel staff)
        {
            sm = staff;
            InitializeComponent();
            nameLabel.Text = $"Welcome {sm.name}";
            this.TopMost = true;

            
        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            appendPass(1);
            fillInBoxes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            count++;
            appendPass(2);
            fillInBoxes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            count++;
            appendPass(3);
            fillInBoxes();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            count++;
            appendPass(4);
            fillInBoxes();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            count++;
            appendPass(5);
            fillInBoxes();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            count++;
            appendPass(6);
            fillInBoxes();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            count++;
            appendPass(7);
            fillInBoxes();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            count++;
            appendPass(8);
            fillInBoxes();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            count++;
            appendPass(9);
            fillInBoxes();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            count++;
            appendPass(0);
            fillInBoxes();
        }


        private void appendPass(int x)
        {
            pass.Append(x);
            welcomeLabel.Text = pass.Length.ToString();
            if(pass.Length == 4)
            {
                //if ((pass.ToString() == "1111") && (sm.pass == "1111"))
                    if (sm.pass == "$MYHASH$V1$10000$KEuCVy2zLizbwbYSFMYg9W7UMjJNGfhQStw9jtJLaWK3uCHz")
                    {
                    ChangePinNumPad newPin = new ChangePinNumPad(sm);
                    
                    newPin.ShowDialog();
                    this.Close();                     
                }
                else
                {
                    checkPasswordsMatch(pass);
                }
                
            }
        }

        private void checkPasswordsMatch(StringBuilder pass)
        {
            if(SecurePasswordHasher.Verify(pass.ToString(), sm.pass))
            {
                //MessageBox.Show("Success");
                
                this.Close();
                
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
            switch (count)
            {
                case 1:
                    displayButton1.Text = "#";
                   
                    break;
                case 2:
                    displayButton2 .Text = "#";
                    
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
            count--;
            if(pass.Length > 0)
            {
                pass.Length--;
            }
            else
            {
                
            }
            
            welcomeLabel.Text = pass.Length.ToString();
            if (count < 0)
            {
                count = 0;
            }

            switch (count)
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
    }
}
