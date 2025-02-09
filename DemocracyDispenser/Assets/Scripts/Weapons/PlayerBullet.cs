using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DemocracyDispenser
{
    public class PlayerBullet : MonoBehaviour
    {
        public BulletType thisBulletType;
        public float Damage;
        private Rigidbody2D rb;
        public float FireForce;
        public int PiercingCount;
        public GameObject DeadBulletTarget;
        private List<GameObject> enemies = new List<GameObject>();
        private bool isPiercing = false;
        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        void Start()
        {
            Destroy(this.gameObject, 10f);

        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<EnemyControl>()!=null)
            {
                switch(thisBulletType)
                {
                    case BulletType.GunBullet:
                        other.gameObject.GetComponent<EnemyHealth>().SetHealth(-Damage);
                        Destroy(gameObject);
                    break;
                    case BulletType.ElectricBullet:
                        isPiercing = true;
                        enemies.Clear();
                        GameObject[] _enemies = GameObject.FindGameObjectsWithTag("Enemy");
                        if (_enemies.Length == 1)
                        {
                            other.gameObject.GetComponent<EnemyHealth>().SetHealth(-Damage);
                            Destroy(this.gameObject);
                        }
                        else
                        {
                            for (int i=0; i<_enemies.Length;i++)
                            {
                                enemies.Add(_enemies[i]);
                            }
                            enemies.Remove(other.gameObject);
                            int chosenEnemy = Random.Range(0,enemies.Count);
                            if (enemies[chosenEnemy] != null)
                            {
                                PiercingCount-=1;
                                rb.velocity = Vector2.zero;
                                if (PiercingCount == 0){Destroy(this.gameObject);}
                                DeadBulletTarget = enemies[chosenEnemy];
                            }
                            else{Destroy(gameObject);}
                            other.gameObject.GetComponent<EnemyHealth>().SetHealth(-Damage);
                            
                        }
                    break;

                    case BulletType.DeadBullet:
                        other.gameObject.GetComponent<EnemyHealth>().SetHealth(-Damage);
                        Destroy(this.gameObject);
                    break;
                }

            }
        }
        public void IRotateTowards(Vector3 targetPosition, GameObject rotateObject)
        {
            Vector2 direction = targetPosition - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            rotateObject.transform.rotation = rotation;
        }
        void Update()
        {

            if (isPiercing)
            {
                if (DeadBulletTarget!= null)
                {
                    transform.position = Vector2.Lerp(transform.position, DeadBulletTarget.transform.position, FireForce/1000);
                    IRotateTowards(DeadBulletTarget.transform.position, this.gameObject);
                }
            }

        }
    }
    public enum BulletType
    {
        GunBullet,
        ElectricBullet,
        DeadBullet
    }
}
