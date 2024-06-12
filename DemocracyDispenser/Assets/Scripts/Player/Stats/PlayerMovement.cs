using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemocracyDispenser
{
    public class PlayerMovement : MonoBehaviour, IStat
    {
        public float DefaultValue { get; set ;}
        public float InUsageValue { get; set;}
        private PlayerStatsSO playerStats;

        public void SetInUsageValue(float amount)
        {
            InUsageValue += amount;
        }

        public void UpgradeUsagePercent(float percentAmount)
        {
            InUsageValue = DefaultValue + (percentAmount/100)*DefaultValue;
        }
        void Start()
        {
            playerStats = PlayerController.Instance.Stats;
            DefaultValue = playerStats.PlayerSpeed;
            InUsageValue = DefaultValue;
        }
    }
}
