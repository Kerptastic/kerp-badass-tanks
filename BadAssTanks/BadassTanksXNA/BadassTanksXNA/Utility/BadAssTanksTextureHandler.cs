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
        /// Returns a texture with the given textureName from the texture map.
        /// </summary>
        /// <param name="textureName">The name of the texture to return.</param>
        /// <returns>A texture from the texture map with the name provided.</returns>
        public override Texture2D GetTexture(string textureName)
        {
            return _titleBad;
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
    }
}
