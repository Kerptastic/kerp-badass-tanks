﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KerpEngine.Global
{
    /// <summary>
    /// 
    /// </summary>
    public struct VertexPositionColorNormal
    {
        public Vector3 Position;
        public Color Color;
        public Vector3 Normal;

        public readonly static VertexDeclaration VertexDeclaration = new VertexDeclaration
        (
            new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
            new VertexElement(sizeof(float) * 3, VertexElementFormat.Color, VertexElementUsage.Color, 0),
            new VertexElement(sizeof(float) * 3 + 4, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0)
        );
    }

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
        /// Ensure the angle value stays between -360 and 360 so the numbers
        /// never get so large or small that they break precision or overflow.
        /// </summary>
        /// <param name="radians">The angle to clamp between -360 and 360.</param>
        /// <returns>A clamped angle, clamped between -360 and 360.</returns>
        public static float ClampAngleDegrees(float degrees)
        {
            while (degrees < -360)
            {
                degrees += 360;
            }
            while (degrees > 360)
            {
                degrees -= 360;
            }

            return degrees;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static Vector3 ClampAngleDegrees(Vector3 degrees)
        {
            //clamp the X
            while (degrees.X < -360)
            {
                degrees.X += 360;
            }
            while (degrees.X > 360)
            {
                degrees.X -= 360;
            }

            //clamp the Y
            while (degrees.Y < -360)
            {
                degrees.Y += 360;
            }
            while (degrees.Y > 360)
            {
                degrees.Y -= 360;
            }

            //clamp the Z
            while (degrees.Z < -360)
            {
                degrees.Z += 360;
            }
            while (degrees.Z > 360)
            {
                degrees.Z -= 360;
            }

            return degrees;
        }

        /// <summary>
        /// Ensure the angle value stays between -2Pi and 2Pi so the numbers
        /// never get so large or small that they break precision or overflow.
        /// </summary>
        /// <param name="radians">The angle to clamp between -2Pi and 2Pi.</param>
        /// <returns>A clamped angle, clamped between -2Pi and 2Pi.</returns>
        public static float ClampAngleRadians(float radians)
        {
            while (radians < -MathHelper.TwoPi)
            {
                radians += MathHelper.TwoPi;
            }
            while (radians > MathHelper.TwoPi)
            {
                radians -= MathHelper.TwoPi;
            }

            return radians;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static Vector3 ClampAngleRadians(Vector3 degrees)
        {
            //clamp the X
            while (degrees.X < -MathHelper.TwoPi)
            {
                degrees.X += MathHelper.TwoPi;
            }
            while (degrees.X > MathHelper.TwoPi)
            {
                degrees.X -= MathHelper.TwoPi;
            }

            //clamp the Y
            while (degrees.Y < -MathHelper.TwoPi)
            {
                degrees.Y += MathHelper.TwoPi;
            }
            while (degrees.Y > MathHelper.TwoPi)
            {
                degrees.Y -= MathHelper.TwoPi;
            }

            //clamp the Z
            while (degrees.Z < -MathHelper.TwoPi)
            {
                degrees.Z += MathHelper.TwoPi;
            }
            while (degrees.Z > MathHelper.TwoPi)
            {
                degrees.Z -= MathHelper.TwoPi;
            }

            return degrees;
        }

        /// <summary>
        /// Draws the outline of a given rectangle with the given texture pixel.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to perform the drawing.</param>
        /// <param name="pixelTexture">The Texture to use for drawing.</param>
        /// <param name="rectangle">The Rectangle to draw the outline of.</param>
        public static void DrawBoxOutline(SpriteBatch spriteBatch, Texture2D pixelTexture, Rectangle rectangle)
        {
            Rectangle top = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, 1);
            Rectangle bottom = new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width, 1);
            Rectangle left = new Rectangle(rectangle.X, rectangle.Y, 1, rectangle.Height);
            Rectangle right = new Rectangle(rectangle.X + rectangle.Width , rectangle.Y, 1, rectangle.Height);

            spriteBatch.Draw(pixelTexture, top, Color.White);
            spriteBatch.Draw(pixelTexture, bottom, Color.White);
            spriteBatch.Draw(pixelTexture, left, Color.White);
            spriteBatch.Draw(pixelTexture, right, Color.White);
        }
    }
}
