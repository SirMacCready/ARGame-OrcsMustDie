using UnityEditor.Embree;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public HealthBar hp;
    private float timer = 5f;
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
        }else {
            if(timer <= 0){
                if(hp.GetGameLost()){
                    return;
                }
                TakePotion(5); // Example potion value
                timer = 5f; // Reset the timer
            }else {
                timer -= Time.deltaTime;

            }
        }
        // if(Keyboard.current.pKey.wasPressedThisFrame)
        // {
        //     TakePotion(10); // Example potion value
        // }
    }

    void TakeDamage(int damage)
    {
        if(hp.GetGameLost()){
            Debug.Log("Player is already dead.");
            return;
        }
        if(hp.GetHealth() - damage <= 0){
            hp.SetHealth(0); // Set health to 0
            hp.SetGameLost(true); // Set game lost flag to true
            Debug.Log("Player is dead.");
            return; // Player is already dead
        }
        hp.SetHealth(hp.GetHealth() - damage);
        // Implement damage logic here
        Debug.Log("Player took " + damage + " damage.");
    }

    void TakePotion(int point){
        if(hp.GetGameLost()){
            Debug.Log("Player is already dead.");
            return;
        }
        if(hp.GetHealth() == hp.GetMaxHealth()){
            return;
        }
        if(hp.GetHealth() + point >= hp.GetMaxHealth()){
            hp.SetHealth(hp.GetMaxHealth()); // Set health to max
            return;
        }
        hp.SetHealth(hp.GetHealth() + point);
    }


}
