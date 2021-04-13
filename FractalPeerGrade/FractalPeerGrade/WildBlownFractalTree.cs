using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fractal_PeerGrade
{
    /// <summary>
    /// Класс для обдуваемого ветром фрактального дерева.
    /// </summary>
    class WildBlownFractalTree : Fractal
    {
        PictureBox pictureBox1;
        static Graphics graphics;
        static public Pen pen1;
        static int iter;
        static int maxDepth;
        // Отношение длины отрезков на предыдушей итерации к длине на данной итерации.
        static double ratio;
        static double length;
        static double rightUserAngle, leftUserAngle;

        /// <summary>
        /// Конструктор обдуваемого ветром фрактального дерева.
        /// </summary>
        /// <param name="pictureBox">
        /// Передаюшееся из программы поле для рисования.
        /// </param>
        /// <param name="trackBar1">
        /// Трекбар для глубины рекурсии.
        /// </param>
        /// <param name="trackBar2">
        /// Трекбар для угла наклона правого отрезка.
        /// </param>
        /// <param name="trackBar3">
        /// Трекбар для угла наклона левого отрезка.
        /// </param>
        /// <param name="trackBar4">
        /// Трекбар для отношения длины отрезков на предыдушей итерации к длине на данной итерации.
        /// </param>
        /// <param name="pen01">
        /// Чёрный карандаш.
        /// </param>
        /// <param name="graphics0"></param>
        public WildBlownFractalTree(PictureBox pictureBox, TrackBar trackBar1, TrackBar trackBar2, TrackBar trackBar3, TrackBar trackBar4, Pen pen01, Graphics graphics0)
        {

            pictureBox1 = pictureBox;
            graphics = graphics0;
            pen1 = pen01;
            graphics.Clear(Color.White);
            float w = pictureBox1.Width;
            float h = pictureBox1.Height;
            maxDepth = iter = trackBar1.Value;
            rightUserAngle = 5 * trackBar2.Value;
            leftUserAngle = 5 * trackBar3.Value;
            length = h / 6;
            ratio = trackBar4.Value / 10.0;
            FractalDraw(new PointF(w / 2, 5 * h / 6),
                new PointF((float)(w / 2), 4 * h / 6), 0, iter);
        }
        /// <summary>
        /// Переопределить метод не удалось, поэтому использую сокрытие.
        /// </summary>
        /// <param name="point0">
        /// </param>
        /// <param name="point1"></param>
        /// <param name="point3"></param>
        /// <param name="iterationNumber"></param>
        /// <returns></returns>
        override public int FractalDraw(PointF point0, PointF point1, PointF point3, int iterationNumber) { return iterationNumber; }
        /// <summary>
        /// Рекурсивный метод отрисовки фрактала.
        /// </summary>
        /// <param name="point0">
        /// Точка начала отрезка.
        /// </param>
        /// <param name="point1">
        /// Точка конца отрезка.
        /// </param>
        /// <param name="angle">
        /// Угол наклона.
        /// </param>
        /// <param name="iterationNumber">
        /// Номер итерации. Что-то вроде обратного отсчёта.
        /// </param>
        /// <returns></returns>
        static int FractalDraw(PointF point0, PointF point1, double angle, int iterationNumber)
        {
            // Дейтсвия для первой итерации.
            if (iterationNumber == maxDepth)
            {
                graphics.DrawLine(pen1, point0, point1);
                double angleMinus = -leftUserAngle;
                double anglePlus = rightUserAngle;
                FractalDraw(point0, point1, anglePlus, iterationNumber - 1);
                FractalDraw(point0, point1, angleMinus, iterationNumber - 1);
            }
            // Дейтсвия для последующих итераций.
            else if (iterationNumber > 0)
            {
                var p2 = new PointF((float)(point1.X - length / Math.Pow(ratio, maxDepth - iterationNumber) * Math.Sin(angle * Math.PI * 2 / 360.0)), (float)(point1.Y - length / Math.Pow(ratio, maxDepth - iterationNumber) * Math.Cos(angle * Math.PI * 2 / 360.0)));
                graphics.DrawLine(pen1, point1, p2);
                FractalDraw(point1, p2, angle - leftUserAngle, iterationNumber - 1);
                FractalDraw(point1, p2, angle + rightUserAngle, iterationNumber - 1);
            }
            return iterationNumber;
        }
    }
}
