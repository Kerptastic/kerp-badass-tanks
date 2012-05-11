using KerpEngine.Engine_2D;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BadassTanksXNA.Utility
{
    /// <summary>
    /// The BadAssTanks Texture Handler.
    /// </summary>
    public class BadAssTanksTextureHandler : TextureHandler
    {
        /// <summary>
        /// Initializes the Texture Handler.
        /// </summary>
        /// <param name="textureInitFile">The init file of textures to use.</param>
        /// <param name="contentManager">The content manager handling the textures.</param>
        public BadAssTanksTextureHandler(string textureInitFile, ContentManager contentManager)
            : base(textureInitFile, contentManager)
        {
        }

        /// <summary>
        /// Loads the Textures - implemented by extending classes.
        /// </summary>
        protected override void LoadTextures()
        {
            //
            //TODO: load all the textures from the string names file and add them to the map
            //

            _textureMap.Add("bad", _contentManager.Load<Texture2D>("bad2"));
            _textureMap.Add("whitePixel", _contentManager.Load<Texture2D>("whitePixel"));
        }

        /// <summary>
        /// Loads the Font Textures - implemented by extending classes.
        /// </summary>
        protected override void LoadFontTextures()
        {
            //
            //TODO: load all the textures from the string names file and add them to the map
            //

            _fontTextureMap.Add("courierNew", _contentManager.Load<SpriteFont>("courierNew"));
        }
    }
}
