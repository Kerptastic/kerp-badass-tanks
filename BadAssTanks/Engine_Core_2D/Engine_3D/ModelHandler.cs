using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace KerpEngine.Engine_3D
{
    /// <summary>
    /// Loads and manages 3D Models for the Game Engine.
    /// 
    /// This class is expected to be implemented by a Custom ModelHandler, 
    /// also requiring the LoadModels method to be implemented.
    /// </summary>
    public abstract class ModelHandler
    {
        /// <summary>
        /// The content manager used to manage the 3D content.
        /// </summary>
        protected ContentManager _contentManager;
        /// <summary>
        /// The initialization file that is used to provide model
        /// loading information (primarily for handling what models
        /// to load/unload and when).
        /// </summary>
        protected string _modelInitFile;
        /// <summary>
        /// The Model Map holding the models to be retrieved when needed.
        /// </summary>
        protected Dictionary<string, Model> _modelMap = new Dictionary<string, Model>();

        /// <summary>
        /// Creates a new 3D Model Handler. 
        /// 
        /// Will load the Models upon creation.
        /// </summary>
        /// <param name="textureInitFile">The init file of models to use.</param>
        /// <param name="contentManager">The content manager handling the models.</param>
        public ModelHandler(string modelInitFile, ContentManager contentManager)
        {
            _modelInitFile = modelInitFile;
            _contentManager = contentManager;

            this.LoadModels();
        }

        /// <summary>
        /// Retrieves a Model that is saved to the given string key.
        /// </summary>
        /// <param name="modelName">The name of the Model to retrieve</param>
        /// <returns>A Model object with the supplied modelName.</returns>
        public virtual Model GetModel(string modelName)
        {
            Model returnModel;

            _modelMap.TryGetValue(modelName, out returnModel);

            return returnModel;
        }

        /// <summary>
        /// Loads the Models - implemented by extending classes.
        /// </summary>
        protected abstract void LoadModels();
    }
}
