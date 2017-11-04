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
    public partial class Sigma_Filter : Form
    {
        Form1 main;
        int scalefiltaer;
        int sigma;
        bool IsKNeighbaors = false;
        int k;

        public Sigma_Filter()
        {
            InitializeComponent();
        }

        private void Sigma_Filter_Load(object sender, EventArgs e)
        {
            main = this.Owner as Form1;
            if(IsKNeighbaors)
            {
                label3.Enabled = true;
                trackBar3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main.isSeccessfullyForm(false);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scalefiltaer = trackBar1.Value;
            sigma = trackBar2.Value;
            k = trackBar3.Value;
            main.setSigmaFilter(scalefiltaer, sigma, k);
            main.isSeccessfullyForm(true);
            this.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Размеры сигма-фильтра " + trackBar1.Value.ToString();
            trackBar3.Value = 2;
            trackBar3.Maximum = (trackBar1.Value * trackBar1.Value)-1;
            label3.Text = "K = " + trackBar3.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Коэффициент сигма = " + trackBar2.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label3.Text = "K = " + trackBar3.Value.ToString();
        }
        public void checkKneighbors(bool flag)
        {
            IsKNeighbaors = flag;
        }
    }
}
