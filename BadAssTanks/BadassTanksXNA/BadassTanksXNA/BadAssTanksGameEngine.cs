using EngineCore2D.Engine;
using BadassTanksXNA.Utility;
using BadassTanksXNA.BadAssTanks_World;

namespace BadassTanksXNA
{
    /// <summary>
    /// 
    /// </summary>
    public class BadAssTanksGameEngine : GameEngine2D
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
    }
}
