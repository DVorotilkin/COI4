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
    public partial class Histogramm : Form
    {
        Form1 main;
        int height, width, allpixel,
            selector, channel = 0;
        int gMin = 0, gMax = 255;
        double alfa = 0.03D;
        byte[, ,] OriginalImageByte,
            AlteredImageByte;

        double[] OriginalRedFrequency, OriginalGreenFrequency, OriginalBlueFrequency,
            AlteredRedFrequency, AlteredGreenFrequency, AlteredBlueFrequency;

        public Histogramm()//Стандартный конструктор
        {
            InitializeComponent();
        }
        public Histogramm(int selector)//Конструктор с селектом
        {
            InitializeComponent();
            this.selector = selector;
        }
        //То что происходит перед началом показа формы
        private void Histogramm_Load(object sender, EventArgs e)
        {
            main = this.Owner as Form1;
            height = main.getHeight();
            width = main.getWidth();
            allpixel = height * width;
            OriginalImageByte = main.getOriginalImageByte();
            CheckMemory();
            getOriginalImageFrequency(OriginalImageByte);
            DrawOriginalHistogramm(OriginalRedFrequency);
            EnabledAndCheckTrackBar(selector);
            SelectHistogramm();
            DrawAlteredHistogramm(AlteredRedFrequency);
        }
        //Выделяем память под массивы всех гистограмм
        private void CheckMemory()
        {
            OriginalRedFrequency = new double[256];
            OriginalBlueFrequency = new double[256];
            OriginalGreenFrequency = new double[256];
            AlteredRedFrequency = new double[256];
            AlteredGreenFrequency = new double[256];
            AlteredBlueFrequency = new double[256];
        }
        //Метод определения частот всех каналов оригинального изображения.
        private void getOriginalImageFrequency(byte[, ,] byteMass)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    OriginalRedFrequency[byteMass[0, y, x]]++;
                    OriginalGreenFrequency[byteMass[1, y, x]]++;
                    OriginalBlueFrequency[byteMass[2, y, x]]++;
                }
            }
           //нормирование гистограммы
            OriginalRedFrequency =  OriginalRedFrequency.Select(x => x / allpixel).ToArray();
            OriginalGreenFrequency = OriginalGreenFrequency.Select(x => x / allpixel).ToArray();
            OriginalBlueFrequency = OriginalBlueFrequency.Select(x => x / allpixel).ToArray();
        }
        //Метод определения частот всех каналов изменённого изображения.
        private void getAlteredImageFrequency(byte[, ,] byteMass)
        {
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    ++AlteredRedFrequency[byteMass[0, y, x]];
                    ++AlteredGreenFrequency[byteMass[1, y, x]];
                    ++AlteredBlueFrequency[byteMass[2, y, x]];
                }
            AlteredRedFrequency = AlteredRedFrequency.Select(x => x / allpixel).ToArray();
            AlteredGreenFrequency = AlteredGreenFrequency.Select(x => x / allpixel).ToArray();
            AlteredBlueFrequency = AlteredBlueFrequency.Select(x => x / allpixel).ToArray();
        }
        //Отрисовка гистограммы оригинального изображения
        private void DrawOriginalHistogramm(double[] frequency)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[channel].Points.DataBindY(frequency);
        }
        //Отрисовка гистограммы изменённого изображения
        private void DrawAlteredHistogramm(double[] frequency)
        {
            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            chart2.Series[2].Points.Clear();
            chart2.Series[channel].Points.DataBindY(frequency);
        }
        //Выбор при помощи селектора, какую гистограмму строить
        private void SelectHistogramm()
        {
            switch(selector)
            {
                case 1:
                    AlteredImageByte = UniformlyHistogramm(OriginalImageByte);
                    break;
                case 2:
                    AlteredImageByte = ExponentialHistogramm(OriginalImageByte);
                    break;
                case 3:
                    AlteredImageByte = ReylyaHistogramm(OriginalImageByte);
                    break;
                case 4:
                    AlteredImageByte = Power23Histogramm(OriginalImageByte);
                    break;
                case 5:
                    AlteredImageByte = HiperbolicHistogramm(OriginalImageByte);
                    break;                    
            }
            getAlteredImageFrequency(AlteredImageByte);
            main.setPictureBox2(AlteredImageByte);
        }
        //Расчёт яркостей пикселей изменённого изображения
        private byte[,,] UniformlyHistogramm(byte[,,] byteMass)
        {
            byte[, ,] res = new byte[3, height, width];
            for(int y=0;y<height;y++)
                for (int x = 0; x < width; x++)
                {
                    res[0, y, x] = Convert.ToByte((gMax - gMin) * FrequencySum(OriginalRedFrequency,byteMass[0,y,x]) + gMin);
                    res[1, y, x] = Convert.ToByte((gMax - gMin) * FrequencySum(OriginalGreenFrequency, byteMass[1, y, x]) + gMin);
                    res[2, y, x] = Convert.ToByte((gMax - gMin) * FrequencySum(OriginalBlueFrequency, byteMass[2, y, x]) + gMin);
                }
            return res;
        }
        
        private byte[,,] ExponentialHistogramm(byte[,,] byteMass)
        {
            byte[, ,] res = new byte[3, height, width];
            for(int y=0;y<height;y++)
                for (int x = 0; x < width; x++)
                {
                    res[0, y, x] = Convert.ToByte(gMin - (1 / alfa) * Math.Log(1 - FrequencySum(OriginalRedFrequency, byteMass[0, y, x])));
                    res[1, y, x] = Convert.ToByte(gMin - (1 / alfa) * Math.Log(1 - FrequencySum(OriginalGreenFrequency, byteMass[1, y, x])));
                    res[2, y, x] = Convert.ToByte(gMin - (1 / alfa) * Math.Log(1 - FrequencySum(OriginalBlueFrequency, byteMass[2, y, x])));
                }
            return res;
        }
        private byte[,,] ReylyaHistogramm(byte[,,] byteMass)
        {
            byte[, ,] res = new byte[3, height, width];
            double PfotF;
            for(int y=0;y<height;y++)
                for (int x = 0; x < width; x++)
                {
                    if((PfotF = FrequencySum(OriginalRedFrequency, byteMass[0, y, x])) < 1)
                        res[0, y, x] = Convert.ToByte(gMin + Math.Pow(2 * alfa * alfa * Math.Log(1.0D / (1 - PfotF)), 0.5D));
                    else
                        res[0, y, x] = Convert.ToByte(gMin + Math.Pow(2 * alfa * alfa * Math.Log(1), 0.5D));
                    if ((PfotF = FrequencySum(OriginalGreenFrequency, byteMass[1, y, x])) < 1)
                        res[1, y, x] = Convert.ToByte(gMin + Math.Pow(2 * alfa * alfa * Math.Log(1.0D / (1 - PfotF)), 0.5D));
                    else
                        res[1, y, x] = Convert.ToByte(gMin + Math.Pow(2 * alfa * alfa * Math.Log(1), 0.5D)); 
                    if ((PfotF = FrequencySum(OriginalBlueFrequency, byteMass[2, y, x])) < 1)
                        res[2, y, x] = Convert.ToByte(gMin + Math.Pow(2 * alfa * alfa * Math.Log(1.0D / (1 - PfotF)), 0.5D));
                    else
                        res[2, y, x] = Convert.ToByte(gMin + Math.Pow(2 * alfa * alfa * Math.Log(1), 0.5D));
                }
            return res;
        }
        private byte[, ,] Power23Histogramm(byte[, ,] byteMass)
        {
            byte[, ,] res = new byte[3, height, width];
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    res[0, y, x] = Convert.ToByte(Math.Pow(((Math.Pow(gMax, 0.333D) - Math.Pow(gMin, 0.333D)) * FrequencySum(OriginalRedFrequency, byteMass[0, y, x]) + Math.Pow(gMin, 0.333D)), 3.0D));
                    res[1, y, x] = Convert.ToByte(Math.Pow(((Math.Pow(gMax, 0.333D) - Math.Pow(gMin, 0.333D)) * FrequencySum(OriginalGreenFrequency, byteMass[1, y, x]) + Math.Pow(gMin, 0.333D)), 3.0D));
                    res[2, y, x] = Convert.ToByte(Math.Pow(((Math.Pow(gMax, 0.333D) - Math.Pow(gMin, 0.333D)) * FrequencySum(OriginalBlueFrequency, byteMass[2, y, x]) + Math.Pow(gMin, 0.333D)), 3.0D));
                }
            return res;
        }
        private byte[, ,] HiperbolicHistogramm(byte[, ,] byteMass)
        {
            if(gMin == 0)
            {
                gMin++;
                trackBar1.Value = gMin;
                label1.Text = "Минимльный уровень: " + trackBar1.Value.ToString();
            }
            byte[, ,] res = new byte[3, height, width];
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    res[0, y, x] = Convert.ToByte(gMin * Math.Pow(Convert.ToDouble(gMax) / gMin, FrequencySum(OriginalRedFrequency, byteMass[0, y, x])));
                    res[1, y, x] = Convert.ToByte(gMin * Math.Pow(Convert.ToDouble(gMax) / gMin, FrequencySum(OriginalGreenFrequency, byteMass[1, y, x])));
                    res[2, y, x] = Convert.ToByte(gMin * Math.Pow(Convert.ToDouble(gMax) / gMin, FrequencySum(OriginalBlueFrequency, byteMass[2, y, x])));
                }
            return res;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Минимльный уровень: " + trackBar1.Value.ToString();
            if (trackBar1.Value >= trackBar2.Value)
            {
                trackBar2.Value = trackBar1.Value + 1;
                label2.Text = "Максимальный уровень: " + trackBar2.Value.ToString();
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Максимальный уровень: " + trackBar2.Value.ToString();
            if (trackBar2.Value <= trackBar1.Value)
            {
                trackBar1.Value = trackBar2.Value - 1;
                label1.Text = "Минималный уровень: " + trackBar1.Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (trackBar2.Enabled)
                gMax = trackBar2.Value;
            gMin = trackBar1.Value;
            SelectHistogramm();
            switch(channel)
            {
                case 0:
                    DrawAlteredHistogramm(AlteredRedFrequency);
                    break;
                case 1:
                    DrawAlteredHistogramm(AlteredGreenFrequency);
                    break;
                case 2:
                    DrawAlteredHistogramm(AlteredBlueFrequency);
                    break;
            }
        }
        //Если нажимем на радио-кнопку RED
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                channel = 0;
                radioButton2.Checked = radioButton3.Checked = false;
                DrawOriginalHistogramm(OriginalRedFrequency);
                DrawAlteredHistogramm(AlteredRedFrequency);
            }
        }
        //Если нажимем на радио-кнопку Green
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                channel = 1;
                radioButton1.Checked = radioButton3.Checked = false;
                DrawOriginalHistogramm(OriginalGreenFrequency);
                DrawAlteredHistogramm(AlteredGreenFrequency);
            }
        }
        //Если нажимем на радио-кнопку Blue
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                channel = 2;
                radioButton2.Checked = radioButton1.Checked = false;
                DrawOriginalHistogramm(OriginalBlueFrequency);
                DrawAlteredHistogramm(AlteredBlueFrequency);
            }
        }
        private double FrequencySum(double[] frequency, int count)
        {
            double sum = 0;
            for (int i = 0; i <= count; i++)
                sum += frequency[i];
            return sum;
        }
        private void EnabledAndCheckTrackBar(int select)
        {
            if (select == 2 || select == 3)
                trackBar2.Enabled = false;
            if (selector == 2)
            {
                alfa = Double.Parse("0,0" + trackBar3.Value.ToString());
            }
            if (selector == 3)
            {
                trackBar3.Maximum = 40;
                trackBar3.Value = 15;
                trackBar3.Minimum = 15;
                alfa = Convert.ToDouble(trackBar3.Value);
            }
            label3.Text = "\"Альфа\" = " + alfa;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            if (selector == 2)
            {
                alfa = Double.Parse("0,0" + trackBar3.Value.ToString());
            }
            if (selector == 3)
            {
                alfa = Convert.ToDouble(trackBar3.Value);
            }
            label3.Text = "\"Альфа\" = " + alfa;
        }
    }
}
