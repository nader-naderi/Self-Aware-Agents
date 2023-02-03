using ArtificialLife.BehaviourTree;

using UnityEngine;

namespace ArtificialLife
{
    public class TaskWander : Node
    {
        Transform transform;
        Vector3[] waypoints;

        private int currentWaiypointIndex = 0;
        private float waitTime = 1;
        private float waitCounter = 0;
        private bool isWaiting = false;

        public TaskWander(Transform transform, Vector3[] waypoints)
        {
            this.transform = transform;
            this.waypoints = waypoints;
        }

        public override NodeState Evaluate()
        {
            if (isWaiting)
            {
                waitCounter += Time.deltaTime;
                if (waitCounter < waitTime)
                    isWaiting = false;
            }
            else
            {
                Vector3 wp = waypoints[currentWaiypointIndex];

                if (Vector3.Distance(transform.position, wp) < 0.01f)
                {
                    transform.position = wp;
                    waitCounter = 0;
                    isWaiting = true;

                    currentWaiypointIndex = (currentWaiypointIndex + 1) % waypoints.Length;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, wp, EntityBehvaiour.Speed * Time.deltaTime);
                    transform.LookAt(wp);
                }
            }

            state = NodeState.RUNNING;
            return state;
        }
    }
}
