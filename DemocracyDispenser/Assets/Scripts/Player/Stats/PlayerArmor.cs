using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemocracyDispenser
{
    public class PlayerArmor : MonoBehaviour, IStat
    {
        public float DefaultValue { get ; set ; }
        public float InUsageValue { get ; set ; }

        public void SetInUsageValue(float amount)
        {
            
        }

        public void UpgradeUsagePercent(float percentAmount)
        {
        }

        void Start()
        {
            InUsageValue = GetComponent<PlayerController>().Stats.Armor;
            DefaultValue = InUsageValue;
        }

        void Update()
        {
        
        }
    }
}
