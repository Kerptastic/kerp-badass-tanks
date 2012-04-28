using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
        public CustomSprite(Texture2D texture)
        {
            this._texture = texture;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        /// <param name="textureTint"></param>
        /// <param name="effects"></param>
        /// <param name="layerDepth"></param>
        public abstract void Draw(SpriteBatch spriteBatch, Vector2 position, float rotation, float scale,
            Color textureTint, SpriteEffects effects, float layerDepth);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="position"></param>
        /// <param name="rotationOrigin"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        /// <param name="textureTint"></param>
        /// <param name="effects"></param>
        /// <param name="layerDepth"></param>
        public abstract void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 rotationOrigin, float rotation,
            float scale, Color textureTint, SpriteEffects effects, float layerDepth);

        /// <summary>
        /// Draws the Sprite to the screen.  Will be implemented differently for the concrete
        /// Sprite classes.
        /// <summary>
        /// <param name="spriteBatch">The SpriteBatch used to draw the Sprite to the screen.</param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        /// <param name="sourceRectangle"></param>
        /// <param name="textureTint">The Tint color to use when drawing the Sprite.</param>
        /// <param name="rotationOrigin"></param>
        /// <param name="effects"></param>
        /// <param name="layerDepth"></param>
        public abstract void Draw(SpriteBatch spriteBatch, Vector2 position, float rotation, float scale,
            Rectangle? sourceRectangle, Color textureTint, Vector2 rotationOrigin, SpriteEffects effects, float layerDepth);
    }
}
