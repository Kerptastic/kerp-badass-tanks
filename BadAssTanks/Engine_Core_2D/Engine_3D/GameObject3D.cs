using KerpEngine.Engine_3D.Models;
using KerpEngine.Global;
using Microsoft.Xna.Framework;

namespace KerpEngine.Engine_3D
{
    /// <summary>
    /// Represents a drawable, 3D, Game Object.  This class is expected to be
    /// extended by a Game Object class in a custom Game.  
    /// 
    /// This class simply provides all the member variables, and interfaces 
    /// required to be drawn, moved, and manipulated at an abstract level.
    /// 
    /// This class will be expected to be extended by a Custom Game Engine.
    /// 
    /// No mention of custom Game Objects will be found here.
    /// </summary>
    public abstract class GameObject3D
    {
        /// <summary>
        /// The model to be drawn to the screen.
        /// </summary>
        protected CustomModel _model;
        public CustomModel Model { get { return _model; } }
         /// <summary>
        /// The tint color to use when drawing the Model. By default, will
        /// be Color.White, which will use no tint.
        /// </summary>
        protected Color _textureTint = Color.White;
        public Color TextureTint { get { return _textureTint; } set { _textureTint = value; } }
        /// <summary>
        /// The current position of this object.
        /// </summary>
        protected Vector3 _position;
        public float X { get { return _position.X; } set { _position.X = value; } }//_boundingRectangle.X = (int)value; } }
        public float Y { get { return _position.Y; } set { _position.Y = value; } }//_boundingRectangle.Y = (int)value; } }
        public float Z { get { return _position.Z; } set { _position.Z = value; } }//_boundingRectangle.Z = (int)value; } }
        public Vector3 Position { get { return _position; } set { _position = value; } }
        /// <summary>
        /// The current rotation angle of this object.
        /// </summary>
        protected Vector3 _rotation;
        public Vector3 Rotation { get { return _rotation; } set { this._rotation = Utilities.ClampAngleDegrees(value); } }
        /// <summary>
        /// The current scale factor of this object.
        /// </summary>
        protected Vector3 _scale;
        public Vector3 ScaleValue { get { return _scale; } set { _scale = value; } }
        /// <summary>
        /// The speed at which this object moves in a particular direction.
        /// </summary>
        protected float _moveSpeed = 1.0f;
        public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
       
        /// <summary>
        /// Default constructor which just represents an object in the game
        /// that isnt drawn to the screen, but still has a location within 
        /// the game (i.e., a camera, a light, etc)
        /// </summary>
        /// <param name="position">The initial location of the object on the screen.</param>
        public GameObject3D(CustomModel model, Vector3 position, Color textureTint)
        {
            _model = model;
            _position = position;
            _textureTint = TextureTint;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewMatrix"></param>
        /// <param name="projectionMatrix"></param>
        public virtual void Draw(Matrix viewMatrix, Matrix projectionMatrix) 
        {
            Matrix worldMatrix = Matrix.CreateScale(_scale) * 
                                 Matrix.CreateRotationX(_rotation.X) *
                                 Matrix.CreateRotationY(_rotation.Y) *
                                 Matrix.CreateRotationZ(_rotation.Z) * 
                                 Matrix.CreateTranslation(_position);

            _model.Draw(worldMatrix, viewMatrix, projectionMatrix);
        }

        /// <summary>
        /// Moves an object in the given direction by the default move speed
        /// for this object.
        /// </summary>
        /// <param name="direction">The direction to move the object.</param>
        public virtual void Move(Vector3 direction)
        {
            this.Move(direction, _moveSpeed);
        }

        /// <summary>
        /// Moves an object in the given direction, while overriding the default
        /// move speed for the object, and replacing it with the given moveSpeed.
        /// </summary>
        /// <param name="direction">The direction to move the object.</param>
        /// <param name="moveSpeed">The magnitude to move the object in the given direction.</param>
        public virtual void Move(Vector3 direction, float moveSpeed)
        {
            this._position += (direction * moveSpeed);
        }

        /// <summary>
        /// Increases (positive) or decreases (negative) the current rotation value
        /// by the provided amount.
        /// </summary>
        /// <param name="amount">The amount to increase (positive) or decrease (negative) the rotation value by.</param>
        public virtual void Rotate(Vector3 amountInDegrees)
        {
            this._rotation += amountInDegrees;
        }

        /// <summary>
        /// Increases (positive) or decreases (negative) the current scale value
        /// by the provided amount.
        /// </summary>
        /// <param name="amount">The amount to increase (positive) or decrease (negative) the scale factor by.</param>
        public virtual void Scale(Vector3 amount)
        {
            this._scale += amount;
        }

        /// <summary>
        /// Sets the tint color of this object to the new tint color.
        /// </summary>
        /// <param name="newTintColor">The new color to tint this object with when drawing.</param>
        public virtual void Tint(Color newTintColor)
        {
            this._textureTint = newTintColor;
        }
    }
}
