using System;
using System.Collections;
using System.Text;

namespace BadAssTanks
{
    public class CollisionHandler
    {
        private static CollisionHandler m_instance = null;

        public struct CollisionResult
        {
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        private CollisionHandler()
        {

        }
        
        /// <summary>
        /// Retrieve the instance of the collision handler.
        /// </summary>
        /// <returns></returns>
        public static CollisionHandler GetInstance()
        {
            if (m_instance == null)
                m_instance = new CollisionHandler();

            return m_instance;
        }

        /// <summary>
        /// Check for a intersection between polygons for a collision of two bounding shapes.
        /// </summary>
        /// <returns></returns>
        public bool CheckOABBIntersection(BoundingShape2D polyA, BoundingShape2D polyB)
        {
            bool collision = false;

            for (int edgeCount1 = 0; edgeCount1 < polyA.EDGES.Count; edgeCount1++)
            {
                for (int edgeCount2 = 0; edgeCount2 < polyB.EDGES.Count; edgeCount2++)
                {
                    collision = CheckLineIntersection(polyA.EDGES[edgeCount1], polyB.EDGES[edgeCount2]);

                    if (collision)
                        return true;
                }
            }

            return collision;
        }

        private bool CheckLineIntersection(BoundingShape2D.Edge edge1, BoundingShape2D.Edge edge2)
        {
            float e1pointAX = edge1.pointA.X; 
            float e1pointAY = edge1.pointA.Y;

            float e1pointBX = edge1.pointB.X;
            float e1pointBY = edge1.pointB.Y;

            // (bX - aX) * (dY - cY) - (bY - aY) * (dX - cX)
            float denom = (e1pointBX - e1pointAX) * (edge2.pointB.Y - edge2.pointA.Y) -
                (e1pointBY - e1pointAY) * (edge2.pointB.X - edge2.pointA.X);

            if (denom == 0.0f)
                return false;

            // (aY - cY) * (dX - cX) - (aX - cX) * (dY - cY)
            float r = ((e1pointAY - edge2.pointA.Y) * (edge2.pointB.X - edge2.pointA.X) -
                (e1pointAX - edge2.pointA.X) * (edge2.pointB.Y - edge2.pointA.Y)) / denom;

            // (aY - cY) * (bX - aX) - (aX - cX) * (bY - aY)
            float s = ((e1pointAY - edge2.pointA.Y) * (e1pointBX - edge1.pointA.X) -
                (e1pointAX - edge2.pointA.X) * (e1pointBY - edge1.pointA.Y)) / denom;

            if (r >= 0.0f && r <= 1.0f)
                if (s >= 0.0f && s <= 1.0f)
                    return true;

            return false;
        }
    }
}
