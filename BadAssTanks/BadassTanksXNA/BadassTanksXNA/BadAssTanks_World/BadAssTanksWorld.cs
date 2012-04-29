using System;
using System.Collections.Generic;
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

        private List<GameObject2D> objects = new List<GameObject2D>();
       
        public BadAssTanksWorld(Texture2DHandler textureHandler, Viewport viewport)
            : base(textureHandler, viewport)
        {
            obj1 = new TitleTextObject2D(new UnanimatedSprite(_textureHandler.GetTexture("bad")), 50, 50, Color.White);
            obj2 = new TextObject2D(new TextSprite(_textureHandler.GetFontTexture("courierNew"), "Hello World"), 100, 100, Color.White);

            _quadTree.AddObject(obj1);
            _quadTree.AddObject(obj2);

            Random random = new Random();

            for (int i = 0; i < 25; i++)
            {
                // Choose a random size
                int size = random.Next(0, 40);

                // Choose x and y values (with a buffer around the border of the window)
                int x = random.Next(size, _viewport.Width - size);
                int y = random.Next(size, _viewport.Height - size);

                TitleTextObject2D temp = new TitleTextObject2D(new UnanimatedSprite(
                    _textureHandler.GetTexture("bad")), x, y, Color.White);

                temp.ScaleValue = 0.25f;

                objects.Add(temp);

                _quadTree.AddObject(temp);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            obj1.Draw(spriteBatch);
            obj2.Draw(spriteBatch);

            _quadTree.Draw(spriteBatch);

            foreach (GameObject2D obj in objects)
            {
                obj.Draw(spriteBatch);
            }
        }
    }
}
