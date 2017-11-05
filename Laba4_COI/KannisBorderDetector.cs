using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4_COI
{
    public partial class KannisBorderDetector : Form
    {
        Form1 main;

        float sigma;
        int firstFlag, secondFlag;
        int selector;

        int height, width;
        byte[, ,] OriginalImageByte,
            AlteredImageByte;
        public KannisBorderDetector()
        {
            InitializeComponent();
        }

        private void KannisBorderDetector_Load(object sender, EventArgs e)
        {
            main = this.Owner as Form1;
            height = main.getHeight();
            width = main.getWidth();
            OriginalImageByte = main.getOriginalImageByte();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sigma = trackBar1.Value/10.0f;
            firstFlag = trackBar2.Value;
            secondFlag = trackBar3.Value;
            selector = FindSelector();
            AlteredImageByte = (byte[,,])OriginalImageByte.Clone();
            FindBorder(selector);

            main.setAlteredImageByte(AlteredImageByte);
            main.setPictureBox2(AlteredImageByte);
        }
        private int FindSelector()
        {
            if (radioButton1.Checked)
                return 1;
            if (radioButton2.Checked)
                return 2;
            return 3;
        }

        private byte[,,] SmothingImage(byte[,,] byteMass)
        {
            byte[, ,] res = new byte[3, height, width];
            double firstCoof = 1.0D / (2 * Math.PI * sigma * sigma);
            for (int y = 1; y < height+1; y++)
                for (int x = 1; x < width+1; x++)
                {
                    double up = (double)(x * x + y * y) / 2;
                    double coof = firstCoof * Math.Exp(-up/(sigma*sigma));
                    for (int chennal = 0; chennal < 3; chennal++)
                    {
                        int pixel = (int)(coof * byteMass[chennal, y-1, x-1]);
                        res[chennal, y-1, x-1] = main.toByte(pixel);
                    }
                }
            return res;
        }

        private void FindBorder(int selector)
        {
            switch(selector)
            {
                case 1:
                    for (int y = 1; y < height-1; y++)
                        for (int x = 1; x < width - 1; x++)
                        {
                            AlteredImageByte[0, y, x] = RobertsFilter(AlteredImageByte,y,x,0);
                            AlteredImageByte[1, y, x] = RobertsFilter(AlteredImageByte,y,x,1);
                            AlteredImageByte[2, y, x] = RobertsFilter(AlteredImageByte,y,x,2);
                        }
                    break;
                case 2:
                    for (int y = 1; y < height - 1; y++)
                        for (int x = 1; x < width - 1; x++)
                        {
                            AlteredImageByte[0, y, x] = SobelsFilter(AlteredImageByte,y,x,0);
                            AlteredImageByte[1, y, x] = SobelsFilter(AlteredImageByte,y,x,1);
                            AlteredImageByte[2, y, x] = SobelsFilter(AlteredImageByte,y,x,2);
                        }
                    break;
                case 3:
                    for (int y = 1; y < height - 1; y++)
                        for (int x = 1; x < width - 1; x++)
                        {
                            AlteredImageByte[0, y, x] = PrevitFilter(AlteredImageByte,y,x,0);
                            AlteredImageByte[1, y, x] = PrevitFilter(AlteredImageByte,y,x,1);
                            AlteredImageByte[2, y, x] = PrevitFilter(AlteredImageByte, y, x, 2);
                        }
                    break;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Сигма = " + trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label3.Text = "Значение высоты гребня = " + trackBar2.Value.ToString();
            if(trackBar2.Value <trackBar3.Value)
            {
                trackBar3.Value = trackBar2.Value;
                label4.Text = "Уменьшать гребень до " + trackBar3.Value.ToString();
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label4.Text = "Уменьшать гребень до " + trackBar3.Value.ToString();
            if(trackBar3.Value>trackBar2.Value)
            {
                trackBar2.Value = trackBar3.Value;
                label3.Text = "Значение высоты гребня = " + trackBar2.Value.ToString();
            }
        }
        private byte RobertsFilter(byte[, ,] byteMass, int y, int x, int chennal)
        {
            int Gx = Math.Abs(byteMass[chennal, y + 1, x + 1] - byteMass[chennal, y, x]),
                Gy = Math.Abs(byteMass[chennal, y + 1, x] - byteMass[chennal, y, x + 1]);
            double E = Math.Sqrt(Gx * Gx + Gy * Gy);
            return main.toByte((int)E);
        }
        private byte SobelsFilter(byte[, ,] byteMass, int y, int x, int chennal)
        {
            int[,] firstMask = new int[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
            int[,] secondMask = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int Gx = Math.Abs(main.MultMatrix(firstMask, byteMass, y, x, chennal, 3));
            int Gy = Math.Abs(main.MultMatrix(secondMask, byteMass, y, x, chennal, 3));
            double E = Math.Sqrt(Gx * Gx + Gy * Gy);
            return main.toByte((int)E);
        }
        private byte PrevitFilter(byte[, ,] byteMass, int y, int x, int chennal)
        {
            int[,] Hx = new int[,] { { 1, 0, -1 }, { 1, 0, -1 }, { 1, 0, -1 } };
            int[,] Hy = new int[,] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };
            int Gx = main.MultMatrix(Hx, byteMass, y, x, chennal, 3),
                Gy = main.MultMatrix(Hy, byteMass, y, x, chennal, 3);
            double E = Math.Sqrt(Gx * Gx + Gy * Gy);
            return main.toByte((int)E);
        }
    }
}
