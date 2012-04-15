using System;
using System.Collections.Generic;

namespace BadAssTanks
{
    /// <summary>
    /// Handler for Trig related calculations. Upon first call to GetInstance(), this
    /// class will create a Sin table and auto populate values so the math calculations
    /// only happen once, and will be used for a table lookup.
    /// 
    /// Only works with whole number integers.
    /// </summary>
    public class TrigHandler
    {
        /// <summary>
        /// The static instance of the Trig Handler. Used for the Singleton Pattern.
        /// </summary>
        private static TrigHandler _instance = null;
        /// <summary>
        /// The table of Sin values for numbers 0 through 89.
        /// </summary>
        private List<float> _sinTable0to89 = null;
        /// <summary>
        /// The table of Sin values for numbers 90 through 179.
        /// </summary>
        private List<float> _sinTable90to179 = null;

        /// <summary>
        /// Initializes the Sin tables. Private constructor for the Singleton Pattern.
        /// </summary>
        private TrigHandler()
        {
            _sinTable0to89 = new List<float>();
            _sinTable90to179 = new List<float>();

            this.GenerateTables();
        }

        /// <summary>
        /// Retrieves the instance of this class. If this is the first call, it will
        /// instantiate the TrigHandle instance and create the Sin tables.
        /// </summary>
        /// <returns>An instance of the TrigHandler</returns>
        public static TrigHandler GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TrigHandler();
            }

            return _instance;
        }

        /// <summary>
        /// Generates the Sin tables.
        /// </summary>
        private void GenerateTables()
        {
            for (int x = 0; x < 90; x++)
            {
                _sinTable0to89.Add((float)Math.Sin(x * Math.PI / 180.0f));
            }

            for (int x = 90; x < 180; x++)
            {
                _sinTable90to179.Add((float)Math.Sin(x * Math.PI / 180.0f));
            }
        }

        /// <summary>
        /// Returns the Sin value for an angle in degrees.
        /// </summary>
        /// <param name="angleInDegrees">An angle in degrees from 0 to 360 - whole numbers only.</param>
        /// <returns>The Sin value for the angle passed in.</returns>
        public float Sin(int angleInDegrees)
        {
            if (angleInDegrees >= 0 && angleInDegrees < 90)
            {
                return _sinTable0to89[angleInDegrees];
            }
            else if (angleInDegrees >= 90 && angleInDegrees < 180)
            {
                return _sinTable90to179[angleInDegrees - 90];
            }
            else if (angleInDegrees >= 180 && angleInDegrees < 270)
            {
                return -_sinTable0to89[angleInDegrees - 180];
            }
            else if (angleInDegrees >= 270 && angleInDegrees < 360)
            {
                return -_sinTable90to179[angleInDegrees - 270];
            }
            else
            {
                return 0.0f;
            }
        }

        /// <summary>
        /// Returns the Sin value for an angle in degrees. Takes a float value, but will round
        /// to the closest degree whole number. Use this if making float angle calculations.
        /// </summary>
        /// <param name="angleInDegrees">An angle in degrees from 0 to 360 - whole numbers only.</param>
        /// <returns>The Sin value for the angle passed in.</returns>
        public float Sin(float angleInDegrees)
        {
            return Sin((int)angleInDegrees);
        }

        /// <summary>
        /// Returns the Cos value for an angle in degrees.
        /// </summary>
        /// <param name="angleInDegrees">An angle in degrees from 0 to 360 - whole numbers only.</param>
        /// <returns>The Cos value for the angle passed in.</returns>
        public float Cos(int angleInDegrees)
        {
            if (angleInDegrees >= 0 && angleInDegrees < 90)
            {
                return _sinTable90to179[angleInDegrees];
            }
            else if (angleInDegrees >= 90 && angleInDegrees < 180)
            {
                return -_sinTable0to89[angleInDegrees - 90];
            }
            else if (angleInDegrees >= 180 && angleInDegrees < 270)
            {
                return -_sinTable90to179[angleInDegrees - 180];
            }
            else if (angleInDegrees >= 270 && angleInDegrees < 360)
            {
                return _sinTable0to89[angleInDegrees - 270];
            }
            else
            {
                return 0.0f;
            }
        }

        /// <summary>
        /// Returns the Cos value for an angle in degrees. Takes a float value, but will round
        /// to the closest degree whole number. Use this if making float angle calculations.
        /// </summary>
        /// <param name="angleInDegrees">An angle in degrees from 0 to 360 - whole numbers only.</param>
        /// <returns>The Cos value for the angle passed in.</returns>
        public float Cos(float angleInDegrees)
        {
            return Cos((int)angleInDegrees);
        }
    }
}
