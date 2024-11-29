using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemocracyDispenser
{
    public class PlayerStats : MonoSingleton<PlayerStats>
    {
        public PlayerStatsSO stats;
        public float HP, Damage, AttackSpeed, GadgetCoolDown, MovementSpeed, Durability, XPGain, Resource, 
        Gathering, Map, CritChance, CritDamage, Dodge, Luck, LifeSteal;
        void Awake()
        {
            HP = stats.HP;
            Damage = stats.Damage;
            AttackSpeed = stats.AttackSpeed;
            GadgetCoolDown = stats.GadgetCoolDown;
            MovementSpeed = stats.MovementSpeed;
            Durability = stats.Durability;
            XPGain = stats.XPGain;
            Resource = stats.Resource;
            Gathering = stats.Gathering;
            Map = stats.Map;
            CritChance = stats.CritChance;
            CritDamage = stats.CritDamage;
            Dodge = stats.Dodge;
            Luck = stats.Dodge;
            Luck = stats.Luck;
            LifeSteal = stats.LifeSteal;
        }

        void Update()
        {
            
        }
    }
}
