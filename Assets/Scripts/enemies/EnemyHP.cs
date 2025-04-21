
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    private int _currentHealth;
    public int maxHealth;
    public int GoldValue;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    // Update is called once per frame
}
