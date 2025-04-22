
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    private int _currentHealth;
    public int maxHealth;
    public int GoldValue;
    [SerializeField] private AudioClip damageSoundClip;
    [SerializeField] private AudioClip deathSoundClip;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (_currentHealth - amount <= 0)
        {
            SFXManager.instance.PlaySFX(deathSoundClip, transform, 1f);
            Destroy(gameObject);   
        }
        else
        {
            _currentHealth -= amount;
            SFXManager.instance.PlaySFX(damageSoundClip, transform, 1f);    
        }
    }

    // Update is called once per frame
}
