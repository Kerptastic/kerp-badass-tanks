using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KerpEngine.Engine_3D;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BadassTanksXNA.Utility
{
    /// <summary>
    /// The BadAssTanks Model Handler.
    /// </summary>
    public class BadAssTanksModelHandler : ModelHandler
    {
       
        /// <summary>
        /// Creates a new 3D Model Handler. 
        /// 
        /// Will load the Models upon creation.
        /// </summary>
        /// <param name="textureInitFile">The init file of models to use.</param>
        /// <param name="contentManager">The content manager handling the models.</param>
        public BadAssTanksModelHandler(string textureInitFile, ContentManager contentManager)
            : base(textureInitFile, contentManager)
        {
        }

        /// <summary>
        /// Loads the Models - implemented by extending classes.
        /// </summary>
        protected override void LoadModels()
        {
            //
            //TODO: load all the models from the string names file and add them to the map
            //

            _modelMap.Add("xwing", _contentManager.Load<Model>("xwing"));
        }
    }
}
