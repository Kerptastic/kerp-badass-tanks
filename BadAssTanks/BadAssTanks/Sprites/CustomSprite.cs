using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BadAssTanks
{
    /// <summary>
    /// Base class defining the behavior required for all Sprites in the
    /// Game Engine.
    /// </summary>
    public class CustomSprite
    {
        /// <summary>
        /// 
        /// </summary>
        protected Rectangle _dimensions;
        /// <summary>
        /// 
        /// </summary>
        protected Point _location;

        /// <summary>
        /// 
        /// </summary>
        public abstract void Draw();

        //public abstract void Move(MathHandler moveVector);
        //public abstract void Rotate(float angle);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        public void SetLocation(Point location)
        {
            this._location = location;
        }

        public void SetLocation(float x, float y)
        {
            this.SetLocation(new Point(x, y));
        }
        
        //public abstract void SetFacingAngle(float angleInDegrees);
        //public abstract void SetMaterialColor(Color color);

        //public abstract float GetXPos();
        //public abstract float GetYPos();
        //public abstract float GetFacingAngle();
        //public abstract float GetFacingAngleInRadians();
        //public abstract void Destroy();
    }
}
