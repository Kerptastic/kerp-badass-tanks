using System.Collections.Generic;
using KerpEngine.Engine_2D.Sprites;
using KerpEngine.Global;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace KerpEngine.Engine_2D
{
    /// <summary>
    /// A Quad Tree Spatial Structure used for 2 dimensional scenes for clipping, object organization
    /// and collision detection.
    /// </summary>
    public class QuadTree : SpatialStructure<GameObject, AABB>
    {
        /// <summary>
        /// Constants for the Quad Tree division rules.
        /// </summary>
        private const int MAX_OBJECTS_IN_CONTAINER = 3;
        private const int MAX_QUAD_TREE_DEPTH = 4;
        
        /// <summary>
        /// Creates a new Quad Tree at the given X/Y location with the given width and height.
        /// </summary>
        /// <param name="xLocation">The x location where the Quad Tree is located.</param>
        /// <param name="yLocation">The y location where the Quad Tree is located.</param>
        /// <param name="width">The width of the Quad Tree.</param>
        /// <param name="height">The height of the Quad Tree.</param>
        public QuadTree(QuadTree parent, float xLocation, float yLocation, float width, float height)
        {
            _parent = parent;
            _objects = new List<GameObject>();
            _childNodes = null;
            _boundingVolume = new AABB(new Vector3(xLocation, yLocation, 0.0f), width, height);
        }

        /// <summary>
        /// Adds a game object to the quad.  If the quad has too many
        /// objects in it, and hasn't been divided already, it will divide
        /// itself and move its game objects into the children nodes.
        /// </summary>
        /// <param name="gameObj">The object to add to the QuadTree.</param>
        public override void AddObject(GameObject gameObj)
        {
            if (_boundingVolume.Contains(gameObj.BoundingVolume))
            {
                if (_childNodes == null)
                {
                    _objects.Add(gameObj);

                    if (_objects.Count >= MAX_OBJECTS_IN_CONTAINER)
                    {
                        Divide();

                        List<GameObject> nonFitOnRedistribute = new List<GameObject>();

                        for (int i = 0; i < _objects.Count; i++)
                        {
                            GameObject currentObj = _objects[i];

                            if (_childNodes[0].BoundingVolume.Contains(currentObj.BoundingVolume))
                            {
                                _childNodes[0].AddObject(currentObj);
                            }
                            else if (_childNodes[1].BoundingVolume.Contains(currentObj.BoundingVolume))
                            {
                                _childNodes[1].AddObject(currentObj);
                            }
                            else if (_childNodes[2].BoundingVolume.Contains(currentObj.BoundingVolume))
                            {
                                _childNodes[2].AddObject(currentObj);
                            }
                            else if (_childNodes[3].BoundingVolume.Contains(currentObj.BoundingVolume))
                            {
                                _childNodes[3].AddObject(currentObj);
                            }
                            else
                            {
                                nonFitOnRedistribute.Add(currentObj);
                            }
                        }

                        _objects.Clear();
                        _objects.AddRange(nonFitOnRedistribute);
                    }
                }
                else
                {
                    if (_childNodes[0].BoundingVolume.Contains(gameObj.BoundingVolume))
                    {
                        _childNodes[0].AddObject(gameObj);
                    }
                    else if (_childNodes[1].BoundingVolume.Contains(gameObj.BoundingVolume))
                    {
                        _childNodes[1].AddObject(gameObj);
                    }
                    else if (_childNodes[2].BoundingVolume.Contains(gameObj.BoundingVolume))
                    {
                        _childNodes[2].AddObject(gameObj);
                    }
                    else if (_childNodes[3].BoundingVolume.Contains(gameObj.BoundingVolume))
                    {
                        _childNodes[3].AddObject(gameObj);
                    }
                    else
                    {
                        _objects.Add(gameObj);
                    }
                }
            }
            else
            {
                gameObj.Move(new Vector3());
            }
        }

        /// <summary>
        /// Divides this quad into 4 smaller quads.
        /// </summary>
        public override void Divide()
        {
            _childNodes = new QuadTree[4];

            float x = _boundingVolume.X;
            float y = _boundingVolume.Y;
            float width = _boundingVolume.Width;
            float height = _boundingVolume.Height;

            //top left node
            _childNodes[0] = new QuadTree(this,
                x - (width / 4.0f),
                y + (height / 4.0f),
                width / 2.0f,
                height / 2.0f);

            //top right node
            _childNodes[1] = new QuadTree(this,
                x + (width / 4.0f),
                y + (height / 4.0f),
                width / 2.0f,
                height / 2.0f);

            //bottom left node
            _childNodes[2] = new QuadTree(this,
                x - (width / 4.0f),
                y - (height / 4.0f),
                width / 2.0f,
                height / 2.0f);

            //bottom right node
            _childNodes[3] = new QuadTree(this,
                x + (width / 4.0f),
                y - (height / 4.0f),
                width / 2.0f,
                height / 2.0f);
        }

        /// <summary>
        /// Removes an object from the structure, and prunes nodes if required.
        /// </summary>
        /// <param name="gameObj">The object to remove from the structure.</param>
        public override void RemoveObject(GameObject gameObj)
        {
            if (_objects.Contains(gameObj))
            {
                _objects.Remove(gameObj);
            }
            else
            {
                FindObjectsNode(gameObj).RemoveObject(gameObj);
            }

            if (_parent != null)
            {
                if (QuadTree.GetAllObjectsInNode(_parent).Count == 0)
                {
                    _parent.RedistributeObjects();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameObj"></param>
        /// <returns></returns>
        public override SpatialStructure<GameObject, AABB> FindObjectsNode(GameObject gameObj)
        {
            if (_childNodes == null)
            {
                if (_objects.Contains(gameObj))
                {
                    return this;
                }
            }
            else
            {
                if (_objects.Contains(gameObj))
                {
                    return this;
                }
                else
                {
                    SpatialStructure<GameObject, AABB> returned;

                    for (int i = 0; i < _childNodes.Length; i++)
                    {
                        returned = _childNodes[i].FindObjectsNode(gameObj);

                        if (returned != null)
                        {
                            return returned;
                        }
                    }
                }
            }
            
            return null;
        }

        /// <summary>
        /// Returns the Node that holds the given object.
        /// </summary>
        /// <param name="gameObj">The search object to find the containing node.</param>
        /// <returns>The Node that holds the given object.</returns>
        public override SpatialStructure<GameObject, AABB> GetObjectsContainingNode(GameObject gameObj)
        {
            if (_boundingVolume.Contains(gameObj.BoundingVolume))
            {
                if (_childNodes != null)
                {
                    SpatialStructure<GameObject, AABB> returned;

                    for (int i = 0; i < _childNodes.Length; i++)
                    {
                        returned = _childNodes[i].GetObjectsContainingNode(gameObj);

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
        /// Draws this Quad Tree node on the screen.
        /// </summary>
        /// <param name="graphicsDevice">The Graphics Device to use to draw the Volume.</param>
        /// <param name="effect">The effect to use when drawing.</param>
        public override void Draw(GraphicsDevice graphicsDevice, BasicEffect effect)
        {
            if (_childNodes != null)
            {
                for (int i = 0; i < _childNodes.Length; i++)
                {
                    ((QuadTree)_childNodes[i]).Draw(graphicsDevice, effect);
                }
            }

            _boundingVolume.Draw(graphicsDevice, effect);
        }
    }
}