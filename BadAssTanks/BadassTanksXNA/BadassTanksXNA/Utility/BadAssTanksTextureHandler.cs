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
        private Texture2D _tank;
        public Texture2D TankTexture { get { return _tank; } }
        /// <summary>
        /// 
        /// </summary>
        private Texture2D _titleBad;
        public Texture2D TitleBadTexture { get { return _titleBad; } }

        private SpriteFont _courierNewFont;
        public SpriteFont CourierNew { get { return _courierNewFont; } }

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
        /// Overriding for testing purposes.
        /// </summary>
        /// <param name="textureName"></param>
        /// <returns></returns>
        public override Texture2D GetTexture(string textureName)
        {
            return _titleBad;
        }

        /// <summary>
        /// Overriding for testing purposes.
        /// </summary>
        /// <param name="textureName"></param>
        /// <returns></returns>
        public override SpriteFont GetFontTexture(string fontTextureName)
        {
            return _courierNewFont;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void LoadTextures()
        {
            //
            //TODO: load all the textures from the string names file and add them to the map
            //
            
            _titleBad = _contentManager.Load<Texture2D>("bad");
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void LoadFontTextures()
        {
            //
            //TODO: load all the textures from the string names file and add them to the map
            //

            _courierNewFont = _contentManager.Load<SpriteFont>("courierNew");
        }
    }
}
