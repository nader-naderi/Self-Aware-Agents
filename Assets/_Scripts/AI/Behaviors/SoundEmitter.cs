
using System.Collections.Generic;

using UnityEngine;

namespace ArtificialLife
{
    public class SoundEmitter : MonoBehaviour
    {
        [SerializeField] private float soundIntensity;
        [SerializeField] private float soundAuttenuation;
        [SerializeField] private GameObject emitterObject;
        private Dictionary<int, SoundReciever> recieverMap;

        private void Start()
        {
            recieverMap = new Dictionary<int, SoundReciever>();

            if (!emitterObject)
                emitterObject = gameObject;
        }

        public void Emit()
        {
            GameObject sourceObj = null;
            Vector3 sourcePosition = Vector3.zero;
            float intensity;
            float distance;
            Vector3 emitterPos = emitterObject.transform.position;

            // Compute Attenuation for every reciever.
            foreach (SoundReciever reciever in recieverMap.Values)
            {
                sourceObj = reciever.gameObject;
                sourcePosition = sourceObj.transform.position;
                distance = Vector3.Distance(sourcePosition, emitterPos);
                intensity = soundIntensity;
                intensity -= soundAuttenuation * distance;

                intensity -= DataBase.GetObstacleAttenuation(transform.position,
                    reciever.transform.position);
                
                Debug.Log("A");

                if (intensity < reciever.SoundThreshold)
                    continue;

                reciever.Recieve(intensity, emitterPos);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            SoundReciever reciever = null;

            if (!other.TryGetComponent(out EntityBehvaiour entity)) return;

            if (!reciever)
                reciever = entity.GetComponentInChildren<SoundReciever>();
            Debug.Log("Q");

            int objID = other.gameObject.GetInstanceID();
            if (!recieverMap.ContainsKey(objID))
                recieverMap.Add(objID, reciever);
        }

        private void OnTriggerExit(Collider other)
        {
            SoundReciever reciever = null;

            if (!other.TryGetComponent(out EntityBehvaiour entity)) return;

            if (!reciever)
                return;
            Debug.Log("S");

            int objID = other.gameObject.GetInstanceID();
            recieverMap.Remove(objID);
        }
    }
}
