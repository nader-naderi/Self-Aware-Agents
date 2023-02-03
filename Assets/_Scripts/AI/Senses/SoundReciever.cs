using System.Collections.Generic;

using UnityEngine;

namespace ArtificialLife
{
    public class SoundReciever : MonoBehaviour, ISensibale
    {
        [SerializeField] private float soundThreshold;
        public EEntityType[] types { get; private set; }
        
        public float Range { get; set; }
        public float SoundThreshold { get => soundThreshold; }

        public virtual void Recieve(float intensity, Vector3 position)
        {
            // TODO:
            // We are hearing something, Behave upon it.
            Debug.Log(position + " Hearing");
        }

        public bool IsSensing()
        {
            return false;
        }

       
    }
}
