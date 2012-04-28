using EngineCore2D.Engine;
using EngineCore2D.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BadassTanksXNA.BadAssTanks_Objects
{
    /// <summary>
    /// 
    /// </summary>
    public class TextObject : GameObject2D
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="xLocation"></param>
        /// <param name="yLocation"></param>
        /// <param name="textureTint"></param>
        public TextObject(TextSprite sprite, int xLocation, int yLocation, Color textureTint)
            : base(sprite, xLocation, yLocation, textureTint)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_sprite != null)
            {
                _sprite.Draw(spriteBatch, _position, _rotation, _scale, _textureTint, SpriteEffects.None, 0.0f);
            }
        }
    }
}
