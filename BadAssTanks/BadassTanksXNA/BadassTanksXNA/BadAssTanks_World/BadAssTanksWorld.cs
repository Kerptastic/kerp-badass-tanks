using System.Collections.Generic;
using BadassTanksXNA.BadAssTanks_Objects;
using KerpEngine.Core;
using KerpEngine.Engine_2D;
using KerpEngine.Engine_2D.Sprites;
using KerpEngine.Engine_3D;
using KerpEngine.Engine_3D.Models;
using KerpEngine.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BadassTanksXNA.BadAssTanks_World
{
    /// <summary>
    /// 
    /// </summary>
    public class BadAssTanksWorld : GameWorld<GameObject, AABB>
    {
        private GameObject2D obj1;
        public GameObject2D TestObject { get { return obj1; } }

        private GameObject2D obj2;
        public GameObject2D TextObject { get { return obj2; } }

        private GameObject3D obj3;
        public GameObject3D MeshObject { get { return obj3; } }

        private List<GameObject> objects = new List<GameObject>();

        private float totalPassed = 0;

        public BadAssTanksWorld(TextureHandler textureHandler, ModelHandler modelHandler, Viewport viewport)
            : base(textureHandler, modelHandler, viewport)
        {
            _spatialStructure = new QuadTree(null, 0, 0, 50, 50);

            obj1 = new TitleTextObject2D(new UnanimatedSprite(_textureHandler.GetTexture("bad"), 1, 1), -10, -10, Color.White);
         
            obj2 = new TextObject2D(new TextSprite2D(_textureHandler.GetFontTexture("courierNew"), "Hello World"), 220, 50, Color.White);

            obj3 = new TankObject3D(new CustomModel(_modelHandler.GetModel("test")), new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, -1.0f), Color.White);
            obj3.ScaleValue = new Vector3(0.5f, 0.5f, 0.5f);


            _spatialStructure.AddObject(obj1);
            objects.Add(obj1);

            Random random = new Random();
            for (int i = 0; i < 105; i++)
            {
                totalPassed = 0.0f;
                // Choose a random size
                int size = random.Next(0, 1);

                // Choose x and y values (with a buffer around the border of the window)
                int x = random.Next(-25 + size, 25 - size);
                int y = random.Next(-25 + size, 25 - size);

                //int x = random.Next(-25, -10);
                //int y = random.Next(-25, -10);

                TitleTextObject2D temp = new TitleTextObject2D(new UnanimatedSprite(
                    _textureHandler.GetTexture("bad"), 1, 1), x, y, Color.White);

                objects.Add(temp);

                _spatialStructure.AddObject(temp);
            }
        }

        protected override void BuildWorld()
        {
        }

        public override void CheckCollisions()
        {
            SpatialStructure<GameObject, AABB> storedNode, actualNode;

            storedNode = _spatialStructure.FindObjectsNode(obj1);
            actualNode = _spatialStructure.GetObjectsContainingNode(obj1);

            if (storedNode != null && !storedNode.Equals(actualNode))
            {
                if (storedNode.Parent != null)
                {
                    storedNode.Parent.RedistributeObjects();
                }
                else
                {
                    _spatialStructure.RedistributeObjects();
                }
            }

            List<GameObject> objs;

            if (actualNode.Parent != null)
            {
                objs = QuadTree.GetAllObjectsInNode(actualNode.Parent);
            }
            else
            {
                objs = QuadTree.GetAllObjectsInNode(actualNode);
            }

            foreach (GameObject obj in objs)
            {
                if (obj1.BoundingVolume.Contains(obj.BoundingVolume))
                {
                    actualNode.RemoveObject(obj);
                    objects.Remove(obj);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            obj2.Draw(spriteBatch);      
        }

        public override void Draw(GraphicsDevice device, BasicEffect effect, Matrix viewMatrix, Matrix projectionMatrix, GameTime gameTime)
        {
            _spatialStructure.Draw(device, effect);

            obj1.Draw(device, effect);

            foreach (GameObject obj in objects)
            {
                if (obj is GameObject2D)
                {
                    ((GameObject2D)obj).Draw(device, effect);
                }
                else
                {
                    ((GameObject3D)obj).Draw(device, effect, viewMatrix, projectionMatrix);
                }
            }  

            //obj3.Draw(device, effect, viewMatrix, projectionMatrix);   
        }

        public override void Update(GameTime gameTime)
        {
            CheckCollisions();

            Random random = new Random();
            totalPassed += gameTime.ElapsedGameTime.Milliseconds;

            //for (int i = 0; i < 6; i++)
            ////if(totalPassed > 3000.0f)
            //{

            //    totalPassed = 0.0f;
            //    // Choose a random size
            //    int size = random.Next(0, 1);

            //    // Choose x and y values (with a buffer around the border of the window)
            //    int x = random.Next(-25 + size, 25 - size);
            //    int y = random.Next(-25 + size, 25 - size);

            //    TitleTextObject2D temp = new TitleTextObject2D(new UnanimatedSprite(
            //        _textureHandler.GetTexture("bad"), 1, 1), x, y, Color.White);

            //    objects.Add(temp);

            //    _spatialStructure.AddObject(temp);
            //}


            obj1.Update();
            obj2.Update();
            obj3.Update();
        }
    }
}
