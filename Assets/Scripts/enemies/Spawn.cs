using UnityEngine;
using Random = UnityEngine.Random;

namespace enemies
{
    public class Spawn : MonoBehaviour
    {
        public GameObject spawnPoint;
        private float delay;
        private int amountSpawned;
        private int maxAmountSpawned = 5;
        public GameObject[] enemies;
        
        private void Start()
        {
            delay = 3;
            amountSpawned = 0;
            
        }

        void Update()
        {
            GameObject selectedEnemy = enemies[Random.Range(0,enemies.Length)]; 
            if (delay >= 5 && maxAmountSpawned > amountSpawned)
            {
                float zSpawn = transform.position.z;
                GameObject temp = Instantiate(selectedEnemy, new Vector3(transform.position.x , transform.position.y, zSpawn ), Quaternion.identity);
                temp.transform.parent = transform;
                temp.name = selectedEnemy.ToString() + amountSpawned;
                delay = 0;
                amountSpawned++;
            }   
            delay += Time.deltaTime;
        }
    }
    
}