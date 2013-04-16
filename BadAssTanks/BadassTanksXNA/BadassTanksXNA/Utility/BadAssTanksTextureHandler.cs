using KerpEngine.Engine_2D;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using KerpEngine.Core;

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
        /// <param name="contentManager">The content manager handling the textures.</param>
        public BadAssTanksTextureHandler(ContentManager contentManager)
            : base(contentManager)
        {
        }

        /// <summary>
        /// Loads the Textures - implemented by extending classes.
        /// </summary>
        /// <param name="textureInitFile">Texture file listing to load.</param>
        public override void LoadTextures(string textureInitFile)
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
        /// <param name="textureInitFile">Texture file listing to load.</param>
        public override void LoadFontTextures(string textureInitFile)
        {
            //
            //TODO: load all the textures from the string names file and add them to the map
            //

            _fontTextureMap.Add("courierNew", _contentManager.Load<SpriteFont>("courierNew"));
        }
    }
}
