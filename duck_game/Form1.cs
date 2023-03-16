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

namespace zad2
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string nick;
        private int score = 1;
        private int gscore = 0;
        private int zm = 1;
        private int czas = 0;
        

        private void button1_Click(object sender, EventArgs e)
        {
            nick = textBox1.Text;
            button1.Visible = false;
            textBox1.Visible = false;
            label1.Visible = false;
            this.BackgroundImage = Properties.Resources.duck2;
            label2.Visible = true;
            label3.Visible = true;
            trackBar1.Visible = true;
            // timer1.Enabled = true;
            button2.Visible = true;
            button3.Visible = true;
            label4.Visible = true;
            textBox2.Visible = true;
            this.Cursor = Cursors.Cross;





        }

        private void button2_Click(object sender, EventArgs e)
        {
            gscore++;
            button2.Visible = false;
            Point loc = button2.Location;
            loc.X = 0;
            loc.Y = 0;
            button2.Location = loc;
            Random r = new Random();
            int zm2 = 10;
            
            czas = timer1.Interval - (zm2 + r.Next(10, 50));
            if (czas > 1) timer1.Interval = czas;

            timer1.Stop();
            timer1.Start();
            score_res();






        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            score = 1;
            gscore = 0;
            timer1.Stop();
            timer2.Stop();
            zm = 4000/trackBar1.Value;
            timer2.Interval = zm;
            button2.Visible = true;
            Point loc = button2.Location;
            loc.X = 369;
            loc.Y = 116;
            button2.Location = loc;
            score_res();

        }

        public void game()
        {
            timer2.Stop();
            timer2.Start();

            Random r = new Random();
            Point loc = button2.Location;
            
            loc.X = 50+r.Next(0, 650);
            loc.Y = 25+r.Next(0, 300);
            button2.Location = loc;
            button2.Visible = true;
            score++;
            score_res();


        }


        private void score_res()
        {

            textBox2.Text = " " + Convert.ToString(gscore) + " / " + Convert.ToString(score) + " ";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            game();
            timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            button2.Visible = false;
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            timer1.Stop();
            button1.Visible = true;
            textBox1.Visible = true;
            label1.Visible = true;
            this.BackgroundImage = Properties.Resources.duck1;
            label2.Visible = false;
            label3.Visible = false;
            trackBar1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            label4.Visible = false;
            textBox2.Visible = false;
            this.Cursor = Cursors.Arrow;
            trackBar1.Value = 1;
            zm = 1;
            Point loc = button2.Location;
            loc.X = 369;
            loc.Y = 116;
            button2.Location = loc;
            using (StreamWriter sw = new StreamWriter("sboard.txt", true))
            {
                sw.WriteLine(nick+" " + Convert.ToString(gscore) + " / " + Convert.ToString(score-1) + "\r\n");
            }
            score = 1;
            gscore = 0;
        }
    }
}
