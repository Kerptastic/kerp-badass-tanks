using System;
using System.Collections;

namespace BadAssTanks
{
    public class BoundingShape
    {
        private ArrayList m_points = null;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="points"> A clockwise list of points that define the bounding shape. </param>
        public BoundingShape(ArrayList points)
        {
            m_points = points;
        }

        /// <summary>
        /// Move the bounding shape the desired X and Y values.
        /// </summary>
        /// <param name="addX"></param>
        /// <param name="addY"></param>
        public void Move(float addX, float addY)
        {
            for(int pointCount = 0; pointCount < m_points.Count; pointCount++)
            {
                ((BoundingPoint)m_points[pointCount]).X += addX;
                ((BoundingPoint)m_points[pointCount]).Y += addY;
            }
        }






        public void PrintShape()
        {
            for (int pointCount = 0; pointCount < m_points.Count; pointCount++)
            {
                Console.WriteLine(((BoundingPoint)m_points[pointCount]).X);
                Console.WriteLine(((BoundingPoint)m_points[pointCount]).Y);
            }
        }

    }

    /// <summary>
    /// Creates a bounding point of float values to use for bounding shape creation.
    /// </summary>
    public class BoundingPoint
    {
        private float x;
        public float X { get { return x; } set { x = value; } }

        private float y;
        public float Y { get { return y; } set { y = value; } }

        public BoundingPoint(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
