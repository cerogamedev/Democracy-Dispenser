using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

namespace DemocracyDispenser
{
    public class PlayerHealth : MonoBehaviour, IStat
    {
        public float DefaultValue { get ; set ; }
        public float InUsageValue { get ; set ; }
        public float currentHealth;
        public float regenerationHealth {get; set;}
        public float regenerationSpeed {get; set;}
        public Slider HealthBar;
        private PlayerStats stats;
        public void SetInUsageValue(float amount)
        {
            InUsageValue += amount;
        }

        public void UpgradeUsagePercent(float percentAmount)
        {
            InUsageValue = DefaultValue + (percentAmount/100)*DefaultValue;
        }

        public void SetCurrentHealth(float amount)
        {
            currentHealth+= amount;
        }

        void Start()
        {
            DefaultValue = PlayerStats.Instance.HP;
            InUsageValue = DefaultValue;
            currentHealth = InUsageValue;
            stats = PlayerStats.Instance;
        }

        void Update()
        {
            InUsageValue = stats.HP;
            HealthBar.value = currentHealth/InUsageValue;
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("EnemyBullet"))
            {
                //player hit from enemy bullet
            }
            if (other.CompareTag("Enemy"))
            {
                if (other.GetComponent<EnemyControl>() != null)
                {
                    SetCurrentHealth(-other.GetComponent<EnemyControl>().enemyStat.Damage + stats.Durability);
                    Debug.Log("Player take damage from "+ other.name);
                }
            }
        }
    }
}
