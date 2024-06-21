using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemocracyDispenser
{
    public class EnemyControl : MonoBehaviour
    {
        private GameObject player;
        public EnemySO enemyStat;
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        void Update()
        {
            switch(enemyStat.enemyType)
            {
                case EnemyType.Basic:
                    Follow(player);
                break;
            }
        }
        public void Follow (GameObject target)
        {
            transform.position = Vector2.Lerp(transform.position, target.transform.position, enemyStat.Speed/100);
        }
    }
}
