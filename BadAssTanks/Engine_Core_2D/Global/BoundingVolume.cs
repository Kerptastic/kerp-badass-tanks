using Microsoft.Xna.Framework.Graphics;

namespace KerpEngine.Global
{
    /// <summary>
    /// Interface defining the methods for a BoundingVolume.
    /// </summary>
    public interface BoundingVolume
    {
        /// <summary>
        /// Checks to see if the given Bounding Volume is contained within this Bounding Volume.
        /// </summary>
        /// <param name="other">The Bounding Volume to see if is contained within this Bounding Volume.</param>
        /// <returns>Whether or not the given Bounding Volume is contained within this Bounding Volume.</returns>
        bool Contains(BoundingVolume other);

        /// <summary>
        /// Draws this Bounding Volume to the screen.
        /// </summary>
        /// <param name="graphicsDevice">The Graphics Device to use to draw the Volume.</param>
        /// <param name="effect">The effect to use when drawing.</param>
        void Draw(GraphicsDevice graphicsDevice, BasicEffect effect);
    }
}
