using System.Collections.Generic;
using System.Windows.Forms;

namespace TimeClock.Forms
{
    partial class TimeTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Location = new System.Drawing.Point(223, 67);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);

            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;

            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);

            this.tableLayoutPanel1.ColumnCount = 8;
            int cc = this.tableLayoutPanel1.ColumnCount;

            for(int i = 0; i < cc; i ++)
            {
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / cc));
               // string buttonName = $"Button{i}";
               // tableLayoutPanel1.Controls.Add(new Button { Text = buttonName, Dock = DockStyle.Fill , AutoSize = true }, 0, 0);
                //tableLayoutPanel1.Controls.Add(new Button { Text = "Type:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 0);
                //Table.Controls.Add(new ComboBox { Dock = DockStyle.Fill }, 0, 1);
            }

            this.tableLayoutPanel1.RowCount = 65;
            int rc = this.tableLayoutPanel1.RowCount;

            for (int i = 0; i < rc; i++)
            {
                //this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / rc));
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50));
            }


            
            

            for (int i = 0; i < cc ; i++)
            {
                string hour = "7";
                string minutes = "00";

                for (int j = 0; j < rc ; j++)
                {
                   
                    if(j == 0)
                    {
                        hour = "";
                        minutes = "";
                    }
                   
                    tableLayoutPanel1.Controls.Add(new Button { Name = $"Button{days[i]}{hour}{minutes}", Text = $"{days[i]}{hour}{minutes}" , Margin = new System.Windows.Forms.Padding(0), Dock = DockStyle.Fill, AutoSize = true }, i, j);
                    //tableLayoutPanel1.ControlAdded += new ControlEventHandler(OnControlAdded);

                    if (hour == "")
                    {
                        hour = "7";
                        minutes = "00";
                    }
                    else
                    {

                        minutes = (int.Parse(minutes) + 15).ToString();
                        if (int.Parse(minutes) == 60)
                        {
                            hour = (int.Parse(hour) + 1).ToString();
                            minutes = "00";
                        }
                    }
                }
            }


            // 
            // TimeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.AutoScroll = true;
            



            //this.ClientSize = new System.Drawing.Size(664, 266);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TimeTable";
            this.Text = "TimeTable";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}