using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Fractal_PeerGrade
{
    /// <summary>
    /// Класс для треугольника Серпинского.
    /// </summary>
    class SierpinskiTriangle : Fractal
    {
        PictureBox pictureBox1;
        static Pen pen1;
        static Graphics graphics;
        static int iter;
        static int maxDepth;

        /// <summary>
        /// Консруктор для треугольника Серпинского.
        /// </summary>
        /// <param name="pictureBox">
        /// Передаюшееся из программы поле для рисования.
        /// </param>
        /// <param name="trackBar">
        /// Трекбар для глубины рекурсии.
        /// </param>
        /// <param name="pen01">
        /// Чёрный карандаш.
        /// </param>
        /// <param name="graphics0"></param>
        public SierpinskiTriangle(PictureBox pictureBox, TrackBar trackBar, Pen pen01, Graphics graphics0)
        {
            pen1 = pen01;
            graphics = graphics0;
            pictureBox1 = pictureBox;
            maxDepth = iter = trackBar.Value;
            graphics.Clear(Color.White);
            float weight = pictureBox1.Width;
            float height = pictureBox1.Height;
            FractalDraw(new PointF(weight / 2, height / 5),
                new PointF((float)(weight / 2 - 3 * weight / (5 * Math.Sqrt(3))), 4 * height / 5),
                new PointF((float)(weight / 2 + 3 * weight / (5 * Math.Sqrt(3))), 4 * height / 5),
                iter);
        }
        /// <summary>
        /// Рекурсивный метод отрисовки фрактала.
        /// </summary>
        /// <param name="point1">
        /// Верхняя точка треугольника.
        /// </param>
        /// <param name="point2">
        /// Левая точка треугольника.
        /// </param>
        /// <param name="point3">
        /// Правая точка треугольника.
        /// </param>
        /// <param name="iterationNumber">
        /// Номер итерации. Что-то вроде обратного отсчёта.
        /// </param>
        /// <returns></returns>
        override public int FractalDraw(PointF point1, PointF point2, PointF point3, int iterationNumber)
        {
            // Дейтсвия для первой итерации.
            if (iterationNumber == maxDepth)
            {
                graphics.DrawLine(pen1, point1, point2);
                graphics.DrawLine(pen1, point2, point3);
                graphics.DrawLine(pen1, point3, point1);

                FractalDraw(point2, point3, point1, iterationNumber - 1);
            }
            // Дейтсвия для последующих итераций.
            else if (iterationNumber > 0)
            {
                var p4 = new PointF((point2.X + point1.X) / 2, (point2.Y + point1.Y) / 2);
                var p5 = new PointF((point2.X + point3.X) / 2, (point3.Y + point2.Y) / 2);
                var p6 = new PointF((point3.X + point1.X) / 2, (point3.Y + point1.Y) / 2);

                graphics.DrawLine(pen1, p4, p6);
                graphics.DrawLine(pen1, p5, p4);
                graphics.DrawLine(pen1, p6, p5);

                FractalDraw(point1, p4, p6, iterationNumber - 1);
                FractalDraw(point2, p4, p5, iterationNumber - 1);
                FractalDraw(point3, p5, p6, iterationNumber - 1);

            }
            return iterationNumber;
        }
    }
}
