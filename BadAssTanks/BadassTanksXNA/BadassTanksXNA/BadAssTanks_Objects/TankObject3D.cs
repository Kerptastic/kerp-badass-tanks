using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KerpEngine.Engine_3D;
using KerpEngine.Engine_3D.Models;
using Microsoft.Xna.Framework;

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
        }
    }
}
