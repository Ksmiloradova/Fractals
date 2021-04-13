using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fractal_PeerGrade
{
    /// <summary>
    /// Класс для множества Кантора.
    /// </summary>
    class KantorSet : Fractal
    {
        static Pen pen1;
        static Graphics graphics;
        static int iter;
        static int maxDepth;
        // Отношения ширины линии и белого пространства между итерациями.
        static double ratio;
        static float width;
        static float height;

        /// <summary>
        /// Конструктор множества Кантора.
        /// </summary>
        /// <param name="pictureBox">
        /// Передаюшееся из программы поле для рисования. (Здесь и далее читай "Переманная для ...".).
        /// </param>
        /// <param name="trackBar1">
        /// Трекбар для глубины рекурсии.
        /// </param>
        /// <param name="trackBar2">
        /// Трекбар для расстояния между итерациями.
        /// </param>
        /// <param name="graphics0"></param>
        public KantorSet(PictureBox pictureBox, TrackBar trackBar1, TrackBar trackBar2, Graphics graphics0)
        {
            graphics = graphics0;
            graphics.Clear(Color.White);
            maxDepth = iter = trackBar1.Value;
            graphics.Clear(Color.White);
            width = pictureBox.Width;
            height = pictureBox.Height;
            ratio = height / (4 * maxDepth + 2);
            pen1 = new Pen(Color.Black, (float)(ratio / (trackBar2.Value / 10.0)));

            FractalDraw(new PointF((float)(width / 5), (float)(3 * ratio)),
                new PointF((float)(4 * width / 5), (float)(3 * ratio)),
                new PointF(1, 1), iter);
        }

        /// <summary>
        /// Рекурсивный метод отрисовки фрактала.
        /// </summary>
        /// <param name="point1">
        /// Точка начала первой линии.
        /// </param>
        /// <param name="point2">
        /// Точка конца первой линии.
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
            // Дейтсвия для первой итерации.
            if (iterationNumber == maxDepth)
            {
                graphics.DrawLine(pen1, point1, point2);
                FractalDraw(point1, point2, point3, iterationNumber - 1);
            }
            // Дейтсвия для последующих итераций.
            else if (iterationNumber > 0)
            {
                var p4 = new PointF(point1.X, (float)(ratio * (4 * (maxDepth + 1 - iterationNumber) - 1)));
                var p5 = new PointF((float)Math.Round((point2.X + 2 * point1.X) / 3, 0), (float)(ratio * (4 * (maxDepth + 1 - iterationNumber) - 1)));
                graphics.DrawLine(pen1, p4, p5);
                var p6 = new PointF((float)Math.Round((2 * point2.X + point1.X) / 3), (float)(ratio * (4 * (maxDepth + 1 - iterationNumber) - 1)));
                var p7 = new PointF(point2.X, (float)(ratio * (4 * (maxDepth + 1 - iterationNumber) - 1)));

                graphics.DrawLine(pen1, p7, p6);

                FractalDraw(p4, p5, point3, iterationNumber - 1);
                FractalDraw(p6, p7, point3, iterationNumber - 1);

            }
            return iterationNumber;
        }
    }
}
