using EngineCore2D.Engine;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace BadassTanksXNA.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public class BadAssTanksTextureHandler : Texture2DHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="textureInitFile"></param>
        /// <param name="contentManager"></param>
        public BadAssTanksTextureHandler(string textureInitFile, ContentManager contentManager)
            : base(textureInitFile, contentManager)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void LoadTextures()
        {
            //
            //TODO: load all the textures from the string names file and add them to the map
            //

            this._textureMap.Add("bad", _contentManager.Load<Texture2D>("bad"));
            this._textureMap.Add("whitePixel", _contentManager.Load<Texture2D>("whitePixel"));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void LoadFontTextures()
        {
            //
            //TODO: load all the textures from the string names file and add them to the map
            //

            this._fontTextureMap.Add("courierNew", _contentManager.Load<SpriteFont>("courierNew"));
        }
    }
}
