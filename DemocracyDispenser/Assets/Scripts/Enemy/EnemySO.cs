using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemocracyDispenser
{
    [CreateAssetMenu(fileName = "EnemyProperties", menuName = "Assets/Scripts/Enemy", order = 1)]

    public class EnemySO : ScriptableObject
    {
        public EnemyLevel enemyLevel;
        public EnemyType enemyType;
        [Header("Common Trait")]
        public float Speed, Damage, Health, Armor;
        public Animation Walk, Attack, Dead;
        [Header("Ranged, RangedWalker")]
        public float FireRange, FireRate;
        [Header("BigBasic")]
        public float RageAttack, JumpPower;
        [Header("Ghost")]
        public float Dodge;
        [Header("Ghost Rider")]
        public float SpawnRate;
        [Header("Worm")]
        public float WormWaitAfterTakeDamage;
    }
    public enum EnemyLevel
    {
        Easy, Medium, Hard
    }
    public enum EnemyType
    {
        Basic,
        Ranged,
        RangedWalker,
        BigBasic,
        Ghost,
        GhostRider,
        Worm,
        RageBasic
    }
}
