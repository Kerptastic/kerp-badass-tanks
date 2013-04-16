using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KerpEngine.Engine_3D;
using KerpEngine.Engine_3D.Models;
using Microsoft.Xna.Framework;
using KerpEngine.Global;

namespace BadassTanksXNA.BadAssTanks_Objects
{
    /// <summary>
    /// 
    /// </summary>
    public class TankObject3D : GameObject3D
    {
        public TankObject3D(CustomModel model, Vector3 position, Vector3 target, Color textureTint)
            : base(model, position, target, textureTint)
        {
            _boundingVolume = new OABB(position, new Vector3(1.0f, 1.0f, 1.0f), 
                new Vector3(-1.0f, -1.0f, -1.0f));
        }
    }
}
