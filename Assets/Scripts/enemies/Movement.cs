using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float movementSpeed = 0.1f; 

    public GameObject hq;
    void Start()
    {
        hq = GameObject.FindWithTag("HQ");
    }

    void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(hq.transform.position.x,transform.position.y, transform.position.z), movementSpeed*Time.deltaTime);
        }
    }
