
using UnityEngine;

namespace ArtificialLife
{
    public class Obstacle : MonoBehaviour, IAttenuatable
    {
        [SerializeField, Range(1, 64)] private float attenuatable = 1;
        public float Attenuatable { get => attenuatable; }
    }
}
