using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace KerpEngine.Core
{
    /// <summary>
    /// Loads and manages 2D Textures for the Game Engine.
    /// 
    /// This class is expected to be implemented by a Custom TextureHandler, 
    /// also requiring the LoadTextures method to be implemented.
    /// </summary>
    public abstract class TextureHandler
    {
        /// <summary>
        /// The content manager used to manage the 2D content.
        /// </summary>
        protected ContentManager _contentManager;
        /// <summary>
        /// The Texture Map holding the sprites to be retrieved when needed.
        /// </summary>
        protected Dictionary<string, Texture2D> _textureMap;
        /// <summary>
        /// The Texture Map holding the sprite fonts to be retrieved when needed.
        /// </summary>
        protected Dictionary<string, SpriteFont> _fontTextureMap;

        /// <summary>
        /// Creates a new 2D Texture Handler. 
        /// </summary>
        /// <param name="contentManager">The content manager handling the textures.</param>
        public TextureHandler(ContentManager contentManager)
        {
            _textureMap = new Dictionary<string, Texture2D>();
            _fontTextureMap = new Dictionary<string, SpriteFont>();

            _contentManager = contentManager;
        }

        /// <summary>
        /// Retrieves a Texture that is saved to the given string key.
        /// </summary>
        /// <param name="textureName">The name of the texture to retrieve</param>
        /// <returns>A Texture2D object with the supplied textureName.</returns>
        public virtual Texture2D GetTexture(string textureName)
        {
            Texture2D returnTexture;

            _textureMap.TryGetValue(textureName, out returnTexture);

            return returnTexture;
        }

        /// <summary>
        /// Retrieves a SpriteFontTexture that is saved to the given string key.
        /// </summary>
        /// <param name="fontTextureName">The name of the SpriteFontTexture to retrieve</param>
        /// <returns>A SpriteFontTexture object with the supplied fontTextureName.</returns>
        public virtual SpriteFont GetFontTexture(string fontTextureName)
        {
            SpriteFont returnTexture;

            _fontTextureMap.TryGetValue(fontTextureName, out returnTexture);

            return returnTexture;
        }

        /// <summary>
        /// Loads the Textures - implemented by extending classes.
        /// </summary>
        /// <param name="textureInitFile">Texture file listing to load.</param>
        public abstract void LoadTextures(string textureInitFile);

        /// <summary>
        /// Loads the Font Textures - implemented by extending classes.
        /// </summary>
        /// <param name="textureInitFile">Texture file listing to load.</param>
        public abstract void LoadFontTextures(string textureInitFile);
    }
}
