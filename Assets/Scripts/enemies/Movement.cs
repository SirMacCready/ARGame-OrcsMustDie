using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 1.0f; 

    public GameObject hq;
    public GameObject self;
    void Start()
    {
        hq = GameObject.FindWithTag("HQ");
    }

    void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(hq.transform.position.x,transform.position.y, transform.position.z), movementSpeed * Time.deltaTime);
        }
    }
