using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KerpEngine.Engine_2D.Sprites
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
        /// <param name="width">The width of the sprite before any scaling.</param>
        /// <param name="height">The height of the sprite before any scaling.</param>
        public UnanimatedSprite(Texture2D texture, float width, float height)
            : base(texture, width, height)
        {
        }

        /// <summary>
        /// Draws the Sprite to the screen using a 3D method of display, thus
        /// not using a SpriteBatch.
        /// </summary>
        /// <param name="device">The GraphicsDevice to perform the drawing.</param>
        /// <param name="effect">The effect to use while drawing.</param>
        public override void Draw(GraphicsDevice device, BasicEffect effect)
        {
            effect.Texture = _texture;
            
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                device.DrawUserIndexedPrimitives<VertexPositionNormalTexture>(
                    PrimitiveType.TriangleList, _vertices, 0, 4, _indices, 0, 2);
            }
        }

        /// <summary>
        /// Draws this Sprite to the Screen using a SpriteBatch.
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
        /// Draws this Sprite to the Screen using a SpriteBatch.
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
        /// Draws this Sprite to the Screen using a SpriteBatch.
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


        