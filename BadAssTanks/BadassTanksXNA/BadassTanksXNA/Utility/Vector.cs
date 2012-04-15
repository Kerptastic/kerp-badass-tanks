using System;
using Microsoft.Xna.Framework;

namespace BadAssTanks
{
    /// <summary>
    /// Class with static methods that handle odds and ends math routines.
    /// </summary>
    public class MathHandler
    {
        /// <summary>
        /// Returns the normal to a polygons surface, in which the polygon defined by three vectors.
        /// </summary>
        /// <param name="vert1">First vector of the polygon.</param>
        /// <param name="vert2">Second vector of the polygon.</param>
        /// <param name="vert3">Third vector of the polygon.</param>
        /// <returns></returns>
        public static Vector3 GetSurfaceNormal(Vector3 vert1, Vector3 vert2, Vector3 vert3)
        {
            //create the edges from the vertices
            Vector3 normal;

            float aX, aY, aZ;
            float bX, bY, bZ;

            //edge 1
            aX = vert2.X - vert1.X;
            aY = vert2.Y - vert1.Y;
            aZ = vert2.Z - vert1.Z;

            //edge 2
            bX = vert3.X - vert1.X;
            bY = vert3.Y - vert1.Y;
            bZ = vert3.Z - vert1.Z;

            //get the normal data (cross product of the 2 edges)
            normal.X = (aY * bZ) - (aZ * bY);
            normal.Y = (aZ * bX) - (aX * bZ);
            normal.Z = (aX * bY) - (aY * bX);

            //normalize
            normal = Vector3.Normalize(normal);

            return normal;
        }
    }
}
