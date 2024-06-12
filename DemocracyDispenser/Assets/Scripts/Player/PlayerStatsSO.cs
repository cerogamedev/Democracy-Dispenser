using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemocracyDispenser
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "Assets/Scripts/Player", order = 1)]

    public class PlayerStatsSO : ScriptableObject
    {
        public float PlayerSpeed;
        public float MaxHealth;
        public float HealthRegeneration;
        public float EnergyLevel;
        public float Damage;
        public float CriticalHit;
        public float Armor;
        public float Energy;
        public float ProcessorPower;
        public float ElectricCapacity;
        public float AntiAirDefend;
    }
}
