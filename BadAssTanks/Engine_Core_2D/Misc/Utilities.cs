using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EngineCore2D.Misc
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

    /// <summary>
    /// Static class providing utility functions to be used within the Game Engine.
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Ensure the angle value stays between -Pi and Pi so the numbers
        /// never get so large or small that they break precision or overflow.
        /// </summary>
        /// <param name="radians">The angle to clamp between -Pi and Pi.</param>
        /// <returns>A clamped angle, clamped between -Pi and Pi.</returns>
        public static float ClampAngle(float radians)
        {
            while (radians < -MathHelper.Pi)
            {
                radians += MathHelper.TwoPi;
            }
            while (radians > MathHelper.Pi)
            {
                radians -= MathHelper.TwoPi;
            }

            return radians;
        }
    }
}
