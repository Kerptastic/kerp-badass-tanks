using Microsoft.Xna.Framework.Graphics;

namespace KerpEngine.Global
{
    public interface BoundingVolume
    {
        bool Contains(BoundingVolume other);

        void Draw(GraphicsDevice graphicsDevice, BasicEffect effect);
    }
}
