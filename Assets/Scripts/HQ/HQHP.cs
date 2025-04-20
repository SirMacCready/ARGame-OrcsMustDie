using UnityEngine;

namespace HQ
{
    public class HQHP : MonoBehaviour
    {
        public float maxHealth ; 
        public float currentHealth ;
        private void Start()
        {
            maxHealth = 10;
            currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Debug.Log("dead");
            }
                
        }
    }
}