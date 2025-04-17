using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public int health = 100; // Health value, can be set to any value between 0 and 100
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
    public void SetHealth(int health){
        this.health = health;
        slider.value = health; // Update the slider value to reflect the current health
        Debug.Log("Health set to: " + health);
    }
}
