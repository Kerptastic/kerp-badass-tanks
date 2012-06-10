using KerpEngine.Engine_3D.Models;
using KerpEngine.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KerpEngine.Engine_3D
{
    /// <summary>
    /// Represents a drawable, 3D, Game Object.  This class is expected to be
    /// extended by a Game Object class in a custom Game.  
    /// 
    /// This class simply provides all the member variables, and interfaces 
    /// required to be drawn, moved, and manipulated at an abstract level.
    /// 
    /// This class will be expected to be extended by a Custom Game Engine.
    /// 
    /// No mention of custom Game Objects will be found here.
    /// </summary>
    public abstract class GameObject3D : GameObject
    {
        /// <summary>
        /// The model to be drawn to the screen.
        /// </summary>
        protected CustomModel _model;
        public CustomModel Model { get { return _model; } }
        /// <summary>
        /// Returns the Z value of the position vector.
        /// </summary>
        public float Z { get { return _position.Z; } set { _position.Z = value; } }//_boundingRectangle.Z = (int)value; } }
        
        /// <summary>
        /// Default constructor which just represents an object in the game
        /// that isnt drawn to the screen, but still has a location within 
        /// the game (i.e., a camera, a light, etc)
        /// </summary>
        /// <param name="position">The initial location of the object on the screen.</param>
        public GameObject3D(CustomModel model, Vector3 position, Color textureTint)
        {
            _model = model;
            _position = position;
            _textureTint = TextureTint;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewMatrix"></param>
        /// <param name="projectionMatrix"></param>
        public virtual void Draw(GraphicsDevice graphicsDevice, BasicEffect effect, Matrix viewMatrix, Matrix projectionMatrix) 
        {
            Matrix worldMatrix = Matrix.CreateScale(_scale) * 
                                 Matrix.CreateRotationX(_rotation.X) *
                                 Matrix.CreateRotationY(_rotation.Y) *
                                 Matrix.CreateRotationZ(_rotation.Z) * 
                                 Matrix.CreateTranslation(_position);

            _model.Draw(worldMatrix, viewMatrix, projectionMatrix);
            _boundingVolume.Draw(graphicsDevice, effect);
        }

    }
}
