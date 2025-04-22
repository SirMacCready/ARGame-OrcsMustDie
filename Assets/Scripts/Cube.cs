using UnityEngine;
// using stats;
public class Cube : MonoBehaviour
{

    public int hp = 0;
    public int damage = 0;
    public int timer = 1;// in sec
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer == 10){
            hp = hp - 1;
            Debug.Log("hp: " + hp);
        }

        transform.Rotate(0, 1 * Time.deltaTime * 100, 0);
    }
}
