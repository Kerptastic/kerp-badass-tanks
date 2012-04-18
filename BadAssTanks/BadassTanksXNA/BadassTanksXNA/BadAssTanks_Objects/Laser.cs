
namespace BadAssTanks
{
    public class Laser// : GameObject2D
    {        
        //private CustomSprite m_laserStartSprite = null;
        //private CustomSprite m_laserSprite = null;
        //private GameEngine.FloatCoords m_laserTileCoords;
        //private GameEngine.IntCoords m_laserWorldCoords;
        //private GameEngine.FloatCoords m_laserStartTileCoords;
        //private GameEngine.IntCoords m_laserStartWorldCoords;

        //private Device m_device = null;

        //private bool m_destroyed = false;

        //private float m_xMove = 0.0f;
        //private float m_yMove = 0.0f;
        //private float m_angle = 0.0f;
        //private float m_modulation = 0;

        //private float m_laserHeight = 50.0f;
        //private float m_laserWidth = 30.0f;

        //private float m_laserStartHeight = 700.0f;
        //private float m_laserStartWidth = 700.0f;

        //private BoundingShape2D m_boundingShape = null;

        //private const float m_range = 7.0f;
        //private const float m_gunLength = .433f;

        //private const int m_crashDamage = 100;

        //public Laser(Device device, int worldX, int worldY, float tileX, float tileY, float angle)
        //{

        //    m_laserTileCoords.x = tileX;
        //    m_laserTileCoords.y = tileY;

        //    m_laserWorldCoords.x = worldX-3;
        //    m_laserWorldCoords.y = worldY;

        //    while (m_laserTileCoords.x > .5)
        //    {
        //        m_laserTileCoords.x -= 1;
        //        m_laserWorldCoords.x += 1;
        //    }
        //    while (m_laserTileCoords.x < -.5)
        //    {
        //        m_laserTileCoords.x += 1;
        //        m_laserWorldCoords.x -= 1;
        //    }

        //    while (m_laserTileCoords.y > .5)
        //    {
        //        m_laserTileCoords.y -= 1;
        //        m_laserWorldCoords.y += 1;
        //    }
        //    while (m_laserTileCoords.y < -.5)
        //    {
        //        m_laserTileCoords.y += 1;
        //        m_laserWorldCoords.y -= 1;
        //    }
        //    m_angle = angle;
        //    m_device = device;

        //    m_laserStartTileCoords.x = m_laserTileCoords.x;
        //    m_laserStartTileCoords.y = m_laserTileCoords.y;

        //    m_laserStartWorldCoords.x = m_laserWorldCoords.x;
        //    m_laserStartWorldCoords.y = m_laserWorldCoords.y;

        //    List<MathHandler> points = new List<MathHandler>();

        //    points.Add(new MathHandler(-1.0f, 4.5f));
        //    points.Add(new MathHandler(1.0f, 4.5f));
        //    points.Add(new MathHandler(1.0f, -4.5f));
        //    points.Add(new MathHandler(-1.0f, -4.5f));

        //    m_boundingShape = new BoundingShape2D(points);

        //    m_laserStartSprite = 
        //        new UnanimatedSprite(m_device, (Texture)TextureHandler.GetInstance().GetLaserTextures()[0], 
        //        (float)m_laserStartWorldCoords.x, (float)m_laserStartWorldCoords.y, 0.0f);

        //    m_laserSprite =
        //        new UnanimatedSprite(m_device, (Texture)TextureHandler.GetInstance().GetLaserTextures()[1],
        //        (float)m_laserWorldCoords.x, (float)m_laserWorldCoords.y, 0.0f);

        //    m_laserSprite.Rotate(m_angle);
        //    m_boundingShape.Translate(new MathHandler(((float)(m_laserWorldCoords.x + m_laserTileCoords.x)), ((float)(m_laserWorldCoords.y + m_laserTileCoords.y))));

        //    for(int index = 0; index < m_angle; index++)
        //        m_boundingShape.Rotate(1.0f * ((float)Math.PI / 180.0f));
        //}

        //public override void Render()
        //{
        //    if (m_laserSprite != null)
        //    {
        //        Matrix saved = m_device.Transform.World;
                
        //        m_device.Transform.World =
        //            Matrix.Scaling(new Vector3(m_laserStartWidth / 1000.0f, m_laserStartHeight / 1000.0f, 0.0f)) *
        //            Matrix.Translation((m_laserWorldCoords.x + m_laserTileCoords.x), (m_laserWorldCoords.y + m_laserTileCoords.y), 0.0f);

        //        m_laserStartSprite.Render();

        //        m_device.Transform.World =
        //            Matrix.Scaling(new Vector3(m_laserWidth / 1000.0f, m_laserHeight / 1000.0f, 0.0f)) *
        //            Matrix.RotationZ(m_laserSprite.GetFacingAngleInRadians())*
        //            Matrix.Translation((m_laserWorldCoords.x + m_laserTileCoords.x), (m_laserWorldCoords.y + m_laserTileCoords.y), 0.0f);

        //        m_laserSprite.Render();

        //        m_device.Transform.World = saved;
        //    }
        //}

        //public override long GetPointValue()
        //{
        //    return 0;
        //}

        //public override int GetCrashDamage()
        //{
        //    return m_crashDamage;
        //}

        //public override bool IsDestroyed()
        //{
        //    return m_destroyed;
        //}

        //public override ArrayList FireWeapon(string weaponName)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        //public override bool ReadyToFire()
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        //public override BoundingShape2D GetBoundingShape()
        //{
        //    return m_boundingShape;
        //}

        //public override void Move(float angle)
        //{
        //    TrigHandler trig = TrigHandler.GetInstance();
            
        //    if (m_modulation >= 360)
        //    {
        //        m_modulation = 0;
        //    }

        //    m_xMove = trig.GetSin((float)m_modulation) / 2;
        //    m_yMove = trig.GetCos((float)m_modulation);


        //    MathHandler move = new MathHandler(m_xMove, m_yMove);

        //    m_laserHeight += trig.GetSin((float)m_modulation) * 700;
            
        //    if (m_laserWidth < 300.0)
        //    {
        //        m_laserWidth += 40;
        //    }
            
        //    m_modulation += 10;
        //    m_laserSprite.Move(move);
        //    m_laserStartSprite.Move(move);
        //    m_boundingShape.Translate(move);

        //    m_laserSprite.Rotate(25.0f);
        //    for (int index = 0; index < 25.0f; index++)
        //        m_boundingShape.Rotate(1.0f * ((float)Math.PI / 180.0f));
        
        //    //reset x if needed
        //    if (m_laserTileCoords.x > 0.5f)
        //    {
        //        m_laserTileCoords.x -= 1.0f;
        //        m_laserWorldCoords.x += 1;
        //    }
        //    else if (m_laserTileCoords.x < -0.5f)
        //    {
        //        m_laserTileCoords.x += 1.0f;
        //        m_laserWorldCoords.x -= 1;
        //    }

        //    //reset y if needed
        //    if (m_laserTileCoords.y > 0.5f)
        //    {
        //        m_laserTileCoords.y -= 1.0f;
        //        m_laserWorldCoords.y += 1;
        //    }
        //    else if (m_laserTileCoords.y < -0.5f)
        //    {
        //        m_laserTileCoords.y += 1.0f;
        //        m_laserWorldCoords.y -= 1;
        //    }

        //    m_laserTileCoords.x += m_xMove;
        //    m_laserTileCoords.y += m_yMove;
        //}

        //public override bool ReduceHealth(float value)
        //{
        //    return false;
        //}

        //public override void Tint(Color color)
        //{
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

        //    if (m_laserSprite != null)
        //        angle = m_laserSprite.GetFacingAngle();

        //    return angle;
        //}
        //public override GameEngine.IntCoords GetWorldCoords() 
        //{
        //    return m_laserWorldCoords;
        //}
        //public override GameEngine.FloatCoords GetTileCoords() 
        //{
        //    return m_laserTileCoords;
        //}

        //public override void Destroy()
        //{
        //    if (this.m_laserSprite != null)
        //    {
        //        this.m_laserSprite.Destroy();
        //        this.m_laserSprite = null;
        //        this.m_laserStartSprite.Destroy();
        //        this.m_laserStartSprite = null;
        //    }
        //    m_destroyed = true;
        //}
    }
}
