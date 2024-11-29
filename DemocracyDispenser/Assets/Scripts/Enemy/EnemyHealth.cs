using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemocracyDispenser
{
    public class EnemyHealth : MonoBehaviour
    {
        private EnemyControl enemy;
        private EnemySO stats;
        private float _health, _maxHealth;

        public GameObject DropItem;
        void Start()
        {
            enemy = GetComponent<EnemyControl>();
            stats = enemy.enemyStat;
            _maxHealth = stats.Health;
            _health = _maxHealth;
        }
        public void SetHealth(float amount)
        {
            _health += amount;
        }
        void Update()
        {
            if (_health<=0)
            {
                Instantiate(DropItem, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
