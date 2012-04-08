using System;
using System.Collections;
using System.Drawing;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace BadAssTanks
{
    class WeaponFactory
    {

        private Device m_device = null;

        public WeaponFactory(Device device)
        {
            m_device = device;
        }

        public WorldObject CreateWeapon(String type, int worldX, int worldY, float tileX, float tileY, float angle)
        {
            WorldObject tempObject = null;

            if (type == "BULLET")
            {
                tempObject = new Bullet(m_device, worldX, worldY, tileX, tileY, angle);
                AudioHandler.GetInstance().PlayAudio(AudioHandler.SoundType.GUNSHOT);
            }
            else if (type == "MISSILE")
            {
                tempObject = new Missile(m_device, worldX, worldY, tileX, tileY, angle);
                AudioHandler.GetInstance().PlayAudio(AudioHandler.SoundType.MISSILELAUNCH);
            }
            else if (type == "LASER")
            {
                tempObject = new Laser(m_device, worldX, worldY, tileX, tileY, angle);
                AudioHandler.GetInstance().PlayAudio(AudioHandler.SoundType.LASER);
            }


            return tempObject;
        }

    }
}
