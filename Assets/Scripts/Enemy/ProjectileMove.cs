using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileMove : MonoBehaviour
{
    [SerializeField] float _speed;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float damageAmount;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

        if(playerHealth != null )
        {
            playerHealth.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        _rigidbody2D.velocity = transform.right * _speed;
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
