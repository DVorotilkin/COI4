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
    public partial class ContrastScalingDialog : Form
    {
        int coofScalling;
        int firstFlag;
        int secondFlag;
        Form1 main;

        public ContrastScalingDialog()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            coofScalling = trackBar1.Value;
            firstFlag = trackBar2.Value;
            secondFlag = trackBar3.Value;
            main.getContrastScalingPar(coofScalling, firstFlag, secondFlag);
            main.isSeccessfullyForm(true);
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main.isSeccessfullyForm(false);
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                trackBar2.Enabled = true;
                trackBar3.Enabled = true;
                label2.Enabled = true;
                label3.Enabled = true;
            }
            else
            {

                trackBar2.Enabled = false;
                trackBar3.Enabled = false;
                label2.Enabled = false;
                label3.Enabled = false;
                firstFlag = 0;
                secondFlag = 255;
            }

        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "от " + trackBar2.Value.ToString();
            if (trackBar2.Value >= trackBar3.Value)
            {
                trackBar3.Value = trackBar2.Value + 1;
                label3.Text = "до " + trackBar3.Value.ToString();
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label3.Text = "до " + trackBar3.Value.ToString();
            if (trackBar3.Value <= trackBar2.Value)
            {
                trackBar2.Value = trackBar3.Value - 1;
                label2.Text = "от " + trackBar2.Value.ToString();
            }
        }

        private void ContrastScalingDialog_Load(object sender, EventArgs e)
        {
            main = this.Owner as Form1;
        }
    }
}
