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
    public abstract class GameObject2D : GameObject
    {
        /// <summary>
        /// The Sprite to be drawn on the screen.
        /// </summary>
        protected CustomSprite _sprite;

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
            _position = new Vector3(xLocation, yLocation, 0.0f);
            _sprite = sprite;
            _textureTint = textureTint;

            _scale = new Vector3(1.0f, 1.0f, 1.0f);
            _rotation = new Vector3(0.0f, 0.0f, 0.0f);

            if (_sprite != null)
            {
                //create a bounding volume giving the location of the center, width and height
                _boundingVolume = new AABB(_position, _sprite.Width, _sprite.Height);
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
                _sprite.Draw(spriteBatch, _position, _rotation.Z, _scale.X, _textureTint, SpriteEffects.None, 0.0f);
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
                effect.World = Matrix.CreateRotationZ(_rotation.Z) * 
                               Matrix.CreateScale(_scale) * 
                               Matrix.CreateTranslation(_position.X, _position.Y, 0.0f);

                _sprite.Draw(device, effect);
                _boundingVolume.Draw(device, effect);
            }
        }
    }
}
