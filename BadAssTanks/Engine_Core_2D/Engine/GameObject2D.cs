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
        /// and Width/Height values.
        /// </summary>
        private Rectangle _drawingRectangle;
        public int X { get { return _drawingRectangle.X; } set { _drawingRectangle.X = value; } }
        public int Y { get { return _drawingRectangle.Y; } set { _drawingRectangle.Y = value; } }
        public int Width { get { return _drawingRectangle.Width; } set { _drawingRectangle.Width = value; } }
        public int Height { get { return _drawingRectangle.Height; } set { _drawingRectangle.Height = value; } }
        /// <summary>
        /// The tint color to use when drawing the Sprite. By default, will
        /// be Color.White, which will use no tint.
        /// </summary>
        protected Color _textureTint = Color.White;
        public Color TextureTint { get; set; }

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
        public GameObject2D(CustomSprite sprite, int xLocation, int yLocation, int width, int height, Color textureTint)
        {
            this._sprite = sprite;

            this._drawingRectangle = new Rectangle(xLocation, yLocation, width, height);
            this._textureTint = textureTint;
        }

        /// <summary>
        /// Draws the Game Object's sprite to the screen.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch used to draw the Sprite.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch, _drawingRectangle, _textureTint);
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
