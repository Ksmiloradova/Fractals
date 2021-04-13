using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fractal_PeerGrade
{
    /// <summary>
    /// Класс для кривой Коха.
    /// </summary>
    class KochCurve : Fractal
    {
        PictureBox pictureBox1;
        static Graphics graphics;
        static public Pen pen1;
        static Pen pen2;
        static int iter;
        // Количество итераций.
        static int maxDepth;
        /// <summary>
        /// Конструктор кривой Коха.
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
        /// <param name="pen02">
        /// Белый карандаш.
        /// </param>
        /// <param name="graphics0"></param>
        public KochCurve(PictureBox pictureBox, TrackBar trackBar, Pen pen01, Pen pen02, Graphics graphics0)
        {
            pen1 = pen01;
            pen2 = pen02;
            graphics = graphics0;
            pictureBox1 = pictureBox;
            pictureBox1 = pictureBox;
            maxDepth = iter = trackBar.Value;
            graphics.Clear(Color.White);
            float weight = pictureBox1.Width;
            float height = pictureBox1.Height;
            FractalDraw(new PointF(weight / 2, 6 * height / 5),
                new PointF((float)(weight / 2 - 3 * weight / (5 * Math.Sqrt(3))), 3 * height / 5),
                new PointF((float)(weight / 2 + 3 * weight / (5 * Math.Sqrt(3))), 3 * height / 5),
                iter);
        }

        /// <summary>
        /// Рекурсивный метод отрисовки фрактала.
        /// </summary>
        /// <param name="point1">
        /// Точка начала линии.
        /// </param>
        /// <param name="point2">
        /// Точка конца линии.
        /// </param>
        /// <param name="point3">
        /// Точка третьей вершины для воображаемого треугольника (вспомогательная).
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
                graphics.DrawLine(pen1, point2, point3);

                FractalDraw(point2, point3, point1, iterationNumber - 1);
            }
            // Дейтсвия для последующих итераций.
            else if (iterationNumber > 0)
            {
                var p4 = new PointF((point2.X + 2 * point1.X) / 3, (point2.Y + 2 * point1.Y) / 3);
                var p5 = new PointF((2 * point2.X + point1.X) / 3, (point1.Y + 2 * point2.Y) / 3);
                var ps = new PointF((point2.X + point1.X) / 2, (point2.Y + point1.Y) / 2);
                var pn = new PointF((4 * ps.X - point3.X) / 3, (4 * ps.Y - point3.Y) / 3);

                graphics.DrawLine(pen1, p4, pn);
                graphics.DrawLine(pen1, p5, pn);
                graphics.DrawLine(pen2, p4, p5);

                FractalDraw(p4, pn, p5, iterationNumber - 1);
                FractalDraw(pn, p5, p4, iterationNumber - 1);
                FractalDraw(point1, p4, new PointF((2 * point1.X + point3.X) / 3,
                    (2 * point1.Y + point3.Y) / 3), iterationNumber - 1);
                FractalDraw(p5, point2, new PointF((2 * point2.X + point3.X) / 3,
                    (2 * point2.Y + point3.Y) / 3), iterationNumber - 1);

            }
            return iterationNumber;
        }
    }
}
