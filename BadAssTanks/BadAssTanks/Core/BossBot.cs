using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BadAssTanks
{
    public class BossBot : WorldObject
    {
        //private ArrayList m_robotTextures = null;
        //private ArrayList m_turretTextures = null;
        //private ArrayList m_bullets = null;

        //private CustomSprite m_baseSprite = null;
        //private CustomSprite m_headSprite = null;
        //private CustomSprite m_leftShoulderTurret = null;
        //private CustomSprite m_rightShoulderTurret = null;

        //private Device m_device = null;

        //private WeaponFactory m_weaponFactory = null;

        //private GameEngine.FloatCoords m_robotTileCoords;
        //private GameEngine.IntCoords m_robotWorldCoords;

        //private BoundingShape2D m_boundingShape = null;
        //private BoundingShape2D m_leftTurretShape = null;
        //private BoundingShape2D m_rightTurretShape = null;

        //private float m_startXCoord = 0.0f;
        //private float m_startYCoord = 0.0f;

        //private float m_health = 1500.0f;
        //private float m_leftTurretHealth = 500.0f;
        //private float m_rightTurretHealth = 500.0f;

        //float xChange = -0.05f;
        //float yChange = 0.0f;

        //private int m_turretFireRate = 0;
        //private int m_fireRate = 0;
        //private int m_spawnRate = 0;
        //private bool m_readyToFire = false;
        //private bool m_turretsReadyToFire = false;
        //private bool m_readyToSpawn = false;

        //private bool m_rendered = false;

        //private bool m_destroyed = false;
        //private const float m_movementSpeed = 0.025f;
        //private const float m_turnSpeed = 1.0f;

        //private const float m_baseWidth = 4000.0f;
        //private const float m_baseHeight = 3000.0f;
        //private const float m_baseAspectRatio = m_baseWidth / m_baseHeight;

        //private const float m_headWidth = 2500.0f;
        //private const float m_headHeight = 2500.0f;
        //private const float m_headAspectRatio = m_headWidth / m_headHeight;

        //private const float m_turretWidth = 1400.0f;
        //private const float m_turretHeight = 1400.0f;

        //private const int headIndex = 3;

        //private const int m_crashDamage = 20;
        //private const long m_pointValue = 600;

        ///// <summary>
        ///// Constructor for the robot.
        ///// </summary>
        ///// <param name="device"> Direct3D device. </param>
        //public BossBot(Device device, int worldTileStartX, int worldTileStartY)
        //{
        //    m_device = device;

        //    m_robotTileCoords.x = m_startXCoord;
        //    m_robotTileCoords.y = m_startYCoord;

        //    m_robotWorldCoords.x = worldTileStartX;
        //    m_robotWorldCoords.y = worldTileStartY;

        //    m_robotTextures = TextureHandler.GetInstance().GetRobotTextures();

        //    m_bullets = new ArrayList();

        //    m_weaponFactory = new WeaponFactory(m_device);

        //    m_turretTextures = TextureHandler.GetInstance().GetTurretTextures();

        //    List<MathHandler> headPoints = new List<MathHandler>();
        //    List<MathHandler> leftTurretPoints = new List<MathHandler>();
        //    List<MathHandler> rightTurretPoints = new List<MathHandler>();

        //    headPoints.Add(new MathHandler((-m_headWidth+1400) / 1000.0f, (m_headHeight-1400) / 1000.0f));
        //    headPoints.Add(new MathHandler((m_headWidth-1400) / 1000.0f, (m_headHeight-1400) / 1000.0f));
        //    headPoints.Add(new MathHandler((m_headWidth-1400) / 1000.0f, (-m_headHeight+1400) / 1000.0f));
        //    headPoints.Add(new MathHandler((-m_headWidth+1400) / 1000.0f, (-m_headHeight+1400) / 1000.0f));

        //    leftTurretPoints.Add(new MathHandler((-m_turretWidth+700) / 1000.0f, (m_turretHeight-700) / 1000.0f));
        //    leftTurretPoints.Add(new MathHandler((m_turretWidth-700) / 1000.0f, (m_turretHeight-700) / 1000.0f));
        //    leftTurretPoints.Add(new MathHandler((m_turretWidth-700) / 1000.0f, (-m_turretHeight+700) / 1000.0f));
        //    leftTurretPoints.Add(new MathHandler((-m_turretWidth+700) / 1000.0f, (-m_turretHeight+700) / 1000.0f));

        //    rightTurretPoints.Add(new MathHandler((-m_turretWidth+700) / 1000.0f, (m_turretHeight-700) / 1000.0f));
        //    rightTurretPoints.Add(new MathHandler((m_turretWidth-700) / 1000.0f, (m_turretHeight-700) / 1000.0f));
        //    rightTurretPoints.Add(new MathHandler((m_turretWidth-700) / 1000.0f, (-m_turretHeight+700) / 1000.0f));
        //    rightTurretPoints.Add(new MathHandler((-m_turretWidth+700) / 1000.0f, (-m_turretHeight+700) / 1000.0f));

        //    m_boundingShape = new BoundingShape2D(headPoints);
        //    m_leftTurretShape = new BoundingShape2D(leftTurretPoints);
        //    m_rightTurretShape = new BoundingShape2D(rightTurretPoints);

        //    m_boundingShape.Translate(new MathHandler((float)m_robotWorldCoords.x, (float)m_robotWorldCoords.y));
        //    m_leftTurretShape.Translate(new MathHandler((float)m_robotWorldCoords.x + 2.0f, (float)m_robotWorldCoords.y));
        //    m_rightTurretShape.Translate(new MathHandler((float)m_robotWorldCoords.x - 2.0f, (float)m_robotWorldCoords.y));

        //    m_baseSprite =
        //        new AnimatedSprite(m_device, m_robotTextures, (float)m_robotWorldCoords.x, (float)m_robotWorldCoords.y, 180.0f, 400);

        //    m_leftShoulderTurret =
        //        new UnanimatedSprite(m_device, ((Texture)m_turretTextures[0]), 
        //        ((float)m_robotWorldCoords.x + 2), (float)m_robotWorldCoords.y, 180.0f);

        //    m_rightShoulderTurret =
        //        new UnanimatedSprite(m_device, ((Texture)m_turretTextures[0]), 
        //        ((float)m_robotWorldCoords.x - 2), (float)m_robotWorldCoords.y, 180.0f);

        //    m_headSprite =
        //        new UnanimatedSprite(m_device, ((Texture)TextureHandler.GetInstance().GetRobotHeadTextures()[0]),
        //        (float)m_robotWorldCoords.x, (float)m_robotWorldCoords.y, 180.0f);

      
        //}

        ///// <summary>
        ///// Move the robot either up or down 1 unit (designated by movement speed).
        ///// </summary>
        ///// <param name="direction"> Either "UP" or "DOWN". </param>
        //public override void Move(String direction, Camera camera)
        //{
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

        //public bool TurretsReadyToFire()
        //{
        //    return m_turretsReadyToFire;
        //}

        //public bool ReadyToSpawn()
        //{
        //    return m_readyToSpawn;
        //}

        ///// <summary>
        ///// Set the x and y coordinates of the robot within an individual tile.
        ///// </summary>
        ///// <param name="xCoord"> The robots x coordinate in the tile. </param>
        ///// <param name="yCoord"> The robots y coordinate in the tile. </param>

        //public void SetUnpassableCoords(int xCoord, int yCoord)
        //{
        //}

        //public override ArrayList FireWeapon(string weaponName)
        //{
        //    ArrayList tempList = new ArrayList();
        //    tempList.Add(m_weaponFactory.CreateWeapon(weaponName, m_robotWorldCoords.x, m_robotWorldCoords.y,
        //            m_robotTileCoords.x + this.GetTurretOffsetCoords().x, m_robotTileCoords.y + this.GetTurretOffsetCoords().y, m_headSprite.GetFacingAngle()));
        //    tempList.Add(m_weaponFactory.CreateWeapon(weaponName, m_robotWorldCoords.x, m_robotWorldCoords.y,
        //                        m_robotTileCoords.x + this.GetTurretOffsetCoords().x, m_robotTileCoords.y + this.GetTurretOffsetCoords().y, m_headSprite.GetFacingAngle()+20));
        //    tempList.Add(m_weaponFactory.CreateWeapon(weaponName, m_robotWorldCoords.x, m_robotWorldCoords.y,
        //            m_robotTileCoords.x + this.GetTurretOffsetCoords().x, m_robotTileCoords.y + this.GetTurretOffsetCoords().y, m_headSprite.GetFacingAngle()-20));
        //    return tempList;
        //}

        //public ArrayList FireTurrets()
        //{
        //    ArrayList tempList = new ArrayList();
        //    if (m_leftShoulderTurret != null)
        //    {
        //        tempList.Add(m_weaponFactory.CreateWeapon("BULLET", m_robotWorldCoords.x + 2, m_robotWorldCoords.y,
        //                m_robotTileCoords.x + this.GetLeftTurretOffsetCoords().x, m_robotTileCoords.y + this.GetLeftTurretOffsetCoords().y, m_leftShoulderTurret.GetFacingAngle()));
        //    }
        //    else
        //        tempList.Add(null);
        //    if (m_rightShoulderTurret != null)
        //    {
        //        tempList.Add(m_weaponFactory.CreateWeapon("BULLET", m_robotWorldCoords.x - 2, m_robotWorldCoords.y,
        //            m_robotTileCoords.x + this.GetRightTurretOffsetCoords().x, m_robotTileCoords.y + this.GetRightTurretOffsetCoords().y, m_rightShoulderTurret.GetFacingAngle()));
        //    }
        //    else
        //        tempList.Add(null);
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

        //public bool ReduceLeftTurretHealth(float value)
        //{
        //    m_leftTurretHealth -= value;
        //    if (m_leftTurretHealth <= 0)
        //    {
        //        m_leftTurretShape = null;
        //        m_leftShoulderTurret.Destroy();
        //        m_leftShoulderTurret = null;
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        //public bool ReduceRightTurretHealth(float value)
        //{
        //    m_rightTurretHealth -= value;
        //    if (m_rightTurretHealth <= 0)
        //    {
        //        m_rightTurretShape = null;
        //        m_rightShoulderTurret.Destroy();
        //        m_rightShoulderTurret = null;
        //        return true;
        //    }
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
        //}

        ///// <summary>
        ///// Rotate the turret and the gun a particular angle.
        ///// </summary>
        ///// <param name="angle"></param>
        //public override void RotateGundam(float angle)
        //{
        //    m_headSprite.SetFacingAngle(angle);
        //}

        //public override void Tint(Color color)
        //{
        //    m_baseSprite.SetMaterialColor(color);
        //    m_headSprite.SetMaterialColor(color);
        //}

        //public void TintLeftTurret(Color color)
        //{
        //    if(m_leftShoulderTurret != null)
        //        m_leftShoulderTurret.SetMaterialColor(color);
        //}

        //public void TintRightTurret(Color color)
        //{
        //    if(m_rightShoulderTurret != null)
        //        m_rightShoulderTurret.SetMaterialColor(color);
        //}

        ///// <summary>
        ///// Render the robot within the game world.
        ///// </summary>
        //public override void Render()
        //{
        //    if (!m_rendered)
        //    {
        //        AudioHandler.GetInstance().PlayAudio(AudioHandler.SoundType.WARNING);
        //        m_rendered = true;
        //    }
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

        //    if (m_rightShoulderTurret != null)
        //    {
        //        m_device.Transform.World =
        //            Matrix.Scaling(new Vector3(m_turretWidth / 1000.0f, m_turretHeight / 1000.0f, 0.0f)) *
        //            Matrix.RotationZ(m_rightShoulderTurret.GetFacingAngleInRadians()) *
        //            Matrix.Translation(m_rightShoulderTurret.GetXPos(), m_rightShoulderTurret.GetYPos(), 0.0f);

        //        m_rightShoulderTurret.Render();
        //    }

        //    if (m_leftShoulderTurret != null)
        //    {
        //        m_device.Transform.World =
        //            Matrix.Scaling(new Vector3(m_turretWidth / 1000.0f, m_turretHeight / 1000.0f, 0.0f)) *
        //            Matrix.RotationZ(m_leftShoulderTurret.GetFacingAngleInRadians()) *
        //            Matrix.Translation(m_leftShoulderTurret.GetXPos(), m_leftShoulderTurret.GetYPos(), 0.0f);

        //        m_leftShoulderTurret.Render();
        //    }

        //    m_baseSprite.SetMaterialColor(Color.White);
        //    m_headSprite.SetMaterialColor(Color.White);
        //    if(m_leftShoulderTurret != null)
        //        m_leftShoulderTurret.SetMaterialColor(Color.White);
        //    if(m_rightShoulderTurret != null)
        //        m_rightShoulderTurret.SetMaterialColor(Color.White);
        //    m_device.Transform.World = saved;
        //}

        //public override BoundingShape2D GetBoundingShape()
        //{
        //    return m_boundingShape;
        //}

        //public BoundingShape2D GetLeftTurretShape()
        //{
        //    return m_leftTurretShape;
        //}

        //public BoundingShape2D GetRightTurretShape()
        //{
        //    return m_rightTurretShape;
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
        //    float hyp = (m_headHeight) / 1000.0f;

        //    TrigHandler trig = TrigHandler.GetInstance();

        //    offsetCoords.y = trig.GetCos(angle) * hyp;
        //    offsetCoords.x = -trig.GetSin(angle) * hyp;

        //    return offsetCoords;


        //}

        //private GameEngine.FloatCoords GetLeftTurretOffsetCoords()
        //{
        //    float angle = m_leftShoulderTurret.GetFacingAngle();

        //    if (angle < 0)
        //        angle += 360;
        //    GameEngine.FloatCoords offsetCoords;
        //    float hyp = (m_turretHeight) / 1000.0f;

        //    TrigHandler trig = TrigHandler.GetInstance();

        //    offsetCoords.y = trig.GetCos(angle) * hyp;
        //    offsetCoords.x = -trig.GetSin(angle) * hyp;

        //    return offsetCoords;
        //}

        //private GameEngine.FloatCoords GetRightTurretOffsetCoords()
        //{
        //    float angle = m_rightShoulderTurret.GetFacingAngle();

        //    if (angle < 0)
        //        angle += 360;
        //    GameEngine.FloatCoords offsetCoords;
        //    float hyp = (m_turretHeight) / 1000.0f;

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
        //    int xdif = 0;
        //    int ydif = 0;

        //    if (m_rightShoulderTurret != null)
        //    {
        //        xdif = (int)m_rightShoulderTurret.GetXPos() - obj.GetWorldCoords().x;
        //        ydif = (int)m_rightShoulderTurret.GetYPos() - obj.GetWorldCoords().y;

        //        if (xdif == 0)
        //        {
        //            if (m_rightShoulderTurret.GetFacingAngle() != 180.0f)
        //            {
        //                if (m_rightShoulderTurret.GetFacingAngle() > 180.0f)
        //                    m_rightShoulderTurret.Rotate(-20.0f);
        //                else
        //                    m_rightShoulderTurret.Rotate(20.0f);
        //            }
        //        }
        //        else if (xdif < 0)
        //        {
        //            if (m_rightShoulderTurret.GetFacingAngle() != 200.0f)
        //                m_rightShoulderTurret.Rotate(20.0f);
        //        }
        //        else if (xdif > 0)
        //        {
        //            if (m_rightShoulderTurret.GetFacingAngle() != 160.0f)
        //            {
        //                if (m_rightShoulderTurret.GetFacingAngle() > 160.0f)
        //                    m_rightShoulderTurret.Rotate(-20.0f);
        //                else
        //                    m_rightShoulderTurret.Rotate(20.0f);
        //            }
        //        }

        //        if (m_robotWorldCoords.x < 16 || m_robotWorldCoords.x > 21)
        //        {
        //            if (m_robotWorldCoords.x < 10)
        //                xChange = 0.05f;
        //            if (m_robotWorldCoords.x > 25)
        //                xChange = -0.05f;
        //        }

        //        m_robotTileCoords.x += xChange;
        //        MathHandler move = new MathHandler(xChange, yChange);

        //        m_boundingShape.Translate(move);
        //        m_baseSprite.Move(move);
        //        m_headSprite.Move(move);

        //        if (m_leftShoulderTurret != null)
        //        {
        //            m_leftShoulderTurret.Move(move);
        //            m_leftTurretShape.Translate(move);
        //        }

        //        if (m_rightShoulderTurret != null)
        //        {
        //            m_rightShoulderTurret.Move(move);
        //            m_rightTurretShape.Translate(move);
        //        }

        //        //reset x if needed
        //        if (m_robotTileCoords.x > 0.5f)
        //        {
        //            m_robotTileCoords.x -= 1.0f;
        //            m_robotWorldCoords.x += 1;
        //        }
        //        else if (m_robotTileCoords.x < -0.5f)
        //        {
        //            m_robotTileCoords.x += 1.0f;
        //            m_robotWorldCoords.x -= 1;
        //        }

        //        //reset y if needed
        //        if (m_robotTileCoords.y > 0.5f)
        //        {
        //            m_robotTileCoords.y -= 1.0f;
        //            m_robotWorldCoords.y += 1;
        //        }
        //        else if (m_robotTileCoords.y < -0.5f)
        //        {
        //            m_robotTileCoords.y += 1.0f;
        //            m_robotWorldCoords.y -= 1;
        //        }

        //        m_turretFireRate++;
        //        m_fireRate++;
        //        m_spawnRate++;


        //        if (m_health > 300)
        //        {
        //            if (m_turretFireRate >= m_health / 10)
        //            {
        //                m_turretsReadyToFire = true;
        //                m_turretFireRate = 0;
        //            }
        //            else
        //                m_turretsReadyToFire = false;

        //            if (m_fireRate >= m_health / 8)
        //            {
        //                m_readyToFire = true;
        //                m_fireRate = 0;
        //            }
        //            else
        //                m_readyToFire = false;

        //            if (m_spawnRate >= m_health / 5)
        //            {
        //                m_readyToSpawn = true;
        //                m_spawnRate = 0;
        //            }
        //            else
        //                m_readyToSpawn = false;
        //        }
        //        else
        //        {
        //            if (m_turretFireRate >= 20)
        //            {
        //                m_turretsReadyToFire = true;
        //                m_turretFireRate = 0;
        //            }
        //            else
        //                m_turretsReadyToFire = false;

        //            if (m_fireRate >= 25)
        //            {
        //                m_readyToFire = true;
        //                m_fireRate = 0;
        //            }
        //            else
        //                m_readyToFire = false;

        //            if (m_spawnRate >= 60)
        //            {
        //                m_readyToSpawn = true;
        //                m_spawnRate = 0;
        //            }
        //            else
        //                m_readyToSpawn = false;
        //        }
        //    }

        //    if (m_leftShoulderTurret != null)
        //    {
        //        xdif = (int)m_leftShoulderTurret.GetXPos() - obj.GetWorldCoords().x;
        //        ydif = (int)m_leftShoulderTurret.GetYPos() - obj.GetWorldCoords().y;

        //        if (xdif == 0)
        //        {
        //            if (m_leftShoulderTurret.GetFacingAngle() != 180.0f)
        //            {
        //                if (m_leftShoulderTurret.GetFacingAngle() > 180.0f)
        //                    m_leftShoulderTurret.Rotate(-20.0f);
        //                else
        //                    m_leftShoulderTurret.Rotate(20.0f);
        //            }
        //        }
        //        else if (xdif < 0)
        //        {
        //            if (m_leftShoulderTurret.GetFacingAngle() != 200.0f)
        //                m_leftShoulderTurret.Rotate(20.0f);
        //        }
        //        else if (xdif > 0)
        //        {
        //            if (m_leftShoulderTurret.GetFacingAngle() != 160.0f)
        //            {
        //                if (m_leftShoulderTurret.GetFacingAngle() > 160.0f)
        //                    m_leftShoulderTurret.Rotate(-20.0f);
        //                else
        //                    m_leftShoulderTurret.Rotate(20.0f);
        //            }
        //        }
        //    }


        //    xdif = (int)m_headSprite.GetXPos() - obj.GetWorldCoords().x;
        //    ydif = (int)m_headSprite.GetYPos() - obj.GetWorldCoords().y;

        //    if (xdif == 0)
        //    {
        //        if (m_headSprite.GetFacingAngle() != 180.0f)
        //        {
        //            if (m_headSprite.GetFacingAngle() > 180.0f)
        //                m_headSprite.Rotate(-20.0f);
        //            else
        //                m_headSprite.Rotate(20.0f);
        //        }
        //    }
        //    else if (xdif < 0)
        //    {
        //        if (m_headSprite.GetFacingAngle() != 200.0f)
        //            m_headSprite.Rotate(20.0f);
        //    }
        //    else if (xdif > 0)
        //    {
        //        if (m_headSprite.GetFacingAngle() != 160.0f)
        //        {
        //            if (m_headSprite.GetFacingAngle() > 160.0f)
        //                m_headSprite.Rotate(-20.0f);
        //            else
        //                m_headSprite.Rotate(20.0f);
        //        }
        //    }
        //}

        //public override void Destroy()
        //{
        //    if (m_baseSprite != null)
        //    {
        //        m_baseSprite.Destroy();
        //        m_headSprite.Destroy();
        //        if(m_leftShoulderTurret != null)
        //            m_leftShoulderTurret.Destroy();
        //        if(m_rightShoulderTurret != null)
        //            m_rightShoulderTurret.Destroy();
        //        m_baseSprite = null;
        //        m_headSprite = null;
        //        m_leftShoulderTurret = null;
        //        m_rightShoulderTurret = null;
        //    }
        //    m_destroyed = true;
        //}
    }
}
