using EngineCore2D.Engine;
using BadassTanksXNA.Utility;
using BadassTanksXNA.BadAssTanks_World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace BadassTanksXNA
{
    /// <summary>
    /// 
    /// </summary>
    public class BadAssTanksGameEngine : GameEngine2D<BadAssTanksWorld>
    {
        public BadAssTanksGameEngine()
            : base()
        {
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            this._textureHandler = new BadAssTanksTextureHandler("", Content);
            this._gameWorld = new BadAssTanksWorld(this._textureHandler);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            GamePadState playerOneController = GamePad.GetState(PlayerIndex.One);

            //Handle the input events the way you want here:
            Vector2 leftStick = playerOneController.ThumbSticks.Left;
            Vector2 rightStick = playerOneController.ThumbSticks.Right;

            //flip the direction of up and down on the sticks
            leftStick.Y *= -1;
            rightStick.Y *= -1;

            //flip the direction of left and right on the stick
            //leftStick.X *= -1;
            //rightStick.X *= -1;

            this._gameWorld.TestObject.Move(leftStick, 5.0f);
            //this._gameWorld.TestObject.Rotation = rightStick.Length();
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            _spriteBatch.Begin(SpriteSortMode.Deferred,
                               BlendState.AlphaBlend,
                               null, null, null, null,
                               _camera2d.View);

            _gameWorld.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();
        }
    }
}
