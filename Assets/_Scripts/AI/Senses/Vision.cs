using UnityEngine;

namespace ArtificialLife
{
    public class Vision : MonoBehaviour, ISensibale
    {
        [SerializeField] private EntityBehvaiour agent;
        public float Range { get; set; }

        public EEntityType[] types { get; }

        private int wantedTag = 0;

        public bool IsSensing()
        {
            return false;
        }

        private void OnTriggerStay(Collider other)
        {
            string tag = other.tag;
            Vision entitiesVision = null;

            if (!other.TryGetComponent(out EntityBehvaiour entity)) return;

            GameObject target = other.gameObject;

            if (!entitiesVision)
                entitiesVision = entity.GetComponentInChildren<Vision>();
            
            Vector3 agentPos = transform.position;
            Vector3 targetPos = entitiesVision.transform.position;
            Vector3 direction = targetPos - agentPos;

            float length = direction.magnitude;

            direction.Normalize();

            Ray ray = new Ray(agentPos, direction);

            RaycastHit[] hits;

            hits = Physics.RaycastAll(ray, length);
            Debug.DrawLine(targetPos, agentPos, Color.red);

            int iterations;

            for (iterations = 0; iterations < hits.Length; iterations++)
            {
                GameObject hitObj;

                hitObj = hits[iterations].collider.gameObject;
                tag = hitObj.tag;

                if (tag.Equals("Barrier"))
                    return;
            }

            // TODO:
            // Target is Visble, Do something with this knowledge.
            // What is my need?
            // What is the type of the object?
            // Is the object usefull for my current need fullfilment?
            // if yes, proceed to interact with it.


            Debug.DrawLine(targetPos, agentPos, Color.green);
        }
    }
}
