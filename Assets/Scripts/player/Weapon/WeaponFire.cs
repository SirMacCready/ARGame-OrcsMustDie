using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class WeaponFire : MonoBehaviour
{
    public Button fireButton;
    public float weaponRange = 100f; // The range of the weapon
    public int damage = 100; // The damage the weapon will deal
    public ARRaycastManager arRaycastManager;
    public LayerMask enemyLayer; // The layer that enemies are on
    public LayerMask playerLayer;
    void Start()
    {
        // Add a listener to the button and call the FireWeapon method when clicked
        if (fireButton != null)
        {
            fireButton.onClick.AddListener(FireWeapon);
            print("Button listener added");
        }
        else
        {
            print("FireButton is not assigned");
        }
    }

    void Update()
    {
        
        Debug.DrawRay(transform.position, transform.forward*weaponRange, Color.red);
    }

    void FireWeapon()
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.red, 50f);
        Ray ray  = Camera.main.ScreenPointToRay(Vector3.forward);

        int layer_mask = LayerMask.GetMask("Enemy");
        if (Physics.Raycast(transform.position,transform.forward,out var hit))
        {
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                EnemyHP enemyHP = hit.transform.GetComponent<EnemyHP>();
                enemyHP.TakeDamage(damage);
            }
            
            
        }
    }
}