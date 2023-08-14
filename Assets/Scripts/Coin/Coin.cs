using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Coin : MonoBehaviour
{
    [SerializeField] private int amount = 1;
    private Animator animator;

    const string COIN_IDLE = "Idle";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.Play(COIN_IDLE);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Wallet wallet = collision.GetComponent<Wallet>();

        if (wallet != null)
        {
            wallet.AddMoney(amount);
            Destroy(gameObject);
        }
    }
}
