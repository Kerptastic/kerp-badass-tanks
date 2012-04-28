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


        public override void Draw(SpriteBatch spriteBatch, Vector2 position, float rotation, float scale, 
            Color textureTint, SpriteEffects effects, float layerDepth)
        {
            this.Draw(spriteBatch, position, new Vector2(0, 0), rotation, scale, textureTint,
                effects, layerDepth);
        }


        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 rotationOrigin, 
            float rotation, float scale, Color textureTint, SpriteEffects effects, float layerDepth)
        {
            this.Draw(spriteBatch, position, rotation, scale, null, textureTint, rotationOrigin, 
                effects, layerDepth);
        }


        public override void Draw(SpriteBatch spriteBatch, Vector2 position, float rotation, float scale,
            Rectangle? sourceRectangle, Color textureTint, Vector2 rotationOrigin, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.Draw(_texture, position, sourceRectangle, textureTint, rotation, rotationOrigin,
                scale, effects, layerDepth);
        }
    }
}


        