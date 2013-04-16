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
    /// Represents an Orientation Aligned Bounding Volume for a 2D/3D object.
    /// </summary>
    public class OABB : BoundingVolume
    {
        /// <summary>
        /// The front top right corner of the OABB.
        /// </summary>
        private Vector3 _frontTopRight;
        /// <summary>
        /// The translated front top right corner of the OABB to be used for collisions.
        /// </summary>
        private Vector3 _collisionFrontTopRight;
        public Vector3 CollisionFrontTopRight { get { return _collisionFrontTopRight; } }
        /// <summary>
        /// The front top right corner of the OABB.
        /// </summary>
        private Vector3 _frontTopLeft;
        /// <summary>
        /// The translated front top right corner of the OABB to be used for collisions.
        /// </summary>
        private Vector3 _collisionFrontTopLeft;
        public Vector3 CollisionFrontTopLeft { get { return _collisionFrontTopLeft; } }
        /// <summary>
        /// The front bottom right corner of the OABB.
        /// </summary>
        private Vector3 _frontBottomRight;
        /// <summary>
        /// The translated front top right corner of the OABB to be used for collisions.
        /// </summary>
        private Vector3 _collisionFrontBottomRight;
        public Vector3 CollisionFrontBottomRight { get { return _collisionFrontBottomRight; } }
        /// <summary>
        /// The bottom left corner of the OABB.
        /// </summary>
        private Vector3 _frontBottomLeft;
        /// <summary>
        /// The translated bottom left corner of the OABB to be used for collisions.
        /// </summary>
        private Vector3 _collisionFrontBottomLeft;
        public Vector3 CollisionFrontBottomLeft { get { return _collisionFrontBottomLeft; } }

        /// <summary>
        /// The back top right corner of the OABB.
        /// </summary>
        private Vector3 _backTopRight;
        /// <summary>
        /// The translated front top right corner of the OABB to be used for collisions.
        /// </summary>
        private Vector3 _collisionBackTopRight;
        public Vector3 CollisionBackTopRight { get { return _collisionBackTopRight; } }
        /// <summary>
        /// The back top right corner of the OABB.
        /// </summary>
        private Vector3 _backTopLeft;
        /// <summary>
        /// The translated front top right corner of the OABB to be used for collisions.
        /// </summary>
        private Vector3 _collisionBackTopLeft;
        public Vector3 CollisionBackTopLeft { get { return _collisionBackTopLeft; } }
        /// <summary>
        /// The back bottom right corner of the OABB.
        /// </summary>
        private Vector3 _backBottomRight;
        /// <summary>
        /// The translated front top right corner of the OABB to be used for collisions.
        /// </summary>
        private Vector3 _collisionBackBottomRight;
        public Vector3 CollisionBackBottomRight { get { return _collisionBackBottomRight; } }
        /// <summary>
        /// The back bottom left corner of the OABB.
        /// </summary>
        private Vector3 _backBottomLeft;
        /// <summary>
        /// The translated bottom left corner of the OABB to be used for collisions.
        /// </summary>
        private Vector3 _collisionBackBottomLeft;
        public Vector3 CollisionBackBottomLeft { get { return _collisionBackBottomLeft; } }

       
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
        /// Gets/sets the Rotation of this Bounding Volume.
        /// </summary>
        public override Vector3 Rotation
        {
            get
            {
                return base.Rotation;
            }
            set
            {
                base.Rotation = value;
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

        /// <summary>
        /// Creates an Orientation Aligned Bounding Box used for collision detection.
        /// </summary>
        /// <param name="topRight">The top right corner of the OABB.</param>
        /// <param name="bottomLeft">The bottom left corner of the OABB.</param>
        public OABB(Vector3 topRight, Vector3 bottomLeft)
            : this(new Vector3((topRight.X + bottomLeft.X) / 2.0f, (topRight.Y + bottomLeft.Y) / 2.0f, (topRight.Z + bottomLeft.Z) / 2.0f), topRight, bottomLeft)
        {
        }

        /// <summary>
        /// Creates an Orientation Aligned Bounding Box used for collision detection.
        /// </summary>
        /// <param name="position">The center of the OABB.</param>
        /// <param name="frontTopRight">The top right corner of the OABB.</param>
        /// <param name="backBottomLeft">The bottom left corner of the OABB.</param>
        public OABB(Vector3 position, Vector3 frontTopRight, Vector3 backBottomLeft)
            : base(position, new Vector3())
        {
            _position = position;
            _frontTopRight = frontTopRight;
            _frontTopLeft = new Vector3(backBottomLeft.X, frontTopRight.Y, frontTopRight.Z);
            _frontBottomRight = new Vector3(frontTopRight.X, backBottomLeft.Y, frontTopRight.Z);
            _frontBottomLeft = new Vector3(backBottomLeft.X, backBottomLeft.Y, frontTopRight.Z);

            _backTopRight = new Vector3(frontTopRight.X, frontTopRight.Y, backBottomLeft.Z);
            _backTopLeft = new Vector3(_frontTopLeft.X, _frontTopLeft.Y, backBottomLeft.Z);
            _backBottomRight = new Vector3(_frontBottomRight.X, _frontBottomRight.Y, backBottomLeft.Z);
            _backBottomLeft = backBottomLeft;

            _scale = new Vector3(1.0f, 1.0f, 1.0f);
            _rotation = new Vector3(0.0f, 0.0f, 0.0f);

            _width = Math.Abs(frontTopRight.X - backBottomLeft.X);
            _height = Math.Abs(frontTopRight.Y - backBottomLeft.Y);
            _depth = Math.Abs(frontTopRight.Z - backBottomLeft.Z);

            _frontFace = new VertexPositionColor[5];
            _backFace = new VertexPositionColor[5];
            _leftFace = new VertexPositionColor[5];
            _rightFace = new VertexPositionColor[5];

            this.UpdateCollisionPoints();
        }

        /// <summary>
        /// Checks to see if the given Bounding Volume is contained within this Bounding Volume.
        /// </summary>
        /// <param name="other">The Bounding Volume to see if is contained within this Bounding Volume.</param>
        /// <returns>Whether or not the given Bounding Volume is contained within this Bounding Volume.</returns>
        public override bool Contains(BoundingVolume other)
        {
            if (other is OABB)
            {
                OABB test = (OABB)other;

                Vector3 testCollTopRight = test.CollisionFrontTopRight;
                Vector3 testCollBottomLeft = test.CollisionBackBottomLeft;

                return
                    (_collisionBackBottomLeft.X <= testCollTopRight.X) && (_collisionFrontTopRight.X >= testCollBottomLeft.X) &&
                    (_collisionBackBottomLeft.Y <= testCollTopRight.Y) && (_collisionFrontTopRight.Y >= testCollBottomLeft.Y) &&
                    (_collisionBackBottomLeft.Z <= testCollTopRight.Z) && (_collisionFrontTopRight.Z >= testCollBottomLeft.Z);
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

            effect.World = Matrix.Identity;
                                   
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
        /// Updates the points for the four faces of the OABB to draw.
        /// </summary>
        private void UpdatePointsList()
        {
            Color c = Color.Red;
            Color b = Color.Yellow;
            Color w = Color.White;
            Color t = Color.Teal;
            
            //tr - front face
            _frontFace[0] =
                new VertexPositionColor(new Vector3(_collisionFrontTopRight.X, _collisionFrontTopRight.Y, _collisionFrontTopRight.Z), w);
            //tl - front face
            _frontFace[1] =
                new VertexPositionColor(new Vector3(_collisionFrontTopLeft.X, _collisionFrontTopLeft.Y, _collisionFrontTopLeft.Z), w);
            //bl - front face
            _frontFace[2] =
                new VertexPositionColor(new Vector3(_collisionFrontBottomLeft.X, _collisionFrontBottomLeft.Y, _collisionFrontBottomLeft.Z), w);
            //br - front face
            _frontFace[3] =
                new VertexPositionColor(new Vector3(_collisionFrontBottomRight.X, _collisionFrontBottomRight.Y, _collisionFrontBottomRight.Z), w);
            //tr - front face
            _frontFace[4] =
                new VertexPositionColor(new Vector3(_collisionFrontTopRight.X, _collisionFrontTopRight.Y, _collisionFrontTopRight.Z), w);

            //tr 
            _backFace[0] =
                new VertexPositionColor(new Vector3(_collisionBackTopRight.X, _collisionBackTopRight.Y, _collisionBackTopRight.Z), c);
            //tl 
            _backFace[1] =
                new VertexPositionColor(new Vector3(_collisionBackTopLeft.X, _collisionBackTopLeft.Y, _collisionBackTopLeft.Z), c);
            //bl 
            _backFace[2] =
                new VertexPositionColor(new Vector3(_collisionBackBottomLeft.X, _collisionBackBottomLeft.Y, _collisionBackBottomLeft.Z), c);
            //br 
            _backFace[3] =
                new VertexPositionColor(new Vector3(_collisionBackBottomRight.X, _collisionBackBottomRight.Y, _collisionBackBottomRight.Z), c);
            //tr
            _backFace[4] =
                new VertexPositionColor(new Vector3(_collisionBackTopRight.X, _collisionBackTopRight.Y, _collisionBackTopRight.Z), c);

            //tr - front face top left
            _leftFace[0] = _frontFace[1];
            //tl - back face top left
            _leftFace[1] = _backFace[1];                
            //bl - back face bottom left
            _leftFace[2] = _backFace[2];             
            //br - front face bottom left
            _leftFace[3] = _frontFace[2];
            //tr - front face top left
            _leftFace[4] = _frontFace[1];
                    
            //tr - back face top right
            _rightFace[0] = _backFace[0];
            //tl - front face top right
            _rightFace[1] = _frontFace[0];
            //bl - front face bottom right
            _rightFace[2] = _frontFace[3];
            //br - back face bottom right
            _rightFace[3] = _backFace[3];
            //tr - back face top right
            _rightFace[4] = _backFace[0];
        }

        /// <summary>
        /// Updates the points used for collision detection. This is needed to keep
        /// in sync the bounding box values with the characteristics of the enclosed object.
        /// </summary>
        private void UpdateCollisionPoints()
        {
            Matrix worldMatrix =
                                 Matrix.CreateRotationX(_rotation.X) *
                                 Matrix.CreateRotationY(_rotation.Y) *
                                 Matrix.CreateRotationZ(_rotation.Z) *
                                 Matrix.CreateTranslation(_position);

            _collisionBackTopRight = Vector3.Transform(_backTopRight, worldMatrix);
            _collisionBackTopLeft = Vector3.Transform(_backTopLeft, worldMatrix);
            _collisionBackBottomRight = Vector3.Transform(_backBottomRight, worldMatrix);
            _collisionBackBottomLeft = Vector3.Transform(_backBottomLeft, worldMatrix);
            
            _collisionFrontTopRight = Vector3.Transform(_frontTopRight, worldMatrix);
            _collisionFrontTopLeft = Vector3.Transform(_frontTopLeft, worldMatrix);
            _collisionFrontBottomRight = Vector3.Transform(_frontBottomRight, worldMatrix);
            _collisionFrontBottomLeft = Vector3.Transform(_frontBottomLeft, worldMatrix);

            UpdatePointsList();
        }
    }
}
