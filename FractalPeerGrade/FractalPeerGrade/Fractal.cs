using System.Drawing;

namespace Fractal_PeerGrade
{
    /// <summary>
    /// Абстрактный класс, родитель всех фракталов.
    /// </summary>
    abstract class Fractal
    {
        /// <summary>
        /// Поле "длина отрезка".
        /// </summary>
        protected double LengthOfSegment { get; set; }

        /// <summary>
        /// Абстрактный метод построения фрактала.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="point3"></param>
        /// <param name="iterationNumber"></param>
        /// <returns></returns>
        public abstract int FractalDraw(PointF point1, PointF point2, PointF point3, int iterationNumber);


    }
}
