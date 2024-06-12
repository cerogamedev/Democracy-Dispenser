using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemocracyDispenser
{
    public class EnemyControl : MonoBehaviour
    {
        public EnemySO enemyStat;
        void Start()
        {
        
        }

        void Update()
        {
            switch(enemyStat.enemyType)
            {
                case EnemyType.Basic:
                //follow player
                break;
            }
        }
    }
}
