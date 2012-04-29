using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace EngineCore2D.Sprites
{
    /// <summary>
    /// Represents an Unanimated Sprite that will be drawn to the screen.
    /// </summary>
    public class UnanimatedSprite : CustomSprite
    {
        /// <summary>
        /// Creates a new Unanimated Sprite.
        /// </summary>
        /// <param name="texture">The Texture that will be drawn for this Sprite.</param>
        public UnanimatedSprite(Texture2D texture)
            : base(texture)
        {
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
        public override void Draw(SpriteBatch spriteBatch, Vector2 position, float rotation, float scale, 
            Color textureTint, SpriteEffects effects, float layerDepth)
        {
            this.Draw(spriteBatch, position, new Vector2(0, 0), rotation, scale, textureTint,
                effects, layerDepth);
        }

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
        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 rotationOrigin, 
            float rotation, float scale, Color textureTint, SpriteEffects effects, float layerDepth)
        {
            this.Draw(spriteBatch, position, rotationOrigin, rotation, scale, null, textureTint, 
                effects, layerDepth);
        }

        /// <summary>
        /// Draws this Sprite to the Screen.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to perform the drawing.</param>
        /// <param name="position">The position to draw the Sprite on the screen.</param>
        /// <param name="rotationOrigin">The point to perform the rotation around.</param>
        /// <param name="rotation">The rotation of the Sprite to be drawn.</param>
        /// <param name="scale">The scale of the Sprite to be drawn.</param>
        /// <param name="sourceRectangle">The rectangular texels to draw of the Sprite.</param>
        /// <param name="textureTint">The tint to draw the Sprite.</param>
        /// <param name="effects">The SpriteEffects to draw with the Sprite.</param>
        /// <param name="layerDepth">The layer at which to draw the Sprite.</param>
        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 rotationOrigin, float rotation,
             float scale, Rectangle? sourceRectangle, Color textureTint, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.Draw(_texture, position, sourceRectangle, textureTint, rotation, rotationOrigin,
                scale, effects, layerDepth);
        }
    }
}


        