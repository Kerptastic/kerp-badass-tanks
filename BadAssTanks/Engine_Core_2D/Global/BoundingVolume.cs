using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using KerpEngine.Engine_3D;

namespace KerpEngine.Global
{
    /// <summary>
    /// Interface defining the methods for a BoundingVolume.
    /// </summary>
    public abstract class BoundingVolume : GameObject3D
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="target"></param>
        public BoundingVolume(Vector3 position, Vector3 target)
            : base(null, position, target, Color.White)
        {
        }

        /// <summary>
        /// Checks to see if the given Bounding Volume is contained within this Bounding Volume.
        /// </summary>
        /// <param name="other">The Bounding Volume to see if is contained within this Bounding Volume.</param>
        /// <returns>Whether or not the given Bounding Volume is contained within this Bounding Volume.</returns>
        public abstract bool Contains(BoundingVolume other);

        /// <summary>
        /// Draws this Bounding Volume to the screen.
        /// </summary>
        /// <param name="graphicsDevice">The Graphics Device to use to draw the Volume.</param>
        /// <param name="effect">The effect to use when drawing.</param>
        public abstract void Draw(GraphicsDevice graphicsDevice, BasicEffect effect);
    }
}
