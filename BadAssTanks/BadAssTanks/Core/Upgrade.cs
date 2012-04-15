using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace BadAssTanks
{
    public class Upgrade : WorldObject
    {
        //private CustomSprite m_sprite = null;
        //private Device m_device = null;

        //private GameWorld.WorldObjectType m_type;

        //private float xPos, yPos;

        //public Upgrade(Device device, CustomSprite sprite, GameWorld.WorldObjectType objectType)
        //{
        //    m_device = device;
        //    m_sprite = sprite;

        //    m_type = objectType;

        //    xPos = m_sprite.GetXPos();
        //    yPos = m_sprite.GetYPos();
        //}

        //public override BoundingShape2D GetBoundingShape()
        //{
        //    return null;
        //}

        //public void SetLocation(float x, float y)
        //{
        //    xPos = x;
        //    yPos = y;

        //    m_sprite.SetLocation(x, y);
        //}

        //public CustomSprite GetSprite()
        //{
        //    return m_sprite;
        //}

        //public override ArrayList FireWeapon(string weaponName)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        //public override void Render()
        //{
        //    Matrix saved = m_device.Transform.World;

        //    m_device.Transform.World = Matrix.Scaling(new Vector3(1.35f, 0.35f, 0.0f)) *
        //            Matrix.Translation(new Vector3(xPos, yPos, 0.0f));

        //    m_sprite.Render();

        //    m_device.Transform.World = saved;
        //}

        //public override int GetCrashDamage()
        //{
        //    return 0;
        //}

        //public override void Destroy()
        //{
        //    if (m_sprite != null)
        //        m_sprite.Destroy();
        //}

        //public override bool IsDestroyed()
        //{
        //    return false;
        //}

        //public override void Move(string direction, Camera camera)
        //{
        //}

        //public override void Move(float angle)
        //{
        //}

        //public override void Move(WorldObject obj)
        //{
        //}

        //public override bool ReadyToFire()
        //{
        //    return false;
        //}

        //public GameWorld.WorldObjectType GetUpgradeType()
        //{
        //    return m_type;
        //}

        //public override void Rotate(string direction)
        //{
        //}

        //public override void RotateGundam(float angle)
        //{
        //}

        //public override float GetFacingAngle()
        //{
        //    return 0.0f;
        //}

        //public override GameEngine.IntCoords GetWorldCoords()
        //{
        //    return new GameEngine.IntCoords();
        //}

        //public override GameEngine.FloatCoords GetTileCoords()
        //{
        //    return new GameEngine.FloatCoords();
        //}

        //public override void Tint(Color color)
        //{
        //}

        //public override bool ReduceHealth(float value)
        //{
        //    return false;
        //}

        //public override long GetPointValue()
        //{
        //    return 0;
        //}
    }
}
