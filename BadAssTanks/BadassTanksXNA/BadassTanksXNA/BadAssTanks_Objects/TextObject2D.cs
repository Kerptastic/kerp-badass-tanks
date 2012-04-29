using EngineCore2D.Engine;
using EngineCore2D.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BadassTanksXNA.BadAssTanks_Objects
{
    /// <summary>
    /// Represents text that will be drawn to the screen.
    /// </summary>
    public class TextObject2D : GameObject2D
    {
        /// <summary>
        /// Creates a new Text Object.
        /// </summary>
        /// <param name="sprite">The sprite to be drawn to the screen.</param>
        /// <param name="xLocation">The x location to draw the object.</param>
        /// <param name="yLocation">The y location to draw the object.</param>
        /// <param name="textureTint">The tint color to use when drawing the object.</param>
        public TextObject2D(TextSprite sprite, int xLocation, int yLocation, Color textureTint)
            : base(sprite, xLocation, yLocation, 0.0f, 0.0f, textureTint)
        {
        }

        /// <summary>
        /// Draws the Game Object's sprite to the screen.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch used to draw the Sprite.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_sprite != null)
            {
                _sprite.Draw(spriteBatch, _position, _rotation, _scale, _textureTint, SpriteEffects.None, 0.0f);
            }
        }
    }
}
