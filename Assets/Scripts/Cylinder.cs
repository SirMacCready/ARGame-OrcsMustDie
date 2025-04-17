using UnityEngine;

public class Cylinder : MonoBehaviour 
{
    public string name = "uwu";
    void Start(){
        
    }
    void Update(){
        transform.Rotate(0, 0, 1 * Time.deltaTime * 100);
    }
    
}
