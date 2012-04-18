
namespace BadAssTanks
{
    public class RoboWalker// : GameObject2D
    {
        //private ArrayList m_robotTextures = null;
        //private ArrayList m_robotUnpassableWorldCoords = null;
        //private ArrayList m_bullets = null;

        //private CustomSprite m_baseSprite = null;
        //private CustomSprite m_headSprite = null;

        //private Device m_device = null;

        //private WeaponFactory m_weaponFactory = null;

        //private GameEngine.FloatCoords m_robotTileCoords;
        //private GameEngine.IntCoords m_robotWorldCoords;

        //private BoundingShape2D m_boundingShape = null;

        //private float m_startXCoord = 0.0f;
        //private float m_startYCoord = 0.0f;

        //private float m_health = 50.0f;

        //private int m_fireRate = 0;
        //private bool m_readyToFire = false;
        //private bool m_destroyed = false;
        //private const float m_movementSpeed = 0.008f;
        //private const float m_turnSpeed = 1.0f;

        //private const float m_baseWidth = 400.0f;
        //private const float m_baseHeight = 300.0f;
        //private const float m_baseAspectRatio = m_baseWidth / m_baseHeight;

        //private const float m_headWidth = 250.0f;
        //private const float m_headHeight = 250.0f;
        //private const float m_headAspectRatio = m_headWidth / m_headHeight;

        //private const int headIndex = 3;

        //private const int m_crashDamage = 20;
        //private const long m_pointValue = 600;

        ///// <summary>
        ///// Constructor for the robot.
        ///// </summary>
        ///// <param name="device"> Direct3D device. </param>
        //public RoboWalker(Device device, int worldTileStartX, int worldTileStartY)
        //{
        //    m_device = device;

        //    m_robotTileCoords.x = m_startXCoord;
        //    m_robotTileCoords.y = m_startYCoord;

        //    m_robotWorldCoords.x = worldTileStartX;
        //    m_robotWorldCoords.y = worldTileStartY;

        //    m_robotTextures = TextureHandler.GetInstance().GetRobotTextures();

        //    m_robotUnpassableWorldCoords = new ArrayList();
        //    m_bullets = new ArrayList();

        //    m_weaponFactory = new WeaponFactory(m_device);

        //    List<MathHandler> points = new List<MathHandler>();

        //    points.Add(new MathHandler(-m_baseWidth / 1000.0f, m_baseHeight / 1000.0f));
        //    points.Add(new MathHandler(m_baseWidth / 1000.0f, m_baseHeight / 1000.0f));
        //    points.Add(new MathHandler(m_baseWidth / 1000.0f, -m_baseHeight / 1000.0f));
        //    points.Add(new MathHandler(-m_baseWidth / 1000.0f, -m_baseHeight / 1000.0f));

        //    m_boundingShape = new BoundingShape2D(points);

        //    m_boundingShape.Translate(new MathHandler((float)m_robotWorldCoords.x, (float)m_robotWorldCoords.y));

        //    m_baseSprite =
        //        new AnimatedSprite(m_device, m_robotTextures, (float)m_robotWorldCoords.x, (float)m_robotWorldCoords.y, 0.0f, 400);

        //    m_baseSprite.Rotate(180.0f);

        //    m_headSprite =
        //        new UnanimatedSprite(m_device, ((Texture)TextureHandler.GetInstance().GetRobotHeadTextures()[0]),
        //        (float)m_robotWorldCoords.x, (float)m_robotWorldCoords.y, 0.0f);
        //}

        ///// <summary>
        ///// Move the robot either up or down 1 unit (designated by movement speed).
        ///// </summary>
        ///// <param name="direction"> Either "UP" or "DOWN". </param>
        //public override void Move(String direction, Camera camera)
        //{
        //    float angle = this.GetFacingAngle();
        //    float xMove = 0.0f;
        //    float yMove = 0.0f;

        //    TrigHandler trig = TrigHandler.GetInstance();

        //    //grab the x and y move for the robot within the tiles
        //    if (direction.Equals("UP"))
        //    {
        //        xMove = -(float)trig.GetSin(angle) * m_movementSpeed;
        //        yMove = (float)trig.GetCos(angle) * m_movementSpeed;
        //        //checkPointX
        //    }
        //    else if (direction.Equals("DOWN"))
        //    {
        //        xMove = (float)trig.GetSin(angle) * m_movementSpeed;
        //        yMove = -(float)trig.GetCos(angle) * m_movementSpeed;
        //    }

        //    //check for unpassable Tiles
        //    //do not go past the left tile boundary
        //    if (m_robotUnpassableWorldCoords.Contains(new Point(m_robotWorldCoords.x + 1, m_robotWorldCoords.y)))
        //    {
        //        float tempNewX = m_robotTileCoords.x + xMove;
        //        if (tempNewX > 0.5f - .5f)
        //        {
        //            if (xMove > 0.0f)
        //                xMove = 0.0f;
        //        }
        //    }
        //    //do not go past the right tile boundary
        //    if (m_robotUnpassableWorldCoords.Contains(new Point(m_robotWorldCoords.x - 1, m_robotWorldCoords.y)))
        //    {
        //        float tempNewX = m_robotTileCoords.x + xMove;
        //        if (tempNewX < 0.0f)
        //        {
        //            if (xMove < 0.0f)
        //                xMove = 0.0f;
        //        }
        //    }
        //    //do not go past the lower tile boundary
        //    if (m_robotUnpassableWorldCoords.Contains(new Point(m_robotWorldCoords.x, m_robotWorldCoords.y + 1)))
        //    {
        //        float tempNewY = m_robotTileCoords.y + yMove;
        //        if (tempNewY > 0.0f)
        //        {
        //            if (yMove > 0.0f)
        //                yMove = 0.0f;
        //        }
        //    }
        //    //do not go past the upper tile boundary
        //    if (m_robotUnpassableWorldCoords.Contains(new Point(m_robotWorldCoords.x, m_robotWorldCoords.y - 1)))
        //    {
        //        float tempNewY = m_robotTileCoords.y + yMove;
        //        if (tempNewY < 0.0f)
        //        {
        //            if (yMove < 0.0f)
        //                yMove = 0.0f;
        //        }
        //    }

        //    //do not go past the left world boundary
        //    if (m_robotWorldCoords.x == 0)
        //    {
        //        float tempNewX = m_robotTileCoords.x + xMove;

        //        if (tempNewX < -0.5f)
        //        {
        //            if (xMove < 0.0f)
        //                xMove = 0.0f;
        //        }
        //    }

        //    //do not go past the right world boundary
        //    else if (m_robotWorldCoords.x == GameWorld.m_worldWidth - 1)
        //    {
        //        float tempNewX = m_robotTileCoords.x + xMove;

        //        if (tempNewX > 0.5f)
        //        {
        //            if (xMove > 0.0f)
        //                xMove = 0.0f;
        //        }
        //    }

        //    //do not go past the lower world boundary
        //    if (m_robotWorldCoords.y == 0)
        //    {
        //        float tempNewY = m_robotTileCoords.y + yMove;

        //        if (tempNewY < -0.5)
        //        {
        //            if (yMove < 0.0f)
        //                yMove = 0.0f;
        //        }
        //    }

        //    //do not go past the upper world boundary
        //    else if (m_robotWorldCoords.y == GameWorld.m_worldHeight - 1)
        //    {
        //        float tempNewY = m_robotTileCoords.y + yMove;

        //        if (tempNewY > 0.5f)
        //        {
        //            if (yMove > 0.0f)
        //                yMove = 0.0f;
        //        }
        //    }

        //    //move the robot and the camera

        //    MathHandler move = new MathHandler(xMove, yMove);

        //    m_baseSprite.Move(move);
        //    m_headSprite.Move(move);

        //    m_boundingShape.Translate(move);

        //    if (camera != null)
        //    {
        //        camera.Move(xMove, yMove);
        //    }

        //    //update the robots tracking of itself in a tile
        //    m_robotTileCoords.x += xMove;
        //    m_robotTileCoords.y += yMove;

        //    //set the new robot position if moving tiles

        //    //reset x if needed
        //    if (m_robotTileCoords.x > 0.5f)
        //    {
        //        m_robotTileCoords.x -= 1.0f;
        //        m_robotWorldCoords.x += 1;
        //    }
        //    else if (m_robotTileCoords.x < -0.5f)
        //    {
        //        m_robotTileCoords.x += 1.0f;
        //        m_robotWorldCoords.x -= 1;
        //    }

        //    //reset y if needed
        //    if (m_robotTileCoords.y > 0.5f)
        //    {
        //        m_robotTileCoords.y -= 1.0f;
        //        m_robotWorldCoords.y += 1;
        //    }
        //    else if (m_robotTileCoords.y < -0.5f)
        //    {
        //        m_robotTileCoords.y += 1.0f;
        //        m_robotWorldCoords.y -= 1;
        //    }

        //}

        //public override long GetPointValue()
        //{
        //    return m_pointValue;
        //}

        //public override int GetCrashDamage()
        //{
        //    return m_crashDamage;
        //}

        //public override bool IsDestroyed()
        //{
        //    return m_destroyed;
        //}

        //public override bool ReadyToFire()
        //{
        //    return m_readyToFire;
        //}
        ///// <summary>
        ///// Set the x and y coordinates of the robot within an individual tile.
        ///// </summary>
        ///// <param name="xCoord"> The robots x coordinate in the tile. </param>
        ///// <param name="yCoord"> The robots y coordinate in the tile. </param>

        //public void SetUnpassableCoords(int xCoord, int yCoord)
        //{
        //    Point tempCoords = new Point(xCoord, yCoord);

        //    m_robotUnpassableWorldCoords.Add(tempCoords);
        //}

        //public override ArrayList FireWeapon(string weaponName)
        //{
        //    ArrayList tempList = new ArrayList();
        //    tempList.Add(m_weaponFactory.CreateWeapon(weaponName, m_robotWorldCoords.x, m_robotWorldCoords.y,
        //            m_robotTileCoords.x + this.GetTurretOffsetCoords().x, m_robotTileCoords.y + this.GetTurretOffsetCoords().y, m_headSprite.GetFacingAngle()));

        //    return tempList;
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
        ///// Retrieve the robots world tile location.
        ///// </summary>
        ///// <returns></returns>
        //public override GameEngine.IntCoords GetWorldCoords()
        //{
        //    return m_robotWorldCoords;
        //}

        ///// <summary>
        ///// Retrieve the robots location within a tile.
        ///// </summary>
        ///// <returns></returns>
        //public override GameEngine.FloatCoords GetTileCoords()
        //{
        //    return m_robotTileCoords;
        //}

        ///// <summary>
        ///// Rotate the robot in the desired direction.
        ///// </summary>
        ///// <param name="direction"> Either "LEFT" or "RIGHT". </param>
        //public override void Rotate(String direction)
        //{
        //    if (direction.Equals("LEFT"))
        //    {
        //        m_baseSprite.Rotate(m_turnSpeed);
        //        m_boundingShape.Rotate(1.0f * ((float)Math.PI / 180.0f));
        //    }
        //    else if (direction.Equals("RIGHT"))
        //    {
        //        m_baseSprite.Rotate(-m_turnSpeed);
        //        m_boundingShape.Rotate(-1.0f * ((float)Math.PI / 180.0f));
        //    }
        //}

        ///// <summary>
        ///// Rotate the turret and the gun a particular angle.
        ///// </summary>
        ///// <param name="angle"></param>
        //public override void RotateGundam(float angle)
        //{
        //    Random rand = new Random((int)GameTimer.timeGetTime());
        //    m_headSprite.SetFacingAngle(angle+rand.Next(-20,20));
        //}

        //public override void Tint(Color color)
        //{
        //    m_baseSprite.SetMaterialColor(color);
        //    m_headSprite.SetMaterialColor(color);
        //}

        ///// <summary>
        ///// Render the robot within the game world.
        ///// </summary>
        //public override void Render()
        //{
        //    Matrix saved = m_device.Transform.World;

        //    m_device.Transform.World =
        //        Matrix.Scaling(new Vector3(m_baseWidth / 1000.0f, m_baseHeight / 1000.0f, 0.0f)) *
        //        Matrix.RotationZ(m_baseSprite.GetFacingAngleInRadians()) *
        //        Matrix.Translation(m_baseSprite.GetXPos(), m_baseSprite.GetYPos(), 0.0f);

        //    m_baseSprite.Render();

        //    m_device.Transform.World =
        //        Matrix.Scaling(new Vector3(m_headWidth / 1000.0f, m_headHeight / 1000.0f, 0.0f))*
        //        Matrix.RotationZ(m_headSprite.GetFacingAngleInRadians()) *
        //        Matrix.Translation(m_headSprite.GetXPos(), m_headSprite.GetYPos(), 0.0f);

        //    m_headSprite.Render();

        //    m_device.Transform.World = saved;
        //}

        //public override BoundingShape2D GetBoundingShape()
        //{
        //    return m_boundingShape;
        //}

        ///// <summary>
        ///// Retrieve the x position of the sprite.
        ///// </summary>
        ///// <returns></returns>
        //public float GetXPos()
        //{
        //    return m_baseSprite.GetXPos();
        //}

        ///// <summary>
        ///// Retrieve the y position of the robots sprite.
        ///// </summary>
        ///// <returns></returns>
        //public float GetYPos()
        //{
        //    return m_baseSprite.GetYPos();
        //}

        ///// <summary>
        ///// Retrieve the facing angle of the robots sprite.
        ///// </summary>
        ///// <returns></returns>
        //public override float GetFacingAngle()
        //{
        //    return m_baseSprite.GetFacingAngle();
        //}

        //public float GetGundamFacingAngle()
        //{
        //    return m_headSprite.GetFacingAngle();
        //}

        //private GameEngine.FloatCoords GetTurretOffsetCoords()
        //{
        //    float angle = GetGundamFacingAngle();

        //    if (angle < 0)
        //        angle += 360;
        //    GameEngine.FloatCoords offsetCoords;
        //    float hyp = (m_headHeight + 250) / 1000.0f;

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
        //    return m_baseSprite.GetFacingAngleInRadians();
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

        //    if (m_fireRate == 160)
        //    {
        //        m_readyToFire = true;
        //        m_fireRate = 0;
        //    }
        //    else
        //        m_readyToFire = false;

        //    if (xdif != 0 && ydif != 0)
        //    {
        //        //Main robot is below and to the left
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
        //            RotateGundam((float)angle);
        //        }
        //        //Main robot is below and to the right
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

        //            RotateGundam((float)angle);
        //        }

        //        //Main robot is above and to the left
        //        if (xdif > 0 && ydif < 0)
        //        {
        //            if (tempAngle != angle)
        //            {
        //                if (tempAngle < angle)
        //                    this.Rotate("LEFT");
        //                else
        //                    this.Rotate("RIGHT");
        //            }

        //            RotateGundam((float)angle);
        //        }

        //        //Main robot is above and to the right
        //        if (xdif < 0 && ydif < 0)
        //        {
        //            angle = 360 + angle;
        //            if (tempAngle == 0)
        //                tempAngle = 360;
        //            if (tempAngle <= angle)
        //                this.Rotate("LEFT");
        //            else
        //                this.Rotate("RIGHT");

        //            RotateGundam((float)angle);
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

        //            RotateGundam((float)angle);
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

        //            RotateGundam((float)angle);
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
        //            RotateGundam((float)angle);
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
        //            RotateGundam((float)angle);
        //        }
        //    }
        //    this.Move("UP", null);
        //}

        //public override void Destroy()
        //{
        //    if (m_baseSprite != null)
        //    {
        //        m_baseSprite.Destroy();
        //        m_headSprite.Destroy();
        //        m_baseSprite = null;
        //        m_headSprite = null;
        //    }

        //    m_destroyed = true;
        //}
    }
}
