using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace EngineCore2D.Sprites
{
    /// <summary>
    /// 
    /// </summary>
    public class TextSprite : CustomSprite
    {
        /// <summary>
        /// 
        /// </summary>
        private string _text;
        public string Text { get { return _text; } set { _text = value; } }
        /// <summary>
        /// 
        /// </summary>
        private SpriteFont _font;
        public SpriteFont Font { get { return _font; } set { _font = value; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        public TextSprite(SpriteFont font, string text)
            : base(null)
        {
            this._font = font;
            this._text = text;
        }


        public override void Draw(SpriteBatch spriteBatch, Vector2 position, float rotation, float scale, 
            Color textureTint, SpriteEffects effects, float layerDepth)
        {
            //Find the center of the string
            Vector2 fontOrigin = this._font.MeasureString(_text) / 2;

            this.Draw(spriteBatch, position, fontOrigin, rotation, scale, textureTint,
               effects, layerDepth);
        }


        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 rotationOrigin,
            float rotation, float scale, Color textureTint, SpriteEffects effects, float layerDepth)
        {
            this.Draw(spriteBatch, position, rotation, scale, null, textureTint, rotationOrigin, effects, layerDepth);
        }


        public override void Draw(SpriteBatch spriteBatch, Vector2 position, float rotation, float scale, 
            Rectangle? sourceRectangle, Color textureTint, Vector2 rotationOrigin, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.DrawString(this._font, this._text, position, textureTint,
                rotation, rotationOrigin, scale, effects, layerDepth);
        }
    }
}

