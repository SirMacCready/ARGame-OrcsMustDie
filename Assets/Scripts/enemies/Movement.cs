using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed; 

    public GameObject target;
    void Start()
    {
        target = GameObject.FindWithTag("HQ");
    }

    void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x,transform.position.y, transform.position.z), movementSpeed*Time.deltaTime);
        }
    }
