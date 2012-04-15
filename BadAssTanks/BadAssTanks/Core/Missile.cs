using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace BadAssTanks
{
    public class Missile : WorldObject
    {          
        //private CustomSprite m_missileSprite = null;
        //private CustomSprite m_smokeSprite = null;

        //private GameEngine.FloatCoords m_missileTileCoords;
        //private GameEngine.IntCoords m_missileWorldCoords;
        //private GameEngine.FloatCoords m_smokeTileCoords;
        //private GameEngine.IntCoords m_smokeWorldCoords;

        //private BoundingShape2D m_boundingShape = null;

        //private Device m_device = null;

        //private Material mat = new Material();

        //private bool m_fired = false;
        //private bool m_destroyed = false;

        //private WorldObject m_target = null;

        //private int m_crashDamage = 30;

        //private float m_xMove = 0.0f;
        //private float m_yMove = 0.0f;
        //private float m_movementSpeed = .1f;
        //private float m_angle = 0.0f;
        //private double m_lengthTraveled = 0.0f;
        //private const float m_range = 7.0f;

        //private int smokeCount = 0;

        //private const float m_missileWidth = 150.0f;
        //private const float m_missileHeight = 200.0f;
        //private const float m_missileAspectRatio = m_missileWidth / m_missileHeight;

        //private const float m_smokeWidth = 150.0f;
        //private const float m_smokeHeight = 200.0f;
        //private const float m_smokeAspectRatio = m_smokeWidth / m_smokeHeight;

        //private const float m_gunLength = .433f;

        //public Missile(Device device, int worldX, int worldY, float tileX, float tileY, float angle)
        //{
        //    m_missileTileCoords.x = tileX;
        //    m_missileTileCoords.y = tileY;

        //    m_missileWorldCoords.x = worldX;
        //    m_missileWorldCoords.y = worldY;

        //    while (m_missileTileCoords.x > .5)
        //    {
        //        m_missileTileCoords.x -= 1;
        //        m_missileWorldCoords.x += 1;
        //    }
        //    while (m_missileTileCoords.x < -.5)
        //    {
        //        m_missileTileCoords.x += 1;
        //        m_missileWorldCoords.x -= 1;
        //    }

        //    while (m_missileTileCoords.y > .5)
        //    {
        //        m_missileTileCoords.y -= 1;
        //        m_missileWorldCoords.y += 1;
        //    }
        //    while (m_missileTileCoords.y < -.5)
        //    {
        //        m_missileTileCoords.y += 1;
        //        m_missileWorldCoords.y -= 1;
        //    }

        //    m_angle = angle;
        //    m_device = device;

        //    mat.Diffuse = Color.White;

        //    List<MathHandler> points = new List<MathHandler>();

        //    points.Add(new MathHandler(-0.02f, 0.05f));
        //    points.Add(new MathHandler(0.02f, 0.05f));
        //    points.Add(new MathHandler(0.02f, -0.05f));
        //    points.Add(new MathHandler(-0.02f, -0.05f));

        //    m_boundingShape = new BoundingShape2D(points);

        //    m_missileSprite = 
        //        new UnanimatedSprite(m_device, (Texture)TextureHandler.GetInstance().GetMissileTextures()[0], 
        //        (float)m_missileWorldCoords.x, (float)m_missileWorldCoords.y, 0.0f);

        //    m_smokeSprite =
        //        new AnimatedSprite(m_device, TextureHandler.GetInstance().GetSmokeTextures(),
        //        (float)m_smokeWorldCoords.x, (float)m_smokeWorldCoords.y, 0.0f, 100);

        //    for (float angleCount = 0.0f; angleCount < m_angle; angleCount++)
        //    {
        //        m_boundingShape.Rotate(1.0f * ((float)Math.PI / 180.0f));
        //    }

        //    MathHandler translation = new MathHandler(worldX + tileX, worldY + tileY);
        //    m_boundingShape.Translate(translation);

        //    m_missileSprite.Rotate(m_angle);
        //}

        //public override ArrayList FireWeapon(string weaponName)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        //public override long GetPointValue()
        //{
        //    return 0;
        //}

        //public override BoundingShape2D GetBoundingShape()
        //{
        //    return m_boundingShape;
        //}

        //public void SetTarget(WorldObject enemy)
        //{
        //    m_target = enemy;
        //}

        //public override int GetCrashDamage()
        //{
        //    return m_crashDamage;
        //}

        //public override void Render()
        //{
        //    if (m_missileSprite != null)
        //    {
        //        Matrix saved = m_device.Transform.World;

        //        m_device.Transform.World =
        //            Matrix.Scaling(new Vector3(m_missileWidth / 1000.0f, m_missileHeight / 1000.0f, 0.0f)) *
        //            Matrix.RotationZ(m_missileSprite.GetFacingAngleInRadians()) *
        //            Matrix.Translation((m_missileWorldCoords.x + m_missileTileCoords.x), (m_missileWorldCoords.y + m_missileTileCoords.y), 0.0f);

        //        m_missileSprite.Render();

        //        m_device.Transform.World =
        //        Matrix.Scaling(new Vector3(m_smokeWidth / 1000.0f, m_smokeHeight / 1000.0f, 0.0f)) *
        //        Matrix.Translation((m_smokeWorldCoords.x + m_smokeTileCoords.x), (m_smokeWorldCoords.y + m_smokeTileCoords.y), 0.0f);

        //        m_smokeSprite.Render();

        //        m_device.Transform.World = saved;
        //    }
        //}


        //public override void Move(float angle)
        //{
        //    if (!m_fired)
        //    {
        //        TrigHandler trig = TrigHandler.GetInstance();

        //        if (m_angle < 0)
        //            m_angle += 360;
        //        if (m_angle > 360)
        //        {
        //            m_angle -= 360;
        //        }
        //        m_xMove = -(float)trig.GetSin(m_angle) * m_movementSpeed;
        //        m_yMove = (float)trig.GetCos(m_angle) * m_movementSpeed;

        //        m_fired = true;
        //    }

        //    m_lengthTraveled += Math.Sqrt((double)(m_xMove * m_xMove) + (m_yMove * m_yMove));

        //    if (m_lengthTraveled <= m_range)
        //    {
        //        MathHandler move = new MathHandler(m_xMove, m_yMove);
        //        m_missileSprite.Move(move);
        //        m_boundingShape.Translate(move);
        //    }
        //    else
        //        this.Destroy();

        //    //reset x if needed
        //    if (m_missileTileCoords.x > 0.5f)
        //    {
        //        m_missileTileCoords.x -= 1.0f;
        //        m_missileWorldCoords.x += 1;
        //    }
        //    else if (m_missileTileCoords.x < -0.5f)
        //    {
        //        m_missileTileCoords.x += 1.0f;
        //        m_missileWorldCoords.x -= 1;
        //    }

        //    //reset y if needed
        //    if (m_missileTileCoords.y > 0.5f)
        //    {
        //        m_missileTileCoords.y -= 1.0f;
        //        m_missileWorldCoords.y += 1;
        //    }
        //    else if (m_missileTileCoords.y < -0.5f)
        //    {
        //        m_missileTileCoords.y += 1.0f;
        //        m_missileWorldCoords.y -= 1;
        //    }

        //    m_missileTileCoords.x += m_xMove;
        //    m_missileTileCoords.y += m_yMove;

        //    if (smokeCount == 5)
        //    {
        //        m_smokeWorldCoords.x = m_missileWorldCoords.x;
        //        m_smokeWorldCoords.y = m_missileWorldCoords.y;
        //        m_smokeTileCoords.x = m_missileTileCoords.x - m_xMove;
        //        m_smokeTileCoords.y = m_missileTileCoords.y - m_yMove;

        //        m_smokeSprite = null;
        //        m_smokeSprite = new AnimatedSprite(m_device, TextureHandler.GetInstance().GetSmokeTextures(),
        //            (float)m_smokeWorldCoords.x, (float)m_smokeWorldCoords.y, 0.0f, 100);
        //        smokeCount = 0;
        //    }

        //    smokeCount++;
        //}

        //public override bool ReduceHealth(float value)
        //{
        //    return false;
        //}

        //public override void Tint(Color color)
        //{
        //    m_missileSprite.SetMaterialColor(color);
        //}

        //public override void Move(String direction, Camera camera)
        //{
        //}

        //public override void Move(WorldObject obj)
        //{
        //}

        //public override void Rotate(String direction) 
        //{
        //}
        //public override void RotateGundam(float angle) 
        //{
        //}
        //public override float GetFacingAngle() 
        //{
        //    float angle = 0.0f;
        //    if (m_missileSprite != null)
        //        angle = m_missileSprite.GetFacingAngle();

        //    return angle;
        //}
        //public override GameEngine.IntCoords GetWorldCoords() 
        //{
        //    return m_missileWorldCoords;
        //}
        //public override GameEngine.FloatCoords GetTileCoords() 
        //{
        //    return m_missileTileCoords;
        //}

        //public override bool IsDestroyed()
        //{
        //    return m_destroyed;
        //}

        //public override bool ReadyToFire()
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        //public override void Destroy()
        //{
        //    if (this.m_missileSprite != null)
        //    {
        //        this.m_missileSprite.Destroy();
        //        this.m_missileSprite = null;
        //        this.m_smokeSprite.Destroy();
        //        this.m_smokeSprite = null;
        //    }

        //    m_destroyed = true;
        //}
    }
}
