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
    /// Represents an Axis Aligned Bounding Volume for a 2D/3D object.
    /// </summary>
    public class AABB : BoundingVolume
    {
        /// <summary>
        /// The top right corner of the OABB.
        /// </summary>
        private Vector3 _topRight;
        /// <summary>
        /// The translated top right corner of the OABB to be used for collisions.
        /// </summary>
        private Vector3 _collisionTopRight;
        public Vector3 CollisionTopRight { get { return _collisionTopRight; } }
        /// <summary>
        /// The bottom left corner of the OABB.
        /// </summary>
        private Vector3 _bottomLeft;
        /// <summary>
        /// The translated bottom left corner of the OABB to be used for collisions.
        /// </summary>
        private Vector3 _collisionBottomLeft;
        public Vector3 CollisionBottomLeft { get { return _collisionBottomLeft; } }
        /// <summary>
        /// Gets/sets the position of this Bounding Volume.
        /// </summary>
        public override Vector3 Position
        {
            get
            {
                return base.Position;
            }
            set
            {
                base.Position = value;
                this.UpdateCollisionPoints();
            }
        }
        /// <summary>
        /// Gets/sets the scale of this Bounding Volume.
        /// </summary>
        public override Vector3 ScaleValue
        {
            get
            {
                return base.ScaleValue;
            }
            set
            {
                base.ScaleValue = value;
                this.UpdateCollisionPoints();
            }
        }
        /// <summary>
        /// Returns the width of the OABB.
        /// </summary>
        private float _width;
        public float Width { get { return _width; } }
        /// <summary>
        /// Returns the height of the OABB.
        /// </summary>
        private float _height;
        public float Height { get { return _height; } }
        /// <summary>
        /// Returns the depth of the OABB.
        /// </summary>
        private float _depth;
        public float Depth { get { return _depth; } }
        /// <summary>
        /// The vertices representing the front face of the OABB when drawn.
        /// </summary>
        private VertexPositionColor[] _frontFace;
        /// <summary>
        /// The vertices representing the back face of the OABB when drawn.
        /// </summary>
        private VertexPositionColor[] _backFace;
        /// <summary>
        /// The vertices representing the left face of the OABB when drawn.
        /// </summary>
        private VertexPositionColor[] _leftFace;
        /// <summary>
        /// The vertices representing the right face of the OABB when drawn.
        /// </summary>
        private VertexPositionColor[] _rightFace;
        /// <summary>
        /// The index buffer used for drawing the OABB.
        /// </summary>
        private static short[] _indices = { 0, 1, 1, 2, 2, 3, 3, 4 };
        /**
         * DEBUG
         */
        private bool useCollisionPoints;

        /// <summary>
        /// Creates an Axis Aligned Bounding Box used for collision detection.
        /// This constructor will force the creation of a 2D AABB.
        /// </summary>
        /// <param name="position">The center of the AABB.</param>
        /// <param name="width">The width of the AABB.</param>
        /// <param name="height">The height of the AABB.</param>
        public AABB(Vector3 position, float width, float height)
            : this(position, new Vector3(width / 2.0f, height / 2.0f, 0.0f),
             new Vector3(-width / 2.0f, -height / 2.0f, 0.0f))
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
            : base(position, new Vector3())
        {
            _position = position;
            _topRight = topRight;
            _bottomLeft = bottomLeft;

            _scale = new Vector3(1.0f, 1.0f, 1.0f);
            _rotation = new Vector3(0.0f, 0.0f, 0.0f);

            _width = Math.Abs(topRight.X - bottomLeft.X);
            _height = Math.Abs(topRight.Y - bottomLeft.Y);
            _depth = Math.Abs(topRight.Z - bottomLeft.Z);

            _frontFace = new VertexPositionColor[5];
            _backFace = new VertexPositionColor[5];
            _leftFace = new VertexPositionColor[5];
            _rightFace = new VertexPositionColor[5];

            useCollisionPoints = true;

            this.UpdateCollisionPoints();
        }

        /// <summary>
        /// Checks to see if the given Bounding Volume is contained within this Bounding Volume.
        /// </summary>
        /// <param name="other">The Bounding Volume to see if is contained within this Bounding Volume.</param>
        /// <returns>Whether or not the given Bounding Volume is contained within this Bounding Volume.</returns>
        public override bool Contains(BoundingVolume other)
        {
            if (other is AABB)
            {
                AABB test = (AABB)other;

                Vector3 testCollTopRight = test.CollisionTopRight;
                Vector3 testCollBottomLeft = test.CollisionBottomLeft;

                return
                    (_collisionBottomLeft.X <= testCollTopRight.X) && (_collisionTopRight.X >= testCollBottomLeft.X) &&
                    (_collisionBottomLeft.Y <= testCollTopRight.Y) && (_collisionTopRight.Y >= testCollBottomLeft.Y) &&
                    (_collisionBottomLeft.Z <= testCollTopRight.Z) && (_collisionTopRight.Z >= testCollBottomLeft.Z);
            }
            return false;
        }
        

        /// <summary>
        /// Draws this Bounding Volume to the screen.
        /// </summary>
        /// <param name="graphicsDevice">The Graphics Device to use to draw the Volume.</param>
        /// <param name="effect">The effect to use when drawing.</param>
        public override void Draw(GraphicsDevice graphicsDevice, BasicEffect effect)
        {
            effect.LightingEnabled = false;
            effect.TextureEnabled = false;
            effect.VertexColorEnabled = true;

            if (!useCollisionPoints)
            {
                effect.World = Matrix.Identity *
                                     Matrix.CreateScale(_scale) *
                                     Matrix.CreateRotationX(_rotation.X) *
                                     Matrix.CreateRotationY(_rotation.Y) *
                                     Matrix.CreateRotationZ(_rotation.Z) *
                                     Matrix.CreateTranslation(_position);
            }
            else
            {
                effect.World = Matrix.Identity;
            }

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

            if (!useCollisionPoints)
            {
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
            else
            {
                //tr - front face
                _frontFace[0] =
                    new VertexPositionColor(new Vector3(_collisionTopRight.X, _collisionTopRight.Y, _collisionTopRight.Z), c);
                //tl - front face
                _frontFace[1] =
                    new VertexPositionColor(new Vector3(_collisionBottomLeft.X, _collisionTopRight.Y, _collisionTopRight.Z), c);
                //bl - front face
                _frontFace[2] =
                    new VertexPositionColor(new Vector3(_collisionBottomLeft.X, _collisionBottomLeft.Y, _collisionTopRight.Z), c);
                //br - front face
                _frontFace[3] =
                    new VertexPositionColor(new Vector3(_collisionTopRight.X, _collisionBottomLeft.Y, _collisionTopRight.Z), c);
                //tr - front face
                _frontFace[4] =
                    new VertexPositionColor(new Vector3(_collisionTopRight.X, _collisionTopRight.Y, _collisionTopRight.Z), c);


                //tr 
                _backFace[0] =
                    new VertexPositionColor(new Vector3(_collisionTopRight.X, _collisionTopRight.Y, _collisionBottomLeft.Z), c);
                //tl 
                _backFace[1] =
                    new VertexPositionColor(new Vector3(_collisionBottomLeft.X, _collisionTopRight.Y, _collisionBottomLeft.Z), c);
                //bl 
                _backFace[2] =
                    new VertexPositionColor(new Vector3(_collisionBottomLeft.X, _collisionBottomLeft.Y, _collisionBottomLeft.Z), c);
                //br 
                _backFace[3] =
                    new VertexPositionColor(new Vector3(_collisionTopRight.X, _collisionBottomLeft.Y, _collisionBottomLeft.Z), c);
                //tr
                _backFace[4] =
                    new VertexPositionColor(new Vector3(_collisionTopRight.X, _collisionTopRight.Y, _collisionBottomLeft.Z), c);


                //tr - 1
                _leftFace[0] =
                    new VertexPositionColor(new Vector3(_collisionBottomLeft.X, _collisionTopRight.Y, _collisionTopRight.Z), c);
                //tl 
                _leftFace[1] =
                    new VertexPositionColor(new Vector3(_collisionBottomLeft.X, _collisionTopRight.Y, _collisionBottomLeft.Z), c);
                //bl - 
                _leftFace[2] =
                    new VertexPositionColor(new Vector3(_collisionBottomLeft.X, _collisionBottomLeft.Y, _collisionBottomLeft.Z), c);
                //br - 2
                _leftFace[3] =
                    new VertexPositionColor(new Vector3(_collisionBottomLeft.X, _collisionBottomLeft.Y, _collisionTopRight.Z), c);
                //tr - 1
                _leftFace[4] =
                    new VertexPositionColor(new Vector3(_collisionBottomLeft.X, _collisionTopRight.Y, _collisionTopRight.Z), c);


                //tr 
                _rightFace[0] =
                    new VertexPositionColor(new Vector3(_collisionTopRight.X, _collisionTopRight.Y, _collisionBottomLeft.Z), c);
                //tl - 0
                _rightFace[1] =
                    new VertexPositionColor(new Vector3(_collisionTopRight.X, _collisionTopRight.Y, _collisionTopRight.Z), c);
                //bl - 3
                _rightFace[2] =
                    new VertexPositionColor(new Vector3(_collisionTopRight.X, _collisionBottomLeft.Y, _collisionTopRight.Z), c);
                //br 
                _rightFace[3] =
                    new VertexPositionColor(new Vector3(_collisionTopRight.X, _collisionBottomLeft.Y, _collisionBottomLeft.Z), c);
                //tr - 4
                _rightFace[4] =
                    new VertexPositionColor(new Vector3(_collisionTopRight.X, _collisionTopRight.Y, _collisionBottomLeft.Z), c);
            }
        }

        /// <summary>
        /// Updates the points used for collision detection. This is needed to keep
        /// in sync the bounding box values with the characteristics of the enclosed object.
        /// </summary>
        private void UpdateCollisionPoints()
        {
            _collisionBottomLeft = (_bottomLeft + _position);
            _collisionTopRight = (_topRight + _position);

            UpdatePointsList();
        }
    }
}
