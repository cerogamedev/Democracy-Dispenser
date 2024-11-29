using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemocracyDispenser
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "Assets/Scripts/Player", order = 1)]

    public class PlayerStatsSO : ScriptableObject
    {
        public float HP, Damage, AttackSpeed, GadgetCoolDown, MovementSpeed, Durability, XPGain, Resource, 
        Gathering, Map, CritChance, CritDamage, Dodge, Luck, LifeSteal;
    }
}
