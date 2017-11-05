using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Laba4_COI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //--
        #region Переменные

        int width, height;//Размеры изображения

        //------Для оригинального изображения
        Bitmap OriginalImage;
        byte[, ,] OriginalImageByte;

        //------Для изменённого изображения
        Bitmap AlteredImage;
        byte[, ,] AlteredImageByte;

        bool FormsSuccessfullFlag = false;//Нажал ли пользователь "Применить" в дочерней форме

        #endregion

        //--
        #region Работа меню программы

        //----Файл
        #region Меню "Файл"

        private void загрузитьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OriginalImage = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
                    EnabledMeny(true);
                    width = OriginalImage.Width;
                    height = OriginalImage.Height;
                    DownConsole.Text = "Изображение успешно загружено.";
                    OriginalImageByte = toBytes(OriginalImage);
                    pictureBox1.Image = OriginalImage;
                    pictureBox2.Image = null;
                    label1.Text = "Количество пикселей: " + (height * width).ToString();
                }
                catch (Exception openE)
                {
                    DownConsole.Text = "Невозможно загрузить изображение: " + openE.Message;
                }
            }
        }
        //------Пункт меню  загрузки изображений

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //------Пункт меню выхода из программы

        #endregion

        //----Выделение контуров
        #region Выделение контуров

        private void дискретныйЛапласианToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlteredImageByte = new byte[3, height, width];
            for (int y = 1; y < height - 1; y++)
                for (int x = 1; x < width - 1; x++)
                {
                    AlteredImageByte[0, y, x] = DisckrLap(OriginalImageByte, y, x, 0);
                    AlteredImageByte[1, y, x] = DisckrLap(OriginalImageByte, y, x, 1);
                    AlteredImageByte[2, y, x] = DisckrLap(OriginalImageByte, y, x, 2);
                }
            AlteredImage = toBitmap(AlteredImageByte);
            pictureBox2.Image = AlteredImage;
        }
        //------Пункт меню Дискретный лапласиан

        private void расширенныйЛапласианToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlteredImageByte = new byte[3, height, width];
            for (int y = 1; y < height - 1; y++)
                for (int x = 1; x < width - 1; x++)
                {
                    AlteredImageByte[0, y, x] = ExpanLap(OriginalImageByte, y, x, 0);
                    AlteredImageByte[1, y, x] = ExpanLap(OriginalImageByte, y, x, 1);
                    AlteredImageByte[2, y, x] = ExpanLap(OriginalImageByte, y, x, 2);
                }
            AlteredImage = toBitmap(AlteredImageByte);
            pictureBox2.Image = AlteredImage;
        }
        //------Пункт меню Расширенный лапласиан

        private void фильтрРобертсаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlteredImageByte = new byte[3, height, width];
            for (int y = 1; y < height - 1; y++)
                for (int x = 1; x < width - 1; x++)
                {
                    AlteredImageByte[0, y, x] = RobertsFilter(OriginalImageByte, y, x, 0);
                    AlteredImageByte[1, y, x] = RobertsFilter(OriginalImageByte, y, x, 1);
                    AlteredImageByte[2, y, x] = RobertsFilter(OriginalImageByte, y, x, 2);
                }
            AlteredImage = toBitmap(AlteredImageByte);
            pictureBox2.Image = AlteredImage;            
        }
        //------Пункт меню Фильтр Робертса

        private void фильтрСобеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlteredImageByte = new byte[3, height, width];
            for (int y = 1; y < height - 1; y++)
                for (int x = 1; x < width - 1; x++)
                {
                    AlteredImageByte[0, y, x] = SobelsFilter(OriginalImageByte, y, x, 0);
                    AlteredImageByte[1, y, x] = SobelsFilter(OriginalImageByte, y, x, 1);
                    AlteredImageByte[2, y, x] = SobelsFilter(OriginalImageByte, y, x, 2);
                }
            AlteredImage = toBitmap(AlteredImageByte);
            pictureBox2.Image = AlteredImage;    
        }
        //------Пункт меню Фильтр Собеля

        private void операторПревитаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlteredImageByte = new byte[3, height, width];
            for (int y = 1; y < height - 1; y++)
                for (int x = 1; x < width - 1; x++)
                {
                    AlteredImageByte[0, y, x] = PrevitsOper(OriginalImageByte, y, x, 0);
                    AlteredImageByte[1, y, x] = PrevitsOper(OriginalImageByte, y, x, 1);
                    AlteredImageByte[2, y, x] = PrevitsOper(OriginalImageByte, y, x, 2);
                }
            AlteredImage = toBitmap(AlteredImageByte);
            pictureBox2.Image = AlteredImage;    
        }
        //------Пункт меню Оператор Превита

        private void операторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlteredImageByte = new byte[3, height, width];
            for (int y = 1; y < height - 1; y++)
                for (int x = 1; x < width - 1; x++)
                {
                    AlteredImageByte[0, y, x] = KirshsOper(OriginalImageByte, y, x, 0);
                    AlteredImageByte[1, y, x] = KirshsOper(OriginalImageByte, y, x, 1);
                    AlteredImageByte[2, y, x] = KirshsOper(OriginalImageByte, y, x, 2);
                }
            AlteredImage = toBitmap(AlteredImageByte);
            pictureBox2.Image = AlteredImage;    
        }
        //------Пункт меню Оператор Кирша

        private void операторУоллесаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlteredImageByte = new byte[3, height, width];
            for (int y = 1; y < height - 1; y++)
                for (int x = 1; x < width - 1; x++)
                {
                    AlteredImageByte[0, y, x] = UollesesOper(OriginalImageByte, y, x, 0);
                    AlteredImageByte[1, y, x] = UollesesOper(OriginalImageByte, y, x, 1);
                    AlteredImageByte[2, y, x] = UollesesOper(OriginalImageByte, y, x, 2);
                }
            AlteredImage = toBitmap(AlteredImageByte);
            pictureBox2.Image = AlteredImage;
        }
        //------Пункт меню Оператор Уоллеса

        private void статистическийМетодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlteredImageByte = new byte[3, height, width];
            for (int y = 1; y < height - 1; y++)
                for (int x = 1; x < width - 1; x++)
                {
                    AlteredImageByte[0, y, x] = StatisticMethod(OriginalImageByte, y, x, 0);
                    AlteredImageByte[1, y, x] = StatisticMethod(OriginalImageByte, y, x, 1);
                    AlteredImageByte[2, y, x] = StatisticMethod(OriginalImageByte, y, x, 2);
                }
            AlteredImage = toBitmap(AlteredImageByte);
            pictureBox2.Image = AlteredImage;
        }
        //------Пункт меню Статистический метод

        private void детекторГраницКанниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KannisBorderDetector KBD = new KannisBorderDetector();
            KBD.Owner = this;
            KBD.Show();
        }
        //------Пункт меню Детектор границ Канни

        #endregion

        #endregion

        //--
        #region Методы обработки изобрадений

        //----Дискретный лапласиан
        private byte DisckrLap(byte[, ,] byteMass, int y, int x, int chennal)
        {
            byte pixel;
            int w = 0;
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        w -= 4 * byteMass[chennal, y + i, x + j];
                    else
                        w += Math.Abs(i + j) % 2 * byteMass[chennal, y + i, x + j];

                }
            //pixel = (byte)(byteMass[chennal,y,x] - toByte(w));
            pixel = toByte(w);
            return pixel;
        }
        //----Расширенный лапласиан
        private byte ExpanLap(byte[, ,] byteMass, int y, int x, int chennal)
        {
            byte pixel;
            int w = 0;
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        w -= 8 * byteMass[chennal, y + i, x + j];
                    else
                        w += byteMass[chennal, y + i, x + j];

                }
            pixel = toByte(w);
            return pixel;
        }
        //----Фильтр Робертса
        public byte RobertsFilter(byte[,,] byteMass,int y, int x, int chennal)
        {
            int pixel = Math.Abs(byteMass[chennal, y + 1, x + 1] - byteMass[chennal, y, x]) +
                Math.Abs(byteMass[chennal, y + 1, x] - byteMass[chennal, y, x + 1]);
            return toByte(pixel);
        }
        //----Фильтр Собеля
        public byte SobelsFilter(byte[,,] byteMass,int y, int x, int chennal)
        {
            //int pixel = Math.Abs((byteMass[chennal, y + 1, x - 1] + 2 * byteMass[chennal, y + 1, x] + byteMass[chennal, y + 1, x + 1]) -
            //    (byteMass[chennal, y - 1, x - 1] + 2 * byteMass[chennal, y - 1, x] + byteMass[chennal, y - 1, x + 1])) +
            //    Math.Abs((byteMass[chennal, y - 1, x + 1] + 2 * byteMass[chennal, y, x + 1] + byteMass[chennal, y + 1, x + 1]) -
            //    (byteMass[chennal, y - 1, x - 1] + 2 * byteMass[chennal, y, x - 1] + byteMass[chennal, y + 1, x - 1]));
            int[,] firstMask = new int[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
            int[,] secondMask = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int pixel = Math.Abs(MultMatrix(firstMask, byteMass, y, x, chennal, 3)) +
                Math.Abs(MultMatrix(secondMask, byteMass, y, x, chennal, 3));
            return toByte(pixel);
        }

        //----Оператор Превита
        public byte PrevitsOper(byte[,,] byteMass, int y, int x, int chennal)
        {
            int pixel;
            int[,] Hx = new int[,] { { 1, 0, -1 }, { 1, 0, -1 }, { 1, 0, -1 } };
            int[,] Hy = new int[,] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };
            int Gx = MultMatrix(Hx, byteMass, y, x, chennal, 3),
                Gy = MultMatrix(Hy, byteMass, y, x, chennal, 3);
            if (Gx >= Gy) pixel = Gx;
            else pixel = Gy;
            return toByte(pixel);
        }

        //----Оператор Кирша
        public byte KirshsOper(byte[,,] byteMass, int y, int x, int chennal)
        {
            int[,] Matrix = new int[,] { { 5, 5, 5 }, { -3, 0, -3 }, { -3, -3, -3 } };
            int[] r = new int[8];
            for(int i =0; i <8; i++)
            {
                r[i] = MultMatrix(Matrix, byteMass, y, x, chennal, 3);
                if(i!=7)
                    Matrix = RotateMatrix(Matrix);
            }
            return toByte(r.Max());
        }

        //----Оператор Уоллеса
        public byte UollesesOper(byte[, ,] byteMass, int y, int x, int chennal)
        {
            double multi = 1;
            for(int i =-1; i<=1;i++)
                for(int j=-1;j<=1;j++)
                {
                    if(Math.Abs(i+j)%2==1)
                        multi *= Convert.ToDouble(byteMass[chennal, y, x] + 1) / (byteMass[chennal, y + i, x + j]+1);
                }
            int pixel= (int)(1000*Math.Log(multi)/4);
            return toByte(pixel);
        }
        //----Статистческий метод
        private byte StatisticMethod(byte[,,] byteMass,int y, int x, int chennal)
        {
            double mult = 0;
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    mult += byteMass[chennal, y + i, x + j];
                }
            double u = mult / 9;
            mult = 0;
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    mult += Math.Pow((byteMass[chennal, y + i, x + j] - u), 2.0D);
                }
            int sigma = (int)Math.Sqrt(mult / 9);
            return toByte(50*sigma);
        }
        #endregion
        #region Специальные и служебные методы

        //----Методы get
        #region Методы get

        public int getHeight()
        {
            return height;
        }
        //------Метод возвращающий высоту изображения

        public int getWidth()
        {
            return width;
        }
        //------Метод возвращающий ширину изображения

        public byte[, ,] getOriginalImageByte()
        {
            return OriginalImageByte;
        }
        //------Метод возращающий массив байтов оригинального изображения

        public byte[, ,] getAlteredImageByte()
        {
            return AlteredImageByte;
        }
        //------Метод возвращающий массив байтов изменённого изображения
        
        public Bitmap getOriginalImage()
        {
            return OriginalImage;
        }
        //------Метод возарщающий орагинальне изображение
        #endregion

        //----Методы set
        #region Методы set

        public void setPictureBox2(byte[, ,] byteMass)
        {
            pictureBox2.Image = toBitmap(byteMass);
        }
        //------Метод заменющий пикчерБокс2 на приходящий массив байт

        public void setAlteredImageByte(byte[,,] byteMass)
        {
            AlteredImageByte = (byte[,,])byteMass.Clone();
        }
        //------Метод заменющий массив изменённого изображения на приходящий массив байт

        #endregion

        //----Методы изменения bool переменных
        #region Методы изменения bool переменных

        private void EnabledMeny(bool flag)
        {
            выделениеКонтуровToolStripMenuItem.Enabled = flag;
        }
        //------Метод определяет активны ли меню обработки изображения

        public void isSeccessfullyForm(bool flag)
        {
            FormsSuccessfullFlag = flag;
        }
        //------Метод определяет, нажал ли пользователь кнопку "Применить" в дочерней форме
        #endregion

        //----Методы конвертации данны
        #region Методы конвертации данны

        public byte[, ,] toBytes(Bitmap bmp)
        {
            byte[, ,] res = new byte[3, height, width];
            for (int y = 0; y < height; ++y)
                for (int x = 0; x < width; ++x)
                {
                    Color color = bmp.GetPixel(x, y);
                    res[0, y, x] = color.R;
                    res[1, y, x] = color.G;
                    res[2, y, x] = color.B;
                }
            return res;
        }
        //------Метод конвертирует изображение в массив байт

        public Bitmap toBitmap(byte[, ,] byteMass)
        {
            Bitmap res = new Bitmap(width, height);
            for (int y = 0; y < height; ++y)
                for (int x = 0; x < width; ++x)
                {
                    Color color = Color.FromArgb(byteMass[0, y, x],
                        byteMass[1, y, x],
                        byteMass[2, y, x]);
                    res.SetPixel(x, y, color);
                }
            return res;
        }
        //------Метод конвертирует массив байт в изображение

        public byte toByte(int pixel)
        {
            if (pixel <= 0)
                return 0;
            else if (pixel > 255)
                return 255;
            else
                return (byte)pixel;
        }
        //------Метод ковертирует значение типа int в значение типа byte

        #endregion

        //----Служебные методы
        #region Служебные методы

        public int MultMatrix(int[,] firstMatrix, byte[,,] byteMass, int y, int x, int chennal, int scale)
        {
            int sum = 0;
            int shift = (scale - 1) / 2;
            for (int i = -shift; i < shift+1; i++)
                for (int j = -shift; j < shift+1; j++)
                {
                    sum += firstMatrix[i+shift, j+shift] * byteMass[chennal,y+i,x+j];
                }
            return sum;
        }
        //------Метод применения маски к участку изображения

        private int[,] RotateMatrix(int[,] Matrix)
        {
            int[,] NewMatrix = new int[3, 3];
            for (int i = 0; i <= 2; i++)
                for (int j = 0; j <= 2; j++)
                {
                    if (i == 0 && (j >= 0 && j < 2))
                        NewMatrix[i, j + 1] = Matrix[i, j];
                    else if (j == 2 && (i >= 0 && i < 2))
                        NewMatrix[i + 1, j] = Matrix[i, j];
                    else if (i == 2 && (j > 0 && j <= 2))
                        NewMatrix[i, j - 1] = Matrix[i, j];
                    else if (j == 0 && (i > 0 && i <= 2))
                        NewMatrix[i - 1, j] = Matrix[i, j];
                    else
                        NewMatrix[i, j] = Matrix[i, j];
                }
            return NewMatrix;
        }
        //------Метода поворачивает входящую матрицу на 45 градусов

        #endregion

        #endregion      
    }
}