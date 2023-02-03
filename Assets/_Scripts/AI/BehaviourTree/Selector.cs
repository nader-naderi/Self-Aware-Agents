using System.Collections.Generic;

namespace ArtificialLife.BehaviourTree
{
    public class Selector : Node
    {
        public Selector() : base() { }
        public Selector(List<Node> children) : base(children) { }
        public override NodeState Evaluate()
        {
            foreach (Node node in childern)
            {
                switch (node.Evaluate())
                {
                    case NodeState.RUNNING:
                        continue;
                    case NodeState.SUCCESS:
                        state = NodeState.RUNNING;
                        break;
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        break;
                    default:
                        break;
                }
            }

            state = NodeState.FAILURE;
            return state;
        }
    }
}
