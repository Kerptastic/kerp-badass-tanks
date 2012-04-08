using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace BadAssTanks
{
    class Tank : WorldObject
    {
        public enum TankColor
        {
            BLUERED, GREENYELLOW, CAMO
        }

        private ArrayList m_tankTextures = null;
        private ArrayList m_tankUnpassableWorldCoords = null;
        private ArrayList m_bullets = null;

        private CustomSprite m_baseSprite = null;
        private CustomSprite m_turretSprite = null;
        private CustomSprite m_gunSprite = null;

        private Device m_device = null;

        private WeaponFactory m_weaponFactory = null;

        private GameEngine.FloatCoords m_tankTileCoords;
        private GameEngine.IntCoords m_tankWorldCoords;

        private BoundingShape2D m_boundingShape = null;

        private float m_health = 100.0f;

        private float m_startXCoord = 0.0f;
        private float m_startYCoord = 0.0f;
        private float m_movementSpeed = 0.02f;

        private bool m_readyToFire = false;
        private int m_fireRate = 0;

        private const float m_turnSpeed = 3.0f;

        private const float m_baseWidth = 460.0f;
        private const float m_baseHeight = 1000.0f;
        private const float m_baseAspectRatio = m_baseWidth / m_baseHeight;

        private const float m_turretWidth = 321.0f;
        private const float m_turretHeight = 768.0f;
        private const float m_turretAspectRatio = m_turretWidth / m_turretHeight;

        private const float m_gunWidth = 43.0f;
        private const float m_gunHeight = 433.0f;
        private const float m_gunAspectRatio = m_gunWidth / m_gunHeight;

        private const int m_baseIndex = 0;
        private const int m_turretIndex = 1;
        private const int m_gunIndex = 2;

        private const int m_crashDamage = 45;
        private const long m_pointValue = 1125;

        /// <summary>
        /// Constructor for the tank.
        /// </summary>
        /// <param name="device"> Direct3D device. </param>
        public Tank(Device device, int worldTileStartX, int worldTileStartY, float moveSpeed, float angle, TankColor color)
        {
            m_device = device;

            m_tankTileCoords.x = m_startXCoord;
            m_tankTileCoords.y = m_startYCoord;

            m_tankWorldCoords.x = worldTileStartX;
            m_tankWorldCoords.y = worldTileStartY;

            if (color == TankColor.CAMO)
                m_tankTextures = TextureHandler.GetInstance().GetCamoTankTextures();
            else if (color == TankColor.BLUERED)
                m_tankTextures = TextureHandler.GetInstance().GetBlueRedTankTextures();
            else if (color == TankColor.GREENYELLOW)
                m_tankTextures = TextureHandler.GetInstance().GetGreenYellowTankTextures();

            m_tankUnpassableWorldCoords = new ArrayList();
            m_bullets = new ArrayList();

            m_weaponFactory = new WeaponFactory(m_device);

            m_movementSpeed = moveSpeed;

            List<Vector> points = new List<Vector>();

            points.Add(new Vector(-m_baseWidth / 1000.0f, m_baseHeight / 1000.0f));
            points.Add(new Vector(m_baseWidth / 1000.0f, m_baseHeight / 1000.0f));
            points.Add(new Vector(m_baseWidth / 1000.0f, -m_baseHeight / 1000.0f));
            points.Add(new Vector(-m_baseWidth / 1000.0f, -m_baseHeight / 1000.0f));

            m_boundingShape = new BoundingShape2D(points);

            m_boundingShape.Translate(new Vector((float)m_tankWorldCoords.x, (float)m_tankWorldCoords.y));

            m_baseSprite =
                new UnanimatedSprite(m_device, ((Texture)m_tankTextures[m_baseIndex]),
                (float)m_tankWorldCoords.x, (float)m_tankWorldCoords.y, angle);

            m_turretSprite =
                new UnanimatedSprite(m_device, ((Texture)m_tankTextures[m_turretIndex]),
                (float)m_tankWorldCoords.x, (float)m_tankWorldCoords.y, angle);

            m_gunSprite =
                new UnanimatedSprite(m_device, ((Texture)m_tankTextures[m_gunIndex]),
                (float)m_tankWorldCoords.x, (float)m_tankWorldCoords.y, angle);
        }
      
        /// <summary>
        /// Move the tank either up or down 1 unit (designated by movement speed).
        /// </summary>
        /// <param name="direction"> Either "UP" or "DOWN". </param>
        public override void Move(String direction, Camera camera)
        {
            float angle = this.GetFacingAngle();
            float xMove = 0.0f;
            float yMove = 0.0f;

            TrigHandler trig = TrigHandler.GetInstance();

            //grab the x and y move for the tank within the tiles
            if(direction.Equals("UP"))
            {
                xMove = -(float)trig.GetSin(angle) * m_movementSpeed;
                yMove = (float)trig.GetCos(angle) * m_movementSpeed;
                //checkPointX
            }
            else if (direction.Equals("DOWN"))
            {
                xMove = (float)trig.GetSin(angle) * m_movementSpeed;
                yMove = -(float)trig.GetCos(angle) * m_movementSpeed;
            }

            //check for unpassable Tiles
            //do not go past the left tile boundary
            if (m_tankUnpassableWorldCoords.Contains(new Point(m_tankWorldCoords.x + 1, m_tankWorldCoords.y)))
            {
                float tempNewX = m_tankTileCoords.x + xMove;
                if (tempNewX > 0.5f - .5f)
                {
                    if (xMove > 0.0f)
                        xMove = 0.0f;
                }
            }
            //do not go past the right tile boundary
            if (m_tankUnpassableWorldCoords.Contains(new Point(m_tankWorldCoords.x - 1, m_tankWorldCoords.y)))
            {
                float tempNewX = m_tankTileCoords.x + xMove;
                if (tempNewX < 0.0f)
                {
                    if (xMove < 0.0f)
                        xMove = 0.0f;
                }
            }
            //do not go past the lower tile boundary
            if (m_tankUnpassableWorldCoords.Contains(new Point(m_tankWorldCoords.x, m_tankWorldCoords.y + 1)))
            {
                float tempNewY = m_tankTileCoords.y + yMove;
                if (tempNewY > 0.0f)
                {
                    if (yMove > 0.0f)
                        yMove = 0.0f;
                }
            }
            //do not go past the upper tile boundary
            if (m_tankUnpassableWorldCoords.Contains(new Point(m_tankWorldCoords.x, m_tankWorldCoords.y - 1)))
            {
                float tempNewY = m_tankTileCoords.y + yMove;
                if (tempNewY < 0.0f)
                {
                    if (yMove < 0.0f)
                        yMove = 0.0f;
                }
            }

            //do not go past the left world boundary
            if (m_tankWorldCoords.x == 0)
            {
                float tempNewX = m_tankTileCoords.x + xMove;

                if (tempNewX < -0.5f)
                {
                    if (xMove < 0.0f)
                        xMove = 0.0f;
                }
            }

            //do not go past the right world boundary
            else if (m_tankWorldCoords.x == GameWorld.m_worldWidth - 1)
            {
                float tempNewX = m_tankTileCoords.x + xMove;

                if (tempNewX > 0.5f)
                {
                    if (xMove > 0.0f)
                        xMove = 0.0f;
                }
            }

            //do not go past the lower world boundary
            if (m_tankWorldCoords.y == 0)
            {
                float tempNewY = m_tankTileCoords.y + yMove;

                if (tempNewY < -0.5)
                {
                    if (yMove < 0.0f)
                        yMove = 0.0f;
                }
            }

            //do not go past the upper world boundary
            else if (m_tankWorldCoords.y == GameWorld.m_worldHeight - 10)
            {
                float tempNewY = m_tankTileCoords.y + yMove;

                if (tempNewY > 0.5f)
                {
                    if (yMove > 0.0f)
                        yMove = 0.0f;
                }
            }

            //move the tank and the camera

            Vector move = new Vector(xMove, yMove);

            m_baseSprite.Move(move);
            m_turretSprite.Move(move);
            m_gunSprite.Move(move);

            m_boundingShape.Translate(move);

            if (camera != null)
            {
                if (m_tankWorldCoords.y < 115 || m_tankWorldCoords.y > 13)
                    camera.Move(xMove, yMove);
                else
                    camera.Move(xMove, 0.0f);
            }

            //update the tanks tracking of itself in a tile
            m_tankTileCoords.x += xMove;
            m_tankTileCoords.y += yMove;

            //set the new tank position if moving tiles

            //reset x if needed
            if (m_tankTileCoords.x > 0.5f)
            {
                m_tankTileCoords.x -= 1.0f;
                m_tankWorldCoords.x += 1;
            }
            else if (m_tankTileCoords.x < -0.5f)
            {
                m_tankTileCoords.x += 1.0f;
                m_tankWorldCoords.x -= 1;
            }

            //reset y if needed
            if (m_tankTileCoords.y > 0.5f)
            {
                m_tankTileCoords.y -= 1.0f;
                m_tankWorldCoords.y += 1;
            }
            else if (m_tankTileCoords.y < -0.5f)
            {
                m_tankTileCoords.y += 1.0f;
                m_tankWorldCoords.y -= 1;
            }

        }

        public override long GetPointValue()
        {
            return m_pointValue;
        }

        public override void Move(WorldObject obj)
        {
            int xdif = this.GetWorldCoords().x - obj.GetWorldCoords().x;
            int ydif = this.GetWorldCoords().y - obj.GetWorldCoords().y;
            double hyp = Math.Sqrt((xdif * xdif) + (ydif * ydif));
            int tempAngle = (int)this.GetFacingAngle();
            int angle = (int)(Math.Sin(xdif / hyp) * (180.0f / Math.PI));


            m_fireRate++;

            if (m_fireRate == 160)
            {
                m_readyToFire = true;
                m_fireRate = 0;
            }
            else
                m_readyToFire = false;

            if (xdif != 0 && ydif != 0)
            {
                //Main tank is below and to the left
                if (xdif > 0 && ydif > 0)
                {
                    angle = 180 - angle;
                    if (tempAngle != angle)
                    {
                        if (tempAngle <= angle)
                            this.Rotate("LEFT");
                        else
                            this.Rotate("RIGHT");
                    }
                    RotateGundam((float)angle);
                }


                //Main tank is below and to the right
                if (xdif < 0 && ydif > 0)
                {
                    angle = 180 + (-angle);
                    if (tempAngle != angle)
                    {
                        if (tempAngle <= angle)
                            this.Rotate("LEFT");
                        else
                            this.Rotate("RIGHT");
                    }

                    RotateGundam((float)angle);
                }

                //Main tank is above and to the left
                if (xdif > 0 && ydif < 0)
                {
                    if (tempAngle != angle)
                    {
                        if (tempAngle < angle)
                            this.Rotate("LEFT");
                        else
                            this.Rotate("RIGHT");
                    }

                    RotateGundam((float)angle);
                }

                //Main tank is above and to the right
                if (xdif < 0 && ydif < 0)
                {
                    angle = 360 + angle;
                    if (tempAngle == 0)
                        tempAngle = 360;
                    if (tempAngle <= angle)
                        this.Rotate("LEFT");
                    else
                        this.Rotate("RIGHT");

                    RotateGundam((float)angle);
                }
            }
            else
            {
                if (xdif < 0 && ydif == 0)
                {
                    angle = 270;
                    if (tempAngle != angle)
                    {
                        if (tempAngle < 90 || tempAngle > 270)
                            this.Rotate("RIGHT");
                        else
                            this.Rotate("LEFT");
                    }

                    RotateGundam((float)angle);
                }
                if (xdif > 0 && ydif == 0)
                {
                    angle = 90;
                    if (tempAngle != angle)
                    {
                        if (tempAngle < 90 || tempAngle > 270)
                            this.Rotate("LEFT");
                        else
                            this.Rotate("RIGHT");
                    }

                    RotateGundam((float)angle);
                }
                if (xdif == 0 && ydif < 0)
                {
                    angle = 0;
                    if (tempAngle != angle)
                    {
                        if (tempAngle < 180)
                            this.Rotate("RIGHT");
                        else
                            this.Rotate("LEFT");
                    }
                    RotateGundam((float)angle);
                }
                if (xdif == 0 && ydif > 0)
                {
                    angle = 180;
                    if (tempAngle != angle)
                    {
                        if (tempAngle < 180)
                            this.Rotate("LEFT");
                        else
                            this.Rotate("RIGHT");
                    }
                    RotateGundam((float)angle);
                }
            }
            this.Move("UP", null);
        }

        public override int GetCrashDamage()
        {
            return m_crashDamage;
        }

        public override bool IsDestroyed()
        {
            return false;
        }

        public override bool ReduceHealth(float value)
        {
            m_health -= value;
            if (m_health <= 0)
                return true;
            else
                return false;
        }

        public void SetUnpassableCoords(int xCoord, int yCoord)
        {
            Point tempCoords = new Point(xCoord, yCoord);

            m_tankUnpassableWorldCoords.Add(tempCoords);
        }

        /// <summary>
        /// Retrieve the tanks world tile location.
        /// </summary>
        /// <returns></returns>
        public override GameEngine.IntCoords GetWorldCoords()
        {
            return m_tankWorldCoords;
        }

        /// <summary>
        /// Retrieve the tanks location within a tile.
        /// </summary>
        /// <returns></returns>
        public override GameEngine.FloatCoords GetTileCoords()
        {
            return m_tankTileCoords;
        }

        /// <summary>
        /// Rotate the tank in the desired direction.
        /// </summary>
        /// <param name="direction"> Either "LEFT" or "RIGHT". </param>
        public override void Rotate(String direction)
        {
            if(direction.Equals("LEFT"))
            {
                m_baseSprite.Rotate(m_turnSpeed);
                m_boundingShape.Rotate(1.0f * ((float)Math.PI / 180.0f));
                m_boundingShape.Rotate(1.0f * ((float)Math.PI / 180.0f));
            }
            else if (direction.Equals("RIGHT"))
            {
                m_baseSprite.Rotate(-m_turnSpeed);
                m_boundingShape.Rotate(-1.0f * ((float)Math.PI / 180.0f));
                m_boundingShape.Rotate(-1.0f * ((float)Math.PI / 180.0f));
            }
        }

        /// <summary>
        /// Rotate the turret and the gun a particular angle.
        /// </summary>
        /// <param name="angle"></param>
        public override void RotateGundam(float angle)
        {
            if (angle < 0.0f)
                angle = 360.0f + angle;

            m_turretSprite.SetFacingAngle(angle);
            m_gunSprite.SetFacingAngle(angle);
        }

        /// <summary>
        /// Render the tank within the game world.
        /// </summary>
        public override void Render()
        {
            Matrix saved = m_device.Transform.World;

            m_device.Transform.World =
                Matrix.Scaling(new Vector3(m_baseWidth / 1000.0f, m_baseHeight / 1000.0f, 0.0f)) *
                Matrix.RotationZ(m_baseSprite.GetFacingAngleInRadians()) *
                Matrix.Translation(m_baseSprite.GetXPos(), m_baseSprite.GetYPos(), 0.0f);

            m_baseSprite.Render();
          
            m_device.Transform.World = 
                Matrix.Scaling(new Vector3(m_turretWidth / 1000.0f, m_turretHeight / 1000.0f, 0.0f)) *
                Matrix.RotationZ(m_turretSprite.GetFacingAngleInRadians()) *
                Matrix.Translation(m_turretSprite.GetXPos(), m_turretSprite.GetYPos(), 0.0f);

            m_turretSprite.Render();

            m_device.Transform.World =
                Matrix.Scaling(new Vector3(m_gunWidth / 1000.0f, m_gunHeight / 1000.0f, 0.0f)) *
                Matrix.Translation(0.0f, 1.0f, 0.0f) *
                Matrix.RotationZ(m_gunSprite.GetFacingAngleInRadians()) *
                Matrix.Translation(m_gunSprite.GetXPos(), m_gunSprite.GetYPos(), 0.0f);

            m_gunSprite.Render();

            m_device.Transform.World = saved;
        }

        public override BoundingShape2D GetBoundingShape()
        {
            return m_boundingShape;
        }

        /// <summary>
        /// Retrieve the x position of the sprite.
        /// </summary>
        /// <returns></returns>
        public float GetXPos()
        {
            return m_baseSprite.GetXPos();
        }

        /// <summary>
        /// Retrieve the y position of the tanks sprite.
        /// </summary>
        /// <returns></returns>
        public float GetYPos()
        {
            return m_baseSprite.GetYPos();
        }

        /// <summary>
        /// Retrieve the facing angle of the tanks sprite.
        /// </summary>
        /// <returns></returns>
        public override float GetFacingAngle()
        {
            return m_baseSprite.GetFacingAngle();
        }

        public float GetGundamFacingAngle()
        {
            return m_gunSprite.GetFacingAngle();
        }

        private GameEngine.FloatCoords GetTurretOffsetCoords()
        {
            float angle = GetGundamFacingAngle();

            if (angle < 0)
                angle += 360;

            GameEngine.FloatCoords offsetCoords;
            float hyp = (m_gunHeight + m_turretHeight + 250) / 1000.0f;

            TrigHandler trig = TrigHandler.GetInstance();

            offsetCoords.y = trig.GetCos(angle) * hyp;
            offsetCoords.x = -trig.GetSin(angle) * hyp;

            return offsetCoords;
        }

        public override bool ReadyToFire()
        {
            return m_readyToFire;
        }

        /// <summary>
        /// Retrieve the facing angle of the tanks sprite in radians.
        /// </summary>
        /// <returns></returns>
        public float GetFacingAngleInRadians()
        {
            return m_baseSprite.GetFacingAngleInRadians();
        }

        public override ArrayList FireWeapon(string weaponName)
        {
            ArrayList tempList = new ArrayList();
            if (weaponName == "VOLLEYMISSILE")
            {
                tempList.Add(m_weaponFactory.CreateWeapon("MISSILE", m_tankWorldCoords.x, m_tankWorldCoords.y,
                    m_tankTileCoords.x + this.GetTurretOffsetCoords().x, m_tankTileCoords.y + this.GetTurretOffsetCoords().y, this.GetGundamFacingAngle()));

                tempList.Add(m_weaponFactory.CreateWeapon("MISSILE", m_tankWorldCoords.x, m_tankWorldCoords.y,
                    m_tankTileCoords.x + this.GetTurretOffsetCoords().x, m_tankTileCoords.y + this.GetTurretOffsetCoords().y, this.GetGundamFacingAngle()+20));

                tempList.Add(m_weaponFactory.CreateWeapon("MISSILE", m_tankWorldCoords.x, m_tankWorldCoords.y,
                    m_tankTileCoords.x + this.GetTurretOffsetCoords().x, m_tankTileCoords.y + this.GetTurretOffsetCoords().y, this.GetGundamFacingAngle()-20));

            }
            else if (weaponName == "LASER")
            {
                tempList.Add(m_weaponFactory.CreateWeapon(weaponName, m_tankWorldCoords.x, m_tankWorldCoords.y - 1,
                    m_tankTileCoords.x, m_tankTileCoords.y, this.GetGundamFacingAngle()));
            }
            else 
            tempList.Add(m_weaponFactory.CreateWeapon(weaponName, m_tankWorldCoords.x, m_tankWorldCoords.y,
                    m_tankTileCoords.x + this.GetTurretOffsetCoords().x, m_tankTileCoords.y + this.GetTurretOffsetCoords().y, this.GetGundamFacingAngle()));

            return tempList;
        }

        public override void Move(float angle)
        {

        }

        public override void Destroy()
        {
            //null the rest of this stuff out in this object

            //m_boundShape = null;
        }

        public override void Tint(Color color)
        {
            m_baseSprite.SetMaterialColor(color);
            m_gunSprite.SetMaterialColor(color);
            m_turretSprite.SetMaterialColor(color);
        }
    }
}
