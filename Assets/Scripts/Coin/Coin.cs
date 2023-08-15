using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Coin : MonoBehaviour
{
    const string COIN_IDLE = "Idle";

    [SerializeField] private int _amount = 1;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _animator.Play(COIN_IDLE);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Wallet wallet))
        {
            wallet.AddMoney(_amount);
            Destroy(gameObject);
        }
    }
}
