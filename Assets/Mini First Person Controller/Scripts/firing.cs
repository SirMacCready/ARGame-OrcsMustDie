using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonLookAndFire : MonoBehaviour
{
    [Header("Firing")]
    public InputActionReference fireAction;

    /// <summary> Functions to override firing behavior. Will use the last added override. </summary>
    public List<System.Action> fireOverrides = new List<System.Action>();

    void OnEnable()
    {
        fireAction.action.performed += OnFire;
        fireAction.action.Enable();
    }

    void OnDisable()
    {
        fireAction.action.performed -= OnFire;
        fireAction.action.Disable();
    }

    void OnFire(InputAction.CallbackContext context)
    {
        // Handle firing logic here.
        if (fireOverrides.Count > 0)
        {
            fireOverrides[fireOverrides.Count - 1]();
        }
        else
        {
            Fire();
        }
    }

    void Fire()
    {
        // Implement your firing logic here.
        Debug.Log("Fired!");
    }
    
}