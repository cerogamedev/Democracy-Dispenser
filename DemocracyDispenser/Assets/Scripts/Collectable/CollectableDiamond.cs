using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemocracyDispenser
{
    public class CollectableDiamond : MonoBehaviour
    {
        public int ItemPrice;
        public float CollectSpeed;
        public bool GoToPlayer = false;
        private GameObject player;
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            ItemPrice = Random.Range(2,6);
        }

        void Update()
        {
            if (GoToPlayer)
            {
                transform.position =  Vector2.Lerp(transform.position,player.transform.position, CollectSpeed/100 );
            }
            if (Vector2.Distance(transform.position,player.transform.position)<0.3f)
            {
                Wallet.Instance.Diamond += ItemPrice;
                Destroy(gameObject);
            }
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")){GoToPlayer=true;}
        }
    }
}
