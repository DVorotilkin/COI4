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
    public partial class Noise : Form
    {
        Form1 main;
        Random rnd;
        Bitmap NoiseImage;
        int range;
        int height, width;
        double levelNoiseInterference;
        double percentOfImpulceNoise;
        int namberImpulcePixel;

        byte[, ,] OriginalImageByte,
            RandomNoiseByte,
            NoiseImageByte;
        public Noise()
        {
            InitializeComponent();
        }

        private void Noise_Load(object sender, EventArgs e)
        {
            main = this.Owner as Form1;
            rnd = new Random();
            OriginalImageByte = main.getOriginalImageByte();
            height = main.getHeight();
            width = main.getWidth();
            pictureBox1.Image = main.getOriginalImage();

        }
        private void AdditiveNoise()
        {
            levelNoiseInterference = trackBar2.Value * 0.25D;
            range = trackBar1.Value * 5+220;
            NoiseImageByte = new byte[3, height, width];
            NoiseByte();
            //double[] NoiseEnergy = EnergyField(RandomNoiseByte);
            double NoiseEnergy=0;
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    NoiseEnergy += RandomNoiseByte[0, y, x] * RandomNoiseByte[0, y, x];
                }
            double[] ImageEnergy = EnergyField(OriginalImageByte);
            double cash;
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    //cash = OriginalImageByte[0, y, x] + levelNoiseInterference * RandomNoiseByte[0, y, x] * (NoiseEnergy[0] / ImageEnergy[0]);
                    //NoiseImageByte[0, y, x] = ReturnLevelChennal(cash);
                    //cash = OriginalImageByte[1, y, x] + levelNoiseInterference * RandomNoiseByte[1, y, x] * (NoiseEnergy[1] / ImageEnergy[1]);
                    //NoiseImageByte[1, y, x] = ReturnLevelChennal(cash);
                    //cash = OriginalImageByte[2, y, x] + levelNoiseInterference * RandomNoiseByte[2, y, x] * (NoiseEnergy[2] / ImageEnergy[2]);
                    //NoiseImageByte[2, y, x] = ReturnLevelChennal(cash);
                    cash = OriginalImageByte[0, y, x] + levelNoiseInterference * RandomNoiseByte[0, y, x] * (ImageEnergy[0]/ NoiseEnergy);
                    NoiseImageByte[0, y, x] = ReturnLevelChennal(cash);                                                    
                    cash = OriginalImageByte[1, y, x] + levelNoiseInterference * RandomNoiseByte[0, y, x] * (ImageEnergy[1]/ NoiseEnergy);
                    NoiseImageByte[1, y, x] = ReturnLevelChennal(cash);                                                   
                    cash = OriginalImageByte[2, y, x] + levelNoiseInterference * RandomNoiseByte[0, y, x] * (ImageEnergy[2]/ NoiseEnergy);
                    NoiseImageByte[2, y, x] = ReturnLevelChennal(cash);

                }
        }
        private void NoiseByte()
        {
            //RandomNoiseByte = new byte[3, height, width];
            //for (int y = 0; y < height; y++)
            //    for (int x = 0; x < width; x++)
            //    {
            //        RandomNoiseByte[0, y, x] = (byte)rnd.Next(100, range);
            //        RandomNoiseByte[1, y, x] = (byte)rnd.Next(100, range);
            //        RandomNoiseByte[2, y, x] = (byte)rnd.Next(100, range);
            //    }
            RandomNoiseByte = new byte [1,height,width];
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    RandomNoiseByte[0, y, x] = (byte)rnd.Next(0, range);
                }       
        }
        private double[] EnergyField(byte[,,] byteMass)
        {
            double[] energy = new double[3];
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    energy[0] += byteMass[0, y, x] * byteMass[0, y, x];
                    energy[1] += byteMass[1, y, x] * byteMass[1, y, x];
                    energy[2] += byteMass[2, y, x] * byteMass[2, y, x];
                }
            return energy;
        }
        private byte ReturnLevelChennal(double value)
        {
            if (value < 0)
                return 0;
            else if (value > 255)
                return 255;
            else
                return Convert.ToByte(value);
        }
        public Bitmap getNoiseImage()
        {
            return NoiseImage;
        }

        private void ImpulceNoise()
        {
            NoiseImageByte = new byte[3, height, width]; 
            percentOfImpulceNoise = (trackBar3.Value * 5 + 5);
            namberImpulcePixel = (int)((height * width) * (percentOfImpulceNoise / 100.0D));
            //NoiseImageByte = OriginalImageByte;
            NoiseImageByte = CopyByteMass(OriginalImageByte);
            for(int count=0; count<namberImpulcePixel;count++)
            {
                CheckNoise(CoordinateNoise());
            }
        }
        private byte[,,] CopyByteMass(byte[,,] byteMass)
        {
            byte[, ,] res = new byte[3, height, width];
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    res[0, y, x] = byteMass[0, y, x];
                    res[1, y, x] = byteMass[1, y, x];
                    res[2, y, x] = byteMass[2, y, x];
                }
            return res;
        }
        private int[] CoordinateNoise()
        {
            int x, y;
            x = rnd.Next(0, width);
            y = rnd.Next(0, height);
            return new int[] { x, y };
        }
        private void CheckNoise(int[] coor)
        {
            int x = coor[0], y = coor[1];
            if (OriginalImageByte[0, y, x] < 129)
            {
                NoiseImageByte[0, y, x] = 255;
                NoiseImageByte[1, y, x] = 255;
                NoiseImageByte[2, y, x] = 255;
            }
            else
            {
                NoiseImageByte[0, y, x] = 0;
                NoiseImageByte[1, y, x] = 0;
                NoiseImageByte[2, y, x] = 0;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Диапазон датчика случайных чисел = " + (trackBar1.Value * 5+220).ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Уровень шумовой помехи = " + (trackBar2.Value * 0.25D).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                AdditiveNoise();
            }
            else
            {
                ImpulceNoise();
            }
            NoiseImage = main.toBitmap(NoiseImageByte);
            pictureBox2.Image = NoiseImage;
            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            main.isSeccessfullyForm(false);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.ApplyNoise(NoiseImageByte);
            main.isSeccessfullyForm(true);
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                radioButton2.Checked = false;
                trackBar3.Enabled = false;
                label5.Enabled = false;
                trackBar1.Enabled = true;
                label1.Enabled = true;
                trackBar2.Enabled = true;
                label2.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked)
            {
                radioButton1.Checked = false;
                trackBar1.Enabled = false;
                label1.Enabled = false;
                trackBar2.Enabled = false;
                label2.Enabled = false;
                trackBar3.Enabled = true;
                label5.Enabled = true;
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label5.Text = "Процент зашумлённости изображения = " + (trackBar3.Value * 5 + 5).ToString() + "%";
        }
    }
}
