using UnityEngine;

public class Targetting : MonoBehaviour
{
  
    public float rotationSpeed = 5f;
    public float detectionRange = 10f;

    private float fireCoolDown;
    private Transform target;
    private GameObject[] enemies;
    
    public GameObject projectile;
    private int amountSpawned = 0;
    void Start()
    {
    }

    void Update()
    {
        FindTarget();
        RotateTurret(); 
        Fire(); 
    }

    void FindTarget()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); 
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        
        foreach (GameObject enemy in enemies)
        {   

            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && distanceToEnemy <= detectionRange)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        target = nearestEnemy != null ? nearestEnemy.transform : null; 
    }

    void RotateTurret()
    {
        if (target != null)
        {
            Vector3 targetDirection = target.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void Fire()
    {
        if (target != null && Vector3.Distance(transform.position, target.position) <= detectionRange && fireCoolDown < 0)
        {
            GameObject temp = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            temp.transform.parent = transform;
            temp.name = "Projectile" + amountSpawned;

            // Pass the target to the projectile
            PathFinding projectileScript = temp.GetComponent<PathFinding>();
            if (projectileScript != null)
            {
                projectileScript.SetTarget(target);
            }

            fireCoolDown = 3;
            amountSpawned++;
        }
        fireCoolDown -= Time.deltaTime;
    }
}