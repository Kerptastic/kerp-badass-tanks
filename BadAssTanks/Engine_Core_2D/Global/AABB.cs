using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KerpEngine.Global;
using Microsoft.Xna.Framework;
using KerpEngine.Engine_2D.Sprites;
using Microsoft.Xna.Framework.Graphics;

namespace KerpEngine.Global
{
    /// <summary>
    /// Represents an Axis Aligned Bounding Volume for a 2D object.
    /// </summary>
    public class AABB : BoundingVolume
    {
        /// <summary>
        /// The center of the AABB.
        /// </summary>
        private Vector3 _position;
        public Vector3 Position { get { return _position; } }
        /// <summary>
        /// The top right corner of the AABB.
        /// </summary>
        private Vector3 _topRight;
        public Vector3 TopRight { get { return _topRight; } }
        /// <summary>
        /// The bottom left corner of the AABB.
        /// </summary>
        private Vector3 _bottomLeft;
        public Vector3 BottomLeft { get { return _bottomLeft; } }

        /// <summary>
        /// The vertices representing the front face of the AABB when drawn.
        /// </summary>
        private VertexPositionColor[] _frontFace;
        /// <summary>
        /// The vertices representing the back face of the AABB when drawn.
        /// </summary>
        private VertexPositionColor[] _backFace;
        /// <summary>
        /// The vertices representing the left face of the AABB when drawn.
        /// </summary>
        private VertexPositionColor[] _leftFace;
        /// <summary>
        /// The vertices representing the right face of the AABB when drawn.
        /// </summary>
        private VertexPositionColor[] _rightFace;

        /// <summary>
        /// The index buffer used for drawing the AABB.
        /// </summary>
        private static short[] _indices = { 0, 1, 1, 2, 2, 3, 3, 4 };


        /// <summary>
        /// Creates an Axis Aligned Bounding Box used for collision detection.
        /// This constructor will force the creation of a 2D AABB.
        /// </summary>
        /// <param name="position">The center of the AABB.</param>
        /// <param name="width">The width of the AABB.</param>
        /// <param name="height">The height of the AABB.</param>
        public AABB(Vector3 position, float width, float height)
            : this(new Vector3(position.X + width / 2.0f, position.Y + height / 2.0f, 0.0f),
             new Vector3(position.X - width / 2.0f, position.Y - height / 2.0f, 0.0f))
        {
        }

        /// <summary>
        /// Creates an Axis Aligned Bounding Box used for collision detection.
        /// </summary>
        /// <param name="topRight">The top right corner of the AABB.</param>
        /// <param name="bottomLeft">The bottom left corner of the AABB.</param>
        public AABB(Vector3 topRight, Vector3 bottomLeft)
            : this(new Vector3((topRight.X + bottomLeft.X) / 2.0f, (topRight.Y + bottomLeft.Y) / 2.0f, (topRight.Z + bottomLeft.Z) / 2.0f), topRight, bottomLeft)
        {
        }

        /// <summary>
        /// Creates an Axis Aligned Bounding Box used for collision detection.
        /// </summary>
        /// <param name="position">The center of the AABB.</param>
        /// <param name="topRight">The top right corner of the AABB.</param>
        /// <param name="bottomLeft">The bottom left corner of the AABB.</param>
        public AABB(Vector3 position, Vector3 topRight, Vector3 bottomLeft)
        {
            _position = position;
            _topRight = topRight;
            _bottomLeft = bottomLeft;

            _frontFace = new VertexPositionColor[5];
            _backFace = new VertexPositionColor[5];
            _leftFace = new VertexPositionColor[5];
            _rightFace = new VertexPositionColor[5];

            this.UpdatePointsList();
        }

        /// <summary>
        /// Sets the position of the AABB.
        /// </summary>
        /// <param name="newPosition">The new center position of the AABB.</param>
        public void SetPosition(Vector3 newPosition)
        {
            //find the different between the old position and the new position
            Vector3 diff = newPosition - _position;
            
            _position = Position;
        
            //add the difference to the top right and bottom left vectors
            _topRight += diff;
            _bottomLeft += diff;

            //reset the points so it can be drawn in the right position
            this.UpdatePointsList();
        }

        ///// <summary>
        ///// Checks to see if the given Bounding Volume is contained within this Bounding Volume.
        ///// </summary>
        ///// <param name="other">The Bounding Volume to see if is contained within this Bounding Volume.</param>
        ///// <returns>Whether or not the given Bounding Volume is contained within this Bounding Volume.</returns>
        public bool Contains(BoundingVolume other)
        {
            if (other is AABB)
            {
                AABB test = (AABB)other;

                Vector3 testTopRight = test.TopRight;
                Vector3 testBottomLeft = test.BottomLeft;

                return
                    (_bottomLeft.X < testTopRight.X) && (_topRight.X > testBottomLeft.X) &&
                    (_bottomLeft.Y < testTopRight.Y) && (_topRight.Y > testBottomLeft.Y) &&
                    (_bottomLeft.Z < testTopRight.Z) && (_topRight.Z > testBottomLeft.Z);
            }
            return false;
        }
        

        /// <summary>
        /// Draws this Bounding Volume to the screen.
        /// </summary>
        /// <param name="graphicsDevice">The Graphics Device to use to draw the Volume.</param>
        /// <param name="effect">The effect to use when drawing.</param>
        public void Draw(GraphicsDevice graphicsDevice, BasicEffect effect)
        {
            effect.LightingEnabled = false;
            effect.TextureEnabled = false;
            effect.VertexColorEnabled = true;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
                    PrimitiveType.LineList, _frontFace, 0, 5, _indices, 0, 4);
                graphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
                    PrimitiveType.LineList, _rightFace, 0, 5, _indices, 0, 4);
                graphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
                    PrimitiveType.LineList, _backFace, 0, 5, _indices, 0, 4);
                graphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
                    PrimitiveType.LineList, _leftFace, 0, 5, _indices, 0, 4);
            }

            effect.LightingEnabled = true;
        }

        /// <summary>
        /// Updates the points for the four faces of the AABB to draw.
        /// </summary>
        private void UpdatePointsList()
        {
            Color c = Color.Red;

            //tr - front face
            _frontFace[0] =
                new VertexPositionColor(new Vector3(_topRight.X, _topRight.Y, _topRight.Z), c);
            //tl - front face
            _frontFace[1] =
                new VertexPositionColor(new Vector3(_bottomLeft.X, _topRight.Y, _topRight.Z), c);
            //bl - front face
            _frontFace[2] =
                new VertexPositionColor(new Vector3(_bottomLeft.X, _bottomLeft.Y, _topRight.Z), c);
            //br - front face
            _frontFace[3] =
                new VertexPositionColor(new Vector3(_topRight.X, _bottomLeft.Y, _topRight.Z), c);
            //tr - front face
            _frontFace[4] =
                new VertexPositionColor(new Vector3(_topRight.X, _topRight.Y, _topRight.Z), c);


            //tr 
            _backFace[0] =
                new VertexPositionColor(new Vector3(_topRight.X, _topRight.Y, _bottomLeft.Z), c);
            //tl 
            _backFace[1] =
                new VertexPositionColor(new Vector3(_bottomLeft.X, _topRight.Y, _bottomLeft.Z), c);
            //bl 
            _backFace[2] =
                new VertexPositionColor(new Vector3(_bottomLeft.X, _bottomLeft.Y, _bottomLeft.Z), c);
            //br 
            _backFace[3] =
                new VertexPositionColor(new Vector3(_topRight.X, _bottomLeft.Y, _bottomLeft.Z), c);
            //tr
            _backFace[4] =
                new VertexPositionColor(new Vector3(_topRight.X, _topRight.Y, _bottomLeft.Z), c);


            //tr - 1
            _leftFace[0] =
                new VertexPositionColor(new Vector3(_bottomLeft.X, _topRight.Y, _topRight.Z), c);
            //tl 
            _leftFace[1] =
                new VertexPositionColor(new Vector3(_bottomLeft.X, _topRight.Y, _bottomLeft.Z), c);
            //bl - 
            _leftFace[2] =
                new VertexPositionColor(new Vector3(_bottomLeft.X, _bottomLeft.Y, _bottomLeft.Z), c);
            //br - 2
            _leftFace[3] =
                new VertexPositionColor(new Vector3(_bottomLeft.X, _bottomLeft.Y, _topRight.Z), c);
            //tr - 1
            _leftFace[4] =
                new VertexPositionColor(new Vector3(_bottomLeft.X, _topRight.Y, _topRight.Z), c);


            //tr 
            _rightFace[0] =
                new VertexPositionColor(new Vector3(_topRight.X, _topRight.Y, _bottomLeft.Z), c);
            //tl - 0
            _rightFace[1] =
                new VertexPositionColor(new Vector3(_topRight.X, _topRight.Y, _topRight.Z), c);
            //bl - 3
            _rightFace[2] =
                new VertexPositionColor(new Vector3(_topRight.X, _bottomLeft.Y, _topRight.Z), c);
            //br 
            _rightFace[3] =
                new VertexPositionColor(new Vector3(_topRight.X, _bottomLeft.Y, _bottomLeft.Z), c);
            //tr - 4
            _rightFace[4] =
                new VertexPositionColor(new Vector3(_topRight.X, _topRight.Y, _bottomLeft.Z), c);
        }
    }
}
