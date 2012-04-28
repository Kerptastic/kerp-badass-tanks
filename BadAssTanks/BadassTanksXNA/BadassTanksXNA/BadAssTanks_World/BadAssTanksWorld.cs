using BadassTanksXNA.BadAssTanks_Objects;
using EngineCore2D.Engine;
using EngineCore2D.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BadassTanksXNA.BadAssTanks_World
{
    /// <summary>
    /// 
    /// </summary>
    public class BadAssTanksWorld : GameWorld
    {
        private GameObject2D obj1;
        public GameObject2D TestObject { get { return obj1; } }

        private GameObject2D obj2;
        public GameObject2D TextObject { get { return obj2; } }

        public BadAssTanksWorld(Texture2DHandler textureHandler)
            : base(textureHandler)
        {
            obj1 = new TitleTextObject(new UnanimatedSprite(_textureHandler.GetTexture("bad")), 50, 50, Color.White);
            obj2 = new TextObject(new TextSprite(_textureHandler.GetFontTexture("courierNew"), "Hello World"), 100, 100, Color.White);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            obj1.Draw(spriteBatch);
            obj2.Draw(spriteBatch);
        }
    }
}
