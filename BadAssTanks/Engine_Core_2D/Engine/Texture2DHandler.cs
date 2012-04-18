using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace EngineCore2D.Engine
{
    /// <summary>
    /// Loads and manages 2D Textures for the Game Engine.
    /// 
    /// This class is expected to be implemented by a Custom TextureHandler, 
    /// also requiring the LoadTextures method to be implemented.
    /// </summary>
    public abstract class Texture2DHandler
    {
        /// <summary>
        /// The content manager used to manage the 2D content.
        /// </summary>
        protected ContentManager _contentManager;
        /// <summary>
        /// The initialization file that is used to provide texture
        /// loading information (primarily for handling what sprites
        /// to load/unload and when).
        /// </summary>
        protected string textureInitFile;
        /// <summary>
        /// The Texture Map holding the sprites to be retrieved when needed.
        /// </summary>
        protected Dictionary<string, Texture2D> _textureMap = new Dictionary<string, Texture2D>();

        /// <summary>
        /// Creates a new 2D Texture Handler. 
        /// 
        /// Will load the Textures upon creation.
        /// </summary>
        /// <param name="textureInitFile">The init file of textures to use.</param>
        /// <param name="contentManager">The content manager handling the textures.</param>
        public Texture2DHandler(string textureInitFile, ContentManager contentManager)
        {
            this.textureInitFile = textureInitFile;
            this._contentManager = contentManager;

            this.LoadTextures();
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
        /// Loads the Textures - implemented by extending classes.
        /// </summary>
        protected abstract void LoadTextures();
    }
}
