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
        /// Draws this Sprite to the Screen.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to perform the drawing.</param>
        /// <param name="position">The position to draw the Sprite on the screen.</param>
        /// <param name="rotation">The rotation of the Sprite to be drawn.</param>
        /// <param name="scale">The scale of the Sprite to be drawn.</param>
        /// <param name="textureTint">The tint to draw the Sprite.</param>
        /// <param name="effects">The SpriteEffects to draw with the Sprite.</param>
        /// <param name="layerDepth">The layer at which to draw the Sprite.</param>
        public abstract void Draw(SpriteBatch spriteBatch, Vector2 position, float rotation, float scale,
            Color textureTint, SpriteEffects effects, float layerDepth);

        /// <summary>
        /// Draws this Sprite to the Screen.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to perform the drawing.</param>
        /// <param name="position">The position to draw the Sprite on the screen.</param>
        /// <param name="rotationOrigin">The point to perform the rotation around.</param>
        /// <param name="rotation">The rotation of the Sprite to be drawn.</param>
        /// <param name="scale">The scale of the Sprite to be drawn.</param>
        /// <param name="textureTint">The tint to draw the Sprite.</param>
        /// <param name="effects">The SpriteEffects to draw with the Sprite.</param>
        /// <param name="layerDepth">The layer at which to draw the Sprite.</param>
        public abstract void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 rotationOrigin, float rotation,
            float scale, Color textureTint, SpriteEffects effects, float layerDepth);

        /// <summary>
        /// Draws this Sprite to the Screen.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to perform the drawing.</param>
        /// <param name="position">The position to draw the Sprite on the screen.</param>
        /// <param name="rotationOrigin">The point to perform the rotation around.</param>
        /// <param name="rotation">The rotation of the Sprite to be drawn.</param>
        /// <param name="scale">The scale of the Sprite to be drawn.</param>
        /// <param name="sourceRectangle">The texels to draw for this Sprite.</param>
        /// <param name="textureTint">The tint to draw the Sprite.</param>
        /// <param name="effects">The SpriteEffects to draw with the Sprite.</param>
        /// <param name="layerDepth">The layer at which to draw the Sprite.</param>
        public abstract void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 rotationOrigin, float rotation, 
            float scale, Rectangle? sourceRectangle, Color textureTint,  SpriteEffects effects, float layerDepth);
    }
}
