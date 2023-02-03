using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace ArtificialLife
{
    public static class DataBase
    {
        public static Dictionary<string, float> obstacleTypes = new Dictionary<string, float>()
        {
            { "Wall", 2f },
            { "Stone", 2.5f },
            { "Wood", 1f },
            { "Metal", 10f }
        };
            
        
        public static bool IsFood(EEntityType target)
        {
            return  target == EEntityType.Fruit &&
                    target == EEntityType.Vegetable && 
                    target == EEntityType.Meat;
        }

        public static bool IsDrink(EEntityType target)
        {
            return target == EEntityType.WaterSource;
        }

        public static float GetObstacleAttenuation(Vector3 emitterPos, Vector3 recieverPos)
        {
            if (obstacleTypes.Count <= 0) 
                return 0;

            float attenuation = 0f;

            Vector3 direction = recieverPos - emitterPos;

            float distance = direction.magnitude;

            direction.Normalize();

            Ray ray = new Ray (emitterPos, direction);

            RaycastHit[] hits = Physics.RaycastAll(ray, distance);

            for (int i = 0; i < hits.Length; i++)
            {
                GameObject obj;

                string tag;

                obj = hits[i].collider.gameObject;

                tag = obj.tag;

                if (obstacleTypes.ContainsKey(tag))
                    attenuation += obstacleTypes[tag];
            }

            return attenuation;
        }
    }
}
