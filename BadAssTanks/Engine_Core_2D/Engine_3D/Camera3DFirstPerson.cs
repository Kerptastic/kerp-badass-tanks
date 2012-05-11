using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KerpEngine.Engine_3D
{
    /// <summary>
    /// First Person 3D Camera to be used in FPS like games.  This camera will
    /// give typical FPS freedom of motion, and a maximum pitch value to prevent rolling.
    /// </summary>
    public class Camera3DFirstPerson : Camera3D
    {
        /// <summary>
        /// The default maximum pitch value.
        /// </summary>
        private const float DEFAULT_MAX_PITCH_DEGREES = MathHelper.PiOver4;

        /// <summary>
        /// The maximum pitch of the camera, so it doesnt roll over itself and go
        /// upside down.
        /// </summary>
        protected float _maxPitch = DEFAULT_MAX_PITCH_DEGREES;
        public float MaxPitch { get { return _maxPitch; } }

        /// <summary>
        /// Creates a First Person camera.
        /// </summary>
        /// <param name="viewport">The Viewport the game is using.</param>
        /// <param name="position">The position of the camera in the world.</param>
        /// <param name="target">The direction the camera is looking in the world.</param>
        public Camera3DFirstPerson(Viewport viewport, Vector3 position, Vector3 target)
            : base(viewport, position, target)
        {
            this.Initialize();
        }

        /// <summary>
        /// Moves the specified amount.
        /// </summary>
        /// <param name="amount">The amount to move.</param>
        public override void Move(Vector3 amount)
        {
            Matrix forwardMovement = Matrix.CreateFromQuaternion(_orientation);

            //transform the amount vector on the rotation matrix to get the
            //vector of what direction the move occurs in
            Vector3 v = Vector3.Transform(amount, forwardMovement);

            //add the transformed values to the current position
            _position.X += v.X;
            _position.Y += v.Y;
            _position.Z += v.Z;
        }

        /// <summary>
        /// Adds/subtracts to the current rotation values.
        /// X = Yaw
        /// Y = Pitch
        /// Z = Roll
        /// </summary>
        /// <param name="amountInDegrees">The amount of change in the rotation values.</param>
        public override void Rotate(Vector3 amountInDegrees)
        {
            base.Rotate(amountInDegrees);

            //lock the pitch based off the max pitch.
            if (_rotation.Y > MathHelper.PiOver4)
            {
                _rotation.Y = MathHelper.PiOver4;
            }
            else if (_rotation.Y < -MathHelper.PiOver4)
            {
                _rotation.Y = -MathHelper.PiOver4;
            }

            _orientation = Quaternion.CreateFromYawPitchRoll(_rotation.X, _rotation.Y, _rotation.Z);
        }

        /// <summary>
        /// Updates the camera matrices.  Needs to be called by all sub-classes.
        /// </summary>
        public override void Update()
        {
            //calculate the camera's current position.
            Matrix rotationMatrix = Matrix.CreateFromQuaternion(_orientation);

            //create a vector pointing the direction the camera is facing.
            Vector3 transformedReference = Vector3.Transform(_referenceLookAt, rotationMatrix);

            //calculate the position the camera is looking at.
            _lookAt = _position + transformedReference;

            //set up the view matrix
            _view = Matrix.CreateLookAt(_position, _lookAt, new Vector3(0.0f, 1.0f, 0.0f));
        }
    }
}
