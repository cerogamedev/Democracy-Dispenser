using System.IO.Enumeration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemocracyDispenser
{
    public class EnemySpawner : MonoBehaviour
    {
        private Transform XLimit, YLimit;
        public GameObject Sign;
        public GameObject Enemy;
        public GameObject[] Stones;
        public int StoneCount;

        void Start()
        {
            GameObject _XLimit = GameObject.Find("X");
            XLimit = _XLimit.transform;
            GameObject _YLimit = GameObject.Find("Y");
            YLimit = _YLimit.transform;

            for (int i=0; i<StoneCount; i++)
            {
                int whichStone = Random.Range(0, Stones.Length);
                float RandomX = Random.Range(-XLimit.position.x,XLimit.position.x);
                float RandomY = Random.Range(-YLimit.position.y,YLimit.position.y);
                Vector2 spawnPos = new Vector2(RandomX,RandomY);
                Instantiate(Stones[whichStone],spawnPos, Quaternion.identity);
            }
            StartCoroutine(Spawner());
        }

        void Update()
        {
        
        }
        public IEnumerator Spawner()
        {
            while(true)
            {
                float XPoint = Random.Range(-XLimit.position.x,XLimit.position.x);
                float YPoint = Random.Range(-YLimit.position.y,YLimit.position.y);
                Vector2 spawnPoint = new Vector2(XPoint, YPoint);
                GameObject _sign = Instantiate(Sign, spawnPoint, Quaternion.identity);
                yield return new WaitForSeconds(2f);
                Destroy(_sign);
                Instantiate(Enemy, spawnPoint, Quaternion.identity);
            }
        }
    }
}
