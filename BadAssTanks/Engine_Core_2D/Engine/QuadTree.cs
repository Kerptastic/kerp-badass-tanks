using System.Collections.Generic;
using EngineCore2D.Engine;
using EngineCore2D.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using EngineCore2D.Misc;

namespace Engine_Core_2D.Engine
{
    /// <summary>
    /// 
    /// </summary>
    public class QuadTree : GameObject2D
    {
        /// <summary>
        /// Constants for the Quad Tree division rules.
        /// </summary>
        private const int MAX_OBJECTS_IN_CONTAINER = 3;
        private const int MAX_QUAD_TREE_DEPTH = 4;

        /// <summary>
        /// The child nodes of this Quad Tree Node.
        /// </summary>
        private QuadTree[] _childNodes;
        public QuadTree[] ChildNodes { get { return _childNodes; } }
        /// <summary>
        /// The list of objects contained within this QuadTree Node.
        /// </summary>
        private List<GameObject2D> _objects;
        public List<GameObject2D> Objects { get { return _objects; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="xLocation"></param>
        /// <param name="yLocation"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public QuadTree(CustomSprite sprite, int xLocation, int yLocation, int width, int height)
            : base(sprite, xLocation, yLocation, width, height, Color.White)
        {
            _objects = new List<GameObject2D>();
            _childNodes = null;
            _boundingRectangle = new Rectangle(xLocation, yLocation, width, height);
        }

        /// <summary>
        /// Adds a game object to the quad.  If the quad has too many
        /// objects in it, and hasn't been divided already, it will divide
        /// itself and move its game objects into the children nodes.
        /// </summary>
        /// <param name="gameObj">The object to add to the QuadTree.</param>
        public void AddObject(GameObject2D gameObj)
        {
            if (this._boundingRectangle.Contains(gameObj.BoundingRectangle))
            {
                if (this._childNodes == null)
                {
                    this._objects.Add(gameObj);

                    if (_objects.Count >= MAX_OBJECTS_IN_CONTAINER)
                    {
                        this.Divide();

                        List<GameObject2D> nonFitOnRedistribute = new List<GameObject2D>();

                        for (int i = 0; i < this._objects.Count; i++)
                        {
                            GameObject2D currentObj = this._objects[i];

                            if (this._childNodes[0]._boundingRectangle.Contains(currentObj.BoundingRectangle))
                            {
                                this._childNodes[0].AddObject(currentObj);
                            }
                            else if (this._childNodes[1]._boundingRectangle.Contains(currentObj.BoundingRectangle))
                            {
                                this._childNodes[1].AddObject(currentObj);
                            }
                            else if (this._childNodes[2]._boundingRectangle.Contains(currentObj.BoundingRectangle))
                            {
                                this._childNodes[2].AddObject(currentObj);
                            }
                            else if (this._childNodes[3]._boundingRectangle.Contains(currentObj.BoundingRectangle))
                            {
                                this._childNodes[3].AddObject(currentObj);
                            }
                            else
                            {
                                nonFitOnRedistribute.Add(currentObj);
                            }
                        }

                        this._objects.Clear();
                        this._objects.AddRange(nonFitOnRedistribute);
                    }
                }
                else
                {
                    if (this._childNodes[0]._boundingRectangle.Contains(gameObj.BoundingRectangle))
                    {
                        this._childNodes[0].AddObject(gameObj);
                    }
                    else if (this._childNodes[1]._boundingRectangle.Contains(gameObj.BoundingRectangle))
                    {
                        this._childNodes[1].AddObject(gameObj);
                    }
                    else if (this._childNodes[2]._boundingRectangle.Contains(gameObj.BoundingRectangle))
                    {
                        this._childNodes[2].AddObject(gameObj);
                    }
                    else if (this._childNodes[3]._boundingRectangle.Contains(gameObj.BoundingRectangle))
                    {
                        this._childNodes[3].AddObject(gameObj);
                    }
                    else
                    {
                        this._objects.Add(gameObj);
                    }
                }
            }
        }

        /// <summary>
        /// Divides this quad into 4 smaller quads.
        /// </summary>
        public void Divide()
        {
            this._childNodes = new QuadTree[4];

            this._childNodes[0] = new QuadTree(_sprite,
                this._boundingRectangle.X,
                this._boundingRectangle.Y,
                this._boundingRectangle.Width / 2,
                this._boundingRectangle.Height / 2);
            this._childNodes[1] = new QuadTree(_sprite,
                this._boundingRectangle.X + this._boundingRectangle.Width / 2,
                this._boundingRectangle.Y,
                this._boundingRectangle.Width / 2,
                this._boundingRectangle.Height / 2);
            this._childNodes[2] = new QuadTree(_sprite,
                this._boundingRectangle.X,
                this._boundingRectangle.Y + this._boundingRectangle.Height / 2,
                this._boundingRectangle.Width / 2,
                this._boundingRectangle.Height / 2);
            this._childNodes[3] = new QuadTree(_sprite,
                this._boundingRectangle.X + this._boundingRectangle.Width / 2,
                this._boundingRectangle.Y + this._boundingRectangle.Height / 2,
                this._boundingRectangle.Width / 2,
                this._boundingRectangle.Height / 2);
        }

        /// <summary>
        /// A possibly recursive method that returns the
        /// smallest quad that contains the specified rectangle
        /// </summary>
        /// <param name="rect">The rectangle to check</param>
        /// <returns>The smallest quad that contains the rectangle</returns>
        public QuadTree GetObjectsContainingQuad(GameObject2D gameObject)
        {
            if (this._boundingRectangle.Contains(gameObject.BoundingRectangle))
            {
                if (this._childNodes != null)
                {
                    QuadTree returned;

                    for (int i = 0; i < this._childNodes.Length; i++)
                    {
                        returned = this._childNodes[i].GetObjectsContainingQuad(gameObject);

                        if (returned != null)
                        {
                            return returned;
                        }
                    }
                }
                return this;
            }
            // Return null if this quad doesn't completely contain
            // the rectangle that was passed in
            return null;
        }

        /// <summary>
        /// Draws the QuadTree and its child nodes to the screen.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch used to draw the Quad Tree.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this._childNodes != null)
            {
                for (int i = 0; i < this._childNodes.Length; i++)
                {
                    this._childNodes[i].Draw(spriteBatch);
                }
            }

            Utilities.DrawBoxOutline(spriteBatch, _sprite.Texture, this._boundingRectangle);
        }
    }
}


/*
		/// <summary>
		/// Recursively populates a list with all of the rectangles in this
		/// quad and any subdivision quads.  Use the "AddRange" method of
		/// the list class to add the elements from one list to another.
		/// </summary>
		/// <returns>A list of rectangles</returns>
		public List<Rectangle> GetAllRectangles()
		{
			List<Rectangle> rects = new List<Rectangle>();

            rects.Add(_boundingRectangle);
            if (_childNodes != null)
            {
                for (int i = 0; i < _childNodes.Length; i++)
                {
                    rects.AddRange(_childNodes[i].GetAllRectangles());
                }
            }

			return rects;
		}

		
		#endregion
	}
}

}
*/