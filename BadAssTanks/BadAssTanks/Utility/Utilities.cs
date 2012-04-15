using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BadAssTanks.Utility
{
    /// <summary>
    /// Represents a pair of int values.
    /// </summary>
    public class PairInt
    {
        /// <summary>
        /// The x value of the pair.
        /// </summary>
        private int _x;
        public int X { get; set; }
        /// <summary>
        /// The y value of the pair.
        /// </summary>
        private int _y;
        public int Y { get; set; }

        /// <summary>
        /// Creates a new integer pair.
        /// </summary>
        /// <param name="x">The x value of the pair</param>
        /// <param name="y">The y value of the pair</param>
        public PairInt(int x, int y)
        {
            this._x = x;
            this._y = y;
        }
    }

    /// <summary>
    /// Represents a pair of float values.
    /// </summary>
    public class PairFloat
    {
        /// <summary>
        /// The x value of the pair.
        /// </summary>
        private float _x;
        public float X { get; set; }
        /// <summary>
        /// The y value of the pair.
        /// </summary>
        private float _y;
        public float Y { get; set; }

        /// <summary>
        /// Creates a new float pair.
        /// </summary>
        /// <param name="x">The x value of the pair</param>
        /// <param name="y">The y value of the pair</param>
        public PairFloat(float x, float y)
        {
            this._x = x;
            this._y = y;
        }
    }
}
