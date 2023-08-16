using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerHealth: MonoBehaviour
{
    const string PlayerHurt = "Hurt";
    const string PlayerIdle = "Idle";

    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private Animator _animator;

    private string _currentState;

    private void Awake()
    {
        maxHealth = 3;
        currentHealth = maxHealth;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void ChangeAnimationState(string newState)
    {
        if (_currentState == newState)
        {
            return;
        }
        _animator.Play(newState);
        _currentState = newState;
    }

    public void TakeDamage(float damageAmount)
    {
        ChangeAnimationState(PlayerHurt);
        currentHealth -= damageAmount;
        ChangeAnimationState(PlayerIdle);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
