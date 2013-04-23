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
        BasicEffect quadEffect;
        float _framesPerSecond = 0.0f;
        StringBuilder _debugTextBuffer = new StringBuilder();

        public BadAssTanksGameEngine()
            : base()
        {  
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            _textureHandler = new BadAssTanksTextureHandler(Content);
            _textureHandler.LoadTextures("");
            _textureHandler.LoadFontTextures("");

            _modelHandler = new BadAssTanksModelHandler(Content);
            _modelHandler.LoadModels("");

            _gameWorld = new BadAssTanksWorld(_textureHandler, _modelHandler, GraphicsDevice.Viewport);

            _camera2d = new Camera2D(GraphicsDevice.Viewport, new Vector3(0, 4, 10));

            _camera3d = new Camera3DFirstPerson(GraphicsDevice.Viewport,
                new Vector3(0, 0, 70), new Vector3(0.0f, 0.0f, 0.0f));

            quadEffect = new BasicEffect(_graphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _gameWorld.Update(gameTime);

            GamePadState playerOneController = GamePad.GetState(PlayerIndex.One);

            //Handle the input events the way you want here:
            Vector2 leftStick = playerOneController.ThumbSticks.Left;
            Vector2 rightStick = playerOneController.ThumbSticks.Right;


            _framesPerSecond = (1000.0f / (float)gameTime.ElapsedGameTime.TotalMilliseconds);

            float moveSpeed = 5.0f;
            float rotateSpeed = MathHelper.ToRadians(70.0f);
            float rotateAmount = 0.0f;
            float moveAmount = 0.0f;

            if(gameTime.ElapsedGameTime.Milliseconds != 0)
            {
                rotateAmount = (rotateSpeed * (float)gameTime.ElapsedGameTime.TotalMilliseconds) / 1000.0f;
                moveAmount = (moveSpeed * (float)gameTime.ElapsedGameTime.TotalMilliseconds) / 1000.0f;
            }

            Vector3 rotation = new Vector3(-rightStick.Y, -rightStick.X, 0.0f);
            _camera3d.Rotate(rotation * rotateAmount);

            Vector3 movement = new Vector3(-leftStick.X, 0.0f, leftStick.Y);
            _camera3d.Move(movement * moveAmount);


            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.D))
            {

                //this._gameWorld.MeshObject.Rotate(new Vector3(0.0f, -rotateAmount, 0.0f));
                //this._gameWorld.TestObject.Move(new Vector2(1.0f, 0.0f), );
                
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                //this._gameWorld.MeshObject.Rotate(new Vector3(0.0f, rotateAmount, 0.0f));
                //
                //this.cam.Move(new Vector3(1.0f, 0.0f, 0.0f), 0.05f);
            }
            if (keyboard.IsKeyDown(Keys.S))
            {
                this._gameWorld.MeshObject.Move(new Vector3(0.0f, 0.0f, -1.0f));
                //_camera3d.Move(new Vector3(0.0f, 0.0f, -0.05f));
            }
            if (keyboard.IsKeyDown(Keys.W))
            {
                this._gameWorld.MeshObject.Move(new Vector3(0.0f, 0.0f, 1.0f));
               // _camera3d.Move(new Vector3(0.0f, 0.0f, 0.05f));
            }

            if (keyboard.IsKeyDown(Keys.S))
            {
                this._gameWorld.MeshObject.Move(new Vector3(0.0f, 0.0f, -1.0f));
                //_camera3d.Move(new Vector3(0.0f, 0.0f, -0.05f));
            }



            if (keyboard.IsKeyDown(Keys.Up))
            {
                this._gameWorld.TestObject.Move(new Vector3(0.0f, 2.0f, 0.0f));
            }

            if (keyboard.IsKeyDown(Keys.Down))
            {
                this._gameWorld.TestObject.Move(new Vector3(0.0f, -2.0f, 0.0f));
            }

            if (keyboard.IsKeyDown(Keys.Left))
            {
                this._gameWorld.TestObject.Move(new Vector3(-2.0f, 0.0f, 0.0f));
            }

            if (keyboard.IsKeyDown(Keys.Right))
            {
                this._gameWorld.TestObject.Move(new Vector3(2.0f, 0.0f, 0.0f));
            }

            if (keyboard.IsKeyDown(Keys.Space))
            {
                this._gameWorld.CheckCollisions();
            }

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
        }


        protected override void Draw(GameTime gameTime)
        {
            quadEffect.EnableDefaultLighting();
            quadEffect.View = _camera3d.View;
            quadEffect.Projection = _camera3d.Projection;

            _spriteBatch.Begin(SpriteSortMode.Deferred,
                               BlendState.AlphaBlend,
                               null, null, null, null,
                               _camera2d.View);

            this.UpdateDebugText();
            _gameWorld.Draw(_spriteBatch, gameTime);


            _spriteBatch.End();


            _gameWorld.Draw(_graphicsDevice, quadEffect, _camera3d.View, _camera3d.Projection, gameTime);
        }


        private void UpdateDebugText()
        {
            _debugTextBuffer.Clear();
          
            _debugTextBuffer.AppendFormat("FPS: {0}\n", _framesPerSecond);
          
            _debugTextBuffer.Append("Camera:\n");
            _debugTextBuffer.AppendFormat("  Position: x:{0} y:{1} z:{2}\n",
                _camera3d.Position.X.ToString("f2"),
                _camera3d.Position.Y.ToString("f2"),
                _camera3d.Position.Z.ToString("f2"));

            _debugTextBuffer.AppendFormat("  Orientation: heading:{0} pitch:{1}\n",
                _camera3d.Yaw.ToString("f2"),
                _camera3d.Pitch.ToString("f2"));

            ((TextObject2D)_gameWorld.TextObject).SetText(_debugTextBuffer.ToString());
        }
    }
}
