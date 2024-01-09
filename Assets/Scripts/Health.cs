using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    const string PlayerHurt = "Hurt";
    const string PlayerIdle = "Idle";

    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;

    private string _currentState;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void IncreaseHealth(int healthToIncrease)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + healthToIncrease, 0, _maxHealth);
    }

    public void TakeDamage(float damageAmount)
    {
        _currentHealth -= damageAmount;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
