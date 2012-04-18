using System;
using System.Collections.Generic;
using System.Text;

namespace BadAssTanks
{
    public class EnemyFactory
    {
        //private Device m_device;
        //private Random m_randomizer;
        //public EnemyFactory(Device device)
        //{
        //    m_device = device;
        //    m_randomizer = new Random((int)GameTimer.timeGetTime());
        //}

        //public enum EnemyType
        //{
        //    ROBOWALKER, TURRET, TANK
        //}

        //public WorldObject CreateEnemy(EnemyType type, int tileX, int tileY)
        //{
        //    WorldObject returnObject = null;
        //    if (type == EnemyType.TANK)
        //    {
        //        int tempRand = m_randomizer.Next(0,3);
        //        if(tempRand < 2)
        //            returnObject = new Tank(m_device, tileX, tileY, 0.01f, 180.0f, Tank.TankColor.BLUERED);
        //        else if(tempRand >= 2)
        //            returnObject = new Tank(m_device, tileX, tileY, 0.01f, 180.0f, Tank.TankColor.GREENYELLOW);
        //    }
        //    else if (type == EnemyType.ROBOWALKER)
        //    {
        //        returnObject = new RoboWalker(m_device, tileX, tileY);
        //    }
        //    else if (type == EnemyType.TURRET)
        //    {
        //        returnObject = new Turret(m_device, tileX, tileY);
        //    }

        //    return returnObject;
        //}
    }
}
