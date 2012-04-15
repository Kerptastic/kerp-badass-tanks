using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;

namespace BadAssTanks
{
    public class Explosion : WorldObject
    {
        //private Device m_device = null;
        //private ArrayList m_explosionImages = null;

        //private CustomSprite m_explosionSprite = null;

        //private GameEngine.FloatCoords m_explosionTileCoords;
        //private GameEngine.IntCoords m_explosionWorldCoords;

        //private bool m_destroyed = false;

        //private const float m_explosionWidth = 400.0f;
        //private const float m_explosionHeight = 400.0f;
        //private const float m_explosionAspectRatio = m_explosionWidth / m_explosionHeight;

        //public Explosion(Device device, int worldX, int worldY, float tileX, float tileY)
        //{
        //    m_device = device;

        //    m_explosionWorldCoords.x = worldX;
        //    m_explosionWorldCoords.y = worldY;

        //    m_explosionTileCoords.x = tileX;
        //    m_explosionTileCoords.y = tileY;

        //    m_explosionImages = TextureHandler.GetInstance().GetExplosionTextures();

        //    m_explosionSprite = new AnimatedSprite(m_device, m_explosionImages,
        //        ((float)(m_explosionWorldCoords.x) + m_explosionTileCoords.x),
        //        ((float)(m_explosionWorldCoords.y) + m_explosionTileCoords.y), 0.0f, 0);
        //}

        //public override int GetCrashDamage()
        //{
        //    return 0;
        //}

        //public override long GetPointValue()
        //{
        //    return 0;
        //}

        //public override bool ReduceHealth(float value)
        //{
        //    return false;
        //}

        //public override bool IsDestroyed()
        //{
        //    return m_destroyed;
        //}

        //public override void Move(String direction, Camera camera)
        //{
        //}

        //public override void Move(float angle)
        //{
        //}

        //public override void Move(WorldObject obj)
        //{
        //}

        //public override ArrayList FireWeapon(string weaponName)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        //public override bool ReadyToFire()
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        //public override void Rotate(String direction)
        //{
        //}

        //public override void RotateGundam(float angle)
        //{
        //}
        //public override void Render()
        //{
        //    if (((AnimatedSprite)m_explosionSprite).GetCurrentCount() != ((AnimatedSprite)m_explosionSprite).GetTotalCount())
        //    {
        //        Matrix saved = m_device.Transform.World;

        //        m_device.Transform.World = Matrix.Scaling(new Vector3(m_explosionWidth / 1000.0f, m_explosionHeight / 1000.0f, 0.0f)) *
        //                Matrix.Translation(new Vector3((m_explosionWorldCoords.x + m_explosionTileCoords.x), (m_explosionWorldCoords.y + m_explosionTileCoords.y), 0.0f));
        //        m_explosionSprite.Render();

        //        m_device.Transform.World = saved;
        //    }
        //    else
        //    {
        //        this.Destroy();
        //    }
        //}

        //public override float GetFacingAngle()
        //{
        //    return 0.0f;
        //}

        //public override BoundingShape2D GetBoundingShape()
        //{
        //    return null;
        //}

        //public override GameEngine.IntCoords GetWorldCoords()
        //{
        //    return m_explosionWorldCoords;
        //}

        //public override GameEngine.FloatCoords GetTileCoords()
        //{
        //    return m_explosionTileCoords;
        //}

        //public override void Tint(Color color)
        //{
        //}

        //public override void Destroy()
        //{
        //    m_explosionSprite.Destroy();
        //    m_explosionSprite = null;
        //    m_destroyed = true;
        //}

    }
}
