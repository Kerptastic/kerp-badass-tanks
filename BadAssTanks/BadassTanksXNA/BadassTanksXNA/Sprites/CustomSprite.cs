
using BadAssTanks.Utility;

namespace BadAssTanks
{
    /// <summary>
    /// Base class defining the behavior required for all Sprites in the
    /// Game Engine.
    /// </summary>
    public abstract class CustomSprite
    {
        /// <summary>
        /// 
        /// </summary>
        protected PairInt _dimensions;
        public int Width { get { return _dimensions.X; } set { _dimensions.X = value; } }
        public int Height { get { return _dimensions.Y; } set { _dimensions.Y = value; } }
        /// <summary>
        /// 
        /// </summary>
        protected PairInt _location;
        public int X { get { return _location.X; } set { _location.X = value; } }
        public int Y { get { return _location.Y; } set { _location.Y = value; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetDimensions(int width, int height)
        {
            this._dimensions = new PairInt(width, height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetLocation(int x, int y)
        {
            this._location = new PairInt(x, y);
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract void Draw();



        //public abstract void Move(MathHandler moveVector);
        //public abstract void Rotate(float angle);

        //public abstract void SetFacingAngle(float angleInDegrees);
        //public abstract void SetMaterialColor(Color color);

        //public abstract float GetXPos();
        //public abstract float GetYPos();
        //public abstract float GetFacingAngle();
        //public abstract float GetFacingAngleInRadians();
        //public abstract void Destroy();
    }
}
