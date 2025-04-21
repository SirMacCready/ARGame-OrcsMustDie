using UnityEngine;
using Defenses;
public class Movement : MonoBehaviour
{
    private float movementSpeed;  
    public float maxspeed;

    public GameObject target;
    private float factor;
    private void SlowedDown(float factor)
    {
            
        movementSpeed /= factor;
    }
    void Start()
    {
        movementSpeed = maxspeed;
        target = GameObject.FindWithTag("HQ");
    }

    void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x,target.transform.position.y, target.transform.position.z), movementSpeed*Time.deltaTime);
            transform.LookAt(target.transform);
        }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Defense"))
        {
            print("slowed down");
            factor = other.gameObject.GetComponent<SlowDown>().slowdownfactor;
            SlowedDown(factor);
        }
        else
        {
            movementSpeed = maxspeed;
        }
    }
    }
