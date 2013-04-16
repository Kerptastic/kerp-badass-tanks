using Microsoft.Xna.Framework;

namespace KerpEngine.Global
{
    public abstract class GameObject
    {
        /// <summary>
        /// The tint color to use when drawing the Model. By default, will
        /// be Color.White, which will use no tint.
        /// </summary>
        protected Color _textureTint = Color.White;
        public Color TextureTint { get { return _textureTint; } set { _textureTint = value; } }
        /// <summary>
        /// The current position of this object.
        /// </summary>
        protected Vector3 _position;
        public virtual Vector3 Position { get { return _position; } set { _position = value; if (_boundingVolume != null) { _boundingVolume.Position = value; } } }
        public float X { get { return _position.X; } set { _position.X = value; if (_boundingVolume != null) { _boundingVolume.X = (int)value; } } }
        public float Y { get { return _position.Y; } set { _position.Y = value; if (_boundingVolume != null) { _boundingVolume.Y = (int)value; } } }
        /// <summary>
        /// The direction the object is currently looking at.
        /// </summary>
        protected Vector3 _lookAt = Vector3.Forward;
        public Vector3 LookAt { get { return _lookAt; } set { _lookAt = value; } }
        /// <summary>
        /// The reference look at vector to be used when calculating
        /// movement.
        /// </summary>
        protected Vector3 _referenceLookAt = new Vector3(0.0f, 0.0f, 1.0f);
        /// <summary>
        /// The Quaternion representing the current orientation.
        /// </summary>
        protected Quaternion _orientation = Quaternion.Identity;
        public Quaternion Orientation { get { return _orientation; } set { _orientation = value; } }
        /// <summary>
        /// The current rotation angle of this object.
        /// </summary>
        protected Vector3 _rotation;
        public virtual Vector3 Rotation { get { return _rotation; } set { this._rotation = Utilities.ClampAngleDegrees(value); } }
        /// <summary>
        /// The current scale factor of this object.
        /// </summary>
        protected Vector3 _scale;
        public virtual Vector3 ScaleValue { get { return _scale; } set { _scale = value; if (_boundingVolume != null) { _boundingVolume.ScaleValue = value; } } }
        /// <summary>
        /// The speed at which this object moves in a particular direction.
        /// </summary>
        protected float _moveSpeed = 0.05f;
        public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
        /// <summary>
        /// The bounding shape around this object.
        /// </summary>
        protected BoundingVolume _boundingVolume;
        public BoundingVolume BoundingVolume { get { return _boundingVolume; } set { _boundingVolume = value; } }


        /// <summary>
        /// Moves an object in the given direction by the default move speed
        /// for this object.
        /// </summary>
        /// <param name="direction">The amount to move the object. This should be a unit Vector.</param>
        public virtual void Move(Vector3 amount)
        {
            amount = (amount * MoveSpeed);

            Matrix forwardMovement = Matrix.CreateFromQuaternion(_orientation);

            //transform the amount vector on the rotation matrix to get the
            //vector of what direction the move occurs in
            Vector3 v = Vector3.Transform(amount, forwardMovement);

            //add the transformed values to the current position
            _position.X += v.X;
            _position.Y += v.Y;
            _position.Z += v.Z;

            if (_boundingVolume != null)
            {
                this._boundingVolume.Position = this._position;
            }
        }

        /// <summary>
        /// Increases (positive) or decreases (negative) the current rotation value
        /// by the provided amount.
        /// </summary>
        /// <param name="amount">The amount to increase (positive) or decrease (negative) the rotation value by.</param>
        public virtual void Rotate(Vector3 amount)
        {
            _rotation += amount;
            _orientation = Quaternion.CreateFromYawPitchRoll(_rotation.Y, _rotation.X, _rotation.Z);

            if (_boundingVolume != null)
            {
                this._boundingVolume.Rotation = this._rotation;
                this._boundingVolume.Orientation = this._orientation;
            }
        }

        /// <summary>
        /// Increases (positive) or decreases (negative) the current scale value
        /// by the provided amount.
        /// </summary>
        /// <param name="amount">The amount to increase (positive) or decrease (negative) the scale factor by.</param>
        public virtual void Scale(Vector3 amount)
        {
            _scale += amount;

            if (_boundingVolume != null)
            {
                _boundingVolume.Scale(amount);
            }
        }

        /// <summary>
        /// Sets the tint color of this object to the new tint color.
        /// </summary>
        /// <param name="newTintColor">The new color to tint this object with when drawing.</param>
        public virtual void Tint(Color newTintColor)
        {
            _textureTint = newTintColor;
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract void Update();
    }
}
