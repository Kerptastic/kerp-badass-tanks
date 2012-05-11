using BadassTanksXNA.BadAssTanks_World;
using BadassTanksXNA.Utility;
using KerpEngine.Engine_3D;
using KerpEngine.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;
using BadassTanksXNA.BadAssTanks_Objects;
using KerpEngine.Engine_2D;

namespace BadassTanksXNA
{
    /// <summary>
    /// 
    /// </summary>
    public class BadAssTanksGameEngine : GameEngine<BadAssTanksWorld>
    {
        Camera3D cam3D;
        BasicEffect quadEffect;
        float _framesPerSecond = 0.0f;

        public BadAssTanksGameEngine()
            : base()
        {  
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            _textureHandler = new BadAssTanksTextureHandler("", Content);
            _modelHandler = new BadAssTanksModelHandler("", Content);
            _gameWorld = new BadAssTanksWorld(_textureHandler, _modelHandler, GraphicsDevice.Viewport);

            cam3D = new Camera3DFirstPerson(GraphicsDevice.Viewport,
                new Vector3(0, 0, -10), new Vector3(0.0f, 0.0f, 0.0f));

            quadEffect = new BasicEffect(_graphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            GamePadState playerOneController = GamePad.GetState(PlayerIndex.One);

            //Handle the input events the way you want here:
            Vector2 leftStick = playerOneController.ThumbSticks.Left;
            Vector2 rightStick = playerOneController.ThumbSticks.Right;


            _framesPerSecond = (1000.0f / (float)gameTime.ElapsedGameTime.TotalMilliseconds);

            float moveSpeed = 5.0f;
            float rotateSpeed = 2.0f;
            float rotateAmount = 0.0f;
            float moveAmount = 0.0f;

            if(gameTime.ElapsedGameTime.Milliseconds != 0)
            {
                rotateAmount = (rotateSpeed * (float)gameTime.ElapsedGameTime.TotalMilliseconds) / 1000.0f;
                moveAmount = (moveSpeed * (float)gameTime.ElapsedGameTime.TotalMilliseconds) / 1000.0f;
            }

            Vector3 rotation = new Vector3(rightStick.X, rightStick.Y, 0.0f);
            cam3D.Rotate(rotation * rotateAmount);

            Vector3 movement = new Vector3(leftStick.X, 0.0f, leftStick.Y);
            cam3D.Move(movement * moveAmount);


            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.D))
            {
                //this._gameWorld.TestObject.Move(new Vector2(1.0f, 0.0f), amount * 10);
                
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                //this._gameWorld.TestObject.Move(new Vector2(-1.0f, 0.0f), amount);
                //this.cam.Move(new Vector3(1.0f, 0.0f, 0.0f), 0.05f);
            }
            if (keyboard.IsKeyDown(Keys.S))
            {
                //this._gameWorld.TestObject.Move(new Vector2(0.0f, -1.0f), amount);
                this.cam3D.Move(new Vector3(0.0f, 0.0f, -0.05f));
            }
            if (keyboard.IsKeyDown(Keys.W))
            {
                //this._gameWorld.TestObject.Move(new Vector2(0.0f, 1.0f), amount);
                this.cam3D.Move(new Vector3(0.0f, 0.0f, 0.05f));
            }
            if (keyboard.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }


            //if (keyboard.IsKeyDown(Keys.Up))
            //{
            //    _gameWorld.MeshObject.Move(new Vector3(0.0f, 1.0f, 0.0f), 0.05f);
            //}
            //if (keyboard.IsKeyDown(Keys.Down))
            //{
            //    _gameWorld.MeshObject.Move(new Vector3(0.0f, -1.0f, 0.0f), 0.05f);
            //}
            //if (keyboard.IsKeyDown(Keys.Left))
            //{
            //    _gameWorld.MeshObject.Move(new Vector3(-1.0f, 0.0f, 0.0f), 0.05f);
            //}
            //if (keyboard.IsKeyDown(Keys.Right))
            //{
            //    _gameWorld.MeshObject.Move(new Vector3(1.0f, 0.0f, 0.0f), 0.05f);
            //}
            //if (keyboard.IsKeyDown(Keys.RightAlt))
            //{
            //    _gameWorld.MeshObject.Move(new Vector3(0.0f, 0.0f, 1.0f), 0.05f);
            //}
            //if (keyboard.IsKeyDown(Keys.RightControl))
            //{
            //    _gameWorld.MeshObject.Move(new Vector3(0.0f, 0.0f, -1.0f), 0.05f);
            //}


            cam3D.Update();
        }


        protected override void Draw(GameTime gameTime)
        {
            quadEffect.EnableDefaultLighting();
            quadEffect.View = cam3D.View;
            quadEffect.Projection = cam3D.Projection;
            quadEffect.TextureEnabled = true;

            //_spriteBatch.Begin(SpriteSortMode.Deferred,
            //                   BlendState.AlphaBlend,
            //                   null, null, null, null,
            //                   _camera2d.View);

            //_gameWorld.Draw(_spriteBatch, gameTime);

            //_spriteBatch.End();

            this.DrawText();

            _gameWorld.Draw(_graphicsDevice, quadEffect, cam3D.View, cam3D.Projection, gameTime);
        }

        private void DrawText()
        {
            StringBuilder buffer = new StringBuilder();
          
            buffer.AppendFormat("FPS: {0}\n", _framesPerSecond);
          
            buffer.Append("Camera:\n");
            buffer.AppendFormat("  Position: x:{0} y:{1} z:{2}\n",
                cam3D.Position.X.ToString("f2"),
                cam3D.Position.Y.ToString("f2"),
                cam3D.Position.Z.ToString("f2"));
            buffer.AppendFormat("  Orientation: heading:{0} pitch:{1}\n",
                cam3D.Yaw.ToString("f2"),
                cam3D.Pitch.ToString("f2"));

            _spriteBatch.Begin(SpriteSortMode.Deferred,
                               BlendState.AlphaBlend,
                               null, null, null, null,
                               _camera2d.View);

            ((TextObject2D)_gameWorld.TextObject).SetText(buffer.ToString());
            _gameWorld.TextObject.Draw(_spriteBatch);

            _spriteBatch.End();
        }
    }
}
