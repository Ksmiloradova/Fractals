using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fractal_PeerGrade
{
    /// <summary>
    /// Класс для ковра Серпинского.
    /// </summary>
    class SierpinskiCarpet : Fractal
    {
        static Graphics graphics;
        static float weight;
        static float height;
        static SolidBrush pen1;
        static SolidBrush pen2;
        static int iter;
        /// <summary>
        /// Констуктор ковра Серпинского.
        /// </summary>
        /// <param name="pictureBox">
        /// Передаюшееся из программы поле для рисования.
        /// </param>
        /// <param name="trackBar">
        /// Трекбар для глубины рекурсии.
        /// </param>
        /// <param name="graphics0"></param>
        public SierpinskiCarpet(PictureBox pictureBox, TrackBar trackBar, Graphics graphics0)
        {
            graphics = graphics0;
            pen1 = new SolidBrush(Color.Black);
            pen2 = new SolidBrush(Color.White);
            graphics.Clear(Color.White);
            iter = trackBar.Value;
            graphics.Clear(Color.White);
            weight = pictureBox.Width;
            height = pictureBox.Height;
            graphics.FillRectangle(pen1, (float)(Math.Min(weight, height) / 11.0), (float)(Math.Min(weight, height) / 11.0), (float)(Math.Min(weight, height) * 9 / 11.0), (float)(Math.Min(weight, height) * 9 / 11.0));
            FractalDraw(new PointF((float)(Math.Min(weight, height) / 11.0), (float)(Math.Min(weight, height) / 11.0)),
                new PointF((float)(Math.Min(weight, height) * 10 / 11.0), (float)(Math.Min(weight, height) * 10 / 11.0)),
                new PointF(1, 1),
                iter);
        }

        /// <summary>
        /// Рекурсивный метод отрисовки фрактала.
        /// </summary>
        /// <param name="point1">
        /// Верхний левый угол квадрата.
        /// </param>
        /// <param name="point2">
        /// Правый нижний угол квадрата.
        /// </param>
        /// <param name="point3">
        /// Пустышка, чтобы переопределить метод родителя.
        /// </param>
        /// <param name="iterationNumber">
        /// Номер итерации. Что-то вроде обратного отсчёта.
        /// </param>
        /// <returns></returns>
        public override int FractalDraw(PointF point1, PointF point2, PointF point3, int iterationNumber)
        {
            if (iterationNumber > 0)
            {
                var p4 = new PointF((point2.X + 2 * point1.X) / 3, (point2.Y + 2 * point1.Y) / 3);
                var p5 = new PointF((2 * point2.X + point1.X) / 3, (point1.Y + 2 * point2.Y) / 3);

                graphics.FillRectangle(pen2, p4.X, p4.Y, p5.X - p4.X, p5.Y - p4.Y);

                FractalDraw(point1, p4, point3, iterationNumber - 1);
                FractalDraw(new PointF(p4.X, point1.Y), new PointF(p5.X, p4.Y), point3, iterationNumber - 1);
                FractalDraw(new PointF(p5.X, point1.Y), new PointF(point2.X, p4.Y), point3, iterationNumber - 1);
                FractalDraw(new PointF(point1.X, p4.Y), new PointF(p4.X, p5.Y), point3, iterationNumber - 1);
                FractalDraw(new PointF(p5.X, p4.Y), new PointF(point2.X, p5.Y), point3, iterationNumber - 1);
                FractalDraw(new PointF(point1.X, p5.Y), new PointF(p4.X, point2.Y), point3, iterationNumber - 1);
                FractalDraw(new PointF(p4.X, p5.Y), new PointF(p5.X, point2.Y), point3, iterationNumber - 1);
                FractalDraw(p5, point2, point3, iterationNumber - 1);
            }
            return iterationNumber;
        }
    }
}
