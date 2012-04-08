using System;

using Microsoft.DirectX;

namespace BadAssTanks
{
    public struct Vector
    {
        private float m_x, m_y;

        public Vector(float x, float y)
        {
            m_x = x;
            m_y = y;
        }

        public float X
        {
            get { return m_x; }
        }

        public float Y
        {
            get { return m_y; }
        }

        public float MAGNITUDE
        {
            get { return (float)Math.Sqrt((m_x * m_x) + (m_y * m_y)); }
        }

        public void Normalize()
        {
            float magnitude = MAGNITUDE;

            m_x = m_x / magnitude;
            m_y = m_y / magnitude;
        }

        public Vector GetNormalized()
        {
            float magnitude = MAGNITUDE;

            return new Vector(m_x / magnitude, m_y / magnitude);         
        }

        public float DotProduct(Vector v)
        {
            return ( (m_x * v.X) + (m_y * v.Y) );
        }

        public float DistanceTo(Vector v)
        {
            return ( (float)Math.Sqrt(Math.Pow(v.X - m_x, 2) + Math.Pow(v.Y - m_y, 2)) );
        }

        public Matrix ToMatrix()
        {
            Matrix matrix = new Matrix();

            matrix.M11 = m_x;
            matrix.M21 = m_y;
           
            return matrix;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.m_x + b.m_x, a.m_y + b.m_y);
        }

        public static Vector operator -(Vector a)
        {
            return new Vector(-a.m_x, -a.m_y);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.m_x - b.m_x, a.m_y - b.m_y);
        }

        public static Vector operator *(Vector a, float b)
        {
            return new Vector(a.m_x * b, a.m_y * b);
        }

        public static Vector operator *(Vector a, int b)
        {
            return new Vector(a.m_x * b, a.m_y * b);
        }

        public static Vector operator *(Vector a, double b)
        {
            return new Vector((float)(a.m_x * b), (float)(a.m_y * b));
        }

        public string ToString(bool rounded)
        {
            if (rounded)
            {
                return (int)Math.Round(m_x) + ", " + (int)Math.Round(m_y);
            }
            else
            {
                return ToString();
            }
        }

        public override string ToString()
        {
            return X + ", " + Y;
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
