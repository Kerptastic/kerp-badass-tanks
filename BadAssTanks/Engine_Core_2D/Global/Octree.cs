using System.Collections.Generic;
using KerpEngine.Engine_2D.Sprites;
using KerpEngine.Global;
using Microsoft.Xna.Framework.Graphics;
using KerpEngine.Engine_3D;
using KerpEngine.Engine_3D.Models;
using Microsoft.Xna.Framework;

namespace KerpEngine.Engine_2D
{
    /// <summary>
    /// A Octee Spatial Structure used for 3 dimensional scenes for clipping, object organization
    /// and collision detection.
    /// </summary>
    public class Octree : SpatialStructure<GameObject3D, AABB>
    {
        /// <summary>
        /// Constants for the Octree division rules.
        /// </summary>
        private const int MAX_OBJECTS_IN_CONTAINER = 3;
        private const int MAX_OCTREE_DEPTH = 4;
        
        /// <summary>
        /// Creates a new Octree at the given X/Y location with the given width and height.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="topRight"></param>
        /// <param name="bottomLeft"></param>
        public Octree(CustomModel model, Vector3 topRight, Vector3 bottomLeft)
        {
            _objects = new List<GameObject3D>();
            _childNodes = null;
            _boundingVolume = new AABB(topRight, bottomLeft);
        }

        /// <summary>
        /// Adds a game object to the node.  If the node has too many
        /// objects in it, and hasn't been divided already, it will divide
        /// itself and move its game objects into the children nodes.
        /// </summary>
        /// <param name="gameObj">The object to add to the Octree.</param>
        public override void AddObject(GameObject3D gameObj)
        {
            //if (_boundingVolume.Contains(gameObj.BoundingVolume))
            //{
            //    if (_childNodes == null)
            //    {
            //        _objects.Add(gameObj);

            //        if (_objects.Count >= MAX_OBJECTS_IN_CONTAINER)
            //        {
            //            Divide();

            //            List<GameObject3D> nonFitOnRedistribute = new List<GameObject3D>();

            //            for (int i = 0; i < _objects.Count; i++)
            //            {
            //                GameObject3D currentObj = _objects[i];

            //                if (_childNodes[0].BoundingVolume.Contains(currentObj.BoundingVolume))
            //                {
            //                    _childNodes[0].AddObject(currentObj);
            //                }
            //                else if (_childNodes[1].BoundingVolume.Contains(currentObj.BoundingVolume))
            //                {
            //                    _childNodes[1].AddObject(currentObj);
            //                }
            //                else if (_childNodes[2].BoundingVolume.Contains(currentObj.BoundingVolume))
            //                {
            //                    _childNodes[2].AddObject(currentObj);
            //                }
            //                else if (_childNodes[3].BoundingVolume.Contains(currentObj.BoundingVolume))
            //                {
            //                    _childNodes[3].AddObject(currentObj);
            //                }
            //                else
            //                {
            //                    nonFitOnRedistribute.Add(currentObj);
            //                }
            //            }

            //            _objects.Clear();
            //            _objects.AddRange(nonFitOnRedistribute);
            //        }
            //    }
            //    else
            //    {
            //        if (_childNodes[0].BoundingVolume.Contains(gameObj.BoundingVolume))
            //        {
            //            _childNodes[0].AddObject(gameObj);
            //        }
            //        else if (_childNodes[1].BoundingVolume.Contains(gameObj.BoundingVolume))
            //        {
            //            _childNodes[1].AddObject(gameObj);
            //        }
            //        else if (_childNodes[2].BoundingVolume.Contains(gameObj.BoundingVolume))
            //        {
            //            _childNodes[2].AddObject(gameObj);
            //        }
            //        else if (_childNodes[3].BoundingVolume.Contains(gameObj.BoundingVolume))
            //        {
            //            _childNodes[3].AddObject(gameObj);
            //        }
            //        else
            //        {
            //            _objects.Add(gameObj);
            //        }
            //    }
            //}
        }

        /// <summary>
        /// Divides this node into 8 smaller nodes.
        /// </summary>
        public override void Divide()
        {
            _childNodes = new Octree[8];

            /*
             * float newLeafRadius = m_fLeafRadius / 2.0f;

	D3DXVECTOR3 parentPos = m_pBoundingBox->GetPosition();
	D3DXVECTOR3 tr = m_pBoundingBox->GetMax();
	D3DXVECTOR3 bl = m_pBoundingBox->GetMin();

	//NE Front
	m_pChildren[0] = 
		new COctreeLeaf(this, tr, parentPos, m_iNodeDepth + 1);

	//NW Front
	m_pChildren[1] = 
		new COctreeLeaf(this, D3DXVECTOR3(parentPos.x, tr.y, tr.z), D3DXVECTOR3(bl.x, parentPos.y, parentPos.z), m_iNodeDepth + 1);

	//SW Front
	m_pChildren[2] = 
		new COctreeLeaf(this, D3DXVECTOR3(parentPos.x, parentPos.y, tr.z), D3DXVECTOR3(bl.x, bl.y, parentPos.z), m_iNodeDepth + 1);

	//SE Front
	m_pChildren[3] = 
		new COctreeLeaf(this, D3DXVECTOR3(tr.x, parentPos.y, tr.z), D3DXVECTOR3(parentPos.x, bl.y, parentPos.z), m_iNodeDepth + 1);

	//NE Back
	m_pChildren[4] = 
		new COctreeLeaf(this, D3DXVECTOR3(tr.x, tr.y, parentPos.z), D3DXVECTOR3(parentPos.x, parentPos.y, bl.z), m_iNodeDepth + 1);

	//NW Back
	m_pChildren[5] = 
		new COctreeLeaf(this, D3DXVECTOR3(parentPos.x, tr.y, parentPos.z), D3DXVECTOR3(bl.x, parentPos.y, bl.z), m_iNodeDepth + 1);

	//SW Back
	m_pChildren[6] =
		new COctreeLeaf(this, parentPos, bl, m_iNodeDepth + 1);

	//SE Back
	m_pChildren[7] =
		new COctreeLeaf(this, D3DXVECTOR3(tr.x, parentPos.y, parentPos.z), D3DXVECTOR3(parentPos.x, bl.y, bl.z), m_iNodeDepth + 1);
*/
            //_childNodes[0] = new QuadTree(_boundingVolume.Drawable,
            //    _boundingVolume.X,
            //    _boundingVolume.Y,
            //    _boundingVolume.Width / 2,
            //    _boundingVolume.Height / 2);
            //_childNodes[1] = new QuadTree(_boundingVolume.Drawable,
            //    _boundingVolume.X + _boundingVolume.Width / 2,
            //    _boundingVolume.Y,
            //    _boundingVolume.Width / 2,
            //    _boundingVolume.Height / 2);
            //_childNodes[2] = new QuadTree(_boundingVolume.Drawable,
            //    _boundingVolume.X,
            //    _boundingVolume.Y + _boundingVolume.Height / 2,
            //    _boundingVolume.Width / 2,
            //    _boundingVolume.Height / 2);
            //_childNodes[3] = new QuadTree(_boundingVolume.Drawable,
            //    _boundingVolume.X + _boundingVolume.Width / 2,
            //    _boundingVolume.Y + _boundingVolume.Height / 2,
            //    _boundingVolume.Width / 2,
            //    _boundingVolume.Height / 2);
        }

        /// <summary>
        /// Removes an object from the structure, and prunes nodes if required.
        /// </summary>
        /// <param name="gameObj">The object to remove from the structure.</param>
        public override void RemoveObject(GameObject3D gameObj)
        {
            
        }

        /// <summary>
        /// Returns the Node that holds the given object.
        /// </summary>
        /// <param name="gameObj">The search object to find the containing node.</param>
        /// <returns>The Node that holds the given object.</returns>
        public override SpatialStructure<GameObject3D, AABB> GetObjectsContainingNode(GameObject3D gameObj)
        {
            //if (_boundingVolume.Contains(gameObj.BoundingVolume))
            //{
            //    if (_childNodes != null)
            //    {
            //        SpatialStructure<GameObject3D, AABB> returned;

            //        for (int i = 0; i < _childNodes.Length; i++)
            //        {
            //            returned = _childNodes[i].GetObjectsContainingNode(gameObj);

            //            if (returned != null)
            //            {
            //                return returned;
            //            }
            //        }
            //    }
            //    return this;
            //}
            // Return null if this quad doesn't completely contain
            // the rectangle that was passed in
            return null;
        }
        

        /// <summary>
        /// Draws this Octree node on the screen.
        /// </summary>
        public override void  Draw(GraphicsDevice device, BasicEffect effect)
        {
            //if (_childNodes != null)
            //{
            //    for (int i = 0; i < _childNodes.Length; i++)
            //    {
            //        ((QuadTree)_childNodes[i]).Draw(spriteBatch);
            //    }
            //}

            //_boundingVolume.Draw(spriteBatch);
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

            rects.Add(_boundingVolume);
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