using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KerpEngine.Global
{
    /// <summary>
    /// Represents an abstract concept of a spatial strucuture, used to
    /// organize objects within a tree.
    /// </summary>
    /// <typeparam name="StoredObject_Type">The type of object to be stored within this structure.</typeparam>
    /// <typeparam name="BoundingShape_Type">The type of bounding volume to be used for this structure.</typeparam>
    public abstract class SpatialStructure<StoredObject_Type, BoundingVolume_Type>
    {
        /// <summary>
        /// 
        /// </summary>
        protected SpatialStructure<StoredObject_Type, BoundingVolume_Type> _parent;
        public SpatialStructure<StoredObject_Type, BoundingVolume_Type> Parent { get { return _parent; } }
        /// <summary>
        /// The list of objects contained within this Structure's Node.
        /// </summary>
        protected List<StoredObject_Type> _objects;
        public List<StoredObject_Type> Objects { get { return _objects; } }
        /// <summary>
        /// The bounding shape around this structures node. Used for placement
        /// and drawing.
        /// </summary>
        protected BoundingVolume_Type _boundingVolume;
        public BoundingVolume_Type BoundingVolume { get { return _boundingVolume; } set { _boundingVolume = value; } }
        /// <summary>
        /// The child nodes of this Quad Tree Node.
        /// </summary>
        protected SpatialStructure<StoredObject_Type, BoundingVolume_Type>[] _childNodes;
        public SpatialStructure<StoredObject_Type, BoundingVolume_Type>[] ChildNodes { get { return _childNodes; } }

        /// <summary>
        /// Adds a game object to the structure.  If the structure has too many
        /// objects in it, and hasn't been divided already, it will divide
        /// itself and move its game objects into the children nodes.
        /// </summary>
        /// <param name="gameObj">The object to add to the structure.</param>
        public abstract void AddObject(StoredObject_Type gameObj);
        /// <summary>
        /// Divides the structure into children nodes, moving the objects in the
        /// node to the child nodes.
        /// </summary>
        public abstract void Divide();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameObj"></param>
        /// <returns></returns>
        public abstract SpatialStructure<StoredObject_Type, BoundingVolume_Type> FindObjectsNode(StoredObject_Type gameObj);
        /// <summary>
        /// A possibly recursive method that returns the
        /// smallest quad that contains the specified rectangle
        /// </summary>
        /// <param name="rect">The rectangle to check</param>
        /// <returns>The smallest quad that contains the rectangle</returns>
        public abstract SpatialStructure<StoredObject_Type, BoundingVolume_Type> GetObjectsContainingNode(StoredObject_Type gameObj);
        /// <summary>
        /// Removes an object from the structure, and prunes nodes if required.
        /// </summary>
        /// <param name="gameObj">The object to remove from the structure.</param>
        public abstract void RemoveObject(StoredObject_Type gameObj);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <param name="effect"></param>
        public abstract void Draw(GraphicsDevice device, BasicEffect effect);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<StoredObject_Type> GetAllObjects()
        {
            SpatialStructure<StoredObject_Type, BoundingVolume_Type> topNode = this;

            while (topNode.Parent != null)
            {
                topNode = topNode.Parent;
            }

            return GetAllObjectsInNode(topNode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static List<StoredObject_Type> GetAllObjectsInNode(SpatialStructure<StoredObject_Type, BoundingVolume_Type> node)
        {
            List<StoredObject_Type> allObjects = new List<StoredObject_Type>();

            allObjects.AddRange(node.Objects);

            if (node.ChildNodes != null)
            {
                for (int nodeCount = 0; nodeCount < node.ChildNodes.Length; nodeCount++)
                {
                    allObjects.AddRange(GetAllObjectsInNode(node.ChildNodes[nodeCount]));
                }
            }

            return allObjects;
        }


        public List<StoredObject_Type> GetMyObjects()
        {
            return GetAllObjectsInNode(this);
        }


        /// <summary>
        /// 
        /// </summary>
        public void RedistributeObjects()
        {
            List<StoredObject_Type> myObjects = GetMyObjects();

            SpatialStructure<StoredObject_Type, BoundingVolume_Type> storedNode;

            //clear out all of the children
            foreach (StoredObject_Type gameObj in myObjects)
            {
                storedNode = FindObjectsNode(gameObj);
                storedNode.RemoveObject(gameObj);
            }

            //clear the children
            _childNodes = null;

            //get the root and readd everything
            SpatialStructure<StoredObject_Type, BoundingVolume_Type> topNode = this;

            while (topNode.Parent != null)
            {
                topNode = topNode.Parent;
            }

            //add all of the objects back in
            foreach (StoredObject_Type gameObj in myObjects)
            {
                topNode.AddObject(gameObj);
            }
        }
    }
}
