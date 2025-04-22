using UnityEngine;

namespace HQ
{
    public class HQHP : MonoBehaviour
    {
        public float maxHealth ; 
        public float currentHealth ;
        [SerializeField] private AudioClip damageSoundClip;
        [SerializeField] private AudioClip deathSoundClip;
        
        private void Start()
        {
            maxHealth = 10;
            currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (currentHealth - damage <= 0)
            {
                SFXManager.instance.PlaySFX(deathSoundClip, transform, 1f);
                Debug.Log("dead");
            }
            else
            {
                currentHealth -= damage;
                SFXManager.instance.PlaySFX(damageSoundClip, transform, 1f);   
            }
            
                
        }public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                TakeDamage(other.gameObject.GetComponent<Attack>().attackValue);
                Destroy(other.gameObject);
            }
        } 
    }
}