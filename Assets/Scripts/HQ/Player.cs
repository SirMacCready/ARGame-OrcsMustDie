using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public HealthBar hp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            TakeDamage(10); // Example damage value
        }
    }

    void TakeDamage(int damage)
    {
        hp.SetHealth(hp.GetHealth() - damage);
        // Implement damage logic here
        Debug.Log("Player took " + damage + " damage.");
    }
}
