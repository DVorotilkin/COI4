using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1_COI
{
    public partial class BrightCut : Form
    {
        Form1 main;
        int firstFlag,
            secondFlag;
        public BrightCut()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "от " + trackBar1.Value.ToString();
            if (trackBar1.Value >= trackBar2.Value)
            {
                trackBar2.Value = trackBar1.Value + 1;
                label2.Text = "до " + trackBar2.Value.ToString();
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "до " + trackBar2.Value.ToString();
            if (trackBar2.Value <= trackBar1.Value)
            {
                trackBar1.Value = trackBar2.Value - 1;
                label1.Text = "от " + trackBar1.Value.ToString();
            }
        }

        private void BrightCut_Load(object sender, EventArgs e)
        {
            main = this.Owner as Form1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main.isSeccessfullyForm(false);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            firstFlag = trackBar1.Value;
            secondFlag = trackBar2.Value;
            main.getBrightCut(firstFlag, secondFlag);
            main.isSeccessfullyForm(true);
            this.Close();
        }
    }
}
