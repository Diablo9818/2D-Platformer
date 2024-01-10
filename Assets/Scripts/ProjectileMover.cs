using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileMover : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] protected float _damageAmount;

    private Rigidbody2D _rigidbody2D;
    private float _timeToDestroy = 2f;
    private WaitForSeconds _waitToDestroy;

    private void Awake()
    {
        _waitToDestroy = new WaitForSeconds(_timeToDestroy);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody2D.velocity = transform.right * _speed;
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return _waitToDestroy;
        Destroy(gameObject);
    }
}
