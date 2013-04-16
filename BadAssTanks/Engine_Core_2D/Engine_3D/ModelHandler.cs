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
        /// The Model Map holding the models to be retrieved when needed.
        /// </summary>
        protected Dictionary<string, Model> _modelMap;

        /// <summary>
        /// Creates a new 3D Model Handler.
        /// </summary>
        /// <param name="contentManager">The content manager handling the models.</param>
        public ModelHandler(ContentManager contentManager)
        {
            _modelMap = new Dictionary<string, Model>();
            _contentManager = contentManager;
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
        /// <param name="modelInitFile">Model file listing to load.</param>
        public abstract void LoadModels(string modelInitFile);
    }
}
