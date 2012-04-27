
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace EngineCore2D.Sprites
{
    /// <summary>
    /// Base class defining the behavior required for all Sprites in the
    /// Game Engine. It is implied that a Sprite will be a 2D image on a screen.
    /// </summary>
    public abstract class CustomSprite
    {
        /// <summary>
        /// The Texture that will be drawn for this Sprite.
        /// </summary>
        protected Texture2D _texture;
        public Texture2D Texture { get { return _texture; } set { _texture = value; } }

        /// <summary>
        /// Creates a new Sprite with the given Texture.
        /// </summary>
        /// <param name="texture">The Texture that will be drawn for this Sprite.</param>
        protected CustomSprite(Texture2D texture)
        {
            this._texture = texture;
        }

        /// <summary>
        /// Draws the Sprite to the screen.  Will be implemented differently for the concrete
        /// Sprite classes.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch used to draw the Sprite to the screen.</param>
        /// <param name="drawingRectangle">The Drawing Rectangle where the Sprite will be drawn on the screen.</param>
        /// <param name="textureTint">The Tint color to use when drawing the Sprite.</param>
        public abstract void Draw(SpriteBatch spriteBatch, Rectangle drawingRectangle, Color textureTint);
    }
}
