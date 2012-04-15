
namespace BadAssTanks
{
    public class Bullet : WorldObject
    {
        //private CustomSprite m_bulletSprite = null;

        //private GameEngine.FloatCoords m_bulletTileCoords;
        //private GameEngine.IntCoords m_bulletWorldCoords;

        //private Device m_device = null;

        //private BoundingShape2D m_boundingShape = null;

        //private bool m_fired = false;
        //private bool m_destroyed = false;

        //private int m_crashDamage = 15;

        //private float m_xMove = 0.0f;
        //private float m_yMove = 0.0f;
        //private float m_angle = 0.0f;
        //private float m_movementSpeed = .09f;
        //private float m_modulation = 0;
        //private double m_lengthTraveled = 0.0f;

        //private float m_bulletHeight = 100.0f;
        //private float m_bulletWidth = 100.0f;

        //private const float m_range = 10.0f;
        //private const float m_gunLength = .433f;

        //public Bullet(Device device, int worldX, int worldY, float tileX, float tileY, float angle)
        //{

        //    m_bulletTileCoords.x = tileX;
        //    m_bulletTileCoords.y = tileY;

        //    m_bulletWorldCoords.x = worldX;
        //    m_bulletWorldCoords.y = worldY;

        //    while (m_bulletTileCoords.x > .5)
        //    {
        //        m_bulletTileCoords.x -= 1;
        //        m_bulletWorldCoords.x += 1;
        //    }
        //    while (m_bulletTileCoords.x < -.5)
        //    {
        //        m_bulletTileCoords.x += 1;
        //        m_bulletWorldCoords.x -= 1;
        //    }

        //    while (m_bulletTileCoords.y > .5)
        //    {
        //        m_bulletTileCoords.y -= 1;
        //        m_bulletWorldCoords.y += 1;
        //    }
        //    while (m_bulletTileCoords.y < -.5)
        //    {
        //        m_bulletTileCoords.y += 1;
        //        m_bulletWorldCoords.y -= 1;
        //    }
        //    m_angle = angle;
        //    m_device = device;

        //    List<MathHandler> points = new List<MathHandler>();

        //    points.Add(new MathHandler(-0.02f, 0.05f));
        //    points.Add(new MathHandler(0.02f, 0.05f));
        //    points.Add(new MathHandler(0.02f, -0.05f));
        //    points.Add(new MathHandler(-0.02f, -0.05f));

        //    m_boundingShape = new BoundingShape2D(points);

        //    m_bulletSprite = 
        //        new UnanimatedSprite(m_device, (Texture)TextureHandler.GetInstance().GetBulletTextures()[0], 
        //        (float)m_bulletWorldCoords.x, (float)m_bulletWorldCoords.y, 0.0f);

        //    for (float angleCount = 0.0f; angleCount < m_angle; angleCount++)
        //    {
        //        m_boundingShape.Rotate(1.0f * ((float)Math.PI / 180.0f));
        //    }

        //    MathHandler translation = new MathHandler(worldX + tileX, worldY + tileY);
        //    m_boundingShape.Translate(translation);
        //    m_bulletSprite.Rotate(m_angle);
        //}

        //public override void Render()
        //{
        //    if (m_bulletSprite != null)
        //    {
        //        Matrix saved = m_device.Transform.World;

        //        m_device.Transform.World =
        //        Matrix.Scaling(new Vector3(m_bulletWidth / 1000.0f, m_bulletHeight / 1000.0f, 0.0f)) *
        //        Matrix.RotationZ(m_bulletSprite.GetFacingAngleInRadians())*
        //        Matrix.Translation((m_bulletWorldCoords.x + m_bulletTileCoords.x), (m_bulletWorldCoords.y + m_bulletTileCoords.y), 0.0f);

        //        m_bulletSprite.Render();


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

        //public override BoundingShape2D GetBoundingShape()
        //{
        //    return m_boundingShape;
        //}

        //public override void Tint(Color color)
        //{
        //}

        //public override bool ReduceHealth(float value)
        //{
        //    return false;
        //}

        //public override ArrayList FireWeapon(string weaponName)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        //public override bool ReadyToFire()
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        //public override void Move(float angle)
        //{
        //    TrigHandler trig = TrigHandler.GetInstance();
        //    if (!m_fired)
        //    {

        //        m_xMove = -(float)trig.GetSin(m_angle) * m_movementSpeed;
        //        m_yMove = (float)trig.GetCos(m_angle) * m_movementSpeed;

        //        m_fired = true;
        //    }

        //    m_lengthTraveled += Math.Sqrt((double)(m_xMove * m_xMove) + (m_yMove * m_yMove));

        //    if (m_lengthTraveled <= m_range)
        //    {
        //        if (m_modulation > 360)
        //            m_modulation = 0;
        //        MathHandler move = new MathHandler(m_xMove, m_yMove);
        //        m_bulletHeight += trig.GetSin(m_modulation) * 20;
        //        m_bulletWidth += trig.GetSin(m_modulation) * 10;
        //        m_modulation += 30;
        //        m_bulletSprite.Move(move);
        //        m_boundingShape.Translate(move);
        //    }
        //    else
        //        this.Destroy();

        //    //reset x if needed
        //    if (m_bulletTileCoords.x > 0.5f)
        //    {
        //        m_bulletTileCoords.x -= 1.0f;
        //        m_bulletWorldCoords.x += 1;
        //    }
        //    else if (m_bulletTileCoords.x < -0.5f)
        //    {
        //        m_bulletTileCoords.x += 1.0f;
        //        m_bulletWorldCoords.x -= 1;
        //    }

        //    //reset y if needed
        //    if (m_bulletTileCoords.y > 0.5f)
        //    {
        //        m_bulletTileCoords.y -= 1.0f;
        //        m_bulletWorldCoords.y += 1;
        //    }
        //    else if (m_bulletTileCoords.y < -0.5f)
        //    {
        //        m_bulletTileCoords.y += 1.0f;
        //        m_bulletWorldCoords.y -= 1;
        //    }

        //    m_bulletTileCoords.x += m_xMove;
        //    m_bulletTileCoords.y += m_yMove;
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
        //    if (m_bulletSprite != null)
        //        angle = m_bulletSprite.GetFacingAngle();

        //    return angle;
        //}
        //public override GameEngine.IntCoords GetWorldCoords() 
        //{
        //    return m_bulletWorldCoords;
        //}
        //public override GameEngine.FloatCoords GetTileCoords() 
        //{
        //    return m_bulletTileCoords;
        //}

        //public override void Destroy()
        //{
        //    if (this.m_bulletSprite != null)
        //    {
        //        this.m_bulletSprite.Destroy();
        //        this.m_bulletSprite = null;
        //    }
        //    m_destroyed = true;
        //}
    }
}
