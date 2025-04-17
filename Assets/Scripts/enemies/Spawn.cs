using UnityEngine;
namespace enemies
{
    public class Spawn : MonoBehaviour
    {
        public GameObject spawnPoint;
        private float delay;
        private int amountSpawned;
        private int maxAmountSpawned = 5;
        public GameObject Orc;
        
        private void Start()
        {
            delay = 3;
            amountSpawned = 0;
            spawnPoint = GameObject.FindWithTag("SpawnPoint");
            
        }

        void Update()
        {
            if (delay >= 5 && maxAmountSpawned > amountSpawned){
                GameObject temp = Instantiate(Orc, new Vector3(spawnPoint.transform.position.x,spawnPoint.transform.position.y ,Random.Range(spawnPoint.transform.lossyScale.z/-2, spawnPoint.transform.lossyScale.z/2)), Quaternion.identity);
                temp.transform.parent = spawnPoint.transform;
                temp.name = "Orc" + amountSpawned;
                delay = 0;
                amountSpawned++;
                print(delay);
            }   
            print(delay);
            delay += Time.deltaTime;
        }
    }
    
}