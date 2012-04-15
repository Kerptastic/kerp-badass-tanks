
namespace BadAssTanks
{
    public class Turret : WorldObject
    {
        //private ArrayList m_turretTextures = null;
        //private ArrayList m_bullets = null;

        //private List<MathHandler> points = null;

        //private CustomSprite m_turretSprite = null;

        //private Device m_device = null;

        //private WeaponFactory m_weaponFactory = null;

        //private GameEngine.FloatCoords m_turretTileCoords;
        //private GameEngine.IntCoords m_turretWorldCoords;

        //private float m_health = 50.0f;

        //private BoundingShape2D m_boundingShape = null;

        //private int m_fireRate;
        //private bool m_readyToFire = false;

        //private float m_startXCoord = 0.5f;
        //private float m_startYCoord = 0.5f;

        //private float m_turnSpeed = 4.0f;

        //private bool m_destroyed = false;

        //private const float m_turretWidth = 800.0f;
        //private const float m_turretHeight = 800.0f;
        //private const float m_turretAspectRatio = m_turretWidth / m_turretHeight;

        //private const int m_crashDamage = 30;
        //private const long m_pointValue = 750;

        ///// <summary>
        ///// Constructor for the robot.
        ///// </summary>
        ///// <param name="device"> Direct3D device. </param>
        //public Turret(Device device, int worldTileStartX, int worldTileStartY)
        //{
        //    m_device = device;

        //    m_turretTileCoords.x = m_startXCoord;
        //    m_turretTileCoords.y = m_startYCoord;

        //    m_turretWorldCoords.x = worldTileStartX;
        //    m_turretWorldCoords.y = worldTileStartY;

        //    m_turretTextures = TextureHandler.GetInstance().GetTurretTextures();

        //    m_bullets = new ArrayList();

        //    m_weaponFactory = new WeaponFactory(m_device);

        //    points = new List<MathHandler>();

        //    points.Add(new MathHandler((m_turretWidth-300) / 1000.0f, (m_turretHeight-300) / 1000.0f));
        //    points.Add(new MathHandler((m_turretWidth-300) / 1000.0f, (-m_turretHeight+300) / 1000.0f));
        //    points.Add(new MathHandler((-m_turretWidth+300) / 1000.0f, (-m_turretHeight+300) / 1000.0f));
        //    points.Add(new MathHandler((-m_turretWidth+300) / 1000.0f, (m_turretHeight-300) / 1000.0f));

        //    m_boundingShape = new BoundingShape2D(points);

        //    m_boundingShape.Translate(new MathHandler((float)m_turretWorldCoords.x + 0.5f, (float)m_turretWorldCoords.y + 0.5f));

        //    m_turretSprite =
        //        new UnanimatedSprite(m_device, ((Texture)m_turretTextures[0]), (float)m_turretWorldCoords.x, (float)m_turretWorldCoords.y, 0.0f);
        //}

        ///// <summary>
        ///// Move the robot either up or down 1 unit (designated by movement speed).
        ///// </summary>
        ///// <param name="direction"> Either "UP" or "DOWN". </param>
        //public override void Move(String direction, Camera camera)
        //{
        //}

        ///// <summary>
        ///// Retrieve the robots world tile location.
        ///// </summary>
        ///// <returns></returns>
        //public override GameEngine.IntCoords GetWorldCoords()
        //{
        //    return m_turretWorldCoords;
        //}

        ///// <summary>
        ///// Retrieve the robots location within a tile.
        ///// </summary>
        ///// <returns></returns>
        //public override GameEngine.FloatCoords GetTileCoords()
        //{
        //    return m_turretTileCoords;
        //}

        //public override int GetCrashDamage()
        //{
        //    return m_crashDamage;
        //}
        //public override ArrayList FireWeapon(string weaponName)
        //{
        //    ArrayList tempList = new ArrayList();
        //    tempList.Add(m_weaponFactory.CreateWeapon(weaponName, m_turretWorldCoords.x, m_turretWorldCoords.y,
        //            m_turretTileCoords.x + this.GetTurretOffsetCoords().x, m_turretTileCoords.y + this.GetTurretOffsetCoords().y, m_turretSprite.GetFacingAngle()));

        //    return tempList;
        //}
        ///// <summary>
        ///// Rotate the robot in the desired direction.
        ///// </summary>
        ///// <param name="direction"> Either "LEFT" or "RIGHT". </param>
        //public override void Rotate(String direction)
        //{
        //    if (direction.Equals("LEFT"))
        //    {
        //        m_turretSprite.Rotate(m_turnSpeed);
        //    }
        //    else if (direction.Equals("RIGHT"))
        //    {
        //        m_turretSprite.Rotate(-m_turnSpeed);
        //    }
        //}

        ///// <summary>
        ///// Rotate the turret and the gun a particular angle.
        ///// </summary>
        ///// <param name="angle"></param>
        //public override void RotateGundam(float angle)
        //{
        //    m_turretSprite.SetFacingAngle(angle);
        //}

        ///// <summary>
        ///// Render the robot within the game world.
        ///// </summary>
        //public override void Render()
        //{
        //    Matrix saved = m_device.Transform.World;

        //    m_device.Transform.World =
        //        Matrix.Scaling(new Vector3(m_turretWidth / 1000.0f, m_turretHeight / 1000.0f, 0.0f)) *
        //        Matrix.RotationZ(m_turretSprite.GetFacingAngleInRadians()) *
        //        Matrix.Translation((m_turretWorldCoords.x + m_turretTileCoords.x), (m_turretWorldCoords.y + m_turretTileCoords.y), 0.0f);

        //    m_turretSprite.Render();

        //    m_device.Transform.World = saved;
        //}

        //public override long GetPointValue()
        //{
        //    return m_pointValue;
        //}

        //public override BoundingShape2D GetBoundingShape()
        //{
        //    return m_boundingShape;
        //}

        //public override void Tint(Color color)
        //{
        //     m_turretSprite.SetMaterialColor(color);
        //}

        //public override bool ReduceHealth(float value)
        //{
        //    m_health -= value;

        //    if (m_health <= 0)
        //        return true;
        //    else
        //        return false;
        //}

        ///// <summary>
        ///// Retrieve the x position of the sprite.
        ///// </summary>
        ///// <returns></returns>
        //public float GetXPos()
        //{
        //    return m_turretSprite.GetXPos();
        //}

        ///// <summary>
        ///// Retrieve the y position of the robots sprite.
        ///// </summary>
        ///// <returns></returns>
        //public float GetYPos()
        //{
        //    return m_turretSprite.GetYPos();
        //}

        ///// <summary>
        ///// Retrieve the facing angle of the robots sprite.
        ///// </summary>
        ///// <returns></returns>
        //public override float GetFacingAngle()
        //{
        //    return m_turretSprite.GetFacingAngle();
        //}

        //public float GetGundamFacingAngle()
        //{
        //    return m_turretSprite.GetFacingAngle();
        //}

        //private GameEngine.FloatCoords GetTurretOffsetCoords()
        //{
        //    float angle = GetGundamFacingAngle();

        //    if (angle < 0)
        //        angle += 360;
        //    GameEngine.FloatCoords offsetCoords;
        //    float hyp = (m_turretHeight + 250) / 1000.0f;

        //    TrigHandler trig = TrigHandler.GetInstance();

        //    offsetCoords.y = trig.GetCos(angle) * hyp;
        //    offsetCoords.x = -trig.GetSin(angle) * hyp;

        //    return offsetCoords;


        //}

        ///// <summary>
        ///// Retrieve the facing angle of the robots sprite in radians.
        ///// </summary>
        ///// <returns></returns>
        //public float GetFacingAngleInRadians()
        //{
        //    return m_turretSprite.GetFacingAngleInRadians();
        //}

        //public WorldObject FireWeapon()
        //{

        //    //return m_weaponFactory.CreateWeapon("BULLET", m_robotWorldCoords.x, m_robotWorldCoords.y,
        //    //    m_robotTileCoords.x, m_robotTileCoords.y); 

        //    return m_weaponFactory.CreateWeapon("MISSILE", m_turretWorldCoords.x, m_turretWorldCoords.y,
        //         m_turretTileCoords.x + this.GetTurretOffsetCoords().x, m_turretTileCoords.y + this.GetTurretOffsetCoords().y, m_turretSprite.GetFacingAngle());
        //}

        //public override void Move(float angle)
        //{

        //}

        //public override void Move(WorldObject obj)
        //{
        //    int xdif = this.GetWorldCoords().x - obj.GetWorldCoords().x;
        //    int ydif = this.GetWorldCoords().y - obj.GetWorldCoords().y;
        //    double hyp = Math.Sqrt((xdif * xdif) + (ydif * ydif));
        //    int tempAngle = (int)this.GetFacingAngle();
        //    int angle = (int)(Math.Sin(xdif / hyp) * (180.0f / Math.PI));

        //    m_fireRate++;

        //    if (m_fireRate == 150)
        //    {
        //        m_readyToFire = true;
        //        m_fireRate = 0;
        //    }
        //    else
        //        m_readyToFire = false;

        //    if (xdif != 0 && ydif != 0)
        //    {
        //        //Main tank is below and to the left
        //        if (xdif > 0 && ydif > 0)
        //        {
        //            angle = 180 - angle;
        //            if (tempAngle != angle)
        //            {
        //                if (tempAngle <= angle)
        //                    this.Rotate("LEFT");
        //                else
        //                    this.Rotate("RIGHT");
        //            }
        //            //RotateGundam((float)angle);
        //        }


        //        //Main tank is below and to the right
        //        if (xdif < 0 && ydif > 0)
        //        {
        //            angle = 180 + (-angle);
        //            if (tempAngle != angle)
        //            {
        //                if (tempAngle <= angle)
        //                    this.Rotate("LEFT");
        //                else
        //                    this.Rotate("RIGHT");
        //            }

        //            //RotateGundam((float)angle);
        //        }

        //        //Main tank is above and to the left
        //        if (xdif > 0 && ydif < 0)
        //        {
        //            if (tempAngle != angle)
        //            {
        //                if (tempAngle < angle)
        //                    this.Rotate("LEFT");
        //                else
        //                    this.Rotate("RIGHT");
        //            }

        //            //RotateGundam((float)angle);
        //        }

        //        //Main tank is above and to the right
        //        if (xdif < 0 && ydif < 0)
        //        {
        //            angle = 360 + angle;
        //            if (tempAngle == 0)
        //                tempAngle = 360;
        //            if (tempAngle <= angle)
        //                this.Rotate("LEFT");
        //            else
        //                this.Rotate("RIGHT");

        //            //RotateGundam((float)angle);
        //        }
        //    }
        //    else
        //    {
        //        if (xdif < 0 && ydif == 0)
        //        {
        //            angle = 270;
        //            if (tempAngle != angle)
        //            {
        //                if (tempAngle < 90 || tempAngle > 270)
        //                    this.Rotate("RIGHT");
        //                else
        //                    this.Rotate("LEFT");
        //            }

        //            //RotateGundam((float)angle);
        //        }
        //        if (xdif > 0 && ydif == 0)
        //        {
        //            angle = 90;
        //            if (tempAngle != angle)
        //            {
        //                if (tempAngle < 90 || tempAngle > 270)
        //                    this.Rotate("LEFT");
        //                else
        //                    this.Rotate("RIGHT");
        //            }

        //            //RotateGundam((float)angle);
        //        }
        //        if (xdif == 0 && ydif < 0)
        //        {
        //            angle = 0;
        //            if (tempAngle != angle)
        //            {
        //                if (tempAngle < 180)
        //                    this.Rotate("RIGHT");
        //                else
        //                    this.Rotate("LEFT");
        //            }
        //            //RotateGundam((float)angle);
        //        }
        //        if (xdif == 0 && ydif > 0)
        //        {
        //            angle = 180;
        //            if (tempAngle != angle)
        //            {
        //                if (tempAngle < 180)
        //                    this.Rotate("LEFT");
        //                else
        //                    this.Rotate("RIGHT");
        //            }
        //            //RotateGundam((float)angle);
        //        }
        //    }
        //}

        //public override bool IsDestroyed()
        //{
        //    return m_destroyed;
        //}
        //public override bool ReadyToFire()
        //{
        //    return m_readyToFire;
        //}
        //public override void Destroy()
        //{
        //    //null the rest of this stuff out in this object

        //    //m_boundShape = null;
        //    m_destroyed = true;
        //}
    }
}
