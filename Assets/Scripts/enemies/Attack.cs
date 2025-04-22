using HQ;
using UnityEditor.AssetImporters;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackValue = 1;
    public HP target ;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("HQ"))
        {
            target.TakeDamage(attackValue);
            Destroy(gameObject);
            print("solong");
        }
    } 

}
