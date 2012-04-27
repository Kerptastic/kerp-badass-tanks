using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using EngineCore2D.Sprites;

namespace EngineCore2D.Engine
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
    public class GameObject2D
    {
        /// <summary>
        /// The Sprite to be drawn on the screen.
        /// </summary>
        protected CustomSprite _sprite;
        /// <summary>
        /// The drawing rectangle for the sprite. Contains X/Y location, 
        /// and Width/Height values for drawing.
        /// </summary>
        private Rectangle _drawingRectangle;
        public int Width { get { return _drawingRectangle.Width; } set { _drawingRectangle.Width = value; } }
        public int Height { get { return _drawingRectangle.Height; } set { _drawingRectangle.Height = value; } }
        /// <summary>
        /// 
        /// </summary>
        protected Vector2 _position;
        public float X { get { return _position.X; } set { _position.X = value; _drawingRectangle.X = (int)_position.X; } }
        public float Y { get { return _position.Y; } set { _position.Y = value; _drawingRectangle.X = (int)_position.X; } }
        public Vector2 Position { get { return _position; } set { _position = value; } }
        /// <summary>
        /// The tint color to use when drawing the Sprite. By default, will
        /// be Color.White, which will use no tint.
        /// </summary>
        protected Color _textureTint = Color.White;
        public Color TextureTint { get { return _textureTint; } set { _textureTint = value; } }
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
        public GameObject2D(float xLocation, float yLocation)
        {
        }

        /// <summary>
        /// Creates a new Game Object, without needing to know the type of
        /// Sprite (Animated, Text, Unanimated, etc) that will be drawn.
        /// </summary>
        /// <param name="sprite">The Sprite that will be drawn.</param>
        /// <param name="xLocation">The initial X location of the sprite on the screen.</param>
        /// <param name="yLocation">The initial Y location of the sprite on the screen.</param>
        /// <param name="width">The width of the Sprite to be drawn.</param>
        /// <param name="height">The height of the Sprite to be drawn.</param>
        /// <param name="textureTint"></param>
        public GameObject2D(CustomSprite sprite, float xLocation, float yLocation, int width, int height, Color textureTint)
        {
            this._sprite = sprite;

            this._drawingRectangle = new Rectangle((int)xLocation, (int)yLocation, width, height);
            this._textureTint = textureTint;
        }

        /// <summary>
        /// Draws the Game Object's sprite to the screen.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch used to draw the Sprite.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (_sprite != null)
            {
                _sprite.Draw(spriteBatch, _drawingRectangle, _textureTint);
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


        //public abstract void Destroy();
        //public abstract bool IsDestroyed();
        //public abstract bool ReadyToFire();
        //public abstract void Move(String direction, Camera camera);
        //public abstract void Move(float angle);
        //public abstract void Move(WorldObject obj);
        //public abstract void Rotate(String direction);
        //public abstract void RotateGundam(float angle);
        //public abstract void Render();
        //public abstract ArrayList FireWeapon(String weaponName);
        //public abstract float GetFacingAngle();
        //public abstract BoundingShape2D GetBoundingShape();
        //public abstract GameEngine.IntCoords GetWorldCoords();
        //public abstract GameEngine.FloatCoords GetTileCoords();
        //public abstract void Tint(Color color);
        //public abstract bool ReduceHealth(float value);
        //public abstract int GetCrashDamage();
        //public abstract long GetPointValue();
    }
}
