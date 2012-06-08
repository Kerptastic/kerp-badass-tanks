using KerpEngine.Engine_2D.Sprites;
using KerpEngine.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KerpEngine.Engine_2D
{
    /// <summary>
    /// Represents a drawable, 2D, Game Object.  This class is expected to be
    /// extended by a Game Object class in a custom Game.  
    /// 
    /// This class simply provides all the member variables, and interfaces 
    /// required to be drawn, moved, and manipulated at an abstract level.
    /// 
    /// This class will be expected to be extended by a Custom Game Engine.
    /// 
    /// No mention of custom Game Objects will be found here.
    /// </summary>
    public abstract class GameObject2D
    {
        /// <summary>
        /// The Sprite to be drawn on the screen.
        /// </summary>
        protected CustomSprite _sprite;
         /// <summary>
        /// The tint color to use when drawing the Sprite. By default, will
        /// be Color.White, which will use no tint.
        /// </summary>
        protected Color _textureTint = Color.White;
        public Color TextureTint { get { return _textureTint; } set { _textureTint = value; } }
        /// <summary>
        /// The current position of this object.
        /// </summary>
        protected Vector2 _position;
        public float X { get { return _position.X; } set { _position.X = value; } } //_boundingVolume.Volume = new Rectangle((int)value, _boundingVolume.Volume.Y, _boundingVolume.Volume.Width, _boundingVolume.Volume.Height); } }
        public float Y { get { return _position.Y; } set { _position.Y = value; } } // _boundingVolume.Volume = new Rectangle(_boundingVolume.Volume.X, (int)value, _boundingVolume.Volume.Width, _boundingVolume.Volume.Height); } }
        public Vector2 Position { get { return _position; } set { _position = value; } }
        /// <summary>
        /// The current rotation angle of this object.
        /// </summary>
        protected float _rotation;
        public float Rotation { get { return _rotation; } set { this._rotation = Utilities.ClampAngleDegrees(value); } }
        /// <summary>
        /// The current scale factor of this object.
        /// </summary>
        protected float _scale;
        public float ScaleValue { get { return _scale; } set { _scale = value; } }
        /// <summary>
        /// The speed at which this object moves in a particular direction.
        /// </summary>
        protected float _moveSpeed = 1.0f;
        public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
        /// <summary>
        /// The bounding shape around this object.
        /// </summary>
        protected BoundingVolume _boundingVolume;
        public BoundingVolume BoundingVolume { get { return _boundingVolume; } set { _boundingVolume = value; } }


        /// <summary>
        /// Default constructor which just represents an object in the game
        /// that isnt drawn to the screen, but still has a location within 
        /// the game (i.e., a camera, a light, etc)
        /// </summary>
        /// <param name="xLocation">The initial X location of the object on the screen.</param>
        /// <param name="yLocation">The initial Y location of the object on the screen.</param>
        public GameObject2D(float xLocation, float yLocation)
            : this(null, xLocation, yLocation, Color.White)
        {
        }

        /// <summary>
        /// Creates a new Game Object, without needing to know the type of
        /// Sprite (Animated, Text, Unanimated, etc) that will be drawn.
        /// </summary>
        /// <param name="sprite">The Sprite that will be drawn.</param>
        /// <param name="xLocation">The initial X location of the sprite on the screen.</param>
        /// <param name="yLocation">The initial Y location of the sprite on the screen.</param>
        /// <param name="textureTint">The color to tint the Sprite when being drawn.</param>
        public GameObject2D(CustomSprite sprite, float xLocation, float yLocation, Color textureTint)
        {
            this._position = new Vector2(xLocation, yLocation);
            this._sprite = sprite;
            this._textureTint = textureTint;

            this._rotation = 0.0f;
            this._scale = 1.0f;

            if (_sprite != null)
            {
                //_boundingVolume = new AABB(new Vector3(xLocation, yLocation, 0.0f), 
                    //new Vector3(xLocation + _sprite.Width, yLocation + _sprite.Height, 0.0f));

                //create a bounding volume giving the location of the center, width and height
                _boundingVolume = new AABB(new Vector3(xLocation, yLocation, 0.0f), _sprite.Width, _sprite.Height);
            }
        }

        /// <summary>
        /// Draws the Game Object's sprite to the screen using a SpriteBatch method.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch used to draw the Sprite.</param>
        public virtual void Draw(SpriteBatch spriteBatch)  
        {
            if (_sprite != null)
            {
                _sprite.Draw(spriteBatch, _position, _rotation, _scale, _textureTint, SpriteEffects.None, 0.0f);
            }
        }

        /// <summary>
        /// Draws the Game Object's sprite to the screen using a GraphicsDevice.
        /// </summary>
        /// <param name="device">The GraphicsDevice used to draw the Object.</param>
        /// <param name="effect">The effect to use to draw the object.</param>
        public virtual void Draw(GraphicsDevice device, BasicEffect effect)
        {
            if (_sprite != null)
            {
                effect.World = Matrix.CreateRotationZ(_rotation) * 
                               Matrix.CreateScale(_scale) * 
                               Matrix.CreateTranslation(_position.X, _position.Y, 0.0f);

                _sprite.Draw(device, effect);
            }
        }

        /// <summary>
        /// Moves an object in the given direction by the default move speed
        /// for this object.
        /// </summary>
        /// <param name="direction">The direction to move the object.</param>
        public virtual void Move(Vector2 direction)
        {
            this.Move(direction, _moveSpeed);
        }

        /// <summary>
        /// Moves an object in the given direction, while overriding the default
        /// move speed for the object, and replacing it with the given moveSpeed.
        /// </summary>
        /// <param name="direction">The direction to move the object.</param>
        /// <param name="moveSpeed">The magnitude to move the object in the given direction.</param>
        public virtual void Move(Vector2 direction, float moveSpeed)
        {
            this._position += (direction * moveSpeed);
        }

        /// <summary>
        /// Increases (positive) or decreases (negative) the current rotation value
        /// by the provided amount.
        /// </summary>
        /// <param name="amount">The amount to increase (positive) or decrease (negative) the rotation value by.</param>
        public virtual void Rotate(float amountInDegrees)
        {
            this._rotation += amountInDegrees;
        }

        /// <summary>
        /// Increases (positive) or decreases (negative) the current scale value
        /// by the provided amount.
        /// </summary>
        /// <param name="amount">The amount to increase (positive) or decrease (negative) the scale factor by.</param>
        public virtual void Scale(float amount)
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
