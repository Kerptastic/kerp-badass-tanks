using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace KerpEngine.Engine_3D.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomModel
    {
        /// <summary>
        /// 
        /// </summary>
        protected Model _model;
        public Model Model { get { return _model; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public CustomModel(Model model)
        {
            _model = model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="worldMatrix"></param>
        /// <param name="viewMatrix"></param>
        /// <param name="projectionMatrix"></param>
        public void Draw(Matrix worldMatrix, Matrix viewMatrix, Matrix projectionMatrix)
        {
            Matrix[] transforms = new Matrix[_model.Bones.Count];
            _model.CopyAbsoluteBoneTransformsTo(transforms);

            foreach (ModelMesh mesh in _model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();

                    //effect.TextureEnabled = true;
                    effect.View = viewMatrix;
                    effect.Projection = projectionMatrix;
                    effect.World = transforms[mesh.ParentBone.Index] * worldMatrix;
                }
                mesh.Draw();
            }
        }
    }
}
