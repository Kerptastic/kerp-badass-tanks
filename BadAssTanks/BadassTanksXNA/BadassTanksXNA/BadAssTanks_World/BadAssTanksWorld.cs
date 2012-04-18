using BadAssTanks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EngineCore2D.Engine;
using EngineCore2D.Sprites;

namespace BadassTanksXNA.BadAssTanks_World
{
    /// <summary>
    /// 
    /// </summary>
    public class BadAssTanksWorld : GameWorld
    {
        private GameObject2D obj1;
        
        public BadAssTanksWorld(Texture2DHandler textureHandler)
            : base(textureHandler)
        {
            obj1 = new GameObject2D(new UnanimatedSprite(_textureHandler.GetTexture("bad")), 10, 10, 300, 300, Color.White);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            obj1.Draw(spriteBatch);
        }
    }
}
