using UnityEngine;

namespace ArtificialLife
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            
        }
    }
}
