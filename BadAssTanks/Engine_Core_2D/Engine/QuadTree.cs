
using System.Collections.Generic;
using EngineCore2D.Engine;

namespace Engine_Core_2D.Engine
{
    public class QuadTree
    {
        /// <summary>
        /// 
        /// </summary>
        private List<GameObject2D> _objects;
        public List<GameObject2D> Objects { get { return _objects; } }

        public QuadTree()
        {
            _objects = new List<GameObject2D>();
        }
    }
}
