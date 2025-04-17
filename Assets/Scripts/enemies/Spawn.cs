using UnityEngine;
namespace enemies
{
    public class Spawn : MonoBehaviour
    {
        public GameObject spawnPoint;
        private float delay;
        private int amountSpawned;
        
        private void Start()
        {
            delay = 3;
            amountSpawned = 0;
            spawnPoint = GameObject.FindWithTag("SpawnPoint");
            
        }

        void Update()
        {
            if (delay >= 1){
                GameObject temp = Instantiate(spawnPoint, new Vector3(0*5,0 ,Random.Range(-10, 10)), Quaternion.identity);
                temp.name = "Orc" + amountSpawned.ToString();
                delay = 0;
                amountSpawned++;
                print(delay);
            }   
            print(delay);
            delay += Time.deltaTime;
        }
    }
    
}