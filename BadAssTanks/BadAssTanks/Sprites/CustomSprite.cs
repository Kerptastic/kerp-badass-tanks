using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BadAssTanks
{
    abstract class CustomSprite
    {
        public abstract void Render();
        public abstract void Move(Vector moveVector);
        public abstract void Rotate(float angle);
        public abstract void SetLocation(float x, float y);
        public abstract void SetFacingAngle(float angleInDegrees);
        public abstract void SetMaterialColor(Color color);
        public abstract float GetXPos();
        public abstract float GetYPos();
        public abstract float GetFacingAngle();
        public abstract float GetFacingAngleInRadians();
        public abstract void Destroy();
    }
}
