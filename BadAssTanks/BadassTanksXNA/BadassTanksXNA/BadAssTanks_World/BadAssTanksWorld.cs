using System;
using System.Collections.Generic;
using BadassTanksXNA.BadAssTanks_Objects;
using KerpEngine.Global;
using KerpEngine.Engine_2D.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using KerpEngine.Engine_2D;
using KerpEngine.Engine_3D;
using KerpEngine.Engine_3D.Models;

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

        private GameObject3D obj3;
        public GameObject3D MeshObject { get { return obj3; } }

        private List<GameObject2D> objects = new List<GameObject2D>();
       
        public BadAssTanksWorld(TextureHandler textureHandler, ModelHandler modelHandler, Viewport viewport)
            : base(textureHandler, modelHandler, viewport)
        {
            obj1 = new TitleTextObject2D(new UnanimatedSprite(_textureHandler.GetTexture("bad"), 1, 1), 0, 0, Color.White);
            obj1.ScaleValue = new Vector3(0.4f, 0.4f, 0.4f);
            
            obj2 = new TextObject2D(new TextSprite(_textureHandler.GetFontTexture("courierNew"), "Hello World"), 220, 50, Color.White);

            obj3 = new TankObject3D(new CustomModel(_modelHandler.GetModel("xwing")), new Vector3(0.0f, 0.0f, 0.5f), Color.White);
            obj3.ScaleValue = new Vector3(0.002f, 0.002f, 0.002f);
            obj3.Rotation = new Vector3(MathHelper.ToRadians(10.0f), MathHelper.ToRadians(10.0f), MathHelper.ToRadians(10.0f));

            //_quadTree.AddObject(obj1);
            //_quadTree.AddObject(obj2);

            //Random random = new Random();

            //for (int i = 0; i < 25; i++)
            //{
            //    // Choose a random size
            //    int size = random.Next(0, 40);

            //    // Choose x and y values (with a buffer around the border of the window)
            //    int x = random.Next(size, _viewport.Width - size);
            //    int y = random.Next(size, _viewport.Height - size);

            //    TitleTextObject2D temp = new TitleTextObject2D(new UnanimatedSprite(
            //        _textureHandler.GetTexture("bad"), 15, 15), x, y, Color.White);

            //    temp.ScaleValue = 0.25f;

            //    objects.Add(temp);

            //    _quadTree.AddObject(temp);
            //}
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            
            //obj2.Draw(spriteBatch);           
        }

        public override void Draw(GraphicsDevice device, BasicEffect effect, Matrix viewMatrix, Matrix projectionMatrix, GameTime gameTime)
        {
            _quadTree.Draw(device, effect);
            obj1.Draw(device, effect);
            obj3.Draw(device, effect, viewMatrix, projectionMatrix);   
        }
    }
}
