using UnityEngine;

namespace ArtificialLife.BehaviourTree
{
    public abstract class BTTree : MonoBehaviour
    {
        private Node _root = null;

        protected virtual void Start()
        {
            _root = SetupTree();
        }

        protected virtual void Update()
        {
            if (_root != null)
                _root.Evaluate();
        }

        protected abstract Node SetupTree();
    }
}
