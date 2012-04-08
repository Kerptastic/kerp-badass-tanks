using System;
using System.Collections;

namespace BadAssTanks
{
    class TrigHandler
    {
        private static TrigHandler m_instance = null;

        private ArrayList m_sinTable0to89 = null;
        private ArrayList m_sinTable90to179 = null;

        //private float[] m_sinTable0to89 = 
        //    {
        //        0.000f, 0.017f, 0.035f, 0.052f, 0.070f, 0.087f, 0.105f, 0.122f, 0.139f, 0.156f, 0.174f,
        //        0.191f, 0.208f, 0.225f, 0.242f, 0.259f, 0.276f, 0.292f, 0.309f, 0.326f, 0.342f, 0.358f, 
        //        0.375f, 0.391f, 0.407f, 0.423f, 0.438f, 0.454f, 0.469f, 0.485f, 0.500f, 0.515f, 0.530f, 
        //        0.545f, 0.559f, 0.574f, 0.588f, 0.602f, 0.616f, 0.629f, 0.643f, 0.656f, 0.669f, 0.682f, 
        //        0.695f, 0.707f, 0.719f, 0.731f, 0.743f, 0.755f, 0.766f, 0.777f, 0.788f, 0.799f, 0.809f, 
        //        0.819f, 0.829f, 0.839f, 0.848f, 0.857f, 0.866f, 0.875f, 0.883f, 0.891f, 0.899f, 0.906f, 
        //        0.914f, 0.921f, 0.927f, 0.934f, 0.940f, 0.946f, 0.951f, 0.956f, 0.961f, 0.966f, 0.970f,
        //        0.974f, 0.978f, 0.982f, 0.985f, 0.988f, 0.990f, 0.993f, 0.995f, 0.996f, 0.998f, 0.999f, 
        //        0.999f, 1.000f, 1.000f
        //    };

        //private float[] m_sinTable90to179 = 
        //    {
        //        1.000f, 1.000f, 0.999f, 0.999f, 0.998f, 0.996f, 0.995f, 0.993f, 0.990f, 0.988f, 0.985f, 
        //        0.982f,	0.978f,	0.974f, 0.970f,	0.966f,	0.961f,	0.956f,	0.951f,	0.946f,	0.940f,	0.934f,	
        //        0.927f,	0.921f,	0.914f, 0.906f,	0.899f,	0.891f,	0.883f,	0.875f,	0.866f,	0.857f,	0.848f,	
        //        0.839f,	0.829f,	0.819f, 0.809f,	0.799f,	0.788f,	0.777f,	0.766f,	0.755f,	0.743f,	0.731f,	
        //        0.719f,	0.707f,	0.695f, 0.682f,	0.669f,	0.656f,	0.643f,	0.629f,	0.616f,	0.602f,	0.588f,	
        //        0.574f,	0.559f,	0.545f, 0.530f,	0.515f,	0.500f,	0.485f,	0.469f,	0.454f,	0.438f,	0.423f,	
        //        0.407f,	0.391f,	0.375f, 0.358f,	0.342f,	0.326f,	0.309f,	0.292f,	0.276f,	0.259f,	0.242f,	
        //        0.225f,	0.208f,	0.191f, 0.174f,	0.156f,	0.139f,	0.122f,	0.105f,	0.087f,	0.070f,	0.052f,	
        //        0.035f,	0.017f,	0.000f			                    
        //    };

        private TrigHandler()
        {
            m_sinTable0to89 = new ArrayList();
            m_sinTable90to179 = new ArrayList();

            this.GenerateTables();
        }

        public static TrigHandler GetInstance()
        {
            if (m_instance == null)
                m_instance = new TrigHandler();

            return m_instance;
        }

        private void GenerateTables()
        {
            for (int x = 0; x < 90; x++)
            {
                m_sinTable0to89.Add((float)Math.Sin(x * Math.PI / 180.0f));
            }

            for (int x = 90; x < 180; x++)
            {
                m_sinTable90to179.Add((float)Math.Sin(x * Math.PI / 180.0f));
            }
        }

        public float GetSin(float degreeInDegrees)
        {
            int degrees = (int)degreeInDegrees;

            if (degrees >= 0 && degrees < 90)
            {
                return (float)m_sinTable0to89[degrees];
            }
            else if (degrees >= 90 && degrees < 180)
            {
                return (float)m_sinTable90to179[degrees - 90];
            }
            else if (degrees >= 180 && degrees < 270)
            {
                return -(float)m_sinTable0to89[degrees - 180];
            }
            else if (degrees >= 270 && degrees < 360)
            {
                return -(float)m_sinTable90to179[degrees - 270];
            }
            else
            {
                return 0.0f;
            }
        }

        public float GetCos(float degreeInDegrees)
        {
            int degrees = (int)degreeInDegrees;

            if (degrees >= 0 && degrees < 90)
            {
                return (float)m_sinTable90to179[degrees];
            }
            else if (degrees >= 90 && degrees < 180)
            {
                return -(float)m_sinTable0to89[degrees - 90];
            }
            else if (degrees >= 180 && degrees < 270)
            {
                return -(float)m_sinTable90to179[degrees - 180];
            }
            else if (degrees >= 270 && degrees < 360)
            {
                return (float)m_sinTable0to89[degrees - 270];
            }
            else
            {
                return 0.0f;
            }
        }
    }
}
