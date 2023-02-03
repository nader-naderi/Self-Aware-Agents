using System.Collections.Generic;

namespace ArtificialLife.BehaviourTree
{
    public class Sequence : Node
    {
        public Sequence() : base () { }
        public Sequence(List<Node> children) : base(children) { }
        public override NodeState Evaluate()
        {
            bool anyChildIsRunning = false;

            foreach (Node node in childern)
            {
                switch (node.Evaluate())
                {
                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        break;
                    case NodeState.SUCCESS:
                        anyChildIsRunning = true;
                        break;
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        break;
                    default:
                        break;
                }
            }

            state = anyChildIsRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return state;
        }
    }
}
