using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeClock.Forms
{
    public partial class TimeTable : Form
    {

        

        private string[] days = new string[] { "", "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        private List<Button> buttonList = new List<Button>();

        public TimeTable()
        {
            InitializeComponent();
            this.TopMost = true;

        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if ((e.Column + e.Row) % 2 == 1)
                    e.Graphics.FillRectangle(Brushes.Black, e.CellBounds);
                else
                    e.Graphics.FillRectangle(Brushes.White, e.CellBounds);          
        }

        private void OnControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control != null)
            {
                // int column = tableLayoutPanel1.GetPositionFromControl(e.Control).Column;
                //int row = tableLayoutPanel1.GetPositionFromControl(e.Control).Row;
                // e.Control.Name = $"Button{buttonNumber}";
                // e.Control.Text = e.Control.Name;
                //e.Control.Margin = new System.Windows.Forms.Padding(0);
                //MessageBox.Show(string.Format("Column: {0}, Row: {1}", column, row));
                buttonList.Add((Button)(e.Control));
            }
        }
    }

}
