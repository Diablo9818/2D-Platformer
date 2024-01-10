using UnityEngine;

public class EnemyProjectileMover : ProjectileMover
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

        if(playerHealth != null )
        {
            playerHealth.TakeDamage(_damageAmount);
            Destroy(gameObject);
        }
    }
}
