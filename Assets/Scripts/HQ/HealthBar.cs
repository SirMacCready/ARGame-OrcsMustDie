using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public int health = 100; // Health value, can be set to any value between 0 and 100
    private int maxHealth = 100; // Maximum health value
    private bool gameLost = false; // Flag to check if the game is lost
    public Slider slider;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("HealthBar script started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxHealth(int hlth){
        slider.maxValue = health;
        slider.minValue = 0;
    }

    public int GetHealth(){
            return health; // Return the current health value
        }
    public int GetMaxHealth(){
            return maxHealth; // Return the maximum health value
    }
    public void SetHealth(int health){
        this.health = health;
        slider.value = health; // Update the slider value to reflect the current health
        Debug.Log("Health set to: " + health);
    }
    public void SetGameLost(bool dead){
        gameLost = dead;
    }
    public bool GetGameLost(){
        return gameLost;
    }
}
