using ArtificialLife.BehaviourTree;

using UnityEngine;

namespace ArtificialLife
{
    public class AgentBehaviour : EntityBehvaiour
    {
        [SerializeField] private Animator anim;
        private Vector3[] waypoints;

        private void Awake()
        {
            InitializeWaypoints();
        }

        protected override void Start()
        {
            base.Start();
        }

        private void InitializeWaypoints()
        {
            waypoints = new Vector3[4];

            for (int i = 0; i < waypoints.Length; i++)
            {
                waypoints[i] = new Vector3(transform.position.x + Random.Range(-10f, 10f), 0, transform.position.z + Random.Range(-10f, 10f));
            }
        }

        protected override Node SetupTree()
        {
            Node root = new TaskWander(transform, waypoints);

            return root;
        }
    }
}