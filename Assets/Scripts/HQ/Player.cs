using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10); // Example damage value
        }
    }

    void TakeDamage(int damage)
    {
        // Implement damage logic here
        Debug.Log("Player took " + damage + " damage.");
    }
}
