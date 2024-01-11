using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VamireAbility : MonoBehaviour
{
    [SerializeField] private float _abilityDuration = 6f;
    [SerializeField] private int _healthAmount;

    private bool _isAbilityActive = false;
    private EnemyHealth _target;
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponentInParent<PlayerHealth>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y)) 
        {
            ActivateAbility();
        }

        if (_isAbilityActive)
        {
            if (_target != null)
            {
                DrainHealth(_healthAmount);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            _target = enemyHealth;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            _target = null;
        }
    }

    private void DrainHealth(int healthAmount)
    {
        _target.TakeDamage(healthAmount);
        _playerHealth.IncreaseHealth(healthAmount);

    }

    private void ActivateAbility()
    {
        _isAbilityActive = true;
        Invoke(nameof(DeactivateAbility), _abilityDuration);
    }

    private void DeactivateAbility()
    {
        _isAbilityActive = false;
        Debug.Log("Ability is Deactivated");
    }
}
