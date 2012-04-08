using System;

using Microsoft.DirectX;

namespace BadAssTanks
{
    class VectorMath
    {
        public VectorMath()
        {
        }

        public Vector3 GetSurfaceNormal(Vector3 vert1, Vector3 vert2, Vector3 vert3)
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
