using Fractal_PeerGrade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FractalPeerGrade
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Метод, инициализирующий форму.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        static public Graphics graphics;
        static Pen pen1;
        static Pen pen2;

        /// <summary>
        /// Метод загрузки формы. 
        /// Инициализирует и закрашивает белым поле для рисования и 
        /// инициализирует два карандаша.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            graphics = pictureBox1.CreateGraphics();
            pen1 = new Pen(Color.Black, 1);
            pen2 = new Pen(Color.White, 1);
            graphics.Clear(Color.White);
        }

        /// <summary>
        /// Метод обработки нажатия кнопки во вкладке "Фракталное дерево".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            new WildBlownFractalTree(pictureBox1, trackBar4, trackBar5, trackBar7, trackBar12, pen1, graphics);
        }

        /// <summary>
        /// Метод обработки нажатия кнопки во вкладке "Треугольник Серпинского".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            new SierpinskiTriangle(pictureBox1, trackBar9, pen1, graphics);
        }

        /// <summary>
        /// Метод обработки нажатия кнопки во вкладке "Кривая Коха".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            new KochCurve(pictureBox1, trackBar10, pen1, pen2, graphics);
        }

        /// <summary>
        /// Метод обработки нажатия кнопки во вкладке "Ковёр Серпинского".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            new SierpinskiCarpet(pictureBox1, trackBar13, graphics);
        }

        /// <summary>
        /// Метод обработки нажатия кнопки во вкладке "Множество Кантора".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            new KantorSet(pictureBox1, trackBar1, trackBar2, graphics);
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
