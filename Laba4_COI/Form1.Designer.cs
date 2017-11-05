namespace Laba4_COI
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выделениеКонтуровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лапласианToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дискретныйЛапласианToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расширенныйЛапласианToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрРобертсаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрСобеляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.операторПревитаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.операторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.операторУоллесаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистическийМетодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.детекторГраницКанниToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.DownConsole = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.выделениеКонтуровToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1028, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьИзображениеToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // загрузитьИзображениеToolStripMenuItem
            // 
            this.загрузитьИзображениеToolStripMenuItem.Name = "загрузитьИзображениеToolStripMenuItem";
            this.загрузитьИзображениеToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.загрузитьИзображениеToolStripMenuItem.Text = "Загрузить изображение";
            this.загрузитьИзображениеToolStripMenuItem.Click += new System.EventHandler(this.загрузитьИзображениеToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // выделениеКонтуровToolStripMenuItem
            // 
            this.выделениеКонтуровToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.лапласианToolStripMenuItem,
            this.фильтрРобертсаToolStripMenuItem,
            this.фильтрСобеляToolStripMenuItem,
            this.операторПревитаToolStripMenuItem,
            this.операторToolStripMenuItem,
            this.операторУоллесаToolStripMenuItem,
            this.статистическийМетодToolStripMenuItem,
            this.детекторГраницКанниToolStripMenuItem});
            this.выделениеКонтуровToolStripMenuItem.Enabled = false;
            this.выделениеКонтуровToolStripMenuItem.Name = "выделениеКонтуровToolStripMenuItem";
            this.выделениеКонтуровToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.выделениеКонтуровToolStripMenuItem.Text = "Выделение контуров";
            // 
            // лапласианToolStripMenuItem
            // 
            this.лапласианToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.дискретныйЛапласианToolStripMenuItem,
            this.расширенныйЛапласианToolStripMenuItem});
            this.лапласианToolStripMenuItem.Name = "лапласианToolStripMenuItem";
            this.лапласианToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.лапласианToolStripMenuItem.Text = "Лапласиан";
            // 
            // дискретныйЛапласианToolStripMenuItem
            // 
            this.дискретныйЛапласианToolStripMenuItem.Name = "дискретныйЛапласианToolStripMenuItem";
            this.дискретныйЛапласианToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.дискретныйЛапласианToolStripMenuItem.Text = "Дискретный лапласиан";
            this.дискретныйЛапласианToolStripMenuItem.Click += new System.EventHandler(this.дискретныйЛапласианToolStripMenuItem_Click);
            // 
            // расширенныйЛапласианToolStripMenuItem
            // 
            this.расширенныйЛапласианToolStripMenuItem.Name = "расширенныйЛапласианToolStripMenuItem";
            this.расширенныйЛапласианToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.расширенныйЛапласианToolStripMenuItem.Text = "Расширенный лапласиан";
            this.расширенныйЛапласианToolStripMenuItem.Click += new System.EventHandler(this.расширенныйЛапласианToolStripMenuItem_Click);
            // 
            // фильтрРобертсаToolStripMenuItem
            // 
            this.фильтрРобертсаToolStripMenuItem.Name = "фильтрРобертсаToolStripMenuItem";
            this.фильтрРобертсаToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.фильтрРобертсаToolStripMenuItem.Text = "Фильтр Робертса";
            this.фильтрРобертсаToolStripMenuItem.Click += new System.EventHandler(this.фильтрРобертсаToolStripMenuItem_Click);
            // 
            // фильтрСобеляToolStripMenuItem
            // 
            this.фильтрСобеляToolStripMenuItem.Name = "фильтрСобеляToolStripMenuItem";
            this.фильтрСобеляToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.фильтрСобеляToolStripMenuItem.Text = "Фильтр Собеля";
            this.фильтрСобеляToolStripMenuItem.Click += new System.EventHandler(this.фильтрСобеляToolStripMenuItem_Click);
            // 
            // операторПревитаToolStripMenuItem
            // 
            this.операторПревитаToolStripMenuItem.Name = "операторПревитаToolStripMenuItem";
            this.операторПревитаToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.операторПревитаToolStripMenuItem.Text = "Оператор Превита";
            this.операторПревитаToolStripMenuItem.Click += new System.EventHandler(this.операторПревитаToolStripMenuItem_Click);
            // 
            // операторToolStripMenuItem
            // 
            this.операторToolStripMenuItem.Name = "операторToolStripMenuItem";
            this.операторToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.операторToolStripMenuItem.Text = "Оператор Кирша";
            this.операторToolStripMenuItem.Click += new System.EventHandler(this.операторToolStripMenuItem_Click);
            // 
            // операторУоллесаToolStripMenuItem
            // 
            this.операторУоллесаToolStripMenuItem.Name = "операторУоллесаToolStripMenuItem";
            this.операторУоллесаToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.операторУоллесаToolStripMenuItem.Text = "Оператор Уоллеса";
            this.операторУоллесаToolStripMenuItem.Click += new System.EventHandler(this.операторУоллесаToolStripMenuItem_Click);
            // 
            // статистическийМетодToolStripMenuItem
            // 
            this.статистическийМетодToolStripMenuItem.Name = "статистическийМетодToolStripMenuItem";
            this.статистическийМетодToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.статистическийМетодToolStripMenuItem.Text = "Статистический метод";
            this.статистическийМетодToolStripMenuItem.Click += new System.EventHandler(this.статистическийМетодToolStripMenuItem_Click);
            // 
            // детекторГраницКанниToolStripMenuItem
            // 
            this.детекторГраницКанниToolStripMenuItem.Name = "детекторГраницКанниToolStripMenuItem";
            this.детекторГраницКанниToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.детекторГраницКанниToolStripMenuItem.Text = "Детектор границ Канни";
            this.детекторГраницКанниToolStripMenuItem.Click += new System.EventHandler(this.детекторГраницКанниToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JPEG-файлы|*.jpg|PNG-файлы|*.png";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(9, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox2.Location = new System.Drawing.Point(526, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(500, 500);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // DownConsole
            // 
            this.DownConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DownConsole.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DownConsole.ForeColor = System.Drawing.SystemColors.InfoText;
            this.DownConsole.Location = new System.Drawing.Point(0, 559);
            this.DownConsole.Name = "DownConsole";
            this.DownConsole.ReadOnly = true;
            this.DownConsole.Size = new System.Drawing.Size(1032, 20);
            this.DownConsole.TabIndex = 3;
            this.DownConsole.TabStop = false;
            this.DownConsole.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 538);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1028, 579);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DownConsole);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Цифровая обработка изображений";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьИзображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox DownConsole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem выделениеКонтуровToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem лапласианToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дискретныйЛапласианToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расширенныйЛапласианToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрРобертсаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрСобеляToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem операторПревитаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem операторToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem операторУоллесаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem детекторГраницКанниToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статистическийМетодToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

