using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

namespace DemocracyDispenser
{
    public class WeaponFire : MonoBehaviour
    {
        public WeaponsSO weaponFeature;
        private Sprite GunSprite;
        private float FireRate;
        private float FirePower;
        public GameObject BulletPrefab;
        private float Range;
        private float BulletDamage;
        private int PiercingTimes;

        private float _fireRate = 0;
        public Transform EdgePoint;
        private PlayerController player;
        private PlayerStats stats;
        private Animator anim;
        private GameObject[] allEnemies;
        private GameObject closestEnemy;
        void Awake()
        {
            this.GetComponent<SpriteRenderer>().sprite = weaponFeature.GunSprite;
            FireRate = weaponFeature.FireRate;
            FirePower = weaponFeature.FirePower;
            Range = weaponFeature.Range;
            BulletDamage = weaponFeature.BulletDamage;
            PiercingTimes = weaponFeature.PiercingTimes;
            GunSprite = weaponFeature.GunSprite;
        }
        void Start()
        {
            //find edge point
            anim = GetComponent<Animator>();
            player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
            stats = PlayerStats.Instance;
            _fireRate = FireRate;
        }

        void Update()
        {
            allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            closestEnemy = GetClosestEnemy();
            IRotateTowards(closestEnemy.transform.position, this.gameObject);
            RateCalculation();
            RotateToEnemy();
            FireRate = weaponFeature.FireRate - stats.AttackSpeed;
        }
        public void RotateToEnemy()
        {
            if (transform.position.x > closestEnemy.transform.position.x) {transform.localScale = new (1,-1,1);}
            else
            {transform.localScale = new (1,1,1);}
        }
        GameObject GetClosestEnemy()
        {
            GameObject closestHere = gameObject;
            float leastDistance = Mathf.Infinity;
            foreach(var enemy in allEnemies)
            {
                float distanceHere = Vector2.Distance(transform.position, enemy.transform.position);
                if (distanceHere < leastDistance)
                {
                    leastDistance = distanceHere;
                    closestHere = enemy;
                }
            }
            return closestHere;
        }
        public void PullTheTrigger()
        {
            if (Vector2.Distance(transform.position,closestEnemy.transform.position)<Range && allEnemies.Length>0)
            {
                GameObject bullet = Instantiate(BulletPrefab, EdgePoint.transform.position, Quaternion.identity);
                IRotateTowards(closestEnemy.transform.position, bullet);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(transform.right*FirePower, ForceMode2D.Force);
                PlayerBullet bulletScript =  bullet.GetComponent<PlayerBullet>();
                bulletScript.Damage = BulletDamage + stats.Damage;
                bulletScript.FireForce = FirePower;
                bulletScript.PiercingCount = PiercingTimes;
            }
        }
        public void RateCalculation()
        {
            _fireRate-=Time.deltaTime;
            if (_fireRate<=0)
            {
                PullTheTrigger();
                _fireRate = FireRate;
            }
        }
        public void IRotateTowards(Vector3 targetPosition, GameObject rotateObject)
        {
                Vector2 direction = targetPosition - transform.position;

                float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                rotateObject.transform.rotation = rotation;
        }
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Range);
        }
    }
}
