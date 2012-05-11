using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace KerpEngine.Engine_2D.Sprites
{
    /// <summary>
    /// Represents a Text Sprite that can be drawn to the screen.
    /// </summary>
    public class TextSprite : CustomSprite
    {
        /// <summary>
        /// The text to display within the TextSprite.
        /// </summary>
        private string _text;
        public string Text { get { return _text; } set { _text = value; } }
        /// <summary>
        /// The font to use when drawing the TextSprite text.
        /// </summary>
        private SpriteFont _font;
        public SpriteFont Font { get { return _font; } set { _font = value; } }

        /// <summary>
        /// Creates a new TextSprite with the given font and display text.
        /// </summary>
        /// <param name="font">The font to use when drawing the TextSprite text.</param>
        /// <param name="text">The text to display within the TextSprite.</param>
        public TextSprite(SpriteFont font, string text)
            : base(null, 0.0f, 0.0f)
        {
            _font = font;
            _text = text;
        }

        /// <summary>
        /// Draws the Sprite to the screen using a 3D method of display, thus
        /// not using a SpriteBatch.
        /// </summary>
        /// <param name="device">The GraphicsDevice to perform the drawing.</param>
        /// <param name="effect">The effect to use while drawing.</param>
        public override void Draw(GraphicsDevice device, BasicEffect effect)
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
            //Find the center of the string
            Vector2 fontOrigin = this._font.MeasureString(_text) / 2;

            this.Draw(spriteBatch, position, fontOrigin, rotation, scale, textureTint,
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
            this.Draw(spriteBatch, position, rotationOrigin, rotation, scale, null, textureTint, effects, layerDepth);
        }

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
        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 rotationOrigin, float rotation,
             float scale, Rectangle? sourceRectangle, Color textureTint, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.DrawString(this._font, this._text, position, textureTint,
                rotation, rotationOrigin, scale, effects, layerDepth);
        }
    }
}

