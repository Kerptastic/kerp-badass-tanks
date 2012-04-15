using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BadAssTanks.Utility
{
    /// <summary>
    /// Provides utility functionality and data to be used by the Game Engine.
    /// </summary>
    public class Utilities
    {
        /// <summary>
        /// Represents coordinates using int values.
        /// </summary>
        public struct CoordsInt
        {
            /// <summary>
            /// The x location in the coordinates.
            /// </summary>
            public int _x;
            /// <summary>
            /// The y location in the coordinates.
            /// </summary>
            public int _y;

            /// <summary>
            /// Creates a new set of integer coordinates.
            /// </summary>
            /// <param name="x">The x location in the coordinates.</param>
            /// <param name="y">The y location in the coordinates.</param>
            public CoordsInt(int x, int y)
            {
                this._x = x;
                this._y = y;
            }
        }

        /// <summary>
        /// Represents coordinates using float values.
        /// </summary>
        public struct CoordsFloat
        {
            /// <summary>
            /// The x location in the coordinates.
            /// </summary>
            public float _x;
            /// <summary>
            /// The y location in the coordinates.
            /// </summary>
            public float _y;

            /// <summary>
            /// Creates a new set of float coordinates.
            /// </summary>
            /// <param name="x">The x location in the coordinates.</param>
            /// <param name="y">The y location in the coordinates.</param>
            public CoordsFloat(float x, float y)
            {
                this._x = x;
                this._y = y;
            }
        }
    }
}
