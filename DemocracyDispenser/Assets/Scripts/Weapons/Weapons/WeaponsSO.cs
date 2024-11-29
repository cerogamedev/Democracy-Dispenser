using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemocracyDispenser
{
    
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "DemocracyDispenser/WeaponsSO", order = 0)]
    public class WeaponsSO : ScriptableObject 
    {
        public BulletType bulletType;
        public Sprite GunSprite;
        public float FireRate;
        public float FirePower;
        public float Range;
        public float BulletDamage;
        public int PiercingTimes;    
        
    }
}
