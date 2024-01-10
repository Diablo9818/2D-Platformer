using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;

    [SerializeField] private Slider _healthBar;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _healthBar.maxValue = _maxHealth;
        _healthBar.value = _currentHealth;
    }

    public void IncreaseHealth(int healthToIncrease)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + healthToIncrease, 0, _maxHealth);
        _healthBar.value = _currentHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        _currentHealth -= damageAmount;
        _healthBar.value = _currentHealth;
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
