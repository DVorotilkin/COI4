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
    public partial class Kriterii : Form
    {
        Form1 main;

        int height, width;
        byte[, ,] OriginalImageByte,
            NoiseImageByte,
            AlteredImageByte;
        double fistKrit,
            secondKrit;
        double EnergyOriginal;

        bool IsNoisedImage;
        public Kriterii()
        {
            InitializeComponent();
        }

        private void Kriterii_Load(object sender, EventArgs e)
        {
            main = this.Owner as Form1;
            height = main.getHeight();
            width = main.getWidth();
            IsNoisedImage = main.getIsNoisedImageByte();
            if (IsNoisedImage)
            {
                OriginalImageByte = main.getBackupImageByte();
                NoiseImageByte = main.getOriginalImageByte();
            }
            else
                OriginalImageByte = main.getOriginalImageByte();
            AlteredImageByte = main.getAlteredImageByte();
            EnergyOriginal = EnergyOriginalImage();
            if (IsNoisedImage)
            {
                fistKrit = Funk(NoiseImageByte, AlteredImageByte) / EnergyOriginal;
            }
            secondKrit = Funk(AlteredImageByte, OriginalImageByte) / EnergyOriginal;
            label1.Text += fistKrit.ToString();
            label2.Text += secondKrit.ToString();
            
        }
        private double EnergyOriginalImage()
        {
            double energy = 0;
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    energy += Math.Pow(OriginalImageByte[0, y, x], 2.0D);
                }
            return energy;
        }
        private double Funk(byte[, ,] first, byte[, ,] second)
        {
            double sum = 0;
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    sum += Math.Pow(Math.Abs(first[0, y, x] - second[0, y, x]), 2.0D);
                }
            return sum;
        }
    }
}
