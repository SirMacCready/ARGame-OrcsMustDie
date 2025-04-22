using UnityEngine;

public class ObjectSpawning : MonoBehaviour
{
    public GameObject barricadePrefab;
    public GameObject balistaPrefab;

    public float doubleTapThreshold = 0.3f;
    private float lastTapTime = 0f;

    public LayerMask terrainAndStructureLayer;

    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            float timeSinceLastTap = Time.time - lastTapTime;

            if (timeSinceLastTap <= doubleTapThreshold)
            {
                OnDoubleTap();
                lastTapTime = 0f; // reset
            }
            else
            {
                lastTapTime = Time.time;
                Invoke(nameof(DelayedSingleTapCheck), doubleTapThreshold);
            }
        }
    }

    void DelayedSingleTapCheck()
    {
        if (Time.time - lastTapTime >= doubleTapThreshold)
        {
            OnSingleTap();
        }
    }

    void OnSingleTap()
    {
        TrySpawn(barricadePrefab);
    }

    void OnDoubleTap()
    {
        TrySpawn(balistaPrefab);
    }

    void TrySpawn(GameObject prefab)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.unityLogger.Log("TrySpawn", ray);
        if (Physics.Raycast(ray, out hit, 100f, terrainAndStructureLayer))
        {
            Instantiate(prefab, hit.point, Quaternion.identity);
            Debug.Log($"Spawned {prefab.name} at {hit.point}");
        }
        else
        {
            Debug.Log("Aucun point valide touché pour le spawn.");
        }
    }
}