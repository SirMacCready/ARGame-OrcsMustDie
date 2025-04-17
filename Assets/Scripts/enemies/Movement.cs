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
        self = GameObject.FindWithTag("Enemy");
    }

    void Update()
        {
        }
    }
