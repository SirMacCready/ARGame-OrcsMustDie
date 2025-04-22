using System;
using UnityEngine;

namespace HQ
{
    public class HP : MonoBehaviour
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
                Time.timeScale = 0f;
            }
                
        }

        private void OnTriggerEnter(Collider other)
        {
            TakeDamage(other.gameObject.GetComponent<Attack>().attackValue);
            Destroy(other.gameObject);
        }
    }
}