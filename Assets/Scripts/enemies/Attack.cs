using HQ;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackValue = 1;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HQ"))
        {
            other.gameObject.GetComponent<HQHP>().TakeDamage(attackValue);
            Destroy(gameObject);
        }
    } 

}
