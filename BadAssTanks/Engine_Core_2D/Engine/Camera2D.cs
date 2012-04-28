using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngineCore2D.Misc;

namespace EngineCore2D.Engine
{
    /// <summary>
    /// 
    /// </summary>
    public class Camera2D : GameObject2D
    {
        /// <summary>
        /// The amount of zoom this camera is currently zoomed into.
        /// </summary>
        protected float _zoom;
        public float ZoomAmount { get { return _zoom; } set { _zoom = value; } }
        /// <summary>
        /// The aspect ratio of the camera, computed from the Viewport.
        /// </summary>
        protected float _aspectRatio;
        public float AspectRatio { get { return _aspectRatio; } set { _aspectRatio = value; } }
      
        /// <summary>
        /// The View matrix, which contains the scale, rotation, and translation matrix
        /// which will position the camera for viewing.
        /// </summary>
        protected Matrix _view;
        public Matrix View { get { return _view; } }
        /// <summary>
        /// If this object is set in the constructor, the camera will 
        /// clamp its movement to follow this object.
        /// </summary>
        protected GameObject2D _targetObjectToFollow = null;
        public GameObject2D TargetObject { get { return _targetObjectToFollow; } }
        /// <summary>
        /// The amount of freedom the following object has to move before the camera begins to follow.
        /// </summary>
        protected float _targetMovementCushion;
        public float TargetMovementCushion;
        /// <summary>
        /// The Graphics Device viewport that this camera will be bounded to.
        /// Essentially, the width and height of the viewing area.
        /// </summary>
        protected Viewport _viewport;

        /// <summary>
        /// Creates a new 2D Camera that will not be clamped to a Game Object.
        /// </summary>
        /// <param name="viewport">The viewport displaying the game sprites.</param>
        /// <param name="position">The initial position for the camera.</param>
        public Camera2D(Viewport viewport, Vector2 position)
            : this(viewport, position, null, 0.0f)
        {
        }

        /// <summary>
        /// Creates a new 2D Camera that is clamped to a given Game Object.
        /// </summary>
        /// <param name="viewport">The viewport displaying the game sprites.</param>
        /// <param name="position">The initial position for the camera.</param>
        /// <param name="objectToFollow">The instance of a Game Object to follow.</param>
        /// <param name="targetMovementCushion">The amount of freedom the following object has to move before the camera begins to follow.</param>
        public Camera2D(Viewport viewport, Vector2 position, GameObject2D objectToFollow, float targetMovementCushion)
            : base(position.X, position.Y)
        {
            this._viewport = viewport;
            this._position = position;
            this._targetMovementCushion = targetMovementCushion;

            this._zoom = 1.0f;
            this._rotation = 0.0f;

            this._aspectRatio = (float)this._viewport.Width / (float)this._viewport.Height;
            this._targetObjectToFollow = objectToFollow;

            this.Update();
        }

        /// <summary>
        /// Updates the camera matrices for drawing a new scene.
        /// </summary>
        public void Update() 
        { 
            this.UpdatePosition();

            //Clamp rotation value
            this._rotation = Utilities.ClampAngleDegrees(this._rotation);

            //setup the view, always rotate and scale first, then move
            //to ensure the scales and rotations happen around the origin.
            this._view = Matrix.CreateRotationZ(MathHelper.ToRadians(_rotation)) *
                         Matrix.CreateScale(new Vector3(this._zoom, this._zoom, 1)) *
                         Matrix.CreateTranslation(this._position.X, this._position.Y, 0);
        }

        /// <summary>
        /// Updates the position of the camera is there is a target
        /// object to be following. This implements the ability to 
        /// have the camera locked onto a players position and follow
        /// it.
        /// </summary>
        private void UpdatePosition()
        {
            //TODO: Add in the logic for the following distance buffer
            // Right now, the camera, if there is an object specified,
            // is locked to the target

            if (this._targetObjectToFollow != null)
            {
                this._position.X = this._targetObjectToFollow.X;
                this._position.Y = this._targetObjectToFollow.Y;
            }
        }

        /// <summary>
        /// Increments (or decrements if negative) the zoom level
        /// of the camera.
        /// </summary>
        /// <param name="amount">The amount to zoom the camera.</param>
        public void Zoom(float amount)
        {
            this._zoom += amount;
        }
    }
}