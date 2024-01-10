using UnityEngine;

public class PlayerProjectileMover : ProjectileMover
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(_damageAmount);
            Destroy(gameObject);
        }
    }
}
