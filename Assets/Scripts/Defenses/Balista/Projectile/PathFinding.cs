using UnityEngine;

public class PathFinding : MonoBehaviour
{
    private float _speed = 10f;
    private Transform _target;
    private int Damage = 1;

    public void SetTarget(Transform newTarget)
    {
        _target = newTarget;
    }

    void Update()
    {
        if (_target != null)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            transform.position += direction * _speed * Time.deltaTime;
            transform.LookAt(_target);

            if (Vector3.Distance(transform.position, _target.position) < 0.1f)
            {
                EnemyHP enemyHP = _target.GetComponent<EnemyHP>();
                if (enemyHP != null)
                {
                    enemyHP.takeDamage(Damage);
                }
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}