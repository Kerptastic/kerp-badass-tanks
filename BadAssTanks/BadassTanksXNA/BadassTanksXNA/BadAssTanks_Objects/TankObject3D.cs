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
        public TankObject3D(CustomModel model, Vector3 position, Color textureTint)
            : base(model, position, textureTint)
        {
            _boundingVolume = new AABB(_position, new Vector3(0.5f, 0.5f, -0.5f), new Vector3(-0.5f, -0.5f, 0.5f));//10.0f, 10.0f);
        }
    }
}
