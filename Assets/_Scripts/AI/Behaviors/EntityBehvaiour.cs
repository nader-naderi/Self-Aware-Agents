
using UnityEngine;
using ArtificialLife.BehaviourTree;
namespace ArtificialLife
{
    public class EntityBehvaiour : BTTree
    {
        [SerializeField] private EEntityType Type;

        public static float Speed { get; private set; } = 2f;

        protected override Node SetupTree()
        {
            throw new System.NotImplementedException();
        }
    }
}
