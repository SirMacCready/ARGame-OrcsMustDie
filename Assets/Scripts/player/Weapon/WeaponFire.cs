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
    void Start()
    {
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
        Debug.Log("FIRE button pressed");

        if (Physics.Raycast(transform.position, transform.forward, out var hit, weaponRange))
        {
            Debug.Log("Raycast hit: " + hit.transform.name);

            if (hit.transform.CompareTag("Enemy"))
            {
                Debug.Log("Enemy tagged object hit");

                EnemyHP enemyHP = hit.transform.GetComponent<EnemyHP>();
                if (enemyHP == null)
                {
                    Debug.LogError("No EnemyHP script found!");
                    return;
                }

                Debug.Log("EnemyHP found, applying damage...");
                enemyHP.TakeDamage(damage);
            }
            else
            {
                Debug.Log("Hit object is NOT tagged as Enemy");
            }
        }
        else
        {
            Debug.Log("Raycast missed");
        }
    }

}