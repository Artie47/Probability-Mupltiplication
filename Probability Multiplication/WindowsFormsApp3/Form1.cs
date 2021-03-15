using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp3
{
   
    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        int k = 0;

        int bb = 0;
        int wb = 0;
        int ww = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Draw()
        {

            Bitmap bmp1 = new Bitmap(200, 200);
            Graphics graph1 = Graphics.FromImage(bmp1);
            Brush pen1 = new LinearGradientBrush(new Point(0,10), new Point(0,160), Color.White, Color.LightGray);
            graph1.FillEllipse(pen1, 10, 10, 150, 150);


            Bitmap bmp2 = new Bitmap(200, 200);
            Graphics graph2 = Graphics.FromImage(bmp2);
            Brush pen2 = new LinearGradientBrush(new Point(0, 10), new Point(0, 250), Color.Black, Color.DarkGray);
            graph2.FillEllipse(pen2, 10, 10, 150, 150);


            char[] Basket1 = { 'Ч', 'Ч', 'Ч', 'Ч', 'Б', 'Б', 'Б', 'Б', 'Б' };
            char[] Basket2 = { 'Ч', 'Ч', 'Ч', 'Ч', 'Б', 'Б', 'Б', 'Б', 'Б' };

            

            char pulled_1 = Basket1[rnd.Next(Basket1.Length)];
            char pulled_2 = Basket2[rnd.Next(Basket2.Length)];


            if (pulled_1 == 'Ч' && pulled_2 == 'Ч')
            {
                pictureBox1.Image = bmp2;
                pictureBox2.Image = bmp2;

                bb++;
            }
            else if (pulled_1 == 'Ч' && pulled_2 == 'Б')
            {
                pictureBox1.Image = bmp2;
                pictureBox2.Image = bmp1;

                wb++;

            }
            else if (pulled_1 == 'Б' && pulled_2 == 'Ч')
            {
                pictureBox1.Image = bmp1;
                pictureBox2.Image = bmp2;

                wb++;
            }
            else if(pulled_1 == 'Б' && pulled_2 == 'Б')
            {
                pictureBox1.Image = bmp1;
                pictureBox2.Image = bmp1;

                ww++;
            }

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < 100; a++)
            {
                Draw();
                k++;
                button1.Text = "Повторить +100";
                label1.Text = "N: " + Convert.ToString(k);
                label2.Text = "Количество наборов ББ: " + Convert.ToString(ww);
                label3.Text = "Количество наборов БЧ: " + Convert.ToString(wb);
                label4.Text = "Количество наборов ЧЧ: " + Convert.ToString(bb);
                label5.Text = "Относительная частота P(ББ) = " + Convert.ToString(Math.Round((double)ww / (double)k, 6));


                chart1.Series["Черный-Черный"].Points.AddXY(1, Convert.ToString(bb));
                chart1.Series["Белый-Черный"].Points.AddXY(2, Convert.ToString(wb));
                chart1.Series["Белый-Белый"].Points.AddXY(3, Convert.ToString(ww));



                chart2.Series["P(ББ)"].Points.AddXY(k, (double)ww / (double)k);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Draw();
            k++;
            button2.Text = "Повторить +1";
            label1.Text = "N: " + Convert.ToString(k);
            label2.Text = "Количество наборов ББ: " + Convert.ToString(ww);
            label3.Text = "Количество наборов БЧ: " + Convert.ToString(wb);
            label4.Text = "Количество наборов ЧЧ: " + Convert.ToString(bb);
            label5.Text = "Относительная частота P(ББ) = " + Convert.ToString(Math.Round((double)ww / k, 6));


            chart1.Series["Черный-Черный"].Points.AddXY(1, Convert.ToString(bb));
            chart1.Series["Белый-Черный"].Points.AddXY(2, Convert.ToString(wb));
            chart1.Series["Белый-Белый"].Points.AddXY(3, Convert.ToString(ww));


            chart2.Series["P(ББ)"].Points.AddXY(k, (double)ww / k);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            trackBar2.Maximum = 5000;
            

            for (int a = 0; a < trackBar2.Value; a++)
            {
                k++;
                Draw();
                
                label1.Text = "N: " + Convert.ToString(k);
                label2.Text = "Количество наборов ББ: " + Convert.ToString(ww);
                label3.Text = "Количество наборов БЧ: " + Convert.ToString(wb);
                label4.Text = "Количество наборов ЧЧ: " + Convert.ToString(bb);
                label5.Text = "Относительная частота P(ББ) = " + Convert.ToString(Math.Round((double)ww / (double)k, 6));

                chart1.Series["Черный-Черный"].Points.AddXY(1, Convert.ToString(bb));
                chart1.Series["Белый-Черный"].Points.AddXY(2, Convert.ToString(wb));
                chart1.Series["Белый-Белый"].Points.AddXY(3, Convert.ToString(ww));

                chart2.Series["P(ББ)"].Points.AddXY(k+trackBar2.Value, (double)ww / (double)k);

            }
        
            

            

            

        }
    }
}
