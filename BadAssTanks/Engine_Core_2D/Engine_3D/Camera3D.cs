using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace KerpEngine.Engine_3D
{
    /// <summary>
    /// Creates a 3D Camera that can be moved throughout a 3D World.
    /// </summary>
    public abstract class Camera3D : GameObject3D
    {
        //static variables
        private const float DEFAULT_FOV = MathHelper.PiOver4;
        private const float DEFAULT_NEAR_PLANE = 0.1f;
        private const float DEFAULT_FAR_PLANE = 2000.0f;
        /// <summary>
        /// The View matrix, used for creating the actual scene.
        /// </summary>
        protected Matrix _view = Matrix.Identity;
        public Matrix View { get { return _view; } }
        /// <summary>
        /// The Projection matrix, used for defining the camera to be
        /// viewing through.
        /// </summary>
        protected Matrix _projection = Matrix.Identity;
        public Matrix Projection { get { return _projection; } }
        /// <summary>
        /// The amount of zoom this camera is currently zoomed into.
        /// </summary>
        protected float _zoom = 1.0f;
        public float ZoomAmount { get { return _zoom; } set { _zoom = value; } }
        /// <summary>
        /// The aspect ratio of the camera, computed from the Viewport.
        /// </summary>
        protected float _aspectRatio = 1.0f;
        public float AspectRatio { get { return _aspectRatio; } set { _aspectRatio = value; } }
        /// <summary>
        /// The near clipping plane, when an object is within this distance
        /// it will begin to be clipped.
        /// </summary>
        protected float _nearPlane = DEFAULT_NEAR_PLANE;
        public float NearPlane { get { return _nearPlane; } }
        /// <summary>
        /// The far clipping plane, when an object is outside this distance
        /// it will begin to be clipped.
        /// </summary>
        protected float _farPlane = DEFAULT_FAR_PLANE;
        public float FarPlane { get { return _farPlane; } }
        /// <summary>
        /// The field of view angle used when determining the viewing frustum.
        /// </summary>
        protected float _fovX = DEFAULT_FOV;
        public float FOVX { get { return _fovX; } }
        /// <summary>
        /// The Pitch rotation value. Defines a rotation around the X Axis.
        /// (Up and Down rotation).
        /// </summary>
        public float Pitch { get { return _rotation.X; } }
        /// <summary>
        /// The Yaw rotation value. Defines a rotation around the Y Axis.
        /// (Left and Right rotation).
        /// </summary>
        public float Yaw { get { return _rotation.Y; } }
        /// <summary>
        /// The Roll rotation value. Defines a rotation around the Z Axis.
        /// (Clockwise and Counterclockwise rotation).
        /// </summary>
        public float Roll { get { return _rotation.Z; } }
        /// <summary>
        /// The Viewport currently used by the game. Used to calculate
        /// the aspect ration.
        /// </summary>
        private Viewport _viewport;

        /// <summary>
        /// Creates a new 3D camera.
        /// </summary>
        /// <param name="viewport">The Viewport the game is using.</param>
        /// <param name="position">The position of the camera in the world.</param>
        /// <param name="target">The direction the camera is looking in the world.</param>
        public Camera3D(Viewport viewport, Vector3 position, Vector3 target)
            : base(null, position, target, Color.White)
        {
            _viewport = viewport;

            _aspectRatio = _viewport.AspectRatio;
        }

        /// <summary>
        /// Initializes the camera.  Sub-classes should call base.Initialize()
        /// after their initialization.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            _projection = Matrix.CreatePerspectiveFieldOfView(_fovX, _viewport.AspectRatio,
                _nearPlane, _farPlane);
        }
    }
}