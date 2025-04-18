using UnityEngine;

public class DefenseSelector : MonoBehaviour
{

    public GameObject barricadePrefab;

    public void PlaceBarricade()
    {
        Vector3 spawnPos = new Vector3(0, 0.1f, 0);
        Instantiate(barricadePrefab, spawnPos, Quaternion.identity);
    }
}
