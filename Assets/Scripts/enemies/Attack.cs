using HQ;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackValue = 1;
    public HP hq ;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("HQ"))
        {
            hq.TakeDamage(attackValue);
            Destroy(gameObject);
            print("solong");
        }
    } 

}
