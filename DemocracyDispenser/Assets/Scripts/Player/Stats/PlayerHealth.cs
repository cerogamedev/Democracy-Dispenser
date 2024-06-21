using System.Collections;
using System.Collections.Generic;
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
        public void SetInUsageValue(float amount)
        {
            InUsageValue += amount;
        }

        public void UpgradeUsagePercent(float percentAmount)
        {
            InUsageValue = DefaultValue + (percentAmount/100)*DefaultValue;
        }
        public void HPRegeneration()
        {
            if (currentHealth != InUsageValue){currentHealth += regenerationHealth;}
        }
        public void SetRegenerationHealth(float speed, float amount)
        {
            regenerationHealth = amount;
            regenerationSpeed = speed;
            InvokeRepeating("HPRegeneration", 0f, regenerationSpeed);
        }
        public void SetCurrentHealth(float amount)
        {
            currentHealth+= amount;
        }

        void Start()
        {
            DefaultValue = PlayerController.Instance.Stats.MaxHealth;
            InUsageValue = DefaultValue;
            currentHealth = InUsageValue;
            InvokeRepeating("HPRegeneration", 0f, regenerationSpeed);
        }

        void Update()
        {
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
                    SetCurrentHealth(-other.GetComponent<EnemyControl>().enemyStat.Damage);
                    Debug.Log("Player take damage from "+ other.name);
                }
            }
        }
    }
}
