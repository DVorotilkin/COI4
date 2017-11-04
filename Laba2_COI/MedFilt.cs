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
    public partial class MedFilt : Form
    {
        Form1 main;

        Bitmap firstImage, secondImage, thirdImage,
            fourthImage, fifthImage, sixthImage;

        int height, width;

        byte[, ,] OriginalImageByte,
            AlteredImageByte;
        
        public MedFilt()
        {
            InitializeComponent();
        }

        private void MedFilt_Load(object sender, EventArgs e)
        {
            main = this.Owner as Form1;
            height = main.getHeight();
            width = main.getWidth();
            OriginalImageByte = main.getOriginalImageByte();
            LoadImage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            int SelectedApert = HowRadioClick();
            switch (SelectedApert)
            {
                case 1:
                    AlteredImageByte = FirstAndSecondApertFilter(OriginalImageByte,SelectedApert);
                    break;
                case 2:
                    AlteredImageByte = FirstAndSecondApertFilter(OriginalImageByte, SelectedApert);
                    break;
                case 3:
                    AlteredImageByte = ThirdAndFifthApertFilter(OriginalImageByte, SelectedApert);
                    break;
                case 4:
                    AlteredImageByte = FourthAndSixthApertFilter(OriginalImageByte, SelectedApert);
                    break;
                case 5:
                    AlteredImageByte = ThirdAndFifthApertFilter(OriginalImageByte, SelectedApert);
                    break;
                case 6:
                    AlteredImageByte = FourthAndSixthApertFilter(OriginalImageByte, SelectedApert);
                    break;
            };
            main.setAlteredImageByte(AlteredImageByte);
            main.setPictureBox2(AlteredImageByte);
            this.Close();

        }
        private void LoadImage()
        {
            firstImage = (Bitmap)Bitmap.FromFile(@"Picture\1.jpg");
            secondImage = (Bitmap)Bitmap.FromFile(@"Picture\2.jpg");
            thirdImage = (Bitmap)Bitmap.FromFile(@"Picture\3.jpg");
            fourthImage = (Bitmap)Bitmap.FromFile(@"Picture\4.jpg");
            fifthImage = (Bitmap)Bitmap.FromFile(@"Picture\5.jpg");
            sixthImage = (Bitmap)Bitmap.FromFile(@"Picture\6.jpg");

            pictureBox1.Image = firstImage;
            pictureBox2.Image = secondImage;
            pictureBox3.Image = thirdImage;
            pictureBox4.Image = fourthImage;
            pictureBox5.Image = fifthImage;
            pictureBox6.Image = sixthImage;
        }
        private int HowRadioClick()
        {
            int select = 1;

            if(radioButton1.Checked) select = 1;
            else if (radioButton2.Checked) select = 2;
            else if (radioButton3.Checked) select = 3;
            else if (radioButton4.Checked) select = 4;
            else if (radioButton5.Checked) select = 5;
            else select = 6;

            return select;
        }

        private byte[, ,] FirstAndSecondApertFilter(byte[, ,] byteMass, int select)
        {
            byte[, ,] res = new byte[3, height, width];
            int i, j;
            if (select == 1) { i = 0; j = 1; }
            else { i = 1; j = 0; }
            for (int y = i; y < height - i; y++)
                for (int x = j; x < width - j; x++)
                {
                    res[0, y, x] = CulcFirstAndSecondFilters(byteMass, select, y, x, 0);
                    res[1, y, x] = CulcFirstAndSecondFilters(byteMass, select, y, x, 1);
                    res[2, y, x] = CulcFirstAndSecondFilters(byteMass, select, y, x, 2);
                }
            return res;
        }

        private byte[, ,] ThirdAndFifthApertFilter(byte[, ,] byteMass, int select)
        {
            byte[, ,] res = new byte[3, height, width];
            int shift = (select - 1) / 2;
            for(int y=shift;y<height-shift;y++)
                for (int x = shift; x < width - shift; x++)
                {
                    res[0, y, x] = CulcThirdAndFifthFilters(byteMass, select, y, x, 0);
                    res[1, y, x] = CulcThirdAndFifthFilters(byteMass, select, y, x, 1);
                    res[2, y, x] = CulcThirdAndFifthFilters(byteMass, select, y, x, 2);
                }
            return res;
        }

        private byte[, ,] FourthAndSixthApertFilter(byte[, ,] byteMass, int select)
        {
            byte[,,] res = new byte[3,height,width];
            int shift = select/2 -1;
            for (int y = shift; y < height - shift; y++)
                for (int x = shift; x < width - shift; x++)
                {
                    res[0, y, x] = CulcFourthAndSixthFilters(byteMass, select, y, x, 0);
                    res[1, y, x] = CulcFourthAndSixthFilters(byteMass, select, y, x, 1);
                    res[2, y, x] = CulcFourthAndSixthFilters(byteMass, select, y, x, 2);
                }
            return res;
        }

        private byte CulcFirstAndSecondFilters(byte[, ,] byteMass, int WhatisFilter, int y, int x, int chennal)
        {
            byte[] filter = new byte[3];
            switch (WhatisFilter)
            {
                case 1:
                    for (int i = -1; i < 2; i++)
                        filter[i + 1] = byteMass[chennal, y, x + i];
                    break;
                case 2:
                    for (int j = -1; j < 2; j++)
                        filter[1 + j] = byteMass[chennal, y + j, x];
                    break;
            }
            return filter.OrderBy(q => q).ToArray()[1];
        }

        private byte CulcThirdAndFifthFilters(byte[, ,] byteMass, int WhatisFilter, int y, int x, int chennal)
        {
            int scaleApert = WhatisFilter * WhatisFilter - (WhatisFilter - 2) * 4;
            List<byte> filter = new List<byte>(scaleApert);
            int shift = (WhatisFilter-1)/2;
            for (int i = -shift; i < shift + 1; i++)
                for (int j = Math.Abs(i); j < WhatisFilter - Math.Abs(i); j++)
                {
                    filter.Add(byteMass[chennal, y + i, x + j - shift]);
                }
            return filter.OrderBy(q => q).ToArray()[(scaleApert-1)/2];
        }

        private byte CulcFourthAndSixthFilters(byte[, ,] byteMass, int WhatisFilter, int y, int x, int chennal)
        {
            int scale = (WhatisFilter - 1) * (WhatisFilter - 1);
            int shift = WhatisFilter/2 -1;
            List<byte> filter = new List<byte>(scale);
            for (int i = -shift; i < shift + 1; i++)
                for (int j = -shift; j < shift + 1; j++)
                {
                    filter.Add(byteMass[chennal, y + i, x + j]);
                }
            return filter.OrderBy(q => q).ToArray()[scale / 2 - 1];
        }
    }
}
