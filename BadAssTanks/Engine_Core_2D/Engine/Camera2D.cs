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
        /// 
        /// </summary>
        protected float _zoom;
        public float ZoomAmount { get { return _zoom; } set { _zoom = value; } }
        /// <summary>
        /// 
        /// </summary>
        protected float _aspectRatio;
        public float AspectRatio { get { return _aspectRatio; } set { _aspectRatio = value; } }
        /// <summary>
        /// 
        /// </summary>
        protected float _rotation;
        public float Rotation { get { return _rotation; } set { _rotation = value; } }
        
        /// <summary>
        /// 
        /// </summary>
        protected Matrix _view;
        public Matrix View { get { return _view; } }
        /// <summary>
        /// 
        /// </summary>
        protected GameObject2D _targetObjectToFollow = null;
        /// <summary>
        /// 
        /// </summary>
        protected Viewport _viewport;

        /// <summary>
        /// Creates a new 2D Camera that will not be clamped to a Game Object.
        /// </summary>
        /// <param name="viewport">The viewport displaying the game sprites.</param>
        /// <param name="position">The initial position for the camera.</param>
        public Camera2D(Viewport viewport, Vector2 position)
            : this(viewport, position, null)
        {
        }

        /// <summary>
        /// Creates a new 2D Camera that is clamped to a given Game Object.
        /// </summary>
        /// <param name="viewport">The viewport displaying the game sprites.</param>
        /// <param name="position">The initial position for the camera.</param>
        /// <param name="objectToFollow">The instance of a Game Object to follow.</param>
        public Camera2D(Viewport viewport, Vector2 position, GameObject2D objectToFollow)
            : base(position.X, position.Y)
        {
            this._viewport = viewport;
            this._position = position;

            this._zoom = 1.0f;
            this._rotation = 0.0f;
            
            this._aspectRatio = (float)viewport.Width / (float)viewport.Height;
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
            this._rotation = Utilities.ClampAngle(_rotation);

            //setup the view, always rotate and scale first, then move
            //to ensure the scales and rotations happen around the origin.
            this._view = Matrix.CreateRotationZ(_rotation) *
                         Matrix.CreateScale(new Vector3(_zoom, _zoom, 1)) *
                         Matrix.CreateTranslation(_position.X, _position.Y, 0);
        }

        /// <summary>
        /// Updates the position of the camera is there is a target
        /// object to be following. This implements the ability to 
        /// have the camera locked onto a players position and follow
        /// it.
        /// </summary>
        private void UpdatePosition()
        {
            if(_targetObjectToFollow != null)
            {
                _position.X = _targetObjectToFollow.X;
                _position.Y = _targetObjectToFollow.Y;
            }
        }

        /// <summary>
        /// Increments (or decrements if negative) the zoom level
        /// of the camera.
        /// </summary>
        /// <param name="amount">The amount to zoom the camera.</param>
        public void Zoom(float amount)
        {

        }
    }
}