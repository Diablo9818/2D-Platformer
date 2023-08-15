using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]

public class ProjectileMove : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] private float _damageAmount;

    private Rigidbody2D _rigidbody2D;
    private float _timeToDestroy = 2f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

        if(playerHealth != null )
        {
            playerHealth.TakeDamage(_damageAmount);
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        _rigidbody2D.velocity = transform.right * _speed;
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_timeToDestroy);
        Destroy(gameObject);
    }
}
