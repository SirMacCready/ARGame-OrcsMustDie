using UnityEngine;

public class DefensePlacer : MonoBehaviour
{
    // Ce qu'on va poser
    public GameObject barricadePrefab;
    
    // Le sol où on peut poser
    public LayerMask groundLayer;

    // Mode placement activé ?
    private bool isPlacing = false;

    // Appelée depuis le bouton UI
    public void ActivatePlacement()
    {
        isPlacing = true;
    }

    void Update()
    {
        if (!isPlacing) return;

        // Clic gauche dans la scène
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Vérifie si on clique sur le sol (Layer "Ground")
            if (Physics.Raycast(ray, out hit, 100f, groundLayer))
            {
                // Légère élévation pour ne pas coller au sol
                Vector3 spawnPos = hit.point;
                spawnPos.y += 0.1f; 

                Instantiate(barricadePrefab, spawnPos, Quaternion.identity);
                // Fin du placement
                isPlacing = false;
            }
        }
    }
}